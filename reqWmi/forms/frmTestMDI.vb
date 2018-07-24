Public Class frmTestMDI
    Public Sub New(ByRef frmMdiParent As Form)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.MdiParent = frmMdiParent
    End Sub
End Class