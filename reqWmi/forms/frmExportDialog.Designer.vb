<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportDialog
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
        Me.pbExport = New System.Windows.Forms.ProgressBar
        Me.tbExport = New System.Windows.Forms.TextBox
        Me.lbTraitement = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'pbExport
        '
        Me.pbExport.Location = New System.Drawing.Point(1, 12)
        Me.pbExport.Name = "pbExport"
        Me.pbExport.Size = New System.Drawing.Size(224, 23)
        Me.pbExport.TabIndex = 0
        '
        'tbExport
        '
        Me.tbExport.Location = New System.Drawing.Point(143, 42)
        Me.tbExport.Name = "tbExport"
        Me.tbExport.Size = New System.Drawing.Size(82, 20)
        Me.tbExport.TabIndex = 1
        '
        'lbTraitement
        '
        Me.lbTraitement.AutoSize = True
        Me.lbTraitement.Location = New System.Drawing.Point(71, 45)
        Me.lbTraitement.Name = "lbTraitement"
        Me.lbTraitement.Size = New System.Drawing.Size(66, 13)
        Me.lbTraitement.TabIndex = 2
        Me.lbTraitement.Text = "Traitement : "
        '
        'ExportDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(230, 70)
        Me.Controls.Add(Me.lbTraitement)
        Me.Controls.Add(Me.tbExport)
        Me.Controls.Add(Me.pbExport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ExportDialog"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "ExportDialog"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbExport As System.Windows.Forms.ProgressBar
    Friend WithEvents tbExport As System.Windows.Forms.TextBox
    Friend WithEvents lbTraitement As System.Windows.Forms.Label
End Class
