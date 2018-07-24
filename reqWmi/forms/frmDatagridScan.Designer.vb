<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatagridScan
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.progBarrQuery = New System.Windows.Forms.ProgressBar()
        Me.gbxOptions = New System.Windows.Forms.GroupBox()
        Me.cbFilterDateScan = New System.Windows.Forms.CheckBox()
        Me.lblOsName = New System.Windows.Forms.Label()
        Me.cmbFilterOsName = New System.Windows.Forms.ComboBox()
        Me.lblSite = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.cmbFilterModel = New System.Windows.Forms.ComboBox()
        Me.cbProgramExactString = New System.Windows.Forms.CheckBox()
        Me.cbDeletedStations = New System.Windows.Forms.CheckBox()
        Me.cbSearchForProgram = New System.Windows.Forms.CheckBox()
        Me.cbShowScanKO = New System.Windows.Forms.CheckBox()
        Me.cbSite = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbScanKO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbBSOD = New System.Windows.Forms.TextBox()
        Me.tbBlocHS = New System.Windows.Forms.TextBox()
        Me.tbBindingSourceCount = New System.Windows.Forms.TextBox()
        Me.lblNbreStation = New System.Windows.Forms.Label()
        Me.tbNbStations = New System.Windows.Forms.TextBox()
        Me.tbSearch = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridViewScan = New System.Windows.Forms.DataGridView()
        Me.scDatagridScan = New System.Windows.Forms.SplitContainer()
        Me.CollapsiblePanelBar1 = New Salamander.Windows.Forms.CollapsiblePanelBar()
        Me.CollapsiblePanelProgrammes = New Salamander.Windows.Forms.CollapsiblePanel()
        Me.CollapsiblePanelDisplay = New Salamander.Windows.Forms.CollapsiblePanel()
        Me.tbMonitorDisplayName = New System.Windows.Forms.TextBox()
        Me.PanelDetailDisplay = New System.Windows.Forms.Panel()
        Me.lbDisplayCount = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tbMonitorName = New System.Windows.Forms.TextBox()
        Me.tbMonitorSerialNumber = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.CollapsiblePanelOs = New Salamander.Windows.Forms.CollapsiblePanel()
        Me.tbUpTime = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbSocle = New System.Windows.Forms.TextBox()
        Me.tbOperatingSystem = New System.Windows.Forms.TextBox()
        Me.collapsiblePanelOrdinateur = New Salamander.Windows.Forms.CollapsiblePanel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbModele = New System.Windows.Forms.TextBox()
        Me.tbSerialNumber = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbHostname = New System.Windows.Forms.TextBox()
        Me.tbMemoireTotale = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbConstructeur = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LvProgramsBatch = New lvPrograms()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btDisplayPrev = New System.Windows.Forms.Button()
        Me.btDisplayNext = New System.Windows.Forms.Button()
        Me.btDisplayDetails = New System.Windows.Forms.Button()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.btCollapsePanelInfos = New System.Windows.Forms.Button()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.gbxOptions.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridViewScan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scDatagridScan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scDatagridScan.Panel1.SuspendLayout()
        Me.scDatagridScan.Panel2.SuspendLayout()
        Me.scDatagridScan.SuspendLayout()
        CType(Me.CollapsiblePanelBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CollapsiblePanelBar1.SuspendLayout()
        Me.CollapsiblePanelProgrammes.SuspendLayout()
        Me.CollapsiblePanelDisplay.SuspendLayout()
        Me.PanelDetailDisplay.SuspendLayout()
        Me.CollapsiblePanelOs.SuspendLayout()
        Me.collapsiblePanelOrdinateur.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.progBarrQuery)
        Me.Panel1.Controls.Add(Me.gbxOptions)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.tbScanKO)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.tbBSOD)
        Me.Panel1.Controls.Add(Me.tbBlocHS)
        Me.Panel1.Controls.Add(Me.tbBindingSourceCount)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblNbreStation)
        Me.Panel1.Controls.Add(Me.tbNbStations)
        Me.Panel1.Controls.Add(Me.tbSearch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1184, 89)
        Me.Panel1.TabIndex = 0
        '
        'progBarrQuery
        '
        Me.progBarrQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progBarrQuery.Location = New System.Drawing.Point(1129, 7)
        Me.progBarrQuery.Name = "progBarrQuery"
        Me.progBarrQuery.Size = New System.Drawing.Size(41, 21)
        Me.progBarrQuery.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.progBarrQuery.TabIndex = 27
        '
        'gbxOptions
        '
        Me.gbxOptions.Controls.Add(Me.cbFilterDateScan)
        Me.gbxOptions.Controls.Add(Me.lblOsName)
        Me.gbxOptions.Controls.Add(Me.cmbFilterOsName)
        Me.gbxOptions.Controls.Add(Me.lblSite)
        Me.gbxOptions.Controls.Add(Me.lblModel)
        Me.gbxOptions.Controls.Add(Me.cmbFilterModel)
        Me.gbxOptions.Controls.Add(Me.cbProgramExactString)
        Me.gbxOptions.Controls.Add(Me.cbDeletedStations)
        Me.gbxOptions.Controls.Add(Me.cbSearchForProgram)
        Me.gbxOptions.Controls.Add(Me.cbShowScanKO)
        Me.gbxOptions.Controls.Add(Me.cbSite)
        Me.gbxOptions.Location = New System.Drawing.Point(201, -1)
        Me.gbxOptions.Name = "gbxOptions"
        Me.gbxOptions.Size = New System.Drawing.Size(560, 82)
        Me.gbxOptions.TabIndex = 26
        Me.gbxOptions.TabStop = False
        Me.gbxOptions.Text = "Options"
        '
        'cbFilterDateScan
        '
        Me.cbFilterDateScan.AutoSize = True
        Me.cbFilterDateScan.Location = New System.Drawing.Point(171, 11)
        Me.cbFilterDateScan.Name = "cbFilterDateScan"
        Me.cbFilterDateScan.Size = New System.Drawing.Size(111, 17)
        Me.cbFilterDateScan.TabIndex = 33
        Me.cbFilterDateScan.Text = "dateScan > 2mois"
        Me.cbFilterDateScan.UseVisualStyleBackColor = True
        '
        'lblOsName
        '
        Me.lblOsName.AutoSize = True
        Me.lblOsName.Location = New System.Drawing.Point(285, 58)
        Me.lblOsName.Name = "lblOsName"
        Me.lblOsName.Size = New System.Drawing.Size(22, 13)
        Me.lblOsName.TabIndex = 32
        Me.lblOsName.Text = "OS"
        '
        'cmbFilterOsName
        '
        Me.cmbFilterOsName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterOsName.FormattingEnabled = True
        Me.cmbFilterOsName.Location = New System.Drawing.Point(330, 53)
        Me.cmbFilterOsName.Name = "cmbFilterOsName"
        Me.cmbFilterOsName.Size = New System.Drawing.Size(215, 21)
        Me.cmbFilterOsName.TabIndex = 31
        '
        'lblSite
        '
        Me.lblSite.AutoSize = True
        Me.lblSite.Location = New System.Drawing.Point(284, 36)
        Me.lblSite.Name = "lblSite"
        Me.lblSite.Size = New System.Drawing.Size(25, 13)
        Me.lblSite.TabIndex = 30
        Me.lblSite.Text = "Site"
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.Location = New System.Drawing.Point(284, 13)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(42, 13)
        Me.lblModel.TabIndex = 29
        Me.lblModel.Text = "Modele"
        '
        'cmbFilterModel
        '
        Me.cmbFilterModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbFilterModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFilterModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterModel.FormattingEnabled = True
        Me.cmbFilterModel.Location = New System.Drawing.Point(330, 9)
        Me.cmbFilterModel.Name = "cmbFilterModel"
        Me.cmbFilterModel.Size = New System.Drawing.Size(215, 21)
        Me.cmbFilterModel.TabIndex = 28
        '
        'cbProgramExactString
        '
        Me.cbProgramExactString.AutoSize = True
        Me.cbProgramExactString.Location = New System.Drawing.Point(6, 61)
        Me.cbProgramExactString.Name = "cbProgramExactString"
        Me.cbProgramExactString.Size = New System.Drawing.Size(95, 17)
        Me.cbProgramExactString.TabIndex = 26
        Me.cbProgramExactString.Text = "Chaine Exacte"
        Me.cbProgramExactString.UseVisualStyleBackColor = True
        '
        'cbDeletedStations
        '
        Me.cbDeletedStations.AutoSize = True
        Me.cbDeletedStations.Location = New System.Drawing.Point(6, 13)
        Me.cbDeletedStations.Name = "cbDeletedStations"
        Me.cbDeletedStations.Size = New System.Drawing.Size(122, 17)
        Me.cbDeletedStations.TabIndex = 23
        Me.cbDeletedStations.Text = "Stations Supprimées"
        Me.cbDeletedStations.UseVisualStyleBackColor = True
        '
        'cbSearchForProgram
        '
        Me.cbSearchForProgram.AutoSize = True
        Me.cbSearchForProgram.Location = New System.Drawing.Point(6, 45)
        Me.cbSearchForProgram.Name = "cbSearchForProgram"
        Me.cbSearchForProgram.Size = New System.Drawing.Size(155, 17)
        Me.cbSearchForProgram.TabIndex = 25
        Me.cbSearchForProgram.Text = "Chercher dans programmes"
        Me.cbSearchForProgram.UseVisualStyleBackColor = True
        '
        'cbShowScanKO
        '
        Me.cbShowScanKO.AutoSize = True
        Me.cbShowScanKO.Location = New System.Drawing.Point(6, 29)
        Me.cbShowScanKO.Name = "cbShowScanKO"
        Me.cbShowScanKO.Size = New System.Drawing.Size(72, 17)
        Me.cbShowScanKO.TabIndex = 24
        Me.cbShowScanKO.Text = "Scan KO."
        Me.cbShowScanKO.UseVisualStyleBackColor = True
        '
        'cbSite
        '
        Me.cbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSite.FormattingEnabled = True
        Me.cbSite.Location = New System.Drawing.Point(330, 31)
        Me.cbSite.Name = "cbSite"
        Me.cbSite.Size = New System.Drawing.Size(215, 21)
        Me.cbSite.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Scan KO"
        '
        'tbScanKO
        '
        Me.tbScanKO.BackColor = System.Drawing.SystemColors.Info
        Me.tbScanKO.Location = New System.Drawing.Point(112, 52)
        Me.tbScanKO.Name = "tbScanKO"
        Me.tbScanKO.ReadOnly = True
        Me.tbScanKO.Size = New System.Drawing.Size(37, 20)
        Me.tbScanKO.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "BlocHS / BSOD"
        '
        'tbBSOD
        '
        Me.tbBSOD.BackColor = System.Drawing.SystemColors.Info
        Me.tbBSOD.Location = New System.Drawing.Point(154, 31)
        Me.tbBSOD.Name = "tbBSOD"
        Me.tbBSOD.ReadOnly = True
        Me.tbBSOD.Size = New System.Drawing.Size(36, 20)
        Me.tbBSOD.TabIndex = 19
        '
        'tbBlocHS
        '
        Me.tbBlocHS.BackColor = System.Drawing.SystemColors.Info
        Me.tbBlocHS.Location = New System.Drawing.Point(112, 30)
        Me.tbBlocHS.Name = "tbBlocHS"
        Me.tbBlocHS.ReadOnly = True
        Me.tbBlocHS.Size = New System.Drawing.Size(37, 20)
        Me.tbBlocHS.TabIndex = 18
        '
        'tbBindingSourceCount
        '
        Me.tbBindingSourceCount.BackColor = System.Drawing.SystemColors.Info
        Me.tbBindingSourceCount.Location = New System.Drawing.Point(154, 8)
        Me.tbBindingSourceCount.Name = "tbBindingSourceCount"
        Me.tbBindingSourceCount.ReadOnly = True
        Me.tbBindingSourceCount.Size = New System.Drawing.Size(37, 20)
        Me.tbBindingSourceCount.TabIndex = 17
        '
        'lblNbreStation
        '
        Me.lblNbreStation.AutoSize = True
        Me.lblNbreStation.Location = New System.Drawing.Point(13, 11)
        Me.lblNbreStation.Name = "lblNbreStation"
        Me.lblNbreStation.Size = New System.Drawing.Size(83, 13)
        Me.lblNbreStation.TabIndex = 3
        Me.lblNbreStation.Text = "Nombre stations"
        '
        'tbNbStations
        '
        Me.tbNbStations.BackColor = System.Drawing.SystemColors.Info
        Me.tbNbStations.Location = New System.Drawing.Point(112, 8)
        Me.tbNbStations.Name = "tbNbStations"
        Me.tbNbStations.ReadOnly = True
        Me.tbNbStations.Size = New System.Drawing.Size(37, 20)
        Me.tbNbStations.TabIndex = 2
        '
        'tbSearch
        '
        Me.tbSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSearch.Location = New System.Drawing.Point(989, 62)
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(190, 20)
        Me.tbSearch.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.btnExportExcel)
        Me.Panel2.Controls.Add(Me.btCollapsePanelInfos)
        Me.Panel2.Controls.Add(Me.btnReload)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1146, 89)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(38, 825)
        Me.Panel2.TabIndex = 1
        '
        'DataGridViewScan
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewScan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewScan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewScan.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewScan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewScan.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewScan.Name = "DataGridViewScan"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewScan.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewScan.Size = New System.Drawing.Size(871, 825)
        Me.DataGridViewScan.TabIndex = 2
        '
        'scDatagridScan
        '
        Me.scDatagridScan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scDatagridScan.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.scDatagridScan.IsSplitterFixed = True
        Me.scDatagridScan.Location = New System.Drawing.Point(0, 89)
        Me.scDatagridScan.Name = "scDatagridScan"
        '
        'scDatagridScan.Panel1
        '
        Me.scDatagridScan.Panel1.Controls.Add(Me.DataGridViewScan)
        '
        'scDatagridScan.Panel2
        '
        Me.scDatagridScan.Panel2.Controls.Add(Me.CollapsiblePanelBar1)
        Me.scDatagridScan.Size = New System.Drawing.Size(1146, 825)
        Me.scDatagridScan.SplitterDistance = 871
        Me.scDatagridScan.TabIndex = 3
        '
        'CollapsiblePanelBar1
        '
        Me.CollapsiblePanelBar1.AutoScroll = True
        Me.CollapsiblePanelBar1.AutoSize = True
        Me.CollapsiblePanelBar1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.CollapsiblePanelBar1.Border = 8
        Me.CollapsiblePanelBar1.Controls.Add(Me.CollapsiblePanelProgrammes)
        Me.CollapsiblePanelBar1.Controls.Add(Me.CollapsiblePanelDisplay)
        Me.CollapsiblePanelBar1.Controls.Add(Me.CollapsiblePanelOs)
        Me.CollapsiblePanelBar1.Controls.Add(Me.collapsiblePanelOrdinateur)
        Me.CollapsiblePanelBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CollapsiblePanelBar1.Location = New System.Drawing.Point(0, 0)
        Me.CollapsiblePanelBar1.Name = "CollapsiblePanelBar1"
        Me.CollapsiblePanelBar1.Size = New System.Drawing.Size(271, 825)
        Me.CollapsiblePanelBar1.Spacing = 8
        Me.CollapsiblePanelBar1.TabIndex = 31
        '
        'CollapsiblePanelProgrammes
        '
        Me.CollapsiblePanelProgrammes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CollapsiblePanelProgrammes.BackColor = System.Drawing.Color.Lavender
        Me.CollapsiblePanelProgrammes.Controls.Add(Me.LvProgramsBatch)
        Me.CollapsiblePanelProgrammes.EndColour = System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.CollapsiblePanelProgrammes.Image = Nothing
        Me.CollapsiblePanelProgrammes.Location = New System.Drawing.Point(8, 426)
        Me.CollapsiblePanelProgrammes.Name = "CollapsiblePanelProgrammes"
        Me.CollapsiblePanelProgrammes.PanelState = Salamander.Windows.Forms.PanelState.Expanded
        Me.CollapsiblePanelProgrammes.Size = New System.Drawing.Size(255, 325)
        Me.CollapsiblePanelProgrammes.StartColour = System.Drawing.Color.White
        Me.CollapsiblePanelProgrammes.TabIndex = 7
        Me.CollapsiblePanelProgrammes.TitleFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CollapsiblePanelProgrammes.TitleFontColour = System.Drawing.Color.Navy
        Me.CollapsiblePanelProgrammes.TitleText = "Programmes"
        '
        'CollapsiblePanelDisplay
        '
        Me.CollapsiblePanelDisplay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CollapsiblePanelDisplay.BackColor = System.Drawing.Color.Lavender
        Me.CollapsiblePanelDisplay.Controls.Add(Me.tbMonitorDisplayName)
        Me.CollapsiblePanelDisplay.Controls.Add(Me.PanelDetailDisplay)
        Me.CollapsiblePanelDisplay.Controls.Add(Me.Label25)
        Me.CollapsiblePanelDisplay.Controls.Add(Me.Label27)
        Me.CollapsiblePanelDisplay.Controls.Add(Me.tbMonitorName)
        Me.CollapsiblePanelDisplay.Controls.Add(Me.tbMonitorSerialNumber)
        Me.CollapsiblePanelDisplay.Controls.Add(Me.Label26)
        Me.CollapsiblePanelDisplay.EndColour = System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.CollapsiblePanelDisplay.Image = Nothing
        Me.CollapsiblePanelDisplay.Location = New System.Drawing.Point(8, 292)
        Me.CollapsiblePanelDisplay.Name = "CollapsiblePanelDisplay"
        Me.CollapsiblePanelDisplay.PanelState = Salamander.Windows.Forms.PanelState.Expanded
        Me.CollapsiblePanelDisplay.Size = New System.Drawing.Size(255, 126)
        Me.CollapsiblePanelDisplay.StartColour = System.Drawing.Color.White
        Me.CollapsiblePanelDisplay.TabIndex = 4
        Me.CollapsiblePanelDisplay.TitleFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CollapsiblePanelDisplay.TitleFontColour = System.Drawing.Color.Navy
        Me.CollapsiblePanelDisplay.TitleText = "Ecrans"
        '
        'tbMonitorDisplayName
        '
        Me.tbMonitorDisplayName.BackColor = System.Drawing.SystemColors.Info
        Me.tbMonitorDisplayName.Location = New System.Drawing.Point(100, 77)
        Me.tbMonitorDisplayName.Name = "tbMonitorDisplayName"
        Me.tbMonitorDisplayName.ReadOnly = True
        Me.tbMonitorDisplayName.Size = New System.Drawing.Size(148, 20)
        Me.tbMonitorDisplayName.TabIndex = 5
        '
        'PanelDetailDisplay
        '
        Me.PanelDetailDisplay.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelDetailDisplay.Controls.Add(Me.lbDisplayCount)
        Me.PanelDetailDisplay.Controls.Add(Me.btDisplayPrev)
        Me.PanelDetailDisplay.Controls.Add(Me.btDisplayNext)
        Me.PanelDetailDisplay.Controls.Add(Me.btDisplayDetails)
        Me.PanelDetailDisplay.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelDetailDisplay.Location = New System.Drawing.Point(0, 108)
        Me.PanelDetailDisplay.Name = "PanelDetailDisplay"
        Me.PanelDetailDisplay.Size = New System.Drawing.Size(255, 18)
        Me.PanelDetailDisplay.TabIndex = 6
        '
        'lbDisplayCount
        '
        Me.lbDisplayCount.AutoSize = True
        Me.lbDisplayCount.Location = New System.Drawing.Point(25, 3)
        Me.lbDisplayCount.Name = "lbDisplayCount"
        Me.lbDisplayCount.Size = New System.Drawing.Size(0, 13)
        Me.lbDisplayCount.TabIndex = 17
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(3, 29)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 13)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "MonitorName"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(4, 80)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(69, 13)
        Me.Label27.TabIndex = 4
        Me.Label27.Text = "DisplayName"
        '
        'tbMonitorName
        '
        Me.tbMonitorName.BackColor = System.Drawing.SystemColors.Info
        Me.tbMonitorName.Location = New System.Drawing.Point(100, 25)
        Me.tbMonitorName.Name = "tbMonitorName"
        Me.tbMonitorName.ReadOnly = True
        Me.tbMonitorName.Size = New System.Drawing.Size(148, 20)
        Me.tbMonitorName.TabIndex = 1
        '
        'tbMonitorSerialNumber
        '
        Me.tbMonitorSerialNumber.BackColor = System.Drawing.SystemColors.Info
        Me.tbMonitorSerialNumber.Location = New System.Drawing.Point(100, 51)
        Me.tbMonitorSerialNumber.Name = "tbMonitorSerialNumber"
        Me.tbMonitorSerialNumber.ReadOnly = True
        Me.tbMonitorSerialNumber.Size = New System.Drawing.Size(148, 20)
        Me.tbMonitorSerialNumber.TabIndex = 3
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(3, 54)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(70, 13)
        Me.Label26.TabIndex = 2
        Me.Label26.Text = "SerialNumber"
        '
        'CollapsiblePanelOs
        '
        Me.CollapsiblePanelOs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CollapsiblePanelOs.BackColor = System.Drawing.Color.Lavender
        Me.CollapsiblePanelOs.Controls.Add(Me.tbUpTime)
        Me.CollapsiblePanelOs.Controls.Add(Me.Label24)
        Me.CollapsiblePanelOs.Controls.Add(Me.Label14)
        Me.CollapsiblePanelOs.Controls.Add(Me.Label16)
        Me.CollapsiblePanelOs.Controls.Add(Me.tbSocle)
        Me.CollapsiblePanelOs.Controls.Add(Me.tbOperatingSystem)
        Me.CollapsiblePanelOs.EndColour = System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.CollapsiblePanelOs.Image = Nothing
        Me.CollapsiblePanelOs.Location = New System.Drawing.Point(8, 171)
        Me.CollapsiblePanelOs.Name = "CollapsiblePanelOs"
        Me.CollapsiblePanelOs.PanelState = Salamander.Windows.Forms.PanelState.Expanded
        Me.CollapsiblePanelOs.Size = New System.Drawing.Size(255, 113)
        Me.CollapsiblePanelOs.StartColour = System.Drawing.Color.White
        Me.CollapsiblePanelOs.TabIndex = 2
        Me.CollapsiblePanelOs.TitleFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CollapsiblePanelOs.TitleFontColour = System.Drawing.Color.Navy
        Me.CollapsiblePanelOs.TitleText = "Systeme Exploitation"
        '
        'tbUpTime
        '
        Me.tbUpTime.BackColor = System.Drawing.SystemColors.Info
        Me.tbUpTime.Location = New System.Drawing.Point(62, 80)
        Me.tbUpTime.Name = "tbUpTime"
        Me.tbUpTime.ReadOnly = True
        Me.tbUpTime.Size = New System.Drawing.Size(184, 20)
        Me.tbUpTime.TabIndex = 9
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(5, 83)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 13)
        Me.Label24.TabIndex = 8
        Me.Label24.Text = "Uptime"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(5, 30)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(22, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "OS"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(5, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 13)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "Socle"
        '
        'tbSocle
        '
        Me.tbSocle.BackColor = System.Drawing.SystemColors.Info
        Me.tbSocle.Location = New System.Drawing.Point(62, 55)
        Me.tbSocle.Name = "tbSocle"
        Me.tbSocle.ReadOnly = True
        Me.tbSocle.Size = New System.Drawing.Size(184, 20)
        Me.tbSocle.TabIndex = 6
        '
        'tbOperatingSystem
        '
        Me.tbOperatingSystem.BackColor = System.Drawing.SystemColors.Info
        Me.tbOperatingSystem.Location = New System.Drawing.Point(62, 27)
        Me.tbOperatingSystem.Name = "tbOperatingSystem"
        Me.tbOperatingSystem.ReadOnly = True
        Me.tbOperatingSystem.Size = New System.Drawing.Size(184, 20)
        Me.tbOperatingSystem.TabIndex = 0
        '
        'collapsiblePanelOrdinateur
        '
        Me.collapsiblePanelOrdinateur.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.collapsiblePanelOrdinateur.BackColor = System.Drawing.Color.Lavender
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.Label8)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.Label4)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.tbModele)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.tbSerialNumber)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.Label13)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.tbHostname)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.tbMemoireTotale)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.Label11)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.tbConstructeur)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.Label9)
        Me.collapsiblePanelOrdinateur.EndColour = System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.collapsiblePanelOrdinateur.Image = Nothing
        Me.collapsiblePanelOrdinateur.Location = New System.Drawing.Point(8, 8)
        Me.collapsiblePanelOrdinateur.Name = "collapsiblePanelOrdinateur"
        Me.collapsiblePanelOrdinateur.PanelState = Salamander.Windows.Forms.PanelState.Expanded
        Me.collapsiblePanelOrdinateur.Size = New System.Drawing.Size(255, 155)
        Me.collapsiblePanelOrdinateur.StartColour = System.Drawing.Color.White
        Me.collapsiblePanelOrdinateur.TabIndex = 1
        Me.collapsiblePanelOrdinateur.TitleFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.collapsiblePanelOrdinateur.TitleFontColour = System.Drawing.Color.Navy
        Me.collapsiblePanelOrdinateur.TitleText = "Ordinateur"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Constructeur"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "N° Série"
        '
        'tbModele
        '
        Me.tbModele.BackColor = System.Drawing.SystemColors.Info
        Me.tbModele.Location = New System.Drawing.Point(96, 51)
        Me.tbModele.Name = "tbModele"
        Me.tbModele.ReadOnly = True
        Me.tbModele.Size = New System.Drawing.Size(150, 20)
        Me.tbModele.TabIndex = 8
        '
        'tbSerialNumber
        '
        Me.tbSerialNumber.BackColor = System.Drawing.SystemColors.Info
        Me.tbSerialNumber.Location = New System.Drawing.Point(96, 99)
        Me.tbSerialNumber.Name = "tbSerialNumber"
        Me.tbSerialNumber.ReadOnly = True
        Me.tbSerialNumber.Size = New System.Drawing.Size(150, 20)
        Me.tbSerialNumber.TabIndex = 28
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 13)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Modele"
        '
        'tbHostname
        '
        Me.tbHostname.BackColor = System.Drawing.SystemColors.Info
        Me.tbHostname.Location = New System.Drawing.Point(96, 122)
        Me.tbHostname.Name = "tbHostname"
        Me.tbHostname.ReadOnly = True
        Me.tbHostname.Size = New System.Drawing.Size(150, 20)
        Me.tbHostname.TabIndex = 14
        '
        'tbMemoireTotale
        '
        Me.tbMemoireTotale.BackColor = System.Drawing.SystemColors.Info
        Me.tbMemoireTotale.Location = New System.Drawing.Point(96, 76)
        Me.tbMemoireTotale.Name = "tbMemoireTotale"
        Me.tbMemoireTotale.ReadOnly = True
        Me.tbMemoireTotale.Size = New System.Drawing.Size(150, 20)
        Me.tbMemoireTotale.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Memoire installée"
        '
        'tbConstructeur
        '
        Me.tbConstructeur.BackColor = System.Drawing.SystemColors.Info
        Me.tbConstructeur.Location = New System.Drawing.Point(96, 28)
        Me.tbConstructeur.Name = "tbConstructeur"
        Me.tbConstructeur.ReadOnly = True
        Me.tbConstructeur.Size = New System.Drawing.Size(150, 20)
        Me.tbConstructeur.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 124)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Nom Machine"
        '
        'LvProgramsBatch
        '
        Me.LvProgramsBatch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvProgramsBatch.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.LvProgramsBatch.FullRowSelect = True
        Me.LvProgramsBatch.Location = New System.Drawing.Point(0, 24)
        Me.LvProgramsBatch.Name = "LvProgramsBatch"
        Me.LvProgramsBatch.Size = New System.Drawing.Size(255, 301)
        Me.LvProgramsBatch.TabIndex = 1
        Me.LvProgramsBatch.UseCompatibleStateImageBehavior = False
        Me.LvProgramsBatch.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Program"
        Me.ColumnHeader1.Width = 360
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Version"
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Publisher"
        Me.ColumnHeader3.Width = 220
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Date Install"
        Me.ColumnHeader4.Width = 96
        '
        'btDisplayPrev
        '
        Me.btDisplayPrev.BackgroundImage = Global.My.Resources.Resources.arrow_180_medium
        Me.btDisplayPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btDisplayPrev.Dock = System.Windows.Forms.DockStyle.Right
        Me.btDisplayPrev.Enabled = False
        Me.btDisplayPrev.Location = New System.Drawing.Point(215, 0)
        Me.btDisplayPrev.Name = "btDisplayPrev"
        Me.btDisplayPrev.Size = New System.Drawing.Size(20, 18)
        Me.btDisplayPrev.TabIndex = 16
        Me.btDisplayPrev.Tag = "prev"
        Me.btDisplayPrev.UseVisualStyleBackColor = True
        '
        'btDisplayNext
        '
        Me.btDisplayNext.BackgroundImage = Global.My.Resources.Resources.arrow_000_medium
        Me.btDisplayNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btDisplayNext.Dock = System.Windows.Forms.DockStyle.Right
        Me.btDisplayNext.Enabled = False
        Me.btDisplayNext.Location = New System.Drawing.Point(235, 0)
        Me.btDisplayNext.Name = "btDisplayNext"
        Me.btDisplayNext.Size = New System.Drawing.Size(20, 18)
        Me.btDisplayNext.TabIndex = 15
        Me.btDisplayNext.Tag = "next"
        Me.btDisplayNext.UseVisualStyleBackColor = True
        '
        'btDisplayDetails
        '
        Me.btDisplayDetails.BackgroundImage = Global.My.Resources.Resources.plus_circle
        Me.btDisplayDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btDisplayDetails.Dock = System.Windows.Forms.DockStyle.Left
        Me.btDisplayDetails.Enabled = False
        Me.btDisplayDetails.Location = New System.Drawing.Point(0, 0)
        Me.btDisplayDetails.Name = "btDisplayDetails"
        Me.btDisplayDetails.Size = New System.Drawing.Size(20, 18)
        Me.btDisplayDetails.TabIndex = 1
        Me.btDisplayDetails.UseVisualStyleBackColor = True
        '
        'btnExportExcel
        '
        Me.btnExportExcel.BackgroundImage = Global.My.Resources.Resources.icone_excel
        Me.btnExportExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportExcel.Location = New System.Drawing.Point(0, 59)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(33, 30)
        Me.btnExportExcel.TabIndex = 5
        Me.btnExportExcel.UseVisualStyleBackColor = True
        '
        'btCollapsePanelInfos
        '
        Me.btCollapsePanelInfos.BackgroundImage = Global.My.Resources.Resources.UCI_Viewer_Selection_Panel_icon
        Me.btCollapsePanelInfos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btCollapsePanelInfos.Location = New System.Drawing.Point(0, 31)
        Me.btCollapsePanelInfos.Name = "btCollapsePanelInfos"
        Me.btCollapsePanelInfos.Size = New System.Drawing.Size(33, 29)
        Me.btCollapsePanelInfos.TabIndex = 4
        Me.btCollapsePanelInfos.UseVisualStyleBackColor = True
        '
        'btnReload
        '
        Me.btnReload.BackgroundImage = Global.My.Resources.Resources.refresh32
        Me.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReload.Location = New System.Drawing.Point(1, 0)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(32, 32)
        Me.btnReload.TabIndex = 3
        Me.btnReload.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.My.Resources.Resources.magnifier
        Me.PictureBox1.Location = New System.Drawing.Point(952, 62)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'frmDatagridScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 914)
        Me.Controls.Add(Me.scDatagridScan)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MinimumSize = New System.Drawing.Size(897, 39)
        Me.Name = "frmDatagridScan"
        Me.Text = "ScanParc"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbxOptions.ResumeLayout(False)
        Me.gbxOptions.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridViewScan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scDatagridScan.Panel1.ResumeLayout(False)
        Me.scDatagridScan.Panel2.ResumeLayout(False)
        Me.scDatagridScan.Panel2.PerformLayout()
        CType(Me.scDatagridScan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scDatagridScan.ResumeLayout(False)
        CType(Me.CollapsiblePanelBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CollapsiblePanelBar1.ResumeLayout(False)
        Me.CollapsiblePanelProgrammes.ResumeLayout(False)
        Me.CollapsiblePanelDisplay.ResumeLayout(False)
        Me.CollapsiblePanelDisplay.PerformLayout()
        Me.PanelDetailDisplay.ResumeLayout(False)
        Me.PanelDetailDisplay.PerformLayout()
        Me.CollapsiblePanelOs.ResumeLayout(False)
        Me.CollapsiblePanelOs.PerformLayout()
        Me.collapsiblePanelOrdinateur.ResumeLayout(False)
        Me.collapsiblePanelOrdinateur.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewScan As System.Windows.Forms.DataGridView
    Friend WithEvents tbSearch As System.Windows.Forms.TextBox
    Friend WithEvents tbNbStations As System.Windows.Forms.TextBox
    Friend WithEvents lblNbreStation As System.Windows.Forms.Label
    Friend WithEvents cbSite As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tbBindingSourceCount As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbBSOD As System.Windows.Forms.TextBox
    Friend WithEvents tbBlocHS As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbScanKO As System.Windows.Forms.TextBox
    Friend WithEvents btnReload As System.Windows.Forms.Button
    Friend WithEvents btCollapsePanelInfos As System.Windows.Forms.Button
    Friend WithEvents btnExportExcel As System.Windows.Forms.Button
    Friend WithEvents cbShowScanKO As System.Windows.Forms.CheckBox
    Friend WithEvents cbDeletedStations As System.Windows.Forms.CheckBox
    Friend WithEvents scDatagridScan As System.Windows.Forms.SplitContainer
    Friend WithEvents CollapsiblePanelBar1 As Salamander.Windows.Forms.CollapsiblePanelBar
    Friend WithEvents collapsiblePanelOrdinateur As Salamander.Windows.Forms.CollapsiblePanel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbModele As System.Windows.Forms.TextBox
    Friend WithEvents tbSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbHostname As System.Windows.Forms.TextBox
    Friend WithEvents tbMemoireTotale As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbConstructeur As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CollapsiblePanelOs As Salamander.Windows.Forms.CollapsiblePanel
    Friend WithEvents tbUpTime As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tbSocle As System.Windows.Forms.TextBox
    Friend WithEvents tbOperatingSystem As System.Windows.Forms.TextBox
    Friend WithEvents CollapsiblePanelDisplay As Salamander.Windows.Forms.CollapsiblePanel
    Friend WithEvents tbMonitorDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents PanelDetailDisplay As System.Windows.Forms.Panel
    Friend WithEvents lbDisplayCount As System.Windows.Forms.Label
    Friend WithEvents btDisplayPrev As System.Windows.Forms.Button
    Friend WithEvents btDisplayNext As System.Windows.Forms.Button
    Friend WithEvents btDisplayDetails As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents tbMonitorName As System.Windows.Forms.TextBox
    Friend WithEvents tbMonitorSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents CollapsiblePanelProgrammes As Salamander.Windows.Forms.CollapsiblePanel
    Friend WithEvents cbSearchForProgram As System.Windows.Forms.CheckBox
    Friend WithEvents LvProgramsBatch As lvPrograms
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbxOptions As System.Windows.Forms.GroupBox
    Friend WithEvents cbProgramExactString As System.Windows.Forms.CheckBox
    Friend WithEvents progBarrQuery As System.Windows.Forms.ProgressBar
    Friend WithEvents cmbFilterModel As System.Windows.Forms.ComboBox
    Friend WithEvents lblSite As System.Windows.Forms.Label
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents cmbFilterOsName As System.Windows.Forms.ComboBox
    Friend WithEvents lblOsName As System.Windows.Forms.Label
    Friend WithEvents cbFilterDateScan As System.Windows.Forms.CheckBox
End Class
