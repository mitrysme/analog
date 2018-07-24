Public Class DBTableLayoutPanel
    Inherits TableLayoutPanel

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        MyBase.New()

        ' Add any initialization after the InitializeComponent() call.
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        'Me.DoubleBuffered = True
    End Sub

End Class
