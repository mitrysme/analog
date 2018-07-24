Imports MDIWindowManager

Public Class frmMdiContainer

    Private _poppedOutWrappedWindowlist As List(Of WrappedWindow) = New List(Of WrappedWindow) ' liste fenetres détachées du window manager
    Private WithEvents _windowManager As WindowManagerPanel

    Public ReadOnly Property windowManager() As WindowManagerPanel
        Get
            Return _windowManager
        End Get
    End Property

    Public Sub New()
        MyBase.new()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Charge menu favoris
        LoadMenuFavorisFromPreferences()
        ' Add any initialization after the InitializeComponent() call.
        Me.KeyPreview = True ' nécessaire pour pouvoir créer un onglet si tous fermés 
        Me.Text = "Analog"
        Me.IsMdiContainer = True
        Me.MainMenuStrip.MdiWindowListItem = ToolStripMenuItemApplication
        Me.AllowDrop = True ' autorise drag and drop
        '
        ' Menu à propos en dernier
        '
        Me.ToolStripMenuApropos.MergeAction = MergeAction.Insert
        Me.ToolStripMenuApropos.MergeIndex = 6

        _windowManager = New WindowManagerPanel

        With _windowManager
            .AutoDetectMdiChildWindows = False
            .Visible = True
            .Style = TabStyle.AngledHiliteTabs
            .ShowLayoutButtons = True
            .AutoHide = False ' cache controle si plus d'onglets visibles.
            .ShowTitle = False
            .Height = 30
        End With

        Me.Controls.Add(_windowManager)
    End Sub

#Region "Event Handlers"

    Private Sub poppedOutWrappedWindowEventHandler(ByVal sender As Object, _
                                                   ByVal e As MDIWindowManager.WrappedWindowCancelEventArgs) Handles _windowManager.WindowPoppingOut
        _poppedOutWrappedWindowlist.Add(e.WrappedWindow)
    End Sub

    Private Sub poppedInWrappedWindowEventHandler(ByVal sender As Object, _
                                                  ByVal e As MDIWindowManager.WrappedWindowCancelEventArgs) Handles _windowManager.WindowPoppingIn
        _poppedOutWrappedWindowlist.Remove(e.WrappedWindow)
    End Sub

    Private Sub windowActivatedEventHandler(ByVal sender As Object, _
                                            ByVal e As MDIWindowManager.WrappedWindowEventArgs) Handles _windowManager.WindowActivated

        setWindowTitle(e.WrappedWindow.Window)

    End Sub

    Private Sub beforeWrappedWindowAddedEventHandler(ByVal sender As Object, _
                                                     ByVal e As MDIWindowManager.WrappedWindowCollection.ItemsCancelEventArgs) Handles _windowManager.BeforeWrappedWindowAdded

        setWindowTitle(e.WrappedWindow.Window)

    End Sub

    Private Sub beforeWrappedWindowRemovedEventHandler(ByVal sender As Object, _
                                                       ByVal e As MDIWindowManager.WrappedWindowCollection.ItemsCancelEventArgs) Handles _windowManager.BeforeWrappedWindowRemoved

        If Not _windowManager.GetActiveWindow Is Nothing Then
            setWindowTitle(_windowManager.GetActiveWindow.Window)
        End If

    End Sub

    Public Sub addTab(Optional ByVal stationName As String = Nothing) Handles _windowManager.addNewTab
        _windowManager.AddWindow(New frmMain)

        If stationName IsNot Nothing Then
            CType(_windowManager.GetActiveWindow.Window, frmMain).startScan(stationName)
        End If
    End Sub

    Public Sub addTabPrinter(ByVal printerName As String, ByVal ldapPrinterProps As ldapWrapper.ldapPrinterProperties)
        _windowManager.AddWindow(New frmWebBrowser(printerName, ldapPrinterProps))
    End Sub

