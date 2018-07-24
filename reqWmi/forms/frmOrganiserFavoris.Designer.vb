<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrganiserFavoris
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
        Me.components = New System.ComponentModel.Container
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lvStationsFavoris = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.tbNote = New System.Windows.Forms.TextBox
        Me.ContextMenuStriplvFavoris = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ScannerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SupprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStriplvFavoris.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lvStationsFavoris)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbNote)
        Me.SplitContainer1.Size = New System.Drawing.Size(547, 389)
        Me.SplitContainer1.SplitterDistance = 257
        Me.SplitContainer1.TabIndex = 0
        '
        'lvStationsFavoris
        '
        Me.lvStationsFavoris.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvStationsFavoris.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvStationsFavoris.FullRowSelect = True
        Me.lvStationsFavoris.Location = New System.Drawing.Point(0, 0)
        Me.lvStationsFavoris.Name = "lvStationsFavoris"
        Me.lvStationsFavoris.Size = New System.Drawing.Size(543, 253)
        Me.lvStationsFavoris.TabIndex = 0
        Me.lvStationsFavoris.UseCompatibleStateImageBehavior = False
        Me.lvStationsFavoris.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Date"
        Me.ColumnHeader1.Width = 93
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Station"
        Me.ColumnHeader2.Width = 86
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "nbErrDisk"
        Me.ColumnHeader3.Width = 93
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "nbErrNetwork"
        Me.ColumnHeader4.Width = 93
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "nbErrShutdown"
        Me.ColumnHeader5.Width = 87
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "nbErrBSOD"
        Me.ColumnHeader6.Width = 89
        '
        'tbNote
        '
        Me.tbNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbNote.Location = New System.Drawing.Point(0, 0)
        Me.tbNote.Multiline = True
        Me.tbNote.Name = "tbNote"
        Me.tbNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbNote.Size = New System.Drawing.Size(543, 124)
        Me.tbNote.TabIndex = 0
        '
        'ContextMenuStriplvFavoris
        '
        Me.ContextMenuStriplvFavoris.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScannerToolStripMenuItem, Me.SupprimerToolStripMenuItem})
        Me.ContextMenuStriplvFavoris.Name = "ContextMenuStriplvFavoris"
        Me.ContextMenuStriplvFavoris.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStriplvFavoris.Size = New System.Drawing.Size(153, 70)
        '
        'ScannerToolStripMenuItem
        '
        Me.ScannerToolStripMenuItem.Name = "ScannerToolStripMenuItem"
        Me.ScannerToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ScannerToolStripMenuItem.Text = "Scanner"
        '
        'SupprimerToolStripMenuItem
        '
        Me.SupprimerToolStripMenuItem.Name = "SupprimerToolStripMenuItem"
        Me.SupprimerToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SupprimerToolStripMenuItem.Text = "Supprimer"
        '
        'frmOrganiserFavoris
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 389)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmOrganiserFavoris"
        Me.Text = "Organiser Favoris"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStriplvFavoris.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lvStationsFavoris As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tbNote As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStriplvFavoris As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ScannerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupprimerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
