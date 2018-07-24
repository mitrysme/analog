Imports System.Management

Public Class cwmi
    'Private _wmiSearcher As New ManagementObjectSearcher
    Private _managementScope As ManagementScope
    Private _connexionOption As ConnectionOptions = New ConnectionOptions
    Private _connected As Boolean = False
    Private _stationName As String

    Private _col As New List(Of ManagementObject) ' test pour wmi async

    Public Event disconnected(ByVal force As Boolean, ByVal msg As String, ByVal normal As Boolean)
    Public Event connected()

    Public Property isConnected() As Boolean
        Get
            Return _connected
        End Get
        Set(ByVal value As Boolean)
            _connected = value
        End Set
    End Property

    Public ReadOnly Property stationName() As String
        Get
            Return _stationName
        End Get
    End Property

    Public Sub New(ByVal stationName As String)
        _stationName = stationName
        _connexionOption.Impersonation = ImpersonationLevel.Impersonate
        _connexionOption.Timeout = System.TimeSpan.FromSeconds(20)
        _connected = False
    End Sub

    ''' <summary>
    ''' Déconnection Wmi
    ''' </summary>
    ''' <param name="force">True si déco suite à requete KO</param>
    ''' <remarks></remarks>
    Public Sub disconnect(Optional ByVal force As Boolean = False, _
                          Optional ByVal msg As String = "", _
                          Optional ByVal normal As Boolean = False)

        _connected = False
        ' FIXME KO pour mode scanner 
        ' assigner erreur dans disconnected ?
        'If program.isServerMode Then station.errorMessage = msg

        RaiseEvent disconnected(force, msg, normal)
        'End If
    End Sub

    ''' <summary>
    ''' établit la connection wmi sur la station passée en param
    ''' </summary>
    ''' <param name="errMessage"></param>
    ''' <param name="wmiNamespace">Namespace sur lequel se connecter</param>
    ''' <returns></returns>
    ''' <remarks> Namespaces : root\wmi pour les infos SMART root\cimv2 sinon ( défaut)
    ''' </remarks>
    Public Function connect(ByRef errMessage As String, _
                            Optional ByVal wmiNamespace As String = Nothing, _
                            Optional ByVal wmiFullNamespace As String = Nothing) As Boolean
        Dim managementPath As ManagementPath

        If wmiFullNamespace IsNot Nothing Then
            managementPath = New ManagementPath(wmiFullNamespace)
        Else
            If wmiNamespace Is Nothing Then
                managementPath = New ManagementPath(String.Format("\\{0}\root\cimv2", _stationName))
            Else
                managementPath = New ManagementPath(String.Format("\\{0}{1}", _stationName, wmiNamespace))
            End If
        End If

        _managementScope = New ManagementScope(managementPath, _connexionOption)

        Try
            _managementScope.Connect()
            _connected = True
            RaiseEvent connected()
        Catch ex As Exception
            ' Erreur COM
            If InStr(ex.Message, "0x800706BA", CompareMethod.Binary) > 0 Then
                errMessage = "Le serveur RPC ne réponds pas"
            ElseIf InStr(ex.Message, "0x80070005", CompareMethod.Binary) > 0 Then
                errMessage = "Accès refusé"
            ElseIf InStr(ex.Message, "0x80010108", CompareMethod.Binary) > 0 Then
                errMessage = "Déconnecté, essayez de relancer la requête"
            Else
                errMessage = ex.Message
            End If

            _connected = False
        End Try

        Return _connected
    End Function

    Public Function getResultsFor(ByRef col As ManagementObjectCollection, _
                                  ByVal className As String, _
                                  ByVal condition As String, _
                                  ByVal properties() As String) As Boolean

        Using wmiSearcher As New ManagementObjectSearcher
            With wmiSearcher
                .Scope = _managementScope
                .Options.Rewindable = True
                .Options.ReturnImmediately = False
                .Query = New SelectQuery(className, condition, properties)
            End With

            If runQuery(col, wmiSearcher) Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function

    Public Function getRelatedResultsFor(ByRef col As ManagementObjectCollection, _
                                         ByVal QueryOrSourceObject As String, _
                                         ByVal relationShipClass As String) As Boolean

        Using wmiSearcher As New ManagementObjectSearcher
            With wmiSearcher
                .Scope = _managementScope
                .Options.Rewindable = True
                .Options.ReturnImmediately = False
                .Query = New RelatedObjectQuery(QueryOrSourceObject, Nothing, relationShipClass, Nothing, Nothing, Nothing, Nothing, Nothing)
            End With

            If runQuery(col, wmiSearcher) Then
                Return True
            Else
                Return False
            End If

        End Using
    End Function

    ' code test pour requetes wmi asynchrones
#Region "Async"
    Public Function getResultsForAsync(ByRef col As ManagementObjectCollection, _
                                ByVal className As String, _
                                ByVal condition As String, _
                                ByVal properties() As String, _
                                Optional ByVal async As Boolean = False) As Boolean

        Using wmiSearcher As New ManagementObjectSearcher
            With wmiSearcher
                .Scope = _managementScope
                .Options.Rewindable = True
                .Options.ReturnImmediately = False
                .Query = New SelectQuery(className, condition, properties)
            End With

            If runQueryAsync(wmiSearcher) Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function


    Private Function runQueryAsync(ByRef wmisearcher As ManagementObjectSearcher) As Boolean
        Try
            Dim observer As ManagementOperationObserver = New ManagementOperationObserver

            wmisearcher.Get(observer)

            AddHandler observer.ObjectReady, AddressOf objectReady
            AddHandler observer.Completed, AddressOf complete

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Sub objectReady(ByVal sender As Object, ByVal e As ObjectReadyEventArgs)
        _col.Add(CType(e.NewObject, ManagementObject))
    End Sub

    Private Sub complete()
        Debug.Print(_col.Count.ToString)

        For Each mo As ManagementObject In _col
            Debug.Print(mo.Item("name").ToString)
            Debug.Print(mo.Item("FreePhysicalMemory").ToString)
        Next
    End Sub
#End Region

    ''' <summary>
    ''' exécution WQL
    ''' </summary>
    ''' <param name="col"></param>
    ''' <param name="wmisearcher"></param>
    ''' <returns>boolean</returns>
    ''' <remarks>
    ''' </remarks>
    Private Function runQuery(ByRef col As ManagementObjectCollection, _
                              ByRef wmisearcher As ManagementObjectSearcher) As Boolean

        If Not _connected Then
            log.addLogEntry(New cLogEntry(String.Format("WQL : {0} Abandon : non connecté", wmisearcher.Query.QueryString), cLogEntry.enumDebugLevel.DEBUG, _stationName, "cwmi"))
            Debug.Print("tentative de requete en mode déconnecté")
            Return False
        End If

        Dim watcher As New Stopwatch

        Try
            watcher.Start()
            col = wmisearcher.Get
            watcher.Stop()

            ' Debug.Print(wmisearcher.Query.QueryString)


            'inutile de loguer toutes les requetes en mode Batch...
            If Not program.isServerMode Then
                log.addLogEntry(New cLogEntry(String.Format("WQL : ( {0} ms ) {1}", watcher.ElapsedMilliseconds.ToString, wmisearcher.Query.QueryString.ToString), _
                                              cLogEntry.enumDebugLevel.INFO, _stationName, "cwmi"))
            End If

            Return True

            ' Exceptions COM
            'Si une exception de type RPC serveur KO ou echec appel proc distante 
            ' on admet que la station n'est plus en ligne et on déconnecte
        Catch ex As System.Runtime.InteropServices.COMException
            Select Case (ex.ErrorCode)
                Case -2147023174 'RPC serveur KO
                    Me.disconnect(True, "Le serveur RPC n'est pas disponible")
                Case -2147023170 ' Echec appel procédure distante
                    Me.disconnect(True, "Echec Appel Procédure distante")
                Case -2147417848 '(Exception de HRESULT : 0x80010108 (RPC_E_DISCONNECTED)
                    Me.disconnect(True, "Client déconnecté")
                Case Else
                    Me.disconnect(True, ex.Message)
            End Select

        Catch ex As ManagementException
            Select Case (ex.ErrorCode)
                Case ManagementStatus.ShuttingDown
                    Me.disconnect(True, "La station est en train de s'arreter")
                Case ManagementStatus.InvalidQuery ' classe n'existe pas ( ex Windows 2000 et requete win32_logicalDisk )
                    log.addLogEntry(New cLogEntry("Requete  : " & wmisearcher.Query.QueryString.ToString & " ==> Requete Invalide", cLogEntry.enumDebugLevel.ERREUR, _stationName, "cwmi"))
                Case ManagementStatus.Failed ' requete plante ( log corrumpu ( fichier .evt ) )
                    log.addLogEntry(New cLogEntry("Requete : " & wmisearcher.Query.QueryString.ToString & " ==> Echec Générique ( log corrompu ?)", cLogEntry.enumDebugLevel.ERREUR, _stationName, "cwmi", ex))
                Case ManagementStatus.NotSupported ' classe non supportée ( SMART par exemple )
                    log.addLogEntry(New cLogEntry("Requete : " & wmisearcher.Query.QueryString.ToString & " ==> Classe Non supportée...", cLogEntry.enumDebugLevel.ERREUR, _stationName, "cwmi", ex))
                Case ManagementStatus.CallCanceled
                    log.addLogEntry(New cLogEntry("Requete : " & wmisearcher.Query.QueryString.ToString & " ==> Appel abandonné ", cLogEntry.enumDebugLevel.ERREUR, _stationName, "cwmi", ex))
                Case Else
                    log.addLogEntry(New cLogEntry("Requete : " & wmisearcher.Query.QueryString.ToString & " " & "Message : " & ex.Message.ToString, cLogEntry.enumDebugLevel.ERREUR, _stationName, "cwmi", ex))
            End Select

        Catch ex As Exception
            log.addLogEntry(New cLogEntry(String.Format("La requete : {0} a échoué", wmisearcher.Query.QueryString), cLogEntry.enumDebugLevel.ERREUR, _stationName, "cwmi", ex))
        End Try


        Return False
    End Function

End Class
