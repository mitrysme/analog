Imports System.Management

Public Class cgInfosStation
    Private _serialNumber As String
    Private _TotalPhysicalMemory As ULong = Nothing
    Private _Model As String
    Private _Domain As String
    Private _Name As String
    Private _NumberOfProcessors As Integer = 1 ' par défaut 1 processeur par station 
    Private _Manufacturer As String
    Private _UserName As String = Nothing
    Private _OperatingSystem As String
    Private _OsInstallDevice As String ' disque sur lequel est installé l'OS
    Private _ServicePack As String
    Private _FreePhysicalMemory As ULong = Nothing
    Private _ProcessorName As String
    Private _ProcessorMaxClockSpeed As String
    Private _IpAdress As String
    Private _DhcpEnabled As Boolean = Nothing
    Private _addressWidth As String
    ' Private _modeBatch As Boolean = False
    Private _colnetworkAdapter As List(Of networkAdapter)
    Private _path As String ' varEnv PATH
    Private _lastBootUpTime As DateTime
    Private _upTime As String
    Private _systemDrive As String ' lettre lecteur sur lequel est installé l'OS
    Private _windowsDirectory As String ' %systemRoot% ex ! c:\windows
    Private _towerCase As Boolean = False ' vrai si boitier tour sur ml450/vl350
    Private _version As String
    Private _osInstallDate As DateTime  ' date install OS

    ' détection boitiers tours pour ml450/vl450
    Public Shared ml450TowerNames() As String = {"POWERMATE ML450"} ' noms modeles pour ML450
    Public Shared vl350TowerNames() As String = {"POWERMATE VL350", "MS-7168"} ' nom modeles pour VL350
    Public Shared ml450TowerCPUFreq As UInt16 = 2992
    Public Shared vl350TowerCPUFreq As UInt16 = 1826

#Region "getter/setter"
    Public ReadOnly Property serialNumber() As String
        Get
            If _serialNumber Is Nothing Then
                _serialNumber = "NA"
            End If

            Return _serialNumber
        End Get
    End Property
    Public Property totalPhysicalMemory() As ULong
        Get
            Return _TotalPhysicalMemory
        End Get
        ' écriture depuis tableau excel
        Set(ByVal value As ULong)
            _TotalPhysicalMemory = value
        End Set
    End Property
    Public Property model() As String
        Get
            If _Model Is Nothing Then
                _Model = "NA"
            End If

            Return _Model
        End Get
        ' écriture depuis tableau excel
        Set(ByVal value As String)
            _Model = value
        End Set
    End Property
    Public ReadOnly Property towercase() As Boolean
        Get
            Return _towerCase
        End Get
    End Property
    Public ReadOnly Property domain() As String
        Get
            If _Domain Is Nothing Then
                _Domain = "NA"
            End If
            Return _Domain
        End Get
    End Property
    Public ReadOnly Property name() As String
        Get
            If _Name Is Nothing Then
                _Name = "NA"
            End If
            Return _Name
        End Get
    End Property
    Public ReadOnly Property numberOfProcessors() As String
        Get
            Return CStr(_NumberOfProcessors)
        End Get
    End Property
    Public ReadOnly Property manufacturer() As String
        Get
            If _Manufacturer Is Nothing Then
                _Manufacturer = "NA"
            End If
            Return _Manufacturer
        End Get
    End Property
    Public ReadOnly Property userName() As String
        Get
            If _UserName Is Nothing Then
                _UserName = "NA"
            End If
            Return _UserName
        End Get
    End Property
    Public ReadOnly Property operatingSystem() As String
        Get
            If _OperatingSystem Is Nothing Then
                _OperatingSystem = "NA"
            End If
            Return _OperatingSystem
        End Get
    End Property
    Public ReadOnly Property OsInstallDevice() As String
        Get
            Return _OsInstallDevice
        End Get
    End Property
    Public ReadOnly Property servicePack() As String
        Get
            Return _ServicePack
        End Get
    End Property
    Public ReadOnly Property freePysicalMemory() As String
        Get
            If _FreePhysicalMemory = 0 Then
                Return "NA"
            Else
                Return CStr(Int((_FreePhysicalMemory) / 1024) + 1) & " Mb"
            End If
        End Get
    End Property
    Public ReadOnly Property processorName() As String
        Get
            Return _ProcessorName
        End Get
    End Property
    Public ReadOnly Property processorMaxClockSpeed() As String
        Get
            Return _ProcessorMaxClockSpeed
        End Get
    End Property
    Public ReadOnly Property ipAddress() As String
        Get
            Return _IpAdress
        End Get
    End Property
    Public ReadOnly Property dhcpEnabled() As String
        Get
            If _DhcpEnabled = Nothing Then
                Return Nothing
            End If
            If _DhcpEnabled Then
                Return "OUI"
            Else
                Return "NON"
            End If
        End Get
    End Property
    Public ReadOnly Property addressWidth() As String
        Get
            Return _addressWidth
        End Get
    End Property

    Public ReadOnly Property colNetworkAdapter() As List(Of networkAdapter)
        Get
            Return _colnetworkAdapter
        End Get
    End Property
    Public ReadOnly Property uptime() As String
        Get
            Dim sUptime As String = ""

            If _lastBootUpTime <> Nothing Then
                Dim timeSpan As New TimeSpan

                timeSpan = Date.Now - _lastBootUpTime
                sUptime = String.Format("{0}j {1}h {2}m", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes)
            Else
                Return Nothing
            End If

            Return sUptime
        End Get
    End Property
    Public ReadOnly Property systemDrive() As String
        Get
            Return _systemDrive
        End Get
    End Property
    Public ReadOnly Property windowsDirectory() As String
        Get
            Return _windowsDirectory
        End Get
    End Property
    Public ReadOnly Property version() As String
        Get
            Return _version
        End Get
    End Property
    Public ReadOnly Property osInstallDate As DateTime
        Get
            Return _osInstallDate
        End Get
    End Property

