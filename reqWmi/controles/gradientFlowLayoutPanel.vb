Imports System.Drawing.Drawing2D

Public Class gradientFlowLayoutPanel
    Inherits FlowLayoutPanel

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SetStyle(ControlStyles.UserPaint, True)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Add your custom paint code here
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Using brush As LinearGradientBrush = New LinearGradientBrush(ClientRectangle, Color.Lavender, Color.White, LinearGradientMode.Horizontal)
            e.Graphics.FillRectangle(brush, ClientRectangle)
        End Using
    End Sub

End Class
