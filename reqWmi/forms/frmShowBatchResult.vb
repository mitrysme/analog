Public Class frmShowBatchResult
    ' Private _BatchResult As structs.analogStructs.BatchResult

    Public Sub frm_load() Handles Me.Load
        Me.CenterToParent()
    End Sub

    Public Sub New(ByVal batchresult As structs.analogStructs.BatchResult)
        InitializeComponent()

        ' _BatchResult = batchresult
        render(batchresult)
    End Sub

    Private Sub render(ByVal br As structs.analogStructs.BatchResult)
        With br
            Me.tbConstructeur.Text = .constructeur
            Me.tbDateScan.Text = .dateScan.ToLongDateString
            Me.tbFreeSpace.Text = .freeSpaceOnSystemDisk
            Me.tbModele.Text = .modele
            Me.tbOsName.Text = .osName
            Me.tbRam.Text = convRamAsUlongToString(.ram)
            Me.TbRDriverFail.Text = .driverPredictFail.ToString
            Me.TbRgErrBloc.Text = .errDisk.ToString
            Me.TbRgErrBsod.Text = .errBsod.ToString
            Me.TbRgErrNetwork.Text = .errNetwork.ToString
            Me.TbRgErrReboot.Text = .errReboot.ToString
            If Not .errMessage Is Nothing Then
                Me.tbScanErrorMsg.Text = .errMessage.ToString
            End If
            Me.tbSn.Text = .sn
            Me.tbSocle.Text = .socle
            Me.tbStationName.Text = .stationName
        End With
    End Sub
   
End Class