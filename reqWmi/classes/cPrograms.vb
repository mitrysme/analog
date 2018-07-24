Public Class cPrograms
    Private _programList As List(Of InstalledProgram)
    Private _programListDB As List(Of InstalledProgram)
    Private _stationName As String

    Private Shared aSoftChu() As String = {"Remplaceilex", "Finalisation déploiement PrimaActivité", "TSEC", _
                                "Service Patient", "Prima'Activité", "CCOW", "DOMH DPS", "Criston Precision Client", _
                                "GemScope V3", "Varian", "Philips Recorder", "DxWin", "Medasys", "Commun", "Laboratory", "Trace Line", _
                                "VNC", "Trend Micro", "TDR", "TD-Synergy", "Bayer Request", "Xplore", "Medi-Q", "MICROMEDEX", "SICAP", "Vidal", "Citrix", _
                                "Cryptolib CPS", "TDWorkstation", "CPageInstall", "INFOFIV", "EndNote", "CARL master", "ETI-Max", "esishop", _
                                "LightCycler", "Sequence Scanner", "FileMaker", "CanoScan", "OmniPage", "CHIMED", "Epi Info", "EpiData", _
                                "DWG TrueView", "CARL Master", "Bentley View", "DEFGEN", "Genikon"}

    ' GFI => gestor, 
    ' Arpege => concerto ( gestion Crêche )
    Private Shared aSoftChuPublisher() As String = {"GIP CPAGE", "GFI CHRONO TIME", "Arpege", "ASIP Santé", "GIE SESAM-Vitale", "Leica Microsystems", "CHU de BORDEAUX"}

    Private Shared aProgramsToIgnore() As String = {"Microsoft", "Update", "Hotfix", "Mise à jour de sécurité", "Adobe Reader", _
                                                    "Intel(R) Extreme Graphics Driver", "ID9_", "MSXML", "AllowReuseShortcuts", "Athlon 64 Processor Driver", _
                                                    "Java 2 Runtime Environment", "DecLanceurV4", "DecLanceurMSI", "Windows Genuine Advantage", _
                                                    "Mise à jour de sécurité pour Windows XP", "Mise à jour pour Windows XP", "Correctif pour Windows XP", _
                                                    "PDFCreator", "Realtek"}

    Public ReadOnly Property getPrograms(Optional ByVal fromDB As Boolean = False) As List(Of InstalledProgram)
        Get
            If fromDB Then
                If _programListDB Is Nothing Then
                    getProgramsFromDB()
                End If
            Else
                If _programList Is Nothing Then
                    getRegistryPrograms()
                End If
            End If

            If fromDB Then
                Return _programListDB
            Else
                Return _programList
            End If
        End Get
    End Property
    'Public ReadOnly Property getProgramsDB() As List(Of InstalledProgram)
    '    Get
    '        If _programListDB Is Nothing Then
    '            getProgramsFromDB()
    '        End If

    '        Return _programListDB
    '    End Get
    'End Property
    Public ReadOnly Property stationName() As String
        Get
            Return _stationName
        End Get
    End Property

    Public Sub New(ByVal stationName As String)
        _stationName = stationName
    End Sub

    Public Structure InstalledProgram
        Public DisplayName As String
        Public DisplayVersion As String
        Public filtered As Boolean
        Public Publisher As String
        Public InstallDate As String
        Public UninstallString As String
    End Structure

    Public Sub setfilterProgram(ByVal searchString As String, ByVal offlineMode As Boolean)
        Dim tempArray As New List(Of cPrograms.InstalledProgram)
        Dim sSearchStringClean As String = Trim(searchString.ToUpperInvariant)
        Dim programList As List(Of InstalledProgram)

        If Not offlineMode Then
            programList = _programList
        Else
            programList = _programListDB
        End If


        For Each program As cPrograms.InstalledProgram In programList
            Dim isStringFound As Boolean = False
            If Trim(program.DisplayName).ToUpperInvariant.Contains(sSearchStringClean) Or Trim(program.Publisher).ToUpperInvariant.Contains(sSearchStringClean) Then
                isStringFound = True
            End If

            program.filtered = Not isStringFound
            tempArray.Add(program)
        Next

        _programList = tempArray
    End Sub

    Public Sub setFilterProgram(ByVal control As CheckBox, Optional ByVal offlineMode As Boolean = False)
        Dim programList As List(Of InstalledProgram)
        If Not offlineMode Then
            programList = _programList
        Else
            programList = _programListDB
        End If

        'If programList Is Nothing Then
        '    ' TODO => loguer
        '    Exit Sub
        'End If

        Dim filterType As String = control.Name
        Dim checked As Boolean = control.Checked
        Dim tempArray As New List(Of cPrograms.InstalledProgram)

        Select Case filterType

            Case "ckbChuFilter"
                For Each program As cPrograms.InstalledProgram In programList
                    Dim isSoftChu As Boolean = False

                    ' Vérification dans nom du programme et Publisher ,
                    ' Moche , dupliqué dans ckbFilterHorsSujet
                    ' TODO =>  refactor
                    '
                    For Each softChu As String In aSoftChu
                        If InStr(program.DisplayName, softChu, CompareMethod.Binary) > 0 Then
                            isSoftChu = True
                        End If
                    Next

                    If Not isSoftChu Then
                        For Each softchuPublisher As String In aSoftChuPublisher
                            If Not program.Publisher Is Nothing Then
                                If InStr(program.Publisher.ToUpperInvariant, softchuPublisher.ToUpperInvariant, CompareMethod.Binary) > 0 Then
                                    isSoftChu = True
                                End If
                            End If
                        Next
                    End If

                    program.filtered = isFiltered(isSoftChu, checked)
                    tempArray.Add(program)
                Next

            Case "ckbFilterMicrosoft"
                For Each program As cPrograms.InstalledProgram In programList
                    Dim isSoftMs As Boolean = False

                    If program.Publisher = "Microsoft Corporation" Then isSoftMs = True

                    program.filtered = isFiltered(isSoftMs, checked)
                    tempArray.Add(program)
                Next

            Case "ckbFilterHorsSujet"
                For Each program As cPrograms.InstalledProgram In programList
                    Dim isSoftHs As Boolean = True

                    ' ok MS
                    If program.Publisher = "Microsoft Corporation" Then isSoftHs = False

                    ' on ignore ?
                    For Each programToIgnore As String In aProgramsToIgnore
                        If InStr(program.DisplayName.ToUpperInvariant, programToIgnore.ToUpperInvariant, CompareMethod.Binary) > 0 Then isSoftHs = False
                    Next

                    ' soft du CHU ?
                    For Each softChu As String In aSoftChu
                        If InStr(program.DisplayName, softChu, CompareMethod.Binary) > 0 Then
                            isSoftHs = False
                        End If
                    Next

                    If isSoftHs Then
                        For Each softchuPublisher As String In aSoftChuPublisher
                            If Not program.Publisher Is Nothing Then
                                If InStr(program.Publisher.ToUpperInvariant, softchuPublisher.ToUpperInvariant, CompareMethod.Binary) > 0 Then
                                    isSoftHs = False
                                End If
                            End If
                        Next
                    End If

                    program.filtered = isFiltered(isSoftHs, checked)
                    tempArray.Add(program)
                Next
        End Select

        If Not offlineMode Then
            _programList = tempArray
        Else
            _programListDB = tempArray
        End If

        tempArray = Nothing
    End Sub

    Public Function getProgramsHashCode() As Integer
        '
        ' Pose probleme si le programme fonctionne dans le monde serveur.
        ' Dans le cas d'une nouvelle station scannée et qui n'est pas pinguable , errMsg="Ping KO"
        ' cette fonction est appelée deupuis cMysqlStationtable.insert et la variable _programList est à NULL donc crashe ici
        '
        If _programList Is Nothing Then
            Return Nothing
        End If

        Dim stringToHash As New System.Text.StringBuilder

        For Each program As cPrograms.InstalledProgram In _programList
            stringToHash.Append(program.DisplayName & program.DisplayVersion)
        Next

        Return stringToHash.ToString.GetHashCode
    End Function

    ''' <summary>
    ''' compte le nombre de programmes dans la collection, sans compter les programmes filtrés
    ''' nécessaire pour le dimensionnement du tableau listview
    ''' </summary>
    ''' <returns>count</returns>
    ''' <remarks></remarks>
    Public Shared Function getProgramFilteredCount(ByVal programList As List(Of cPrograms.InstalledProgram)) As Integer
        Dim count As Integer = 0
        For Each program As cPrograms.InstalledProgram In programList
            If Not program.filtered Then count += 1
        Next
        Return count
    End Function

    Private Function isProgramChanged(ByRef firstScan As Boolean) As Boolean
        Dim hashCodePrograms As Integer = getProgramsHashCode()
        Dim hashCodeDb As Integer = cMySqlStationTable.selectAll(True, stationName).First.Value.programHashCode

        If hashCodeDb = 0 Then
            firstScan = True
        End If

        Return hashCodePrograms <> hashCodeDb
    End Function

    ''' <summary>
    ''' Sauve les progs si nécessaire dans la base
    ''' </summary>
    ''' <param name="firstScan">Vrai si premier scan de la station</param>
    ''' <returns>Boolean</returns>
    ''' <remarks>
    ''' Si c'est le premier scan de la station le hashcode des programmes
    ''' doit etre à null dans la table station 
    ''' Dans ce cas on n'affiche pas le bouton  différence sur le frmMain ( tous les programmes sont différents dans ce cas ... )
    ''' </remarks>
    Public Function save(ByRef firstScan As Boolean) As Boolean
        If _programList IsNot Nothing Then
            Try
                If isProgramChanged(firstScan) Then
                    log.addLogEntry(New cLogEntry(String.Format("SQL : Sauvegarde des programmes ({0}) lignes", _programList.Count), cLogEntry.enumDebugLevel.INFO, _stationName))

                    If Not firstScan Then
                        getProgramsFromDB() ' pour comparer diff entre programmes lors du dernier scan et programmes actuelssi différences
                    End If

                    Return cMysqlStationProgramsTable.save(_programList, _stationName) > 0
                End If
            Catch ex As Exception
                log.addLogEntry(New cLogEntry("SQL : Impossible de sauvegarder programmes", cLogEntry.enumDebugLevel.ERREUR, _stationName, "", ex))
                Return False
            End Try
      
        End If

        Return False
    End Function

    ''' <summary>
    ''' retourne Vrai si genuineAdvantage détecté dans la liste des programmes
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkGenuineAdvantage() As Boolean
        If _programList Is Nothing Or _programList.Count = 0 Then Return False

        For Each program As cPrograms.InstalledProgram In _programList
            If InStr(program.DisplayName, "Genuine", CompareMethod.Binary) > 0 Then Return True
        Next

        Return False
    End Function

    Private Function isFiltered(ByVal filter As Boolean, ByVal checked As Boolean) As Boolean
        If filter Or Not checked Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub getRegistryPrograms()
        Dim programList As New List(Of InstalledProgram)
        Dim sw As New Stopwatch

        sw.Start()
        Dim bok As Boolean = cregistry.GetInstalledComponents(_stationName, programList)
        sw.Stop()

        If bok Then
            _programList = programList
            log.addLogEntry(New cLogEntry(String.Format("récupération programmes registre  {0} ms", sw.ElapsedMilliseconds), cLogEntry.enumDebugLevel.INFO, _stationName))
        End If
    End Sub

    Private Sub getProgramsFromDB()
        _programListDB = New List(Of InstalledProgram)
        cMysqlStationProgramsTable.selectProgramsforStation(_stationName, _programListDB)
    End Sub
End Class
