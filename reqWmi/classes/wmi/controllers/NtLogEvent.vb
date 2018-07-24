Imports System.Management

Namespace wmi
    Public Class NtLogEvent
        Inherits NtBaseLogEvent

        Public Enum ntLogErrType
            BsodError = 1
            ControllerError = 2
            DiskBlockErrorOnOtherDisk = 4
            DiskBlockErrorOnSystemDisk = 3
            DiskPredictFail = 5
            NetworkError = 6
            ShutdownError = 7
            ftDiskErr = 8
            ntfsErr = 9
            applicationError = 10
            officeError = 11
        End Enum

        ' Private _strucLogErrorCount As Nullable(Of structNtSystemLogErrorCount)

        Public Structure structNtSystemLogErrorCount
            Public iNumDiskBlockErrorOnSystemDisk As Nullable(Of Integer)
            'Public iNumDiskBlockErrorOnOtherDisk As Nullable(Of Integer)
            Public iNumNetworkError As Nullable(Of Integer)
            Public iNumShutdownError As Nullable(Of Integer)
            Public iNumBsobError As Nullable(Of Integer)
            Public iNumControllerError As Nullable(Of Integer)
            Public iNumDiskPredictFail As Nullable(Of Integer)
            Public iNumFtDiskError As Nullable(Of Integer) ' eventId 57 fource ftdisk
            Public iNumNtfsError As Nullable(Of Integer) ' eventId 55 source NTFS
        End Structure

        ''' <summary>
        ''' Constructeur
        ''' </summary>
        ''' <param name="wmiWrapper"></param>
        ''' <remarks></remarks>
        Public Sub New(ByRef wmiWrapper As cwmi)
            MyBase.New(wmiWrapper)
        End Sub


        ''' <summary>
        ''' Sélectionne instances de la classe
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' Ne sélectionne pas les évènements de type "information" sauf dans le cas d'un SAVEDUMP (BSOD)
        ''' </remarks>
        Protected Overrides Function getInstances() As Boolean
            If _wmiWrapper.isConnected Then

                Return _wmiWrapper.getResultsFor(_moc, _
                                          "Win32_NTLogEvent", "Logfile = 'System' and (type <> 'information' or sourcename = 'SAVE DUMP')", _
                                          getWqlProperties())
            End If
        End Function

        ''' <summary>
        ''' renvoie true si Erreur disque se situe sur disque système
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function isErrBlockOnOsInstallDevice(ByRef e As Win32_NTLogEvent, _
                                                           ByVal osInstallDevice As String) As Boolean


            ' testé sur les stations ( caisses ) qui renvoient 0,00 en capacité disque 
            ' osInstalldevice = "" => fonction plante avec index hors limite .... 
            ' FIX : si on ne connait pas le disque systeme on admets que l'erreur se situe sur celui ci 
            If osInstallDevice = String.Empty Then Return True

            Dim sOsInstalldevice = Split(osInstallDevice, "\")(2)
            Dim sErrblockInstallDevice As String = CType(e.InsertionStrings, String())(0)

            sErrblockInstallDevice = Split(sErrblockInstallDevice, "\")(2)

            Return sOsInstalldevice = sErrblockInstallDevice
        End Function

        ' FIXME Doit etre géré pour le mode serveur ....
        Public Sub setNtLogAnalyse(ByRef listOfEvents As List(Of Win32_NTLogEvent), ByVal osInstallDevice As String)
            '_ntLogAnalyse = getNtSystemLogErrorCount(listOfEvents, osInstallDevice)
        End Sub

        ''' <summary>
        ''' Analyse les évènements inscrits dans le log systeme 
        ''' et inscrit  les erreurs recherchées dans structure _ntLogAnalyse
        ''' </summary>
        ''' <remarks>
        ''' Nécessite de remplir Ginfostations avant d'appeler cette fonction car a besoin de osInstallDevice....
        ''' TODO :
        ''' pour les erreurs 55 ( NTFS ) l'erreur peut provenir d'un volume != %systemRoot%
        ''' il faudrait pouvoir dissocier avec les erreurs sur le %systemRoot%
        ''' </remarks>
        Public Function getNtSystemLogErrorCount(ByVal osInstallDevice As String, _
                                                 Optional ByVal onlyLastXDaysFilter As Boolean = False) As structNtSystemLogErrorCount

            Dim structErrorCount As New structNtSystemLogErrorCount

            With structErrorCount
                .iNumBsobError = 0
                .iNumControllerError = 0
                .iNumDiskBlockErrorOnSystemDisk = 0
                .iNumDiskPredictFail = 0
                .iNumFtDiskError = 0
                .iNumNetworkError = 0
                .iNumNtfsError = 0
                .iNumShutdownError = 0
            End With

            Try
                For Each logEvents As Win32_NTLogEvent In _listOfWin32LogEvents
                    'Debug.Print(logEvents.Type.ToString & " " & logEvents.SourceName.ToString)
                    If onlyLastXDaysFilter Then
                        If isEventOlderThanXDay(logEvents) Then
                            Continue For
                        End If
                    End If

                    Select Case logEvents.EventCode
                        Case 7
                            ' Ajoute l'erreur disque uniquement si se situe sur le disque Système
                            ' on ne s'occupe pas des clefs USB, disque externes moisis etc....
                            If logEvents.SourceName.ToUpperInvariant = "DISK" Then
                                If isErrBlockOnOsInstallDevice(logEvents, osInstallDevice) Then
                                    structErrorCount.iNumDiskBlockErrorOnSystemDisk += 1
                                End If
                            End If
                        Case 1003
                            If logEvents.SourceName.ToUpperInvariant = "DHCP" Then
                                structErrorCount.iNumNetworkError += 1
                            End If
                        Case 5719 ' erreur Netlogon DC unavailable
                            If logEvents.SourceName.ToUpperInvariant = "NETLOGON" Then
                                structErrorCount.iNumNetworkError += 1
                            End If
                        Case 1001
                            If logEvents.SourceName.ToUpperInvariant = "SAVE DUMP" Or
                                logEvents.SourceName = "Microsoft-Windows-WER-SystemErrorReporting" Then
                                structErrorCount.iNumBsobError += 1
                            End If
                        Case 6008
                            structErrorCount.iNumShutdownError += 1
                        Case 9 Or 11
                            If logEvents.SourceName.ToUpperInvariant = "ATAPI" Then
                                structErrorCount.iNumControllerError += 1
                            End If
                        Case 52
                            If logEvents.SourceName.ToUpperInvariant = "DISK" Then
                                structErrorCount.iNumDiskPredictFail += 1
                            End If
                        Case 55
                            If logEvents.SourceName.ToUpperInvariant = "NTFS" Then
                                structErrorCount.iNumNtfsError += 1
                            End If
                        Case 57
                            If logEvents.SourceName.ToUpper = "FTDISK" Then
                                structErrorCount.iNumFtDiskError += 1
                            End If
                    End Select
                Next
            Catch ex As Exception
                ' TODO loguer
                structErrorCount = Nothing
            End Try

            Return structErrorCount
        End Function
    End Class

End Namespace
