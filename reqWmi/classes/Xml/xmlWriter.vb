Imports System.Xml
Imports System.Xml.XPath
Imports structs.analogStructs
Imports System.Text.RegularExpressions

Public Class xmlWriter
    Private _XDoc As XDocument
    Private _pathToXml As String
    Private _firstSiteScan As Boolean = False

    Public Sub New()
        '_scanResultPath = scanResultPath
    End Sub

    ''' <summary>
    ''' charge le fichier XML
    ''' retourne faux si le fichier n'existe pas
    ''' </summary>
    ''' <param name="pathToXml"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function load(ByVal pathToXml As String) As Boolean
        _pathToXml = pathToXml

        If System.IO.File.Exists(_pathToXml) Then
            Return loadXml()
        Else
            _XDoc = New XDocument(New XDeclaration("1.0", "utf-8", "yes"), _
                                  New XComment("Fichier Scan Stations"), _
                                  New XElement("LstStation")) ' root Node

            _firstSiteScan = True
            Return False
        End If

    End Function

    Public Sub save()
        _XDoc.Save(_pathToXml)
    End Sub

    ''' <summary>
    ''' Ajoute ou mets à jour le noeud correspondant à la station passée en paramètre
    ''' </summary>
    ''' <param name="station"></param>
    ''' <remarks></remarks>
    Public Sub saveStation(ByRef station As cstation)
        If findStationByName(station.stationName) Then
            updateStation(station)
        Else
            _XDoc.Root.Add(getXElementFromStation(station))
        End If
    End Sub

    ''' <summary>
    ''' retourne les stations à scanner
    ''' si Message erreur ( poste n'a pas pu etre scanné ) => scan
    ''' si station a été scannée depuis plus de dateinterval => scan
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub getStationsToScan(ByRef stationsToScan As List(Of String))

        For Each child As XElement In _XDoc.Elements("LstStation").Descendants("Station")
            Dim dateScan As DateTime = CDate(child.Element("DateScan").Value)
            Dim message As String = child.Element("ErrMessage").Value

            Dim scan As Boolean = False
            If message <> String.Empty Then
                scan = True
            Else
                'Scanne si intervalle de scan > 30 jours
                ' Peut etre serait bien de scanner si numéro de série a changer depuis dernier scan,
                ' implique une requete sur win32_BIOS pour toutes les machines .....
                Dim datedif As Long = DateAndTime.DateDiff(DateInterval.Day, dateScan, Date.Now)
                If datedif >= 29 Then
                    scan = True
                End If
            End If

            If scan Then
                Dim stationName As String = child.Attribute("name").Value
                stationsToScan.Add(stationName)
            End If
        Next
    End Sub

    Public Function getListBatchResults() As Dictionary(Of String, structs.analogStructs.BatchResult)
        Dim dicBatchResult As New Dictionary(Of String, structs.analogStructs.BatchResult)

        For Each child As XElement In _XDoc.Elements("LstStation").Descendants("Station")
            Dim e As BatchResult = getBatchResultFromXElement(child)

            ' Vérifie si doublon avant d'ajouter
            ' clé => stationName
            ' Il existe des doublons dans le fichier d'entrée*
            ' TODO => nettoyer fichier d'entrée avant d'importer ......
            If Not dicBatchResult.ContainsKey(e.stationName) Then
                dicBatchResult.Add(e.stationName, getBatchResultFromXElement(child))
            End If
        Next

        Return dicBatchResult
    End Function

    ''' <summary>
    ''' Fouille dans le fichier et tente de retrouver la station passée en argument
    ''' si trouvé renvoi un batchResult
    ''' </summary>
    ''' <param name="stationName"></param>
    ''' <param name="batchResult"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getBatchResultFromStationName(ByVal stationName As String, ByRef batchResult As BatchResult) As Boolean
        Dim success As Boolean = True
        ' on cherche la station dans la liste
        Dim e As XElement = getXElementfromStationName(stationName)
        ' si station non trouvée 
        If e Is Nothing Then Return False

        Try
            batchResult = getBatchResultFromXElement(e)
            ' on trouve la station mais scan KO
            If batchResult.errMessage <> "" Then
                success = False
            End If
        Catch ex As Exception
            success = False
        End Try

        Return success

    End Function

    ''' <summary>
    ''' Mets à jour le noeud XML 
    ''' </summary>
    ''' <param name="station">objet station à mettre à jour dans XML</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' e.setElementValue supprime la propriété si la valeur passé est NULL ....
    ''' FIXME => aucune valeur de retour ... SUB ??
    ''' </remarks>
    Private Function updateStation(ByRef station As cstation) As Integer
        Dim e As XElement = getXElementfromStationName(station.stationName)
        Dim systemLogErrorCount = station.ntSystemLog.getNtSystemLogErrorCount(station.gInfoStation.OsInstallDevice)

        If station.errorMessage Is Nothing Then
            With station
                e.SetElementValue("DateScan", .dateScan.ToString)
                e.SetElementValue("Modele", .gInfoStation.model)
                e.SetElementValue("Constructeur", .gInfoStation.manufacturer)
                e.SetElementValue("OsName", .gInfoStation.operatingSystem)
                e.SetElementValue("Sn", .gInfoStation.serialNumber)
                e.SetElementValue("Ram", CStr(.gInfoStation.totalPhysicalMemory))
                e.SetElementValue("ErrDisk", systemLogErrorCount.iNumDiskBlockErrorOnSystemDisk.ToString)
                e.SetElementValue("DriverPredictFail", systemLogErrorCount.iNumDiskPredictFail.ToString)
                e.SetElementValue("ErrNetwork", systemLogErrorCount.iNumNetworkError.ToString)
                e.SetElementValue("ErrReboot", systemLogErrorCount.iNumShutdownError.ToString)
                e.SetElementValue("ErrBsod", systemLogErrorCount.iNumBsobError.ToString)
                e.SetElementValue("Socle", station.socle)
                e.SetElementValue("FreeSpaceOnSystemDisk", station.freeSpaceOnSystemDisk)
                e.SetElementValue("SMART", station.smart.smartFailurePredictStatusAsString(station.gInfoStation.systemDrive))
                e.SetElementValue("TowerCase", station.gInfoStation.towercase)
                e.SetElementValue("ErrMessage", "")
            End With

            ' si noeud Display présent dans le fichier => efface 
            For Each v As XElement In e.Descendants
                If v.Name = "Displays" Then
                    v.Remove()
                    Exit For
                End If
            Next
            ' remplace par infos de la station
            setDisplayNode(e, station)
        End If
    End Function

    ''' <summary>
    ''' Cherche la station dans le fichier
    ''' retourne un XElement si trouve
    ''' </summary>
    ''' <param name="stationName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getXElementfromStationName(ByVal stationName As String) As XElement
        Dim e As XElement = _XDoc.XPathSelectElement("LstStation/Station[@name='" & stationName & "']")
        Return e
    End Function

    Private Function getXElementFromStation(ByRef station As cstation) As XElement
        Dim systemLogErrorCount = station.ntSystemLog.getNtSystemLogErrorCount(station.gInfoStation.OsInstallDevice)

        Dim Xelement As XElement = New XElement("Station", _
                                   New XAttribute("name", station.stationName.ToUpperInvariant), _
                                   New XElement("DateScan", station.dateScan.ToString), _
                                   New XElement("Modele", station.gInfoStation.model), _
                                   New XElement("Constructeur", station.gInfoStation.manufacturer), _
                                   New XElement("OsName", station.gInfoStation.operatingSystem), _
                                   New XElement("Sn", station.gInfoStation.serialNumber), _
                                   New XElement("Ram", CStr(station.gInfoStation.totalPhysicalMemory)), _
                                   New XElement("ErrDisk", systemLogErrorCount.iNumDiskBlockErrorOnSystemDisk.ToString), _
                                   New XElement("DriverPredictFail", systemLogErrorCount.iNumDiskPredictFail.ToString), _
                                   New XElement("ErrNetwork", systemLogErrorCount.iNumNetworkError.ToString), _
                                   New XElement("ErrReboot", systemLogErrorCount.iNumShutdownError.ToString), _
                                   New XElement("ErrBsod", systemLogErrorCount.iNumBsobError.ToString), _
                                   New XElement("Socle", station.socle), _
                                   New XElement("SMART", station.smart.smartFailurePredictStatusAsString(station.gInfoStation.systemDrive)), _
                                   New XElement("TowerCase", station.gInfoStation.towercase), _
                                   New XElement("FreeSpaceOnSystemDisk", station.freeSpaceOnSystemDisk), _
                                   New XElement("ErrMessage", station.errorMessage) _
                                   )

        setDisplayNode(Xelement, station)

        Return Xelement
    End Function

    ''' <summary>
    ''' Ajoute les infos ecrans sur le XElement passé en param
    ''' </summary>
    ''' <param name="e">XELEMENT</param>
    ''' <remarks></remarks>
    Private Sub setDisplayNode(ByRef e As XElement, ByRef station As cstation)
        Dim rootDisplayNode As New XElement("Displays")

        If station.edidInfo.listMonitorEdidInfo IsNot Nothing Then

            For Each edidInfo As cMonitorInfo.monitorEdidInfo In station.edidInfo.listMonitorEdidInfo
                Dim displayNode As New XElement("Display", New XAttribute("Sn", edidInfo.serialNumber))
                Dim monitorName As New XElement("monitorName", edidInfo.monitorName)
                Dim displayName As New XElement("displayName", edidInfo.displayName)

                displayNode.Add(monitorName)
                displayNode.Add(displayName)
                rootDisplayNode.Add(displayNode)
            Next
        End If

        e.Add(rootDisplayNode)
    End Sub

    Private Function findStationByName(ByVal stationName As String) As Boolean
        If _XDoc.XPathSelectElement("LstStation/Station[@name='" & stationName & "']") Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function loadXml() As Boolean
        Dim success As Boolean = True

        Try
            _XDoc = XDocument.Load(_pathToXml)
        Catch ex As Exception
            log.addLogEntry(New cLogEntry("Impossible de charger le fichier de XML", cLogEntry.enumDebugLevel.ERREUR))
            success = False
        End Try

        Return success
    End Function

    Private Function getBatchResultFromXElement(ByVal e As XElement) As structs.analogStructs.BatchResult
        Dim batchResult As New structs.analogStructs.BatchResult

        With batchResult
            .stationName = e.Attribute("name").Value.ToUpperInvariant
            .dateScan = CType(e.Element("DateScan").Value, DateTime)
            .modele = e.Element("Modele").Value
            .constructeur = e.Element("Constructeur").Value
            .osName = e.Element("OsName").Value
            .sn = e.Element("Sn").Value

            ' TODO essayer avec tryparse...
            'Integer.TryParse(CType(e.Element("DriverPredictFail"))
            If e.Element("DriverPredictFail").Value <> "" Then .driverPredictFail = CType(e.Element("DriverPredictFail"), Integer)
            If e.Element("Ram").Value <> "NA" Then .ram = CType(e.Element("Ram").Value, ULong)
            If e.Element("ErrDisk").Value <> "" Then .errDisk = CType(e.Element("ErrDisk").Value, Integer)
            If e.Element("ErrNetwork").Value <> "" Then .errNetwork = CType(e.Element("ErrNetwork").Value, Integer)
            If e.Element("ErrReboot").Value <> "" Then .errReboot = CType(e.Element("ErrReboot").Value, Integer)
            If e.Element("ErrBsod").Value <> "" Then .errBsod = CType(e.Element("ErrBsod").Value, Integer)

            .socle = e.Element("Socle").Value
            .freeSpaceOnSystemDisk = e.Element("FreeSpaceOnSystemDisk").Value
            .smartStatus = e.Element("SMART").Value
            .towerCase = CBool(e.Element("TowerCase").Value)
            .errMessage = e.Element("ErrMessage").Value
        End With
        ' Examen du noeud display et création 
        Dim displayNode As XElement = e.Element("Displays")

        If displayNode IsNot Nothing Then
            Dim listMonitorEdidInfo As New List(Of cMonitorInfo.monitorEdidInfo)
            Dim subNodes As System.Collections.Generic.IEnumerable(Of XElement)

            subNodes = displayNode.Elements()

            For Each nodeDisplay As XElement In subNodes
                Dim sMonitorSerial As String = nodeDisplay.Attribute("Sn").Value.ToUpperInvariant
                Dim sMonitorName As String = nodeDisplay.Element("monitorName").Value
                Dim sDisplayName As String = nodeDisplay.Element("displayName").Value

                Dim monitorEdidInfo As New cMonitorInfo.monitorEdidInfo(sMonitorName, sMonitorSerial, sDisplayName)
                listMonitorEdidInfo.Add(monitorEdidInfo)
            Next

            batchResult.listMonitorEdidInfo = New List(Of cMonitorInfo.monitorEdidInfo)
            batchResult.listMonitorEdidInfo = listMonitorEdidInfo
        End If

        Return batchResult
    End Function

End Class
