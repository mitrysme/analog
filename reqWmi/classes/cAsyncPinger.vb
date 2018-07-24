Imports System.Net.NetworkInformation

Public Class cAsyncPinger
    Private _stationName As String
    Private _tmr As Timers.Timer
    Private _pingSender As Ping
    Private _timeout As Integer
    Private _sent As Integer = 0
    Private _lost As Integer = 0
    Private _averageRoundtrip As Integer = 0
    Private _maxRoundtrip As Integer = 0
    Private _minRoundTrip As Integer = 0
    Private _aRoundTrip As New List(Of Integer)
    Private _listOfPingData As New List(Of pingData)
    Private _lastFivePings As New List(Of Boolean)
    Private _buffer() As Byte
    Private _deg As [Delegate]
    Private _control As Control ' frmMain.lvping
    Private _lock As New Object
    Private _canceled As Boolean = False
    Private _bsetPingdata As Boolean = True ' pas de stockage détail ping si false ( imprimantes )

    Public Const MAX_LV_PING_HISTORY As UShort = 1800 ' 1/2 heure histo dans frmmain.lvping

    Public Property bsetPingData() As Boolean
        Get
            Return _bsetPingdata
        End Get
        Set(ByVal value As Boolean)
            _bsetPingdata = value
        End Set
    End Property

    Public Sub New(ByVal stationName As String,
                   ByRef control As ListView,
                   ByRef deg As [Delegate],
                   Optional ByVal intPingBufferLength As Integer = 32)

        _tmr = New Timers.Timer(1000) ' ping toutes les secondes
        _tmr.AutoReset = False
        _stationName = stationName
        _pingSender = New Ping
        _timeout = program.preferences.uintPingTimeout
        _control = control
        _deg = deg

        _buffer = getBufferData(intPingBufferLength)
    End Sub

    Public Enum pingBufferDataLenght As UShort
        pingNormal = 32
        pingLong = 1400
    End Enum

    Public Structure pingResults
        Public text As String
        Public sent As Integer
        Public lost As Integer
        Public lostPercentage As Double
        Private _avgRoundtripTime As Double
        Private _maxRoundtrip As Double
        Private _minRoundtrip As Double

        Public Property avgRoundtripTime() As Double
            Get
                If _avgRoundtripTime <= 0 Then
                    Return 1
                Else
                    Return _avgRoundtripTime
                End If
            End Get
            Set(ByVal value As Double)
                _avgRoundtripTime = value
            End Set
        End Property
        Public Property maxRoundtrip() As Double
            Get
                If _maxRoundtrip < 1 Then
                    Return 1
                Else
                    Return _maxRoundtrip
                End If
            End Get
            Set(ByVal value As Double)
                _maxRoundtrip = value
            End Set
        End Property
        Public Property minRoundTrip() As Double
            Get
                If _minRoundtrip < 1 Then
                    Return 1
                Else
                    Return _minRoundtrip
                End If
            End Get
            Set(ByVal value As Double)
                _minRoundtrip = value
            End Set
        End Property
    End Structure

    Public Structure pingData
        Private _dateSent As DateTime
        Private _roundTripTime As Nullable(Of Integer)
        Private _address As String
        Private _bufferLenght As Integer

        Public ReadOnly Property datesent() As Date
            Get
                Return _dateSent
            End Get
        End Property
        Public ReadOnly Property roundTripTime() As Nullable(Of Integer)
            Get
                Return _roundTripTime
            End Get
        End Property
        Public ReadOnly Property address() As String
            Get
                Return _address
            End Get
        End Property
        Public ReadOnly Property bufferLenght() As Integer
            Get
                Return _bufferLenght
            End Get
        End Property

        Public Sub New(ByVal rtt As Nullable(Of Integer), ByVal address As String, ByVal bufferLenght As Integer)
            _dateSent = Date.Now
            _roundTripTime = rtt
            _address = address
            _bufferLenght = bufferLenght
        End Sub
    End Structure

    Public Sub startPing()
        _tmr.Start()

        AddHandler _tmr.Elapsed, AddressOf pingAsync
        AddHandler _pingSender.PingCompleted, AddressOf pingCompletedCallback
    End Sub

    Public Sub pingAsync(ByVal sender As Object, ByVal e As System.EventArgs)
        _pingSender.SendAsync(_stationName, _timeout, _buffer, New Object)
    End Sub

    Public Function getNewDataArray() As List(Of pingData)
        Dim pingDataList As New List(Of pingData)

        SyncLock _listOfPingData
            For Each pdata As pingData In _listOfPingData
                pingDataList.Add(pdata)
            Next
        End SyncLock

        Return pingDataList
    End Function

    Public Shared Function filterPingData(ByVal filterTimeout As Boolean, _
                                          ByVal filterByDate As Boolean, _
                                          ByRef pingdata As List(Of pingData), _
                                          Optional ByVal datefrom As DateTime = Nothing, _
                                          Optional ByVal todate As DateTime = Nothing) As List(Of pingData)

        Dim tempPingData As New List(Of pingData)

        For Each pdata As pingData In pingdata
            If filterTimeout Then
                If pdata.roundTripTime Is Nothing Then
                    If filterByDate Then
                        If Not isPingDataFiltered(datefrom, todate, pdata) Then
                            tempPingData.Add(pdata)
                        End If
                    Else
                        tempPingData.Add(pdata)
                    End If
                End If
            ElseIf filterByDate Then
                If Not isPingDataFiltered(datefrom, todate, pdata) Then
                    tempPingData.Add(pdata)
                End If
            End If
        Next

        Return tempPingData
    End Function

    Private Shared Function isPingDataFiltered(ByRef datefrom As DateTime, _
                                               ByRef todate As DateTime, _
                                               ByRef pingdata As cAsyncPinger.pingData) As Boolean

        Dim resultDateFrom, resultDateTo As Integer

        resultDateFrom = DateTime.Compare(pingdata.datesent, datefrom)
        resultDateTo = DateTime.Compare(pingdata.datesent, todate)

        Return Not (resultDateFrom > 0 And resultDateTo < 0)
    End Function

    Private Sub addPingDataSynchronized(ByVal pingdata As pingData)
        SyncLock _listOfPingData
            _listOfPingData.Add(pingdata)
        End SyncLock
    End Sub

    Private Sub pingCompletedCallback(ByVal sender As Object, _
                                      ByVal e As PingCompletedEventArgs)

        Static pingresults As New pingResults
        Dim text As String = String.Empty
        Dim pingReply As PingReply

        _sent += 1

        If e.Reply Is Nothing Then
            If _bsetPingdata Then
                addPingDataSynchronized(New pingData(Nothing, Nothing, Nothing))
            End If

            _lost += 1
            text = e.Error.InnerException.Message
        Else
            pingReply = e.Reply

            If Not pingReply.Status = IPStatus.Success Then
                If _bsetPingdata Then
                    addPingDataSynchronized(New pingData(Nothing, Nothing, Nothing))
                End If

                _lost += 1
                updateLastFivePings(False)
                text = pingReply.Status.ToString
            Else
                updateLastFivePings(True)
                If _bsetPingdata Then
                    addPingDataSynchronized(New pingData(CInt(pingReply.RoundtripTime), pingReply.Address.ToString, pingReply.Buffer.Count))
                End If

                _aRoundTrip.Add(CInt(pingReply.RoundtripTime))

                setMinMaxRoundtrip(pingReply.RoundtripTime)

                Dim roundTrip As String
                If pingReply.RoundtripTime = 0 Then
                    roundTrip = "<1"
                Else
                    roundTrip = pingReply.RoundtripTime.ToString
                End If

                text = String.Format("réponse de {0} : octets {1} {2} {3} ms", pingReply.Address.ToString, pingReply.Buffer.Count, pingReply.Status.ToString, roundTrip)
            End If
        End If

        With pingresults
            .text = text
            .sent = _sent
            .lost = _lost
            .avgRoundtripTime = getRoundtripTimeAvg()
            .maxRoundtrip = _maxRoundtrip
            .minRoundTrip = _minRoundTrip
            .lostPercentage = getLostPercentage()
        End With

        SyncLock _lock
            If _control IsNot Nothing Then
                If _control.IsHandleCreated And Not _control.Disposing And Not _canceled Then
                    Try
                        _control.BeginInvoke(_deg, pingresults) ' deadlock si invoke ...
                    Catch ex As Exception
                        Debug.Print("exception invoke ping")
                    End Try

                    _tmr.Start()
                Else
                    Debug.Print("Ping : invoke impossible => handle du controle non créé .... ")
                End If
            End If
        End SyncLock
    End Sub

    Private Function getBufferData(ByVal intBufferLength As Integer) As Byte()
        Dim sBuffer As String = Analog.functions.misc.CreateAleatoire(intBufferLength)

        Return System.Text.Encoding.ASCII.GetBytes(sBuffer)
    End Function

    Public Sub changeBufferSize(ByVal intBufferSize As Integer)
        _buffer = getBufferData(intBufferSize)
    End Sub

    Private Function getRoundtripTimeAvg() As Double
        Dim totalRoundtripTime As Long = 0
        For Each roundtripValue As Long In _aRoundTrip
            totalRoundtripTime += roundtripValue
        Next

        Return totalRoundtripTime / _aRoundTrip.Count
    End Function

    Private Sub updateLastFivePings(ByVal val As Boolean)
        SyncLock (_lastFivePings)
            If _lastFivePings.Count > 4 Then
                _lastFivePings.RemoveAt(0)
            End If

            _lastFivePings.Add(val)
        End SyncLock
    End Sub

    Private Sub setMinMaxRoundtrip(ByVal rtp As Long)
        If rtp > _maxRoundtrip Then
            _maxRoundtrip = CInt(rtp)
        ElseIf rtp < _minRoundTrip Then
            _minRoundTrip = CInt(rtp)
        End If
    End Sub

    Private Function getLostPercentage() As Double
        If Not _sent = 0 Then
            Return 100 - ((_sent - _lost) / _sent) * 100
        Else
            Return 0
        End If
    End Function

    ''' <summary>
    ''' Retourne vrai si les 5 derniers pings sont OK
    ''' </summary>
    ''' <returns>boolean</returns>
    ''' <remarks>
    ''' </remarks>
    Public Function isPingOk() As Boolean
        SyncLock _lastFivePings
            For Each Val As Boolean In _lastFivePings
                If Not Val Then Return False
            Next
        End SyncLock

        Return True
    End Function

    Public Sub stopPing()
        RemoveHandler _pingSender.PingCompleted, AddressOf pingCompletedCallback
        RemoveHandler _tmr.Elapsed, AddressOf pingAsync

        SyncLock _lock
            _canceled = True

            With _tmr
                .Stop()
                .Enabled = False
                .Dispose()
            End With

            _pingSender.SendAsyncCancel()
            '
            ' a priori probleme de leak si on fait simplement ping.dispose()
            ' voir http://blogs.msdn.com/b/joncole/archive/2005/12/15/debugging-a-memory-leak-in-managed-code_3a00_-ping-_2d00_-sendasync.aspx
            '
            CType(_pingSender, IDisposable).Dispose()

            _deg = Nothing
            _control = Nothing
        End SyncLock

        resetPingData()

        'SyncLock _aRoundTrip
        '    _aRoundTrip.Clear()
        'End SyncLock
    End Sub

    Public Sub resetPingData()
        _sent = 0
        _lost = 0
        _averageRoundtrip = 0

        SyncLock _aRoundTrip
            _aRoundTrip.Clear()
        End SyncLock
        SyncLock _lastFivePings
            _lastFivePings.Clear()
        End SyncLock
        SyncLock _listOfPingData
            _listOfPingData.Clear()
        End SyncLock
    End Sub

    Public Function getPingReport() As String
        Dim txt As String = String.Empty

        If _aRoundTrip.Count > 0 Then
            txt += String.Format("Statistiques ping pour hôte   : {0}", _stationName) & vbNewLine
            txt += String.Format("Paquets envoyés               : {0}", _sent) & vbNewLine
            txt += String.Format("Paquets perdus                : {0}", _lost) & vbNewLine
            txt += String.Format("Temps de réponse Max          : {0} ms", _maxRoundtrip.ToString) & vbNewLine
            txt += String.Format("Temps de réponse Min          : {0} ms", _minRoundTrip.ToString) & vbNewLine
            txt += String.Format("Temps de réponse Moyen        : {0} ms", CInt(getRoundtripTimeAvg()).ToString) & vbNewLine
            txt += String.Format("Pourcentage de perte          : {0} %", getLostPercentage) ' format => double genre 10 chiffres après la virgule => 1 chiffre suffirait ....
        End If

        Return txt
    End Function

End Class
