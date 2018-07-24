Imports System.Collections
Imports System.Management
Imports program
Imports structs
Imports wmi

Public Class cstation
    Private _stationName As String = Nothing ' nom de la station
    Private _frmToUpdate As frmMain ' bof ...

    ' Controller Classes
    Private _NtSystemLog As NtLogEvent
    Private _NtApplicationLog As NtApplicationEvent
    Private _LogicalDisk As LogicalDisk
    Private _DiskDrive As DiskDrive
    Private _VideoController As VideoController
    Private _Service As Service
    Private _battery As win32_batteryController
    ' Classes Métiers
    Private _listOfLogicalDisk As List(Of Win32_LogicalDisk)
    Private _listOfDiskDrive As List(Of Win32_DiskDrive)
    Private _listofVideoController As List(Of Win32_VideoController)
    Private _listOfService As List(Of Win32_Service)
    Private _listofBattery As List(Of win32_battery)
    '
    Private _dateScan As DateTime ' date du scan (initialisé quand _modeBatch = true )
    Private _socle As String = "" ' Socle Image
    Private _freeSpaceOnSystemDisk As Single  ' place libre sur disque systeme
    Private _edidInfo As cMonitorInfo ' informations sur ecrans connectés

    Private _smart As wmiSmart ' Classe SMART
    Private _gInfoStation As cgInfosStation ' infos my_wmi
    'Private _aInstalledSoftwareSet As New List(Of analogStructs.InstalledProgram) ' Collection Programmes installés
    Private _programs As cPrograms
    Private WithEvents _wmiWrapper As cwmi


    Public errorMessage As String = Nothing ' message d'erreur si requete KO

    Private _iAsynctaskcounter As Integer = 0 'nb de taches asynchrones (poolThread) en cours
    Private _cancelAsyncTasks As Boolean = False ' mettre à true pour abandon ( si changement de station avant fin traitement par exemple )


    ' historique 
    Private Shared _lstLastUsedStation As New List(Of String)

    Public offlineMode As Boolean

#Region "getter/setter"
    Public ReadOnly Property ntSystemLog() As NtLogEvent
        Get
            Return _NtSystemLog
        End Get
    End Property
    Public ReadOnly Property NtApplicationLog() As NtApplicationEvent
        Get
            Return _NtApplicationLog
        End Get
    End Property
    Public Property stationName() As String
        Get
            Return _stationName
        End Get
        Set(ByVal value As String)
            _stationName = value
        End Set
    End Property
    Public ReadOnly Property socle() As String
        Get
            Return _socle
        End Get
    End Property
    Public ReadOnly Property freeSpaceOnSystemDisk() As Single
        Get
            Return _freeSpaceOnSystemDisk
        End Get
    End Property
    Public ReadOnly Property wmi() As cwmi
        Get
            Return _wmiWrapper
        End Get
    End Property
    Public Shared ReadOnly Property lstLastUsedStation() As List(Of String)
        Get
            Return _lstLastUsedStation
        End Get
    End Property
    Public Property gInfoStation() As cgInfosStation
        Get
            If Not _gInfoStation Is Nothing Then
                Return _gInfoStation
            Else
                _gInfoStation = New cgInfosStation()
                Return _gInfoStation
            End If
        End Get
        Set(ByVal value As cgInfosStation)
            _gInfoStation = value
        End Set
    End Property
    Public ReadOnly Property listOfDiskDrive() As List(Of Win32_DiskDrive)
        Get
            Return _listOfDiskDrive
        End Get
    End Property
    Public ReadOnly Property listOfLogicalDisk() As List(Of Win32_LogicalDisk)
        Get
            Return _listOfLogicalDisk
        End Get
    End Property
    Public ReadOnly Property listofVideoController() As List(Of Win32_VideoController)
        Get
            Return _listofVideoController
        End Get
    End Property
    Public ReadOnly Property listOfService() As List(Of Win32_Service)
        Get
            Return _listOfService
        End Get
    End Property
    Public Property dateScan() As DateTime
        Get
            Return _dateScan
        End Get
        Set(ByVal value As DateTime)
            _dateScan = value
        End Set
    End Property
    Public ReadOnly Property edidInfo() As cMonitorInfo
        Get
            Return _edidInfo
        End Get
    End Property
    Public ReadOnly Property smart() As wmiSmart
        Get
            Return _smart
        End Get
    End Property
    Public ReadOnly Property iAsynctaskcounter() As Integer
        Get
            Return _iAsynctaskcounter
        End Get
    End Property
    Public Property cancelAsyncTasks() As Boolean
        Get
            Return _cancelAsyncTasks
        End Get
        Set(ByVal value As Boolean)
            _cancelAsyncTasks = value
        End Set
    End Property
    Public ReadOnly Property systemDiskTotalCapacity() As Nullable(Of Integer)
        Get
            Return getTotalSpaceOnSystemDisk()
        End Get
    End Property
    Public ReadOnly Property systemDiskFreeSpaceAsPercentage() As Nullable(Of Integer)
        Get
            Return getFreeSpaceOnSystemDiskAsPercentage()
        End Get
    End Property
    Public ReadOnly Property programs() As cPrograms
        Get
            Return _programs
        End Get
    End Property
    Public ReadOnly Property listOfBattery() As List(Of win32_battery)
        Get
            Return _listofBattery
        End Get
    End Property
