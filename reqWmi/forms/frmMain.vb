Imports System.ComponentModel ' backgroundworker
Imports wmi
Imports Salamander.Windows.Forms


Public Class frmMain

    Private _station As cstation

    '
    ' delegates
    '
    Private Delegate Sub _degResetForm(ByVal force As Boolean, ByVal msg As String, ByVal normal As Boolean)
    Private Delegate Sub _degDisableVncMenuToolStrip()
    Private Delegate Sub _degUpdatePing(ByVal pingResults As cAsyncPinger.pingResults)
    Private Delegate Sub _degAddLvItem(ByVal logEntry As cLogEntry)
    Private Delegate Sub _degUpdateLvPrograms(ByRef programs As List(Of cPrograms.InstalledProgram))
    Private Delegate Sub _degEnableTbSearchProgram()
    Private Delegate Sub _degLogInfos(ByVal ntSystemLogerrorCount As NtLogEvent.structNtSystemLogErrorCount,
                                      ByVal ntApplicationErrorCount As Integer,
                                      ByVal ntOfficeErrorCount As Integer)
    Private Delegate Sub _degMainProgressBarSetVisible(ByVal visible As Boolean)
    Private Delegate Sub _degActivateCbHilightDiff(ByVal visible As Boolean)
    '
    ' delegates labels graphs
    '
    Private Delegate Sub _degUpdateLabelNetIO(ByVal i As Single, ByVal o As Single)
    Private Delegate Sub _degUpdateLabelDiskIO(ByVal r As Single, ByVal w As Single)
    Private Delegate Sub _degUpdateLabelFreeRam(ByVal v As Single)
    Private Delegate Sub _degUpdatecpu(ByVal v As Single)
    Private Delegate Sub _degSetWarningVisible(ByVal visible As Boolean)
    '
    ' BackgroundWorkers threads
    '
    Private WithEvents _bw As BackgroundWorker ' Thread Scan general
    Private WithEvents _bw_NetworkInfos As BackgroundWorker ' thread infos station
    '
    ' Pinger
    '
    Private _pinger As cAsyncPinger
    '
    Private _controlHashtable As New Hashtable ' hashtable avec une ref vers tous les controles du form
    '
    ' timers
    '
    Friend WithEvents tmrUpdateGraphs As Windows.Forms.Timer
    Friend WithEvents tmrUpdateProcess As Windows.Forms.Timer
    Friend WithEvents tmrTryReconnect As Windows.Forms.Timer
    '
    ' tab pour commentaires
    '
    Friend WithEvents tabComments As TabPage
    '
    ' sauvegarde index courant pour collections collapsiblePanel 
    '
    Private _currentNetworkIndex As Integer = Nothing
    Private _currentdisplayIndex As Integer = Nothing
    Private _currentVideoControllerIndex As Integer = Nothing
    '
    ' table Layout Panel pour affichage commentaires
    '
    Public LayoutPanelCommentaires As DBTableLayoutPanel
    Private _cCommentDisplay As cCommentaireDisplayList
    '
    ' ToolTip
    '
    Private _tooltip As New ToolTip
    '
    Public noErrorPopup As Boolean = False

    Private _lock As New Object
    Private _bClosingFlag As Boolean = False

    Private Enum windowIcon
        defaultIcon = 0
        connectedIcon = 1
        disconnectedIcon = 2
        offline = 3 ' affichage depuis database
    End Enum

    Public Const GIGA_OCTETS As Double = 1 << 30

    Public ReadOnly Property station() As cstation
        Get
            Return _station
        End Get
    End Property
    Public Property closingFlag() As Boolean
        Get
            SyncLock _lock
                Return _bClosingFlag
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            SyncLock _lock
                _bClosingFlag = value
            End SyncLock
        End Set
    End Property

    Public Function isActiveBackgroundWorker() As Boolean
        Dim bBwActive, bBwNetwork As Boolean

        bBwActive = False
        bBwNetwork = False

        If Not _bw Is Nothing Then
            If _bw.IsBusy Then
                bBwActive = True
            End If
        End If
        If Not _bw_NetworkInfos Is Nothing Then
            If _bw_NetworkInfos.IsBusy Then
                bBwNetwork = True
            End If
        End If

        Return bBwActive Or bBwNetwork
    End Function

    Public Sub New(Optional ByVal noErrorPopup As Boolean = False)
        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
        '
        Me.Name = "mainForm"

        If noErrorPopup Then
            noErrorPopup = True
        End If
        '
        ' init timers
        '
        Me.tmrUpdateGraphs = New Timer
        Me.tmrUpdateProcess = New Timer
        Me.tmrTryReconnect = New Timer
        Me.tmrUpdateGraphs.Interval = program.preferences.usMajGraphsDelay * 1000
        Me.tmrUpdateProcess.Interval = 3000
        Me.tmrTryReconnect.Interval = program.tryReconnectInterval
        '
        ' Ordre pour merger les menus dans le frmParent
        '
        Me.ToolStripMenuOutils.MergeAction = MergeAction.Insert
        Me.ToolStripMenuAffichage.MergeAction = MergeAction.Insert
        Me.ToolStripMenuOutils.MergeIndex = 1
        Me.ToolStripMenuAffichage.MergeIndex = 2
        '
        ' MAJ evt log
        '
        AddHandler log.eventLogItemAdded, AddressOf addLvItemEventHandler
        '
        ' Handlers pour mise à jour des labels Graphiques
        '
        AddHandler NetworkIOgraph.valueUpdated, AddressOf graphNetIOValueUpdated
        AddHandler DiskIOGraph.valueUpdated, AddressOf graphDiskIOValueUpdated
        AddHandler FreeMemoryGraph.valueUpdated, AddressOf graphFreeramvalueUpdated
        AddHandler CpuGraph.valueUpdated, AddressOf graphCpuvalueUpdated
        '
        AddHandler Me.tbControlMain.SelectedIndexChanged, AddressOf tabChanged_handler
        '
        ' INIT Tooltip
        '
        With _tooltip
            .AutoPopDelay = 5000
            .InitialDelay = 500
            .ReshowDelay = 500
            .ShowAlways = True
        End With

        LayoutPanelCommentaires = New DBTableLayoutPanel

        With LayoutPanelCommentaires
            .Dock = DockStyle.Fill
            .AutoScroll = True
            .AutoSize = True
            .AutoScrollMinSize = New Size(600, 600) ' empeche probleme resize pourquoi ??? 
            .AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
            .BackColor = Color.White
        End With
        Me.SplitContainerCommentaires.Panel1.Controls.Add(LayoutPanelCommentaires)

        _cCommentDisplay = New cCommentaireDisplayList(LayoutPanelCommentaires)

        _tooltip.SetToolTip(Me.btLastComments, "Derniers Commentaires")

        If program.releaseName = "BETA" Then
            Me.lblBetaVersion.Visible = True
        End If

    End Sub

    Private Sub getFocusHandler() Handles Me.GotFocus
        Me.cmbStationName.Focus()
    End Sub

    Private Sub setWindowIcon(ByVal windowicon As windowIcon)
        Select Case windowicon
            Case frmMain.windowIcon.defaultIcon
                '
            Case frmMain.windowIcon.connectedIcon
                Me.Icon = program.tabicons.iconConnected
            Case frmMain.windowIcon.disconnectedIcon
                Me.Icon = program.tabicons.iconDisconnected
            Case frmMain.windowIcon.offline
                Me.Icon = program.tabicons.iconOffline
        End Select

        program.frmMdiContainer.forceTabRepaint()
    End Sub

    Private Sub tmrUpdateProcess_Tick() Handles tmrUpdateProcess.Tick
        LvProcess.asyncUpdate()
        tstripLabelNbProcesses.Text = String.Format("Processes : {0}", CStr(LvProcess.Items.Count))
    End Sub

    Private Sub tmrUpdateProcessSwitch(ByVal bool As Boolean)
        Me.tmrUpdateProcess.Enabled = bool
        Me.tmrUpdateProcess.Start()
    End Sub

    ''' <summary>
    ''' Perte de connexion Wmi avec la station en cours
    ''' évènement disconnect émis par cwmi ( addhandler dans sub lancer )
    ''' on réinit le From et on vide les processes
    ''' Appelé depuis threadWorker (cwmi) => invoke
    ''' </summary>
    ''' <param name="force">True si déco suite à requete ko</param>
    ''' <param name="msg">Infos exception</param>
    ''' <param name="normal">true si déconnection suite à cnx sur autre station ( pas d'erreur )</param>
    ''' <remarks>
    ''' </remarks>
    Public Sub disconnectedHandler(Optional ByVal force As Boolean = False,
                                   Optional ByVal msg As String = "",
                                   Optional ByVal normal As Boolean = False)

        If Not _bClosingFlag Then
            If InvokeRequired Then
                Dim deg As New _degResetForm(AddressOf disconnectedHandler)
                Me.BeginInvoke(deg, force, msg, normal)
            Else
                setWindowIcon(windowIcon.disconnectedIcon)
                Me.tmrUpdateProcess.Stop()
                Me.StopUpdateGraphs()
                '
                ' désactivation entrées menu outil
                '
                Me.VNCNotificationToolStripMenuItem.Enabled = False
                Me.VNCQueryConnectToolStripMenuItem.Enabled = False
                Me.SCCMValidationToolStripMenuItem.Enabled = False
                Me.btnClearLogs.Enabled = False
                Me.RsopToolStripMenuItem.Enabled = False
                Me.PsExecToolStripMenuItem.Enabled = False
                Me.InfosHDDToolStripMenuItem.Enabled = False
                Me.ToolStripStatusConx.Image = My.Resources.cross_circle16

                CpuGraph.close()
                NetworkIOgraph.close()
                FreeMemoryGraph.close()
                DiskIOGraph.close()

                ' TODO 
                ' affreux 
                ' on attends que  lvProcess ai fini d'etre mis à jour avant de Vider ...
                ' erreur crossThread sinon ( voir cProcessConnection )
                ' ==> thread synchronisation
                If Me.LvProcess.processConnection.syncBusyFlag = True Then
                    log.addLogEntry(New cLogEntry("PROCESS : la connexion est occupée ... annulation", cLogEntry.enumDebugLevel.DEBUG, _station.stationName))
                    Me.LvProcess.processConnection.isCanceled = True
                End If

                'TODO
                ' FIIIIIIXME 
                ' peut bloquer ICI 
                ' a revoir :(
                If Not Me.LvProcess.processConnection.isCanceled Then
                    If Me.LvProcess.processConnection.isInvokecompleted = False Then
                        Throw New Exception("Erreur grave : Process Updater : pas de réponse")
                    End If
                End If

                Me.LvProcess.ClearItems()

                If normal Then
                    log.addLogEntry(New cLogEntry("Deconnexion", cLogEntry.enumDebugLevel.INFO, _station.stationName))
                Else
                    tmrTryReconnect.Start() ' déco suite à erreur => on essaie de se reconnecter
                    'TODO Critical , _station peut être à NULL 
                    log.addLogEntry(New cLogEntry("Deconnexion, raison : " & msg, cLogEntry.enumDebugLevel.ERREUR, _station.stationName, "cwmi"))
                End If
            End If
        Else

            Debug.Print("Operation deconnexion annulée frm Closing ...")
        End If

    End Sub

    Public Sub connectedHandler()
        SyncLock _lock
            If Not _bClosingFlag Then
                If InvokeRequired Then
                    Me.BeginInvoke(New _degDisableVncMenuToolStrip(AddressOf connectedHandler))
                Else
                    tmrTryReconnect.Stop()
                    '
                    ' activation entrées menu outil
                    '
                    Me.VNCNotificationToolStripMenuItem.Enabled = True
                    Me.VNCQueryConnectToolStripMenuItem.Enabled = True
                    Me.SCCMValidationToolStripMenuItem.Enabled = True
                    Me.btnClearLogs.Enabled = True
                    Me.RsopToolStripMenuItem.Enabled = True
                    Me.PsExecToolStripMenuItem.Enabled = True
                    Me.InfosHDDToolStripMenuItem.Enabled = True
                    '
                    ' Assignation icone de la fenetre
                    '
                    setWindowIcon(windowIcon.connectedIcon)
                    '
                    Me.ToolStripStatusConx.Image = My.Resources.ok16 ' icone cnx OK
                    '
                    '  Affichage du nom de la station dans onglet en cours
                    '
                    program.frmMdiContainer.setFrmTitleText(_station.stationName)
                End If
            End If
        End SyncLock
    End Sub

    ''' <summary>
    ''' Si ping OK essaie de se reconnecter toutes les 5 secondes
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub tmrTryReconnectHandler() Handles tmrTryReconnect.Tick
        ' TODO
        ' On peut se retrouver ici avec station à nothing
        ' ce n'est pas normal
        '
        ' MODIF 2/10/2013
        ' crash reference non définie , peut etre tick émis après fermeture onglet ..
        ' ajout lock et test bclosingflag 
        ' 
        SyncLock _lock
            If Not _bClosingFlag Then
                If Not _station Is Nothing Then
                    If _pinger.isPingOk Then
                        log.addLogEntry(New cLogEntry("Tentative reconnexion", cLogEntry.enumDebugLevel.INFO, _station.stationName))

                        ' TODO fonction bloquante => UI :(
                        If station.connect Then
                            log.addLogEntry(New cLogEntry("Reconnexion réussie", cLogEntry.enumDebugLevel.INFO, _station.stationName))

                            tmrTryReconnect.Stop()
                            Me.tmrUpdateProcess.Start()
                            Me.startUpdateGraphs()
                        Else
                            log.addLogEntry(New cLogEntry(String.Format("Reconnexion impossible : {0}", _station.errorMessage), cLogEntry.enumDebugLevel.ERREUR, _station.stationName))
                        End If
                    End If
                Else
                    log.addLogEntry(New cLogEntry("Reconnexion impossible, station = NULL ", cLogEntry.enumDebugLevel.DEBUG))
                    tmrTryReconnect.Stop()
                End If
            End If
        End SyncLock
    End Sub

    Public Sub setMainProgressBarVisible(ByVal visible As Boolean)
        SyncLock _lock
            If Not _bClosingFlag Then
                If InvokeRequired Then
                    Me.BeginInvoke(New _degMainProgressBarSetVisible(AddressOf setMainProgressBarVisible), visible)
                Else
                    If Not Me.Disposing Then
                        Me.ToolStripProgressMain.Visible = visible
                    End If
                End If
            End If
        End SyncLock
    End Sub

    Public Sub setCbHilightVisible(ByVal visible As Boolean)
        SyncLock _lock
            If Not _bClosingFlag Then
                If InvokeRequired Then
                    Me.BeginInvoke(New _degActivateCbHilightDiff(AddressOf setCbHilightVisible), visible)
                Else
                    If Not Me.Disposing Then
                        Me.ckbHighlistProgDiff.Visible = visible
                    End If
                End If
            End If
        End SyncLock
    End Sub

    Private Sub Form1_Load(ByVal sender As Object,
                           ByVal e As System.EventArgs)

        getAllcontrolRecursive(Me)
        '
        'rétablit état panneaux infos
        '
        If program.preferences.bSavePanelState Then
            setPanelState()
        End If
        '
        ' rétablit état log Panel
        '
        SplitContainer2.Panel2Collapsed = program.preferences.bLogPanelCollapse
        Me.ToolStripMenuItemLogs.Checked = Not SplitContainer2.Panel2Collapsed
        '
        ' menu Contextuel listView Disques
        '
        Me.LvInfoDisk.ContextMenuStrip = Me.ContextMenuStripDisk
        '
        ' Tooltips
        '
        With _tooltip
            .SetToolTip(Me.btnVnc, "VNC")
            .SetToolTip(Me.btnCleanStation, "Nettoyage")
            .SetToolTip(Me.btnFrmBatch, "Scan Batch")
            .SetToolTip(Me.btnPrinterInfos, "Files impression")
            .SetToolTip(Me.btComptMgmt, "Gérer")
            .SetToolTip(Me.btScmRdp, "Scm Viewer")
            .SetToolTip(Me.btEnvVar, "Variables d'environnement")
            .SetToolTip(Me.cbLogFilterByDate, "filtrer evts antérieurs à 15 jours")
            .SetToolTip(Me.btnClearLogs, "Effacer logs")
            .SetToolTip(Me.lblWGA, "WGA non détecté")
            .SetToolTip(Me.btCreatePingReport, "Copier rapport Ping")
            .SetToolTip(Me.cbChangeBufferPingSize, "Ping Long")
            .SetToolTip(Me.btResetPing, "reset")
            .SetToolTip(Me.ckbChuFilter, "Filtre programmes CHU")
            .SetToolTip(Me.ckbFilterMicrosoft, "Filtre programmes Microsoft")
            .SetToolTip(Me.ckbFilterHorsSujet, "Filtre programmes inconnus")
            .SetToolTip(Me.ckbHighlistProgDiff, "Filtre différences Dernier scan")
        End With
        '
        Me.btnlancer.Enabled = False
        ' Mise à jour Historique
        Me.updateLastUsedStationComboBox()
        '
        Me.resetForm()
        ' lance scan station si option ligne commande
        If program.stationCommandLine IsNot Nothing Then
            startScan(program.stationCommandLine)
        End If
        '
        'Me.memoryUse.graphType = graphControl.enumGraphType.bar
        ' FIXME affreux hack => bug resize si 1er panel expanded et scrollBar visible....
        ' a voir si toujours nécessaire ...
        reversePanelState(Me.collapsiblePanelOrdinateur)
        reversePanelState(Me.collapsiblePanelOrdinateur)

        ' TODO collapsible to flow
        ' CollapsiblePanelHandlerRegister()

        ' setOfflineMode()

    End Sub

    ' TODO collapsible to Flowpanel
    'Private Sub CollapsiblePanelHandlerRegister(Optional ByVal remove As Boolean = False)
    '    For Each c As CollapsiblePanel In CollapsiblePanelBar1.CollapsiblePanelCollection
    '        If Not remove Then
    '            AddHandler c.PanelStateChanged, AddressOf CollapsiblePanelAddedEventHandler
    '        Else
    '            RemoveHandler c.PanelStateChanged, AddressOf CollapsiblePanelAddedEventHandler
    '        End If
    '    Next
    'End Sub

    ' TODO flow to collapsible
    Private Sub CollapsiblePanelAddedEventHandler(ByVal s As Object, ByVal e As PanelEventArgs)
        ' sauve etat des panels infos si nécessaire
        'If program.preferences.bSavePanelState Then
        '    Dim sPanelState As String = ""

        '    For Each Panel As Salamander.Windows.Forms.CollapsiblePanel In Me.CollapsiblePanelBar1.Controls
        '        If sPanelState <> String.Empty Then sPanelState += "|"
        '        Dim panelName As String = Panel.Name
        '        Dim panelState As String = Panel.PanelState.ToString
        '        sPanelState += panelName & "|" & panelState
        '    Next

        '    program.preferences.savePanelState(sPanelState)
        'End If
    End Sub

    Private Sub reversePanelState(ByVal panel As Salamander.Windows.Forms.CollapsiblePanel)
        If panel.PanelState = Salamander.Windows.Forms.PanelState.Collapsed Then
            panel.PanelState = Salamander.Windows.Forms.PanelState.Expanded
        Else
            panel.PanelState = Salamander.Windows.Forms.PanelState.Collapsed
        End If
    End Sub

    ''' <summary>
    ''' Stocke une réf de tous les controles ME dans hashtable
    ''' </summary>
    ''' <param name="ctr"></param>
    ''' <remarks>
    ''' Si controles ajoutés Dynamiquement
    ''' il faudrait les rajouter dans cette table
    ''' </remarks>
    Private Sub getAllcontrolRecursive(ByVal ctr As Control)
        If Not _controlHashtable.ContainsKey(ctr.Name) Then
            _controlHashtable.Add(ctr.Name, ctr)
        End If

        If ctr.HasChildren Then
            For Each c As Control In ctr.Controls
                getAllcontrolRecursive(c)
            Next c
        End If
    End Sub

    ''' <summary>
    ''' retrouve controle stocké dans hashtable par son nom
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetControlByName(ByVal name As String) As Control
        Return CType(_controlHashtable(name), Control)
    End Function

    ''' <summary>
    ''' Rétablit état des panels infos depuis les préférences
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setPanelState()
        'TODO fix collapsible to flow
        Exit Sub
        Dim sPanelState As String = program.preferences.cPanelState

        If Not sPanelState = String.Empty Then
            Dim aPanelState As String() = sPanelState.Split(CChar("|"))
            Dim panelName, panelState As String

            For i = 0 To aPanelState.Count - 1 Step 2
                panelName = aPanelState(i)
                panelState = aPanelState(i + 1)

                Dim panel = CType(GetControlByName(panelName), Salamander.Windows.Forms.CollapsiblePanel)

                If panelState = "Expanded" Then
                    panel.PanelState = Salamander.Windows.Forms.PanelState.Expanded
                Else
                    panel.PanelState = Salamander.Windows.Forms.PanelState.Collapsed
                End If
            Next
        End If
    End Sub

    Private Sub updateFromDB()
        _station.offlineMode = True
        setWindowIcon(windowIcon.offline)

        '
        ' MAJ Programmes
        '
        Me.LvPrograms.updateitemsForStation(_station.programs.getPrograms(True))
        Me.tbSearchProgram.Enabled = True

        For Each CheckBox As CheckBox In PanelProgramFilterButtons.Controls
            CheckBox.Enabled = True
        Next

        ' program.frmMdiContainer.set()
        Dim br As New structs.analogStructs.BatchResult
        cMysqlStation.getStationBatchResultFromDB(_station.stationName, br)
        _station.dateScan = br.dateScan

        Me.Text = _station.stationName
        Me.lbOfflineMode.Visible = True
        Me.lblLDAPDeleted.Visible = br.bdeleted
        Me.LvInfoDisk.ContextMenuStrip.Enabled = False
        Me.LvPrograms.ContextMenuStrip.Enabled = False
        '
        With Me.tbControlMain.TabPages
            .RemoveByKey("tabProcess")
            .RemoveByKey("tabServices")
            .RemoveByKey("tabCommentaires")
        End With
        '
        Me.tstripLabelStationName.Text = String.Format("{0} Date Scan :  {1} {2}", _station.stationName, _station.dateScan.ToLongDateString, _station.dateScan.ToLongTimeString)

        '
        Me.txtbErrDisque.Text = br.errDisk.ToString
        Me.txtbErrNetwork.Text = br.errNetwork.ToString
        Me.txtbErrReboot.Text = br.errReboot.ToString
        Me.txtbBsod.Text = br.errBsod.ToString
        Me.tbHdFailure.Text = br.driverPredictFail.ToString
        '
        Me.tbConstructeur.Text = br.constructeur
        Me.tbMemoireTotale.Text = convRamAsUlongToString(br.ram)
        Me.tbModele.Text = br.modele
        Me.tbOperatingSystem.Text = br.osName
        Me.tbSerialNumber.Text = br.sn
        Me.tbSocle.Text = br.socle
        Me.tbHostname.Text = br.stationName
        '
        'Infos disk
        '
        Me.LvInfoDisk.updateitemsForStation(br.hddTotalSpace, CInt(br.freeSpaceOnSystemDisk))
        '
        ' Passage tb modele en orange si boitier tour 
        '
        If br.towerCase Then
            Me.tbModele.BackColor = Color.Orange
        End If
        '
        setColorsTxt()
        '
        ' Maj Des ecrans depuis DB
        '
        _station.edidInfo.listMonitorEdidInfo = cMysqlDisplaysTable.selectdisplaysForStation(_station.stationName)
        updateDisplayInfos()
    End Sub

    '
    ' TODO => cette fonction devrait uniquement mettre à jour lvPING ....
    '
    Public Sub updatePing(ByVal pingResults As cAsyncPinger.pingResults)
        ' 3 heures max historique ping dans le LV
        If Me.Lvping.Items.Count > cAsyncPinger.MAX_LV_PING_HISTORY Then
            Me.Lvping.Items.RemoveAt(0)
        End If

        If Me.Lvping.Items.Count = 0 Then

            Dim sr As DirectoryServices.SearchResult = ldapWrapper.getComputerDNWithoutFilter(_station.stationName)
            Dim creationDate, operatingSystem, operatingSystemServicePack, DN, lastLogonTimeStamp, readableLastLogon As String

            creationDate = Nothing
            operatingSystem = Nothing
            operatingSystemServicePack = Nothing
            DN = Nothing
            lastLogonTimeStamp = Nothing
            readableLastLogon = Nothing

            If sr IsNot Nothing Then
                If sr.Properties("whencreated") IsNot Nothing AndAlso
                    sr.Properties("whencreated").Count > 0 Then
                    creationDate = sr.Properties("whencreated")(0).ToString
                End If
                If sr.Properties("operatingsystem") IsNot Nothing AndAlso
                    sr.Properties("operatigsystem").Count > 0 Then
                    operatingSystem = sr.Properties("operatingsystem")(0).ToString
                End If
                If sr.Properties("operatingSystemServicePack") IsNot Nothing AndAlso
                   sr.Properties("operatingSystemServicePack").Count > 0 Then
                    operatingSystemServicePack = sr.Properties("operatingSystemServicePack")(0).ToString
                End If
                If sr.Properties("distinguishedname") IsNot Nothing Then DN = sr.Properties("distinguishedname")(0).ToString

                If sr.Properties("lastlogontimestamp") IsNot Nothing AndAlso
                        sr.Properties("lastlogontimestamp").Count > 0 Then
                    lastLogonTimeStamp = sr.Properties("lastlogontimestamp")(0).ToString
                End If

                If lastLogonTimeStamp IsNot Nothing Then
                    readableLastLogon = DateTime.FromFileTime(CLng(lastLogonTimeStamp)).ToString
                End If
            End If


            If CBool(pingResults.lost) Then
                resetForm()

                If sr IsNot Nothing Then
                    Me.tbADComputerCreationDate.Text = creationDate
                    Me.tbADcomputerOS.Text = operatingSystem
                    Me.tbADComputerServicePack.Text = operatingSystemServicePack
                    Me.tbADcomputerDN.Text = DN
                    Me.tbADcomputerLastLogonTS.Text = readableLastLogon
                End If

                '
                ' Todo meme si la station figure dans la base 
                ' il faudrait afficher les infos récupérées dans Active Directory
                '
                If cMySqlStationTable.isStationExist(_station.stationName) Then
                    updateFromDB()
                ElseIf sr Is Nothing Then
                    MsgBox(String.Format("Impossible de joindre {0}", _station.stationName))
                End If

                Exit Sub
            Else ' If CBool(pingResults.lost)

                If sr IsNot Nothing Then
                    Me.tbADComputerCreationDate.Text = creationDate
                    Me.tbADcomputerOS.Text = operatingSystem
                    Me.tbADComputerServicePack.Text = operatingSystemServicePack
                    Me.tbADcomputerDN.Text = DN
                    Me.tbADcomputerLastLogonTS.Text = readableLastLogon
                End If

                If Not _station Is Nothing Then
                    If Not _station.wmi.isConnected Then
                        startScan()
                    End If
                End If
            End If
        End If ' If Me.Lvping.Items.Count = 0 

        If Not Me.Disposing Then

            If CBool(pingResults.lost) Then
                If Me.tbPingLOst.BackColor <> Color.Red Then
                    Me.tbPingLOst.BackColor = Color.Red
                End If
            End If

            With Me.Lvping
                .SuspendLayout()
                .Items.Add(New ListViewItem(pingResults.text))
                .Items(Me.Lvping.Items.Count - 1).EnsureVisible()
                .ResumeLayout()
            End With

            ' maj TextBoxes stats ping
            With pingResults
                Me.tbPingSent.Text = .sent.ToString
                Me.tbPingLOst.Text = .lost.ToString
                Me.tbAvgRoundtrip.Text = .avgRoundtripTime.ToString
                Me.tbMaxRoundTrip.Text = .maxRoundtrip.ToString
                Me.tbMinRoundtrip.Text = .minRoundTrip.ToString
                Me.tbMinRoundtrip.Text = .minRoundTrip.ToString
                Me.tbPercentLost.Text = .lostPercentage.ToString
            End With
        End If
    End Sub

    Private Sub resetForm()
        ' clean ping 
        If Not closingFlag Then
            If _pinger IsNot Nothing Then
                _pinger.stopPing()
            End If
            '
            setWindowIcon(windowIcon.defaultIcon)
            '
            Me.Lvping.Items.Clear()
            Me.tbPingLOst.Clear()
            Me.tbPingSent.Clear()
            Me.tbAvgRoundtrip.Clear()
            Me.tbMaxRoundTrip.Clear()
            Me.tbMinRoundtrip.Clear()
            Me.tbPercentLost.Clear()
            Me.tbPingLOst.BackColor = Color.White
            ' titre fenêtre
            Me.Text = "Analog"
            Me.ToolStripProgressMain.Visible = False
            Me.ToolStripProgressMain.Style = ProgressBarStyle.Marquee
            '
            Me.tbSearchProgram.Enabled = False
            Me.tbSearchProgram.Clear()
            ' vide les listView
            Me.LvInfoDisk.Items.Clear()
            Me.LvPrograms.Items.Clear()
            Me.LvServices.Items.Clear()
            '
            Me.btNetIDetails.Enabled = False
            Me.btnLogDetails.Enabled = False
            Me.btnClearLogs.Enabled = False
            Me.btEnvVar.Enabled = False
            ' désactive boutons lancement
            Me.switchLaunchButtons(False)
            '
            Me.cbLogFilterByDate.Checked = False
            Me.cbLogFilterByDate.Enabled = False
            'Me.btnlancer.Enabled = True
            Me.ckbChuFilter.Checked = False
            Me.ckbFilterMicrosoft.Checked = False
            Me.ckbFilterHorsSujet.Checked = False
            Me.ckbChuFilter.Enabled = False
            Me.ckbFilterMicrosoft.Enabled = False
            Me.ckbFilterHorsSujet.Enabled = False
            Me.ckbHighlistProgDiff.Visible = False
            '
            Me.btnPrinterInfos.Enabled = False
            '
            ' Efface TextBoxes log systeme
            '
            Me.txtbErrDisque.Clear()
            Me.txtbErrNetwork.Clear()
            Me.txtbErrReboot.Clear()
            Me.txtbBsod.Clear()
            Me.tbErrControleur.Clear()
            Me.tbHdFailure.Clear()
            Me.tbNtfsError.Clear()
            Me.tbftDiskError.Clear()
            Me.tbErrApplication.Clear()
            Me.tbOfficeErrors.Clear()
            '
            Me.lblWGA.Visible = False
            ' efface commentaires
            If Not _cCommentDisplay Is Nothing Then
                _cCommentDisplay.dispose()
            End If
            '
            Me.resetColorsTxt()
            '
            Me.tstripLabelNbProcesses.Text = "NA"
            Me.tstripLabelNbServices.Text = "NA"
            Me.tstripLabelStationName.Text = "non connecté"
            '
            ' outils VNC / SCCM viewer
            '
            Me.VNCQueryConnectToolStripMenuItem.Enabled = False
            Me.VNCNotificationToolStripMenuItem.Enabled = False
            Me.SCCMValidationToolStripMenuItem.Enabled = False
            '
            ' PsExec
            '
            Me.PsExecToolStripMenuItem.Enabled = False
            '
            ' Raz groupBoxes
            '
            razCollapsiblePanel(Me.collapsiblePanelOrdinateur)
            razCollapsiblePanel(Me.CollapsiblePanelOs)
            razCollapsiblePanel(Me.CollapsiblePanelNetwork)
            razCollapsiblePanel(Me.CollapsiblePanelDisplay)
            razCollapsiblePanel(Me.CollapsiblePanelVideoController)
            '
            ' Raz indexes collections ( collapsible panels Video / Network)
            '
            _currentdisplayIndex = Nothing
            _currentNetworkIndex = Nothing
            _currentdisplayIndex = Nothing
            _currentVideoControllerIndex = Nothing
            '
            ' Labels erreurs 
            '
            lblReservIP.Visible = False
            lblWGA.Visible = False
            lblDHCP.Visible = False
            lblLDAPDeleted.Visible = False
            lblOsArchi.Visible = False
            '
            ' Offline
            '
            Me.lbOfflineMode.Visible = False
            Me.LvInfoDisk.ContextMenuStrip.Enabled = True
            Me.LvPrograms.ContextMenuStrip.Enabled = True
            Me.InfosHDDToolStripMenuItem.Enabled = False
            '
            Me.cmbStationName.Select()
            '
            '  diff Programmes
            '
            Me.PanelLegendProgramDiff.Visible = False
            Me.ckbHighlistProgDiff.Checked = False
            '
            If Me.tbControlMain.TabPages.Count = 1 Then
                Me.tbControlMain.TabPages.Add(Me.tabProcess)
                Me.tbControlMain.TabPages.Add(Me.tabServices)
                Me.tbControlMain.TabPages.Add(Me.TabCommentaires)
            End If
            '
            ' Reset données LDAP
            '
            Me.tbADComputerCreationDate.Clear()
            Me.tbADcomputerDN.Clear()
            Me.tbADcomputerLastLogonTS.Clear()
            Me.tbADcomputerOS.Clear()
            Me.tbADComputerServicePack.Clear()
        End If
    End Sub

    ''' <summary>
    ''' Remise à zéro Collapsible panels
    ''' </summary>
    ''' <param name="control"></param>
    ''' <remarks></remarks>
    Private Sub razCollapsiblePanel(ByVal control As Control)
        For Each control In control.Controls
            If TypeOf (control) Is TextBox Then
                Dim tb = CType(control, TextBox)
                tb.Clear()
                tb.BackColor = Color.FromKnownColor(KnownColor.Info)
                ' remise à zéro des controles pour le panels collection
            ElseIf TypeOf (control) Is Panel Then
                For Each controlPanel In control.Controls
                    If TypeOf (controlPanel) Is Label Then
                        CType(controlPanel, Label).Text = String.Empty
                    ElseIf TypeOf (controlPanel) Is Button Then
                        CType(controlPanel, Button).Enabled = False
                    End If
                Next
            End If
        Next
    End Sub

    ''' <summary>
    ''' Charge historique dans comboBOx
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub updateLastUsedStationComboBox()
        Me.cmbStationName.Items.Clear()

        For Each setting As String In cstation.lstLastUsedStation
            Me.cmbStationName.Items.Add(setting)
        Next
    End Sub

    ''' <summary>
    ''' Scanne une station
    ''' </summary>
    ''' <param name="stationName"></param>
    ''' <remarks>Appelé depuis frmBatch</remarks>
    Public Sub startScan(ByVal stationName As String)
        Me.cmbStationName.Text = stationName
        Me.Lancer_Click()
    End Sub

    ''' <summary>
    ''' Démarre scan station
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Lancer_Click() Handles btnlancer.Click
        Dim textStation As String = Trim(Me.cmbStationName.Text).ToUpperInvariant
        textStation = System.Text.RegularExpressions.Regex.Replace(textStation, "[^a-zA-Z0-9_.-]+", "", System.Text.RegularExpressions.RegexOptions.Compiled)

        Dim bscanSameStation As Boolean = False

        Dim isBusy As Boolean = False
        If _bw IsNot Nothing Then
            If _bw.IsBusy Then
                _bw.CancelAsync()
                isBusy = True
            End If
        End If
        If _bw_NetworkInfos IsNot Nothing Then
            If _bw_NetworkInfos.IsBusy Then
                _bw_NetworkInfos.CancelAsync()
                isBusy = True
            End If
        End If

        If isBusy Then
            MsgBox("Traitement en cours ....")
            Exit Sub
        End If

        If textStation = "" Then
            MsgBox("Veuillez choisir une station")
            Exit Sub
        End If

        If Not _station Is Nothing Then
            If textStation = _station.stationName Then
                bscanSameStation = True
            End If
        End If

        If Not program.frmMdiContainer.isTabAlreadyOpened(textStation) Or bscanSameStation Then
            Me.resetForm()

            ' Déconnecte la cnx actuelle si nécessaire
            If Not _station Is Nothing Then
                If _station.wmi.isConnected Then
                    _station.disconnect(normal:=True) 'voir me.disconnectedHandler => à arranger
                End If
            End If

            _station = Nothing

            '
            ' Si nom station = File imprimante dans AD 
            ' ou appuie touche control => ouverture form Interface Printer
            '
            If ldapWrapper.getComputerDNWithoutFilter(textStation) Is Nothing Then

                Dim ldapPrinterProps As New ldapWrapper.ldapPrinterProperties
                If ldapWrapper.getLDAPPrinterINfos(textStation, ldapPrinterProps) Or
                    ((Control.ModifierKeys And Keys.Control) = Keys.Control) Then

                    program.frmMdiContainer.addTabPrinter(textStation, ldapPrinterProps)
                    Me.Close()
                    Exit Sub

                End If
            End If

            _station = New cstation(textStation, Me)

            ' lance ping sur la station
            log.addLogEntry(New cLogEntry(String.Format("Pinging {0} ...", _station.stationName), cLogEntry.enumDebugLevel.INFO, _station.stationName))

            Dim bufferPing As Integer
            If Me.cbChangeBufferPingSize.Checked Then
                bufferPing = cAsyncPinger.pingBufferDataLenght.pingLong
            Else
                bufferPing = cAsyncPinger.pingBufferDataLenght.pingNormal
            End If

            LvProcess.initConexion(Me.station)

            _pinger = New cAsyncPinger(_station.stationName,
                                       Me.Lvping,
                                       New _degUpdatePing(AddressOf updatePing),
                                       bufferPing)

            _pinger.startPing()
        End If
    End Sub

    ' Appeler si ping OK
    Private Sub startScan()
        Me.switchLaunchButtons(True)
        Me.ToolStripProgressMain.Visible = True

        Me.Text = _station.stationName
        ' TODO bof
        ' Fixme ces handlers sont enlevés qque part ????? ==> leak
        AddHandler _station.wmi.disconnected, AddressOf Me.disconnectedHandler
        AddHandler _station.wmi.connected, AddressOf Me.connectedHandler
        '
        Me.btnlancer.Enabled = False
        _bw = New BackgroundWorker
        _bw_NetworkInfos = New BackgroundWorker
        _bw.WorkerSupportsCancellation = True
        _bw_NetworkInfos.WorkerSupportsCancellation = True

        _bw.RunWorkerAsync()

        ' on ajoute la station dans l'historique
        cstation.addStationTolstUsedStation(_station.stationName)
        Me.updateLastUsedStationComboBox()
    End Sub

    ''' <summary>
    ''' Récupère les résultats dans thread Worker
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' TODO 
    ''' A corriger 
    ''' si station.connect reste bloqué ( peut le rester longtemps )
    ''' quand retourne false on a probablement changé x fois de station 
    ''' cependant l'erreur va remonter jusqu'ici et on va passer station ( variable globale déclarée dans program ) à nothing !!!!!!
    ''' </remarks>
    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles _bw.DoWork

        If Not _bw.CancellationPending Then

            If _station.connect Then
                log.addLogEntry(New cLogEntry(String.Format("Connexion réussie sur {0}", _station.stationName), cLogEntry.enumDebugLevel.INFO, _station.stationName, "cwmi"))
            Else

                If Not noErrorPopup Then
                    MessageBox.Show(String.Format("Impossible de se connecter sur : {0} Erreur : {1}", _station.stationName, _station.errorMessage),
                                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification, False)
                Else
                    log.addLogEntry(New cLogEntry(String.Format("Impossible de se connecter, raison : {0}", _station.errorMessage), cLogEntry.enumDebugLevel.ERREUR, _station.stationName, "cwmi"))
                End If

                e.Result = False
                Exit Sub
            End If

            If Not closingFlag Then
                _station.getResults()
                e.Result = True
            End If

        Else
            log.addLogEntry(New cLogEntry("le backgroundWorker a été abandonné", cLogEntry.enumDebugLevel.DEBUG))
        End If

    End Sub

    Private Sub bw_NetorkInfos_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles _bw_NetworkInfos.DoWork
        If Not _bw_NetworkInfos.CancellationPending Then
            _station.getNeworkInfos()
        End If
    End Sub

    Private Sub bw_NetworkInfos_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles _bw_NetworkInfos.RunWorkerCompleted
        SyncLock _lock
            If Not _bClosingFlag Then
                If Not e.Cancelled Or _bw.CancellationPending Then
                    If Not _station Is Nothing Then
                        If _station.iAsynctaskcounter = 0 Then
                            Me.ToolStripProgressMain.Visible = False
                        End If

                        Me.updateNetworkInfosNew(True)
                    End If
                End If
            End If
        End SyncLock
    End Sub

    Public Sub LvProgramUpdater()
        SyncLock _lock
            If Not _bClosingFlag Then
                If Not Me.Disposing Then
                    If Not _station Is Nothing Then
                        LvPrograms.BeginInvoke(New _degUpdateLvPrograms(AddressOf Me.LvPrograms.updateitemsForStation), _station.programs.getPrograms)
                        Me.BeginInvoke(New _degEnableTbSearchProgram(AddressOf updateTbSearchProgram))
                    End If
                End If
            End If
        End SyncLock
    End Sub

    Public Sub setPboxWarningVisibility(ByVal visibility As Boolean)
        SyncLock _lock
            If Not _bClosingFlag Then
                If InvokeRequired Then
                    Me.lblWGA.BeginInvoke(New _degSetWarningVisible(AddressOf setPboxWarningVisibility), New Object() {visibility})
                Else
                    Me.lblWGA.Visible = visibility
                End If
            End If
        End SyncLock
    End Sub

    Public Sub degUpdateLogInfos(ByVal ntSystemLogerrorCount As NtLogEvent.structNtSystemLogErrorCount,
                                 ByVal ntApplicationErrorCount As Integer,
                                 ByVal ntOfficeErrorCount As Integer)

        ' FIXME crash si fermeture onglet 
        SyncLock _lock
            If Not _bClosingFlag Then
                Me.BeginInvoke(New _degLogInfos(AddressOf updateLogInfos), ntSystemLogerrorCount, ntApplicationErrorCount, ntOfficeErrorCount)
            End If
        End SyncLock

    End Sub

    Private Sub updateLogInfos(ByVal ntSystemLogerrorCount As NtLogEvent.structNtSystemLogErrorCount,
                               ByVal ntApplicationErrorCount As Integer,
                               ByVal ntOfficeErrorCount As Integer)

        With ntSystemLogerrorCount
            If Not IsNothing(.iNumDiskBlockErrorOnSystemDisk) Then Me.txtbErrDisque.Text = .iNumDiskBlockErrorOnSystemDisk.ToString
            If Not IsNothing(.iNumNetworkError) Then Me.txtbErrNetwork.Text = .iNumNetworkError.ToString
            If Not IsNothing(.iNumShutdownError) Then Me.txtbErrReboot.Text = .iNumShutdownError.ToString
            If Not IsNothing(.iNumBsobError) Then Me.txtbBsod.Text = .iNumBsobError.ToString
            If Not IsNothing(.iNumDiskPredictFail) Then Me.tbHdFailure.Text = .iNumDiskPredictFail.ToString
            If Not IsNothing(.iNumControllerError) Then Me.tbErrControleur.Text = .iNumControllerError.ToString
            If Not IsNothing(.iNumFtDiskError) Then Me.tbftDiskError.Text = .iNumFtDiskError.ToString
            If Not IsNothing(.iNumNtfsError) Then Me.tbNtfsError.Text = .iNumNtfsError.ToString
        End With

        If Not IsNothing(ntApplicationErrorCount) Then
            Me.tbErrApplication.Text = ntApplicationErrorCount.ToString
        End If
        If Not IsNothing(ntOfficeErrorCount) Then
            Me.tbOfficeErrors.Text = ntOfficeErrorCount.ToString
        End If

        Me.setColorsTxt()
        Me.btnLogDetails.Enabled = True
        Me.btnClearLogs.Enabled = True
        Me.cbLogFilterByDate.Enabled = True
    End Sub

    Private Sub bw_RunWorkerCompleted(ByVal sender As Object,
                                      ByVal e As RunWorkerCompletedEventArgs) Handles _bw.RunWorkerCompleted

        If Not e.Cancelled Then
            If Me.closingFlag Then
                Exit Sub
            End If

            If CBool(e.Result) = False Then
                Me.btnlancer.Enabled = True
                Me.resetForm()

                _station = Nothing

                Exit Sub
            End If

            ' active bouton 'SMART' si stats disques récupérées
            Me.btnPrinterInfos.Enabled = CBool(program.preferences.getStatDisque)
            Me.btEnvVar.Enabled = True

            If _station.iAsynctaskcounter = 0 Then
                Me.ToolStripProgressMain.Visible = False
            End If

            ' statusLabel
            Me.tstripLabelStationName.Text = _station.stationName
            showResults()

            ' démarre mise à jour graphiques
            startUpdateGraphs()

            ' Mets à jour infos Carte réseau
            ' exécuté dans worker séparé 
            '  la récup de la vitesse de la carte par compteur de performance est assez longue entre qques ms et + 10 secondes ... 
            Me.ToolStripProgressMain.Visible = True
            _bw_NetworkInfos.RunWorkerAsync()

            If Not _station.errorMessage Is Nothing Then
                MsgBox(_station.errorMessage, MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox("Traitement abandonné", MsgBoxStyle.Exclamation)
            Me.resetForm()
        End If
    End Sub

    Private Sub switchLaunchButtons(ByVal bool As Boolean)
        For Each button As Button In panelLaunchButtons.Controls
            button.Enabled = bool
        Next
    End Sub

    ''' <summary>
    ''' Affichage résultats
    ''' </summary>
    ''' <remarks>
    ''' Appelé quand Bw.completed 
    ''' </remarks>
    Private Sub showResults()
        '
        ' Maj collapsible panels 
        ' panel network mis à jour dans bw => long pour retrouver interface speed
        '
        updateSystemInfo()
        updateDisplayInfos()
        updateVideoControllerInfos()
        '
        ' si boitier tour ( ML/VL ) change couleur textbox modele
        '
        If _station.gInfoStation.towercase Then
            Me.tbModele.BackColor = Color.Orange
        End If
        '
        ' Maj  services
        '
        If Not _station.listOfService Is Nothing Then
            Me.LvServices.updateItemsForStation(_station)
            Me.tstripLabelNbServices.Text = String.Format("Services : {0} ({1})", _station.listOfService.Count, Service.getNumberOfStartedServices(_station.listOfService))
        End If
        '
        If Not _station.listOfLogicalDisk Is Nothing Then Me.LvInfoDisk.updateitemsForStation(_station)
        ' traitement terminé on réactive le bouton
        Me.btnlancer.Enabled = True
        '  Lance MAJ processes
        tmrUpdateProcessSwitch(True)
        '
        ' connecte graphs sur station en cours
        '
        Me.CpuGraph.connectToStation(_station.stationName)
        Me.FreeMemoryGraph.connectToStation(_station.stationName, _station.gInfoStation.totalPhysicalMemory)
        Me.NetworkIOgraph.connectToStation(_station.stationName)
        Me.DiskIOGraph.connectToStation(_station.stationName)
        '
        ' mise à jour onglet commentaires si sélectionné
        '
        If tbControlMain.SelectedIndex() = 3 Then
            loadCommentaires()
        End If

    End Sub

#Region "CollapsiblePanelUpdate"
    Private Sub updateSystemInfo()
        With _station.gInfoStation
            Me.tbMemoireTotale.Text = functions.convRamAsUlongToString(.totalPhysicalMemory)
            Me.tbConstructeur.Text = .manufacturer
            Me.tbDomaine.Text = .domain
            Me.tbModele.Text = .model
            Me.tbCurrentUser.Text = .userName
            Me.tbSerialNumber.Text = .serialNumber
            Me.tbNbCpu.Text = .numberOfProcessors
            Me.tbHostname.Text = .name
            Me.tbOperatingSystem.Text = .operatingSystem
            Me.tbServicePack.Text = .servicePack
            Me.tbFreeMemory.Text = .freePysicalMemory
            Me.tbProcessor.Text = .processorName
            Me.tbMaxFrequency.Text = .processorMaxClockSpeed
            Me.tbUpTime.Text = .uptime
            Me.tbOsArch.Text = .addressWidth
            Me.tbOsDateInstall.Text = .osInstallDate.ToString
            Me.tbBuild.Text = .version
        End With

        If _station.gInfoStation.addressWidth = "64 bits" Then
            Me.lblOsArchi.Visible = True
        End If

        Me.tbSocle.Text = _station.socle
    End Sub

    ''' <summary>
    ''' MAJ infos cartes graphiques
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub updateVideoControllerInfos()
        Dim controller As Win32_VideoController

        If Not _station.listofVideoController Is Nothing Then
            If _currentVideoControllerIndex = Nothing Then
                _currentVideoControllerIndex = 0
            End If

            If _station.listofVideoController.Count = 0 Then
                program.log.addLogEntry(New cLogEntry("Aucune carte video dans la liste, abandon ", cLogEntry.enumDebugLevel.DEBUG, station.stationName, "updateNetworkInfosNew", Nothing, False))
                Exit Sub
            End If

            controller = _station.listofVideoController(_currentVideoControllerIndex)

            With controller
                Me.tbAdapterRAM.Text = functions.convRamAsUlongToString(.AdapterRAM)
                Me.tbCaption.Text = controller.Caption
                Me.tbVresolution.Text = .CurrentVerticalResolution.ToString
                Me.tbHresolution.Text = .CurrentHorizontalResolution.ToString
                Me.tbRefreshRate.Text = .CurrentRefreshRate.ToString
                If Not .VideoProcessor Is Nothing Then
                    Me.tbVideoProcessor.Text = .VideoProcessor.ToString
                Else
                    Me.tbVideoProcessor.Text = "NA"
                End If
                Me.tbInstalledDriver.Text = .InstalledDisplayDrivers
                Me.tbDriverVersion.Text = .DriverVersion
            End With

            If _station.listofVideoController.Count > 1 Then
                Me.btVideoControllerDetail.Enabled = True
                Me.btVideoControllerNext.Enabled = True
                Me.btVideoControllerPrev.Enabled = True
                Me.lbVideoControllerCount.Text = String.Format("{0}/{1}", _currentVideoControllerIndex + 1, _station.listofVideoController.Count)
            End If
        End If
    End Sub

    Private Sub videoControllerPrevNext(ByVal sender As Object,
                                        ByVal e As System.EventArgs)

        Dim bt As Button = CType(sender, Button)

        If bt.Tag.ToString = "next" Then
            If Not _station.listofVideoController.Count - 1 = _currentVideoControllerIndex Then
                _currentVideoControllerIndex += 1
            End If
        Else
            If _currentVideoControllerIndex <> 0 Then
                _currentVideoControllerIndex -= 1
            End If
        End If

        updateVideoControllerInfos()
    End Sub

    Private Sub updateNetworkInfosNew(Optional ByVal bCheckAllNetworkCardPrm As Boolean = False)
        Dim col As cgInfosStation.networkAdapter = Nothing

        If Not station.gInfoStation.colNetworkAdapter Is Nothing Then
            ' 
            ' check toutes les cartes réseaux pour vérifier si 
            ' réservation / IPFixe 
            ' 
            If bCheckAllNetworkCardPrm Then
                For Each networkAdapter As cgInfosStation.networkAdapter In station.gInfoStation.colNetworkAdapter
                    If networkAdapter.DHCPEnabled = False Then
                        lblDHCP.Visible = True
                    End If
                    If networkAdapter.reservationIP Then
                        lblReservIP.Visible = True
                    End If
                Next
            End If

            If station.gInfoStation.colNetworkAdapter.Count = 0 Then
                program.log.addLogEntry(New cLogEntry("Aucune carte reseau dans la liste, abandon ",
                                                      cLogEntry.enumDebugLevel.DEBUG,
                                                      station.stationName,
                                                      "updateNetworkInfosNew",
                                                      Nothing,
                                                      False)
                                                      )
                Exit Sub
            End If

            col = station.gInfoStation.colNetworkAdapter(_currentNetworkIndex)

            With col
                Me.tbNetConnectionID.Text = .NeTConnectionID
                Me.tbIpAdress.Text = .ipAddress(0)
                If .DefaultIpGateway IsNot Nothing Then
                    Me.tbGateway.Text = .DefaultIpGateway(0)
                End If
                If Not .DHCPEnabled Then
                    Me.tbDHCPEnabled.BackColor = Color.Red
                Else
                    Me.tbDHCPEnabled.BackColor = Color.FromKnownColor(KnownColor.Info)
                End If
                Me.tbDHCPEnabled.Text = .DHCPEnabled.ToString
                Me.tbIpSubnet.Text = .ipSubnet(0)
                Me.tbMACadress.Text = .MACaddress
                Me.tbEstimatedSpeed.Text = perfCounterHelper.formatBytes(.NetworkSpeed)

                If .reservationIP Then
                    lblReservIP.Visible = True
                    tbIpAdress.BackColor = Color.Orange
                Else
                    Me.tbIpAdress.BackColor = Color.FromKnownColor(KnownColor.Info)
                End If

                Me.tbNetworkDriverVersion.Text = .driverVersion
                Me.tbNetworkDriverDate.Text = .driverDate.ToShortDateString
                Me.tbNetworkDriverDesc.Text = .driverDesc
                Me.tbNetworkDriverManufacturer.Text = .driverManufacturer
            End With

            If station.gInfoStation.colNetworkAdapter.Count > 1 Then
                Me.btNetIDetails.Enabled = True
                Me.btPrev.Enabled = True
                Me.btNext.Enabled = True
                Me.lbNetworkCount.Text = String.Format("{0}/{1}", _currentNetworkIndex + 1, station.gInfoStation.colNetworkAdapter.Count)
            End If

        End If
    End Sub

    Private Sub onclick_DetailNetwork() Handles btNetIDetails.Click
        Dim frmNetworkInterfacesDetails = New frmNetworkInterfacesDetails(_station.gInfoStation.colNetworkAdapter)
        frmNetworkInterfacesDetails.Show()
    End Sub

    Private Sub networkPrevNext(ByVal sender As Object,
                                ByVal e As System.EventArgs)

        Dim bt As Button = CType(sender, Button)

        If bt.Tag.ToString = "next" Then
            If Not _station.gInfoStation.colNetworkAdapter.Count - 1 = _currentNetworkIndex Then
                _currentNetworkIndex += 1
            End If

        Else
            If _currentNetworkIndex <> 0 Then
                _currentNetworkIndex -= 1
            End If
        End If

        updateNetworkInfosNew()
    End Sub

    ''' <summary>
    ''' Affiche premier écran trouvé dans la collection
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub updateDisplayInfos()
        If Not _station.edidInfo.listMonitorEdidInfo Is Nothing Then
            If _currentdisplayIndex = Nothing Then
                _currentdisplayIndex = 0
            End If

            If _station.edidInfo.listMonitorEdidInfo.Count > 0 Then
                Dim structMonitorEdidInfo = _station.edidInfo.listMonitorEdidInfo(_currentdisplayIndex)

                With structMonitorEdidInfo
                    Me.tbMonitorName.Text = .monitorName
                    Me.tbMonitorSerialNumber.Text = .serialNumber
                    Me.tbMonitorDisplayName.Text = .displayName
                End With

                If _station.edidInfo.listMonitorEdidInfo.Count > 1 Then
                    Me.btDisplayDetails.Enabled = True
                    Me.btDisplayNext.Enabled = True
                    Me.btDisplayPrev.Enabled = True
                    Me.lbDisplayCount.Text = String.Format("{0}/{1}", _currentdisplayIndex + 1, _station.edidInfo.listMonitorEdidInfo.Count)
                End If
            End If
        End If
    End Sub

    Private Sub displayPrevNext(ByVal sender As Object,
                                ByVal e As System.EventArgs)

        Dim bt As Button = CType(sender, Button)

        If bt.Tag.ToString = "next" Then
            If Not _station.edidInfo.listMonitorEdidInfo.Count - 1 = _currentdisplayIndex Then
                _currentdisplayIndex += 1
            End If

        Else
            If _currentdisplayIndex <> 0 Then
                _currentdisplayIndex -= 1
            End If
        End If

        updateDisplayInfos()
    End Sub

    Private Sub onclick_DetailsDisplay() Handles btDisplayDetails.Click
        ' utiliser cMysqlDisplaysTable 
        ' FIXME
        MsgBox("TODO => utiliser cMysqlDisplaysTable", MsgBoxStyle.Critical)
        'Dim frmDisplayDetails = New frmDisplayDetails(station.edidInfo.listMonitorEdidInfo)
        'frmDisplayDetails.Show()
    End Sub
#End Region

#Region "UpdateGraphs"
    ''' <summary>
    ''' Traite ticks pour mise à jour des Graphs
    ''' tous les doivent etre mis a jour dans cette sub
    ''' </summary>
    ''' <remarks>
    ''' todo Changer le nom de la fonction tmrUpdateGraphControls()
    ''' </remarks>
    Private Sub tmrUpdateGraphsHandler() Handles tmrUpdateGraphs.Tick
        Me.CpuGraph.updateControl()
        Me.FreeMemoryGraph.updateControl()
        Me.NetworkIOgraph.updateControl()
        Me.DiskIOGraph.updateControl()
    End Sub

    ' update Labels
    Private Sub graphNetIOValueUpdated(ByVal i As Single, ByVal o As Single)
        SyncLock _lock
            If Not _bClosingFlag Then
                If Me.InvokeRequired Then
                    Me.BeginInvoke(New _degUpdateLabelNetIO(AddressOf graphNetIOValueUpdated), i, o)
                Else
                    Me.lblNetIO.Text = String.Format("I : {0} / O : {1}", perfCounterHelper.formatBytes(i), perfCounterHelper.formatBytes(o))
                End If
            End If
        End SyncLock
    End Sub

    Private Sub graphDiskIOValueUpdated(ByVal r As Single, ByVal w As Single)
        SyncLock _lock
            If Not _bClosingFlag Then
                If Me.InvokeRequired Then
                    Me.BeginInvoke(New _degUpdateLabelDiskIO(AddressOf graphDiskIOValueUpdated), r, w)
                Else
                    Me.lblDiskIO.Text = String.Format("R : {0} / W : {1}", perfCounterHelper.formatBytes(r), perfCounterHelper.formatBytes(w))
                End If
            End If
        End SyncLock

    End Sub

    Private Sub graphFreeramvalueUpdated(ByVal v As Single)
        SyncLock _lock
            If Not _bClosingFlag Then
                If Me.InvokeRequired Then
                    Me.BeginInvoke(New _degUpdateLabelFreeRam(AddressOf graphFreeramvalueUpdated), v)
                Else
                    Me.lblFreeRam.Text = String.Format("free : {0}", perfCounterHelper.formatBytes(v))
                End If
            End If
        End SyncLock
    End Sub

    Private Sub graphCpuvalueUpdated(ByVal v As Single)
        SyncLock _lock
            If Not _bClosingFlag Then
                If Me.InvokeRequired Then
                    Me.BeginInvoke(New _degUpdatecpu(AddressOf graphCpuvalueUpdated), v)
                Else
                    Me.lblCpuUse.Text = String.Format("Utilisé : {0} %", v)
                End If
            End If
        End SyncLock
    End Sub

    Private Sub startUpdateGraphs()
        Me.tmrUpdateGraphs.Enabled = True
    End Sub

    Public Sub StopUpdateGraphs()
        Me.tmrUpdateGraphs.Enabled = False
        '
        Me.CpuGraph.clear()
        Me.FreeMemoryGraph.clear()
        Me.NetworkIOgraph.clear()
        Me.DiskIOGraph.clear()
        '
        Me.lblCpuUse.Text = ""
        Me.lblDiskIO.Text = ""
        Me.lblNetIO.Text = ""
        Me.lblFreeRam.Text = ""
    End Sub
#End Region

    Private Sub setColorsTxt()
        For Each Control As Control In Me.GroupBoxResults.Controls
            If TypeOf (Control) Is TextBox Then
                If Control.Text <> "" Then
                    If CDbl(Control.Text) > 0 Then
                        Control.BackColor = Color.Red
                    Else
                        Control.BackColor = Color.LightGreen
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub resetColorsTxt()
        For Each Control As Control In Me.GroupBoxResults.Controls
            If TypeOf Control Is TextBox Then Control.BackColor = Color.LightGray
        Next
    End Sub

#Region " gestion des menus"

    Private Sub OrganiserToolStripMenuItem_Click(ByVal sender As System.Object,
                                                 ByVal e As System.EventArgs)

        Dim frmOpened As Boolean = False
        For Each frm As Form In System.Windows.Forms.Application.OpenForms
            If frm.Name = "frmOrganiserFavoris" Then
                frm.Focus()
                frm.WindowState = FormWindowState.Normal
                frmOpened = True
                Exit For
            End If
        Next
        If Not frmOpened Then
            Dim frmOrganiserFavoris = New frmOrganiserFavoris
            frmOrganiserFavoris.Show()
        End If

    End Sub

    Private Sub AfficherPanneauLatéralToolStripMenuItem_Click(ByVal sender As Object,
                                                              ByVal e As System.EventArgs) Handles ToolStripMenuItemPanneauLateral.Click

        Dim tsmi As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        tsmi.Checked = Not tsmi.Checked
        Me.SplitContainer3.Panel2Collapsed = Not ToolStripMenuItemPanneauLateral.Checked

    End Sub

    Private Sub AfficherLogsToolStripMenuItem_Click(ByVal sender As Object,
                                                    ByVal e As System.EventArgs) Handles ToolStripMenuItemLogs.Click

        Dim tsmi As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        tsmi.Checked = Not tsmi.Checked
        Me.SplitContainer2.Panel2Collapsed = Not Me.SplitContainer2.Panel2Collapsed

        program.preferences.bLogPanelCollapse = Me.SplitContainer2.Panel2Collapsed

    End Sub

    Private Sub QuitterToolStripMenuItem1_Click(ByVal sender As System.Object,
                                                ByVal e As System.EventArgs) Handles QuitterToolStripMenuItem1.Click
        Application.Exit()
    End Sub

    Private Sub InfosUtilisateurToolStripMenuItem_Click(ByVal sender As System.Object,
                                                        ByVal e As System.EventArgs) Handles InfosUtilisateurToolStripMenuItem1.Click

        showfrmLDAPUSER()
    End Sub

    Private Sub InfosHDDToolStripMenuItem_click(ByVal sender As System.Object,
                                                ByVal e As System.EventArgs) Handles InfosHDDToolStripMenuItem.Click

        If _station Is Nothing Then Return

        Dim frm As Form = getFrmByName("frmHddInfos")

        If frm IsNot Nothing Then
            Dim frmDetailsHDD As frmHddInfos = CType(frm, frmHddInfos)

            If frmDetailsHDD.stationName = Me.station.stationName Then
                frm.Focus()
                frm.WindowState = FormWindowState.Normal
            Else
                frm.Close()
                frm.Dispose()
                frm = New frmHddInfos(_station.stationName, _station.listOfDiskDrive)
                frm.Show()
            End If
        Else
            frm = New frmHddInfos(_station.stationName, _station.listOfDiskDrive)
            frm.Show()
        End If

    End Sub

    ''' <summary>
    ''' ouvre console 
    ''' PPID = analog donc en théorie ouvre console admin ...
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OuvrirConsoleCtrlkToolStripMenuItem_Click(sender As Object,
                                                          e As EventArgs) Handles OuvrirConsoleCtrlkToolStripMenuItem.Click

        Dim prc As New System.Diagnostics.Process

        With prc
            .StartInfo.Arguments = " /k cd c:/"
            .StartInfo.FileName = "cmd"
            .Start()
            .Dispose()
        End With
    End Sub
#Region "Psexec"
    Private Sub DefragToolStripMenuItem_Click(ByVal sender As System.Object,
                                              ByVal e As System.EventArgs) Handles DefragToolStripMenuItem.Click
        psExec.defrag(_station.stationName)
    End Sub

    Private Sub DefragAnalyseToolStripMenuItem_Click(ByVal sender As System.Object,
                                                     ByVal e As System.EventArgs) Handles DefragAnalyseToolStripMenuItem.Click
        psExec.defrag(_station.stationName, True)
    End Sub

    Private Sub RedémarrerToolStripMenuItem_Click(ByVal sender As System.Object,
                                                  ByVal e As System.EventArgs) Handles RedémarrerToolStripMenuItem.Click
        psExec.shutdownOrReboot(_station.stationName, True)
    End Sub

    Private Sub RedémarrerForcerToolStripMenuItem_Click(ByVal sender As System.Object,
                                                        ByVal e As System.EventArgs) Handles RedémarrerForcerToolStripMenuItem.Click
        psExec.shutdownOrReboot(_station.stationName, True, True)
    End Sub

    Private Sub ArreterToolStripMenuItem_Click(ByVal sender As System.Object,
                                               ByVal e As System.EventArgs) Handles ArreterToolStripMenuItem.Click
        psExec.shutdownOrReboot(_station.stationName)
    End Sub

    Private Sub ArrêterForcerToolStripMenuItem_Click(ByVal sender As System.Object,
                                                     ByVal e As System.EventArgs) Handles ArreterForcerToolStripMenuItem.Click
        psExec.shutdownOrReboot(_station.stationName, False, True)
    End Sub

    Private Sub ChkdskF_Click(ByVal sender As System.Object,
                              ByVal e As System.EventArgs) Handles ChkdskFToolStripMenuItem.Click
        psExec.chkdsk(_station.stationName)
    End Sub

    Private Sub ChkdskFR_Click(ByVal sender As System.Object,
                               ByVal e As System.EventArgs) Handles ChkdskFRToolStripMenuItem.Click
        psExec.chkdsk(_station.stationName, True)
    End Sub


    Private Sub ConsoleToolStripMenuItem_Click(sender As Object,
                                               e As EventArgs) Handles ConsoleToolStripMenuItem.Click
        If _station Is Nothing OrElse _station.stationName = String.Empty Then
            Exit Sub
        End If

        psExec.openRemotConsole(_station.stationName)
    End Sub

    Private Sub VNCQueryConnectToolStripMenuItem_Click(ByVal sender As System.Object,
                                                       ByVal e As System.EventArgs) Handles VNCQueryConnectToolStripMenuItem.Click
        Dim stationName As String = station.stationName

        Try
            cregistry.SetVNCQueryConnect(stationName)
        Catch ex As Exception
            MsgBox(String.Format("Une erreur s'est produite !" & System.Environment.NewLine & "Message : {0}", ex.Message.ToString), MsgBoxStyle.Exclamation, String.Format("SetVncQueryConnect : {0}", stationName))
        End Try
    End Sub

    Private Sub VNCNotificationToolStripMenuItem_Click(ByVal sender As System.Object,
                                                       ByVal e As System.EventArgs) Handles VNCNotificationToolStripMenuItem.Click
        Dim errMessage As String = ""
        Dim stationName As String = station.stationName
        Dim ok As Boolean = cregistry.SetVNCNotification(stationName, errMessage)

        If Not ok Then
            MsgBox(String.Format("Une erreur s'est produite !" & System.Environment.NewLine & "Message : {0}", errMessage), MsgBoxStyle.Exclamation, String.Format("SetVncNotification : {0}", stationName))
        End If
    End Sub

    Private Sub SCCMValidationToolStripMenuItem_Click(ByVal sender As System.Object,
                                                      ByVal e As System.EventArgs) Handles SCCMValidationToolStripMenuItem.Click
        Try
            cregistry.SetSCCMViewerQueryConnect(station.stationName)
        Catch ex As Exception
            MsgBox(String.Format("Une erreur s'est produite !" & System.Environment.NewLine & "Message : {0}", ex.Message.ToString), MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RsopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RsopToolStripMenuItem.Click
        Dim frmrsop As New frmRsop(_station.stationName, _station.gInfoStation.userName)
        frmrsop.Show()
    End Sub
#End Region

#End Region

    Private Sub cmbStationName_TextChanged(ByVal sender As Object,
                                           ByVal e As System.EventArgs)

        Dim cmbb As ComboBox = CType(sender, ComboBox)

        If cmbb.Text = "" Then
            Me.btnlancer.Enabled = False
        Else
            Me.btnlancer.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' gère les filtres sur programmes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ckbFilterPrograms(ByVal sender As Object,
                                  ByVal e As System.EventArgs)

        Dim ckb As CheckBox = CType(sender, CheckBox)

        ' désactive les filtres autres que celui sélectionné ( pas deux à la fois ... )
        For Each Button As CheckBox In PanelProgramFilterButtons.Controls
            If Button.Name <> ckb.Name Then Button.Checked = False
        Next

        If ckb.Name = "ckbHighlistProgDiff" Then
            If ckb.Checked Then
                Me.PanelLegendProgramDiff.Visible = True
                Me.LvPrograms.filterProgramsDiff(_station.programs.getPrograms(True))
            Else
                Me.PanelLegendProgramDiff.Visible = False
                Me.LvPrograms.restoreItemscolor()
            End If

            Exit Sub
        End If

        _station.programs.setFilterProgram(ckb, _station.offlineMode)
        Me.LvPrograms.updateitemsForStation(_station.programs.getPrograms(_station.offlineMode))
    End Sub

    Private Sub searchforProgram() Handles tbSearchProgram.TextChanged
        ' on désactive les filtres 
        For Each Button As CheckBox In PanelProgramFilterButtons.Controls
            Button.Checked = False
        Next
        Me.ckbHighlistProgDiff.Checked = False

        If Not station Is Nothing Then
            station.programs.setfilterProgram(tbSearchProgram.Text, station.offlineMode)
            Me.LvPrograms.updateitemsForStation(_station.programs.getPrograms)
        End If
    End Sub


    ''' <summary>
    ''' Mets à jour les boutons de filtre programmes
    ''' 
    ''' ==> à supprimer car les boutons sont tous invisibles 
    ''' </summary>
    Private Sub updateTbSearchProgram()
        Me.tbSearchProgram.Enabled = True

        For Each CheckBox As CheckBox In PanelProgramFilterButtons.Controls
            ' If CheckBox.Visible = True Then
            CheckBox.Enabled = True
            'End If
        Next
    End Sub

    ''' <summary>
    ''' Retrouve un frm ouvert par son Nom (frm.name)
    ''' renvoie Nothing si le form n'est pas ouvert
    ''' </summary>
    ''' <param name="frmName"></param>
    ''' <returns>Form</returns>
    ''' <remarks></remarks>
    Private Function getFrmByName(ByVal frmName As String) As Form
        Dim frm As Form = Application.OpenForms.Item(frmName)

        If frm Is Nothing Then
            Return Nothing
        Else
            Return frm
        End If
    End Function

    ''' <summary>
    ''' Gestion de la touche entrée en fonction du controle qui a le focus
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub analog_keyPressed(ByVal sender As Object,
                                  ByVal e As KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Return
                If tbSearchCommentaire.Focused Then
                    btSearchCommentaireClick()
                Else
                    If Not _cCommentDisplay Is Nothing Then
                        If Not _cCommentDisplay.bediting Then
                            If Me.btnlancer.Enabled Then
                                If Not rtbCommentairesInput.Focused Then
                                    Me.Lancer_Click()
                                End If
                            End If
                        End If
                    End If
                End If
        End Select

    End Sub

    ''' <summary>
    ''' Exécuté à la fermeture du form
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    Private Sub frmMain_FormClosing(ByVal sender As System.Object,
                                    ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If e.CloseReason = CloseReason.MdiFormClosing Then
            e.Cancel = True
            Return
        End If

        closingFlag = True

        If Not _pinger Is Nothing Then
            _pinger.stopPing()
            _pinger = Nothing
        End If

        program.frmMdiContainer.removeTab(Me)

        _tooltip.Dispose()

        '
        ' abandonne les background workers si en cours ....
        '
        If Not _bw_NetworkInfos Is Nothing Then
            With _bw_NetworkInfos
                .CancelAsync()
                .Dispose()
            End With
        End If
        If Not _bw Is Nothing Then
            With _bw
                .CancelAsync()
                .Dispose()
            End With
        End If

        If Not Me.LvProcess.processConnection Is Nothing Then
            Me.LvProcess.processConnection.isCanceled = True
        End If

        Me.LvProcess.ClearItems()
        '
        ' Cleanup Timers
        '
        With tmrUpdateProcess
            .Stop()
            .Dispose()
        End With
        With tmrUpdateGraphs
            .Stop()
            .Dispose()
        End With
        With tmrTryReconnect
            .Stop()
            .Dispose()
        End With
        '
        ' Cleanup ListViews
        '
        Me.LvPrograms.dispose()
        Me.LvInfoDisk.dispose()
        Me.lvLog.Dispose()
        Me.Lvping.Dispose()
        Me.LvProcess.dispose()
        Me.LvServices.dispose()


        '------- Ajout Cleanup Code ------------------
        My.Resources.cross_circle16.Dispose()
        My.Resources.ok16.Dispose()

        '
        ' Cleanup Graphiques
        '
        RemoveHandler NetworkIOgraph.valueUpdated, AddressOf graphNetIOValueUpdated
        RemoveHandler DiskIOGraph.valueUpdated, AddressOf graphDiskIOValueUpdated
        RemoveHandler FreeMemoryGraph.valueUpdated, AddressOf graphFreeramvalueUpdated
        RemoveHandler CpuGraph.valueUpdated, AddressOf graphCpuvalueUpdated
        '
        NetworkIOgraph.Dispose()
        DiskIOGraph.Dispose()
        FreeMemoryGraph.Dispose()
        CpuGraph.Dispose()
        '
        Me.ToolStripMenuAffichage.Dispose()
        Me.ToolStripMenuItem1.Dispose()
        Me.ToolStripMenuItem2.Dispose()
        Me.ToolStripMenuItem3.Dispose()
        Me.ToolStripMenuItemLogs.Dispose()
        Me.ToolStripMenuItemPanneauLateral.Dispose()
        Me.ToolStripMenuOutils.Dispose()
        Me.ToolStripProgressMain.Dispose()
        Me.ToolStripSeparator1.Dispose()
        Me.ToolStripStatusConx.Image.Dispose()
        Me.ToolStripStatusConx.Dispose()

        '
        'Supprime handlers pour MAJ logs
        '
        RemoveHandler log.eventLogItemAdded, AddressOf addLvItemEventHandler
        '
        RemoveHandler Me.tbControlMain.SelectedIndexChanged, AddressOf tabChanged_handler

        If Not _station Is Nothing Then
            RemoveHandler _station.wmi.disconnected, AddressOf Me.disconnectedHandler
            RemoveHandler _station.wmi.connected, AddressOf Me.connectedHandler

            _station.wmi.disconnect(False, Nothing, True)

            _station = Nothing
        End If

        '
        ' Supression handlers Collapsible Panel 

        ' TODO collapsilbe to flow
        'CollapsiblePanelHandlerRegister(remove:=True)
        '
        ' sauve log Panel collapse status
        '
        'With program.preferences
        '    '.IlogPanelSplitterDistance = Me.SplitContainer2.SplitterDistance
        'End With

    End Sub

#Region "ContextMenuDisk"
    Private Sub OuvrirToolStripMenuItem_Click(ByVal sender As System.Object,
                                              ByVal e As System.EventArgs) Handles LvInfoDisk.DoubleClick

        Dim diskpart As String = String.Empty
        Dim disktype As String = String.Empty

        If Me.LvInfoDisk.getSelectedItemsDriveInfos(diskpart, disktype) Then
            Analog.functions.misc.openShellExplorer(disktype, diskpart, _station.stationName)
        End If
    End Sub

    Private Sub smartToolStripMenuItem_click(ByVal sender As System.Object,
                                             ByVal e As System.EventArgs) Handles SMARTToolStripMenuItem.Click

        If Not LvInfoDisk.SelectedItems.Count = 0 Then

            Dim driveId As String = LvInfoDisk.SelectedItems(0).SubItems(1).Text
            Dim driveType As String = LvInfoDisk.SelectedItems(0).SubItems(0).Text

            If driveType <> "Local" Then
                MsgBox("Smart n'est supporté que pour les disques locaux...", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If Not driveId Is Nothing Then
                Dim frmSmart As New frmSmart(driveId, _station.smart, _station.stationName)
                frmSmart.Show()
            End If
        End If
    End Sub

#End Region

#Region "gestion Log"
    Public Sub addLvItemEventHandler(ByVal logEntry As cLogEntry)
        SyncLock _lock
            If Not closingFlag Then
                If Me.InvokeRequired Then
                    Me.BeginInvoke(New _degAddLvItem(AddressOf addLvItemEventHandler), New Object() {logEntry})
                Else
                    If station Is Nothing Then
                        Exit Sub
                    Else
                        If logEntry.stationName <> station.stationName Then
                            Exit Sub
                        End If
                    End If

                    If Me.lvLog.Items.Count > 300 Then
                        Me.lvLog.Items.RemoveAt(0)
                    End If

                    Dim lvi As New ListViewItem(logEntry.getFormattedEntry)
                    lvi.UseItemStyleForSubItems = False ' nécessaire sinon les couleurs disparaissent ....

                    Select Case logEntry.debugLevel
                        Case cLogEntry.enumDebugLevel.DEBUG
                            lvi.ForeColor = Color.Red
                        Case cLogEntry.enumDebugLevel.ERREUR
                            lvi.ForeColor = Color.Blue
                        Case Else
                            ' ??
                    End Select

                    Me.lvLog.Items.Add(lvi)

                    If Not Control.MouseButtons = Windows.Forms.MouseButtons.Left Then
                        lvi.EnsureVisible()
                    End If

                End If
            End If
        End SyncLock
    End Sub
#End Region

#Region "Commentaires"
    Private Sub btSearchCommentaireClick()
        Dim searchExpr As String = Trim(tbSearchCommentaire.Text)
        _cCommentDisplay.dispose()

        _cCommentDisplay.displayComment(cMysqlcommentaires.searchCommentairesFor(searchExpr))
    End Sub

    Private Sub btLastComments_Click(ByVal sender As System.Object,
                                     ByVal e As System.EventArgs) Handles btLastComments.Click

        _cCommentDisplay.dispose()

        _cCommentDisplay.displayComment(cMysqlcommentaires.getLastComments)
    End Sub

    Private Sub rtbCommentairesInput_cliked_enter() Handles rtbCommentairesInput.TextChanged, rtbCommentairesInput.Enter
        If Trim(rtbCommentairesInput.Text) = String.Empty Then
            btnSendCommentaire.Enabled = False
        Else
            btnSendCommentaire.Enabled = True
        End If
    End Sub

    Private Sub btSendCommentaireClick() Handles btnSendCommentaire.Click
        Dim stationName As String = Nothing

        If Not station Is Nothing Then
            If Me.cbAssocierStation.Checked Then
                stationName = station.stationName
            End If
        End If

        If Not CBool(cMysqlcommentaires.sendCommentaire(Me.rtbCommentairesInput.Text, stationName)) Then
            MsgBox("echec envoie commentaire")
        End If

        Me.rtbCommentairesInput.Clear()
    End Sub

    Private Sub loadCommentaires()
        Me.rtbCommentairesInput.Clear()
        Me._cCommentDisplay.dispose()

        If Not station Is Nothing Then
            '_cCommentDisplay.displayComment(cCommentaire.getAllCommentForStation(station.stationName))
            _cCommentDisplay.displayComment(cMysqlcommentaires.getCommentairesForStation(station.stationName))
        End If
    End Sub

    Private Sub tabChanged_handler(ByVal sender As Object, ByVal e As EventArgs)
        If tbControlMain.SelectedTab.Name = "TabCommentaires" Then
            If Not _cCommentDisplay.bLoaded Then
                loadCommentaires()
            End If
        End If
    End Sub
#End Region

#Region "Button Handlers"
    ''' <summary>
    ''' Ouvre mmc gestion de l'ordinateur
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btComptMgmt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btComptMgmt.Click
        If station Is Nothing Then
            Exit Sub
        End If

        Dim prc As New System.Diagnostics.Process()

        With prc
            .StartInfo.FileName = "compmgmt.msc"
            .StartInfo.Arguments = " /computer:\\" & station.stationName
            .Start()
            .Dispose()
        End With

    End Sub

    ''' <summary>
    ''' formulaire affichage variables environement système
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btEnvVar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEnvVar.Click
        Dim frm As New frmEnvVar(_station)
        frm.Show()
    End Sub

    Private Sub btPingReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btResetPing.Click
        If Not _pinger Is Nothing Then
            Me.tbPingLOst.BackColor = Color.White

            Me.Lvping.Items.Clear()
            _pinger.resetPingData()
        End If
    End Sub

    Private Sub btnFrmBatch_Click(ByVal sender As System.Object,
                                  ByVal e As System.EventArgs) Handles btnFrmBatch.Click

        If Not program.frmMdiContainer.isTabAlreadyOpened("ScanParc") Then
            program.frmMdiContainer.addScanTab()
        End If

    End Sub

    '''
    ''' cherche si frm nettoyage déja ouvert 
    ''' pour la station en cours, si oui focus sur le frm  sinon => new
    '''
    Private Sub btnCleanStation_Click(ByVal sender As System.Object,
                                      ByVal e As System.EventArgs) Handles btnCleanStation.Click

        If String.IsNullOrEmpty(_station.gInfoStation.version) Then
            MsgBox("Impossible de déterminer version OS" & vbNewLine & "Merci d'attendre la fin de du scan et de réessayer", MsgBoxStyle.OkOnly, "Erreur")
            Exit Sub
        End If

        Dim frmName As String = String.Format("cleanfrm_{0}", _station.stationName)
        Dim frm As Form = getFrmByName(frmName)

        If frm IsNot Nothing Then
            frm.Focus()
            frm.WindowState = FormWindowState.Normal
        Else
            frm = New cleanForm(_station.stationName, _station.gInfoStation.version)
            frm.Show()
        End If
    End Sub

    Private Sub btnVnc_Click(ByVal sender As System.Object,
                             ByVal e As System.EventArgs) Handles btnVnc.Click

        Dim prc As New System.Diagnostics.Process()
        Dim sVncPath As String = program.preferences.sVncPath

        If Not System.IO.File.Exists(sVncPath) Then
            MsgBox("Impossible de trouver l'exécutable VNC : " & program.preferences.sVncPath & vbNewLine _
                    & "Veuillez vérifier dans les préférences que le chemin vers VNC est correct", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        With prc
            .StartInfo.FileName = sVncPath
            .StartInfo.Arguments = String.Format("-username {0} {1}", functions.getDomainUserIdentity(), station.stationName)
            .Start()
            .Dispose()
        End With
    End Sub

    Private Sub btScmRdp_Click(ByVal sender As System.Object,
                            ByVal e As System.EventArgs) Handles btScmRdp.Click

        Dim cmRcViewerPath As String = program.preferences.sSccmPath
        Dim sccmServer As String = "sccmsmp.chu-bordeaux.fr"
        Dim stationName As String = station.stationName

        If Not System.IO.File.Exists(cmRcViewerPath) Then
            MsgBox("Viewer introuvable ! Vérifiez installation console Sccm ...", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Using prc As New System.Diagnostics.Process()
            With prc
                .StartInfo.FileName = cmRcViewerPath
                .StartInfo.Arguments = String.Format(" {0} \\{1}", stationName, sccmServer)
                .Start()
            End With
        End Using
    End Sub

    Private Sub btnPrinterInfos_Click(ByVal sender As System.Object,
                                      ByVal e As System.EventArgs) Handles btnPrinterInfos.Click

        If String.IsNullOrEmpty(_station.gInfoStation.userName) Or
                _station.gInfoStation.userName = "NA" Then
            MsgBox("aucun profil actif")
            Exit Sub
        End If

        Dim frmPrinterList As New frmPrinterList(_station.stationName, _station.gInfoStation.userName)
        frmPrinterList.Show()

    End Sub

    Private Sub btnDetailsErr_Click(ByVal sender As Object,
                                    ByVal e As System.EventArgs) Handles btnLogDetails.Click

        If _station.ntSystemLog IsNot Nothing Then
            Dim frm As Form = getFrmByName("frmDetailsErr")

            If frm IsNot Nothing Then
                Dim frmDetailsErr As frmDetailsErr = CType(frm, frmDetailsErr)

                If frmDetailsErr.stationName = Me.station.stationName Then
                    frm.Focus()
                    frm.WindowState = FormWindowState.Normal
                Else
                    frm.Close()
                    frm.Dispose()
                    frm = New frmDetailsErr(_station, Me.cbLogFilterByDate.Checked)
                    frm.Show()
                End If
            Else
                frm = New frmDetailsErr(_station, Me.cbLogFilterByDate.Checked)
                frm.Show()
            End If
        End If
    End Sub

    Private Sub btfrmDetailPing_Click(ByVal sender As System.Object,
                                      ByVal e As System.EventArgs) Handles btDetailPing.Click

        If Not Me.station Is Nothing Then
            Dim frm As Form = getFrmByName("frmDetailPing")

            If frm IsNot Nothing Then
                Dim frmDetailPing As frmDetailPing = CType(frm, frmDetailPing)

                If frmDetailPing.stationName = Me.station.stationName Then
                    frm.Focus()
                    frm.WindowState = FormWindowState.Normal
                Else
                    frm.Close()
                    frm.Dispose()
                    frm = New frmDetailPing(_pinger.getNewDataArray, Me.station.stationName)
                    frm.Show()
                End If
            Else
                frm = New frmDetailPing(_pinger.getNewDataArray, Me.station.stationName)
                frm.Show()
            End If
        End If
    End Sub

    Private Sub btUserInfos_Click(ByVal sender As System.Object,
                                  ByVal e As System.EventArgs) Handles btUserInfos.Click

        showfrmLDAPUSER()
    End Sub

    Private Sub showfrmLDAPUSER()
        Dim frm As Form = getFrmByName("frmInfoLDAPUser")

        If frm IsNot Nothing Then
            frm.Focus()
            frm.WindowState = FormWindowState.Normal
        Else
            frmInfoLDAPUser.Show()

            If tbCurrentUser.Text <> "NA" _
            And tbCurrentUser.Text <> String.Empty Then
                frmInfoLDAPUser.user = tbCurrentUser.Text.Split((CChar("\")))(1)
                frmInfoLDAPUser.getUserInfosAsync()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Efface logs
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btClearLogs_Click(ByVal sender As System.Object,
                                  ByVal e As System.EventArgs) Handles btnClearLogs.Click

        Dim frmClearlogs As frmClearLogs = New frmClearLogs(_station.stationName)
        frmClearlogs.ShowDialog()
    End Sub
#End Region

    Private Sub cbLogFilterByDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLogFilterByDate.Click
        If station IsNot Nothing Then
            station.ntLogAnalyseWithfilter(cbLogFilterByDate.Checked)
        End If
    End Sub

    Private Sub cbChangeBufferSizePing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbChangeBufferPingSize.Click
        If Not _pinger Is Nothing Then
            If cbChangeBufferPingSize.Checked Then
                _pinger.changeBufferSize(cAsyncPinger.pingBufferDataLenght.pingLong)
            Else
                _pinger.changeBufferSize(cAsyncPinger.pingBufferDataLenght.pingNormal)
            End If
        End If
    End Sub

    Private Sub btCreatePingReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCreatePingReport.Click
        If Not _pinger Is Nothing Then
            Clipboard.SetData(DataFormats.Text, CType(_pinger.getPingReport, Object))
        End If
    End Sub

    Private Sub NouvelOngletToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouvelOngletToolStripMenuItem1.Click
        program.frmMdiContainer.addTab()
    End Sub

    Private Sub ScanImprimantesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScanImprimantesToolStripMenuItem.Click

        If Not program.frmMdiContainer.isTabAlreadyOpened("Scan Impr.") Then
            program.frmMdiContainer.addScanPrinterTab()
        End If

    End Sub

    Private Sub FlushdnsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FlushdnsToolStripMenuItem.Click
        native.api.nativeFunctions.DnsFlushResolverCache()
    End Sub

    Private Sub FermerOngletToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FermerOngletToolStripMenuItem.Click
        Me.Close()
        program.frmMdiContainer.removeTab(Me)
    End Sub
End Class