<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShowBatchResult
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
        Me.tbStationName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbDateScan = New System.Windows.Forms.TextBox
        Me.tbSn = New System.Windows.Forms.TextBox
        Me.tbRam = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.tbFreeSpace = New System.Windows.Forms.TextBox
        Me.tbConstructeur = New System.Windows.Forms.TextBox
        Me.tbOsName = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.tbScanErrorMsg = New System.Windows.Forms.TextBox
        Me.TbRgErrBsod = New tbErrorRedGreen
        Me.TbRgErrNetwork = New tbErrorRedGreen
        Me.TbRDriverFail = New tbErrorRedGreen
        Me.TbRgErrBloc = New tbErrorRedGreen
        Me.tbModele = New System.Windows.Forms.TextBox
        Me.TbRgErrReboot = New tbErrorRedGreen
        Me.tbSocle = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Station"
        '
        'tbStationName
        '
        Me.tbStationName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbStationName.BackColor = System.Drawing.SystemColors.Info
        Me.tbStationName.Location = New System.Drawing.Point(90, 5)
        Me.tbStationName.Name = "tbStationName"
        Me.tbStationName.ReadOnly = True
        Me.tbStationName.Size = New System.Drawing.Size(232, 20)
        Me.tbStationName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "DateScan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "SN"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Ram (Go)"
        '
        'tbDateScan
        '
        Me.tbDateScan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDateScan.BackColor = System.Drawing.SystemColors.Info
        Me.tbDateScan.Location = New System.Drawing.Point(90, 33)
        Me.tbDateScan.Name = "tbDateScan"
        Me.tbDateScan.ReadOnly = True
        Me.tbDateScan.Size = New System.Drawing.Size(232, 20)
        Me.tbDateScan.TabIndex = 6
        '
        'tbSn
        '
        Me.tbSn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSn.BackColor = System.Drawing.SystemColors.Info
        Me.tbSn.Location = New System.Drawing.Point(90, 61)
        Me.tbSn.Name = "tbSn"
        Me.tbSn.ReadOnly = True
        Me.tbSn.Size = New System.Drawing.Size(232, 20)
        Me.tbSn.TabIndex = 8
        '
        'tbRam
        '
        Me.tbRam.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbRam.BackColor = System.Drawing.SystemColors.Info
        Me.tbRam.Location = New System.Drawing.Point(90, 93)
        Me.tbRam.Name = "tbRam"
        Me.tbRam.ReadOnly = True
        Me.tbRam.Size = New System.Drawing.Size(232, 20)
        Me.tbRam.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 226)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Socle"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 190)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Libre c:\ (Go)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 157)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "constructeur"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 123)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(20, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Os"
        '
        'tbFreeSpace
        '
        Me.tbFreeSpace.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbFreeSpace.BackColor = System.Drawing.SystemColors.Info
        Me.tbFreeSpace.Location = New System.Drawing.Point(90, 193)
        Me.tbFreeSpace.Name = "tbFreeSpace"
        Me.tbFreeSpace.ReadOnly = True
        Me.tbFreeSpace.Size = New System.Drawing.Size(232, 20)
        Me.tbFreeSpace.TabIndex = 18
        '
        'tbConstructeur
        '
        Me.tbConstructeur.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbConstructeur.BackColor = System.Drawing.SystemColors.Info
        Me.tbConstructeur.Location = New System.Drawing.Point(90, 160)
        Me.tbConstructeur.Name = "tbConstructeur"
        Me.tbConstructeur.ReadOnly = True
        Me.tbConstructeur.Size = New System.Drawing.Size(232, 20)
        Me.tbConstructeur.TabIndex = 16
        '
        'tbOsName
        '
        Me.tbOsName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbOsName.BackColor = System.Drawing.SystemColors.Info
        Me.tbOsName.Location = New System.Drawing.Point(90, 126)
        Me.tbOsName.Name = "tbOsName"
        Me.tbOsName.ReadOnly = True
        Me.tbOsName.Size = New System.Drawing.Size(232, 20)
        Me.tbOsName.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 477)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Scan. Err Msg."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 440)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Err. BSOD"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(5, 404)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Err. Reboot"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(5, 369)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 13)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Err. Network"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(5, 337)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Err. Driver Fail"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(5, 301)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 13)
        Me.Label17.TabIndex = 21
        Me.Label17.Text = "Err. Bloc HS"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(5, 265)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 13)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "Modele"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.75922!))
        Me.TableLayoutPanel1.Controls.Add(Me.tbScanErrorMsg, 1, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.TbRgErrBsod, 1, 13)
        Me.TableLayoutPanel1.Controls.Add(Me.tbStationName, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TbRgErrNetwork, 1, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.TbRDriverFail, 1, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TbRgErrBloc, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbDateScan, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 0, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 0, 13)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 0, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.tbSn, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 0, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.tbRam, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label17, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.tbOsName, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.tbConstructeur, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.tbFreeSpace, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.tbModele, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.TbRgErrReboot, 1, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.Label18, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.tbSocle, 1, 7)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 15
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(327, 532)
        Me.TableLayoutPanel1.TabIndex = 41
        '
        'tbScanErrorMsg
        '
        Me.tbScanErrorMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbScanErrorMsg.BackColor = System.Drawing.SystemColors.Info
        Me.tbScanErrorMsg.Location = New System.Drawing.Point(90, 480)
        Me.tbScanErrorMsg.Name = "tbScanErrorMsg"
        Me.tbScanErrorMsg.ReadOnly = True
        Me.tbScanErrorMsg.Size = New System.Drawing.Size(232, 20)
        Me.tbScanErrorMsg.TabIndex = 43
        '
        'TbRgErrBsod
        '
        Me.TbRgErrBsod.Location = New System.Drawing.Point(90, 443)
        Me.TbRgErrBsod.Name = "TbRgErrBsod"
        Me.TbRgErrBsod.ReadOnly = True
        Me.TbRgErrBsod.Size = New System.Drawing.Size(68, 20)
        Me.TbRgErrBsod.TabIndex = 42
        '
        'TbRgErrNetwork
        '
        Me.TbRgErrNetwork.Location = New System.Drawing.Point(90, 372)
        Me.TbRgErrNetwork.Name = "TbRgErrNetwork"
        Me.TbRgErrNetwork.ReadOnly = True
        Me.TbRgErrNetwork.Size = New System.Drawing.Size(68, 20)
        Me.TbRgErrNetwork.TabIndex = 36
        '
        'TbRDriverFail
        '
        Me.TbRDriverFail.Location = New System.Drawing.Point(90, 340)
        Me.TbRDriverFail.Name = "TbRDriverFail"
        Me.TbRDriverFail.ReadOnly = True
        Me.TbRDriverFail.Size = New System.Drawing.Size(68, 20)
        Me.TbRDriverFail.TabIndex = 38
        '
        'TbRgErrBloc
        '
        Me.TbRgErrBloc.Location = New System.Drawing.Point(90, 304)
        Me.TbRgErrBloc.Name = "TbRgErrBloc"
        Me.TbRgErrBloc.ReadOnly = True
        Me.TbRgErrBloc.Size = New System.Drawing.Size(68, 20)
        Me.TbRgErrBloc.TabIndex = 37
        '
        'tbModele
        '
        Me.tbModele.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbModele.BackColor = System.Drawing.SystemColors.Info
        Me.tbModele.Location = New System.Drawing.Point(90, 268)
        Me.tbModele.Name = "tbModele"
        Me.tbModele.ReadOnly = True
        Me.tbModele.Size = New System.Drawing.Size(232, 20)
        Me.tbModele.TabIndex = 41
        '
        'TbRgErrReboot
        '
        Me.TbRgErrReboot.Location = New System.Drawing.Point(90, 407)
        Me.TbRgErrReboot.Name = "TbRgErrReboot"
        Me.TbRgErrReboot.ReadOnly = True
        Me.TbRgErrReboot.Size = New System.Drawing.Size(68, 20)
        Me.TbRgErrReboot.TabIndex = 39
        '
        'tbSocle
        '
        Me.tbSocle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSocle.BackColor = System.Drawing.SystemColors.Info
        Me.tbSocle.Location = New System.Drawing.Point(90, 229)
        Me.tbSocle.Name = "tbSocle"
        Me.tbSocle.ReadOnly = True
        Me.tbSocle.Size = New System.Drawing.Size(232, 20)
        Me.tbSocle.TabIndex = 44
        '
        'frmShowBatchResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 532)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmShowBatchResult"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "frmShowBatchResult"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbStationName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbDateScan As System.Windows.Forms.TextBox
    Friend WithEvents tbSn As System.Windows.Forms.TextBox
    Friend WithEvents tbRam As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbFreeSpace As System.Windows.Forms.TextBox
    Friend WithEvents tbConstructeur As System.Windows.Forms.TextBox
    Friend WithEvents tbOsName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TbRgErrNetwork As tbErrorRedGreen
    Friend WithEvents TbRgErrBloc As tbErrorRedGreen
    Friend WithEvents TbRDriverFail As tbErrorRedGreen
    Friend WithEvents TbRgErrReboot As tbErrorRedGreen
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbScanErrorMsg As System.Windows.Forms.TextBox
    Friend WithEvents TbRgErrBsod As tbErrorRedGreen
    Friend WithEvents tbModele As System.Windows.Forms.TextBox
    Friend WithEvents tbSocle As System.Windows.Forms.TextBox
End Class
