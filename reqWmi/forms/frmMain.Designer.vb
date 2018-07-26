<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitterToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChkdskFR = New System.Windows.Forms.ToolStripMenuItem()
        Me.FavorisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveLogDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.StatusStripMain = New System.Windows.Forms.StatusStrip()
        Me.tstripLabelStationName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstripLabelNbProcesses = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstripLabelNbServices = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressMain = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusConx = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ChkdskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CollapsiblePanelVideoController = New Salamander.Windows.Forms.CollapsiblePanel()
        Me.lbVideoControllerDriverVersion = New System.Windows.Forms.Label()
        Me.tbDriverVersion = New System.Windows.Forms.TextBox()
        Me.lbVideoControllerInstalledDriver = New System.Windows.Forms.Label()
        Me.tbInstalledDriver = New System.Windows.Forms.TextBox()
        Me.PanelDetailvideoController = New System.Windows.Forms.Panel()
        Me.btVideoControllerPrev = New System.Windows.Forms.Button()
        Me.lbVideoControllerCount = New System.Windows.Forms.Label()
        Me.btVideoControllerNext = New System.Windows.Forms.Button()
        Me.btVideoControllerDetail = New System.Windows.Forms.Button()
        Me.lbVideoControllerYres = New System.Windows.Forms.Label()
        Me.LbVideoControllerProcessor = New System.Windows.Forms.Label()
        Me.lbVideoControlleRefreshRate = New System.Windows.Forms.Label()
        Me.lbVideoControllerHres = New System.Windows.Forms.Label()
        Me.lbVideoControllerCaption = New System.Windows.Forms.Label()
        Me.tbVideoProcessor = New System.Windows.Forms.TextBox()
        Me.lbVideoControllerRam = New System.Windows.Forms.Label()
        Me.tbRefreshRate = New System.Windows.Forms.TextBox()
        Me.tbAdapterRAM = New System.Windows.Forms.TextBox()
        Me.tbVresolution = New System.Windows.Forms.TextBox()
        Me.tbHresolution = New System.Windows.Forms.TextBox()
        Me.tbCaption = New System.Windows.Forms.TextBox()
        Me.CollapsiblePanelDisplay = New Salamander.Windows.Forms.CollapsiblePanel()
        Me.tbMonitorDisplayName = New System.Windows.Forms.TextBox()
        Me.PanelDetailDisplay = New System.Windows.Forms.Panel()
        Me.lbDisplayCount = New System.Windows.Forms.Label()
        Me.btDisplayPrev = New System.Windows.Forms.Button()
        Me.btDisplayNext = New System.Windows.Forms.Button()
        Me.btDisplayDetails = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tbMonitorName = New System.Windows.Forms.TextBox()
        Me.tbMonitorSerialNumber = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.CollapsiblePanelNetwork = New Salamander.Windows.Forms.CollapsiblePanel()
        Me.CollapsiblePanel1 = New Salamander.Windows.Forms.CollapsiblePanel()
        Me.tbNetworkDriverManufacturer = New System.Windows.Forms.TextBox()
        Me.lblDriverManufacturer = New System.Windows.Forms.Label()
        Me.tbNetworkDriverDate = New System.Windows.Forms.TextBox()
        Me.blbDriverDate = New System.Windows.Forms.Label()
        Me.tbNetworkDriverVersion = New System.Windows.Forms.TextBox()
        Me.blbDriverVersion = New System.Windows.Forms.Label()
        Me.tbNetworkDriverDesc = New System.Windows.Forms.TextBox()
        Me.lblDriverDesc = New System.Windows.Forms.Label()
        Me.tbEstimatedSpeed = New System.Windows.Forms.TextBox()
        Me.PanelDetailNetwork = New System.Windows.Forms.Panel()
        Me.btNetIDetails = New System.Windows.Forms.Button()
        Me.lbNetworkCount = New System.Windows.Forms.Label()
        Me.btPrev = New System.Windows.Forms.Button()
        Me.btNext = New System.Windows.Forms.Button()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.tbIpSubnet = New System.Windows.Forms.TextBox()
        Me.lbIpSubnet = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tbNetConnectionID = New System.Windows.Forms.TextBox()
        Me.tbGateway = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.tbDHCPEnabled = New System.Windows.Forms.TextBox()
        Me.tbIpAdress = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tbMACadress = New System.Windows.Forms.TextBox()
        Me.CollapsiblePanelOs = New Salamander.Windows.Forms.CollapsiblePanel()
        Me.tbOsDateInstall = New System.Windows.Forms.TextBox()
        Me.lblOSDateInstall = New System.Windows.Forms.Label()
        Me.tbOsArch = New System.Windows.Forms.TextBox()
        Me.lblOsArch = New System.Windows.Forms.Label()
        Me.CollapsiblePanel2 = New Salamander.Windows.Forms.CollapsiblePanel()
        Me.tbUpTime = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbServicePack = New System.Windows.Forms.TextBox()
        Me.tbSocle = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbOperatingSystem = New System.Windows.Forms.TextBox()
        Me.PanelMainControls = New System.Windows.Forms.Panel()
        Me.lblBetaVersion = New System.Windows.Forms.Label()
        Me.lblOsArchi = New System.Windows.Forms.Label()
        Me.lblLDAPDeleted = New System.Windows.Forms.Label()
        Me.lbOfflineMode = New System.Windows.Forms.Label()
        Me.lblReservIP = New System.Windows.Forms.Label()
        Me.lblDHCP = New System.Windows.Forms.Label()
        Me.lblWGA = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNetIO = New System.Windows.Forms.Label()
        Me.lblDiskIO = New System.Windows.Forms.Label()
        Me.lblFreeRam = New System.Windows.Forms.Label()
        Me.lblCpuUse = New System.Windows.Forms.Label()
        Me.btEnvVar = New System.Windows.Forms.Button()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.tbControlMain = New System.Windows.Forms.TabControl()
        Me.tabProgrammes = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ckbHighlistProgDiff = New System.Windows.Forms.CheckBox()
        Me.PanelProgramFilterButtons = New System.Windows.Forms.Panel()
        Me.ckbFilterHorsSujet = New System.Windows.Forms.CheckBox()
        Me.ckbFilterMicrosoft = New System.Windows.Forms.CheckBox()
        Me.ckbChuFilter = New System.Windows.Forms.CheckBox()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.PanelLegendProgramDiff = New System.Windows.Forms.Panel()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tbSearchProgram = New System.Windows.Forms.TextBox()
        Me.tabProcess = New System.Windows.Forms.TabPage()
        Me.tabServices = New System.Windows.Forms.TabPage()
        Me.TabCommentaires = New System.Windows.Forms.TabPage()
        Me.SplitContainerCommentaires = New System.Windows.Forms.SplitContainer()
        Me.btnSendCommentaire = New System.Windows.Forms.Button()
        Me.rtbCommentairesInput = New System.Windows.Forms.RichTextBox()
        Me.lvLog = New System.Windows.Forms.ListView()
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnPrinterInfos = New System.Windows.Forms.Button()
        Me.cmbStationName = New System.Windows.Forms.ComboBox()
        Me.GroupBoxResults = New System.Windows.Forms.GroupBox()
        Me.btnClearLogs = New System.Windows.Forms.Button()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.tbOfficeErrors = New System.Windows.Forms.TextBox()
        Me.cbLogFilterByDate = New System.Windows.Forms.CheckBox()
        Me.lblErrApplication = New System.Windows.Forms.Label()
        Me.tbErrApplication = New System.Windows.Forms.TextBox()
        Me.tbNtfsError = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.tbftDiskError = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.tbHdFailure = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.tbErrControleur = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtbBsod = New System.Windows.Forms.TextBox()
        Me.LblErrDisk = New System.Windows.Forms.Label()
        Me.lblErrNetwork = New System.Windows.Forms.Label()
        Me.lblRebootSauvage = New System.Windows.Forms.Label()
        Me.txtbErrReboot = New System.Windows.Forms.TextBox()
        Me.btnLogDetails = New System.Windows.Forms.Button()
        Me.txtbErrNetwork = New System.Windows.Forms.TextBox()
        Me.txtbErrDisque = New System.Windows.Forms.TextBox()
        Me.btnFrmBatch = New System.Windows.Forms.Button()
        Me.panelLaunchButtons = New System.Windows.Forms.Panel()
        Me.btScmRdp = New System.Windows.Forms.Button()
        Me.btComptMgmt = New System.Windows.Forms.Button()
        Me.btnVnc = New System.Windows.Forms.Button()
        Me.btnCleanStation = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnlancer = New System.Windows.Forms.Button()
        Me.GroupBoxDisk = New System.Windows.Forms.GroupBox()
        Me.ContextMenuStripDisk = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OuvrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SMARTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBoxPinger = New System.Windows.Forms.GroupBox()
        Me.btDetailPing = New System.Windows.Forms.Button()
        Me.cbChangeBufferPingSize = New System.Windows.Forms.CheckBox()
        Me.btResetPing = New System.Windows.Forms.Button()
        Me.btCreatePingReport = New System.Windows.Forms.Button()
        Me.Lvping = New System.Windows.Forms.ListView()
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tbPingSent = New System.Windows.Forms.TextBox()
        Me.tbPingLOst = New System.Windows.Forms.TextBox()
        Me.tbMaxRoundTrip = New System.Windows.Forms.TextBox()
        Me.tbPercentLost = New System.Windows.Forms.TextBox()
        Me.tbMinRoundtrip = New System.Windows.Forms.TextBox()
        Me.tbAvgRoundtrip = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.MenuStripFrmMain = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuOutils = New System.Windows.Forms.ToolStripMenuItem()
        Me.VNCQueryConnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VNCNotificationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SCCMValidationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfosUtilisateurToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PsExecToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DefragToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DefragAnalyseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArreterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArreterForcerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedémarrerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedémarrerForcerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChkdskFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChkdskFRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RsopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfosHDDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerouillerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScanImprimantesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlushdnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OuvrirConsoleCtrlkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuAffichage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPanneauLateral = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemLogs = New System.Windows.Forms.ToolStripMenuItem()
        Me.NouvelOngletToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FermerOngletToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.FlowLayoutPanelCollapsiblePanels = New System.Windows.Forms.FlowLayoutPanel()
        Me.collapsiblePanelOrdinateur = New Salamander.Windows.Forms.CollapsiblePanel()
        Me.btUserInfos = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbDomaine = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbModele = New System.Windows.Forms.TextBox()
        Me.tbSerialNumber = New System.Windows.Forms.TextBox()
        Me.tbFreeMemory = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbMaxFrequency = New System.Windows.Forms.TextBox()
        Me.tbHostname = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbMemoireTotale = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbNbCpu = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbProcessor = New System.Windows.Forms.TextBox()
        Me.tbCurrentUser = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbConstructeur = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CollapsiblePanelActiveDirectory = New Salamander.Windows.Forms.CollapsiblePanel()
        Me.lblADComputerLastLogonTS = New System.Windows.Forms.Label()
        Me.tbADcomputerLastLogonTS = New System.Windows.Forms.TextBox()
        Me.lblADComputerDN = New System.Windows.Forms.Label()
        Me.tbADcomputerDN = New System.Windows.Forms.TextBox()
        Me.lblADComputerSercicePack = New System.Windows.Forms.Label()
        Me.tbADComputerServicePack = New System.Windows.Forms.TextBox()
        Me.lblADComputerOS = New System.Windows.Forms.Label()
        Me.tbADcomputerOS = New System.Windows.Forms.TextBox()
        Me.lblADComputerCreationDate = New System.Windows.Forms.Label()
        Me.tbADComputerCreationDate = New System.Windows.Forms.TextBox()
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CpuGraph = New cpuGraph()
        Me.DiskIOGraph = New diskIOGraph()
        Me.FreeMemoryGraph = New freeMemoryGraph()
        Me.NetworkIOgraph = New networkIOgraph()
        Me.LvPrograms = New lvPrograms()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LvProcess = New lvProcess()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LvServices = New lvServices(Me.components)
        Me.ColumnHeaderNom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderDemarrage = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderCompte = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderPath = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderServiceType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderProcessPID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PanelSearchcommentaires = New gradientPanel()
        Me.btLastComments = New System.Windows.Forms.Button()
        Me.cbAssocierStation = New System.Windows.Forms.CheckBox()
        Me.PanelSearchCommentaire = New System.Windows.Forms.Panel()
        Me.pbLoupe = New System.Windows.Forms.PictureBox()
        Me.lbNbResultsCount = New System.Windows.Forms.Label()
        Me.tbSearchCommentaire = New System.Windows.Forms.TextBox()
        Me.LvInfoDisk = New lvInfoDisk()
        Me.columnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StatusStripMain.SuspendLayout()
        Me.CollapsiblePanelVideoController.SuspendLayout()
        Me.PanelDetailvideoController.SuspendLayout()
        Me.CollapsiblePanelDisplay.SuspendLayout()
        Me.PanelDetailDisplay.SuspendLayout()
        Me.CollapsiblePanelNetwork.SuspendLayout()
        Me.PanelDetailNetwork.SuspendLayout()
        Me.CollapsiblePanelOs.SuspendLayout()
        Me.PanelMainControls.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.tbControlMain.SuspendLayout()
        Me.tabProgrammes.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.PanelProgramFilterButtons.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.PanelLegendProgramDiff.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabProcess.SuspendLayout()
        Me.tabServices.SuspendLayout()
        Me.TabCommentaires.SuspendLayout()
        CType(Me.SplitContainerCommentaires, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerCommentaires.Panel2.SuspendLayout()
        Me.SplitContainerCommentaires.SuspendLayout()
        Me.GroupBoxResults.SuspendLayout()
        Me.panelLaunchButtons.SuspendLayout()
        Me.GroupBoxDisk.SuspendLayout()
        Me.ContextMenuStripDisk.SuspendLayout()
        Me.GroupBoxPinger.SuspendLayout()
        Me.MenuStripFrmMain.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.FlowLayoutPanelCollapsiblePanels.SuspendLayout()
        Me.collapsiblePanelOrdinateur.SuspendLayout()
        Me.CollapsiblePanelActiveDirectory.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.PanelSearchcommentaires.SuspendLayout()
        Me.PanelSearchCommentaire.SuspendLayout()
        CType(Me.pbLoupe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 20)
        '
        'QuitterToolStripMenuItem1
        '
        Me.QuitterToolStripMenuItem1.Name = "QuitterToolStripMenuItem1"
        Me.QuitterToolStripMenuItem1.Size = New System.Drawing.Size(32, 19)
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(12, 20)
        '
        'ChkdskFR
        '
        Me.ChkdskFR.Name = "ChkdskFR"
        Me.ChkdskFR.Size = New System.Drawing.Size(32, 19)
        '
        'FavorisToolStripMenuItem
        '
        Me.FavorisToolStripMenuItem.Name = "FavorisToolStripMenuItem"
        Me.FavorisToolStripMenuItem.Size = New System.Drawing.Size(12, 20)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 6)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(12, 20)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(12, 20)
        '
        'StatusStripMain
        '
        Me.StatusStripMain.AutoSize = False
        Me.StatusStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstripLabelStationName, Me.tstripLabelNbProcesses, Me.tstripLabelNbServices, Me.ToolStripProgressMain, Me.ToolStripStatusConx})
        Me.StatusStripMain.Location = New System.Drawing.Point(0, 720)
        Me.StatusStripMain.Name = "StatusStripMain"
        Me.StatusStripMain.Size = New System.Drawing.Size(1356, 22)
        Me.StatusStripMain.TabIndex = 50
        '
        'tstripLabelStationName
        '
        Me.tstripLabelStationName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.tstripLabelStationName.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.tstripLabelStationName.Name = "tstripLabelStationName"
        Me.tstripLabelStationName.Size = New System.Drawing.Size(84, 17)
        Me.tstripLabelStationName.Text = "non connecté"
        Me.tstripLabelStationName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tstripLabelNbProcesses
        '
        Me.tstripLabelNbProcesses.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.tstripLabelNbProcesses.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.tstripLabelNbProcesses.Name = "tstripLabelNbProcesses"
        Me.tstripLabelNbProcesses.Size = New System.Drawing.Size(28, 17)
        Me.tstripLabelNbProcesses.Text = "NA"
        '
        'tstripLabelNbServices
        '
        Me.tstripLabelNbServices.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.tstripLabelNbServices.Name = "tstripLabelNbServices"
        Me.tstripLabelNbServices.Size = New System.Drawing.Size(28, 17)
        Me.tstripLabelNbServices.Text = "NA"
        '
        'ToolStripProgressMain
        '
        Me.ToolStripProgressMain.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripProgressMain.Name = "ToolStripProgressMain"
        Me.ToolStripProgressMain.Size = New System.Drawing.Size(100, 16)
        '
        'ToolStripStatusConx
        '
        Me.ToolStripStatusConx.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.ToolStripStatusConx.Image = Global.My.Resources.Resources.cross_circle16
        Me.ToolStripStatusConx.Name = "ToolStripStatusConx"
        Me.ToolStripStatusConx.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripStatusConx.Size = New System.Drawing.Size(20, 17)
        Me.ToolStripStatusConx.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ChkdskToolStripMenuItem
        '
        Me.ChkdskToolStripMenuItem.Enabled = False
        Me.ChkdskToolStripMenuItem.Name = "ChkdskToolStripMenuItem"
        Me.ChkdskToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.ChkdskToolStripMenuItem.Text = "Chkdsk"
        '
        'CollapsiblePanelVideoController
        '
        Me.CollapsiblePanelVideoController.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CollapsiblePanelVideoController.BackColor = System.Drawing.Color.Lavender
        Me.CollapsiblePanelVideoController.Controls.Add(Me.lbVideoControllerDriverVersion)
        Me.CollapsiblePanelVideoController.Controls.Add(Me.tbDriverVersion)
        Me.CollapsiblePanelVideoController.Controls.Add(Me.lbVideoControllerInstalledDriver)
        Me.CollapsiblePanelVideoController.Controls.Add(Me.tbInstalledDriver)
        Me.CollapsiblePanelVideoController.Controls.Add(Me.PanelDetailvideoController)
        Me.CollapsiblePanelVideoController.Controls.Add(Me.lbVideoControllerYres)
        Me.CollapsiblePanelVideoController.Controls.Add(Me.LbVideoControllerProcessor)
        Me.CollapsiblePanelVideoController.Controls.Add(Me.lbVideoControlleRefreshRate)
        Me.CollapsiblePanelVideoController.Controls.Add(Me.lbVideoControllerHres)
        Me.CollapsiblePanelVideoController.Controls.Add(Me.lbVideoControllerCaption)
        Me.CollapsiblePanelVideoController.Controls.Add(Me.tbVideoProcessor)
        Me.CollapsiblePanelVideoController.Controls.Add(Me.lbVideoControllerRam)
        Me.CollapsiblePanelVideoController.Controls.Add(Me.tbRefreshRate)
        Me.CollapsiblePanelVideoController.Controls.Add(Me.tbAdapterRAM)
        Me.CollapsiblePanelVideoController.Controls.Add(Me.tbVresolution)
        Me.CollapsiblePanelVideoController.Controls.Add(Me.tbHresolution)
        Me.CollapsiblePanelVideoController.Controls.Add(Me.tbCaption)
        Me.CollapsiblePanelVideoController.EndColour = System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.CollapsiblePanelVideoController.Image = Nothing
        Me.CollapsiblePanelVideoController.Location = New System.Drawing.Point(4, 1083)
        Me.CollapsiblePanelVideoController.Margin = New System.Windows.Forms.Padding(1)
        Me.CollapsiblePanelVideoController.Name = "CollapsiblePanelVideoController"
        Me.CollapsiblePanelVideoController.PanelState = Salamander.Windows.Forms.PanelState.Expanded
        Me.CollapsiblePanelVideoController.Size = New System.Drawing.Size(265, 261)
        Me.CollapsiblePanelVideoController.StartColour = System.Drawing.Color.White
        Me.CollapsiblePanelVideoController.TabIndex = 4
        Me.CollapsiblePanelVideoController.TitleFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CollapsiblePanelVideoController.TitleFontColour = System.Drawing.Color.Navy
        Me.CollapsiblePanelVideoController.TitleText = "Carte Video"
        '
        'lbVideoControllerDriverVersion
        '
        Me.lbVideoControllerDriverVersion.AutoSize = True
        Me.lbVideoControllerDriverVersion.Location = New System.Drawing.Point(8, 214)
        Me.lbVideoControllerDriverVersion.Name = "lbVideoControllerDriverVersion"
        Me.lbVideoControllerDriverVersion.Size = New System.Drawing.Size(73, 13)
        Me.lbVideoControllerDriverVersion.TabIndex = 19
        Me.lbVideoControllerDriverVersion.Text = "Version Driver"
        '
        'tbDriverVersion
        '
        Me.tbDriverVersion.BackColor = System.Drawing.SystemColors.Info
        Me.tbDriverVersion.Location = New System.Drawing.Point(100, 211)
        Me.tbDriverVersion.Name = "tbDriverVersion"
        Me.tbDriverVersion.ReadOnly = True
        Me.tbDriverVersion.Size = New System.Drawing.Size(150, 20)
        Me.tbDriverVersion.TabIndex = 18
        '
        'lbVideoControllerInstalledDriver
        '
        Me.lbVideoControllerInstalledDriver.AutoSize = True
        Me.lbVideoControllerInstalledDriver.Location = New System.Drawing.Point(8, 188)
        Me.lbVideoControllerInstalledDriver.Name = "lbVideoControllerInstalledDriver"
        Me.lbVideoControllerInstalledDriver.Size = New System.Drawing.Size(71, 13)
        Me.lbVideoControllerInstalledDriver.TabIndex = 17
        Me.lbVideoControllerInstalledDriver.Text = "Driver Installé"
        '
        'tbInstalledDriver
        '
        Me.tbInstalledDriver.BackColor = System.Drawing.SystemColors.Info
        Me.tbInstalledDriver.Location = New System.Drawing.Point(100, 185)
        Me.tbInstalledDriver.Name = "tbInstalledDriver"
        Me.tbInstalledDriver.ReadOnly = True
        Me.tbInstalledDriver.Size = New System.Drawing.Size(150, 20)
        Me.tbInstalledDriver.TabIndex = 16
        '
        'PanelDetailvideoController
        '
        Me.PanelDetailvideoController.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelDetailvideoController.Controls.Add(Me.btVideoControllerPrev)
        Me.PanelDetailvideoController.Controls.Add(Me.lbVideoControllerCount)
        Me.PanelDetailvideoController.Controls.Add(Me.btVideoControllerNext)
        Me.PanelDetailvideoController.Controls.Add(Me.btVideoControllerDetail)
        Me.PanelDetailvideoController.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelDetailvideoController.Location = New System.Drawing.Point(0, 243)
        Me.PanelDetailvideoController.Name = "PanelDetailvideoController"
        Me.PanelDetailvideoController.Size = New System.Drawing.Size(265, 18)
        Me.PanelDetailvideoController.TabIndex = 7
        '
        'btVideoControllerPrev
        '
        Me.btVideoControllerPrev.BackgroundImage = Global.My.Resources.Resources.arrow_180_medium
        Me.btVideoControllerPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btVideoControllerPrev.Dock = System.Windows.Forms.DockStyle.Right
        Me.btVideoControllerPrev.Enabled = False
        Me.btVideoControllerPrev.Location = New System.Drawing.Point(225, 0)
        Me.btVideoControllerPrev.Name = "btVideoControllerPrev"
        Me.btVideoControllerPrev.Size = New System.Drawing.Size(20, 18)
        Me.btVideoControllerPrev.TabIndex = 17
        Me.btVideoControllerPrev.Tag = "prev"
        Me.btVideoControllerPrev.UseVisualStyleBackColor = True
        '
        'lbVideoControllerCount
        '
        Me.lbVideoControllerCount.AutoSize = True
        Me.lbVideoControllerCount.Location = New System.Drawing.Point(25, 3)
        Me.lbVideoControllerCount.Name = "lbVideoControllerCount"
        Me.lbVideoControllerCount.Size = New System.Drawing.Size(0, 13)
        Me.lbVideoControllerCount.TabIndex = 10
        '
        'btVideoControllerNext
        '
        Me.btVideoControllerNext.BackgroundImage = Global.My.Resources.Resources.arrow_000_medium
        Me.btVideoControllerNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btVideoControllerNext.Dock = System.Windows.Forms.DockStyle.Right
        Me.btVideoControllerNext.Enabled = False
        Me.btVideoControllerNext.Location = New System.Drawing.Point(245, 0)
        Me.btVideoControllerNext.Name = "btVideoControllerNext"
        Me.btVideoControllerNext.Size = New System.Drawing.Size(20, 18)
        Me.btVideoControllerNext.TabIndex = 16
        Me.btVideoControllerNext.Tag = "next"
        Me.btVideoControllerNext.UseVisualStyleBackColor = True
        '
        'btVideoControllerDetail
        '
        Me.btVideoControllerDetail.BackgroundImage = Global.My.Resources.Resources.plus_circle
        Me.btVideoControllerDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btVideoControllerDetail.Dock = System.Windows.Forms.DockStyle.Left
        Me.btVideoControllerDetail.Enabled = False
        Me.btVideoControllerDetail.Location = New System.Drawing.Point(0, 0)
        Me.btVideoControllerDetail.Name = "btVideoControllerDetail"
        Me.btVideoControllerDetail.Size = New System.Drawing.Size(20, 18)
        Me.btVideoControllerDetail.TabIndex = 1
        Me.btVideoControllerDetail.UseVisualStyleBackColor = True
        '
        'lbVideoControllerYres
        '
        Me.lbVideoControllerYres.AutoSize = True
        Me.lbVideoControllerYres.Location = New System.Drawing.Point(7, 110)
        Me.lbVideoControllerYres.Name = "lbVideoControllerYres"
        Me.lbVideoControllerYres.Size = New System.Drawing.Size(31, 13)
        Me.lbVideoControllerYres.TabIndex = 13
        Me.lbVideoControllerYres.Text = "Y-res"
        '
        'LbVideoControllerProcessor
        '
        Me.LbVideoControllerProcessor.AutoSize = True
        Me.LbVideoControllerProcessor.Location = New System.Drawing.Point(8, 162)
        Me.LbVideoControllerProcessor.Name = "LbVideoControllerProcessor"
        Me.LbVideoControllerProcessor.Size = New System.Drawing.Size(30, 13)
        Me.LbVideoControllerProcessor.TabIndex = 15
        Me.LbVideoControllerProcessor.Text = "GPU"
        '
        'lbVideoControlleRefreshRate
        '
        Me.lbVideoControlleRefreshRate.AutoSize = True
        Me.lbVideoControlleRefreshRate.Location = New System.Drawing.Point(6, 136)
        Me.lbVideoControlleRefreshRate.Name = "lbVideoControlleRefreshRate"
        Me.lbVideoControlleRefreshRate.Size = New System.Drawing.Size(66, 13)
        Me.lbVideoControlleRefreshRate.TabIndex = 14
        Me.lbVideoControlleRefreshRate.Text = "Refresh (Hz)"
        '
        'lbVideoControllerHres
        '
        Me.lbVideoControllerHres.AutoSize = True
        Me.lbVideoControllerHres.Location = New System.Drawing.Point(7, 84)
        Me.lbVideoControllerHres.Name = "lbVideoControllerHres"
        Me.lbVideoControllerHres.Size = New System.Drawing.Size(32, 13)
        Me.lbVideoControllerHres.TabIndex = 12
        Me.lbVideoControllerHres.Text = "H-res"
        '
        'lbVideoControllerCaption
        '
        Me.lbVideoControllerCaption.AutoSize = True
        Me.lbVideoControllerCaption.Location = New System.Drawing.Point(4, 58)
        Me.lbVideoControllerCaption.Name = "lbVideoControllerCaption"
        Me.lbVideoControllerCaption.Size = New System.Drawing.Size(28, 13)
        Me.lbVideoControllerCaption.TabIndex = 11
        Me.lbVideoControllerCaption.Text = "Titre"
        '
        'tbVideoProcessor
        '
        Me.tbVideoProcessor.BackColor = System.Drawing.SystemColors.Info
        Me.tbVideoProcessor.Location = New System.Drawing.Point(100, 159)
        Me.tbVideoProcessor.Name = "tbVideoProcessor"
        Me.tbVideoProcessor.ReadOnly = True
        Me.tbVideoProcessor.Size = New System.Drawing.Size(150, 20)
        Me.tbVideoProcessor.TabIndex = 9
        '
        'lbVideoControllerRam
        '
        Me.lbVideoControllerRam.AutoSize = True
        Me.lbVideoControllerRam.Location = New System.Drawing.Point(5, 32)
        Me.lbVideoControllerRam.Name = "lbVideoControllerRam"
        Me.lbVideoControllerRam.Size = New System.Drawing.Size(31, 13)
        Me.lbVideoControllerRam.TabIndex = 10
        Me.lbVideoControllerRam.Text = "RAM"
        '
        'tbRefreshRate
        '
        Me.tbRefreshRate.BackColor = System.Drawing.SystemColors.Info
        Me.tbRefreshRate.Location = New System.Drawing.Point(100, 133)
        Me.tbRefreshRate.Name = "tbRefreshRate"
        Me.tbRefreshRate.ReadOnly = True
        Me.tbRefreshRate.Size = New System.Drawing.Size(150, 20)
        Me.tbRefreshRate.TabIndex = 8
        '
        'tbAdapterRAM
        '
        Me.tbAdapterRAM.BackColor = System.Drawing.SystemColors.Info
        Me.tbAdapterRAM.Location = New System.Drawing.Point(100, 29)
        Me.tbAdapterRAM.Name = "tbAdapterRAM"
        Me.tbAdapterRAM.ReadOnly = True
        Me.tbAdapterRAM.Size = New System.Drawing.Size(150, 20)
        Me.tbAdapterRAM.TabIndex = 1
        '
        'tbVresolution
        '
        Me.tbVresolution.BackColor = System.Drawing.SystemColors.Info
        Me.tbVresolution.Location = New System.Drawing.Point(100, 107)
        Me.tbVresolution.Name = "tbVresolution"
        Me.tbVresolution.ReadOnly = True
        Me.tbVresolution.Size = New System.Drawing.Size(150, 20)
        Me.tbVresolution.TabIndex = 4
        '
        'tbHresolution
        '
        Me.tbHresolution.BackColor = System.Drawing.SystemColors.Info
        Me.tbHresolution.Location = New System.Drawing.Point(100, 81)
        Me.tbHresolution.Name = "tbHresolution"
        Me.tbHresolution.ReadOnly = True
        Me.tbHresolution.Size = New System.Drawing.Size(150, 20)
        Me.tbHresolution.TabIndex = 3
        '
        'tbCaption
        '
        Me.tbCaption.BackColor = System.Drawing.SystemColors.Info
        Me.tbCaption.Location = New System.Drawing.Point(100, 55)
        Me.tbCaption.Name = "tbCaption"
        Me.tbCaption.ReadOnly = True
        Me.tbCaption.Size = New System.Drawing.Size(150, 20)
        Me.tbCaption.TabIndex = 2
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
        Me.CollapsiblePanelDisplay.Location = New System.Drawing.Point(4, 955)
        Me.CollapsiblePanelDisplay.Margin = New System.Windows.Forms.Padding(1)
        Me.CollapsiblePanelDisplay.Name = "CollapsiblePanelDisplay"
        Me.CollapsiblePanelDisplay.PanelState = Salamander.Windows.Forms.PanelState.Expanded
        Me.CollapsiblePanelDisplay.Size = New System.Drawing.Size(265, 126)
        Me.CollapsiblePanelDisplay.StartColour = System.Drawing.Color.White
        Me.CollapsiblePanelDisplay.TabIndex = 3
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
        Me.PanelDetailDisplay.Size = New System.Drawing.Size(265, 18)
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
        'btDisplayPrev
        '
        Me.btDisplayPrev.BackgroundImage = Global.My.Resources.Resources.arrow_180_medium
        Me.btDisplayPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btDisplayPrev.Dock = System.Windows.Forms.DockStyle.Right
        Me.btDisplayPrev.Enabled = False
        Me.btDisplayPrev.Location = New System.Drawing.Point(225, 0)
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
        Me.btDisplayNext.Location = New System.Drawing.Point(245, 0)
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
        'CollapsiblePanelNetwork
        '
        Me.CollapsiblePanelNetwork.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CollapsiblePanelNetwork.BackColor = System.Drawing.Color.Lavender
        Me.CollapsiblePanelNetwork.Controls.Add(Me.CollapsiblePanel1)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.tbNetworkDriverManufacturer)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.lblDriverManufacturer)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.tbNetworkDriverDate)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.blbDriverDate)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.tbNetworkDriverVersion)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.blbDriverVersion)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.tbNetworkDriverDesc)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.lblDriverDesc)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.tbEstimatedSpeed)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.PanelDetailNetwork)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.Label37)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.tbIpSubnet)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.lbIpSubnet)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.Label19)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.tbNetConnectionID)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.tbGateway)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.Label20)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.Label23)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.tbDHCPEnabled)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.tbIpAdress)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.Label21)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.Label22)
        Me.CollapsiblePanelNetwork.Controls.Add(Me.tbMACadress)
        Me.CollapsiblePanelNetwork.EndColour = System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.CollapsiblePanelNetwork.Image = Nothing
        Me.CollapsiblePanelNetwork.Location = New System.Drawing.Point(4, 631)
        Me.CollapsiblePanelNetwork.Margin = New System.Windows.Forms.Padding(1)
        Me.CollapsiblePanelNetwork.Name = "CollapsiblePanelNetwork"
        Me.CollapsiblePanelNetwork.PanelState = Salamander.Windows.Forms.PanelState.Expanded
        Me.CollapsiblePanelNetwork.Size = New System.Drawing.Size(265, 322)
        Me.CollapsiblePanelNetwork.StartColour = System.Drawing.Color.White
        Me.CollapsiblePanelNetwork.TabIndex = 2
        Me.CollapsiblePanelNetwork.TitleFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CollapsiblePanelNetwork.TitleFontColour = System.Drawing.Color.Navy
        Me.CollapsiblePanelNetwork.TitleText = "Réseau"
        '
        'CollapsiblePanel1
        '
        Me.CollapsiblePanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CollapsiblePanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CollapsiblePanel1.EndColour = System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.CollapsiblePanel1.Image = Nothing
        Me.CollapsiblePanel1.Location = New System.Drawing.Point(7, -253)
        Me.CollapsiblePanel1.Name = "CollapsiblePanel1"
        Me.CollapsiblePanel1.PanelState = Salamander.Windows.Forms.PanelState.Expanded
        Me.CollapsiblePanel1.Size = New System.Drawing.Size(265, 100)
        Me.CollapsiblePanel1.StartColour = System.Drawing.Color.White
        Me.CollapsiblePanel1.TabIndex = 5
        Me.CollapsiblePanel1.TitleFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CollapsiblePanel1.TitleFontColour = System.Drawing.Color.Navy
        Me.CollapsiblePanel1.TitleText = "Title"
        '
        'tbNetworkDriverManufacturer
        '
        Me.tbNetworkDriverManufacturer.BackColor = System.Drawing.SystemColors.Info
        Me.tbNetworkDriverManufacturer.Location = New System.Drawing.Point(96, 266)
        Me.tbNetworkDriverManufacturer.Name = "tbNetworkDriverManufacturer"
        Me.tbNetworkDriverManufacturer.ReadOnly = True
        Me.tbNetworkDriverManufacturer.Size = New System.Drawing.Size(150, 20)
        Me.tbNetworkDriverManufacturer.TabIndex = 23
        '
        'lblDriverManufacturer
        '
        Me.lblDriverManufacturer.AutoSize = True
        Me.lblDriverManufacturer.Location = New System.Drawing.Point(3, 269)
        Me.lblDriverManufacturer.Name = "lblDriverManufacturer"
        Me.lblDriverManufacturer.Size = New System.Drawing.Size(73, 13)
        Me.lblDriverManufacturer.TabIndex = 22
        Me.lblDriverManufacturer.Text = " Manufacturer"
        '
        'tbNetworkDriverDate
        '
        Me.tbNetworkDriverDate.BackColor = System.Drawing.SystemColors.Info
        Me.tbNetworkDriverDate.Location = New System.Drawing.Point(96, 194)
        Me.tbNetworkDriverDate.Name = "tbNetworkDriverDate"
        Me.tbNetworkDriverDate.ReadOnly = True
        Me.tbNetworkDriverDate.Size = New System.Drawing.Size(150, 20)
        Me.tbNetworkDriverDate.TabIndex = 21
        '
        'blbDriverDate
        '
        Me.blbDriverDate.AutoSize = True
        Me.blbDriverDate.Location = New System.Drawing.Point(6, 197)
        Me.blbDriverDate.Name = "blbDriverDate"
        Me.blbDriverDate.Size = New System.Drawing.Size(61, 13)
        Me.blbDriverDate.TabIndex = 20
        Me.blbDriverDate.Text = "Driver Date"
        '
        'tbNetworkDriverVersion
        '
        Me.tbNetworkDriverVersion.BackColor = System.Drawing.SystemColors.Info
        Me.tbNetworkDriverVersion.Location = New System.Drawing.Point(96, 218)
        Me.tbNetworkDriverVersion.Name = "tbNetworkDriverVersion"
        Me.tbNetworkDriverVersion.ReadOnly = True
        Me.tbNetworkDriverVersion.Size = New System.Drawing.Size(150, 20)
        Me.tbNetworkDriverVersion.TabIndex = 19
        '
        'blbDriverVersion
        '
        Me.blbDriverVersion.AutoSize = True
        Me.blbDriverVersion.Location = New System.Drawing.Point(6, 221)
        Me.blbDriverVersion.Name = "blbDriverVersion"
        Me.blbDriverVersion.Size = New System.Drawing.Size(73, 13)
        Me.blbDriverVersion.TabIndex = 18
        Me.blbDriverVersion.Text = "Driver Version"
        '
        'tbNetworkDriverDesc
        '
        Me.tbNetworkDriverDesc.BackColor = System.Drawing.SystemColors.Info
        Me.tbNetworkDriverDesc.Location = New System.Drawing.Point(96, 242)
        Me.tbNetworkDriverDesc.Name = "tbNetworkDriverDesc"
        Me.tbNetworkDriverDesc.ReadOnly = True
        Me.tbNetworkDriverDesc.Size = New System.Drawing.Size(150, 20)
        Me.tbNetworkDriverDesc.TabIndex = 17
        '
        'lblDriverDesc
        '
        Me.lblDriverDesc.AutoSize = True
        Me.lblDriverDesc.Location = New System.Drawing.Point(6, 245)
        Me.lblDriverDesc.Name = "lblDriverDesc"
        Me.lblDriverDesc.Size = New System.Drawing.Size(66, 13)
        Me.lblDriverDesc.TabIndex = 16
        Me.lblDriverDesc.Text = "Driver Desc."
        '
        'tbEstimatedSpeed
        '
        Me.tbEstimatedSpeed.BackColor = System.Drawing.SystemColors.Info
        Me.tbEstimatedSpeed.Location = New System.Drawing.Point(96, 170)
        Me.tbEstimatedSpeed.Name = "tbEstimatedSpeed"
        Me.tbEstimatedSpeed.ReadOnly = True
        Me.tbEstimatedSpeed.Size = New System.Drawing.Size(150, 20)
        Me.tbEstimatedSpeed.TabIndex = 15
        '
        'PanelDetailNetwork
        '
        Me.PanelDetailNetwork.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelDetailNetwork.Controls.Add(Me.btNetIDetails)
        Me.PanelDetailNetwork.Controls.Add(Me.lbNetworkCount)
        Me.PanelDetailNetwork.Controls.Add(Me.btPrev)
        Me.PanelDetailNetwork.Controls.Add(Me.btNext)
        Me.PanelDetailNetwork.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelDetailNetwork.Location = New System.Drawing.Point(0, 304)
        Me.PanelDetailNetwork.Name = "PanelDetailNetwork"
        Me.PanelDetailNetwork.Size = New System.Drawing.Size(265, 18)
        Me.PanelDetailNetwork.TabIndex = 13
        '
        'btNetIDetails
        '
        Me.btNetIDetails.BackgroundImage = Global.My.Resources.Resources.plus_circle
        Me.btNetIDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btNetIDetails.Dock = System.Windows.Forms.DockStyle.Left
        Me.btNetIDetails.Enabled = False
        Me.btNetIDetails.Location = New System.Drawing.Point(0, 0)
        Me.btNetIDetails.Name = "btNetIDetails"
        Me.btNetIDetails.Size = New System.Drawing.Size(20, 18)
        Me.btNetIDetails.TabIndex = 0
        Me.btNetIDetails.UseVisualStyleBackColor = True
        '
        'lbNetworkCount
        '
        Me.lbNetworkCount.AutoSize = True
        Me.lbNetworkCount.Location = New System.Drawing.Point(25, 3)
        Me.lbNetworkCount.Name = "lbNetworkCount"
        Me.lbNetworkCount.Size = New System.Drawing.Size(0, 13)
        Me.lbNetworkCount.TabIndex = 7
        '
        'btPrev
        '
        Me.btPrev.BackgroundImage = Global.My.Resources.Resources.arrow_180_medium
        Me.btPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btPrev.Dock = System.Windows.Forms.DockStyle.Right
        Me.btPrev.Enabled = False
        Me.btPrev.Location = New System.Drawing.Point(225, 0)
        Me.btPrev.Name = "btPrev"
        Me.btPrev.Size = New System.Drawing.Size(20, 18)
        Me.btPrev.TabIndex = 14
        Me.btPrev.Tag = "prev"
        Me.btPrev.UseVisualStyleBackColor = True
        '
        'btNext
        '
        Me.btNext.BackgroundImage = Global.My.Resources.Resources.arrow_000_medium
        Me.btNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btNext.Dock = System.Windows.Forms.DockStyle.Right
        Me.btNext.Enabled = False
        Me.btNext.Location = New System.Drawing.Point(245, 0)
        Me.btNext.Name = "btNext"
        Me.btNext.Size = New System.Drawing.Size(20, 18)
        Me.btNext.TabIndex = 14
        Me.btNext.Tag = "next"
        Me.btNext.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(6, 173)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(69, 13)
        Me.Label37.TabIndex = 14
        Me.Label37.Text = "Estim. Speed"
        '
        'tbIpSubnet
        '
        Me.tbIpSubnet.BackColor = System.Drawing.SystemColors.Info
        Me.tbIpSubnet.Location = New System.Drawing.Point(96, 146)
        Me.tbIpSubnet.Name = "tbIpSubnet"
        Me.tbIpSubnet.ReadOnly = True
        Me.tbIpSubnet.Size = New System.Drawing.Size(150, 20)
        Me.tbIpSubnet.TabIndex = 12
        '
        'lbIpSubnet
        '
        Me.lbIpSubnet.AutoSize = True
        Me.lbIpSubnet.Location = New System.Drawing.Point(6, 149)
        Me.lbIpSubnet.Name = "lbIpSubnet"
        Me.lbIpSubnet.Size = New System.Drawing.Size(50, 13)
        Me.lbIpSubnet.TabIndex = 11
        Me.lbIpSubnet.Text = "IpSubnet"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 29)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(89, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "NetConnectionID"
        '
        'tbNetConnectionID
        '
        Me.tbNetConnectionID.BackColor = System.Drawing.SystemColors.Info
        Me.tbNetConnectionID.Location = New System.Drawing.Point(96, 26)
        Me.tbNetConnectionID.Name = "tbNetConnectionID"
        Me.tbNetConnectionID.ReadOnly = True
        Me.tbNetConnectionID.Size = New System.Drawing.Size(150, 20)
        Me.tbNetConnectionID.TabIndex = 1
        '
        'tbGateway
        '
        Me.tbGateway.BackColor = System.Drawing.SystemColors.Info
        Me.tbGateway.Location = New System.Drawing.Point(96, 122)
        Me.tbGateway.Name = "tbGateway"
        Me.tbGateway.ReadOnly = True
        Me.tbGateway.Size = New System.Drawing.Size(150, 20)
        Me.tbGateway.TabIndex = 9
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 53)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(76, 13)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "DHCPEnabled"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(6, 125)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(49, 13)
        Me.Label23.TabIndex = 8
        Me.Label23.Text = "Gateway"
        '
        'tbDHCPEnabled
        '
        Me.tbDHCPEnabled.BackColor = System.Drawing.SystemColors.Info
        Me.tbDHCPEnabled.Location = New System.Drawing.Point(96, 50)
        Me.tbDHCPEnabled.Name = "tbDHCPEnabled"
        Me.tbDHCPEnabled.ReadOnly = True
        Me.tbDHCPEnabled.Size = New System.Drawing.Size(150, 20)
        Me.tbDHCPEnabled.TabIndex = 3
        '
        'tbIpAdress
        '
        Me.tbIpAdress.BackColor = System.Drawing.SystemColors.Info
        Me.tbIpAdress.Location = New System.Drawing.Point(96, 98)
        Me.tbIpAdress.Name = "tbIpAdress"
        Me.tbIpAdress.ReadOnly = True
        Me.tbIpAdress.Size = New System.Drawing.Size(150, 20)
        Me.tbIpAdress.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 77)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 13)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "MACadress"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 101)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(48, 13)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "IpAdress"
        '
        'tbMACadress
        '
        Me.tbMACadress.BackColor = System.Drawing.SystemColors.Info
        Me.tbMACadress.Location = New System.Drawing.Point(96, 74)
        Me.tbMACadress.Name = "tbMACadress"
        Me.tbMACadress.ReadOnly = True
        Me.tbMACadress.Size = New System.Drawing.Size(150, 20)
        Me.tbMACadress.TabIndex = 5
        '
        'CollapsiblePanelOs
        '
        Me.CollapsiblePanelOs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CollapsiblePanelOs.BackColor = System.Drawing.Color.Lavender
        Me.CollapsiblePanelOs.Controls.Add(Me.tbOsDateInstall)
        Me.CollapsiblePanelOs.Controls.Add(Me.lblOSDateInstall)
        Me.CollapsiblePanelOs.Controls.Add(Me.tbOsArch)
        Me.CollapsiblePanelOs.Controls.Add(Me.lblOsArch)
        Me.CollapsiblePanelOs.Controls.Add(Me.CollapsiblePanel2)
        Me.CollapsiblePanelOs.Controls.Add(Me.tbUpTime)
        Me.CollapsiblePanelOs.Controls.Add(Me.Label24)
        Me.CollapsiblePanelOs.Controls.Add(Me.Label14)
        Me.CollapsiblePanelOs.Controls.Add(Me.Label16)
        Me.CollapsiblePanelOs.Controls.Add(Me.tbServicePack)
        Me.CollapsiblePanelOs.Controls.Add(Me.tbSocle)
        Me.CollapsiblePanelOs.Controls.Add(Me.Label15)
        Me.CollapsiblePanelOs.Controls.Add(Me.tbOperatingSystem)
        Me.CollapsiblePanelOs.EndColour = System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.CollapsiblePanelOs.Image = Nothing
        Me.CollapsiblePanelOs.Location = New System.Drawing.Point(4, 300)
        Me.CollapsiblePanelOs.Margin = New System.Windows.Forms.Padding(1)
        Me.CollapsiblePanelOs.Name = "CollapsiblePanelOs"
        Me.CollapsiblePanelOs.PanelState = Salamander.Windows.Forms.PanelState.Expanded
        Me.CollapsiblePanelOs.Size = New System.Drawing.Size(265, 177)
        Me.CollapsiblePanelOs.StartColour = System.Drawing.Color.White
        Me.CollapsiblePanelOs.TabIndex = 1
        Me.CollapsiblePanelOs.TitleFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CollapsiblePanelOs.TitleFontColour = System.Drawing.Color.Navy
        Me.CollapsiblePanelOs.TitleText = "Systeme Exploitation"
        '
        'tbOsDateInstall
        '
        Me.tbOsDateInstall.BackColor = System.Drawing.SystemColors.Info
        Me.tbOsDateInstall.Location = New System.Drawing.Point(62, 148)
        Me.tbOsDateInstall.Name = "tbOsDateInstall"
        Me.tbOsDateInstall.ReadOnly = True
        Me.tbOsDateInstall.Size = New System.Drawing.Size(184, 20)
        Me.tbOsDateInstall.TabIndex = 13
        '
        'lblOSDateInstall
        '
        Me.lblOSDateInstall.AutoSize = True
        Me.lblOSDateInstall.Location = New System.Drawing.Point(5, 151)
        Me.lblOSDateInstall.Name = "lblOSDateInstall"
        Me.lblOSDateInstall.Size = New System.Drawing.Size(60, 13)
        Me.lblOSDateInstall.TabIndex = 12
        Me.lblOSDateInstall.Text = "Date Install"
        '
        'tbOsArch
        '
        Me.tbOsArch.BackColor = System.Drawing.SystemColors.Info
        Me.tbOsArch.Location = New System.Drawing.Point(62, 123)
        Me.tbOsArch.Name = "tbOsArch"
        Me.tbOsArch.ReadOnly = True
        Me.tbOsArch.Size = New System.Drawing.Size(184, 20)
        Me.tbOsArch.TabIndex = 11
        '
        'lblOsArch
        '
        Me.lblOsArch.AutoSize = True
        Me.lblOsArch.Location = New System.Drawing.Point(5, 126)
        Me.lblOsArch.Name = "lblOsArch"
        Me.lblOsArch.Size = New System.Drawing.Size(52, 13)
        Me.lblOsArch.TabIndex = 10
        Me.lblOsArch.Text = "Architect."
        '
        'CollapsiblePanel2
        '
        Me.CollapsiblePanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CollapsiblePanel2.BackColor = System.Drawing.Color.AliceBlue
        Me.CollapsiblePanel2.EndColour = System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.CollapsiblePanel2.Image = Nothing
        Me.CollapsiblePanel2.Location = New System.Drawing.Point(11, -867)
        Me.CollapsiblePanel2.Name = "CollapsiblePanel2"
        Me.CollapsiblePanel2.PanelState = Salamander.Windows.Forms.PanelState.Expanded
        Me.CollapsiblePanel2.Size = New System.Drawing.Size(248, 100)
        Me.CollapsiblePanel2.StartColour = System.Drawing.Color.White
        Me.CollapsiblePanel2.TabIndex = 5
        Me.CollapsiblePanel2.TitleFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CollapsiblePanel2.TitleFontColour = System.Drawing.Color.Navy
        Me.CollapsiblePanel2.TitleText = "Title"
        '
        'tbUpTime
        '
        Me.tbUpTime.BackColor = System.Drawing.SystemColors.Info
        Me.tbUpTime.Location = New System.Drawing.Point(62, 99)
        Me.tbUpTime.Name = "tbUpTime"
        Me.tbUpTime.ReadOnly = True
        Me.tbUpTime.Size = New System.Drawing.Size(184, 20)
        Me.tbUpTime.TabIndex = 9
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(5, 102)
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
        Me.Label16.Location = New System.Drawing.Point(5, 77)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 13)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "Socle"
        '
        'tbServicePack
        '
        Me.tbServicePack.BackColor = System.Drawing.SystemColors.Info
        Me.tbServicePack.Location = New System.Drawing.Point(62, 50)
        Me.tbServicePack.Name = "tbServicePack"
        Me.tbServicePack.ReadOnly = True
        Me.tbServicePack.Size = New System.Drawing.Size(184, 20)
        Me.tbServicePack.TabIndex = 1
        '
        'tbSocle
        '
        Me.tbSocle.BackColor = System.Drawing.SystemColors.Info
        Me.tbSocle.Location = New System.Drawing.Point(62, 74)
        Me.tbSocle.Name = "tbSocle"
        Me.tbSocle.ReadOnly = True
        Me.tbSocle.Size = New System.Drawing.Size(184, 20)
        Me.tbSocle.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(5, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(21, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "SP"
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
        'PanelMainControls
        '
        Me.PanelMainControls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PanelMainControls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelMainControls.Controls.Add(Me.lblBetaVersion)
        Me.PanelMainControls.Controls.Add(Me.lblOsArchi)
        Me.PanelMainControls.Controls.Add(Me.lblLDAPDeleted)
        Me.PanelMainControls.Controls.Add(Me.lbOfflineMode)
        Me.PanelMainControls.Controls.Add(Me.lblReservIP)
        Me.PanelMainControls.Controls.Add(Me.lblDHCP)
        Me.PanelMainControls.Controls.Add(Me.lblWGA)
        Me.PanelMainControls.Controls.Add(Me.TableLayoutPanel1)
        Me.PanelMainControls.Controls.Add(Me.btEnvVar)
        Me.PanelMainControls.Controls.Add(Me.SplitContainer2)
        Me.PanelMainControls.Controls.Add(Me.btnPrinterInfos)
        Me.PanelMainControls.Controls.Add(Me.cmbStationName)
        Me.PanelMainControls.Controls.Add(Me.GroupBoxResults)
        Me.PanelMainControls.Controls.Add(Me.btnFrmBatch)
        Me.PanelMainControls.Controls.Add(Me.panelLaunchButtons)
        Me.PanelMainControls.Controls.Add(Me.Label1)
        Me.PanelMainControls.Controls.Add(Me.btnlancer)
        Me.PanelMainControls.Controls.Add(Me.GroupBoxDisk)
        Me.PanelMainControls.Controls.Add(Me.GroupBoxPinger)
        Me.PanelMainControls.Controls.Add(Me.MenuStripFrmMain)
        Me.PanelMainControls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMainControls.Location = New System.Drawing.Point(0, 0)
        Me.PanelMainControls.Name = "PanelMainControls"
        Me.PanelMainControls.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PanelMainControls.Size = New System.Drawing.Size(1063, 720)
        Me.PanelMainControls.TabIndex = 48
        '
        'lblBetaVersion
        '
        Me.lblBetaVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBetaVersion.AutoSize = True
        Me.lblBetaVersion.BackColor = System.Drawing.Color.Red
        Me.lblBetaVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBetaVersion.Location = New System.Drawing.Point(719, 6)
        Me.lblBetaVersion.Name = "lblBetaVersion"
        Me.lblBetaVersion.Size = New System.Drawing.Size(88, 15)
        Me.lblBetaVersion.TabIndex = 88
        Me.lblBetaVersion.Text = "VERSION BETA"
        Me.lblBetaVersion.Visible = False
        '
        'lblOsArchi
        '
        Me.lblOsArchi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOsArchi.AutoSize = True
        Me.lblOsArchi.BackColor = System.Drawing.Color.Yellow
        Me.lblOsArchi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOsArchi.Location = New System.Drawing.Point(813, 6)
        Me.lblOsArchi.Name = "lblOsArchi"
        Me.lblOsArchi.Size = New System.Drawing.Size(40, 15)
        Me.lblOsArchi.TabIndex = 87
        Me.lblOsArchi.Text = "64 bits"
        Me.lblOsArchi.Visible = False
        '
        'lblLDAPDeleted
        '
        Me.lblLDAPDeleted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLDAPDeleted.AutoSize = True
        Me.lblLDAPDeleted.BackColor = System.Drawing.Color.Crimson
        Me.lblLDAPDeleted.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLDAPDeleted.Location = New System.Drawing.Point(856, 6)
        Me.lblLDAPDeleted.Name = "lblLDAPDeleted"
        Me.lblLDAPDeleted.Size = New System.Drawing.Size(30, 15)
        Me.lblLDAPDeleted.TabIndex = 86
        Me.lblLDAPDeleted.Text = "DEL"
        Me.lblLDAPDeleted.Visible = False
        '
        'lbOfflineMode
        '
        Me.lbOfflineMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbOfflineMode.AutoSize = True
        Me.lbOfflineMode.BackColor = System.Drawing.Color.Yellow
        Me.lbOfflineMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbOfflineMode.Location = New System.Drawing.Point(890, 6)
        Me.lbOfflineMode.Name = "lbOfflineMode"
        Me.lbOfflineMode.Size = New System.Drawing.Size(39, 15)
        Me.lbOfflineMode.TabIndex = 85
        Me.lbOfflineMode.Text = "Offline"
        Me.lbOfflineMode.Visible = False
        '
        'lblReservIP
        '
        Me.lblReservIP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReservIP.AutoSize = True
        Me.lblReservIP.BackColor = System.Drawing.Color.Orange
        Me.lblReservIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblReservIP.Location = New System.Drawing.Point(977, 6)
        Me.lblReservIP.Name = "lblReservIP"
        Me.lblReservIP.Size = New System.Drawing.Size(41, 15)
        Me.lblReservIP.TabIndex = 84
        Me.lblReservIP.Text = "Res.IP"
        '
        'lblDHCP
        '
        Me.lblDHCP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDHCP.AutoSize = True
        Me.lblDHCP.BackColor = System.Drawing.Color.Orange
        Me.lblDHCP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDHCP.Location = New System.Drawing.Point(935, 6)
        Me.lblDHCP.Name = "lblDHCP"
        Me.lblDHCP.Size = New System.Drawing.Size(39, 15)
        Me.lblDHCP.TabIndex = 83
        Me.lblDHCP.Text = "DHCP"
        '
        'lblWGA
        '
        Me.lblWGA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWGA.AutoSize = True
        Me.lblWGA.BackColor = System.Drawing.Color.Orange
        Me.lblWGA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWGA.Location = New System.Drawing.Point(1021, 6)
        Me.lblWGA.Name = "lblWGA"
        Me.lblWGA.Size = New System.Drawing.Size(35, 15)
        Me.lblWGA.TabIndex = 82
        Me.lblWGA.Text = "WGA"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.CpuGraph, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DiskIOGraph, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FreeMemoryGraph, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.NetworkIOgraph, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNetIO, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDiskIO, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblFreeRam, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCpuUse, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(345, 161)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(708, 66)
        Me.TableLayoutPanel1.TabIndex = 79
        '
        'lblNetIO
        '
        Me.lblNetIO.AutoEllipsis = True
        Me.lblNetIO.AutoSize = True
        Me.lblNetIO.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNetIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNetIO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNetIO.Location = New System.Drawing.Point(357, 51)
        Me.lblNetIO.Name = "lblNetIO"
        Me.lblNetIO.Size = New System.Drawing.Size(171, 15)
        Me.lblNetIO.TabIndex = 77
        Me.lblNetIO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDiskIO
        '
        Me.lblDiskIO.AutoEllipsis = True
        Me.lblDiskIO.AutoSize = True
        Me.lblDiskIO.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblDiskIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDiskIO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDiskIO.Location = New System.Drawing.Point(534, 51)
        Me.lblDiskIO.Name = "lblDiskIO"
        Me.lblDiskIO.Size = New System.Drawing.Size(171, 15)
        Me.lblDiskIO.TabIndex = 78
        Me.lblDiskIO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFreeRam
        '
        Me.lblFreeRam.AutoSize = True
        Me.lblFreeRam.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFreeRam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFreeRam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFreeRam.Location = New System.Drawing.Point(180, 51)
        Me.lblFreeRam.Name = "lblFreeRam"
        Me.lblFreeRam.Size = New System.Drawing.Size(171, 15)
        Me.lblFreeRam.TabIndex = 79
        Me.lblFreeRam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCpuUse
        '
        Me.lblCpuUse.AutoSize = True
        Me.lblCpuUse.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCpuUse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCpuUse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCpuUse.Location = New System.Drawing.Point(3, 51)
        Me.lblCpuUse.Name = "lblCpuUse"
        Me.lblCpuUse.Size = New System.Drawing.Size(171, 15)
        Me.lblCpuUse.TabIndex = 80
        Me.lblCpuUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btEnvVar
        '
        Me.btEnvVar.BackgroundImage = Global.My.Resources.Resources.EnvVar
        Me.btEnvVar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btEnvVar.Enabled = False
        Me.btEnvVar.Location = New System.Drawing.Point(277, 177)
        Me.btEnvVar.Name = "btEnvVar"
        Me.btEnvVar.Size = New System.Drawing.Size(50, 43)
        Me.btEnvVar.TabIndex = 72
        Me.btEnvVar.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 231)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer2.Panel1.Controls.Add(Me.tbControlMain)
        Me.SplitContainer2.Panel1MinSize = 0
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.lvLog)
        Me.SplitContainer2.Panel2MinSize = 0
        Me.SplitContainer2.Size = New System.Drawing.Size(1059, 487)
        Me.SplitContainer2.SplitterDistance = 399
        Me.SplitContainer2.TabIndex = 71
        '
        'tbControlMain
        '
        Me.tbControlMain.Controls.Add(Me.tabProgrammes)
        Me.tbControlMain.Controls.Add(Me.tabProcess)
        Me.tbControlMain.Controls.Add(Me.tabServices)
        Me.tbControlMain.Controls.Add(Me.TabCommentaires)
        Me.tbControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbControlMain.Location = New System.Drawing.Point(0, 0)
        Me.tbControlMain.Name = "tbControlMain"
        Me.tbControlMain.SelectedIndex = 0
        Me.tbControlMain.Size = New System.Drawing.Size(1059, 399)
        Me.tbControlMain.TabIndex = 63
        '
        'tabProgrammes
        '
        Me.tabProgrammes.Controls.Add(Me.SplitContainer1)
        Me.tabProgrammes.Location = New System.Drawing.Point(4, 22)
        Me.tabProgrammes.Name = "tabProgrammes"
        Me.tabProgrammes.Padding = New System.Windows.Forms.Padding(3)
        Me.tabProgrammes.Size = New System.Drawing.Size(1051, 373)
        Me.tabProgrammes.TabIndex = 0
        Me.tabProgrammes.Text = "Programmes"
        Me.tabProgrammes.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ckbHighlistProgDiff)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PanelProgramFilterButtons)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Panel1MinSize = 45
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer4)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Size = New System.Drawing.Size(1045, 367)
        Me.SplitContainer1.TabIndex = 0
        '
        'ckbHighlistProgDiff
        '
        Me.ckbHighlistProgDiff.Appearance = System.Windows.Forms.Appearance.Button
        Me.ckbHighlistProgDiff.AutoSize = True
        Me.ckbHighlistProgDiff.BackgroundImage = Global.My.Resources.Resources.unequal
        Me.ckbHighlistProgDiff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ckbHighlistProgDiff.Location = New System.Drawing.Point(4, 115)
        Me.ckbHighlistProgDiff.MinimumSize = New System.Drawing.Size(36, 36)
        Me.ckbHighlistProgDiff.Name = "ckbHighlistProgDiff"
        Me.ckbHighlistProgDiff.Size = New System.Drawing.Size(36, 36)
        Me.ckbHighlistProgDiff.TabIndex = 60
        Me.ckbHighlistProgDiff.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ckbHighlistProgDiff.UseVisualStyleBackColor = True
        '
        'PanelProgramFilterButtons
        '
        Me.PanelProgramFilterButtons.Controls.Add(Me.ckbFilterHorsSujet)
        Me.PanelProgramFilterButtons.Controls.Add(Me.ckbFilterMicrosoft)
        Me.PanelProgramFilterButtons.Controls.Add(Me.ckbChuFilter)
        Me.PanelProgramFilterButtons.Location = New System.Drawing.Point(0, 0)
        Me.PanelProgramFilterButtons.Name = "PanelProgramFilterButtons"
        Me.PanelProgramFilterButtons.Size = New System.Drawing.Size(44, 113)
        Me.PanelProgramFilterButtons.TabIndex = 59
        '
        'ckbFilterHorsSujet
        '
        Me.ckbFilterHorsSujet.Appearance = System.Windows.Forms.Appearance.Button
        Me.ckbFilterHorsSujet.AutoSize = True
        Me.ckbFilterHorsSujet.BackgroundImage = Global.My.Resources.Resources.help16
        Me.ckbFilterHorsSujet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ckbFilterHorsSujet.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbFilterHorsSujet.Location = New System.Drawing.Point(3, 71)
        Me.ckbFilterHorsSujet.MaximumSize = New System.Drawing.Size(36, 36)
        Me.ckbFilterHorsSujet.MinimumSize = New System.Drawing.Size(36, 36)
        Me.ckbFilterHorsSujet.Name = "ckbFilterHorsSujet"
        Me.ckbFilterHorsSujet.Size = New System.Drawing.Size(36, 36)
        Me.ckbFilterHorsSujet.TabIndex = 45
        Me.ckbFilterHorsSujet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ckbFilterHorsSujet.UseVisualStyleBackColor = True
        '
        'ckbFilterMicrosoft
        '
        Me.ckbFilterMicrosoft.Appearance = System.Windows.Forms.Appearance.Button
        Me.ckbFilterMicrosoft.AutoSize = True
        Me.ckbFilterMicrosoft.BackgroundImage = Global.My.Resources.Resources.operating_system
        Me.ckbFilterMicrosoft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ckbFilterMicrosoft.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbFilterMicrosoft.Location = New System.Drawing.Point(3, 37)
        Me.ckbFilterMicrosoft.MinimumSize = New System.Drawing.Size(36, 36)
        Me.ckbFilterMicrosoft.Name = "ckbFilterMicrosoft"
        Me.ckbFilterMicrosoft.Size = New System.Drawing.Size(36, 36)
        Me.ckbFilterMicrosoft.TabIndex = 36
        Me.ckbFilterMicrosoft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ckbFilterMicrosoft.UseVisualStyleBackColor = True
        '
        'ckbChuFilter
        '
        Me.ckbChuFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckbChuFilter.Appearance = System.Windows.Forms.Appearance.Button
        Me.ckbChuFilter.AutoSize = True
        Me.ckbChuFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ckbChuFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbChuFilter.Location = New System.Drawing.Point(3, 3)
        Me.ckbChuFilter.MaximumSize = New System.Drawing.Size(36, 36)
        Me.ckbChuFilter.MinimumSize = New System.Drawing.Size(36, 36)
        Me.ckbChuFilter.Name = "ckbChuFilter"
        Me.ckbChuFilter.Size = New System.Drawing.Size(36, 36)
        Me.ckbChuFilter.TabIndex = 35
        Me.ckbChuFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ckbChuFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ckbChuFilter.UseVisualStyleBackColor = True
        '
        'SplitContainer4
        '
        Me.SplitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer4.IsSplitterFixed = True
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer4.Panel1.Controls.Add(Me.PanelLegendProgramDiff)
        Me.SplitContainer4.Panel1.Controls.Add(Me.PictureBox1)
        Me.SplitContainer4.Panel1.Controls.Add(Me.tbSearchProgram)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.LvPrograms)
        Me.SplitContainer4.Size = New System.Drawing.Size(991, 367)
        Me.SplitContainer4.SplitterDistance = 34
        Me.SplitContainer4.SplitterWidth = 2
        Me.SplitContainer4.TabIndex = 0
        '
        'PanelLegendProgramDiff
        '
        Me.PanelLegendProgramDiff.Controls.Add(Me.Label41)
        Me.PanelLegendProgramDiff.Controls.Add(Me.Label40)
        Me.PanelLegendProgramDiff.Controls.Add(Me.Label38)
        Me.PanelLegendProgramDiff.Controls.Add(Me.Label39)
        Me.PanelLegendProgramDiff.Location = New System.Drawing.Point(0, 0)
        Me.PanelLegendProgramDiff.Name = "PanelLegendProgramDiff"
        Me.PanelLegendProgramDiff.Size = New System.Drawing.Size(226, 31)
        Me.PanelLegendProgramDiff.TabIndex = 22
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(32, 16)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(184, 13)
        Me.Label41.TabIndex = 23
        Me.Label41.Text = "Version différente lors du dernier scan"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(32, 2)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(190, 13)
        Me.Label40.TabIndex = 22
        Me.Label40.Text = "Programme absent lors du dernier scan"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Red
        Me.Label38.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label38.Location = New System.Drawing.Point(3, 3)
        Me.Label38.Margin = New System.Windows.Forms.Padding(0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(22, 13)
        Me.Label38.TabIndex = 20
        Me.Label38.Text = "     "
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Orange
        Me.Label39.Location = New System.Drawing.Point(3, 17)
        Me.Label39.Margin = New System.Windows.Forms.Padding(0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(22, 13)
        Me.Label39.TabIndex = 21
        Me.Label39.Text = "     "
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.My.Resources.Resources.magnifier
        Me.PictureBox1.Location = New System.Drawing.Point(757, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'tbSearchProgram
        '
        Me.tbSearchProgram.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSearchProgram.Enabled = False
        Me.tbSearchProgram.Location = New System.Drawing.Point(794, 5)
        Me.tbSearchProgram.Name = "tbSearchProgram"
        Me.tbSearchProgram.Size = New System.Drawing.Size(190, 20)
        Me.tbSearchProgram.TabIndex = 16
        '
        'tabProcess
        '
        Me.tabProcess.Controls.Add(Me.LvProcess)
        Me.tabProcess.Location = New System.Drawing.Point(4, 22)
        Me.tabProcess.Name = "tabProcess"
        Me.tabProcess.Padding = New System.Windows.Forms.Padding(3)
        Me.tabProcess.Size = New System.Drawing.Size(1051, 373)
        Me.tabProcess.TabIndex = 1
        Me.tabProcess.Text = "Process"
        Me.tabProcess.UseVisualStyleBackColor = True
        '
        'tabServices
        '
        Me.tabServices.Controls.Add(Me.LvServices)
        Me.tabServices.Location = New System.Drawing.Point(4, 22)
        Me.tabServices.Name = "tabServices"
        Me.tabServices.Padding = New System.Windows.Forms.Padding(3)
        Me.tabServices.Size = New System.Drawing.Size(1051, 373)
        Me.tabServices.TabIndex = 2
        Me.tabServices.Text = "Services"
        Me.tabServices.UseVisualStyleBackColor = True
        '
        'TabCommentaires
        '
        Me.TabCommentaires.Controls.Add(Me.SplitContainerCommentaires)
        Me.TabCommentaires.Controls.Add(Me.PanelSearchcommentaires)
        Me.TabCommentaires.Location = New System.Drawing.Point(4, 22)
        Me.TabCommentaires.Name = "TabCommentaires"
        Me.TabCommentaires.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCommentaires.Size = New System.Drawing.Size(1051, 373)
        Me.TabCommentaires.TabIndex = 3
        Me.TabCommentaires.Text = "Commentaires"
        Me.TabCommentaires.UseVisualStyleBackColor = True
        '
        'SplitContainerCommentaires
        '
        Me.SplitContainerCommentaires.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainerCommentaires.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerCommentaires.Location = New System.Drawing.Point(3, 34)
        Me.SplitContainerCommentaires.Name = "SplitContainerCommentaires"
        Me.SplitContainerCommentaires.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerCommentaires.Panel2
        '
        Me.SplitContainerCommentaires.Panel2.Controls.Add(Me.btnSendCommentaire)
        Me.SplitContainerCommentaires.Panel2.Controls.Add(Me.rtbCommentairesInput)
        Me.SplitContainerCommentaires.Size = New System.Drawing.Size(1045, 336)
        Me.SplitContainerCommentaires.SplitterDistance = 282
        Me.SplitContainerCommentaires.TabIndex = 1
        '
        'btnSendCommentaire
        '
        Me.btnSendCommentaire.BackgroundImage = Global.My.Resources.Resources.ok32
        Me.btnSendCommentaire.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSendCommentaire.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSendCommentaire.Enabled = False
        Me.btnSendCommentaire.Location = New System.Drawing.Point(1019, 0)
        Me.btnSendCommentaire.Name = "btnSendCommentaire"
        Me.btnSendCommentaire.Size = New System.Drawing.Size(24, 48)
        Me.btnSendCommentaire.TabIndex = 1
        Me.btnSendCommentaire.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnSendCommentaire.UseVisualStyleBackColor = True
        '
        'rtbCommentairesInput
        '
        Me.rtbCommentairesInput.AcceptsTab = True
        Me.rtbCommentairesInput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbCommentairesInput.Location = New System.Drawing.Point(0, 0)
        Me.rtbCommentairesInput.Name = "rtbCommentairesInput"
        Me.rtbCommentairesInput.Size = New System.Drawing.Size(1020, 48)
        Me.rtbCommentairesInput.TabIndex = 0
        Me.rtbCommentairesInput.Text = ""
        '
        'lvLog
        '
        Me.lvLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader22})
        Me.lvLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvLog.HideSelection = False
        Me.lvLog.Location = New System.Drawing.Point(0, 0)
        Me.lvLog.Name = "lvLog"
        Me.lvLog.Size = New System.Drawing.Size(1059, 84)
        Me.lvLog.TabIndex = 0
        Me.lvLog.UseCompatibleStateImageBehavior = False
        Me.lvLog.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Width = 1680
        '
        'btnPrinterInfos
        '
        Me.btnPrinterInfos.BackgroundImage = Global.My.Resources.Resources.printerIcon2
        Me.btnPrinterInfos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrinterInfos.Location = New System.Drawing.Point(193, 177)
        Me.btnPrinterInfos.Name = "btnPrinterInfos"
        Me.btnPrinterInfos.Size = New System.Drawing.Size(42, 43)
        Me.btnPrinterInfos.TabIndex = 54
        Me.btnPrinterInfos.UseVisualStyleBackColor = True
        '
        'cmbStationName
        '
        Me.cmbStationName.FormattingEnabled = True
        Me.cmbStationName.Location = New System.Drawing.Point(56, 9)
        Me.cmbStationName.Name = "cmbStationName"
        Me.cmbStationName.Size = New System.Drawing.Size(165, 21)
        Me.cmbStationName.TabIndex = 60
        '
        'GroupBoxResults
        '
        Me.GroupBoxResults.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBoxResults.Controls.Add(Me.btnClearLogs)
        Me.GroupBoxResults.Controls.Add(Me.Label36)
        Me.GroupBoxResults.Controls.Add(Me.tbOfficeErrors)
        Me.GroupBoxResults.Controls.Add(Me.cbLogFilterByDate)
        Me.GroupBoxResults.Controls.Add(Me.lblErrApplication)
        Me.GroupBoxResults.Controls.Add(Me.tbErrApplication)
        Me.GroupBoxResults.Controls.Add(Me.tbNtfsError)
        Me.GroupBoxResults.Controls.Add(Me.Label35)
        Me.GroupBoxResults.Controls.Add(Me.tbftDiskError)
        Me.GroupBoxResults.Controls.Add(Me.Label34)
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
        Me.GroupBoxResults.Controls.Add(Me.btnLogDetails)
        Me.GroupBoxResults.Controls.Add(Me.txtbErrNetwork)
        Me.GroupBoxResults.Controls.Add(Me.txtbErrDisque)
        Me.GroupBoxResults.Location = New System.Drawing.Point(3, 35)
        Me.GroupBoxResults.Name = "GroupBoxResults"
        Me.GroupBoxResults.Size = New System.Drawing.Size(335, 134)
        Me.GroupBoxResults.TabIndex = 52
        Me.GroupBoxResults.TabStop = False
        Me.GroupBoxResults.Text = "Analyse logs"
        '
        'btnClearLogs
        '
        Me.btnClearLogs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearLogs.BackgroundImage = Global.My.Resources.Resources.trash32
        Me.btnClearLogs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnClearLogs.Location = New System.Drawing.Point(307, 38)
        Me.btnClearLogs.Name = "btnClearLogs"
        Me.btnClearLogs.Size = New System.Drawing.Size(25, 30)
        Me.btnClearLogs.TabIndex = 45
        Me.btnClearLogs.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(156, 110)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(61, 13)
        Me.Label36.TabIndex = 44
        Me.Label36.Text = "ERR Office"
        '
        'tbOfficeErrors
        '
        Me.tbOfficeErrors.Location = New System.Drawing.Point(244, 107)
        Me.tbOfficeErrors.Name = "tbOfficeErrors"
        Me.tbOfficeErrors.ReadOnly = True
        Me.tbOfficeErrors.Size = New System.Drawing.Size(57, 20)
        Me.tbOfficeErrors.TabIndex = 43
        '
        'cbLogFilterByDate
        '
        Me.cbLogFilterByDate.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbLogFilterByDate.BackgroundImage = Global.My.Resources.Resources.dateIcon
        Me.cbLogFilterByDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbLogFilterByDate.Enabled = False
        Me.cbLogFilterByDate.Location = New System.Drawing.Point(307, 9)
        Me.cbLogFilterByDate.Name = "cbLogFilterByDate"
        Me.cbLogFilterByDate.Size = New System.Drawing.Size(25, 30)
        Me.cbLogFilterByDate.TabIndex = 42
        Me.cbLogFilterByDate.UseVisualStyleBackColor = True
        '
        'lblErrApplication
        '
        Me.lblErrApplication.AutoSize = True
        Me.lblErrApplication.Location = New System.Drawing.Point(156, 88)
        Me.lblErrApplication.Name = "lblErrApplication"
        Me.lblErrApplication.Size = New System.Drawing.Size(85, 13)
        Me.lblErrApplication.TabIndex = 41
        Me.lblErrApplication.Text = "ERR Application"
        '
        'tbErrApplication
        '
        Me.tbErrApplication.Location = New System.Drawing.Point(244, 85)
        Me.tbErrApplication.Name = "tbErrApplication"
        Me.tbErrApplication.ReadOnly = True
        Me.tbErrApplication.Size = New System.Drawing.Size(57, 20)
        Me.tbErrApplication.TabIndex = 40
        '
        'tbNtfsError
        '
        Me.tbNtfsError.Location = New System.Drawing.Point(95, 107)
        Me.tbNtfsError.Name = "tbNtfsError"
        Me.tbNtfsError.ReadOnly = True
        Me.tbNtfsError.Size = New System.Drawing.Size(57, 20)
        Me.tbNtfsError.TabIndex = 39
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(6, 108)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(70, 13)
        Me.Label35.TabIndex = 38
        Me.Label35.Text = "HDD ntfs Err."
        '
        'tbftDiskError
        '
        Me.tbftDiskError.Location = New System.Drawing.Point(95, 85)
        Me.tbftDiskError.Name = "tbftDiskError"
        Me.tbftDiskError.ReadOnly = True
        Me.tbftDiskError.Size = New System.Drawing.Size(57, 20)
        Me.tbftDiskError.TabIndex = 37
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(6, 87)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(78, 13)
        Me.Label34.TabIndex = 36
        Me.Label34.Text = "HDD ftdisk Err."
        '
        'tbHdFailure
        '
        Me.tbHdFailure.Location = New System.Drawing.Point(95, 63)
        Me.tbHdFailure.Name = "tbHdFailure"
        Me.tbHdFailure.ReadOnly = True
        Me.tbHdFailure.Size = New System.Drawing.Size(57, 20)
        Me.tbHdFailure.TabIndex = 35
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(6, 66)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(76, 13)
        Me.Label29.TabIndex = 34
        Me.Label29.Text = "HDD driver fail"
        '
        'tbErrControleur
        '
        Me.tbErrControleur.Location = New System.Drawing.Point(95, 41)
        Me.tbErrControleur.Name = "tbErrControleur"
        Me.tbErrControleur.ReadOnly = True
        Me.tbErrControleur.Size = New System.Drawing.Size(57, 20)
        Me.tbErrControleur.TabIndex = 33
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 44)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(78, 13)
        Me.Label28.TabIndex = 32
        Me.Label28.Text = "HDD Err Contr."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(157, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "BSOD"
        '
        'txtbBsod
        '
        Me.txtbBsod.Location = New System.Drawing.Point(244, 62)
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
        Me.lblErrNetwork.Location = New System.Drawing.Point(156, 21)
        Me.lblErrNetwork.Name = "lblErrNetwork"
        Me.lblErrNetwork.Size = New System.Drawing.Size(60, 13)
        Me.lblErrNetwork.TabIndex = 20
        Me.lblErrNetwork.Text = "ErrNetwork"
        '
        'lblRebootSauvage
        '
        Me.lblRebootSauvage.AutoSize = True
        Me.lblRebootSauvage.Location = New System.Drawing.Point(156, 42)
        Me.lblRebootSauvage.Name = "lblRebootSauvage"
        Me.lblRebootSauvage.Size = New System.Drawing.Size(88, 13)
        Me.lblRebootSauvage.TabIndex = 21
        Me.lblRebootSauvage.Text = "Reboot Sauvage"
        '
        'txtbErrReboot
        '
        Me.txtbErrReboot.Location = New System.Drawing.Point(244, 40)
        Me.txtbErrReboot.Name = "txtbErrReboot"
        Me.txtbErrReboot.ReadOnly = True
        Me.txtbErrReboot.Size = New System.Drawing.Size(57, 20)
        Me.txtbErrReboot.TabIndex = 17
        '
        'btnLogDetails
        '
        Me.btnLogDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogDetails.BackgroundImage = Global.My.Resources.Resources.magnify32
        Me.btnLogDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLogDetails.Location = New System.Drawing.Point(307, 68)
        Me.btnLogDetails.Name = "btnLogDetails"
        Me.btnLogDetails.Size = New System.Drawing.Size(25, 61)
        Me.btnLogDetails.TabIndex = 26
        Me.btnLogDetails.UseVisualStyleBackColor = True
        '
        'txtbErrNetwork
        '
        Me.txtbErrNetwork.Location = New System.Drawing.Point(244, 18)
        Me.txtbErrNetwork.Name = "txtbErrNetwork"
        Me.txtbErrNetwork.ReadOnly = True
        Me.txtbErrNetwork.Size = New System.Drawing.Size(57, 20)
        Me.txtbErrNetwork.TabIndex = 16
        '
        'txtbErrDisque
        '
        Me.txtbErrDisque.Location = New System.Drawing.Point(95, 19)
        Me.txtbErrDisque.Name = "txtbErrDisque"
        Me.txtbErrDisque.ReadOnly = True
        Me.txtbErrDisque.Size = New System.Drawing.Size(57, 20)
        Me.txtbErrDisque.TabIndex = 15
        '
        'btnFrmBatch
        '
        Me.btnFrmBatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFrmBatch.Location = New System.Drawing.Point(235, 177)
        Me.btnFrmBatch.Name = "btnFrmBatch"
        Me.btnFrmBatch.Size = New System.Drawing.Size(42, 43)
        Me.btnFrmBatch.TabIndex = 55
        Me.btnFrmBatch.Text = "ScanParc"
        Me.btnFrmBatch.UseVisualStyleBackColor = True
        '
        'panelLaunchButtons
        '
        Me.panelLaunchButtons.Controls.Add(Me.btScmRdp)
        Me.panelLaunchButtons.Controls.Add(Me.btComptMgmt)
        Me.panelLaunchButtons.Controls.Add(Me.btnVnc)
        Me.panelLaunchButtons.Controls.Add(Me.btnCleanStation)
        Me.panelLaunchButtons.Location = New System.Drawing.Point(22, 174)
        Me.panelLaunchButtons.Name = "panelLaunchButtons"
        Me.panelLaunchButtons.Size = New System.Drawing.Size(171, 49)
        Me.panelLaunchButtons.TabIndex = 58
        '
        'btScmRdp
        '
        Me.btScmRdp.Enabled = False
        Me.btScmRdp.Image = Global.My.Resources.Resources.network32
        Me.btScmRdp.Location = New System.Drawing.Point(44, 3)
        Me.btScmRdp.Name = "btScmRdp"
        Me.btScmRdp.Size = New System.Drawing.Size(42, 43)
        Me.btScmRdp.TabIndex = 66
        Me.btScmRdp.UseVisualStyleBackColor = True
        '
        'btComptMgmt
        '
        Me.btComptMgmt.Image = Global.My.Resources.Resources.compmgmt
        Me.btComptMgmt.Location = New System.Drawing.Point(128, 3)
        Me.btComptMgmt.Name = "btComptMgmt"
        Me.btComptMgmt.Size = New System.Drawing.Size(42, 43)
        Me.btComptMgmt.TabIndex = 65
        Me.btComptMgmt.UseVisualStyleBackColor = True
        '
        'btnVnc
        '
        Me.btnVnc.Location = New System.Drawing.Point(2, 3)
        Me.btnVnc.Name = "btnVnc"
        Me.btnVnc.Size = New System.Drawing.Size(42, 43)
        Me.btnVnc.TabIndex = 32
        Me.btnVnc.Text = "VNC"
        Me.btnVnc.UseVisualStyleBackColor = True
        '
        'btnCleanStation
        '
        Me.btnCleanStation.Image = Global.My.Resources.Resources.clean
        Me.btnCleanStation.Location = New System.Drawing.Point(86, 3)
        Me.btnCleanStation.Name = "btnCleanStation"
        Me.btnCleanStation.Size = New System.Drawing.Size(42, 43)
        Me.btnCleanStation.TabIndex = 40
        Me.btnCleanStation.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Station :"
        '
        'btnlancer
        '
        Me.btnlancer.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnlancer.BackgroundImage = Global.My.Resources.Resources.control
        Me.btnlancer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnlancer.Location = New System.Drawing.Point(227, 8)
        Me.btnlancer.Name = "btnlancer"
        Me.btnlancer.Size = New System.Drawing.Size(41, 23)
        Me.btnlancer.TabIndex = 48
        Me.btnlancer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlancer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnlancer.UseVisualStyleBackColor = False
        '
        'GroupBoxDisk
        '
        Me.GroupBoxDisk.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxDisk.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBoxDisk.Controls.Add(Me.LvInfoDisk)
        Me.GroupBoxDisk.Location = New System.Drawing.Point(342, 36)
        Me.GroupBoxDisk.Name = "GroupBoxDisk"
        Me.GroupBoxDisk.Size = New System.Drawing.Size(301, 123)
        Me.GroupBoxDisk.TabIndex = 77
        Me.GroupBoxDisk.TabStop = False
        Me.GroupBoxDisk.Text = "Disk"
        '
        'ContextMenuStripDisk
        '
        Me.ContextMenuStripDisk.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OuvrirToolStripMenuItem, Me.SMARTToolStripMenuItem})
        Me.ContextMenuStripDisk.Name = "ContextMenuStrip2"
        Me.ContextMenuStripDisk.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStripDisk.Size = New System.Drawing.Size(108, 48)
        '
        'OuvrirToolStripMenuItem
        '
        Me.OuvrirToolStripMenuItem.Image = Global.My.Resources.Resources.open_folder32
        Me.OuvrirToolStripMenuItem.Name = "OuvrirToolStripMenuItem"
        Me.OuvrirToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.OuvrirToolStripMenuItem.Text = "Ouvrir"
        '
        'SMARTToolStripMenuItem
        '
        Me.SMARTToolStripMenuItem.Image = Global.My.Resources.Resources.hddIcon
        Me.SMARTToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.SMARTToolStripMenuItem.Name = "SMARTToolStripMenuItem"
        Me.SMARTToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.SMARTToolStripMenuItem.Text = "Smart"
        '
        'GroupBoxPinger
        '
        Me.GroupBoxPinger.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxPinger.Controls.Add(Me.btDetailPing)
        Me.GroupBoxPinger.Controls.Add(Me.cbChangeBufferPingSize)
        Me.GroupBoxPinger.Controls.Add(Me.btResetPing)
        Me.GroupBoxPinger.Controls.Add(Me.btCreatePingReport)
        Me.GroupBoxPinger.Controls.Add(Me.Lvping)
        Me.GroupBoxPinger.Controls.Add(Me.tbPingSent)
        Me.GroupBoxPinger.Controls.Add(Me.tbPingLOst)
        Me.GroupBoxPinger.Controls.Add(Me.tbMaxRoundTrip)
        Me.GroupBoxPinger.Controls.Add(Me.tbPercentLost)
        Me.GroupBoxPinger.Controls.Add(Me.tbMinRoundtrip)
        Me.GroupBoxPinger.Controls.Add(Me.tbAvgRoundtrip)
        Me.GroupBoxPinger.Controls.Add(Me.Label17)
        Me.GroupBoxPinger.Controls.Add(Me.Label31)
        Me.GroupBoxPinger.Controls.Add(Me.Label30)
        Me.GroupBoxPinger.Controls.Add(Me.Label32)
        Me.GroupBoxPinger.Controls.Add(Me.Label18)
        Me.GroupBoxPinger.Controls.Add(Me.Label33)
        Me.GroupBoxPinger.Location = New System.Drawing.Point(649, 21)
        Me.GroupBoxPinger.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBoxPinger.Name = "GroupBoxPinger"
        Me.GroupBoxPinger.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBoxPinger.Size = New System.Drawing.Size(409, 138)
        Me.GroupBoxPinger.TabIndex = 78
        Me.GroupBoxPinger.TabStop = False
        Me.GroupBoxPinger.Text = "Ping"
        '
        'btDetailPing
        '
        Me.btDetailPing.BackgroundImage = Global.My.Resources.Resources.magnifier
        Me.btDetailPing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btDetailPing.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btDetailPing.Location = New System.Drawing.Point(4, 12)
        Me.btDetailPing.Name = "btDetailPing"
        Me.btDetailPing.Size = New System.Drawing.Size(43, 17)
        Me.btDetailPing.TabIndex = 75
        Me.btDetailPing.UseVisualStyleBackColor = True
        '
        'cbChangeBufferPingSize
        '
        Me.cbChangeBufferPingSize.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbChangeBufferPingSize.BackgroundImage = Global.My.Resources.Resources.up16
        Me.cbChangeBufferPingSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cbChangeBufferPingSize.Location = New System.Drawing.Point(361, 7)
        Me.cbChangeBufferPingSize.Name = "cbChangeBufferPingSize"
        Me.cbChangeBufferPingSize.Size = New System.Drawing.Size(16, 18)
        Me.cbChangeBufferPingSize.TabIndex = 74
        Me.cbChangeBufferPingSize.UseVisualStyleBackColor = True
        '
        'btResetPing
        '
        Me.btResetPing.BackgroundImage = Global.My.Resources.Resources.refresh16
        Me.btResetPing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btResetPing.Location = New System.Drawing.Point(391, 7)
        Me.btResetPing.Name = "btResetPing"
        Me.btResetPing.Size = New System.Drawing.Size(16, 18)
        Me.btResetPing.TabIndex = 73
        Me.btResetPing.UseVisualStyleBackColor = True
        '
        'btCreatePingReport
        '
        Me.btCreatePingReport.BackgroundImage = Global.My.Resources.Resources.copy16
        Me.btCreatePingReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btCreatePingReport.Location = New System.Drawing.Point(376, 7)
        Me.btCreatePingReport.Name = "btCreatePingReport"
        Me.btCreatePingReport.Size = New System.Drawing.Size(16, 18)
        Me.btCreatePingReport.TabIndex = 72
        Me.btCreatePingReport.UseVisualStyleBackColor = True
        '
        'Lvping
        '
        Me.Lvping.BackColor = System.Drawing.Color.Black
        Me.Lvping.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader17})
        Me.Lvping.ForeColor = System.Drawing.Color.White
        Me.Lvping.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.Lvping.Location = New System.Drawing.Point(48, 7)
        Me.Lvping.Name = "Lvping"
        Me.Lvping.Size = New System.Drawing.Size(313, 129)
        Me.Lvping.TabIndex = 70
        Me.Lvping.UseCompatibleStateImageBehavior = False
        Me.Lvping.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Width = 280
        '
        'tbPingSent
        '
        Me.tbPingSent.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbPingSent.Location = New System.Drawing.Point(4, 45)
        Me.tbPingSent.Name = "tbPingSent"
        Me.tbPingSent.Size = New System.Drawing.Size(44, 20)
        Me.tbPingSent.TabIndex = 66
        '
        'tbPingLOst
        '
        Me.tbPingLOst.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbPingLOst.Location = New System.Drawing.Point(4, 80)
        Me.tbPingLOst.Name = "tbPingLOst"
        Me.tbPingLOst.Size = New System.Drawing.Size(44, 20)
        Me.tbPingLOst.TabIndex = 67
        '
        'tbMaxRoundTrip
        '
        Me.tbMaxRoundTrip.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbMaxRoundTrip.Location = New System.Drawing.Point(361, 48)
        Me.tbMaxRoundTrip.Name = "tbMaxRoundTrip"
        Me.tbMaxRoundTrip.Size = New System.Drawing.Size(45, 20)
        Me.tbMaxRoundTrip.TabIndex = 66
        '
        'tbPercentLost
        '
        Me.tbPercentLost.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbPercentLost.Location = New System.Drawing.Point(4, 115)
        Me.tbPercentLost.Name = "tbPercentLost"
        Me.tbPercentLost.Size = New System.Drawing.Size(44, 20)
        Me.tbPercentLost.TabIndex = 67
        '
        'tbMinRoundtrip
        '
        Me.tbMinRoundtrip.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbMinRoundtrip.Location = New System.Drawing.Point(361, 81)
        Me.tbMinRoundtrip.Name = "tbMinRoundtrip"
        Me.tbMinRoundtrip.Size = New System.Drawing.Size(45, 20)
        Me.tbMinRoundtrip.TabIndex = 67
        '
        'tbAvgRoundtrip
        '
        Me.tbAvgRoundtrip.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbAvgRoundtrip.Location = New System.Drawing.Point(361, 116)
        Me.tbAvgRoundtrip.Name = "tbAvgRoundtrip"
        Me.tbAvgRoundtrip.Size = New System.Drawing.Size(45, 20)
        Me.tbAvgRoundtrip.TabIndex = 67
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(4, 30)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 15)
        Me.Label17.TabIndex = 68
        Me.Label17.Text = "Envoyé"
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label31.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label31.Location = New System.Drawing.Point(361, 32)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(45, 15)
        Me.Label31.TabIndex = 68
        Me.Label31.Text = "Max."
        '
        'Label30
        '
        Me.Label30.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label30.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(4, 100)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(44, 15)
        Me.Label30.TabIndex = 68
        Me.Label30.Text = "% perte"
        '
        'Label32
        '
        Me.Label32.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label32.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label32.Location = New System.Drawing.Point(361, 101)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(45, 15)
        Me.Label32.TabIndex = 68
        Me.Label32.Text = "Moy."
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(4, 65)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 15)
        Me.Label18.TabIndex = 69
        Me.Label18.Text = "Perdu"
        '
        'Label33
        '
        Me.Label33.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label33.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.Location = New System.Drawing.Point(361, 68)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(45, 15)
        Me.Label33.TabIndex = 69
        Me.Label33.Text = "Min."
        '
        'MenuStripFrmMain
        '
        Me.MenuStripFrmMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuOutils, Me.ToolStripMenuAffichage})
        Me.MenuStripFrmMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripFrmMain.Name = "MenuStripFrmMain"
        Me.MenuStripFrmMain.Size = New System.Drawing.Size(1059, 24)
        Me.MenuStripFrmMain.TabIndex = 81
        Me.MenuStripFrmMain.Text = "MenuStrip2"
        Me.MenuStripFrmMain.Visible = False
        '
        'ToolStripMenuOutils
        '
        Me.ToolStripMenuOutils.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VNCQueryConnectToolStripMenuItem, Me.VNCNotificationToolStripMenuItem, Me.SCCMValidationToolStripMenuItem, Me.InfosUtilisateurToolStripMenuItem1, Me.PsExecToolStripMenuItem, Me.RsopToolStripMenuItem, Me.InfosHDDToolStripMenuItem, Me.VerouillerToolStripMenuItem, Me.ScanImprimantesToolStripMenuItem, Me.FlushdnsToolStripMenuItem, Me.OuvrirConsoleCtrlkToolStripMenuItem})
        Me.ToolStripMenuOutils.Name = "ToolStripMenuOutils"
        Me.ToolStripMenuOutils.Size = New System.Drawing.Size(50, 20)
        Me.ToolStripMenuOutils.Text = "Outils"
        '
        'VNCQueryConnectToolStripMenuItem
        '
        Me.VNCQueryConnectToolStripMenuItem.Enabled = False
        Me.VNCQueryConnectToolStripMenuItem.Name = "VNCQueryConnectToolStripMenuItem"
        Me.VNCQueryConnectToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.VNCQueryConnectToolStripMenuItem.Text = "VNC Query Connect"
        '
        'VNCNotificationToolStripMenuItem
        '
        Me.VNCNotificationToolStripMenuItem.Name = "VNCNotificationToolStripMenuItem"
        Me.VNCNotificationToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.VNCNotificationToolStripMenuItem.Text = "VNC Notification"
        '
        'SCCMValidationToolStripMenuItem
        '
        Me.SCCMValidationToolStripMenuItem.Image = CType(resources.GetObject("SCCMValidationToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SCCMValidationToolStripMenuItem.Name = "SCCMValidationToolStripMenuItem"
        Me.SCCMValidationToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.SCCMValidationToolStripMenuItem.Text = "SCCM validation"
        '
        'InfosUtilisateurToolStripMenuItem1
        '
        Me.InfosUtilisateurToolStripMenuItem1.Image = Global.My.Resources.Resources.information_frame
        Me.InfosUtilisateurToolStripMenuItem1.Name = "InfosUtilisateurToolStripMenuItem1"
        Me.InfosUtilisateurToolStripMenuItem1.Size = New System.Drawing.Size(192, 22)
        Me.InfosUtilisateurToolStripMenuItem1.Text = "Infos utilisateur"
        '
        'PsExecToolStripMenuItem
        '
        Me.PsExecToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DefragToolStripMenuItem, Me.DefragAnalyseToolStripMenuItem, Me.ArreterToolStripMenuItem, Me.ArreterForcerToolStripMenuItem, Me.RedémarrerToolStripMenuItem, Me.RedémarrerForcerToolStripMenuItem, Me.ChkdskFToolStripMenuItem, Me.ChkdskFRToolStripMenuItem, Me.ConsoleToolStripMenuItem})
        Me.PsExecToolStripMenuItem.Enabled = False
        Me.PsExecToolStripMenuItem.Name = "PsExecToolStripMenuItem"
        Me.PsExecToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.PsExecToolStripMenuItem.Text = "PsExec"
        '
        'DefragToolStripMenuItem
        '
        Me.DefragToolStripMenuItem.Name = "DefragToolStripMenuItem"
        Me.DefragToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.DefragToolStripMenuItem.Text = "Defrag"
        '
        'DefragAnalyseToolStripMenuItem
        '
        Me.DefragAnalyseToolStripMenuItem.Name = "DefragAnalyseToolStripMenuItem"
        Me.DefragAnalyseToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.DefragAnalyseToolStripMenuItem.Text = "Defrag (Analyse)"
        '
        'ArreterToolStripMenuItem
        '
        Me.ArreterToolStripMenuItem.Image = Global.My.Resources.Resources.shutdown
        Me.ArreterToolStripMenuItem.Name = "ArreterToolStripMenuItem"
        Me.ArreterToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.ArreterToolStripMenuItem.Text = "Arrêter"
        '
        'ArreterForcerToolStripMenuItem
        '
        Me.ArreterForcerToolStripMenuItem.Image = Global.My.Resources.Resources.shutdown
        Me.ArreterForcerToolStripMenuItem.Name = "ArreterForcerToolStripMenuItem"
        Me.ArreterForcerToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.ArreterForcerToolStripMenuItem.Text = "Arrêter (Forcer)"
        '
        'RedémarrerToolStripMenuItem
        '
        Me.RedémarrerToolStripMenuItem.Image = Global.My.Resources.Resources.reboot
        Me.RedémarrerToolStripMenuItem.Name = "RedémarrerToolStripMenuItem"
        Me.RedémarrerToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.RedémarrerToolStripMenuItem.Text = "Redémarrer"
        '
        'RedémarrerForcerToolStripMenuItem
        '
        Me.RedémarrerForcerToolStripMenuItem.Image = Global.My.Resources.Resources.reboot
        Me.RedémarrerForcerToolStripMenuItem.Name = "RedémarrerForcerToolStripMenuItem"
        Me.RedémarrerForcerToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.RedémarrerForcerToolStripMenuItem.Text = "Redémarrer (Forcer)"
        '
        'ChkdskFToolStripMenuItem
        '
        Me.ChkdskFToolStripMenuItem.Name = "ChkdskFToolStripMenuItem"
        Me.ChkdskFToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.ChkdskFToolStripMenuItem.Text = "Chkdsk /F"
        '
        'ChkdskFRToolStripMenuItem
        '
        Me.ChkdskFRToolStripMenuItem.Name = "ChkdskFRToolStripMenuItem"
        Me.ChkdskFRToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.ChkdskFRToolStripMenuItem.Text = "Chkdsk /F /R"
        '
        'ConsoleToolStripMenuItem
        '
        Me.ConsoleToolStripMenuItem.Image = Global.My.Resources.Resources.Console_mdk
        Me.ConsoleToolStripMenuItem.Name = "ConsoleToolStripMenuItem"
        Me.ConsoleToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.K), System.Windows.Forms.Keys)
        Me.ConsoleToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.ConsoleToolStripMenuItem.Text = "Console distante"
        '
        'RsopToolStripMenuItem
        '
        Me.RsopToolStripMenuItem.Enabled = False
        Me.RsopToolStripMenuItem.Name = "RsopToolStripMenuItem"
        Me.RsopToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.RsopToolStripMenuItem.Text = "Rsop"
        '
        'InfosHDDToolStripMenuItem
        '
        Me.InfosHDDToolStripMenuItem.Enabled = False
        Me.InfosHDDToolStripMenuItem.Image = Global.My.Resources.Resources.harddisk
        Me.InfosHDDToolStripMenuItem.Name = "InfosHDDToolStripMenuItem"
        Me.InfosHDDToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.InfosHDDToolStripMenuItem.Text = "Infos HDD"
        '
        'VerouillerToolStripMenuItem
        '
        Me.VerouillerToolStripMenuItem.Name = "VerouillerToolStripMenuItem"
        Me.VerouillerToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.VerouillerToolStripMenuItem.Text = "Verouiller"
        Me.VerouillerToolStripMenuItem.Visible = False
        '
        'ScanImprimantesToolStripMenuItem
        '
        Me.ScanImprimantesToolStripMenuItem.Image = Global.My.Resources.Resources.icone_imprimante
        Me.ScanImprimantesToolStripMenuItem.Name = "ScanImprimantesToolStripMenuItem"
        Me.ScanImprimantesToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ScanImprimantesToolStripMenuItem.Text = "Scan Imprimantes"
        '
        'FlushdnsToolStripMenuItem
        '
        Me.FlushdnsToolStripMenuItem.Name = "FlushdnsToolStripMenuItem"
        Me.FlushdnsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.FlushdnsToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.FlushdnsToolStripMenuItem.Text = "Flushdns"
        '
        'OuvrirConsoleCtrlkToolStripMenuItem
        '
        Me.OuvrirConsoleCtrlkToolStripMenuItem.Image = Global.My.Resources.Resources.EnvVar
        Me.OuvrirConsoleCtrlkToolStripMenuItem.Name = "OuvrirConsoleCtrlkToolStripMenuItem"
        Me.OuvrirConsoleCtrlkToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.K), System.Windows.Forms.Keys)
        Me.OuvrirConsoleCtrlkToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.OuvrirConsoleCtrlkToolStripMenuItem.Text = "Ouvrir console"
        '
        'ToolStripMenuAffichage
        '
        Me.ToolStripMenuAffichage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemPanneauLateral, Me.ToolStripMenuItemLogs, Me.NouvelOngletToolStripMenuItem1, Me.FermerOngletToolStripMenuItem})
        Me.ToolStripMenuAffichage.Name = "ToolStripMenuAffichage"
        Me.ToolStripMenuAffichage.Size = New System.Drawing.Size(70, 20)
        Me.ToolStripMenuAffichage.Text = "Affichage"
        '
        'ToolStripMenuItemPanneauLateral
        '
        Me.ToolStripMenuItemPanneauLateral.Checked = True
        Me.ToolStripMenuItemPanneauLateral.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenuItemPanneauLateral.Name = "ToolStripMenuItemPanneauLateral"
        Me.ToolStripMenuItemPanneauLateral.Size = New System.Drawing.Size(193, 22)
        Me.ToolStripMenuItemPanneauLateral.Text = "Panneau latéral"
        '
        'ToolStripMenuItemLogs
        '
        Me.ToolStripMenuItemLogs.Checked = True
        Me.ToolStripMenuItemLogs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenuItemLogs.Name = "ToolStripMenuItemLogs"
        Me.ToolStripMenuItemLogs.Size = New System.Drawing.Size(193, 22)
        Me.ToolStripMenuItemLogs.Text = "Logs"
        '
        'NouvelOngletToolStripMenuItem1
        '
        Me.NouvelOngletToolStripMenuItem1.Name = "NouvelOngletToolStripMenuItem1"
        Me.NouvelOngletToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.NouvelOngletToolStripMenuItem1.Size = New System.Drawing.Size(193, 22)
        Me.NouvelOngletToolStripMenuItem1.Text = "Nouvel onglet"
        '
        'FermerOngletToolStripMenuItem
        '
        Me.FermerOngletToolStripMenuItem.Name = "FermerOngletToolStripMenuItem"
        Me.FermerOngletToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.FermerOngletToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.FermerOngletToolStripMenuItem.Text = "Fermer onglet"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.PanelMainControls)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.FlowLayoutPanelCollapsiblePanels)
        Me.SplitContainer3.Size = New System.Drawing.Size(1356, 720)
        Me.SplitContainer3.SplitterDistance = 1063
        Me.SplitContainer3.TabIndex = 49
        '
        'FlowLayoutPanelCollapsiblePanels
        '
        Me.FlowLayoutPanelCollapsiblePanels.AutoScroll = True
        Me.FlowLayoutPanelCollapsiblePanels.BackColor = System.Drawing.Color.CornflowerBlue
        Me.FlowLayoutPanelCollapsiblePanels.Controls.Add(Me.collapsiblePanelOrdinateur)
        Me.FlowLayoutPanelCollapsiblePanels.Controls.Add(Me.CollapsiblePanelOs)
        Me.FlowLayoutPanelCollapsiblePanels.Controls.Add(Me.CollapsiblePanelActiveDirectory)
        Me.FlowLayoutPanelCollapsiblePanels.Controls.Add(Me.CollapsiblePanelNetwork)
        Me.FlowLayoutPanelCollapsiblePanels.Controls.Add(Me.CollapsiblePanelDisplay)
        Me.FlowLayoutPanelCollapsiblePanels.Controls.Add(Me.CollapsiblePanelVideoController)
        Me.FlowLayoutPanelCollapsiblePanels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanelCollapsiblePanels.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanelCollapsiblePanels.Name = "FlowLayoutPanelCollapsiblePanels"
        Me.FlowLayoutPanelCollapsiblePanels.Padding = New System.Windows.Forms.Padding(3)
        Me.FlowLayoutPanelCollapsiblePanels.Size = New System.Drawing.Size(289, 720)
        Me.FlowLayoutPanelCollapsiblePanels.TabIndex = 0
        '
        'collapsiblePanelOrdinateur
        '
        Me.collapsiblePanelOrdinateur.AutoScrollMargin = New System.Drawing.Size(5, 5)
        Me.collapsiblePanelOrdinateur.BackColor = System.Drawing.Color.Lavender
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.btUserInfos)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.Label3)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.tbDomaine)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.Label8)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.Label4)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.tbModele)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.tbSerialNumber)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.tbFreeMemory)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.Label5)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.Label13)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.tbMaxFrequency)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.tbHostname)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.Label6)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.tbMemoireTotale)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.Label7)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.Label12)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.tbNbCpu)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.Label11)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.tbProcessor)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.tbCurrentUser)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.Label10)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.tbConstructeur)
        Me.collapsiblePanelOrdinateur.Controls.Add(Me.Label9)
        Me.collapsiblePanelOrdinateur.EndColour = System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.collapsiblePanelOrdinateur.Image = Nothing
        Me.collapsiblePanelOrdinateur.Location = New System.Drawing.Point(4, 4)
        Me.collapsiblePanelOrdinateur.Margin = New System.Windows.Forms.Padding(1)
        Me.collapsiblePanelOrdinateur.Name = "collapsiblePanelOrdinateur"
        Me.collapsiblePanelOrdinateur.PanelState = Salamander.Windows.Forms.PanelState.Expanded
        Me.collapsiblePanelOrdinateur.Size = New System.Drawing.Size(265, 294)
        Me.collapsiblePanelOrdinateur.StartColour = System.Drawing.Color.White
        Me.collapsiblePanelOrdinateur.TabIndex = 0
        Me.collapsiblePanelOrdinateur.TitleFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.collapsiblePanelOrdinateur.TitleFontColour = System.Drawing.Color.Navy
        Me.collapsiblePanelOrdinateur.TitleText = "Ordinateur"
        '
        'btUserInfos
        '
        Me.btUserInfos.BackgroundImage = Global.My.Resources.Resources.information_frame
        Me.btUserInfos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btUserInfos.Location = New System.Drawing.Point(226, 164)
        Me.btUserInfos.Name = "btUserInfos"
        Me.btUserInfos.Size = New System.Drawing.Size(23, 23)
        Me.btUserInfos.TabIndex = 30
        Me.btUserInfos.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 241)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Domaine"
        '
        'tbDomaine
        '
        Me.tbDomaine.BackColor = System.Drawing.SystemColors.Info
        Me.tbDomaine.Location = New System.Drawing.Point(96, 235)
        Me.tbDomaine.Name = "tbDomaine"
        Me.tbDomaine.ReadOnly = True
        Me.tbDomaine.Size = New System.Drawing.Size(150, 20)
        Me.tbDomaine.TabIndex = 3
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
        Me.Label4.Location = New System.Drawing.Point(3, 121)
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
        Me.tbSerialNumber.Location = New System.Drawing.Point(96, 120)
        Me.tbSerialNumber.Name = "tbSerialNumber"
        Me.tbSerialNumber.ReadOnly = True
        Me.tbSerialNumber.Size = New System.Drawing.Size(150, 20)
        Me.tbSerialNumber.TabIndex = 28
        '
        'tbFreeMemory
        '
        Me.tbFreeMemory.BackColor = System.Drawing.SystemColors.Info
        Me.tbFreeMemory.Location = New System.Drawing.Point(96, 212)
        Me.tbFreeMemory.Name = "tbFreeMemory"
        Me.tbFreeMemory.ReadOnly = True
        Me.tbFreeMemory.Size = New System.Drawing.Size(150, 20)
        Me.tbFreeMemory.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Frequence Max"
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
        'tbMaxFrequency
        '
        Me.tbMaxFrequency.BackColor = System.Drawing.SystemColors.Info
        Me.tbMaxFrequency.Location = New System.Drawing.Point(96, 189)
        Me.tbMaxFrequency.Name = "tbMaxFrequency"
        Me.tbMaxFrequency.ReadOnly = True
        Me.tbMaxFrequency.Size = New System.Drawing.Size(150, 20)
        Me.tbMaxFrequency.TabIndex = 26
        '
        'tbHostname
        '
        Me.tbHostname.BackColor = System.Drawing.SystemColors.Info
        Me.tbHostname.Location = New System.Drawing.Point(96, 143)
        Me.tbHostname.Name = "tbHostname"
        Me.tbHostname.ReadOnly = True
        Me.tbHostname.Size = New System.Drawing.Size(150, 20)
        Me.tbHostname.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Processeur"
        '
        'tbMemoireTotale
        '
        Me.tbMemoireTotale.BackColor = System.Drawing.SystemColors.Info
        Me.tbMemoireTotale.Location = New System.Drawing.Point(96, 97)
        Me.tbMemoireTotale.Name = "tbMemoireTotale"
        Me.tbMemoireTotale.ReadOnly = True
        Me.tbMemoireTotale.Size = New System.Drawing.Size(150, 20)
        Me.tbMemoireTotale.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 265)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Nb.Phys CPU"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 217)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Memoire libre"
        '
        'tbNbCpu
        '
        Me.tbNbCpu.BackColor = System.Drawing.SystemColors.Info
        Me.tbNbCpu.Location = New System.Drawing.Point(96, 258)
        Me.tbNbCpu.Name = "tbNbCpu"
        Me.tbNbCpu.ReadOnly = True
        Me.tbNbCpu.Size = New System.Drawing.Size(150, 20)
        Me.tbNbCpu.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Memoire installée"
        '
        'tbProcessor
        '
        Me.tbProcessor.BackColor = System.Drawing.SystemColors.Info
        Me.tbProcessor.Location = New System.Drawing.Point(96, 74)
        Me.tbProcessor.Name = "tbProcessor"
        Me.tbProcessor.ReadOnly = True
        Me.tbProcessor.Size = New System.Drawing.Size(150, 20)
        Me.tbProcessor.TabIndex = 24
        '
        'tbCurrentUser
        '
        Me.tbCurrentUser.BackColor = System.Drawing.SystemColors.Info
        Me.tbCurrentUser.Location = New System.Drawing.Point(96, 166)
        Me.tbCurrentUser.Name = "tbCurrentUser"
        Me.tbCurrentUser.ReadOnly = True
        Me.tbCurrentUser.Size = New System.Drawing.Size(129, 20)
        Me.tbCurrentUser.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 169)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Session en cours"
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
        Me.Label9.Location = New System.Drawing.Point(3, 145)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Nom Machine"
        '
        'CollapsiblePanelActiveDirectory
        '
        Me.CollapsiblePanelActiveDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CollapsiblePanelActiveDirectory.BackColor = System.Drawing.Color.Lavender
        Me.CollapsiblePanelActiveDirectory.Controls.Add(Me.lblADComputerLastLogonTS)
        Me.CollapsiblePanelActiveDirectory.Controls.Add(Me.tbADcomputerLastLogonTS)
        Me.CollapsiblePanelActiveDirectory.Controls.Add(Me.lblADComputerDN)
        Me.CollapsiblePanelActiveDirectory.Controls.Add(Me.tbADcomputerDN)
        Me.CollapsiblePanelActiveDirectory.Controls.Add(Me.lblADComputerSercicePack)
        Me.CollapsiblePanelActiveDirectory.Controls.Add(Me.tbADComputerServicePack)
        Me.CollapsiblePanelActiveDirectory.Controls.Add(Me.lblADComputerOS)
        Me.CollapsiblePanelActiveDirectory.Controls.Add(Me.tbADcomputerOS)
        Me.CollapsiblePanelActiveDirectory.Controls.Add(Me.lblADComputerCreationDate)
        Me.CollapsiblePanelActiveDirectory.Controls.Add(Me.tbADComputerCreationDate)
        Me.CollapsiblePanelActiveDirectory.EndColour = System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.CollapsiblePanelActiveDirectory.Image = Nothing
        Me.CollapsiblePanelActiveDirectory.Location = New System.Drawing.Point(4, 479)
        Me.CollapsiblePanelActiveDirectory.Margin = New System.Windows.Forms.Padding(1)
        Me.CollapsiblePanelActiveDirectory.Name = "CollapsiblePanelActiveDirectory"
        Me.CollapsiblePanelActiveDirectory.PanelState = Salamander.Windows.Forms.PanelState.Expanded
        Me.CollapsiblePanelActiveDirectory.Size = New System.Drawing.Size(265, 150)
        Me.CollapsiblePanelActiveDirectory.StartColour = System.Drawing.Color.White
        Me.CollapsiblePanelActiveDirectory.TabIndex = 5
        Me.CollapsiblePanelActiveDirectory.TitleFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CollapsiblePanelActiveDirectory.TitleFontColour = System.Drawing.Color.Navy
        Me.CollapsiblePanelActiveDirectory.TitleText = "LDAP Computer"
        '
        'lblADComputerLastLogonTS
        '
        Me.lblADComputerLastLogonTS.AutoSize = True
        Me.lblADComputerLastLogonTS.Location = New System.Drawing.Point(7, 123)
        Me.lblADComputerLastLogonTS.Name = "lblADComputerLastLogonTS"
        Me.lblADComputerLastLogonTS.Size = New System.Drawing.Size(77, 13)
        Me.lblADComputerLastLogonTS.TabIndex = 10
        Me.lblADComputerLastLogonTS.Text = "Last Logon TS"
        '
        'tbADcomputerLastLogonTS
        '
        Me.tbADcomputerLastLogonTS.BackColor = System.Drawing.SystemColors.Info
        Me.tbADcomputerLastLogonTS.Location = New System.Drawing.Point(97, 120)
        Me.tbADcomputerLastLogonTS.Name = "tbADcomputerLastLogonTS"
        Me.tbADcomputerLastLogonTS.ReadOnly = True
        Me.tbADcomputerLastLogonTS.Size = New System.Drawing.Size(150, 20)
        Me.tbADcomputerLastLogonTS.TabIndex = 11
        '
        'lblADComputerDN
        '
        Me.lblADComputerDN.AutoSize = True
        Me.lblADComputerDN.Location = New System.Drawing.Point(7, 99)
        Me.lblADComputerDN.Name = "lblADComputerDN"
        Me.lblADComputerDN.Size = New System.Drawing.Size(23, 13)
        Me.lblADComputerDN.TabIndex = 8
        Me.lblADComputerDN.Text = "DN"
        '
        'tbADcomputerDN
        '
        Me.tbADcomputerDN.BackColor = System.Drawing.SystemColors.Info
        Me.tbADcomputerDN.Location = New System.Drawing.Point(97, 96)
        Me.tbADcomputerDN.Name = "tbADcomputerDN"
        Me.tbADcomputerDN.ReadOnly = True
        Me.tbADcomputerDN.Size = New System.Drawing.Size(150, 20)
        Me.tbADcomputerDN.TabIndex = 9
        '
        'lblADComputerSercicePack
        '
        Me.lblADComputerSercicePack.AutoSize = True
        Me.lblADComputerSercicePack.Location = New System.Drawing.Point(7, 76)
        Me.lblADComputerSercicePack.Name = "lblADComputerSercicePack"
        Me.lblADComputerSercicePack.Size = New System.Drawing.Size(71, 13)
        Me.lblADComputerSercicePack.TabIndex = 6
        Me.lblADComputerSercicePack.Text = "Sercice Pack"
        '
        'tbADComputerServicePack
        '
        Me.tbADComputerServicePack.BackColor = System.Drawing.SystemColors.Info
        Me.tbADComputerServicePack.Location = New System.Drawing.Point(97, 73)
        Me.tbADComputerServicePack.Name = "tbADComputerServicePack"
        Me.tbADComputerServicePack.ReadOnly = True
        Me.tbADComputerServicePack.Size = New System.Drawing.Size(150, 20)
        Me.tbADComputerServicePack.TabIndex = 7
        '
        'lblADComputerOS
        '
        Me.lblADComputerOS.AutoSize = True
        Me.lblADComputerOS.Location = New System.Drawing.Point(7, 54)
        Me.lblADComputerOS.Name = "lblADComputerOS"
        Me.lblADComputerOS.Size = New System.Drawing.Size(22, 13)
        Me.lblADComputerOS.TabIndex = 4
        Me.lblADComputerOS.Text = "OS"
        '
        'tbADcomputerOS
        '
        Me.tbADcomputerOS.BackColor = System.Drawing.SystemColors.Info
        Me.tbADcomputerOS.Location = New System.Drawing.Point(97, 51)
        Me.tbADcomputerOS.Name = "tbADcomputerOS"
        Me.tbADcomputerOS.ReadOnly = True
        Me.tbADcomputerOS.Size = New System.Drawing.Size(150, 20)
        Me.tbADcomputerOS.TabIndex = 5
        '
        'lblADComputerCreationDate
        '
        Me.lblADComputerCreationDate.AutoSize = True
        Me.lblADComputerCreationDate.Location = New System.Drawing.Point(7, 32)
        Me.lblADComputerCreationDate.Name = "lblADComputerCreationDate"
        Me.lblADComputerCreationDate.Size = New System.Drawing.Size(72, 13)
        Me.lblADComputerCreationDate.TabIndex = 2
        Me.lblADComputerCreationDate.Text = "Date Création"
        '
        'tbADComputerCreationDate
        '
        Me.tbADComputerCreationDate.BackColor = System.Drawing.SystemColors.Info
        Me.tbADComputerCreationDate.Location = New System.Drawing.Point(97, 29)
        Me.tbADComputerCreationDate.Name = "tbADComputerCreationDate"
        Me.tbADComputerCreationDate.ReadOnly = True
        Me.tbADComputerCreationDate.Size = New System.Drawing.Size(150, 20)
        Me.tbADComputerCreationDate.TabIndex = 3
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Util. Memoire (Ko)"
        Me.ColumnHeader21.Width = 91
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Priorite"
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "Parent Process"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.MenuBar
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.OptionsToolStripMenuItem, Me.FavorisToolStripMenuItem, Me.ToolStripMenuItem3, Me.ToolStripMenuItem2})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(267, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CpuGraph
        '
        Me.CpuGraph.BackColor = System.Drawing.Color.Black
        Me.CpuGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CpuGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CpuGraph.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.CpuGraph.Location = New System.Drawing.Point(3, 3)
        Me.CpuGraph.Name = "CpuGraph"
        Me.CpuGraph.retryCount = 0
        Me.CpuGraph.Size = New System.Drawing.Size(171, 45)
        Me.CpuGraph.TabIndex = 73
        Me.CpuGraph.title = "CPU"
        '
        'DiskIOGraph
        '
        Me.DiskIOGraph.BackColor = System.Drawing.Color.Black
        Me.DiskIOGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DiskIOGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DiskIOGraph.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.DiskIOGraph.Location = New System.Drawing.Point(534, 3)
        Me.DiskIOGraph.Name = "DiskIOGraph"
        Me.DiskIOGraph.retryCount = 0
        Me.DiskIOGraph.Size = New System.Drawing.Size(171, 45)
        Me.DiskIOGraph.TabIndex = 76
        Me.DiskIOGraph.title = "DiskIO"
        '
        'FreeMemoryGraph
        '
        Me.FreeMemoryGraph.BackColor = System.Drawing.Color.Black
        Me.FreeMemoryGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.FreeMemoryGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FreeMemoryGraph.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.FreeMemoryGraph.Location = New System.Drawing.Point(180, 3)
        Me.FreeMemoryGraph.Name = "FreeMemoryGraph"
        Me.FreeMemoryGraph.retryCount = 0
        Me.FreeMemoryGraph.Size = New System.Drawing.Size(171, 45)
        Me.FreeMemoryGraph.TabIndex = 74
        Me.FreeMemoryGraph.title = "Ram"
        '
        'NetworkIOgraph
        '
        Me.NetworkIOgraph.BackColor = System.Drawing.Color.Black
        Me.NetworkIOgraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.NetworkIOgraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NetworkIOgraph.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.NetworkIOgraph.Location = New System.Drawing.Point(357, 3)
        Me.NetworkIOgraph.Name = "NetworkIOgraph"
        Me.NetworkIOgraph.retryCount = 0
        Me.NetworkIOgraph.Size = New System.Drawing.Size(171, 45)
        Me.NetworkIOgraph.TabIndex = 75
        Me.NetworkIOgraph.title = "NetIO"
        '
        'LvPrograms
        '
        Me.LvPrograms.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader16, Me.ColumnHeader18, Me.ColumnHeader19})
        Me.LvPrograms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvPrograms.FullRowSelect = True
        Me.LvPrograms.Location = New System.Drawing.Point(0, 0)
        Me.LvPrograms.Name = "LvPrograms"
        Me.LvPrograms.Size = New System.Drawing.Size(987, 327)
        Me.LvPrograms.TabIndex = 62
        Me.LvPrograms.UseCompatibleStateImageBehavior = False
        Me.LvPrograms.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Program"
        Me.ColumnHeader3.Width = 360
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Version"
        Me.ColumnHeader4.Width = 80
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Publisher"
        Me.ColumnHeader16.Width = 220
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Date Install."
        Me.ColumnHeader18.Width = 96
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Uninstall String"
        Me.ColumnHeader19.Width = 280
        '
        'LvProcess
        '
        Me.LvProcess.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader25, Me.ColumnHeader26, Me.ColumnHeader27})
        Me.LvProcess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvProcess.FullRowSelect = True
        Me.LvProcess.Location = New System.Drawing.Point(3, 3)
        Me.LvProcess.Name = "LvProcess"
        Me.LvProcess.Size = New System.Drawing.Size(1045, 367)
        Me.LvProcess.TabIndex = 3
        Me.LvProcess.UseCompatibleStateImageBehavior = False
        Me.LvProcess.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Name"
        Me.ColumnHeader7.Width = 148
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "PID"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "TotalCpu"
        Me.ColumnHeader2.Width = 75
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Threads"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Page Faults"
        Me.ColumnHeader6.Width = 74
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Path"
        Me.ColumnHeader13.Width = 183
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Username"
        Me.ColumnHeader14.Width = 147
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Cpu"
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "Util. Memoire (Ko)"
        Me.ColumnHeader25.Width = 122
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "Priorite"
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "Parent Process"
        '
        'LvServices
        '
        Me.LvServices.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderNom, Me.ColumnHeaderDescription, Me.ColumnHeaderStatus, Me.ColumnHeaderDemarrage, Me.ColumnHeaderCompte, Me.ColumnHeaderPath, Me.ColumnHeaderServiceType, Me.ColumnHeaderProcessPID})
        Me.LvServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvServices.FullRowSelect = True
        Me.LvServices.Location = New System.Drawing.Point(3, 3)
        Me.LvServices.MultiSelect = False
        Me.LvServices.Name = "LvServices"
        Me.LvServices.Size = New System.Drawing.Size(1045, 367)
        Me.LvServices.TabIndex = 0
        Me.LvServices.UseCompatibleStateImageBehavior = False
        Me.LvServices.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderNom
        '
        Me.ColumnHeaderNom.Text = "Nom"
        Me.ColumnHeaderNom.Width = 255
        '
        'ColumnHeaderDescription
        '
        Me.ColumnHeaderDescription.Text = "Description"
        Me.ColumnHeaderDescription.Width = 262
        '
        'ColumnHeaderStatus
        '
        Me.ColumnHeaderStatus.Text = "Status"
        '
        'ColumnHeaderDemarrage
        '
        Me.ColumnHeaderDemarrage.Text = "Demarrage"
        Me.ColumnHeaderDemarrage.Width = 75
        '
        'ColumnHeaderCompte
        '
        Me.ColumnHeaderCompte.Text = "Compte"
        Me.ColumnHeaderCompte.Width = 138
        '
        'ColumnHeaderPath
        '
        Me.ColumnHeaderPath.Text = "Path"
        '
        'ColumnHeaderServiceType
        '
        Me.ColumnHeaderServiceType.Text = "Type"
        '
        'ColumnHeaderProcessPID
        '
        Me.ColumnHeaderProcessPID.Text = "ProcessPID"
        Me.ColumnHeaderProcessPID.Width = 73
        '
        'PanelSearchcommentaires
        '
        Me.PanelSearchcommentaires.BackColor = System.Drawing.Color.Lavender
        Me.PanelSearchcommentaires.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelSearchcommentaires.Controls.Add(Me.btLastComments)
        Me.PanelSearchcommentaires.Controls.Add(Me.cbAssocierStation)
        Me.PanelSearchcommentaires.Controls.Add(Me.PanelSearchCommentaire)
        Me.PanelSearchcommentaires.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSearchcommentaires.Location = New System.Drawing.Point(3, 3)
        Me.PanelSearchcommentaires.Name = "PanelSearchcommentaires"
        Me.PanelSearchcommentaires.Size = New System.Drawing.Size(1045, 31)
        Me.PanelSearchcommentaires.TabIndex = 0
        '
        'btLastComments
        '
        Me.btLastComments.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btLastComments.BackgroundImage = Global.My.Resources.Resources.unread
        Me.btLastComments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btLastComments.Location = New System.Drawing.Point(665, 2)
        Me.btLastComments.Name = "btLastComments"
        Me.btLastComments.Size = New System.Drawing.Size(42, 23)
        Me.btLastComments.TabIndex = 20
        Me.btLastComments.UseVisualStyleBackColor = True
        '
        'cbAssocierStation
        '
        Me.cbAssocierStation.AutoSize = True
        Me.cbAssocierStation.BackColor = System.Drawing.Color.Transparent
        Me.cbAssocierStation.Location = New System.Drawing.Point(4, 4)
        Me.cbAssocierStation.Name = "cbAssocierStation"
        Me.cbAssocierStation.Size = New System.Drawing.Size(102, 17)
        Me.cbAssocierStation.TabIndex = 19
        Me.cbAssocierStation.Text = "Associer Station"
        Me.cbAssocierStation.UseVisualStyleBackColor = False
        '
        'PanelSearchCommentaire
        '
        Me.PanelSearchCommentaire.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelSearchCommentaire.BackColor = System.Drawing.Color.Transparent
        Me.PanelSearchCommentaire.Controls.Add(Me.pbLoupe)
        Me.PanelSearchCommentaire.Controls.Add(Me.lbNbResultsCount)
        Me.PanelSearchCommentaire.Controls.Add(Me.tbSearchCommentaire)
        Me.PanelSearchCommentaire.Location = New System.Drawing.Point(713, 1)
        Me.PanelSearchCommentaire.Name = "PanelSearchCommentaire"
        Me.PanelSearchCommentaire.Size = New System.Drawing.Size(326, 27)
        Me.PanelSearchCommentaire.TabIndex = 17
        '
        'pbLoupe
        '
        Me.pbLoupe.Image = Global.My.Resources.Resources.magnifier
        Me.pbLoupe.Location = New System.Drawing.Point(3, 3)
        Me.pbLoupe.Name = "pbLoupe"
        Me.pbLoupe.Size = New System.Drawing.Size(31, 21)
        Me.pbLoupe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLoupe.TabIndex = 14
        Me.pbLoupe.TabStop = False
        '
        'lbNbResultsCount
        '
        Me.lbNbResultsCount.AutoSize = True
        Me.lbNbResultsCount.Location = New System.Drawing.Point(177, 8)
        Me.lbNbResultsCount.Name = "lbNbResultsCount"
        Me.lbNbResultsCount.Size = New System.Drawing.Size(0, 13)
        Me.lbNbResultsCount.TabIndex = 15
        '
        'tbSearchCommentaire
        '
        Me.tbSearchCommentaire.Location = New System.Drawing.Point(40, 3)
        Me.tbSearchCommentaire.Name = "tbSearchCommentaire"
        Me.tbSearchCommentaire.Size = New System.Drawing.Size(281, 20)
        Me.tbSearchCommentaire.TabIndex = 13
        '
        'LvInfoDisk
        '
        Me.LvInfoDisk.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader20, Me.ColumnHeader12})
        Me.LvInfoDisk.ContextMenuStrip = Me.ContextMenuStripDisk
        Me.LvInfoDisk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvInfoDisk.FullRowSelect = True
        Me.LvInfoDisk.Location = New System.Drawing.Point(3, 16)
        Me.LvInfoDisk.MultiSelect = False
        Me.LvInfoDisk.Name = "LvInfoDisk"
        Me.LvInfoDisk.Size = New System.Drawing.Size(295, 104)
        Me.LvInfoDisk.TabIndex = 61
        Me.LvInfoDisk.UseCompatibleStateImageBehavior = False
        Me.LvInfoDisk.View = System.Windows.Forms.View.Details
        '
        'columnHeader8
        '
        Me.columnHeader8.Text = "Type"
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Unité"
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Capacité"
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Libre"
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "% Libre"
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Dirty"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1356, 742)
        Me.Controls.Add(Me.SplitContainer3)
        Me.Controls.Add(Me.StatusStripMain)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "Analog"
        Me.StatusStripMain.ResumeLayout(False)
        Me.StatusStripMain.PerformLayout()
        Me.CollapsiblePanelVideoController.ResumeLayout(False)
        Me.CollapsiblePanelVideoController.PerformLayout()
        Me.PanelDetailvideoController.ResumeLayout(False)
        Me.PanelDetailvideoController.PerformLayout()
        Me.CollapsiblePanelDisplay.ResumeLayout(False)
        Me.CollapsiblePanelDisplay.PerformLayout()
        Me.PanelDetailDisplay.ResumeLayout(False)
        Me.PanelDetailDisplay.PerformLayout()
        Me.CollapsiblePanelNetwork.ResumeLayout(False)
        Me.CollapsiblePanelNetwork.PerformLayout()
        Me.PanelDetailNetwork.ResumeLayout(False)
        Me.PanelDetailNetwork.PerformLayout()
        Me.CollapsiblePanelOs.ResumeLayout(False)
        Me.CollapsiblePanelOs.PerformLayout()
        Me.PanelMainControls.ResumeLayout(False)
        Me.PanelMainControls.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.tbControlMain.ResumeLayout(False)
        Me.tabProgrammes.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.PanelProgramFilterButtons.ResumeLayout(False)
        Me.PanelProgramFilterButtons.PerformLayout()
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.PerformLayout()
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.PanelLegendProgramDiff.ResumeLayout(False)
        Me.PanelLegendProgramDiff.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabProcess.ResumeLayout(False)
        Me.tabServices.ResumeLayout(False)
        Me.TabCommentaires.ResumeLayout(False)
        Me.SplitContainerCommentaires.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerCommentaires, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerCommentaires.ResumeLayout(False)
        Me.GroupBoxResults.ResumeLayout(False)
        Me.GroupBoxResults.PerformLayout()
        Me.panelLaunchButtons.ResumeLayout(False)
        Me.GroupBoxDisk.ResumeLayout(False)
        Me.ContextMenuStripDisk.ResumeLayout(False)
        Me.GroupBoxPinger.ResumeLayout(False)
        Me.GroupBoxPinger.PerformLayout()
        Me.MenuStripFrmMain.ResumeLayout(False)
        Me.MenuStripFrmMain.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.FlowLayoutPanelCollapsiblePanels.ResumeLayout(False)
        Me.collapsiblePanelOrdinateur.ResumeLayout(False)
        Me.collapsiblePanelOrdinateur.PerformLayout()
        Me.CollapsiblePanelActiveDirectory.ResumeLayout(False)
        Me.CollapsiblePanelActiveDirectory.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.PanelSearchcommentaires.ResumeLayout(False)
        Me.PanelSearchcommentaires.PerformLayout()
        Me.PanelSearchCommentaire.ResumeLayout(False)
        Me.PanelSearchCommentaire.PerformLayout()
        CType(Me.pbLoupe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveLogDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents StatusStripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressMain As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents ChkdskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FavorisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents AjouterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    'Friend WithEvents OrganiserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstripLabelStationName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstripLabelNbProcesses As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbMonitorDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents PanelDetailDisplay As System.Windows.Forms.Panel
    Friend WithEvents btDisplayDetails As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents tbMonitorName As System.Windows.Forms.TextBox
    Friend WithEvents tbMonitorSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PanelDetailNetwork As System.Windows.Forms.Panel
    Friend WithEvents btNetIDetails As System.Windows.Forms.Button
    Friend WithEvents tbIpSubnet As System.Windows.Forms.TextBox
    Friend WithEvents lbIpSubnet As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tbNetConnectionID As System.Windows.Forms.TextBox
    Friend WithEvents tbGateway As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents tbDHCPEnabled As System.Windows.Forms.TextBox
    Friend WithEvents tbIpAdress As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tbMACadress As System.Windows.Forms.TextBox
    Friend WithEvents CollapsiblePanelOs As Salamander.Windows.Forms.CollapsiblePanel
    Friend WithEvents tbUpTime As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tbServicePack As System.Windows.Forms.TextBox
    Friend WithEvents tbSocle As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbOperatingSystem As System.Windows.Forms.TextBox
    Friend WithEvents PanelMainControls As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents LvInfoDisk As lvInfoDisk
    Friend WithEvents columnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnPrinterInfos As System.Windows.Forms.Button
    Friend WithEvents cmbStationName As System.Windows.Forms.ComboBox
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
    Friend WithEvents btnLogDetails As System.Windows.Forms.Button
    Friend WithEvents txtbErrNetwork As System.Windows.Forms.TextBox
    Friend WithEvents txtbErrDisque As System.Windows.Forms.TextBox
    Friend WithEvents btnFrmBatch As System.Windows.Forms.Button
    Friend WithEvents panelLaunchButtons As System.Windows.Forms.Panel
    Friend WithEvents btComptMgmt As System.Windows.Forms.Button
    Friend WithEvents btnVnc As System.Windows.Forms.Button
    Friend WithEvents btnCleanStation As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnlancer As System.Windows.Forms.Button
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tbAvgRoundtrip As System.Windows.Forms.TextBox
    Friend WithEvents tbMinRoundtrip As System.Windows.Forms.TextBox
    Friend WithEvents tbPercentLost As System.Windows.Forms.TextBox
    Friend WithEvents tbMaxRoundTrip As System.Windows.Forms.TextBox
    Friend WithEvents tbPingLOst As System.Windows.Forms.TextBox
    Friend WithEvents tbPingSent As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents CollapsiblePanelVideoController As Salamander.Windows.Forms.CollapsiblePanel
    Friend WithEvents tbAdapterRAM As System.Windows.Forms.TextBox
    Friend WithEvents tbCaption As System.Windows.Forms.TextBox
    Friend WithEvents tbVresolution As System.Windows.Forms.TextBox
    Friend WithEvents tbHresolution As System.Windows.Forms.TextBox
    Friend WithEvents PanelDetailvideoController As System.Windows.Forms.Panel
    Friend WithEvents btVideoControllerDetail As System.Windows.Forms.Button
    Friend WithEvents btPrev As System.Windows.Forms.Button
    Friend WithEvents btNext As System.Windows.Forms.Button
    Friend WithEvents btDisplayPrev As System.Windows.Forms.Button
    Friend WithEvents btDisplayNext As System.Windows.Forms.Button
    Friend WithEvents CollapsiblePanelDisplay As Salamander.Windows.Forms.CollapsiblePanel
    Friend WithEvents CollapsiblePanelNetwork As Salamander.Windows.Forms.CollapsiblePanel
    Friend WithEvents tbRefreshRate As System.Windows.Forms.TextBox
    Friend WithEvents tbVideoProcessor As System.Windows.Forms.TextBox
    Friend WithEvents lbNetworkCount As System.Windows.Forms.Label
    Friend WithEvents lbDisplayCount As System.Windows.Forms.Label
    Friend WithEvents btVideoControllerPrev As System.Windows.Forms.Button
    Friend WithEvents btVideoControllerNext As System.Windows.Forms.Button
    Friend WithEvents lbVideoControllerCount As System.Windows.Forms.Label
    Friend WithEvents lbVideoControllerCaption As System.Windows.Forms.Label
    Friend WithEvents lbVideoControllerRam As System.Windows.Forms.Label
    Friend WithEvents lbVideoControlleRefreshRate As System.Windows.Forms.Label
    Friend WithEvents lbVideoControllerYres As System.Windows.Forms.Label
    Friend WithEvents lbVideoControllerHres As System.Windows.Forms.Label
    Friend WithEvents LbVideoControllerProcessor As System.Windows.Forms.Label
    Friend WithEvents lbVideoControllerInstalledDriver As System.Windows.Forms.Label
    Friend WithEvents tbInstalledDriver As System.Windows.Forms.TextBox
    Friend WithEvents lbVideoControllerDriverVersion As System.Windows.Forms.Label
    Friend WithEvents tbDriverVersion As System.Windows.Forms.TextBox
    Friend WithEvents btEnvVar As System.Windows.Forms.Button
    Friend WithEvents tbNtfsError As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents tbftDiskError As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusConx As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBoxDisk As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxPinger As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CpuGraph As cpuGraph
    Friend WithEvents DiskIOGraph As diskIOGraph
    Friend WithEvents FreeMemoryGraph As freeMemoryGraph
    Friend WithEvents NetworkIOgraph As networkIOgraph
    Friend WithEvents lblNetIO As System.Windows.Forms.Label
    Friend WithEvents lblDiskIO As System.Windows.Forms.Label
    Friend WithEvents lblFreeRam As System.Windows.Forms.Label
    Friend WithEvents lblCpuUse As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStripDisk As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OuvrirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SMARTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents InfosUtilisateurToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstripLabelNbServices As System.Windows.Forms.ToolStripStatusLabel
    'Friend WithEvents AfficherPanneauLatéralToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    ' Friend WithEvents AfficherLogsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbControlMain As System.Windows.Forms.TabControl
    Friend WithEvents tabProgrammes As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents PanelProgramFilterButtons As System.Windows.Forms.Panel
    Friend WithEvents ckbFilterHorsSujet As System.Windows.Forms.CheckBox
    Friend WithEvents ckbFilterMicrosoft As System.Windows.Forms.CheckBox
    Friend WithEvents ckbChuFilter As System.Windows.Forms.CheckBox
    Friend WithEvents LvPrograms As lvPrograms
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tabProcess As System.Windows.Forms.TabPage
    Friend WithEvents LvProcess As lvProcess
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tabServices As System.Windows.Forms.TabPage
    Friend WithEvents LvServices As lvServices
    Friend WithEvents ColumnHeaderNom As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderDemarrage As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderCompte As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderPath As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderServiceType As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderProcessPID As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabCommentaires As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainerCommentaires As System.Windows.Forms.SplitContainer
    Friend WithEvents btnSendCommentaire As System.Windows.Forms.Button
    Friend WithEvents rtbCommentairesInput As System.Windows.Forms.RichTextBox
    Friend WithEvents PanelSearchcommentaires As gradientPanel
    Friend WithEvents cbAssocierStation As System.Windows.Forms.CheckBox
    Friend WithEvents PanelSearchCommentaire As System.Windows.Forms.Panel
    Friend WithEvents pbLoupe As System.Windows.Forms.PictureBox
    Friend WithEvents lbNbResultsCount As System.Windows.Forms.Label
    Friend WithEvents tbSearchCommentaire As System.Windows.Forms.TextBox
    Friend WithEvents btLastComments As System.Windows.Forms.Button
    Friend WithEvents lblErrApplication As System.Windows.Forms.Label
    Friend WithEvents tbErrApplication As System.Windows.Forms.TextBox
    Friend WithEvents cbLogFilterByDate As System.Windows.Forms.CheckBox
    Friend WithEvents Lvping As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents tbOfficeErrors As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tbEstimatedSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tbSearchProgram As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLog As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ChkdskFR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btResetPing As System.Windows.Forms.Button
    Friend WithEvents btCreatePingReport As System.Windows.Forms.Button
    Friend WithEvents cbChangeBufferPingSize As System.Windows.Forms.CheckBox
    'Friend WithEvents NouvelOngletToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuStripFrmMain As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuOutils As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RsopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VNCQueryConnectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    '  Friend WithEvents VNCNotificationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfosUtilisateurToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PsExecToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DefragToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DefragAnalyseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArreterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArreterForcerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedémarrerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedémarrerForcerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChkdskFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChkdskFRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerouillerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuAffichage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemPanneauLateral As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemLogs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NouvelOngletToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbNetworkDriverDate As System.Windows.Forms.TextBox
    Friend WithEvents blbDriverDate As System.Windows.Forms.Label
    Friend WithEvents tbNetworkDriverVersion As System.Windows.Forms.TextBox
    Friend WithEvents blbDriverVersion As System.Windows.Forms.Label
    Friend WithEvents tbNetworkDriverDesc As System.Windows.Forms.TextBox
    Friend WithEvents lblDriverDesc As System.Windows.Forms.Label
    Friend WithEvents lblReservIP As System.Windows.Forms.Label
    Friend WithEvents lblDHCP As System.Windows.Forms.Label
    Friend WithEvents lblWGA As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader25 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader26 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader27 As System.Windows.Forms.ColumnHeader
    Friend WithEvents VNCNotificationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnClearLogs As System.Windows.Forms.Button
    Friend WithEvents lbOfflineMode As System.Windows.Forms.Label
    Friend WithEvents ckbHighlistProgDiff As System.Windows.Forms.CheckBox
    Friend WithEvents btDetailPing As System.Windows.Forms.Button
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents PanelLegendProgramDiff As System.Windows.Forms.Panel
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents tbNetworkDriverManufacturer As System.Windows.Forms.TextBox
    Friend WithEvents lblDriverManufacturer As System.Windows.Forms.Label
    Friend WithEvents btScmRdp As System.Windows.Forms.Button
    Friend WithEvents SCCMValidationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfosHDDToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CollapsiblePanel1 As Salamander.Windows.Forms.CollapsiblePanel
    Friend WithEvents CollapsiblePanel2 As Salamander.Windows.Forms.CollapsiblePanel
    Friend WithEvents FlowLayoutPanelCollapsiblePanels As FlowLayoutPanel
    Friend WithEvents collapsiblePanelOrdinateur As Salamander.Windows.Forms.CollapsiblePanel
    Friend WithEvents btUserInfos As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents tbDomaine As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tbModele As TextBox
    Friend WithEvents tbSerialNumber As TextBox
    Friend WithEvents tbFreeMemory As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents tbMaxFrequency As TextBox
    Friend WithEvents tbHostname As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tbMemoireTotale As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents tbNbCpu As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents tbProcessor As TextBox
    Friend WithEvents tbCurrentUser As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents tbConstructeur As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents CollapsiblePanelActiveDirectory As Salamander.Windows.Forms.CollapsiblePanel
    Friend WithEvents lblADComputerDN As Label
    Friend WithEvents tbADcomputerDN As TextBox
    Friend WithEvents lblADComputerSercicePack As Label
    Friend WithEvents tbADComputerServicePack As TextBox
    Friend WithEvents lblADComputerOS As Label
    Friend WithEvents tbADcomputerOS As TextBox
    Friend WithEvents lblADComputerCreationDate As Label
    Friend WithEvents tbADComputerCreationDate As TextBox
    Friend WithEvents lblADComputerLastLogonTS As Label
    Friend WithEvents tbADcomputerLastLogonTS As TextBox
    Friend WithEvents lblLDAPDeleted As Label
    Friend WithEvents tbOsArch As TextBox
    Friend WithEvents lblOsArch As Label
    Friend WithEvents lblOsArchi As Label
    Friend WithEvents ScanImprimantesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsoleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FlushdnsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OuvrirConsoleCtrlkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tbOsDateInstall As TextBox
    Friend WithEvents lblOSDateInstall As Label
    Friend WithEvents FermerOngletToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblBetaVersion As Label
End Class
