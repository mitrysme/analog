Public Class cUtests
    Private WithEvents _timer As New System.Timers.Timer
    Private _randomizer As New Random
    Dim listeStations() As String
    Private Delegate Sub _addTab(ByVal statioName As String)

    Public Sub New()
        listeStations = New String() {"PC2", "DC1", "DC2", "FS2", "gateway", "gateway2", "mail1", "pctest", "PC4"}
        Debug.Print("MainThread : " & Threading.Thread.CurrentThread.ManagedThreadId)
    End Sub

    Public Sub start()
        _timer.Start()
    End Sub

    Private Sub randomScan() Handles _timer.Elapsed
        changeTimerInterval()
        Debug.Print("Itmer Method : " & Threading.Thread.CurrentThread.ManagedThreadId)

        Dim stationName As String = getRandomStationName()
        If program.frmMdiContainer.isTabAlreadyOpened(stationName) Then
            program.frmMdiContainer.getActiveFrm.Close()
        Else
            ' Dim frmMain As New frmMain
            Dim deg = New _addTab(AddressOf program.frmMdiContainer.addTab)
            program.frmMdiContainer.Invoke(deg, stationName)

        End If

    End Sub

    Private Function getRandomStationName() As String
        Return listeStations.ElementAt(_randomizer.Next(0, listeStations.Count - 1))
    End Function

    Private Sub changeTimerInterval()
        _timer.Interval = _randomizer.Next(1000, 5000)
    End Sub
End Class
