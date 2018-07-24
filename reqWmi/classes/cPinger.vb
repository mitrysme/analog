Imports System.Net.NetworkInformation

' plus utilisé +> ping async 
Public Class cPingerDeprecated
    Private _stationName As String
    Private _active As Boolean = True
    Private _sent As Integer = 0
    Private _lost As Integer = 0
    Private _averageRoundtrip As Integer = 0
    Private _oPing As Ping
    Private _aRoundTrip As New List(Of Integer)
    Private _lastFivePings As New List(Of Boolean)
    Private _baPingBuffer() As Byte
    Private _deg As [Delegate]
    Private _control As Control
    '
    Public Const MAX_LV_PING_HISTORY As UShort = 10800 ' 3heures histo dans frmmain.lvping

    'Public Event pingLost()

    Public Sub New(ByVal stationName As String, _
                   ByRef control As Control, _
                   ByRef deg As [Delegate], _
                    Optional ByVal intPingBufferLength As Integer = 32)
        _control = control
        _deg = deg
        _stationName = stationName
        setPingBuffer(intPingBufferLength)
        _oPing = New Ping
    End Sub

    Public Sub startPing()
        Dim text As String
        Dim errMsg As String = ""
        Dim reply As System.Net.NetworkInformation.PingReply = Nothing
        Dim bPingOk As Boolean
        Dim pingResults As New pingResults
        ' Dim test As [Delegate] = 

        ' test += AddressOf (_frmToUpdate.updatePing)

        'Dim deg = New _frmToUpdate._degUpdatePing(AddressOf program.frmMain.updatePing)

        ' Dim deg = New _frm._degUpdatePing

        While _active
            bPingOk = network.getPingTime(_stationName, errMsg, reply, _oPing, _baPingBuffer)
            _sent += 1

            If Not bPingOk Then ' exception lors de ping.send
                _lost += 1
                updateLastFivePings(False)
                text = errMsg
            Else
                Select Case reply.Status
                    Case IPStatus.Success
                        updateLastFivePings(True)

                        ' calcul moyenne roundtrip
                        _aRoundTrip.Add(CInt(reply.RoundtripTime))

                        Dim roundTrip As String = reply.RoundtripTime.ToString
                        If roundTrip = "0" Then roundTrip = "<1"

                        text = String.Format("réponse de {0} : octets {1} {2} {3} ms", reply.Address.ToString, reply.Buffer.Count, reply.Status.ToString, roundTrip)
                    Case Else
                        _lost += 1
                        updateLastFivePings(False)
                        text = reply.Status.ToString
                End Select
            End If

            If _active Then
                With pingResults
                    .text = text
                    .sent = _sent
                    .lost = _lost
                    .avgRoundtripTime = getRoundtripTimeAvg()
                    .maxRoundtrip = getMaxRoundTrip()
                    .minRoundTrip = getMinRoundtrip()
                    .lostPercentage = getLostPercentage()
                End With

                'If Not _control.Disposing Then
                _control.BeginInvoke(_deg, pingResults)
                'End If

                ' _deg.DynamicInvoke(

                '_.BeginInvoke(deg, pingResults)
            End If

            ' TODO pas joli la petite sieste ....
            ' TODO => utiliser PingAsync
            Threading.Thread.Sleep(1000)
        End While

        Return
    End Sub

    Public Sub stopPing()
        _active = False
        _oPing.Dispose()
        SyncLock (_aRoundTrip)
            _aRoundTrip.Clear()
        End SyncLock
    End Sub

    Public Structure pingResults
        Public text As String
        Public sent As Integer
        Public lost As Integer
        Public lostPercentage As Double ' pourcentage de perte de paquets
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
                If _maxRoundtrip <= 0 Then
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
                If _minRoundtrip <= 0 Then
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

    Public Sub resetPingData()
        If Not _active Then Exit Sub

        _sent = 0
        _lost = 0
        _averageRoundtrip = 0

        SyncLock _aRoundTrip
            _aRoundTrip.Clear()
        End SyncLock
        SyncLock _lastFivePings
            _lastFivePings.Clear()
        End SyncLock
    End Sub

    Public Sub changeBufferSize(ByVal intBufferSize As Integer)
        setPingBuffer(intBufferSize)
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

    Private Sub setPingBuffer(ByVal intBufferLength As Integer)
        Dim sBuffer As String = Analog.functions.misc.CreateAleatoire(intBufferLength)

        _baPingBuffer = System.Text.Encoding.ASCII.GetBytes(sBuffer)
    End Sub

    ''' <summary>
    ''' Retourne délai ping mini dans collection
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' lock car collection peut être effacée par méthode stopPing appelée depuis thread UI ( race )
    ''' </remarks>
    Private Function getMinRoundtrip() As Long
        If _aRoundTrip.Count > 0 Then
            Return _aRoundTrip.Min
        Else
            Return 0
        End If
    End Function

    ''' <summary>
    ''' Retourne délai ping max dans collection
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    Private Function getMaxRoundTrip() As Long
        If _aRoundTrip.Count > 0 Then
            Return _aRoundTrip.Max
        Else
            Return 0
        End If
    End Function

    Private Function getLostPercentage() As Double
        If Not _sent = 0 Or _lost = 0 Then
            Return (_lost * 100) / (_sent + _lost)
        Else
            Return 0
        End If
    End Function



End Class
