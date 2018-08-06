Imports program
Imports System.Xml.Serialization
Imports System.Xml

Public Class preferences
    ' Informations à récupérer sur la station
    Private _bGetStatDisque As Boolean
    Private _bGetLogAnalyze As Boolean
    Private _bGetPrograms As Boolean
    Private _sSite As String ' code site CHU
    Private _sScanServer As String ' Serveur scan
    Private _sScanServerDataFolder As String ' nom du dossier fichiers de scans 
    Private _sVncPath As String
    Private _sSccmPath As String
    Private _bLogPanelCollapse As Boolean ' affiche / cache panel Log
    Private _iLogPanelSplitterDistance As Integer ' position Splitter logPanel ( panel2 )
    ' préférences Log
    Private _bLogDebug As Boolean
    Private _bLogErreur As Boolean
    Private _blogInfo As Boolean
    ' panelState
    Private _cPanelState As String
    Private _bSavePanelState As Boolean
    ' Position fenetre
    Private _bSaveWindowsPos As Boolean
    ' Délai MAJ graphs
    Private _usMajGraphsDelay As UShort
    ' Mysql
    Private _sDBServer As String
    Private _sDBDataSource As String
    Private _sDBUser As String
    Private _sDBPassword As String
    ' Commentaires 
    Private _bActivecomments As Boolean
    ' Etat colonne DatagridViewScan
    Private _sColDataGridViewState As Specialized.StringCollection
    ' favoris
    Public colFavoris As cColFavoris
    ' Sauvegarde options frmDatagridScan
    Private _bShowDeletedComputers As Boolean
    Private _bShowScanKO As Boolean
    Private _bFilterDateScan As Boolean
    ' prefs Graphs
    Private _bgraphAntialiasing As Boolean
    Private _bAnimateGraph As Boolean
    ' Sauvegarde liste tabs
    Private _sTabOpenList As String
    Private _bSaveSessionTabs As Boolean
    ' Configuration
    Private _sDomainName As String
    Private _sContactMail As String
    Private _sccmServerAddress As String
    Private _smtpServerAddress As String
    ' préférence timeout Ping
    Private _uintPingTimeout As UShort
    ' contactURL
    Private _sContactURL As String
    ' compte pour envoi message crash
    Private _sMailNTAccount As String
    ' Serveur de messagerie pour envoi message crash
    Private _sMailServer As String


