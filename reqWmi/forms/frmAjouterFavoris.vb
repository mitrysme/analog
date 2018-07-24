Public Class frmAddFavoris
    Private _station As cstation


    Public Sub New(ByRef station As cstation)
        InitializeComponent()
        _station = station
        Me.tbStationName.Text = _station.stationName
    End Sub

    Public Sub frm_load() Handles Me.Load
        Me.CenterToParent()
    End Sub

    Private Sub btnAjouter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAjouter.Click
        Dim systemLogErrorCount = _station.ntSystemLog.getNtSystemLogErrorCount(_station.gInfoStation.OsInstallDevice)

        Dim favoris As New cFavoris
        With favoris
            .stationName = tbStationName.Text
            .note = tbNote.Text
            .nbErrDisk = systemLogErrorCount.iNumDiskBlockErrorOnSystemDisk
            .nbErrNetwork = systemLogErrorCount.iNumNetworkError
            .nbErrShutdown = systemLogErrorCount.iNumShutdownError
            .nbErrBsod = systemLogErrorCount.iNumBsobError
            .favorisDate = Date.Now
        End With

        If program.preferences.colFavoris.Add(favoris) <> -1 Then
            program.frmMdiContainer.reloadMenuFavorisFromPreferences()
            program.preferences.colFavoris.writeToXml()
        End If

        Me.Close()
    End Sub

    Private Sub btnAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnnuler.Click
        Me.Close()
    End Sub
End Class