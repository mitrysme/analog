<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServerPreferences
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
        Me.gpbPath = New System.Windows.Forms.GroupBox
        Me.btnChangeResultsFolder = New System.Windows.Forms.Button
        Me.btnChangeStationToScan = New System.Windows.Forms.Button
        Me.txtbPathFolderResults = New System.Windows.Forms.TextBox
        Me.lbPathScanResult = New System.Windows.Forms.Label
        Me.txtbPathListeStations = New System.Windows.Forms.TextBox
        Me.lbPathScanListStationToScan = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.gpbPath.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpbPath
        '
        Me.gpbPath.BackColor = System.Drawing.SystemColors.Control
        Me.gpbPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.gpbPath.Controls.Add(Me.btnChangeResultsFolder)
        Me.gpbPath.Controls.Add(Me.btnChangeStationToScan)
        Me.gpbPath.Controls.Add(Me.txtbPathFolderResults)
        Me.gpbPath.Controls.Add(Me.lbPathScanResult)
        Me.gpbPath.Controls.Add(Me.txtbPathListeStations)
        Me.gpbPath.Controls.Add(Me.lbPathScanListStationToScan)
        Me.gpbPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpbPath.Location = New System.Drawing.Point(0, 0)
        Me.gpbPath.Name = "gpbPath"
        Me.gpbPath.Size = New System.Drawing.Size(416, 120)
        Me.gpbPath.TabIndex = 0
        Me.gpbPath.TabStop = False
        Me.gpbPath.Text = "Chemins"
        '
        'btnChangeResultsFolder
        '
        Me.btnChangeResultsFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChangeResultsFolder.Location = New System.Drawing.Point(328, 49)
        Me.btnChangeResultsFolder.Name = "btnChangeResultsFolder"
        Me.btnChangeResultsFolder.Size = New System.Drawing.Size(75, 23)
        Me.btnChangeResultsFolder.TabIndex = 5
        Me.btnChangeResultsFolder.Text = "Changer"
        Me.btnChangeResultsFolder.UseVisualStyleBackColor = True
        '
        'btnChangeStationToScan
        '
        Me.btnChangeStationToScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChangeStationToScan.Location = New System.Drawing.Point(329, 24)
        Me.btnChangeStationToScan.Name = "btnChangeStationToScan"
        Me.btnChangeStationToScan.Size = New System.Drawing.Size(75, 22)
        Me.btnChangeStationToScan.TabIndex = 4
        Me.btnChangeStationToScan.Text = "Changer"
        Me.btnChangeStationToScan.UseVisualStyleBackColor = True
        '
        'txtbPathFolderResults
        '
        Me.txtbPathFolderResults.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtbPathFolderResults.Location = New System.Drawing.Point(137, 51)
        Me.txtbPathFolderResults.Name = "txtbPathFolderResults"
        Me.txtbPathFolderResults.Size = New System.Drawing.Size(185, 20)
        Me.txtbPathFolderResults.TabIndex = 3
        '
        'lbPathScanResult
        '
        Me.lbPathScanResult.AutoSize = True
        Me.lbPathScanResult.Location = New System.Drawing.Point(16, 54)
        Me.lbPathScanResult.Name = "lbPathScanResult"
        Me.lbPathScanResult.Size = New System.Drawing.Size(87, 13)
        Me.lbPathScanResult.TabIndex = 2
        Me.lbPathScanResult.Text = "dossier Résultats"
        '
        'txtbPathListeStations
        '
        Me.txtbPathListeStations.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtbPathListeStations.Location = New System.Drawing.Point(137, 25)
        Me.txtbPathListeStations.Name = "txtbPathListeStations"
        Me.txtbPathListeStations.Size = New System.Drawing.Size(185, 20)
        Me.txtbPathListeStations.TabIndex = 1
        '
        'lbPathScanListStationToScan
        '
        Me.lbPathScanListStationToScan.AutoSize = True
        Me.lbPathScanListStationToScan.Location = New System.Drawing.Point(16, 28)
        Me.lbPathScanListStationToScan.Name = "lbPathScanListStationToScan"
        Me.lbPathScanListStationToScan.Size = New System.Drawing.Size(100, 13)
        Me.lbPathScanListStationToScan.TabIndex = 0
        Me.lbPathScanListStationToScan.Text = "dossier liste stations"
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnSave.ForeColor = System.Drawing.SystemColors.InfoText
        Me.btnSave.Location = New System.Drawing.Point(0, 97)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(416, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Sauver"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmServerPreferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 120)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gpbPath)
        Me.Name = "frmServerPreferences"
        Me.Text = "Préférences"
        Me.gpbPath.ResumeLayout(False)
        Me.gpbPath.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpbPath As System.Windows.Forms.GroupBox
    Friend WithEvents btnChangeResultsFolder As System.Windows.Forms.Button
    Friend WithEvents btnChangeStationToScan As System.Windows.Forms.Button
    Friend WithEvents txtbPathFolderResults As System.Windows.Forms.TextBox
    Friend WithEvents lbPathScanResult As System.Windows.Forms.Label
    Friend WithEvents txtbPathListeStations As System.Windows.Forms.TextBox
    Friend WithEvents lbPathScanListStationToScan As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