#End Region

#Region "gestion historique"
    Public Shared Sub loadLastUsedStationFromSettings()
        For Each setting As String In My.Settings.LastUsedStation
            _lstLastUsedStation.Add(setting)
        Next
    End Sub

    Public Shared Sub addStationTolstUsedStation(ByVal station As String)
        If _lstLastUsedStation.IndexOf(station.ToUpperInvariant) = -1 Then
            If _lstLastUsedStation.Count > 6 Then
                _lstLastUsedStation.RemoveAt(0)
            End If
            _lstLastUsedStation.Add(station.ToUpperInvariant)
        End If
    End Sub
#End Region

    Public Sub New(ByVal stationName As String, _
                   ByRef frm As frmMain)
        _frmToUpdate = frm
        _stationName = stationName

        _wmiWrapper = New cwmi(_stationName)
        _edidInfo = New cMonitorInfo(_stationName)
        _smart = New wmiSmart(_stationName)
        _NtSystemLog = New NtLogEvent(_wmiWrapper)
        _NtApplicationLog = New NtApplicationEvent(_wmiWrapper)
        _LogicalDisk = New LogicalDisk(_wmiWrapper)
        _programs = New cPrograms(_stationName)
        ' _battery = New win32_batteryController(_wmiWrapper)

        ' classes non utilisées en mode server
        If Not program.isServerMode Then
            _DiskDrive = New DiskDrive(_wmiWrapper)
            _VideoController = New VideoController(_wmiWrapper)
            _Service = New Service(_wmiWrapper)
        Else
            _dateScan = DateTime.Now
        End If
    End Sub

    Private Sub AsyncTaskRegister()

        If Not _frmToUpdate.closingFlag Then
            _iAsynctaskcounter += 1
            If _iAsynctaskcounter = 0 And Not _frmToUpdate.isActiveBackgroundWorker Then
                _frmToUpdate.setMainProgressBarVisible(False)
            Else
                _frmToUpdate.setMainProgressBarVisible(True)
            End If
        End If

    End Sub

    Private Sub AsyncTaskUnRegister()

        If Not _frmToUpdate.closingFlag Then
            _iAsynctaskcounter -= 1

            If _iAsynctaskcounter = 0 And Not _frmToUpdate.isActiveBackgroundWorker Then
                _frmToUpdate.setMainProgressBarVisible(False)
            Else
                _frmToUpdate.setMainProgressBarVisible(True)
            End If
        End If

        ' FIXME rien à faire ici
        ' ==> race condition possible 
        ' il faudrait émettre un event quand le scan et les taches async associées est terminé
        ' et sauvegarder à ce moment là ... 
        If _iAsynctaskcounter = 0 Then
            ' On n'enregitre pas dans la base les machines scannées avec l'adresse IP
            If Not System.Net.IPAddress.TryParse(stationName, Nothing) Then
                Dim firstscan As Boolean

                If _programs.save(firstscan) Then
                    If Not firstscan Then
                        _frmToUpdate.setCbHilightVisible(True)
                    End If
                End If

                cMysqlStation.save(Me)
            End If
        End If
    End Sub

    Public Function connect() As Boolean
        If Not network.ping(stationName) Then
            errorMessage = "Ping Ko"
            Return False
        End If

        Return _wmiWrapper.connect(errorMessage)
    End Function

    Public Sub disconnect(Optional ByVal normal As Boolean = False)
        _cancelAsyncTasks = True
        _wmiWrapper.disconnect(Nothing, Nothing, normal)
    End Sub

    Public Function getOsInstallDevice() As String
        If gInfoStation.OsInstallDevice Is Nothing Then
            Throw New ArgumentException("Impossible de déterminer disque sur lequel est installé le système, non défini")
        Else
            Return gInfoStation.OsInstallDevice
        End If
    End Function

    ''' <summary>
    ''' Renvoie la place disponible sur le disque c:
    ''' utilisé en modeBatch
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getFreeSpaceOnSystemDisk() As Single
        Dim freeSpace As Single

        Try
                For Each logicalDisk As Win32_LogicalDisk In _listOfLogicalDisk
                    If logicalDisk.Name = "C:" Then
                        freeSpace = Math.Round(CDec(logicalDisk.FreeSpace / frmMain.GIGA_OCTETS), 2)
                        Exit For
                    End If
                Next
            Catch ex As Exception
                program.log.addLogEntry(New cLogEntry("Impossible de calculer espace disponible", cLogEntry.enumDebugLevel.ERREUR, Me.stationName))
                freeSpace = Nothing
            End Try

        Return freeSpace
    End Function

    Private Function getTotalSpaceOnSystemDisk() As Nullable(Of Integer)
        Dim TotalSpace As Integer

        Try
            For Each logicalDisk As Win32_LogicalDisk In _listOfLogicalDisk
                If logicalDisk.Name = "C:" Then
                    TotalSpace = CInt(Math.Truncate(CDec(logicalDisk.Size / frmMain.GIGA_OCTETS)))
                    Exit For
                End If
            Next
        Catch ex As Exception
            program.log.addLogEntry(New cLogEntry("Impossible de calculer capacité du disque", cLogEntry.enumDebugLevel.ERREUR, Me.stationName))
            TotalSpace = Nothing
        End Try

        Return TotalSpace
    End Function

    Private Function getFreeSpaceOnSystemDiskAsPercentage() As Nullable(Of Integer)
        Dim percent As Integer

        Try
            For Each Disk As Win32_LogicalDisk In _listOfLogicalDisk
                If Disk.Name = "C:" Then
                    percent = CInt(LogicalDisk.getFreeDiskSpaceAsPercentage(Disk.Size, Disk.FreeSpace))
                End If
            Next
        Catch ex As Exception
            program.log.addLogEntry(New cLogEntry("Impossible de calculer capacité du disque", cLogEntry.enumDebugLevel.ERREUR, Me.stationName))
            percent = Nothing
        End Try

        Return percent
    End Function

    Private Sub UpdateLvPrograms()

        If _programs.getPrograms() IsNot Nothing Then
            If Not _frmToUpdate.closingFlag And Not _cancelAsyncTasks Then
                _frmToUpdate.LvProgramUpdater()
            End If
        End If

        AsyncTaskUnRegister()
    End Sub

    Private Sub AsyncUpdateLvPrograms()
        If Not _cancelAsyncTasks Then
            AsyncTaskRegister()
            System.Threading.ThreadPool.QueueUserWorkItem(AddressOf UpdateLvPrograms)
        End If
    End Sub

    Private Sub AsyncNtLogAnalyse()
        If Not _cancelAsyncTasks Then
            AsyncTaskRegister()
            System.Threading.ThreadPool.QueueUserWorkItem(AddressOf ntLogAnalyse)
        End If
    End Sub

    Private Sub ntLogAnalyse()
        _NtSystemLog.selectAll()
        _NtApplicationLog.selectAll()

        If Not _cancelAsyncTasks Then

            _frmToUpdate.degUpdateLogInfos(_NtSystemLog.getNtSystemLogErrorCount(Me.gInfoStation.OsInstallDevice),
                                             _NtApplicationLog.countApplicationErrors(False),
                                             _NtApplicationLog.countOfficeErrors(False))

        End If

        AsyncTaskUnRegister()
    End Sub

    ''' <summary>
    ''' Données log déja récupérées on utilise les données disponible en filtrant
    ''' </summary>
    ''' <param name="filterActive"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ntLogAnalyseWithfilter(ByVal filterActive As Boolean) As NtLogEvent.structNtSystemLogErrorCount

        If Not _cancelAsyncTasks Then
            _frmToUpdate.degUpdateLogInfos(_NtSystemLog.getNtSystemLogErrorCount(Me.gInfoStation.OsInstallDevice, filterActive),
                                     _NtApplicationLog.countApplicationErrors(filterActive),
                                     _NtApplicationLog.countOfficeErrors(filterActive))
        End If

    End Function

    Public Sub getNeworkInfos()
        _gInfoStation.setNetworkInfos(Me)
    End Sub

    ''' <summary>
    ''' Scanne station
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub getResults()
        '
        ' TODO => checkwga n'est plus mis à jour , vérifier
        '
        _socle = cregistry.GetSocleName(Me.stationName)
        _gInfoStation = New cgInfosStation(Me)
        _listOfLogicalDisk = _LogicalDisk.selectAll()
        _freeSpaceOnSystemDisk = getFreeSpaceOnSystemDisk()
        '_listofBattery = _battery.selectAll
        ' infos ecran
        _edidInfo.setEdidInfo()
        ' Recup SMART Failure predict STATUS
        If Not _gInfoStation.systemDrive Is Nothing Then
            ' _smart.setSmartfailurePredictStatus(_gInfoStation.systemDrive)
        End If

        If program.isServerMode Then
            _NtSystemLog.selectAll()
        Else
            ' videoControllers
            _listofVideoController = _VideoController.selectAll()
            _listOfService = _Service.selectAll
            ' -----------------------------------------------------------
            ' recup infos en fonction des préférences
            With program.preferences
                AsyncUpdateLvPrograms()
                AsyncNtLogAnalyse()

                _listOfDiskDrive = _DiskDrive.selectAll()
            End With
        End If
    End Sub

    ''' <summary>
    ''' récupère les infos station contructeur, modele , etc
    ''' appelé depuis un background worker dans frmMain
    ''' TODO non protégé si exception 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub getInfosStation()
        gInfoStation = New cgInfosStation(Me)
    End Sub
End Class
