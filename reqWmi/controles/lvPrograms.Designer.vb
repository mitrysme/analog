<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class lvPrograms
    Inherits baseLv

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.components = New System.ComponentModel.Container
        Me.ContextMenuStripPrograms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemCopyUninstallString = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStripPrograms.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStripPrograms
        '
        Me.ContextMenuStripPrograms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemCopyUninstallString})
        Me.ContextMenuStripPrograms.Name = "ContextMenuStripPrograms"
        Me.ContextMenuStripPrograms.Size = New System.Drawing.Size(217, 26)
        Me.ContextMenuStripPrograms.Text = "Copier chaine désinstallation"
        '
        'ToolStripMenuItemCopyUninstallString
        '
        Me.ToolStripMenuItemCopyUninstallString.Name = "ToolStripMenuItemCopyUninstallString"
        Me.ToolStripMenuItemCopyUninstallString.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItemCopyUninstallString.Text = "Copier chaine déinstallation"
        '
        'lvPrograms
        '
        Me.Name = "lvInfoProgram"
        Me.ContextMenuStripPrograms.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStripPrograms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemCopyUninstallString As System.Windows.Forms.ToolStripMenuItem

End Class
