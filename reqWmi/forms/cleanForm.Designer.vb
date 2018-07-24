<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cleanForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstCleanLog = New System.Windows.Forms.ListBox
        Me.statusBar = New System.Windows.Forms.StatusStrip
        Me.progressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.tlstripStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.btnStartClean = New System.Windows.Forms.Button
        Me.btnAbortClean = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtbStation = New System.Windows.Forms.TextBox
        Me.lblStation = New System.Windows.Forms.Label
        Me.txtProfil = New System.Windows.Forms.TextBox
        Me.lblProfil = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtProcessingFile = New System.Windows.Forms.TextBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SauverLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.statusBar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstCleanLog
        '
        Me.lstCleanLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstCleanLog.FormattingEnabled = True
        Me.lstCleanLog.Location = New System.Drawing.Point(0, 150)
        Me.lstCleanLog.Name = "lstCleanLog"
        Me.lstCleanLog.Size = New System.Drawing.Size(630, 212)
        Me.lstCleanLog.TabIndex = 0
        '
        'statusBar
        '
        Me.statusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.progressBar, Me.tlstripStatus})
        Me.statusBar.Location = New System.Drawing.Point(0, 377)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(630, 22)
        Me.statusBar.TabIndex = 1
        Me.statusBar.Text = "StatusStrip1"
        '
        'progressBar
        '
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(140, 16)
        '
        'tlstripStatus
        '
        Me.tlstripStatus.Name = "tlstripStatus"
        Me.tlstripStatus.Size = New System.Drawing.Size(0, 17)
        '
        'btnStartClean
        '
        Me.btnStartClean.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnStartClean.Location = New System.Drawing.Point(548, 0)
        Me.btnStartClean.Name = "btnStartClean"
        Me.btnStartClean.Size = New System.Drawing.Size(78, 23)
        Me.btnStartClean.TabIndex = 2
        Me.btnStartClean.Text = "Démarrer"
        Me.btnStartClean.UseVisualStyleBackColor = True
        '
        'btnAbortClean
        '
        Me.btnAbortClean.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAbortClean.Location = New System.Drawing.Point(473, 0)
        Me.btnAbortClean.Name = "btnAbortClean"
        Me.btnAbortClean.Size = New System.Drawing.Size(75, 23)
        Me.btnAbortClean.TabIndex = 3
        Me.btnAbortClean.Text = "Abandonner"
        Me.btnAbortClean.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.btnAbortClean)
        Me.Panel1.Controls.Add(Me.btnStartClean)
        Me.Panel1.Location = New System.Drawing.Point(1, 115)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(626, 23)
        Me.Panel1.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.txtbStation)
        Me.Panel2.Controls.Add(Me.lblStation)
        Me.Panel2.Controls.Add(Me.txtProfil)
        Me.Panel2.Controls.Add(Me.lblProfil)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtProcessingFile)
        Me.Panel2.Location = New System.Drawing.Point(-1, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(628, 87)
        Me.Panel2.TabIndex = 5
        '
        'txtbStation
        '
        Me.txtbStation.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtbStation.Location = New System.Drawing.Point(82, 10)
        Me.txtbStation.Name = "txtbStation"
        Me.txtbStation.ReadOnly = True
        Me.txtbStation.Size = New System.Drawing.Size(144, 20)
        Me.txtbStation.TabIndex = 5
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(13, 10)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(46, 13)
        Me.lblStation.TabIndex = 4
        Me.lblStation.Text = "Station :"
        '
        'txtProfil
        '
        Me.txtProfil.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProfil.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtProfil.Location = New System.Drawing.Point(82, 57)
        Me.txtProfil.Name = "txtProfil"
        Me.txtProfil.ReadOnly = True
        Me.txtProfil.Size = New System.Drawing.Size(541, 20)
        Me.txtProfil.TabIndex = 3
        '
        'lblProfil
        '
        Me.lblProfil.AutoSize = True
        Me.lblProfil.Location = New System.Drawing.Point(13, 64)
        Me.lblProfil.Name = "lblProfil"
        Me.lblProfil.Size = New System.Drawing.Size(36, 13)
        Me.lblProfil.TabIndex = 2
        Me.lblProfil.Text = "Profil :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fichier :"
        '
        'txtProcessingFile
        '
        Me.txtProcessingFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProcessingFile.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtProcessingFile.Location = New System.Drawing.Point(82, 33)
        Me.txtProcessingFile.Name = "txtProcessingFile"
        Me.txtProcessingFile.ReadOnly = True
        Me.txtProcessingFile.Size = New System.Drawing.Size(541, 20)
        Me.txtProcessingFile.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichierToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(630, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SauverLogToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        Me.FichierToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.FichierToolStripMenuItem.Text = "Fichier"
        '
        'SauverLogToolStripMenuItem
        '
        Me.SauverLogToolStripMenuItem.Name = "SauverLogToolStripMenuItem"
        Me.SauverLogToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.SauverLogToolStripMenuItem.Text = "Sauver log"
        '
        'cleanForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 399)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.statusBar)
        Me.Controls.Add(Me.lstCleanLog)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "cleanForm"
        Me.Text = "cleanForm"
        Me.statusBar.ResumeLayout(False)
        Me.statusBar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstCleanLog As System.Windows.Forms.ListBox
    Friend WithEvents statusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents progressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tlstripStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnStartClean As System.Windows.Forms.Button
    Friend WithEvents btnAbortClean As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProcessingFile As System.Windows.Forms.TextBox
    Friend WithEvents lblProfil As System.Windows.Forms.Label
    Friend WithEvents txtProfil As System.Windows.Forms.TextBox
    Friend WithEvents txtbStation As System.Windows.Forms.TextBox
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FichierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SauverLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
