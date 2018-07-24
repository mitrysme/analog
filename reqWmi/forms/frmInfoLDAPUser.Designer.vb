<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfoLDAPUser
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbLdapAccountSN = New System.Windows.Forms.TextBox
        Me.tbLdapAccountFullName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbLdapAccountMail = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbPasswordNeverExpire = New System.Windows.Forms.CheckBox
        Me.cbExpiredPassword = New System.Windows.Forms.CheckBox
        Me.cbUserCannotChangePassword = New System.Windows.Forms.CheckBox
        Me.cbDisabledAccount = New System.Windows.Forms.CheckBox
        Me.tbLdapAccountComments = New System.Windows.Forms.TextBox
        Me.tbLdapAccountLogonScriptPath = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.tbLdapAccountSID = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.tbLdapUserSearch = New System.Windows.Forms.TextBox
        Me.TabUserLdapInfos = New System.Windows.Forms.TabControl
        Me.TabUserInfos = New System.Windows.Forms.TabPage
        Me.Label10 = New System.Windows.Forms.Label
        Me.tbLdapAccountgivenName = New System.Windows.Forms.TextBox
        Me.tbLastLogonDateTime = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TabUserGroups = New System.Windows.Forms.TabPage
        Me.lvLDAPGroups = New System.Windows.Forms.ListView
        Me.ColumnHeaderName = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderADFolder = New System.Windows.Forms.ColumnHeader
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBarLDAP = New System.Windows.Forms.ToolStripProgressBar
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabUserLdapInfos.SuspendLayout()
        Me.TabUserInfos.SuspendLayout()
        Me.TabUserGroups.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nom"
        '
        'tbLdapAccountSN
        '
        Me.tbLdapAccountSN.Location = New System.Drawing.Point(176, 6)
        Me.tbLdapAccountSN.Name = "tbLdapAccountSN"
        Me.tbLdapAccountSN.ReadOnly = True
        Me.tbLdapAccountSN.Size = New System.Drawing.Size(148, 20)
        Me.tbLdapAccountSN.TabIndex = 1
        '
        'tbLdapAccountFullName
        '
        Me.tbLdapAccountFullName.Location = New System.Drawing.Point(176, 34)
        Me.tbLdapAccountFullName.Name = "tbLdapAccountFullName"
        Me.tbLdapAccountFullName.ReadOnly = True
        Me.tbLdapAccountFullName.Size = New System.Drawing.Size(254, 20)
        Me.tbLdapAccountFullName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fullname"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Commentaire"
        '
        'tbLdapAccountMail
        '
        Me.tbLdapAccountMail.Location = New System.Drawing.Point(176, 192)
        Me.tbLdapAccountMail.Name = "tbLdapAccountMail"
        Me.tbLdapAccountMail.ReadOnly = True
        Me.tbLdapAccountMail.Size = New System.Drawing.Size(278, 20)
        Me.tbLdapAccountMail.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 199)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Mail"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbPasswordNeverExpire)
        Me.GroupBox1.Controls.Add(Me.cbExpiredPassword)
        Me.GroupBox1.Controls.Add(Me.cbUserCannotChangePassword)
        Me.GroupBox1.Controls.Add(Me.cbDisabledAccount)
        Me.GroupBox1.Location = New System.Drawing.Point(81, 291)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(421, 142)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Options Compte"
        '
        'cbPasswordNeverExpire
        '
        Me.cbPasswordNeverExpire.AutoSize = True
        Me.cbPasswordNeverExpire.Enabled = False
        Me.cbPasswordNeverExpire.Location = New System.Drawing.Point(25, 90)
        Me.cbPasswordNeverExpire.Name = "cbPasswordNeverExpire"
        Me.cbPasswordNeverExpire.Size = New System.Drawing.Size(175, 17)
        Me.cbPasswordNeverExpire.TabIndex = 3
        Me.cbPasswordNeverExpire.Text = "Le mot de passe n'expire jamais"
        Me.cbPasswordNeverExpire.UseVisualStyleBackColor = True
        '
        'cbExpiredPassword
        '
        Me.cbExpiredPassword.AutoSize = True
        Me.cbExpiredPassword.Enabled = False
        Me.cbExpiredPassword.Location = New System.Drawing.Point(25, 67)
        Me.cbExpiredPassword.Name = "cbExpiredPassword"
        Me.cbExpiredPassword.Size = New System.Drawing.Size(122, 17)
        Me.cbExpiredPassword.TabIndex = 2
        Me.cbExpiredPassword.Text = "Mot de Passe expiré"
        Me.cbExpiredPassword.UseVisualStyleBackColor = True
        '
        'cbUserCannotChangePassword
        '
        Me.cbUserCannotChangePassword.AutoSize = True
        Me.cbUserCannotChangePassword.Enabled = False
        Me.cbUserCannotChangePassword.Location = New System.Drawing.Point(25, 43)
        Me.cbUserCannotChangePassword.Name = "cbUserCannotChangePassword"
        Me.cbUserCannotChangePassword.Size = New System.Drawing.Size(250, 17)
        Me.cbUserCannotChangePassword.TabIndex = 1
        Me.cbUserCannotChangePassword.Text = "Utilisateur ne peut pas changer le mot de passe"
        Me.cbUserCannotChangePassword.UseVisualStyleBackColor = True
        '
        'cbDisabledAccount
        '
        Me.cbDisabledAccount.AutoSize = True
        Me.cbDisabledAccount.Enabled = False
        Me.cbDisabledAccount.Location = New System.Drawing.Point(25, 19)
        Me.cbDisabledAccount.Name = "cbDisabledAccount"
        Me.cbDisabledAccount.Size = New System.Drawing.Size(113, 17)
        Me.cbDisabledAccount.TabIndex = 0
        Me.cbDisabledAccount.Text = "Compte Désactivé"
        Me.cbDisabledAccount.UseVisualStyleBackColor = True
        '
        'tbLdapAccountComments
        '
        Me.tbLdapAccountComments.Location = New System.Drawing.Point(176, 69)
        Me.tbLdapAccountComments.Multiline = True
        Me.tbLdapAccountComments.Name = "tbLdapAccountComments"
        Me.tbLdapAccountComments.ReadOnly = True
        Me.tbLdapAccountComments.Size = New System.Drawing.Size(387, 81)
        Me.tbLdapAccountComments.TabIndex = 5
        '
        'tbLdapAccountLogonScriptPath
        '
        Me.tbLdapAccountLogonScriptPath.Location = New System.Drawing.Point(176, 165)
        Me.tbLdapAccountLogonScriptPath.Name = "tbLdapAccountLogonScriptPath"
        Me.tbLdapAccountLogonScriptPath.ReadOnly = True
        Me.tbLdapAccountLogonScriptPath.Size = New System.Drawing.Size(278, 20)
        Me.tbLdapAccountLogonScriptPath.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 172)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Script Connexion"
        '
        'tbLdapAccountSID
        '
        Me.tbLdapAccountSID.Location = New System.Drawing.Point(176, 218)
        Me.tbLdapAccountSID.Name = "tbLdapAccountSID"
        Me.tbLdapAccountSID.ReadOnly = True
        Me.tbLdapAccountSID.Size = New System.Drawing.Size(278, 20)
        Me.tbLdapAccountSID.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 225)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "SID"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.tbLdapUserSearch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(599, 33)
        Me.Panel1.TabIndex = 19
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.My.Resources.Resources.magnifier
        Me.PictureBox1.Location = New System.Drawing.Point(322, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'tbLdapUserSearch
        '
        Me.tbLdapUserSearch.Location = New System.Drawing.Point(359, 7)
        Me.tbLdapUserSearch.Name = "tbLdapUserSearch"
        Me.tbLdapUserSearch.Size = New System.Drawing.Size(234, 20)
        Me.tbLdapUserSearch.TabIndex = 0
        '
        'TabUserLdapInfos
        '
        Me.TabUserLdapInfos.Controls.Add(Me.TabUserInfos)
        Me.TabUserLdapInfos.Controls.Add(Me.TabUserGroups)
        Me.TabUserLdapInfos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabUserLdapInfos.Location = New System.Drawing.Point(0, 33)
        Me.TabUserLdapInfos.Name = "TabUserLdapInfos"
        Me.TabUserLdapInfos.SelectedIndex = 0
        Me.TabUserLdapInfos.Size = New System.Drawing.Size(599, 487)
        Me.TabUserLdapInfos.TabIndex = 1
        '
        'TabUserInfos
        '
        Me.TabUserInfos.Controls.Add(Me.Label10)
        Me.TabUserInfos.Controls.Add(Me.tbLdapAccountgivenName)
        Me.TabUserInfos.Controls.Add(Me.tbLastLogonDateTime)
        Me.TabUserInfos.Controls.Add(Me.Label9)
        Me.TabUserInfos.Controls.Add(Me.Label1)
        Me.TabUserInfos.Controls.Add(Me.tbLdapAccountSN)
        Me.TabUserInfos.Controls.Add(Me.tbLdapAccountSID)
        Me.TabUserInfos.Controls.Add(Me.Label2)
        Me.TabUserInfos.Controls.Add(Me.Label8)
        Me.TabUserInfos.Controls.Add(Me.tbLdapAccountFullName)
        Me.TabUserInfos.Controls.Add(Me.tbLdapAccountLogonScriptPath)
        Me.TabUserInfos.Controls.Add(Me.Label3)
        Me.TabUserInfos.Controls.Add(Me.Label7)
        Me.TabUserInfos.Controls.Add(Me.tbLdapAccountComments)
        Me.TabUserInfos.Controls.Add(Me.GroupBox1)
        Me.TabUserInfos.Controls.Add(Me.tbLdapAccountMail)
        Me.TabUserInfos.Controls.Add(Me.Label5)
        Me.TabUserInfos.Location = New System.Drawing.Point(4, 22)
        Me.TabUserInfos.Name = "TabUserInfos"
        Me.TabUserInfos.Padding = New System.Windows.Forms.Padding(3)
        Me.TabUserInfos.Size = New System.Drawing.Size(591, 461)
        Me.TabUserInfos.TabIndex = 0
        Me.TabUserInfos.Text = "Infos"
        Me.TabUserInfos.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(330, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Prénom"
        '
        'tbLdapAccountgivenName
        '
        Me.tbLdapAccountgivenName.Location = New System.Drawing.Point(400, 6)
        Me.tbLdapAccountgivenName.Name = "tbLdapAccountgivenName"
        Me.tbLdapAccountgivenName.ReadOnly = True
        Me.tbLdapAccountgivenName.Size = New System.Drawing.Size(163, 20)
        Me.tbLdapAccountgivenName.TabIndex = 22
        '
        'tbLastLogonDateTime
        '
        Me.tbLastLogonDateTime.Location = New System.Drawing.Point(176, 244)
        Me.tbLastLogonDateTime.Name = "tbLastLogonDateTime"
        Me.tbLastLogonDateTime.ReadOnly = True
        Me.tbLastLogonDateTime.Size = New System.Drawing.Size(278, 20)
        Me.tbLastLogonDateTime.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 247)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Dernière Connexion"
        '
        'TabUserGroups
        '
        Me.TabUserGroups.Controls.Add(Me.lvLDAPGroups)
        Me.TabUserGroups.Location = New System.Drawing.Point(4, 22)
        Me.TabUserGroups.Name = "TabUserGroups"
        Me.TabUserGroups.Padding = New System.Windows.Forms.Padding(3)
        Me.TabUserGroups.Size = New System.Drawing.Size(592, 451)
        Me.TabUserGroups.TabIndex = 1
        Me.TabUserGroups.Text = "Groupes"
        Me.TabUserGroups.UseVisualStyleBackColor = True
        '
        'lvLDAPGroups
        '
        Me.lvLDAPGroups.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderName, Me.ColumnHeaderADFolder})
        Me.lvLDAPGroups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvLDAPGroups.FullRowSelect = True
        Me.lvLDAPGroups.Location = New System.Drawing.Point(3, 3)
        Me.lvLDAPGroups.Name = "lvLDAPGroups"
        Me.lvLDAPGroups.Size = New System.Drawing.Size(586, 445)
        Me.lvLDAPGroups.TabIndex = 5
        Me.lvLDAPGroups.UseCompatibleStateImageBehavior = False
        Me.lvLDAPGroups.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderName
        '
        Me.ColumnHeaderName.Text = "Nom"
        Me.ColumnHeaderName.Width = 250
        '
        'ColumnHeaderADFolder
        '
        Me.ColumnHeaderADFolder.Text = "Dossier AD"
        Me.ColumnHeaderADFolder.Width = 255
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBarLDAP})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 498)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(599, 22)
        Me.StatusStrip1.TabIndex = 23
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBarLDAP
        '
        Me.ToolStripProgressBarLDAP.Name = "ToolStripProgressBarLDAP"
        Me.ToolStripProgressBarLDAP.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBarLDAP.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ToolStripProgressBarLDAP.Visible = False
        '
        'frmInfoLDAPUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 520)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabUserLdapInfos)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(607, 554)
        Me.MinimumSize = New System.Drawing.Size(607, 554)
        Me.Name = "frmInfoLDAPUser"
        Me.Text = "frmInfoLDAPUser"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabUserLdapInfos.ResumeLayout(False)
        Me.TabUserInfos.ResumeLayout(False)
        Me.TabUserInfos.PerformLayout()
        Me.TabUserGroups.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbLdapAccountSN As System.Windows.Forms.TextBox
    Friend WithEvents tbLdapAccountFullName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbLdapAccountMail As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbDisabledAccount As System.Windows.Forms.CheckBox
    Friend WithEvents cbUserCannotChangePassword As System.Windows.Forms.CheckBox
    Friend WithEvents cbExpiredPassword As System.Windows.Forms.CheckBox
    Friend WithEvents tbLdapAccountComments As System.Windows.Forms.TextBox
    Friend WithEvents tbLdapAccountLogonScriptPath As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbLdapAccountSID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabUserLdapInfos As System.Windows.Forms.TabControl
    Friend WithEvents TabUserGroups As System.Windows.Forms.TabPage
    Friend WithEvents TabUserInfos As System.Windows.Forms.TabPage
    Friend WithEvents tbLdapUserSearch As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvLDAPGroups As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeaderName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderADFolder As System.Windows.Forms.ColumnHeader
    Friend WithEvents tbLastLogonDateTime As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbPasswordNeverExpire As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbLdapAccountgivenName As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBarLDAP As System.Windows.Forms.ToolStripProgressBar
End Class
