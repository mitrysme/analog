<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class lvProcess
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
        Me.ContextMenuStripProcess = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.KillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InfosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InternetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStripProcess.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStripProcess
        '
        Me.ContextMenuStripProcess.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KillToolStripMenuItem, Me.InfosToolStripMenuItem, Me.InternetToolStripMenuItem})
        Me.ContextMenuStripProcess.Name = "ContextMenuStripProcess"
        Me.ContextMenuStripProcess.Size = New System.Drawing.Size(153, 92)
        '
        'KillToolStripMenuItem
        '
        Me.KillToolStripMenuItem.Image = Global.My.Resources.Resources.cross16
        Me.KillToolStripMenuItem.Name = "KillToolStripMenuItem"
        Me.KillToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.KillToolStripMenuItem.Text = "Kill"
        '
        'InfosToolStripMenuItem
        '
        Me.InfosToolStripMenuItem.Enabled = False
        Me.InfosToolStripMenuItem.Image = Global.My.Resources.Resources.info32
        Me.InfosToolStripMenuItem.Name = "InfosToolStripMenuItem"
        Me.InfosToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.InfosToolStripMenuItem.Text = "Infos"
        '
        'InternetToolStripMenuItem
        '
        Me.InternetToolStripMenuItem.Image = Global.My.Resources.Resources.ie716
        Me.InternetToolStripMenuItem.Name = "InternetToolStripMenuItem"
        Me.InternetToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.InternetToolStripMenuItem.Text = "Internet"
        Me.ContextMenuStripProcess.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStripProcess As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents KillToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InternetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