#End Region

    Public Structure networkAdapter
        Public NeTConnectionID As String ' nom de l'interface
        Public name As String ' nom de l'interface (instanceName) pour récup speed performanceCounter
        Public NetworkSpeed As Single ' vitesse interface récup par performanceCounter
        Public DHCPEnabled As Boolean
        Public MACaddress As String
        Public ipAddress As String()
        Public DefaultIpGateway As String()
        Public ipSubnet As String()
        Public reservationIP As Boolean ' true si reservation IP ( 3eme octet = 1 )
        Public index As UInteger
        Public driverVersion As String
        Public driverDate As Date
        Public driverDesc As String
        Public driverManufacturer As String
    End Structure

    ''' <summary>
    ''' Constructeur
    ''' </summary>
    ''' <param name="station">objet cstation</param>
    ''' <remarks></remarks>
    Sub New(ByRef station As cstation)
        '_modeBatch = program.isServerMode
        'TODO [critical] pas protégé car cwmi catche l'exception et retourne une collection = nothing si ça merde
        setInfos(station)
    End Sub

    ' Appelé depuis Cexcel pour reconstruire objet depuis feuille excel
    Sub New(Optional ByVal model As String = "",
            Optional ByVal TotalPhysicalMemory As ULong = Nothing)

        _Model = model
        _TotalPhysicalMemory = TotalPhysicalMemory

    End Sub

    Private Sub setInfos(ByRef station As cstation)
        ' TODO exceptions possibles => catche uniquement managementException ( rpc serveur unavailable = une erreur est survenue ... )
        ' dans station.getresults puis remonte dans frmMain.dowork 
        setOsInfos(station)
        setComputerInfos(station)
        setSerialNumber(station)
        If Not program.isServerMode Then
            setProcessorInfos(station)
        End If
        setVLMLTowerCase()
        If Not program.isServerMode Then
            setNumberOfProcessors(station)
        End If

    End Sub

    ''' <summary>
    ''' Teste si ordi = VL350 / ML450 
    ''' dans ce cas teste si boitier tour ( nom + freq CPU )
    ''' </summary>
    ''' <remarks>
    ''' On pourrait aussi remplacer le modele affiché avec ml450 / VL350 
    ''' au lien de ms-6178 etc ....
    ''' </remarks>
    Public Sub setVLMLTowerCase()
        If Not _Model Is Nothing And Not _ProcessorMaxClockSpeed Is Nothing Then
            If ml450TowerNames.Contains(_Model) Then
                If _ProcessorMaxClockSpeed = CStr(ml450TowerCPUFreq) & " Mhz" Then
                    _towerCase = True
                End If
            Else
                If vl350TowerNames.Contains(_Model) Then
                    If _ProcessorMaxClockSpeed = CStr(vl350TowerCPUFreq) & " Mhz" Then
                        If _ProcessorName.Contains("3200") Then
                            _towerCase = True
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Récupère le nombre de processeurs dans le registre
    ''' </summary>
    ''' <remarks>
    '''   si la requete échoue, on garde la valeur par défaut (1)
    ''' TODO gérer le cas pour OS != XP voir p70anph130 (win7)
    ''' ==> fonctionne SI remote registry activé sur la machine ( désactivé par défaut sur win7 )
    ''' </remarks>
    Private Sub setNumberOfProcessors(ByRef station As cstation)
        Dim res As Object = Nothing
        If cregistry.GetEnvironmentVariablesByName(station.stationName, "NUMBER_OF_PROCESSORS", res) Then
            _NumberOfProcessors = CInt(res)
        End If
    End Sub

    Private Sub setComputerInfos(ByRef station As cstation)
        Dim col As ManagementObjectCollection = Nothing

        If station.wmi.getResultsFor(col, _
                                     "Win32_ComputerSystem", _
                                     "", _
                                     New String() {"totalPhysicalMemory", "Model", "Domain", "Name", "NumberOfProcessors", "Manufacturer", "UserName"}) Then
            Try
                For Each ManagementObject In col
                    _TotalPhysicalMemory = CULng(ManagementObject.Item("totalPhysicalMemory"))
                    _Model = CStr(ManagementObject.Item("Model"))
                    _Domain = CStr(ManagementObject.Item("Domain"))
                    _Name = CStr(ManagementObject.Item("Name"))
                    _Manufacturer = CStr(ManagementObject.Item("Manufacturer"))
                    _UserName = CStr(ManagementObject.Item("UserName"))
                Next

                ' Dans le cas de LENOVO , le modele se situe dans une autre classe ...
                If _Manufacturer = "LENOVO" Then
                    col.Dispose()
                    col = Nothing

                    If station.wmi.getResultsFor(col,
                                                 "Win32_ComputerSystemProduct",
                                                 "",
                                                 New String() {"Version"}) Then

                        For Each ManagementObject In col
                            _Model = CStr(ManagementObject.Item("Version"))
                        Next
                    End If

                End If
            Catch ex As ManagementException
                log.addLogEntry(New cLogEntry("Erreur CginfosStation : fetch win32_computerSystem / Win32_ComputerSystemProduct, classe wmi corrompue?", cLogEntry.enumDebugLevel.ERREUR, station.stationName, "cgInfosStation", ex))
            Catch ex As Exception
                log.addLogEntry(New cLogEntry("Erreur pendant récupération ComputerInfos", cLogEntry.enumDebugLevel.ERREUR, station.stationName, "cgInfosStation", ex))
            Finally
                If col IsNot Nothing Then
                    col.Dispose()
                End If
            End Try
        End If

    End Sub

    Private Sub setSerialNumber(ByRef station As cstation)
        Dim col As ManagementObjectCollection = Nothing

        If station.wmi.getResultsFor(col, "win32_Bios", "", New String() {"SerialNumber"}) Then
            Try
                For Each ManagementObject In col
                    _serialNumber = TryCast(ManagementObject.Item("SerialNumber"), String)
                Next
            Catch ex As ManagementException
                log.addLogEntry(New cLogEntry("Erreur fetch win32_BIOS ( serial number ), classe wmi corrompue?", cLogEntry.enumDebugLevel.ERREUR, station.stationName, "cgInfosStation", ex))
            Catch ex As Exception
                log.addLogEntry(New cLogEntry("Erreur pendant récupération SerialNumber", cLogEntry.enumDebugLevel.ERREUR, station.stationName, "cgInfosStation", ex))
            Finally
                If col IsNot Nothing Then
                    col.Dispose()
                End If
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Informations OS
    ''' </summary>
    ''' <remarks>
    ''' La propriété systemDrive n'est pas disponible sur windows 2000 ( ex P45ABAT103 )
    ''' Dans ce cas la requete plante et aucune info OS n'est dispo ....
    ''' TODO :
    ''' Il faudrait utiliser requete différente si OS == W2000
    ''' </remarks>
    Private Sub setOsInfos(ByRef station As cstation)
        Dim col As ManagementObjectCollection = Nothing

        ' Si requête échoue, tente sans la propriété systemdrive ( absente sur win2000 )
        ' probleme => si 1ere requete crashe ( invalidCasException sur une machine => du à WMI KO ) la deuxième requete est passée....
        ' ce n'est pas la peine ....
        If Not station.wmi.getResultsFor(col,
                                     "Win32_OperatingSystem",
                                     "",
                                     New String() {"FreePhysicalMemory", "name", "CSDVersion", "lastBootUpTime", "systemDrive", "WindowsDirectory", "version", "InstallDate"}) Then

            station.wmi.getResultsFor(col,
                                      "Win32_OperatingSystem",
                                      "",
                                      New String() {"FreePhysicalMemory", "name", "CSDVersion", "lastBootUpTime", "WindowsDirectory", "version"})

        End If

        If Not col Is Nothing Then
            Try
                For Each ManagementObject In col
                    Dim name As String = TryCast(ManagementObject.Item("name"), String)

                    If name IsNot Nothing Then
                        Dim aName() As String = Split(name, "|")
                        _OperatingSystem = aName(0)
                        _OsInstallDevice = aName(2)
                    End If

                    _FreePhysicalMemory = CULng(ManagementObject.Item("FreePhysicalMemory"))
                    _ServicePack = TryCast(ManagementObject.Item("CSDVersion"), String)
                    _lastBootUpTime = Management.ManagementDateTimeConverter.ToDateTime(ManagementObject.Item("LastBootUpTime").ToString)
                    _osInstallDate = Management.ManagementDateTimeConverter.ToDateTime(ManagementObject.Item("InstallDate").ToString)

                    If Not _OperatingSystem = "Microsoft Windows 2000 Professional" Then
                        _systemDrive = TryCast(ManagementObject.Item("SystemDrive"), String) ' n'existe pas si Win2000
                    End If
                    _windowsDirectory = TryCast(ManagementObject.Item("WindowsDirectory"), String)
                    _version = CStr(ManagementObject.Item("Version"))
                Next

            Catch ex As ManagementException
                log.addLogEntry(New cLogEntry("Erreur fetch Win32_OperationgSystem, classe wmi corrompue?", cLogEntry.enumDebugLevel.ERREUR, station.stationName, "cgInfosStation", ex))
            Catch ex As Exception
                log.addLogEntry(New cLogEntry("Erreur pendant récupération infos OS", cLogEntry.enumDebugLevel.ERREUR, station.stationName, "cgInfosStation", ex))
            Finally
                If col IsNot Nothing Then
                    col.Dispose()
                End If
            End Try
        End If
        ' End If
    End Sub

    ''' <summary>
    ''' Infos Processeur
    ''' </summary>
    ''' <remarks>
    '''  "select NumberOfCores from Win32_Processor"
    ''' la propriété numberOfCores existe dans win32_Processor sur XP SP3 et renvoie le bon nombre de core
    ''' problème si requete sur XP avec sp != 3 autre système 2003serveur , nt.... car requete plante
    ''' soit tester OS avant de faire la requete pour récup ou non la propriété
    ''' soit récupérer le nb de cores ailleurs, registre / win32_environment (mieux je pense )
    ''' </remarks>
    Private Sub setProcessorInfos(ByRef station As cstation)
        Dim col As ManagementObjectCollection = Nothing

        If station.wmi.getResultsFor(col,
                                     "Win32_Processor",
                                     "",
                                     New String() {"name", "MaxClockSpeed", "AddressWidth"}) Then
            Try
                For Each ManagementObject As ManagementObject In col
                    _ProcessorName = ManagementObject.Item("name").ToString
                    _ProcessorMaxClockSpeed = String.Format("{0} Mhz", ManagementObject.Item("MaxClockSpeed").ToString)

                    Dim addressWidth As Object = ManagementObject.Item("AddressWidth")

                    If addressWidth IsNot Nothing Then
                        _addressWidth = If(CInt(ManagementObject.Item("AddressWidth")) = 32, "32 bits", "64 bits")
                    Else
                        _addressWidth = "NA"
                    End If

                Next
            Catch ex As ManagementException
                log.addLogEntry(New cLogEntry("Erreur fetch Win32_Processor, classe wmi corrompue?", cLogEntry.enumDebugLevel.ERREUR, station.stationName, "cgInfosStation", ex))
            Catch ex As Exception
                log.addLogEntry(New cLogEntry("Erreur pendant récupération infos processeur", cLogEntry.enumDebugLevel.ERREUR, station.stationName, "cgInfosStation", ex))
            Finally
                If col IsNot Nothing Then
                    col.Dispose()
                End If
            End Try
        End If
    End Sub

    Public Shared Function checkIpReservation(ByVal sIpAdress As String) As Boolean
        If sIpAdress = "" Or sIpAdress = Nothing Then
            Return False
        End If

        Dim ipAdress As System.Net.IPAddress = Nothing

        If Net.IPAddress.TryParse(sIpAdress, ipAdress) Then
            Dim abyte() As Byte = ipAdress.GetAddressBytes

            If abyte(2) = 1 Then
                Return True
            End If
        End If

        Return False
    End Function

    ''' <summary>
    ''' remonte infos Interfaces réseaux
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub setNetworkInfos(ByRef station As cstation)
        Dim col As ManagementObjectCollection = Nothing

        If station.wmi.getResultsFor(col, "Win32_NetworkAdapterConfiguration", _
                                      "IPEnabled = True", _
                                      New String() {"index", "ipAddress", "IPSubnet", "DefaultIpGateway", "dhcpEnabled", "MACAddress", "Description", "Index"}) Then

            _colnetworkAdapter = New List(Of networkAdapter)

            Try
                For Each nicConfig As ManagementObject In col
                    Dim relatedQuery As New RelatedObjectQuery("win32_networkAdapterConfiguration=" & nicConfig.Item("Index").ToString)
                    relatedQuery.RelationshipClass = "Win32_NetworkAdapterSetting" ' classe de jointure

                    Dim colNics As ManagementObjectCollection = Nothing

                    If station.wmi.getRelatedResultsFor(colNics, _
                                                         relatedQuery.SourceObject, _
                                                         relatedQuery.RelationshipClass) Then

                        Dim networkAdapter As New networkAdapter

                        With networkAdapter
                            .MACaddress = TryCast(nicConfig.Item("MACAddress"), String)
                            .ipAddress = TryCast(nicConfig.Item("IPAddress"), String()) ' tableau une interface réseau peut avoir plusieurs adresses .... ( pool )
                            .ipSubnet = TryCast(nicConfig.Item("IPSubnet"), String())
                            .DefaultIpGateway = TryCast(nicConfig.Item("DefaultIpGateway"), String())
                            .DHCPEnabled = CType(nicConfig.Item("DHCPEnabled"), Boolean)
                            .index = CType(nicConfig.Item("Index"), UInt32)

                            '
                            ' Récupère infos driver dans le registre
                            '
                            cregistry.getNetworkDriverInfos(station.stationName, networkAdapter.index, .driverVersion, .driverDate, .driverDesc, .driverManufacturer)
                            '
                            ' check si reservation IP
                            '
                            .reservationIP = checkIpReservation(.ipAddress(0))
                            '
                            ' Sur certaines machines win32_networkAdapterConfiguration renvoie une 
                            ' collection vide, dans ce cas on assigne  simplement les infos networkAdapter
                            ' netConnectionID  => indisponible
                            '
                            If colNics.Count <> 0 Then
                                '
                                ' moche de comparer TypeOS avec une chaine
                                ' il doit il y avoir des constantes qqupart
                                '
                                If _OperatingSystem <> "Microsoft Windows 2000 Professional" Then
                                    For Each nic As ManagementObject In colNics
                                        .NeTConnectionID = TryCast(nic.Item("NeTConnectionID"), String) ' n'existe pas sous win2000
                                        .name = TryCast(nic.Item("Description").ToString, String)
                                        .NetworkSpeed = getNetworkInterfaceCurrentBandwith(nicConfig.Item("Description").ToString, station.stationName)
                                    Next
                                Else
                                    .NeTConnectionID = "NA"
                                End If
                            Else
                                .NeTConnectionID = "NA"
                            End If
                        End With

                        _colnetworkAdapter.Add(networkAdapter)

                        If colNics IsNot Nothing Then
                            colNics.Dispose()
                        End If

                    End If
                Next
            Catch ex As ManagementException
                _colnetworkAdapter = Nothing
                log.addLogEntry(New cLogEntry("Erreur fetch Win32_NetworkAdapter, classe wmi corrompue ?", cLogEntry.enumDebugLevel.ERREUR, station.stationName, "cgInfosStation", ex))
            Catch ex As Exception
                _colnetworkAdapter = Nothing
                log.addLogEntry(New cLogEntry("Erreur pendant récupération infos réseau", cLogEntry.enumDebugLevel.ERREUR, station.stationName, "cgInfosStation", ex))
            Finally
                If col IsNot Nothing Then
                    col.Dispose()
                End If
            End Try
        End If
    End Sub

    Private Function getNetworkInterfaceCurrentBandwith(ByVal instanceName As String, ByVal stationName As String) As Single
        Dim value As Single
        Dim sw As New Stopwatch
        sw.Start()

        ' TODO : BEURK !!
        ' Le nom de l'instance du compteur et la description dans les classes wmi ne correspondent pas toujours
        ' souvent à 1 caractère près ... Comment associer instance compteur et instance classe WMI ??
        ' grosse bidouille 
        ' on sélectionne les cas dans lesquels problématiques et on modifie la chaine .... 
        If instanceName.StartsWith("Realtek RTL8169") Then
            instanceName = instanceName.Replace(CChar("/"), CChar("_"))
        ElseIf instanceName.StartsWith("Broadcom NetLink") Then
            instanceName = instanceName.Replace(CChar("("), CChar("[")).Replace(CChar(")"), CChar("]"))
        ElseIf instanceName.StartsWith("Intel(R)") Then
            instanceName = instanceName.Replace(CChar("("), CChar("[")).Replace(CChar(")"), CChar("]")).Replace(CChar("/"), CChar("_")).Replace(CChar("#"), CChar("_"))
        ElseIf instanceName.StartsWith("Realtek RTL8168/8111") Then
            instanceName = instanceName.Replace(CChar("/"), CChar("_"))
        ElseIf instanceName.StartsWith("11a/b/g Wireless") Then
            instanceName = instanceName.Replace(CChar("/"), CChar("_"))
        ElseIf instanceName.StartsWith("3Com Gigabit NIC") Then
            instanceName = instanceName.Replace(CChar("("), CChar("[")).Replace(CChar(")"), CChar("]"))
        End If

        Try
            If PerformanceCounterCategory.InstanceExists(instanceName, "Network Interface", stationName) Then
                Using pc As New PerformanceCounter("Network Interface", "Current Bandwidth", instanceName, stationName)
                    value = pc.NextValue()
                End Using
            Else
                log.addLogEntry(New cLogEntry("Le compteur de performance currentBandwith n'existe pas pour l'instance : " & instanceName, cLogEntry.enumDebugLevel.ERREUR, stationName))
        End If
        Catch ex As Exception
            log.addLogEntry(New cLogEntry("Une erreur s'est produite pendant la récupération du compteur currentBandwith pour l'instance : " & instanceName, cLogEntry.enumDebugLevel.ERREUR, stationName, Nothing, ex))
        End Try

        sw.Stop()

        log.addLogEntry(New cLogEntry(String.Format("CPT : ( {0} ms ) Récup  Compteur CurrentBandwith  pour instance : {1}", sw.ElapsedMilliseconds, instanceName), cLogEntry.enumDebugLevel.INFO, stationName))


        Return value
    End Function
End Class
