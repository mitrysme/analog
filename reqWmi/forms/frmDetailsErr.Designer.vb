<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetailsErr
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetailsErr))
        Me.GroupBoxResults = New System.Windows.Forms.GroupBox
        Me.cbFilterOfficeErr = New System.Windows.Forms.CheckBox
        Me.tbErrOffice = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbFilterApplicationErr = New System.Windows.Forms.CheckBox
        Me.tbErrApplication = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbFilterNtfsErr = New System.Windows.Forms.CheckBox
        Me.cbFilterFtdiskErr = New System.Windows.Forms.CheckBox
        Me.tbNtfsError = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.tbftDiskError = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.cbFilterBsod = New System.Windows.Forms.CheckBox
        Me.cbFilterErrShutdown = New System.Windows.Forms.CheckBox
        Me.cbFilterErrNetwork = New System.Windows.Forms.CheckBox
        Me.cbFilterHddDriverFail = New System.Windows.Forms.CheckBox
        Me.cbFilterHddErrControl = New System.Windows.Forms.CheckBox
        Me.cbFilterHddblockHs = New System.Windows.Forms.CheckBox
        Me.tbHdFailure = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.tbErrControleur = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtbBsod = New System.Windows.Forms.TextBox
        Me.LblErrDisk = New System.Windows.Forms.Label
        Me.lblErrNetwork = New System.Windows.Forms.Label
        Me.lblRebootSauvage = New System.Windows.Forms.Label
        Me.txtbErrReboot = New System.Windows.Forms.TextBox
        Me.txtbErrNetwork = New System.Windows.Forms.TextBox
        Me.txtbErrDisque = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbEvntFirst = New System.Windows.Forms.TextBox
        Me.tbNbEvent = New System.Windows.Forms.TextBox
        Me.lblcbLogFilterByDate = New System.Windows.Forms.Label
        Me.cbLogFilterByDate = New System.Windows.Forms.CheckBox
        Me.StatusStripFrmDetailsErr = New System.Windows.Forms.StatusStrip
        Me.ContextMenuStripLogItem = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EventIdToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WinDbgToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LvDetailsErr1 = New lvDetailsErr
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.GroupBoxResults.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStripLogItem.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxResults
        '
        Me.GroupBoxResults.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxResults.Controls.Add(Me.cbFilterOfficeErr)
        Me.GroupBoxResults.Controls.Add(Me.tbErrOffice)
        Me.GroupBoxResults.Controls.Add(Me.Label3)
        Me.GroupBoxResults.Controls.Add(Me.cbFilterApplicationErr)
        Me.GroupBoxResults.Controls.Add(Me.tbErrApplication)
        Me.GroupBoxResults.Controls.Add(Me.Label1)
        Me.GroupBoxResults.Controls.Add(Me.cbFilterNtfsErr)
        Me.GroupBoxResults.Controls.Add(Me.cbFilterFtdiskErr)
        Me.GroupBoxResults.Controls.Add(Me.tbNtfsError)
        Me.GroupBoxResults.Controls.Add(Me.Label35)
        Me.GroupBoxResults.Controls.Add(Me.tbftDiskError)
        Me.GroupBoxResults.Controls.Add(Me.Label34)
        Me.GroupBoxResults.Controls.Add(Me.cbFilterBsod)
        Me.GroupBoxResults.Controls.Add(Me.cbFilterErrShutdown)
        Me.GroupBoxResults.Controls.Add(Me.cbFilterErrNetwork)
        Me.GroupBoxResults.Controls.Add(Me.cbFilterHddDriverFail)
        Me.GroupBoxResults.Controls.Add(Me.cbFilterHddErrControl)
        Me.GroupBoxResults.Controls.Add(Me.cbFilterHddblockHs)
        Me.GroupBoxResults.Controls.Add(Me.tbHdFailure)
        Me.GroupBoxResults.Controls.Add(Me.Label29)
        Me.GroupBoxResults.Controls.Add(Me.tbErrControleur)
        Me.GroupBoxResults.Controls.Add(Me.Label28)
        Me.GroupBoxResults.Controls.Add(Me.Label2)
        Me.GroupBoxResults.Controls.Add(Me.txtbBsod)
        Me.GroupBoxResults.Controls.Add(Me.LblErrDisk)
        Me.GroupBoxResults.Controls.Add(Me.lblErrNetwork)
        Me.GroupBoxResults.Controls.Add(Me.lblRebootSauvage)
        Me.GroupBoxResults.Controls.Add(Me.txtbErrReboot)
        Me.GroupBoxResults.Controls.Add(Me.txtbErrNetwork)
        Me.GroupBoxResults.Controls.Add(Me.txtbErrDisque)
        Me.GroupBoxResults.Location = New System.Drawing.Point(3, 3)
        Me.GroupBoxResults.Name = "GroupBoxResults"
        Me.GroupBoxResults.Size = New System.Drawing.Size(554, 119)
        Me.GroupBoxResults.TabIndex = 53
        Me.GroupBoxResults.TabStop = False
        Me.GroupBoxResults.Text = "Filtres"
        '
        'cbFilterOfficeErr
        '
        Me.cbFilterOfficeErr.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbFilterOfficeErr.BackgroundImage = Global.My.Resources.Resources.filterGif
        Me.cbFilterOfficeErr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbFilterOfficeErr.Location = New System.Drawing.Point(524, 43)
        Me.cbFilterOfficeErr.Name = "cbFilterOfficeErr"
        Me.cbFilterOfficeErr.Size = New System.Drawing.Size(20, 21)
        Me.cbFilterOfficeErr.TabIndex = 73
        Me.cbFilterOfficeErr.UseVisualStyleBackColor = True
        '
        'tbErrOffice
        '
        Me.tbErrOffice.Location = New System.Drawing.Point(437, 43)
        Me.tbErrOffice.Name = "tbErrOffice"
        Me.tbErrOffice.ReadOnly = True
        Me.tbErrOffice.Size = New System.Drawing.Size(81, 20)
        Me.tbErrOffice.TabIndex = 72
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(351, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "ERR Office"
        '
        'cbFilterApplicationErr
        '
        Me.cbFilterApplicationErr.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbFilterApplicationErr.BackgroundImage = Global.My.Resources.Resources.filterGif
        Me.cbFilterApplicationErr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbFilterApplicationErr.Location = New System.Drawing.Point(524, 19)
        Me.cbFilterApplicationErr.Name = "cbFilterApplicationErr"
        Me.cbFilterApplicationErr.Size = New System.Drawing.Size(20, 21)
        Me.cbFilterApplicationErr.TabIndex = 70
        Me.cbFilterApplicationErr.UseVisualStyleBackColor = True
        '
        'tbErrApplication
        '
        Me.tbErrApplication.Location = New System.Drawing.Point(437, 19)
        Me.tbErrApplication.Name = "tbErrApplication"
        Me.tbErrApplication.ReadOnly = True
        Me.tbErrApplication.Size = New System.Drawing.Size(81, 20)
        Me.tbErrApplication.TabIndex = 69
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(351, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "ERR Application"
        '
        'cbFilterNtfsErr
        '
        Me.cbFilterNtfsErr.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbFilterNtfsErr.BackgroundImage = CType(resources.GetObject("cbFilterNtfsErr.BackgroundImage"), System.Drawing.Image)
        Me.cbFilterNtfsErr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbFilterNtfsErr.Location = New System.Drawing.Point(325, 92)
        Me.cbFilterNtfsErr.Name = "cbFilterNtfsErr"
        Me.cbFilterNtfsErr.Size = New System.Drawing.Size(20, 20)
        Me.cbFilterNtfsErr.TabIndex = 60
        Me.cbFilterNtfsErr.UseVisualStyleBackColor = True
        '
        'cbFilterFtdiskErr
        '
        Me.cbFilterFtdiskErr.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbFilterFtdiskErr.BackgroundImage = CType(resources.GetObject("cbFilterFtdiskErr.BackgroundImage"), System.Drawing.Image)
        Me.cbFilterFtdiskErr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbFilterFtdiskErr.Location = New System.Drawing.Point(152, 92)
        Me.cbFilterFtdiskErr.Name = "cbFilterFtdiskErr"
        Me.cbFilterFtdiskErr.Size = New System.Drawing.Size(20, 20)
        Me.cbFilterFtdiskErr.TabIndex = 67
        Me.cbFilterFtdiskErr.UseVisualStyleBackColor = True
        '
        'tbNtfsError
        '
        Me.tbNtfsError.Location = New System.Drawing.Point(265, 92)
        Me.tbNtfsError.Name = "tbNtfsError"
        Me.tbNtfsError.ReadOnly = True
        Me.tbNtfsError.Size = New System.Drawing.Size(57, 20)
        Me.tbNtfsError.TabIndex = 66
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(179, 95)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(70, 13)
        Me.Label35.TabIndex = 65
        Me.Label35.Text = "HDD ntfs Err."
        '
        'tbftDiskError
        '
        Me.tbftDiskError.Location = New System.Drawing.Point(93, 92)
        Me.tbftDiskError.Name = "tbftDiskError"
        Me.tbftDiskError.ReadOnly = True
        Me.tbftDiskError.Size = New System.Drawing.Size(57, 20)
        Me.tbftDiskError.TabIndex = 64
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(6, 94)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(78, 13)
        Me.Label34.TabIndex = 63
        Me.Label34.Text = "HDD ftdisk Err."
        '
        'cbFilterBsod
        '
        Me.cbFilterBsod.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbFilterBsod.BackgroundImage = CType(resources.GetObject("cbFilterBsod.BackgroundImage"), System.Drawing.Image)
        Me.cbFilterBsod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbFilterBsod.Location = New System.Drawing.Point(325, 68)
        Me.cbFilterBsod.Name = "cbFilterBsod"
        Me.cbFilterBsod.Size = New System.Drawing.Size(20, 20)
        Me.cbFilterBsod.TabIndex = 62
        Me.cbFilterBsod.UseVisualStyleBackColor = True
        '
        'cbFilterErrShutdown
        '
        Me.cbFilterErrShutdown.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbFilterErrShutdown.BackgroundImage = CType(resources.GetObject("cbFilterErrShutdown.BackgroundImage"), System.Drawing.Image)
        Me.cbFilterErrShutdown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbFilterErrShutdown.Location = New System.Drawing.Point(325, 44)
        Me.cbFilterErrShutdown.Name = "cbFilterErrShutdown"
        Me.cbFilterErrShutdown.Size = New System.Drawing.Size(20, 20)
        Me.cbFilterErrShutdown.TabIndex = 61
        Me.cbFilterErrShutdown.UseVisualStyleBackColor = True
        '
        'cbFilterErrNetwork
        '
        Me.cbFilterErrNetwork.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbFilterErrNetwork.BackgroundImage = Global.My.Resources.Resources.filterGif
        Me.cbFilterErrNetwork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbFilterErrNetwork.Location = New System.Drawing.Point(325, 19)
        Me.cbFilterErrNetwork.Name = "cbFilterErrNetwork"
        Me.cbFilterErrNetwork.Size = New System.Drawing.Size(20, 21)
        Me.cbFilterErrNetwork.TabIndex = 60
        Me.cbFilterErrNetwork.UseVisualStyleBackColor = True
        '
        'cbFilterHddDriverFail
        '
        Me.cbFilterHddDriverFail.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbFilterHddDriverFail.BackgroundImage = CType(resources.GetObject("cbFilterHddDriverFail.BackgroundImage"), System.Drawing.Image)
        Me.cbFilterHddDriverFail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbFilterHddDriverFail.Location = New System.Drawing.Point(152, 67)
        Me.cbFilterHddDriverFail.Name = "cbFilterHddDriverFail"
        Me.cbFilterHddDriverFail.Size = New System.Drawing.Size(20, 20)
        Me.cbFilterHddDriverFail.TabIndex = 59
        Me.cbFilterHddDriverFail.UseVisualStyleBackColor = True
        '
        'cbFilterHddErrControl
        '
        Me.cbFilterHddErrControl.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbFilterHddErrControl.BackgroundImage = CType(resources.GetObject("cbFilterHddErrControl.BackgroundImage"), System.Drawing.Image)
        Me.cbFilterHddErrControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbFilterHddErrControl.Location = New System.Drawing.Point(152, 43)
        Me.cbFilterHddErrControl.Name = "cbFilterHddErrControl"
        Me.cbFilterHddErrControl.Size = New System.Drawing.Size(20, 20)
        Me.cbFilterHddErrControl.TabIndex = 58
        Me.cbFilterHddErrControl.UseVisualStyleBackColor = True
        '
        'cbFilterHddblockHs
        '
        Me.cbFilterHddblockHs.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbFilterHddblockHs.BackgroundImage = Global.My.Resources.Resources.filterGif
        Me.cbFilterHddblockHs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbFilterHddblockHs.Location = New System.Drawing.Point(152, 18)
        Me.cbFilterHddblockHs.Name = "cbFilterHddblockHs"
        Me.cbFilterHddblockHs.Size = New System.Drawing.Size(20, 21)
        Me.cbFilterHddblockHs.TabIndex = 57
        Me.cbFilterHddblockHs.UseVisualStyleBackColor = True
        '
        'tbHdFailure
        '
        Me.tbHdFailure.Location = New System.Drawing.Point(93, 67)
        Me.tbHdFailure.Name = "tbHdFailure"
        Me.tbHdFailure.ReadOnly = True
        Me.tbHdFailure.Size = New System.Drawing.Size(57, 20)
        Me.tbHdFailure.TabIndex = 35
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(6, 69)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(76, 13)
        Me.Label29.TabIndex = 34
        Me.Label29.Text = "HDD driver fail"
        '
        'tbErrControleur
        '
        Me.tbErrControleur.Location = New System.Drawing.Point(93, 43)
        Me.tbErrControleur.Name = "tbErrControleur"
        Me.tbErrControleur.ReadOnly = True
        Me.tbErrControleur.Size = New System.Drawing.Size(57, 20)
        Me.tbErrControleur.TabIndex = 33
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 46)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(78, 13)
        Me.Label28.TabIndex = 32
        Me.Label28.Text = "HDD Err Contr."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(179, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "BSOD"
        '
        'txtbBsod
        '
        Me.txtbBsod.Location = New System.Drawing.Point(266, 67)
        Me.txtbBsod.Name = "txtbBsod"
        Me.txtbBsod.ReadOnly = True
        Me.txtbBsod.Size = New System.Drawing.Size(57, 20)
        Me.txtbBsod.TabIndex = 29
        '
        'LblErrDisk
        '
        Me.LblErrDisk.AutoSize = True
        Me.LblErrDisk.Location = New System.Drawing.Point(6, 21)
        Me.LblErrDisk.Name = "LblErrDisk"
        Me.LblErrDisk.Size = New System.Drawing.Size(73, 13)
        Me.LblErrDisk.TabIndex = 19
        Me.LblErrDisk.Text = "HDD Bloc HS"
        '
        'lblErrNetwork
        '
        Me.lblErrNetwork.AutoSize = True
        Me.lblErrNetwork.Location = New System.Drawing.Point(178, 21)
        Me.lblErrNetwork.Name = "lblErrNetwork"
        Me.lblErrNetwork.Size = New System.Drawing.Size(60, 13)
        Me.lblErrNetwork.TabIndex = 20
        Me.lblErrNetwork.Text = "ErrNetwork"
        '
        'lblRebootSauvage
        '
        Me.lblRebootSauvage.AutoSize = True
        Me.lblRebootSauvage.Location = New System.Drawing.Point(178, 45)
        Me.lblRebootSauvage.Name = "lblRebootSauvage"
        Me.lblRebootSauvage.Size = New System.Drawing.Size(88, 13)
        Me.lblRebootSauvage.TabIndex = 21
        Me.lblRebootSauvage.Text = "Reboot Sauvage"
        '
        'txtbErrReboot
        '
        Me.txtbErrReboot.Location = New System.Drawing.Point(266, 43)
        Me.txtbErrReboot.Name = "txtbErrReboot"
        Me.txtbErrReboot.ReadOnly = True
        Me.txtbErrReboot.Size = New System.Drawing.Size(57, 20)
        Me.txtbErrReboot.TabIndex = 17
        '
        'txtbErrNetwork
        '
        Me.txtbErrNetwork.Location = New System.Drawing.Point(266, 19)
        Me.txtbErrNetwork.Name = "txtbErrNetwork"
        Me.txtbErrNetwork.ReadOnly = True
        Me.txtbErrNetwork.Size = New System.Drawing.Size(57, 20)
        Me.txtbErrNetwork.TabIndex = 16
        '
        'txtbErrDisque
        '
        Me.txtbErrDisque.Location = New System.Drawing.Point(93, 19)
        Me.txtbErrDisque.Name = "txtbErrDisque"
        Me.txtbErrDisque.ReadOnly = True
        Me.txtbErrDisque.Size = New System.Drawing.Size(57, 20)
        Me.txtbErrDisque.TabIndex = 15
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.tbEvntFirst)
        Me.Panel1.Controls.Add(Me.tbNbEvent)
        Me.Panel1.Controls.Add(Me.lblcbLogFilterByDate)
        Me.Panel1.Controls.Add(Me.cbLogFilterByDate)
        Me.Panel1.Controls.Add(Me.GroupBoxResults)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(830, 130)
        Me.Panel1.TabIndex = 54
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(561, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Evt plus ancien :"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(561, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Nb. Evts :"
        '
        'tbEvntFirst
        '
        Me.tbEvntFirst.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbEvntFirst.BackColor = System.Drawing.SystemColors.Info
        Me.tbEvntFirst.Location = New System.Drawing.Point(650, 65)
        Me.tbEvntFirst.Name = "tbEvntFirst"
        Me.tbEvntFirst.ReadOnly = True
        Me.tbEvntFirst.Size = New System.Drawing.Size(172, 20)
        Me.tbEvntFirst.TabIndex = 75
        '
        'tbNbEvent
        '
        Me.tbNbEvent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbNbEvent.BackColor = System.Drawing.SystemColors.Info
        Me.tbNbEvent.Location = New System.Drawing.Point(650, 41)
        Me.tbNbEvent.Name = "tbNbEvent"
        Me.tbNbEvent.ReadOnly = True
        Me.tbNbEvent.Size = New System.Drawing.Size(172, 20)
        Me.tbNbEvent.TabIndex = 73
        '
        'lblcbLogFilterByDate
        '
        Me.lblcbLogFilterByDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcbLogFilterByDate.AutoSize = True
        Me.lblcbLogFilterByDate.Location = New System.Drawing.Point(643, 10)
        Me.lblcbLogFilterByDate.Name = "lblcbLogFilterByDate"
        Me.lblcbLogFilterByDate.Size = New System.Drawing.Size(141, 13)
        Me.lblcbLogFilterByDate.TabIndex = 72
        Me.lblcbLogFilterByDate.Text = "filtrer évts antérieurs 15 jours"
        '
        'cbLogFilterByDate
        '
        Me.cbLogFilterByDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbLogFilterByDate.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbLogFilterByDate.BackgroundImage = Global.My.Resources.Resources.dateIcon
        Me.cbLogFilterByDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbLogFilterByDate.Location = New System.Drawing.Point(792, 3)
        Me.cbLogFilterByDate.Name = "cbLogFilterByDate"
        Me.cbLogFilterByDate.Size = New System.Drawing.Size(32, 26)
        Me.cbLogFilterByDate.TabIndex = 71
        Me.cbLogFilterByDate.UseVisualStyleBackColor = True
        '
        'StatusStripFrmDetailsErr
        '
        Me.StatusStripFrmDetailsErr.Location = New System.Drawing.Point(0, 564)
        Me.StatusStripFrmDetailsErr.Name = "StatusStripFrmDetailsErr"
        Me.StatusStripFrmDetailsErr.Size = New System.Drawing.Size(830, 22)
        Me.StatusStripFrmDetailsErr.TabIndex = 55
        Me.StatusStripFrmDetailsErr.Text = "StatusStrip1"
        '
        'ContextMenuStripLogItem
        '
        Me.ContextMenuStripLogItem.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EventIdToolStripMenuItem, Me.WinDbgToolStripMenuItem})
        Me.ContextMenuStripLogItem.Name = "ContextMenuStripLogItem"
        Me.ContextMenuStripLogItem.Size = New System.Drawing.Size(124, 48)
        '
        'EventIdToolStripMenuItem
        '
        Me.EventIdToolStripMenuItem.Image = Global.My.Resources.Resources.eventId
        Me.EventIdToolStripMenuItem.Name = "EventIdToolStripMenuItem"
        Me.EventIdToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.EventIdToolStripMenuItem.Text = "EventId"
        '
        'WinDbgToolStripMenuItem
        '
        Me.WinDbgToolStripMenuItem.Image = Global.My.Resources.Resources.wdbg
        Me.WinDbgToolStripMenuItem.Name = "WinDbgToolStripMenuItem"
        Me.WinDbgToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.WinDbgToolStripMenuItem.Text = "WinDbg"
        '
        'LvDetailsErr1
        '
        Me.LvDetailsErr1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvDetailsErr1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader7, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.LvDetailsErr1.FullRowSelect = True
        Me.LvDetailsErr1.Location = New System.Drawing.Point(0, 136)
        Me.LvDetailsErr1.Name = "LvDetailsErr1"
        Me.LvDetailsErr1.Size = New System.Drawing.Size(830, 425)
        Me.LvDetailsErr1.TabIndex = 0
        Me.LvDetailsErr1.UseCompatibleStateImageBehavior = False
        Me.LvDetailsErr1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "> Date"
        Me.ColumnHeader1.Width = 86
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Heure"
        Me.ColumnHeader7.Width = 87
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Message"
        Me.ColumnHeader2.Width = 428
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Type"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Utilisateur"
        Me.ColumnHeader4.Width = 80
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "EventId"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "source"
        '
        'frmDetailsErr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 586)
        Me.Controls.Add(Me.StatusStripFrmDetailsErr)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LvDetailsErr1)
        Me.MinimumSize = New System.Drawing.Size(838, 480)
        Me.Name = "frmDetailsErr"
        Me.GroupBoxResults.ResumeLayout(False)
        Me.GroupBoxResults.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenuStripLogItem.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LvDetailsErr1 As lvDetailsErr
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBoxResults As System.Windows.Forms.GroupBox
    Friend WithEvents tbHdFailure As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents tbErrControleur As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtbBsod As System.Windows.Forms.TextBox
    Friend WithEvents LblErrDisk As System.Windows.Forms.Label
    Friend WithEvents lblErrNetwork As System.Windows.Forms.Label
    Friend WithEvents lblRebootSauvage As System.Windows.Forms.Label
    Friend WithEvents txtbErrReboot As System.Windows.Forms.TextBox
    Friend WithEvents txtbErrNetwork As System.Windows.Forms.TextBox
    Friend WithEvents txtbErrDisque As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStripFrmDetailsErr As System.Windows.Forms.StatusStrip
    Friend WithEvents cbFilterHddblockHs As System.Windows.Forms.CheckBox
    Friend WithEvents cbFilterHddErrControl As System.Windows.Forms.CheckBox
    Friend WithEvents cbFilterHddDriverFail As System.Windows.Forms.CheckBox
    Friend WithEvents cbFilterBsod As System.Windows.Forms.CheckBox
    Friend WithEvents cbFilterErrShutdown As System.Windows.Forms.CheckBox
    Friend WithEvents cbFilterErrNetwork As System.Windows.Forms.CheckBox
    Friend WithEvents tbftDiskError As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cbFilterNtfsErr As System.Windows.Forms.CheckBox
    Friend WithEvents cbFilterFtdiskErr As System.Windows.Forms.CheckBox
    Friend WithEvents tbNtfsError As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStripLogItem As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EventIdToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WinDbgToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbFilterApplicationErr As System.Windows.Forms.CheckBox
    Friend WithEvents tbErrApplication As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbLogFilterByDate As System.Windows.Forms.CheckBox
    Friend WithEvents lblcbLogFilterByDate As System.Windows.Forms.Label
    Friend WithEvents cbFilterOfficeErr As System.Windows.Forms.CheckBox
    Friend WithEvents tbErrOffice As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbEvntFirst As System.Windows.Forms.TextBox
    Friend WithEvents tbNbEvent As System.Windows.Forms.TextBox
End Class
