Imports structs.analogStructs
Imports System.IO

Public Class cbatchScan
    Private _stationsToScan As New List(Of String) ' liste de stations à scanner
    Private WithEvents _pcQueue As producerConsumerQueue
    ' Private _dateScan As DateTime ' date début du scan
    Private _iBatchStationsUpdated As Integer = 0 ' nombre de stations mise à jour ( pas d'erreur )
    Private _domainStationList As ArrayList ' liste de station sur DC
    Private _dicOfStationsFromDB As Dictionary(Of String, cMySqlStationTable) ' liste de stations dans la BDD
    Private Shared _dicSiteNames As New Dictionary(Of String, String) ' liste sites CHU
    Private _batchScanReport As New cBatchScanReport

    Public Const NB_THREADS As Integer = 25 ' nombre de threads worker
    Public Const NB_DAYS_BETWEEN_SCAN As Integer = 29

    Public Shared ReadOnly Property dicsiteNames() As Dictionary(Of String, String)
        Get
            Return _dicSiteNames
        End Get
    End Property

    ' //---------------- Constructeurs ----------------------------//
    Public Sub New()
        '
    End Sub

    Public Sub startScan()
        _batchScanReport.dateScanStart = Date.Now

        If getScanInfos() Then
            setDeleteStatus()
            getStationsToScan()
            scanAll()
            'scanPrinters()
        Else
            AnalogExit()
        End If
    End Sub

    Private Function getScanInfos() As Boolean
        '
        ' On merge les ordis contenus dans OrdisCHU et Newcomputers dans la même arrayList
        '
        Try
            Dim domainStationListOUNewcomputers As ArrayList = ldapWrapper.getDomainStationList("OU=NewComputers")
            _domainStationList = ldapWrapper.getDomainStationList("OU=OrdisCHU")

            For Each station As String In domainStationListOUNewcomputers
                _domainStationList.Add(station)
            Next

            _dicOfStationsFromDB = cMySqlStationTable.selectAll(True)
            _batchScanReport.iNumberStationOnDC = _domainStationList.Count
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    ''' <summary>
    ''' Crée la liste de station à scanner
    ''' </summary>
    ''' <remarks>
    ''' Logique bordélique , à revoir
    ''' </remarks>
    Private Sub getStationsToScan()
        '
        ' Toujours le meme PC wmi.connect() ne retourne jamais 
        ' worker.abort ne semble pas fonctionner 
        ' testé dans le débugger à voir si OK sans passer par le débogger
        '

        Dim i As Integer = 0

        For i = 0 To _domainStationList.Count - 1
            Dim stationName As String = _domainStationList(i).ToString

            ' la station est déjà dans la BDD
            If _dicOfStationsFromDB.ContainsKey(stationName) Then
                ' Le scan a échoué la dernière fois, on retente "PING KO" ETC ....
                ' pour les stations qui répondent "accès refusé" par exemple 
                ' il faudrait blackLister, inutile de tenter à chaque fois ....
                ' on ne rescanne pas si  la station a été marqué deleted ( présente dans base mais pas sur le controleur de domaine )
                If _dicOfStationsFromDB(stationName).deleted = False Then
                    If _dicOfStationsFromDB(stationName).errMessage <> String.Empty Then
                        _stationsToScan.Add(stationName)
                    Else
                        Dim dateDiFF As Long = DateAndTime.DateDiff(DateInterval.Day, _dicOfStationsFromDB(stationName).dateScan, Date.Now)
                        If dateDiFF >= NB_DAYS_BETWEEN_SCAN Then
                            _stationsToScan.Add(stationName)
                        End If
                    End If
                End If
            Else
                ' la station n'est pas encore dans la base 
                ' => nouvelle station => on ajoute => a loguer ....
                _stationsToScan.Add(stationName)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Parcours les stations dans la base et vérifie si la station existe
    ''' sur le DC. Si non, on marque la station deleted
    ''' si la station existe sur le DC et est marquée deleted on undelete
    ''' TODO loguer ces infos
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setDeleteStatus()
        Dim arrStationNamesToDelete As New ArrayList
        Dim arrStationNamesToUndelete As New ArrayList

        ' stations à undeleter
        For Each station As String In _domainStationList
            If _dicOfStationsFromDB.Keys.Contains(station) Then
                If _dicOfStationsFromDB(station).deleted Then
                    arrStationNamesToUndelete.Add(station)
                End If
            End If
        Next
        ' stations à effacer 
        For Each station As String In _dicOfStationsFromDB.Keys
            If Not _domainStationList.Contains(station) Then
                If Not _dicOfStationsFromDB(station).deleted Then
                    arrStationNamesToDelete.Add(station)
                End If
            End If
        Next

        _batchScanReport.arrStationNamesToDelete = arrStationNamesToDelete
        _batchScanReport.arrStationNamesToUndelete = arrStationNamesToUndelete

        If arrStationNamesToDelete.Count > 0 Then cMySqlStationTable.setDeletedStatus(arrStationNamesToDelete, True)
        If arrStationNamesToUndelete.Count > 0 Then cMySqlStationTable.setDeletedStatus(arrStationNamesToUndelete, False)
    End Sub

    Private Sub batchScanPcUpdatedHandler()
        _iBatchStationsUpdated += 1
    End Sub

    Public Sub scanAll()
        If _stationsToScan.Count <> 0 Then
            _pcQueue = New producerConsumerQueue(NB_THREADS)
            AddHandler _pcQueue.batchScanStationUpdated, AddressOf batchScanPcUpdatedHandler

            For Each stationName As String In _stationsToScan
                _pcQueue.enqueue(stationName)
            Next

            ' On attends que tous les threads aient terminé
            _pcQueue.shutdown(True)
        End If

        RemoveHandler _pcQueue.batchScanStationUpdated, AddressOf batchScanPcUpdatedHandler

        _batchScanReport.dateScanStop = Date.Now
        log.addLogEntry(New cLogEntry("Traitement terminé, exiting...", cLogEntry.enumDebugLevel.INFO))

        AnalogExit()
    End Sub

End Class
