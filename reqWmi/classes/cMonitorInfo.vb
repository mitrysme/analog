Imports System.Management
Imports System.Text.RegularExpressions

''' <summary>
''' alire 
''' http://www.autoitscript.com/forum/topic/11136-simple-monitor-serial-number-retriever/page__hl__edid
''' http://www.autoitscript.com/forum/topic/17904-get-monitor-information/page__st__20__p__124058#entry124058
''' http://www.autoitscript.com/forum/topic/17904-get-monitor-information/page__st__15
''' </summary>
''' <remarks></remarks>

Public Class cMonitorInfo

    Private _listMonitorEdidInfo As List(Of monitorEdidInfo)
    Private _stationName As String

    Public Structure monitorEdidInfo
        Public monitorName As String
        Public serialNumber As String
        Public displayName As String

        Public Sub New(ByVal valMonitorName As String, _
                       ByVal valSerialNumber As String, _
                       ByVal valDisplayName As String)
            monitorName = valMonitorName
            serialNumber = valSerialNumber
            displayName = valDisplayName
        End Sub
    End Structure

    Public Property listMonitorEdidInfo() As List(Of monitorEdidInfo)
        Get
            Return _listMonitorEdidInfo
        End Get
        Set(ByVal value As List(Of monitorEdidInfo))
            _listMonitorEdidInfo = value
        End Set
    End Property

    Public Sub New(ByVal stationName As String)
        _stationName = stationName
    End Sub

    Public Sub setEdidInfo()
        _listMonitorEdidInfo = getDisplayInfos()
    End Sub

    ''' <summary>
    ''' cherche SN dans chaine EDID
    ''' </summary>
    ''' <param name="EDID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getMonitorSerialFromEDID(ByVal EDID As Byte()) As String
        Dim sMonitorSerial As String = ""
        Dim i As Integer = 0
        Dim serNumOffset As Integer

        For i = 1 To (UBound(EDID) - 4)
            If EDID(i) = 0 And EDID(i + 1) = 0 And EDID(i + 2) = 0 And EDID(i + 3) = 255 And EDID(i + 4) = 0 Then
                serNumOffset = i + 4
            End If
        Next

        If serNumOffset <> 0 Then
            Dim endStr As Boolean

            For i = 1 To 13
                If EDID(serNumOffset + i) = 10 Then
                    endStr = True
                Else
                    If Not endStr Then
                        sMonitorSerial += Chr(EDID(serNumOffset + i))
                    End If
                End If
            Next
        End If

        Return sMonitorSerial
    End Function

    ''' <summary>
    ''' cherche monitor Name  dans chaine EDID
    ''' </summary>
    ''' <param name="EDID"></param>
    ''' <returns>string</returns>
    ''' <remarks></remarks>
    Private Function getMonitorNameFromEDID(ByVal EDID As Byte()) As String
        Dim sMonitorName As String = ""
        Dim i As Integer = 0
        Dim serNumOffset As Integer

        For i = 1 To (UBound(EDID) - 4)
            If EDID(i) = 0 And EDID(i + 1) = 0 And EDID(i + 2) = 252 And EDID(i + 3) = 0 Then
                serNumOffset = i + 3
            End If
        Next

        If serNumOffset <> 0 Then
            Dim endStr As Boolean

            For i = 1 To 13
                If EDID(serNumOffset + i) = 10 Then
                    endStr = True
                Else
                    If Not endStr Then
                        sMonitorName += Chr(EDID(serNumOffset + i))
                    End If
                End If
            Next
        End If

        If String.IsNullOrEmpty(sMonitorName) Then
            sMonitorName = "NA"
        End If

        Return sMonitorName
    End Function

    ''' <summary>
    ''' Retourne list de structure MonitorEdidInfo => infos ecrans , SN , model ,etc
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getDisplayInfos() As List(Of monitorEdidInfo)
        Dim listOfMonitorInfo As New List(Of monitorEdidInfo)
        Dim wd As New Stopwatch

        wd.Start()

        Try
            Dim listOfEdid As Dictionary(Of String, Byte()) = cregistry.getEdidKeys(_stationName)

            For Each edidKey In listOfEdid
                Dim sMonitorSerial As String = getMonitorSerialFromEDID(edidKey.Value)
                Dim sMonitorName As String = getMonitorNameFromEDID(edidKey.Value)
                Dim sDisplayName As String = edidKey.Key
                Dim bDoublon As Boolean = False

                ' Dédoublonnage 
                ' si deux numéros de série identique on passe
                ' TODO => particulièrement horrible de traiter ça ici ....
                If listOfMonitorInfo.Count >= 1 Then
                    For Each mi As monitorEdidInfo In listOfMonitorInfo
                        If mi.serialNumber = sMonitorSerial Then
                            bDoublon = True
                        End If
                    Next
                End If

                ' vire codes de controles 0x00 - 0x1f 
                ' probleme lors de la sauvegarde XML sinon ( exception invalid character )
                sMonitorSerial = Regex.Replace(sMonitorSerial, "[\x00-\x1f]", "")
                sMonitorName = Regex.Replace(sMonitorName, "[\x00-\x1f]", "")
                sDisplayName = Regex.Replace(sDisplayName, "[\x00-\x1f]", "")

                If Not bDoublon Then
                    listOfMonitorInfo.Add(New monitorEdidInfo(sMonitorName, sMonitorSerial, sDisplayName))
                End If

            Next
        Catch ex As Exception
            log.addLogEntry(New cLogEntry("Impossible de récupérer les infos écran", cLogEntry.enumDebugLevel.ERREUR, _stationName, "cMonitorInfo", ex))
        End Try
        wd.Stop()

        'log.addLogEntry(New cLogEntry("Recup infos écrans : " & wd.ElapsedMilliseconds & " ms", cLogEntry.enumDebugLevel.INFO.ToString, _stationName))

        Return listOfMonitorInfo
    End Function
End Class
