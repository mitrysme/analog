<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreferences
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
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnSavePreferences = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tbSccmPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btSccmViewerPathChange = New System.Windows.Forms.Button()
        Me.btVncPathChange = New System.Windows.Forms.Button()
        Me.tbVncPath = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSite = New System.Windows.Forms.ComboBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.cbInfo = New System.Windows.Forms.CheckBox()
        Me.cbDebug = New System.Windows.Forms.CheckBox()
        Me.cbErreur = New System.Windows.Forms.CheckBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lblPingTimeoutDesc = New System.Windows.Forms.Label()
        Me.lblPingTimeout = New System.Windows.Forms.Label()
        Me.tbPingTimeout = New System.Windows.Forms.TextBox()
        Me.cbSaveSession = New System.Windows.Forms.CheckBox()
        Me.cbAnimateGraphs = New System.Windows.Forms.CheckBox()
        Me.cbGraphAntialiasing = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbMajGraphsDelay = New System.Windows.Forms.ComboBox()
        Me.cbSavePanelState = New System.Windows.Forms.CheckBox()
        Me.cbSaveWindowPos = New System.Windows.Forms.CheckBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbDBDataSource = New System.Windows.Forms.TextBox()
        Me.tbDBUser = New System.Windows.Forms.TextBox()
        Me.tbDBPassword = New System.Windows.Forms.TextBox()
        Me.tbDBServer = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSavePreferences
        '
        Me.btnSavePreferences.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnSavePreferences.Location = New System.Drawing.Point(0, 263)
        Me.btnSavePreferences.Name = "btnSavePreferences"
        Me.btnSavePreferences.Size = New System.Drawing.Size(722, 23)
        Me.btnSavePreferences.TabIndex = 3
        Me.btnSavePreferences.Text = "Sauver"
        Me.btnSavePreferences.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(722, 263)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tbSccmPath)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.btSccmViewerPathChange)
        Me.TabPage1.Controls.Add(Me.btVncPathChange)
        Me.TabPage1.Controls.Add(Me.tbVncPath)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.cbSite)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(714, 237)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Chemins"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tbSccmPath
        '
        Me.tbSccmPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSccmPath.Location = New System.Drawing.Point(144, 81)
        Me.tbSccmPath.Name = "tbSccmPath"
        Me.tbSccmPath.Size = New System.Drawing.Size(517, 20)
        Me.tbSccmPath.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Chemin exe Viewer Sccm"
        '
        'btSccmViewerPathChange
        '
        Me.btSccmViewerPathChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSccmViewerPathChange.BackgroundImage = Global.My.Resources.Resources._48px_Folder_svg
        Me.btSccmViewerPathChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btSccmViewerPathChange.Location = New System.Drawing.Point(667, 80)
        Me.btSccmViewerPathChange.Name = "btSccmViewerPathChange"
        Me.btSccmViewerPathChange.Size = New System.Drawing.Size(37, 23)
        Me.btSccmViewerPathChange.TabIndex = 10
        Me.btSccmViewerPathChange.UseVisualStyleBackColor = True
        '
        'btVncPathChange
        '
        Me.btVncPathChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btVncPathChange.BackgroundImage = Global.My.Resources.Resources._48px_Folder_svg
        Me.btVncPathChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btVncPathChange.Location = New System.Drawing.Point(667, 46)
        Me.btVncPathChange.Name = "btVncPathChange"
        Me.btVncPathChange.Size = New System.Drawing.Size(37, 23)
        Me.btVncPathChange.TabIndex = 9
        Me.btVncPathChange.UseVisualStyleBackColor = True
        '
        'tbVncPath
        '
        Me.tbVncPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbVncPath.Location = New System.Drawing.Point(144, 48)
        Me.tbVncPath.Name = "tbVncPath"
        Me.tbVncPath.Size = New System.Drawing.Size(517, 20)
        Me.tbVncPath.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Chemin exe Vnc"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Site par défaut"
        '
        'cbSite
        '
        Me.cbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSite.FormattingEnabled = True
        Me.cbSite.Location = New System.Drawing.Point(100, 12)
        Me.cbSite.Name = "cbSite"
        Me.cbSite.Size = New System.Drawing.Size(121, 21)
        Me.cbSite.TabIndex = 3
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.cbInfo)
        Me.TabPage3.Controls.Add(Me.cbDebug)
        Me.TabPage3.Controls.Add(Me.cbErreur)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(714, 237)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Log"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'cbInfo
        '
        Me.cbInfo.AutoSize = True
        Me.cbInfo.Location = New System.Drawing.Point(8, 58)
        Me.cbInfo.Name = "cbInfo"
        Me.cbInfo.Size = New System.Drawing.Size(51, 17)
        Me.cbInfo.TabIndex = 3
        Me.cbInfo.Text = "INFO"
        Me.cbInfo.UseVisualStyleBackColor = True
        '
        'cbDebug
        '
        Me.cbDebug.AutoSize = True
        Me.cbDebug.Location = New System.Drawing.Point(8, 12)
        Me.cbDebug.Name = "cbDebug"
        Me.cbDebug.Size = New System.Drawing.Size(64, 17)
        Me.cbDebug.TabIndex = 2
        Me.cbDebug.Text = "DEBUG"
        Me.cbDebug.UseVisualStyleBackColor = True
        '
        'cbErreur
        '
        Me.cbErreur.AutoSize = True
        Me.cbErreur.Location = New System.Drawing.Point(8, 35)
        Me.cbErreur.Name = "cbErreur"
        Me.cbErreur.Size = New System.Drawing.Size(72, 17)
        Me.cbErreur.TabIndex = 1
        Me.cbErreur.Text = "ERREUR"
        Me.cbErreur.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.lblPingTimeoutDesc)
        Me.TabPage4.Controls.Add(Me.lblPingTimeout)
        Me.TabPage4.Controls.Add(Me.tbPingTimeout)
        Me.TabPage4.Controls.Add(Me.cbSaveSession)
        Me.TabPage4.Controls.Add(Me.cbAnimateGraphs)
        Me.TabPage4.Controls.Add(Me.cbGraphAntialiasing)
        Me.TabPage4.Controls.Add(Me.Label10)
        Me.TabPage4.Controls.Add(Me.Label4)
        Me.TabPage4.Controls.Add(Me.cmbMajGraphsDelay)
        Me.TabPage4.Controls.Add(Me.cbSavePanelState)
        Me.TabPage4.Controls.Add(Me.cbSaveWindowPos)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(714, 237)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Interface"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'lblPingTimeoutDesc
        '
        Me.lblPingTimeoutDesc.AutoSize = True
        Me.lblPingTimeoutDesc.Location = New System.Drawing.Point(209, 109)
        Me.lblPingTimeoutDesc.Name = "lblPingTimeoutDesc"
        Me.lblPingTimeoutDesc.Size = New System.Drawing.Size(92, 13)
        Me.lblPingTimeoutDesc.TabIndex = 17
        Me.lblPingTimeoutDesc.Text = "( 1000 - 4000 ms )"
        '
        'lblPingTimeout
        '
        Me.lblPingTimeout.AutoSize = True
        Me.lblPingTimeout.Location = New System.Drawing.Point(7, 110)
        Me.lblPingTimeout.Name = "lblPingTimeout"
        Me.lblPingTimeout.Size = New System.Drawing.Size(65, 13)
        Me.lblPingTimeout.TabIndex = 16
        Me.lblPingTimeout.Text = "Ping timeout"
        '
        'tbPingTimeout
        '
        Me.tbPingTimeout.Location = New System.Drawing.Point(100, 107)
        Me.tbPingTimeout.Name = "tbPingTimeout"
        Me.tbPingTimeout.Size = New System.Drawing.Size(100, 20)
        Me.tbPingTimeout.TabIndex = 15
        '
        'cbSaveSession
        '
        Me.cbSaveSession.AutoSize = True
        Me.cbSaveSession.Location = New System.Drawing.Point(209, 15)
        Me.cbSaveSession.Name = "cbSaveSession"
        Me.cbSaveSession.Size = New System.Drawing.Size(111, 17)
        Me.cbSaveSession.TabIndex = 14
        Me.cbSaveSession.Text = "Restaurer Onglets"
        Me.cbSaveSession.UseVisualStyleBackColor = True
        '
        'cbAnimateGraphs
        '
        Me.cbAnimateGraphs.AutoSize = True
        Me.cbAnimateGraphs.Location = New System.Drawing.Point(8, 88)
        Me.cbAnimateGraphs.Name = "cbAnimateGraphs"
        Me.cbAnimateGraphs.Size = New System.Drawing.Size(115, 17)
        Me.cbAnimateGraphs.TabIndex = 13
        Me.cbAnimateGraphs.Text = "Animer Graphiques"
        Me.cbAnimateGraphs.UseVisualStyleBackColor = True
        '
        'cbGraphAntialiasing
        '
        Me.cbGraphAntialiasing.AutoSize = True
        Me.cbGraphAntialiasing.Location = New System.Drawing.Point(8, 65)
        Me.cbGraphAntialiasing.Name = "cbGraphAntialiasing"
        Me.cbGraphAntialiasing.Size = New System.Drawing.Size(104, 17)
        Me.cbGraphAntialiasing.TabIndex = 12
        Me.cbGraphAntialiasing.Text = "Lissage Courbes"
        Me.cbGraphAntialiasing.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(221, 150)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = " Redémarrage nécessaire"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Délai Maj Graphs (secondes)"
        '
        'cmbMajGraphsDelay
        '
        Me.cmbMajGraphsDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMajGraphsDelay.FormattingEnabled = True
        Me.cmbMajGraphsDelay.Items.AddRange(New Object() {"1", "3", "5"})
        Me.cmbMajGraphsDelay.Location = New System.Drawing.Point(170, 147)
        Me.cmbMajGraphsDelay.Name = "cmbMajGraphsDelay"
        Me.cmbMajGraphsDelay.Size = New System.Drawing.Size(45, 21)
        Me.cmbMajGraphsDelay.TabIndex = 6
        '
        'cbSavePanelState
        '
        Me.cbSavePanelState.AutoSize = True
        Me.cbSavePanelState.Location = New System.Drawing.Point(8, 40)
        Me.cbSavePanelState.Name = "cbSavePanelState"
        Me.cbSavePanelState.Size = New System.Drawing.Size(129, 17)
        Me.cbSavePanelState.TabIndex = 5
        Me.cbSavePanelState.Text = "Conserver etat panels"
        Me.cbSavePanelState.UseVisualStyleBackColor = True
        '
        'cbSaveWindowPos
        '
        Me.cbSaveWindowPos.AutoSize = True
        Me.cbSaveWindowPos.Location = New System.Drawing.Point(8, 15)
        Me.cbSaveWindowPos.Name = "cbSaveWindowPos"
        Me.cbSaveWindowPos.Size = New System.Drawing.Size(149, 17)
        Me.cbSaveWindowPos.TabIndex = 3
        Me.cbSaveWindowPos.Text = "Conserver position fenêtre"
        Me.cbSaveWindowPos.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Label9)
        Me.TabPage5.Controls.Add(Me.Label8)
        Me.TabPage5.Controls.Add(Me.Label7)
        Me.TabPage5.Controls.Add(Me.Label6)
        Me.TabPage5.Controls.Add(Me.tbDBDataSource)
        Me.TabPage5.Controls.Add(Me.tbDBUser)
        Me.TabPage5.Controls.Add(Me.tbDBPassword)
        Me.TabPage5.Controls.Add(Me.tbDBServer)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(714, 237)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Base"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Base"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Utilisateur"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Passe"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Serveur"
        '
        'tbDBDataSource
        '
        Me.tbDBDataSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDBDataSource.Location = New System.Drawing.Point(94, 36)
        Me.tbDBDataSource.Name = "tbDBDataSource"
        Me.tbDBDataSource.Size = New System.Drawing.Size(304, 20)
        Me.tbDBDataSource.TabIndex = 1
        '
        'tbDBUser
        '
        Me.tbDBUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDBUser.Location = New System.Drawing.Point(94, 62)
        Me.tbDBUser.Name = "tbDBUser"
        Me.tbDBUser.Size = New System.Drawing.Size(304, 20)
        Me.tbDBUser.TabIndex = 2
        '
        'tbDBPassword
        '
        Me.tbDBPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDBPassword.Location = New System.Drawing.Point(94, 88)
        Me.tbDBPassword.Name = "tbDBPassword"
        Me.tbDBPassword.Size = New System.Drawing.Size(304, 20)
        Me.tbDBPassword.TabIndex = 3
        '
        'tbDBServer
        '
        Me.tbDBServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDBServer.Location = New System.Drawing.Point(94, 10)
        Me.tbDBServer.Name = "tbDBServer"
        Me.tbDBServer.Size = New System.Drawing.Size(304, 20)
        Me.tbDBServer.TabIndex = 0
        '
        'frmPreferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 286)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnSavePreferences)
        Me.Name = "frmPreferences"
        Me.Text = "Preferences"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnSavePreferences As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents cbDebug As System.Windows.Forms.CheckBox
    Friend WithEvents cbErreur As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbSite As System.Windows.Forms.ComboBox
    Friend WithEvents btVncPathChange As System.Windows.Forms.Button
    Friend WithEvents tbVncPath As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents cbSavePanelState As System.Windows.Forms.CheckBox
    Friend WithEvents cbSaveWindowPos As System.Windows.Forms.CheckBox
    Friend WithEvents cbInfo As System.Windows.Forms.CheckBox
    Friend WithEvents cmbMajGraphsDelay As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbDBDataSource As System.Windows.Forms.TextBox
    Friend WithEvents tbDBUser As System.Windows.Forms.TextBox
    Friend WithEvents tbDBPassword As System.Windows.Forms.TextBox
    Friend WithEvents tbDBServer As System.Windows.Forms.TextBox
    Friend WithEvents cbGraphAntialiasing As System.Windows.Forms.CheckBox
    Friend WithEvents cbAnimateGraphs As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbSaveSession As System.Windows.Forms.CheckBox
    Friend WithEvents btSccmViewerPathChange As System.Windows.Forms.Button
    Friend WithEvents tbSccmPath As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPingTimeoutDesc As Label
    Friend WithEvents lblPingTimeout As Label
    Friend WithEvents tbPingTimeout As TextBox
End Class