#Region "Getter/setter"
    Public ReadOnly Property getStatDisque() As Boolean
        Get
            Return _bGetStatDisque
        End Get
    End Property
    Public ReadOnly Property getLogAnalyse() As Boolean
        Get
            Return _bGetLogAnalyze
        End Get
    End Property
    Public ReadOnly Property getPrograms() As Boolean
        Get
            Return _bGetPrograms
        End Get
    End Property
    Public Property scanServer() As String
        Get
            Return _sScanServer
        End Get
        Set(ByVal value As String)
            _sScanServer = value
        End Set
    End Property
    Public ReadOnly Property cbDebug() As Boolean
        Get
            Return _bLogDebug
        End Get
    End Property
    Public ReadOnly Property cbErreur() As Boolean
        Get
            Return _bLogErreur
        End Get
    End Property
    Public ReadOnly Property cbInfo() As Boolean
        Get
            Return _blogInfo
        End Get
    End Property

    Public Property sSite() As String
        Get
            Return _sSite
        End Get
        Set(ByVal value As String)
            _sSite = value
        End Set
    End Property
    Public ReadOnly Property sSiteAsCode() As String
        Get
            Select Case _sSite
                Case "PEL"
                    Return "03"
                Case "SA"
                    Return "02"
                Case "HL"
                    Return "06"
                Case "DG"
                    Return "01"
                Case Else
                    Return "03" ' on renvoie pellegrin par défaut
            End Select
        End Get
    End Property
    Public Property sVncPath() As String
        Get
            Return _sVncPath
        End Get
        Set(ByVal value As String)
            _sVncPath = value
        End Set
    End Property
    Public Property sSccmPath() As String
        Get
            Return _sSccmPath
        End Get
        Set(ByVal value As String)
            _sSccmPath = value
        End Set
    End Property
    Public ReadOnly Property cPanelState() As String
        Get
            Return _cPanelState
        End Get
    End Property
    Public Property bSavePanelState() As Boolean
        Get
            Return _bSavePanelState
        End Get
        Set(ByVal value As Boolean)
            _bSavePanelState = value
        End Set
    End Property
    Public Property bSaveWindowPos() As Boolean
        Get
            Return _bSaveWindowsPos
        End Get
        Set(ByVal value As Boolean)
            _bSaveWindowsPos = value
        End Set
    End Property
    Public Property bLogPanelCollapse() As Boolean
        Get
            Return _bLogPanelCollapse
        End Get
        Set(ByVal value As Boolean)
            _bLogPanelCollapse = value
        End Set
    End Property
    Public Property IlogPanelSplitterDistance() As Integer
        Get
            Return _iLogPanelSplitterDistance
        End Get
        Set(ByVal value As Integer)
            _iLogPanelSplitterDistance = value
        End Set
    End Property
    Public Property usMajGraphsDelay() As UShort
        Get
            If _usMajGraphsDelay = Nothing Then
                Return 1
            Else
                Return _usMajGraphsDelay
            End If
        End Get
        Set(ByVal value As UShort)
            _usMajGraphsDelay = value
        End Set
    End Property
    Public Property bActiveComments() As Boolean
        Get
            Return _bActivecomments
        End Get
        Set(ByVal value As Boolean)
            _bActivecomments = value
        End Set
    End Property
    Public ReadOnly Property sColDataGridViewState() As Specialized.StringCollection
        Get
            Return _sColDataGridViewState
        End Get
    End Property
    Public Property sDBServer() As String
        Get
            Return _sDBServer
        End Get
        Set(ByVal value As String)
            _sDBServer = value
        End Set
    End Property
    Public Property sDBDataSource() As String
        Get
            Return _sDBDataSource
        End Get
        Set(ByVal value As String)
            _sDBDataSource = value
        End Set
    End Property
    Public Property sDBUser() As String
        Get
            Return _sDBUser
        End Get
        Set(ByVal value As String)
            _sDBUser = value
        End Set
    End Property
    Public Property sDBPassword() As String
        Get
            Return _sDBPassword
        End Get
        Set(ByVal value As String)
            _sDBPassword = value
        End Set
    End Property
    Public Property bShowDeletedComputers() As Boolean
        Get
            Return _bShowDeletedComputers
        End Get
        Set(ByVal value As Boolean)
            _bShowDeletedComputers = value
        End Set
    End Property
    Public Property bShowScanKO() As Boolean
        Get
            Return _bShowScanKO
        End Get
        Set(ByVal value As Boolean)
            _bShowScanKO = value
        End Set
    End Property
    Public Property bFilterDateScan() As Boolean
        Get
            Return _bFilterDateScan
        End Get
        Set(ByVal value As Boolean)
            _bFilterDateScan = value
        End Set
    End Property
    Public Property bGraphAntialiasing() As Boolean
        Get
            Return _bgraphAntialiasing
        End Get
        Set(ByVal value As Boolean)
            _bgraphAntialiasing = value
        End Set
    End Property
    Public Property bAnimateGraph() As Boolean
        Get
            Return _bAnimateGraph
        End Get
        Set(ByVal value As Boolean)
            _bAnimateGraph = value
        End Set
    End Property
    Public Property bSaveSessionTabs() As Boolean
        Get
            Return _bSaveSessionTabs
        End Get
        Set(ByVal value As Boolean)
            _bSaveSessionTabs = value
        End Set
    End Property
    Public Property sTabOpenList() As String
        Get
            Return _sTabOpenList
        End Get
        Set(ByVal value As String)
            _sTabOpenList = value
        End Set
    End Property
    Public ReadOnly Property sDomainName() As String
        Get
            Return _sDomainName
        End Get
    End Property
    Public Property uintPingTimeout As UShort
        Get
            Return _uintPingTimeout
        End Get
        Set(value As UInt16)
            _uintPingTimeout = value
        End Set
    End Property
    Public Property sContactURL() As String
        Get
            Return _sContactURL
        End Get
        Set(value As String)
            _sContactURL = value
        End Set
    End Property
    Public Property sMailNTAccount As String
        Get
            Return _sMailNTAccount
        End Get
        Set(value As String)
            _sMailNTAccount = value
        End Set
    End Property
    Public Property sMailServer As String
        Get
            Return _sMailServer
        End Get
        Set(value As String)
            _sMailServer = value
        End Set
    End Property

