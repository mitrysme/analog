Public Class tbErrorRedGreen
    Inherits TextBox

    Public Sub New()
        MyBase.new()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.ReadOnly = True
    End Sub

    Private Sub text_changed() Handles Me.TextChanged
        If Not Me.Text = "" Then
            Dim intVal As Integer
            If Integer.TryParse(Text, intVal) Then
                Select Case intVal
                    Case 0
                        Me.BackColor = Color.LightGreen
                    Case Else
                        Me.BackColor = Color.Red
                End Select
            Else
                Me.BackColor = Color.LightGray
            End If
        Else
            Me.BackColor = Color.LightGray
        End If
    End Sub

End Class
