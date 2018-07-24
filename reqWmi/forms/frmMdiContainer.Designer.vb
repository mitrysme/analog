<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMdiContainer
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
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel
        Me.MenuStripMain = New System.Windows.Forms.MenuStrip
        Me.ToolStripMenuItemApplication = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemPreferences = New System.Windows.Forms.ToolStripMenuItem
        Me.QuitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuFavoris = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemAjouterFavoris = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemOrganiserFavoris = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuApropos = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemApropos = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ContentPanel
        '
        Me.ContentPanel.Size = New System.Drawing.Size(581, 501)
        '
        'MenuStripMain
        '
        Me.MenuStripMain.BackColor = System.Drawing.Color.Gainsboro
        Me.MenuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemApplication, Me.ToolStripMenuFavoris, Me.ToolStripMenuApropos})
        Me.MenuStripMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripMain.Name = "MenuStripMain"
        Me.MenuStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStripMain.Size = New System.Drawing.Size(1144, 24)
        Me.MenuStripMain.TabIndex = 0
        Me.MenuStripMain.Text = "MenuStrip1"
        '
        'ToolStripMenuItemApplication
        '
        Me.ToolStripMenuItemApplication.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemPreferences, Me.QuitterToolStripMenuItem})
        Me.ToolStripMenuItemApplication.Name = "ToolStripMenuItemApplication"
        Me.ToolStripMenuItemApplication.Size = New System.Drawing.Size(71, 20)
        Me.ToolStripMenuItemApplication.Text = "Application"
        '
        'ToolStripMenuItemPreferences
        '
        Me.ToolStripMenuItemPreferences.Name = "ToolStripMenuItemPreferences"
        Me.ToolStripMenuItemPreferences.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItemPreferences.Text = "Préférences"
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.QuitterToolStripMenuItem.Text = "Quitter"
        '
        'ToolStripMenuFavoris
        '
        Me.ToolStripMenuFavoris.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemAjouterFavoris, Me.ToolStripMenuItemOrganiserFavoris, Me.ToolStripSeparator2})
        Me.ToolStripMenuFavoris.Name = "ToolStripMenuFavoris"
        Me.ToolStripMenuFavoris.Size = New System.Drawing.Size(54, 20)
        Me.ToolStripMenuFavoris.Text = "Favoris"
        '
        'ToolStripMenuItemAjouterFavoris
        '
        Me.ToolStripMenuItemAjouterFavoris.Name = "ToolStripMenuItemAjouterFavoris"
        Me.ToolStripMenuItemAjouterFavoris.Size = New System.Drawing.Size(132, 22)
        Me.ToolStripMenuItemAjouterFavoris.Tag = "Menu"
        Me.ToolStripMenuItemAjouterFavoris.Text = "Ajouter"
        '
        'ToolStripMenuItemOrganiserFavoris
        '
        Me.ToolStripMenuItemOrganiserFavoris.Name = "ToolStripMenuItemOrganiserFavoris"
        Me.ToolStripMenuItemOrganiserFavoris.Size = New System.Drawing.Size(132, 22)
        Me.ToolStripMenuItemOrganiserFavoris.Tag = "Menu"
        Me.ToolStripMenuItemOrganiserFavoris.Text = "Organiser"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(129, 6)
        '
        'ToolStripMenuApropos
        '
        Me.ToolStripMenuApropos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemApropos})
        Me.ToolStripMenuApropos.Name = "ToolStripMenuApropos"
        Me.ToolStripMenuApropos.Size = New System.Drawing.Size(24, 20)
        Me.ToolStripMenuApropos.Text = "?"
        '
        'ToolStripMenuItemApropos
        '
        Me.ToolStripMenuItemApropos.Image = Global.My.Resources.Resources.help16
        Me.ToolStripMenuItemApropos.Name = "ToolStripMenuItemApropos"
        Me.ToolStripMenuItemApropos.Size = New System.Drawing.Size(128, 22)
        Me.ToolStripMenuItemApropos.Text = "A propos"
        '
        'frmMdiContainer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1144, 849)
        Me.Controls.Add(Me.MenuStripMain)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStripMain
        Me.MinimumSize = New System.Drawing.Size(1152, 34)
        Me.Name = "frmMdiContainer"
        Me.Text = "frmMdiContainer"
        Me.MenuStripMain.ResumeLayout(False)
        Me.MenuStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PréférencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VNCQueryConnectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfosUtilisateurToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PsExecToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DefragToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DefraganalyseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DefragArreterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrêterForcerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedémarrerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedémarrerForcerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChkdskToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChkdskFR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RsopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FavorisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AjouterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrganiserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AfficherPanneauLatéralToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AfficherLogsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NouvelOngletToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AProposToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ContentPanel As System.Windows.Forms.ToolStripContentPanel
    Friend WithEvents MenuStripMain As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItemApplication As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemPreferences As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuApropos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemApropos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuFavoris As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemAjouterFavoris As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemOrganiserFavoris As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