#End Region

    Public Sub New()
        ' si nécessaire importe les préférences de la dernière version 
        ' avec classe my.settings compatible
        ' voir http://blogs.msdn.com/b/rprabhu/archive/2005/06/29/433979.aspx
        If CBool(My.Settings.Item("bUpgrade")) Then
            My.Settings.Upgrade()
            My.Settings.Item("bUpgrade") = False
        End If

        ' lecture / assignation des préfs depuis my.settings
        With My.Settings
            ' Mysql
            _sDBServer = .sDBServer
            _sDBDataSource = .sDBDatasource
            _sDBUser = .sDBUser
            _sDBPassword = .sDBPassword

            ' si mode serveur on récupère params pour scan batch
            If program.isServerMode Then
                _bGetLogAnalyze = True
            Else ' sinon on lit les préférences utilisateur
                _bGetLogAnalyze = .bGetLogAnalyze
                _bGetPrograms = .bGetPrograms
                _bGetStatDisque = .bGetStatDisque
                _bLogDebug = .bLogDebug
                _bLogErreur = .bLogErreur
                _blogInfo = .blogInfo
                _sSite = .sSite
                _sVncPath = .sVncPath
                _sSccmPath = .sSccmPath
                _cPanelState = .cPanelState ' etat des panels ( collapsed /expanded)
                _bSavePanelState = .bSavePanelState
                _bSaveWindowsPos = .bSaveWindowPos
                _bLogPanelCollapse = .bLogPanelCollapse
                _iLogPanelSplitterDistance = .iLogPanelSplitterDistance
                _usMajGraphsDelay = .shortMajGraphDelay ' délai MAJ graphs
                ' Commentaires
                _bActivecomments = .bActiveComments
                ' scanParc
                _sColDataGridViewState = .sColDataGridViewState
                _bShowDeletedComputers = .bShowDeletedComputers
                _bShowScanKO = .bShowScanKO
                _bFilterDateScan = .bfilterDatescan
                ' graphs
                _bgraphAntialiasing = .bGraphAntialiasing
                _bAnimateGraph = .bAnimateGraph
                _sTabOpenList = .sTabOpenList
                _bSaveSessionTabs = .bSaveSessionTabs
                ' Ping timeout
                _uintPingTimeout = .uintPingTimeout
                ' contact
                _sContactURL = .sConcactURL
                ' Compte de messagerie pour envoi message crash
                _sMailNTAccount = .sMailNTAccount
                ' Serveur de messagerie pour envoi message crash
                _sMailServer = sMailServer
            End If

            If program.isServerMode Then
                _sScanServer = "127.0.0.1"
            Else
                _sScanServer = .sScanServer
            End If

        End With

        ' importation des favoris depuis favoris.xml
        ' si le fichier XML de favoris n'existe pas crée nouvelle instance
        If Not IO.File.Exists(cColFavoris.favorisPath) Then
            Me.colFavoris = New cColFavoris()
        Else
            'désérialisation et assignation depuis fichier XML
            Dim mySerializer As System.Xml.Serialization.XmlSerializer = New System.Xml.Serialization.XmlSerializer(GetType(cColFavoris))
            ' To read the file, create a FileStream.
            Dim myFileStream As IO.FileStream = New IO.FileStream(cColFavoris.favorisPath, IO.FileMode.Open)
            ' Call the Deserialize method and cast to the object type.
            ' voir http://social.msdn.microsoft.com/Forums/en-US/xmlandnetfx/thread/a5e411f1-b247-4e16-83c9-4a227b75883e => LF OK
            Me.colFavoris = CType(mySerializer.Deserialize(New XmlTextReader(myFileStream)), cColFavoris)
            myFileStream.Dispose()
        End If
    End Sub

    Public Sub saveDataGridViewColumnState(ByVal sCol As Specialized.StringCollection)
        _sColDataGridViewState = sCol
    End Sub

    Public Sub savePreferences()
        prefToSettings()
        My.Settings.Save()
    End Sub

    ''' <summary>
    ''' Sauve les préférences dans my.settings ( xml sérialisé)
    ''' </summary>
    ''' <remarks>
    ''' TODO = On passe deux fois ici à la  fermeture ....
    ''' </remarks>
    Public Sub prefToSettings()
        With My.Settings
            .bGetPrograms = _bGetPrograms
            .bGetLogAnalyze = _bGetLogAnalyze
            .bGetStatDisque = _bGetStatDisque
            .bLogDebug = _bLogDebug
            .bLogErreur = _bLogErreur
            .blogInfo = _blogInfo
            .sSite = _sSite
            .sScanServer = _sScanServer
            .sVncPath = _sVncPath
            .sSccmPath = _sSccmPath
            .cPanelState = _cPanelState
            .bSavePanelState = _bSavePanelState
            .bSaveWindowPos = _bSaveWindowsPos
            .bLogPanelCollapse = _bLogPanelCollapse
            .iLogPanelSplitterDistance = _iLogPanelSplitterDistance
            .shortMajGraphDelay = _usMajGraphsDelay
            .sDBServer = _sDBServer
            .sDBDatasource = _sDBDataSource
            .sDBUser = _sDBUser
            .sDBPassword = _sDBPassword
            .bActiveComments = _bActivecomments
            ' scanParc
            .sColDataGridViewState = _sColDataGridViewState
            .bShowDeletedComputers = _bShowDeletedComputers
            .bShowScanKO = _bShowScanKO
            .bfilterDatescan = _bFilterDateScan
            '
            .bGraphAntialiasing = _bgraphAntialiasing
            .bAnimateGraph = _bAnimateGraph
            .sTabOpenList = _sTabOpenList
            .bSaveSessionTabs = _bSaveSessionTabs
            ' ping timeout 
            .uintPingTimeout = _uintPingTimeout

            ' Compte de messagerie pour envoi message crash
            .sMailNTAccount = _sMailNTAccount
            ' Serveur de messagerie pour envoi message crash
            .sMailServer = _sMailServer
        End With
    End Sub

    Public Sub changeInfosToGet(ByVal checkbox As CheckBox)
        Select Case checkbox.Name
            Case "CheckBoxPrograms"
                _bGetPrograms = checkbox.Checked
            Case "CheckBoxStatDisque"
                _bGetStatDisque = checkbox.Checked
            Case "CheckBoxAnalyseLog"
                _bGetLogAnalyze = checkbox.Checked
        End Select
    End Sub

    Public Sub changeLogLevel(ByVal checkbox As CheckBox)
        Select Case checkbox.Name
            Case "cbDebug"
                _bLogDebug = checkbox.Checked
            Case "cbErreur"
                _bLogErreur = checkbox.Checked
            Case "cbInfo"
                _blogInfo = checkbox.Checked
        End Select
    End Sub

    Public Shared Sub LoadFormPositionAndSize(ByVal form As Form, ByVal name As String)
        ' Example : X|Y|W|H
        If My.Settings.bRemenberPosAndSize Then
            Try
                Dim value As String = CStr(My.Settings(name))
                Dim b() As String = value.Split(CChar("|"))
                Dim bb() As Integer = {Integer.Parse(b(0)), _
                                       Integer.Parse(b(1)), _
                                       Integer.Parse(b(2)), _
                                       Integer.Parse(b(3))}
                If bb(0) + bb(1) + bb(2) + bb(3) = 0 Then
                    ' Then we center the form !
                    With form
                        .Left = (Screen.PrimaryScreen.Bounds.Width - .Width) \ 2
                        .Top = (Screen.PrimaryScreen.Bounds.Height - .Height) \ 2
                    End With
                Else
                    With form
                        .Left = Integer.Parse(b(0))
                        .Top = Integer.Parse(b(1))
                        .Width = Integer.Parse(b(2))
                        .Height = Integer.Parse(b(3))
                    End With
                End If
            Catch ex As Exception
                log.addLogEntry(New cLogEntry("Impossible de charger la position de la fenêtre", cLogEntry.enumDebugLevel.ERREUR, , "cPref", ex))
            End Try
        End If
    End Sub

    ' Save position & size of a form
    Public Shared Sub SaveFormPositionAndSize(ByVal form As Form, ByVal name As String)
        ' Example : X|Y|W|H
        If form IsNot Nothing Then
            If form.WindowState <> FormWindowState.Minimized Then
                If My.Settings.bRemenberPosAndSize Then
                    Try
                        Dim res As String = String.Format("{0}|{1}|{2}|{3}", _
                                                          form.Left.ToString, _
                                                          form.Top.ToString, _
                                                          form.Width.ToString, _
                                                          form.Height.ToString)
                        My.Settings(name) = res
                    Catch ex As Exception
                        log.addLogEntry(New cLogEntry("Impossible de sauver la position de la fenêtre", cLogEntry.enumDebugLevel.ERREUR, , "cPref", ex))
                    End Try
                End If
            End If
        End If
    End Sub

    Public Sub saveTabOpenList(ByVal tol As List(Of String))
        If Not tol Is Nothing Then
            If tol.Count > 0 Then
                Dim formatString As String = ""
                For Each tabName As String In tol
                    formatString += tabName
                    formatString += ";"
                Next

                _sTabOpenList = formatString
            Else
                _sTabOpenList = String.Empty
            End If
        End If
    End Sub


    ''' <summary>
    ''' Sauve etat des panels dans les préférences
    ''' </summary>
    ''' <param name="colPanelState"></param>
    ''' <remarks></remarks>
    Public Sub savePanelState(ByVal colPanelState As String)
        _cPanelState = colPanelState
    End Sub

    Public Function getPanelState() As String
        Return _cPanelState
    End Function

End Class
