Public Module program
    Public applicationPath As String = Application.StartupPath
    Public frmServer As frmServer
    Public WithEvents log As clog
    Public programVersion As Version = My.Application.Info.Version ' version
    Public releaseName As String = "BETA"
    Public WINDBG_PATH As String = "\Debugging Tools for Windows (x86)\windbg.exe" ' chemin pour le debugger Windows
    Public tabicons As structTabIcons

    Public Structure structTabIcons
        Public iconConnected As Icon
        Public iconOffline As Icon
        Public iconDisconnected As Icon
        Public iconDatabase As Icon
        Public iconPrinter As Icon
        Public iconPrinterScan As Icon
    End Structure

    Private _frmMdiContainer As frmMdiContainer
    Private _preferences As preferences ' préférences
    Private _programParameters As ProgramParameters ' paramètres ligne de commande
    Private _time As Integer ' temps démarrage
    Private _applicationStartDate As DateTime

    ' constantes
    Private Const _tryReconnectInterval As Integer = 50000 ' nb de ms entre chaque essai de reconnexion sur station

    ''' <summary>
    ''' classe gestion paramètres lignes de commande
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ProgramParameters
        Private _isServerMode As Boolean = False
        Private _isServerConfigMode As Boolean = False ' ne lance pas le scan dans ce mode, pour reglage préférences...
        Private _stationCommandLine As String ' station à scanner passée en ligne commande

        Public ReadOnly Property isServerMode() As Boolean
            Get
                Return _isServerMode ' mettre à true pour forcer server
            End Get
        End Property
        Public ReadOnly Property isServerConfigMode() As Boolean
            Get
                Return _isServerConfigMode
            End Get
        End Property
        Public ReadOnly Property stationCommandLine() As String
            Get
                Return _stationCommandLine
            End Get
        End Property

        Public Sub New(ByRef parameters As String())
            If parameters Is Nothing Then
                Exit Sub
            End If
            For i As Integer = 0 To parameters.Length - 1
                If parameters(i).ToUpperInvariant = "-SERVER" Then
                    _isServerMode = True
                End If
                If parameters(i).ToUpperInvariant = "-CONFIG" Then
                    _isServerConfigMode = True
                End If
                If parameters(i).StartsWith("-M:") Then
                    If parameters(i).Length > 3 Then
                        _stationCommandLine = parameters(i).Substring(3).Trim
                    End If
                End If
            Next
        End Sub
    End Class

#Region "getter/setter"
    Public ReadOnly Property preferences() As preferences
        Get
            Return _preferences
        End Get
    End Property
    Public ReadOnly Property isServerMode() As Boolean
        Get
            Return _programParameters.isServerMode
        End Get
    End Property
    Public ReadOnly Property isServerConfigMode() As Boolean
        Get
            Return _programParameters.isServerConfigMode
        End Get
    End Property
    Public ReadOnly Property stationCommandLine() As String
        Get
            Return _programParameters.stationCommandLine
        End Get
    End Property
    Public ReadOnly Property ElapsedTime() As Integer
        Get
            Return native.api.nativeFunctions.GetTickCount - _time
        End Get
    End Property
    Public ReadOnly Property applicationStartDate() As DateTime
        Get
            Return _applicationStartDate
        End Get
    End Property
    Public ReadOnly Property tryReconnectInterval() As Integer
        Get
            Return _tryReconnectInterval
        End Get
    End Property
    Public ReadOnly Property frmMdiContainer() As frmMdiContainer
        Get
            Return _frmMdiContainer
        End Get
    End Property
#End Region

    <STAThread()> _
    Public Sub main()
        Application.EnableVisualStyles()

        '
        ' definition Sites CHU
        '
        With cbatchScan.dicsiteNames
            .Add("Tous", "Tous")
            .Add("PEL", "Pellegrin")
            .Add("SA", "Saint-andre")
            .Add("HL", "Haut-Leveque")
            .Add("DG", "Direction-generale")
            .Add("LCA", "Lormont-CJA -Abadie")
        End With

        '======= Set handler for exceptions
        AddHandler Application.ThreadException, AddressOf MYThreadHandler
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf MYExnHandler

        _time = native.api.nativeFunctions.GetTickCount
        _applicationStartDate = Date.Now
        _programParameters = New ProgramParameters(Environment.GetCommandLineArgs)
        _preferences = New preferences
        log = New clog

        log.addLogEntry(New cLogEntry(String.Format("====================== Analog v {0} ==========================", program.programVersion.ToString),
                                      cLogEntry.enumDebugLevel.INFO, "Hello !")
                                      )
        ' charge l'historique
        ' TODO  => classe historique séparée ...
        cstation.loadLastUsedStationFromSettings()

        If _programParameters.isServerMode Then
            If _programParameters.isServerConfigMode Then
                Application.Run(frmServerPreferences)
            Else
                frmServer = New frmServer
                Application.Run(frmServer)
            End If
        Else
            tabicons = New structTabIcons
            With tabicons
                .iconConnected = Icon.FromHandle(CType(My.Resources.ok16, Bitmap).GetHicon)
                .iconDisconnected = Icon.FromHandle(CType(My.Resources.cross_circle16, Bitmap).GetHicon)
                .iconOffline = Icon.FromHandle(CType(My.Resources.offlineIcon, Bitmap).GetHicon)
                .iconDatabase = Icon.FromHandle(My.Resources.database.GetHicon)
                .iconPrinter = Icon.FromHandle(My.Resources.icone_imprimante.GetHicon)
                .iconPrinterScan = Icon.FromHandle(My.Resources.printerScan.GetHicon)
            End With

            _frmMdiContainer = New frmMdiContainer
            Application.Run(_frmMdiContainer)
        End If
    End Sub

    ' Handler for exceptions
    Private Sub MYExnHandler(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        Dim ex As Exception
        ex = CType(e.ExceptionObject, Exception)

        Dim t As New frmError(ex)
        t.TopMost = True
        t.ShowDialog()
    End Sub

    Private Sub MYThreadHandler(ByVal sender As Object, ByVal e As Threading.ThreadExceptionEventArgs)
        Dim t As New frmError(e.Exception)
        t.TopMost = True
        t.ShowDialog()
    End Sub


    ''' <summary>
    ''' Fermeture 
    ''' sauvegarde histo si nécessaire
    ''' clean objets
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AnalogExit()

        If Not program.isServerMode Then
            My.Settings.LastUsedStation.Clear()
            For Each stationUsed As String In cstation.lstLastUsedStation
                My.Settings.LastUsedStation.Add(stationUsed)
            Next
        End If

        MySql.Data.MySqlClient.MySqlConnection.ClearAllPools()
        preferences.savePreferences()

        log.addLogEntry(New cLogEntry("bye"))
        log.dispose()

        ' disposer les tabicons ...


        Application.Exit()
        ' => raisefrmClosingOnApplicationExit 
        ' vu pile appel , cause deux passages dans cette fonction ... a voir ) 
    End Sub

End Module