#End Region

    ''' <summary>
    ''' Force refresh des tabs 
    ''' Si pas appelé l'icone de la fenetre ne se mets pas à jour avant qu'un invalidate ne soit reçut
    ''' TODO : pas optimal car on pourrait peut etre redessiner que le tab concerné et pas tout le contrôle .... 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub forceTabRepaint()
        _windowManager.Refresh()
    End Sub

    Public Sub removeTab(ByRef frm As Form)
        _windowManager.RemoveWindow(frm)
    End Sub

    Public Sub addScanTab()
        _windowManager.AddWindow(New frmDatagridScan)

        getTabListName()
    End Sub

    Public Sub addScanPrinterTab()
        _windowManager.AddWindow(New frmPrinterScan)

        getTabListName()
    End Sub

    Public Function getTabListName() As List(Of String)
        Dim windowsList As WrappedWindowCollection = _windowManager.GetAllWindows
        Dim listTabNames As New List(Of String)

        For Each ww As WrappedWindow In _windowManager.GetAllWindows
            listTabNames.Add(ww.Window.Text)
        Next

        Return listTabNames
    End Function

    Public Function getActiveFrm() As Form
        If _windowManager.GetActiveWindow Is Nothing Then
            Return Nothing
        Else
            Return _windowManager.GetActiveWindow.Window
        End If
    End Function

    Public Sub setFrmTitleText(Optional ByVal text As String = "")
        If String.IsNullOrEmpty(text) Then
            Me.Text = "Analog"
        Else
            Me.Text = String.Format("Analog : {0}", text)
        End If
    End Sub

    Private Sub setWindowTitle(ByRef frm As Form)
        Select Case frm.GetType.Name
            Case "frmMain"
                Dim frmMain As frmMain = CType(frm, frmMain)
                If Not frmMain.station Is Nothing Then
                    setFrmTitleText(frmMain.station.stationName)
                Else
                    setFrmTitleText()
                End If
            Case "frmDatagridScan"
                setFrmTitleText("ScanParc")
            Case "frmPrinterScan"
                setFrmTitleText("Scan Impr.")
            Case "frmWebBrowser"
                setFrmTitleText(frm.Name)
        End Select
    End Sub

    'Public Sub removeWrappedWindow(ByVal frm As Form)
    '    frm.MdiParent = Nothing
    '    _windowManager.RemoveWindow(frm)
    'End Sub

    ' Affiche un frmMain au démarrage
    Private Sub frmLoad() Handles Me.Load
        '
        '  rétablit position fenêtre si nécessaire
        '
        If program.preferences.bSaveWindowPos Then
            preferences.LoadFormPositionAndSize(Me, "sFrmMainPosAndSize")
        End If
        '
        ' Restauration Onglets session
        '
        If program.preferences.bSaveSessionTabs Then
            Dim tabListString = program.preferences.stabOpenLIst
            If tabListString IsNot Nothing Then
                If tabListString = String.Empty Then
                    _windowManager.AddWindow(New frmMain)
                Else
                    Dim listOfTabs As List(Of String) = tabListString.Split(CChar(";")).ToList
                    listOfTabs.Remove(listOfTabs.Last)

                    openMultipleTabs(listOfTabs)
                End If
            End If
        Else
            _windowManager.AddWindow(New frmMain)
        End If

        'LeakAddTabTest()
        'openManyTabs()
        'continuousScan(3000)
    End Sub

    Private Sub form_dragEnter(ByVal sender As Object, _
                          ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim fileName As String = CType(e.Data.GetData(DataFormats.FileDrop), String())(0)
            Dim fileExt As String = System.IO.Path.GetExtension(fileName)
            If fileExt = ".txt" Then
                e.Effect = DragDropEffects.Move
            Else
                e.Effect = DragDropEffects.None
            End If
        End If
    End Sub

    Private Sub form_dragDrop(ByVal sender As Object, _
                          ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop


        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
        Dim fileFullPath As String = files(0)
        Dim arrStation As New List(Of String)

        Try
            Using sr As New IO.StreamReader(fileFullPath)
                While Not sr.EndOfStream
                    arrStation.Add(sr.ReadLine)
                End While
            End Using
        Catch ex As Exception
            MsgBox(String.Format("Impossible de lire le fichier ! Erreur : {0}", ex.Message))
        End Try

        openMultipleTabs(arrStation)
    End Sub

    Private Sub openMultipleTabs(ByVal listOfStation As List(Of String))
        For Each station As String In listOfStation
            If station.ToUpperInvariant = "SCANPARC" Then
                addScanTab()
            ElseIf station.ToUpperInvariant = "SCAN IMPR." Then
                addScanPrinterTab()
            Else
                Dim frmMain As New frmMain(True)
                _windowManager.AddWindow(frmMain)
                frmMain.startScan(station)
            End If
        Next
    End Sub

#Region "tests"

    Private Sub LeakAddTabTest()
        Dim i As Integer = 0
        For i = 0 To 200 Step 1
            Dim frmMain As New frmMain
            Debug.Print("working set : " & System.Diagnostics.Process.GetCurrentProcess.WorkingSet64.ToString)
            _windowManager.AddWindow(frmMain)
            frmMain.Close()
            _windowManager.RemoveWindow(frmMain)
            frmMain = Nothing

            Threading.Thread.Sleep(350)
            Application.DoEvents()
        Next
    End Sub

    Private Sub continuousScan(ByVal numberOfScanToDo As Integer)
        Dim listeStations() As String = New String() {"PC2", "DC1", "DC2", "FS2", "gateway", "gateway2", "mail1", "pctest", "PC4"}
        ' Dim listestations() As String = New String() {"P00CAPX002", "P00CAPX003", "P00CAPX004", "P00CAPX005", "CJ0AATL101"}

        Dim randomizer As New Random
        Dim iterationCount As Integer = 0
        Dim counter As Integer = 0

        While counter < numberOfScanToDo
            Dim stationName As String = listeStations.ElementAt(randomizer.Next(0, listeStations.Count - 1))
            If isTabAlreadyOpened(stationName) Then
                getActiveFrm.Close()
            Else
                ' Dim frmMain As New frmMain
                ' Dim deg = New _addTab(AddressOf program.frmMdiContainer.addTab)
                addTab(stationName)


            End If
            Debug.Print("Nb Tabs : " & windowManager.GetAllWindows.Count.ToString)

            Application.DoEvents()
            Application.DoEvents()
            Application.DoEvents()

            Threading.Thread.Sleep(randomizer.Next(500, 2000))

            counter += 1
            iterationCount += 1
            Debug.Print("iteration : " & iterationCount.ToString)
        End While

    End Sub

    Private Sub openManyTabs()
        Dim listeStations() As String = New String() {"PC2", "DC1", "DC2", "FS2", "gateway", "gateway2", "mail1", "pctest", "PC4"}
        'Dim listestations() As String = New String() {"P00CAPX002", "P00CAPX003", "P00CAPX004", "P00CAPX005", "CJ0AATL101"}

        For Each s As String In listeStations
            Dim frmMain As New frmMain
            _windowManager.AddWindow(frmMain)
            frmMain.startScan(s)

            Application.DoEvents()
        Next
    End Sub
#End Region


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        addTab()
    End Sub

    ''' <summary>
    ''' Cherche tous les onglets ouverts ( ainsi que les fenêtres détachées ) si déja ouvert avec meme nom
    ''' </summary>
    ''' <param name="tabName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isTabAlreadyOpened(ByVal tabName As String) As Boolean
        Dim ww As WrappedWindow = Nothing
        Dim WrappedWindowCollectionWithPoppedWindow As WrappedWindowCollection = _windowManager.GetAllWindows

        '
        ' On ajoute les fenetres détachées ( popOut ) dans la collection
        ' il y a bien une classe PoppedOutWindowsManager présente dans la librairie 
        ' mais pas trouvé comment on y accède depuis le code client ...
        '
        ' Il n'y a pas d'évènement émis lorsque une fenêtre détachée est fermée,
        ' La fenêtre n'est donc pas retirée de la liste _poppedOut à la fermeture 
        ' si la fenêtre a été fermée la propriété window est à nothing et closed est à true ...
        '
        Dim listOfPoppedOutClosedwindow As New List(Of WrappedWindow)

        For Each www As WrappedWindow In _poppedOutWrappedWindowlist
            If www.Window Is Nothing Then
                listOfPoppedOutClosedwindow.Add(www)
            Else
                WrappedWindowCollectionWithPoppedWindow.Add(www)
            End If
        Next

        ' on retire les fenêtre fermées de la collection
        If listOfPoppedOutClosedwindow.Count > 0 Then
            For Each closedWindow As WrappedWindow In listOfPoppedOutClosedwindow
                _poppedOutWrappedWindowlist.Remove(closedWindow)
            Next
        End If

        For Each WrappedWindow As MDIWindowManager.WrappedWindow In WrappedWindowCollectionWithPoppedWindow
            If WrappedWindow.Window.Text.ToUpperInvariant = tabName.ToUpperInvariant Then
                ww = WrappedWindow
            End If
        Next

        WrappedWindowCollectionWithPoppedWindow.Clear()
        WrappedWindowCollectionWithPoppedWindow = Nothing

        If ww Is Nothing Then
            Return False
        Else
            '
            ' si la fenetre est popOut on active directement le frm et on donne le focus 
            ' sinon on utilise la methode du windowManager
            '
            If _windowManager.IsWrappedWindowPoppedOut(ww) Then
                ww.Window.Activate()
                ww.Window.WindowState = FormWindowState.Normal
            Else
                _windowManager.SetActiveWindow(ww)
            End If

            Return True
        End If

    End Function

    Private Sub ExitAnalog()
        '
        'sauv form pos and size 
        '
        If program.preferences.bSaveWindowPos Then
            preferences.SaveFormPositionAndSize(Me, "sFrmMainPosAndSize")
        End If
        '
        ' sauv list tabs Ouverts
        '
        If program.preferences.bSaveSessionTabs Then
            program.preferences.saveTabOpenList(getTabListName)
        End If

        Call AnalogExit()
    End Sub

    Private Sub frm_closing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        '
        ' Si un frm de nettoyage est en cours on annule la fermeture 
        '
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is cleanForm Then
                Dim cleanForm As cleanForm = CType(frm, cleanForm)

                If cleanForm.busy Then
                    MsgBox("Nettoyage en cours, veuillez terminer avant de quitter  !", MsgBoxStyle.Exclamation)
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Next

        ExitAnalog()
    End Sub

    Private Sub ToolStripButtonBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmDatagridScan
        With frm
            frm.MdiParent = Me
            frm.Show()
        End With
    End Sub

    Private Sub PréférencesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemPreferences.Click
        Dim frmPreferences = New frmPreferences
        frmPreferences.ShowDialog()
    End Sub

    Private Sub AProposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemApropos.Click
        Dim frmAbout = New frmAPropos
        frmAbout.ShowDialog()
    End Sub

    Private Sub analog_keyPressed(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.T
                If e.Modifiers = Keys.Control Then
                    addTab()
                End If
            Case Keys.F9
                If e.Modifiers = Keys.Control Then
                    Debug.Print("Garbage collect")
                    GC.Collect()
                End If
            Case Keys.W
                If e.Modifiers = Keys.Control Then
                    If IsNothing(Me.ActiveControl) Then Exit Sub

                    Dim frm As Form = TryCast(Me.ActiveControl, Form)
                    If frm IsNot Nothing Then
                        frm.Close()
                        removeTab(frm)
                    End If
                End If
        End Select
    End Sub

#Region "gestion Favoris"
    ''' <summary>
    ''' Parcours les favoris stockés dans preferences
    ''' et ajoute les machines dans le menu favoris
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadMenuFavorisFromPreferences()
        For Each favoris As cFavoris In program.preferences.colFavoris
            Dim menuItem As New ToolStripMenuItem
            With menuItem
                .Name = favoris.stationName
                .Text = favoris.stationName
                .ToolTipText = favoris.note
            End With

            Me.ToolStripMenuFavoris.DropDownItems.Add(menuItem)

            AddHandler menuItem.Click, AddressOf toolStripItemFavoris_ClickHandler
        Next
    End Sub

    Public Sub reloadMenuFavorisFromPreferences()
        ' Supprime favoris présents dans le menu mais plus dans les préférences
        Dim listOfToolStripItemsToRemove As New List(Of ToolStripItem)

        For Each tsi As ToolStripItem In Me.ToolStripMenuFavoris.DropDownItems
            ' rajouté un tag pour distinguer entrées menu ( ajouter / Organiser ) pour différencier avec les stations
            If tsi.Tag Is Nothing Then
                If Not TypeOf tsi Is ToolStripSeparator Then
                    Dim tsmi As ToolStripMenuItem = CType(tsi, ToolStripMenuItem)

                    If Not program.preferences.colFavoris.favorisExist(tsi.Text) Then
                        listOfToolStripItemsToRemove.Add(tsi)
                    End If
                End If
            End If
        Next

        For Each tsi As ToolStripItem In listOfToolStripItemsToRemove
            Me.ToolStripMenuFavoris.DropDownItems.Remove(tsi)
            RemoveHandler tsi.Click, AddressOf toolStripItemFavoris_ClickHandler
        Next

        ' ajoute les nouveaux favoris
        For Each favoris As cFavoris In program.preferences.colFavoris
            If Me.ToolStripMenuFavoris.DropDownItems.Find(favoris.stationName, False).Count = 0 Then
                Dim ts As ToolStripItem = Me.ToolStripMenuFavoris.DropDownItems.Add(favoris.stationName)
                AddHandler ts.Click, AddressOf toolStripItemFavoris_ClickHandler
            End If
        Next
    End Sub

    Public Sub toolStripItemFavoris_ClickHandler(ByVal sender As Object, ByVal e As EventArgs)
        addTab(CType(sender, ToolStripItem).Text)
    End Sub

    Private Sub ToolStripMenuItemAjouterFavoris_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemAjouterFavoris.Click
        Dim activeFrm As Form = getActiveFrm()

        ' si tous les onglets sont fermés , évite crash
        If ActiveForm Is Nothing Then
            Return
        End If

        If TypeOf activeFrm Is frmMain Then
            Dim frm As frmMain = CType(activeFrm, frmMain)

            If frm IsNot Nothing Then
                If frm.station IsNot Nothing Then
                    If Not program.preferences.colFavoris.favorisExist(frm.station.stationName) Then
                        Dim frmAjouterFavoris As New frmAddFavoris(frm.station)
                        frmAjouterFavoris.ShowDialog()
                    Else
                        MsgBox(String.Format("La station {0} est déjà dans vos favoris", frm.station.stationName))
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub OrganiserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemOrganiserFavoris.Click
        Dim frmOpened As Boolean = False
        For Each frm As Form In System.Windows.Forms.Application.OpenForms
            If frm.Name = "frmOrganiserFavoris" Then
                With frm
                    .Focus()
                    .WindowState = FormWindowState.Normal
                End With
                frmOpened = True
                Exit For
            End If
        Next
        If Not frmOpened Then
            Dim frmOrganiserFavoris = New frmOrganiserFavoris
            frmOrganiserFavoris.Show()
        End If
    End Sub
#End Region

    Protected Overrides Sub onmdichildactivate(ByVal e As EventArgs)
        MyBase.OnMdiChildActivate(e)
        Try
            GetType(Form).InvokeMember("FormerlyActiveMdiChild", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.SetProperty Or Reflection.BindingFlags.NonPublic, Nothing, Me, New Object() {Nothing})
        Catch ex As Exception

        End Try
    End Sub

    Private Sub QuitterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitterToolStripMenuItem.Click
        ExitAnalog()
    End Sub
End Class