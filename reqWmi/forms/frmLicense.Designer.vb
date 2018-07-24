<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class License
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(License))
        Me.RichTextBoxLicense = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'RichTextBoxLicense
        '
        Me.RichTextBoxLicense.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBoxLicense.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBoxLicense.Name = "RichTextBoxLicense"
        Me.RichTextBoxLicense.Size = New System.Drawing.Size(292, 266)
        Me.RichTextBoxLicense.TabIndex = 0
        Me.RichTextBoxLicense.Text = resources.GetString("RichTextBoxLicense.Text")
        '
        'License
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.RichTextBoxLicense)
        Me.Name = "License"
        Me.Text = "frmLicense"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RichTextBoxLicense As System.Windows.Forms.RichTextBox
End Class
