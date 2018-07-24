Imports System.Threading

Public Class producerConsumerQueue
    Private _queue As New Queue(Of String) ' list de station à scanner
    Private _workerCount As Integer ' nombre de threads de traitement

    Public Const MAX_SCAN_TIME As Integer = 180000 ' temps max de scan avant abort ( 3 minutes )
    Public Event batchScanStationUpdated()

    ReadOnly _locker As Object = New Object ' synchronisation

    Dim _workers() As Thread ' array de Workers

    ''' <summary>
    ''' Constructeur
    ''' </summary>
    ''' <param name="workercount">Nombre de threads de traitement</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal workercount As Integer)
        ReDim _workers(workercount - 1)

        ' Worker.isbackground => permet au thread principal de terminer même si un thread worker est 
        ' planté ( wmiSearcher.get hangs ) 
        ' TODO => PAS BIEN !!!!
        For i As Integer = 0 To workercount - 1
            _workers(i) = New Thread(AddressOf consume)
            _workers(i).IsBackground = True
            _workers(i).Start()
        Next
    End Sub

    Public Sub enqueue(ByVal stationName As String)
        SyncLock _locker
            _queue.Enqueue(stationName)
            Monitor.PulseAll(_locker)
        End SyncLock
    End Sub

    Private Sub consume()
        While (True)
            Dim stationName As String = Nothing

            SyncLock (_locker)
                While (_queue.Count = 0)
                    Monitor.Wait(_locker)
                End While

                stationName = _queue.Dequeue
                'Debug.Print("Thread id : " & Thread.CurrentThread.ManagedThreadId & "consuming :" & stationName)
            End SyncLock

            If stationName Is Nothing Then Return
            scan(stationName)
        End While
    End Sub

    Public Sub shutdown(ByVal waitForWorkers As Boolean)
        For Each worker As Thread In _workers
            enqueue(Nothing)
        Next

        If waitForWorkers Then
            For Each worker As Thread In _workers


                ' Laisse cinq minutes au thread pour terminer
                ' abort sinon
                ' Probleme rencontré sur 

                ' wmiSearcher.get ne retourne jamais ... et abort ne termine pas le thread
                ' apparemment parceque le thread est bloqué dans du code non managé ( interop )
                ' à tester en passant les threads de scan en background
                ' le process devrait terminer avec le main thread ???
                ' 
                ' PROBLEME :
                ' si le thread est aborté il est sorti de la queue et 
                ' on tourne alors  avec 1 thread de moins à chaque 
                ' fois pour finir le traitement .....
                If Not worker.Join(MAX_SCAN_TIME) Then
                    log.addLogEntry(New cLogEntry("le thread n'a pas terminé au bout de 3 minutes Aborting...", cLogEntry.enumDebugLevel.ERREUR, Nothing, Nothing))
                    worker.Abort()
                End If
            Next

        End If

    End Sub

    ''' <summary>
    ''' Scan stations threads worker
    ''' </summary>
    ''' <param name="stationName"></param>
    ''' <remarks>
    ''' </remarks>
    Private Sub scan(ByVal stationName As String)
        Dim station As cstation = New cstation(stationName, Nothing)

        Try
            If station.connect() Then
                station.getResults()
            End If
        Catch ex As ThreadAbortException
            station.errorMessage = "Le thread n'a pas répondu au bout de 3 minutes => abandon"
        Catch ex As Exception
            station.errorMessage = "Scan Erreur Interne : " & ex.Message.ToString
        Finally
            If station.errorMessage = "" Then
                RaiseEvent batchScanStationUpdated()
            End If

            cMysqlStation.save(station)

            SyncLock (_locker)
                station = Nothing
            End SyncLock
        End Try
    End Sub

End Class

