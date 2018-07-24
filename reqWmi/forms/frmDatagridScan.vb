Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Collections.Specialized

Public Class frmDatagridScan
    Private _bindingSource As New BindingSource
    Private _datatable As New DataTable
    Private _datatableModel As New DataTable
    Private _datatableOsName As New DataTable
    Private _saveOriginalCellColor As Color
    Private _previousSelectRowIndex As Integer
    Private _initialised As Boolean = False
    Private _listOfDisplays As List(Of cMonitorInfo.monitorEdidInfo)
    Private _currentdisplayIndex As Integer
    Private _disposed As Boolean = False
    Private WithEvents _timerDelaySearch As New Timer

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call
        Me.Name = "Scan Batch"

        Me.Icon = program.tabicons.iconDatabase
        program.frmMdiContainer.forceTabRepaint()

        ' remplit cb choix Sites
        cbSite.Items.AddRange(cbatchScan.dicsiteNames.Values.ToArray)

        With Me.DataGridViewScan
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
        End With

        Me.scDatagridScan.Panel2Collapsed = True
        Me.cbProgramExactString.Enabled = False
        Me.progBarrQuery.Visible = True

        '
        ' setup table pour filtre modele
        '
        _datatableModel.Columns.Add("modele")
        _datatableModel.Rows.Add("Tous")

        '
        ' setup table pour filtre osName
        '
        _datatableOsName.Columns.Add("osname")
        _datatableOsName.Rows.Add("Tous")

        '
        ' timer 250 ms pour delay recherche station
        '
        _timerDelaySearch.Interval = 500
    End Sub

    Private Sub loaded() Handles Me.Load
        Me.DataGridViewScan.GetType.InvokeMember("DoubleBuffered",
                                                 Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty,
                                                 Nothing, DataGridViewScan,
                                                 New Object() {True}
                                                 )

    End Sub

    Private Sub updateScanInfos()
        Me.tbNbStations.Text = _datatable.Rows.Count.ToString
        Me.tbBindingSourceCount.Text = _bindingSource.Count.ToString
        Me.tbBlocHS.Text = _datatable.Select("err_disk > 0").Count.ToString
        Me.tbBSOD.Text = _datatable.Select("err_bsod > 0").Count.ToString
        Me.tbScanKO.Text = _datatable.Select("err_message <> ''").Count.ToString
    End Sub

    Private Sub populateCmbFilterModel()
        Dim query As String = "SELECT  DISTINCT 
                                    modele
                                FROM station_infos 
                                GROUP BY 
                                    modele 
                                HAVING(COUNT(modele)> 2) 
                                ORDER BY 
                                    modele ASC"

        Try
            Using mysqlAdapter As New MySqlDataAdapter(query, cMysqlConnection.getDBConnectionString)
                mysqlAdapter.Fill(_datatableModel)

                Me.cmbFilterModel.ValueMember = "modele"
                Me.cmbFilterModel.DataSource = _datatableModel
            End Using
        Catch ex As Exception
            Debug.Print("erreur cmbModel")
        Finally
            'dt.Dispose()
        End Try
    End Sub

    Private Sub populateCmbfilterOsName()
        Dim query As String = "SELECT  DISTINCT osname FROM station_infos ORDER BY osname ASC"

        Try
            Using mysqlAdapter As New MySqlDataAdapter(query, cMysqlConnection.getDBConnectionString)
                mysqlAdapter.Fill(_datatableOsName)

                Me.cmbFilterOsName.ValueMember = "osname"
                Me.cmbFilterOsName.DataSource = _datatableOsName
            End Using
        Catch ex As Exception
            Debug.Print("erreur cmbOsName")
        Finally
            'dt.Dispose()
        End Try
    End Sub

    Private Sub frm_load() Handles Me.Load
        '
        ' Restauration des préférences
        '
        With program.preferences
            cbSite.SelectedItem = .sSite
            cbDeletedStations.Checked = .bShowDeletedComputers
            cbShowScanKO.Checked = .bShowScanKO
            cbFilterDateScan.Checked = .bFilterDateScan
        End With

        populateCmbFilterModel()
        populateCmbfilterOsName()

        Dim errMessage As String = Nothing
        If Not setBindingSource(errMessage) Then
            MsgBox(String.Format("Une erreur est survenue ! {0} Message : {1}", Environment.NewLine, errMessage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        DataGridViewScan.Columns(1).Frozen = True
        addDiskFreePercentColumn()
        restoreDatagridViewColumnState()

        ' renommage des colonnes
        ' générées automatiquement d'après champs BDD ( autogeneratecolums = true )
        With DataGridViewScan
            .Columns("hdd_free_space_percent").Visible = False
            .Columns("deleted").SortMode = DataGridViewColumnSortMode.Automatic
            .Columns("station_name").HeaderText = "Station"
            .Columns("datescan").HeaderText = "Date Scan"
            .Columns("serialnumber").HeaderText = "SN"
            .Columns("err_disk").HeaderText = "BlocHs"
            .Columns("driver_predict_fail").HeaderText = "DriverFail"
            .Columns("err_network").HeaderText = "ErrNetwork"
            .Columns("err_reboot").HeaderText = "ErrReboot"
            .Columns("err_bsod").HeaderText = "BSOD"
            .Columns("freespaceondisk").HeaderText = "Free c:\ (Go)"
            .Columns("smartstatus").HeaderText = "Smart"
            .Columns("username").HeaderText = "Session"
            .Columns("towercase").Visible = False
        End With

        updateScanInfos()

        _initialised = True
    
    End Sub

    Private Sub cbSiteindexChanged_Handler(ByVal sender As System.Object, _
                                           ByVal e As System.EventArgs) Handles cbSite.SelectedIndexChanged, _
                                                                                cmbFilterModel.SelectedIndexChanged, _
                                                                                cmbFilterOsName.SelectedIndexChanged

        If _initialised And Not _disposed Then
            Dim errMessage As String = Nothing
            If Not setBindingSource(errMessage) Then
                MsgBox(String.Format("Une erreur est survenue ! {0} Message : {1}", Environment.NewLine, errMessage), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If

    End Sub

    Private Sub cellFormatingEvent_Handler(ByVal sender As Object, _
                                           ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridViewScan.CellFormatting

        If DataGridViewScan.Columns(e.ColumnIndex).Name = "err_bsod" _
        Or DataGridViewScan.Columns(e.ColumnIndex).Name = "err_disk" _
        Or DataGridViewScan.Columns(e.ColumnIndex).Name = "err_reboot" Then

            If Not IsDBNull(e.Value) Then
                Dim value As Integer = CType(e.Value, Integer)
                If value > 0 Then
                    e.CellStyle.BackColor = Color.Red
                End If
            End If
        ElseIf DataGridViewScan.Columns(e.ColumnIndex).Name = "ram" Then
            e.Value = functions.convRamAsUlongToString(e.Value)
        End If

        ' coloration orange si ML450 / VL350 boitier TOUR
        If DataGridViewScan.Columns(e.ColumnIndex).Name = "modele" Then
            With DataGridViewScan
                If Not IsDBNull(.Rows(e.RowIndex).Cells("towercase").Value) Then
                    Dim towerCase As Boolean = CType(.Rows(e.RowIndex).Cells("towercase").Value, Boolean)
                    If towerCase Then
                        e.CellStyle.BackColor = Color.Orange
                    End If
                End If
            End With
        End If

    End Sub

    Private Sub rowLeave_Handler(ByVal sender As Object, _
                                 ByVal e As DataGridViewCellEventArgs) Handles DataGridViewScan.CellMouseLeave
        If e.RowIndex >= 0 Then
            CType(sender, DataGridView).Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
        End If
    End Sub

    Private Sub rowHover_Handler(ByVal sender As Object, _
                                 ByVal e As DataGridViewCellEventArgs) Handles DataGridViewScan.CellMouseEnter
        If e.RowIndex >= 0 Then
            CType(sender, DataGridView).Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
        End If
    End Sub

    Private Sub cellDblClick_Handler() Handles DataGridViewScan.CellDoubleClick
        If DataGridViewScan.SelectedRows.Count > 0 Then
            Dim stationName As String = DataGridViewScan.SelectedRows(0).Cells("station_name").Value.ToString

            If Not program.frmMdiContainer.isTabAlreadyOpened(stationName) Then
                program.frmMdiContainer.addTab(stationName)
            End If
        End If
    End Sub

    Private Sub addDiskFreePercentColumn()
        Dim percentDiskSpaceColumn As New DataGridViewPercentageColumn.DataGridViewPercentageColumn
        With percentDiskSpaceColumn
            .HeaderText = "Libre"
            .DataPropertyName = "hdd_free_space_percent"
            .DisplayIndex = 16
            .SortMode = DataGridViewColumnSortMode.Automatic
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        DataGridViewScan.Columns.Add(percentDiskSpaceColumn)
    End Sub

    Private Sub frm_closing(ByVal sender As System.Object, _
                            ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        program.preferences.saveDataGridViewColumnState(getDatagridViewColumnsState)

        With program.preferences
            'If cbDeletedStations.Checked <> .bShowDeletedComputers Or _
            'cbShowScanKO.Checked <> .bShowScanKO Or _
            ' cbFilterDateScan.Checked <> .bFilterDateScan Then

            .bShowDeletedComputers = cbDeletedStations.Checked
            .bShowScanKO = cbShowScanKO.Checked
            .bFilterDateScan = cbFilterDateScan.Checked
            '.prefToSettings()
            'End If
        End With

        '_bindingSource.Dispose()
        ' _timerDelaySearch.Dispose()
    End Sub

    Private Function getDatagridViewColumnsState() As StringCollection
        Dim stringCollection As New StringCollection

        Dim i As Integer = 0
        For Each col As DataGridViewColumn In DataGridViewScan.Columns
            stringCollection.Add(String.Format("{0},{1},{2},{3}", col.DisplayIndex.ToString("D2"), col.Width, col.Visible, i))
            i += 1
        Next

        Return stringCollection
    End Function

    Private Sub restoreDatagridViewColumnState()
        Dim colState As StringCollection = program.preferences.sColDataGridViewState

        If Not colState Is Nothing Then
            Dim colsArray As String()
            ReDim colsArray(colState.Count - 1)
            colState.CopyTo(colsArray, 0)
            Array.Sort(colsArray)

            Try
                For i = 0 To colsArray.Length - 1 Step 1
                    Dim state() As String = colsArray(i).Split(CChar(","))
                    Dim index As Integer = Int16.Parse(state(3))
                    With DataGridViewScan
                        .Columns(index).DisplayIndex = Int16.Parse(state(0))
                        .Columns(index).Width = Int16.Parse(state(1))
                        .Columns(index).Visible = Boolean.Parse(state(2))
                    End With
                Next
            Catch ex As Exception
                log.addLogEntry(New cLogEntry("Impossible de restaurer Etat DatagridView", cLogEntry.enumDebugLevel.ERREUR))
            End Try

        End If
    End Sub

    Private Function getSqlWhereFilterSite() As String
        Dim filterSiteSQL, filter As String
        filterSiteSQL = String.Empty

        Select Case (cbSite.Text)
            Case cbatchScan.dicsiteNames("PEL")
                filter = "'P%'"
            Case cbatchScan.dicsiteNames("SA")
                filter = "'S%'"
            Case cbatchScan.dicsiteNames("HL")
                filter = "'H%' OR station.station_name LIKE 'X%'"
            Case cbatchScan.dicsiteNames("DG")
                filter = "'D%'"
            Case cbatchScan.dicsiteNames("LCA")
                filter = "'L%' OR station.station_name LIKE 'C%'"
            Case Else
                filter = ""
        End Select

        If filter <> "" Then filterSiteSQL = String.Format("station.station_name LIKE {0}", filter)

        Return filterSiteSQL
    End Function

    Private Function getSqlWhereFilterDeleted() As String
        Dim filterSiteSQL As String = String.Empty

        ' si cb filtre station effacés n'est pas coché on ne charge 
        ' que les stations qui ne sont pas en état éffacé
        If Not cbDeletedStations.Checked Then
            filterSiteSQL = "station.deleted ='0'"
        End If

        Return filterSiteSQL
    End Function

    Private Function getSqlWhereFilterScanKO() As String
        Dim filterSiteSQL As String = String.Empty

        If Not cbShowScanKO.Checked Then
            filterSiteSQL = "station.err_message IS null"
        End If

        Return filterSiteSQL
    End Function

    Private Function getSqlWhereDatescan() As String
        Dim filterDatescan As String = String.Empty

        If cbFilterDateScan.Checked Then
            filterDatescan = "datescan BETWEEN DATE_SUB(NOW(), INTERVAL 2 MONTH) AND NOW()"
        End If

        Return filterDatescan
    End Function

    Private Function getSqlWhereProgram() As String
        Dim filterProgramSQL As String = String.Empty

        Dim escapedSearchText As String = MySql.Data.MySqlClient.MySqlHelper.EscapeString(tbSearch.Text)

        If cbSearchForProgram.Checked Then
            If Not cbProgramExactString.Checked Then
                filterProgramSQL = String.Format("MATCH (program_name) AGAINST ('{0}')  ", escapedSearchText)
            Else
                filterProgramSQL = String.Format("MATCH (program_name) AGAINST ('""{0}""' IN BOOLEAN MODE)  ", escapedSearchText)
            End If

        End If

        Return filterProgramSQL
    End Function

    Private Function getSqlWhereModele() As String
        Dim filterModeleSQL As String = String.Empty

        If cmbFilterModel.Text <> "Tous" Then
            filterModeleSQL = String.Format("modele='{0}'", cmbFilterModel.Text)
        End If

        Return filterModeleSQL
    End Function

    Private Function getsqlWhereOsName() As String
        Dim filterOsName As String = String.Empty

        If cmbFilterOsName.Text <> "Tous" Then
            filterOsName = String.Format("osname='{0}'", cmbFilterOsName.Text)
        End If

        Return filterOsName
    End Function

    Private Function getSqlWherefilter() As String
        Dim listSqlfilterString As New List(Of String)
        Dim filterString As String = String.Empty

        With listSqlfilterString
            .Add(getSqlWhereProgram)
            .Add(getSqlWhereFilterDeleted)
            .Add(getSqlWhereFilterScanKO)
            .Add(getSqlWhereFilterSite)
            .Add(getSqlWhereModele)
            .Add(getsqlWhereOsName)
            .Add(getSqlWhereDatescan)
        End With

        For Each Filter As String In listSqlfilterString
            If Not Filter = String.Empty Then
                If filterString = String.Empty Then
                    filterString += " WHERE "
                Else
                    filterString += " AND "
                End If

                ' filterString += "( " & Filter & " ) "

                filterString += String.Format("( {0} )", Filter)
            End If
        Next

        Return filterString
    End Function

    Private Sub cbSearchProgramCheckedChanged() Handles cbSearchForProgram.CheckedChanged, _
                                                        cbProgramExactString.CheckedChanged

        Me.cbProgramExactString.Enabled = cbSearchForProgram.Checked

        If cbSearchForProgram.Checked Then
            _bindingSource.Filter = ""
        End If

        If cbSearchForProgram.Checked And tbSearch.Text.Trim = String.Empty Then
            Exit Sub

        End If

        Dim errMsg As String = Nothing
        setBindingSource(errMsg)
        'End If
    End Sub

    Private Sub setControlsWhileQuerying(ByVal val As Boolean)
        Me.tbSearch.Enabled = val
        Me.cbDeletedStations.Enabled = val
        Me.cbProgramExactString.Enabled = val
        Me.cbSearchForProgram.Enabled = val
        Me.cbSite.Enabled = val
        Me.cbShowScanKO.Enabled = val
    End Sub

    ''' <summary>
    ''' Throws Exception
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    Private Function setBindingSource(ByRef errMessage As String) As Boolean
        Me.progBarrQuery.Visible = True

        Application.DoEvents()

        If _datatable.Rows.Count > 0 Then
            _datatable.Clear()
        End If

        Dim query As String = "SELECT DISTINCT datescan , station.station_name, modele, constructeur, osname, serialnumber, ram, err_disk,
                                driver_predict_fail, err_network, err_reboot, err_bsod, socle, freespaceondisk, 
                                hdd_total_space as 'Cap. (Go)', hdd_free_space_percent , smartstatus, uptime, deleted,err_message, towercase, username
                                FROM station 
                                LEFT JOIN station_infos On station.station_Name = station_infos.station_name 
                                LEFT Join station_logs On station.station_Name = station_logs.station_name"

        If cbSearchForProgram.Checked And tbSearch.Text <> String.Empty Then
            query += " INNER JOIN station_programs On station_programs.station_name = station.station_name"
        End If

        query += getSqlWherefilter()

        Try
            Using mysqlAdapter As New MySqlDataAdapter(query, cMysqlConnection.getDBConnectionString)
                mysqlAdapter.Fill(_datatable)
            End Using
        Catch ex As Exception
            errMessage = ex.Message
            Return False
        Finally
            Me.progBarrQuery.Visible = False
        End Try

        _bindingSource.DataSource = _datatable ' nécessaire pour recherche 
        Me.DataGridViewScan.DataSource = _datatable
        Me.DataGridViewScan.Refresh()

        updateScanInfos()
        updateCollapsiblePanels()

        Return True
    End Function

    Private Sub setBindingSourceFilter(Optional ByVal filter As String = "")
        filter = filter.Replace("'", "")

        _bindingSource.Filter = String.Format("station_name LIKE '%{0}%' OR serialnumber LIKE '%{0}%' OR username LIKE '%{0}%'", filter)
        Me.DataGridViewScan.Refresh()

        updateScanInfos()
    End Sub

    Private Sub searchStation() Handles _timerDelaySearch.Tick
        _timerDelaySearch.Stop()

        If cbSearchForProgram.Checked Then
            Dim errMsg As String = Nothing

            If tbSearch.Text.Trim <> String.Empty Then
                setBindingSource(errMsg)
            End If

        Else
            setBindingSourceFilter(clearInput(Me.tbSearch.Text))
        End If
    End Sub

    ''' <summary>
    ''' Filtre input champs recherche station
    ''' empêche crash requete sql si caractères spéciaux dans la chaine de recherche
    ''' </summary>
    ''' <param name="strIN"></param>
    ''' <returns></returns>
    ''' <remarks>Le modèle d'expression régulière [^\w\.@-] correspond à tout caractère 
    ''' qui n'est pas un caractère alphabétique, un point, un symbole @ ou un tiret.
    ''' </remarks>
    Private Function clearInput(ByVal strIN As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(strIN, "[^\w\.@-]", "")
    End Function

    Private Sub tbSearchHandler() Handles tbSearch.TextChanged
        If Not _timerDelaySearch.Enabled = True Then
            _timerDelaySearch.Enabled = True
        Else
            _timerDelaySearch.Stop()
            _timerDelaySearch.Start()
        End If
    End Sub

    Private Sub frm_close() Handles Me.FormClosed
        Dispose()
    End Sub

    Private Overloads Sub dispose()
        MyBase.Dispose()

        _disposed = True
        _bindingSource.Dispose()
        _datatable.Dispose()
        _datatableModel.Dispose()
        _datatableOsName.Dispose()
        _timerDelaySearch.Dispose()
        Me.DataGridViewScan.Dispose()
    End Sub

    Private Sub btnReload_Click(ByVal sender As System.Object, _
                                ByVal e As System.EventArgs) Handles btnReload.Click

        Dim selectedRowIndex As Integer = -1
        If DataGridViewScan.SelectedRows().Count > 0 Then
            selectedRowIndex = DataGridViewScan.SelectedRows(0).Index
        End If

        Dim errMessage As String = Nothing
        If Not setBindingSource(errMessage) Then
            MsgBox("Une erreur est survenue ! " & vbNewLine & "Message : " & errMessage, MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If selectedRowIndex <> -1 And _
        DataGridViewScan.Rows.Count > 0 Then
            DataGridViewScan.Rows(selectedRowIndex).Selected = True

            If Not DataGridViewScan.Rows(selectedRowIndex).Displayed Then
                DataGridViewScan.FirstDisplayedScrollingRowIndex = selectedRowIndex
            End If
        End If

    End Sub

    Private Sub btncollapsePanelInfos_Click(ByVal sender As System.Object, _
                                            ByVal e As System.EventArgs) Handles btCollapsePanelInfos.Click
        Me.scDatagridScan.Panel2Collapsed = Not scDatagridScan.Panel2Collapsed
    End Sub

    Private Sub filterCbHandler() Handles cbDeletedStations.CheckedChanged, _
                                            cbShowScanKO.CheckedChanged, _
                                            cbFilterDateScan.CheckedChanged

        If _datatable.Rows.Count > 0 Then
            Dim errMessage As String = Nothing
            If Not setBindingSource(errMessage) Then
                MsgBox("Une erreur est survenue ! " & vbNewLine & "Message : " & errMessage, MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            updateScanInfos()
        End If
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, _
                                     ByVal e As System.EventArgs) Handles btnExportExcel.Click

        Dim frmExportDialog As New frmExportDialog(_datatable.DefaultView.Count)

        Dim dataSet As New DataSet
        Dim dtDisplays As DataTable = cMysqlDisplaysTable.getDataTable
        Dim dtStation As DataTable = _datatable.DefaultView.ToTable

        With dataSet.Tables
            .Add(dtStation)
            .Add(dtDisplays)
        End With

        Dim dr As New DataRelation("Displays", dtStation.Columns("station_name"), dtDisplays.Columns("station_name"), False)

        dataSet.Relations.Add(dr)

        Dim excelExporter As New cexcel(dataSet)
        Dim t As New System.Threading.Thread(AddressOf excelExporter.export)
        t.Start()

        dataSet.Dispose()
        dataSet = Nothing

        ' todo handlers non removés
        AddHandler excelExporter.lineProcess, AddressOf frmExportDialog.updateDialog
        AddHandler excelExporter.exportKO, AddressOf frmExportDialog.exportKo


        frmExportDialog.ShowDialog()
    End Sub

#Region "Collapsible panels"
    Private Sub row_selected() Handles DataGridViewScan.SelectionChanged
        If _initialised Then
            razCollapsiblePanel(Me.collapsiblePanelOrdinateur)
            razCollapsiblePanel(Me.CollapsiblePanelOs)
            razCollapsiblePanel(Me.CollapsiblePanelDisplay)
            razCollapsiblePanel(Me.CollapsiblePanelProgrammes)
            _currentdisplayIndex = Nothing

            updateCollapsiblePanels()
        End If
    End Sub

    ''' <summary>
    ''' Remise à zéro Collapsible panels
    ''' TODO dupliqué avec frmMain
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
            ElseIf TypeOf (control) Is ListView Then
                CType(control, ListView).Items.Clear()
            End If
        Next
    End Sub

    Private Sub updateCollapsiblePanels()
        If DataGridViewScan.SelectedRows.Count > 0 Then
            Dim currentRow As DataGridViewRow = DataGridViewScan.SelectedRows(0)

            ' Ordinateur
            Me.tbConstructeur.Text = currentRow.Cells("constructeur").Value.ToString
            Me.tbModele.Text = currentRow.Cells("modele").Value.ToString
            Me.tbMemoireTotale.Text = convRamAsUlongToString(currentRow.Cells("ram").Value)
            Me.tbSerialNumber.Text = currentRow.Cells("serialnumber").Value.ToString
            Me.tbHostname.Text = currentRow.Cells("station_name").Value.ToString
            ' Systeme exploitation
            Me.tbOperatingSystem.Text = currentRow.Cells("osname").Value.ToString
            Me.tbSocle.Text = currentRow.Cells("socle").Value.ToString
            Me.tbUpTime.Text = currentRow.Cells("uptime").Value.ToString
            ' Récupère liste écran pour la station sélectionnée
            _listOfDisplays = cMysqlDisplaysTable.selectdisplaysForStation(DataGridViewScan.SelectedRows(0).Cells(1).Value.ToString)
            If _listOfDisplays.Count > 0 Then
                updateDisplayInfos()
            End If

            '
            ' Maj Programmes
            ' TODO => insérer timer pour éviter requete SQL en chaines lors du parcours rapide des lignes .... 
            '
            Dim programList As New List(Of cPrograms.InstalledProgram)
            cMysqlStationProgramsTable.selectProgramsforStation(Me.tbHostname.Text, programList)

            Me.LvProgramsBatch.updateitemsForStation(programList)

        End If
    End Sub

    Private Sub updateDisplayInfos()
        If _currentdisplayIndex = Nothing Then
            _currentdisplayIndex = 0
        End If

        Dim display As cMonitorInfo.monitorEdidInfo = _listOfDisplays(_currentdisplayIndex)

        With display
            Me.tbMonitorName.Text = .monitorName
            Me.tbMonitorSerialNumber.Text = .serialNumber
            Me.tbMonitorDisplayName.Text = .displayName
        End With

        If _listOfDisplays.Count > 1 Then
            Me.btDisplayDetails.Enabled = True
            Me.btDisplayNext.Enabled = True
            Me.btDisplayPrev.Enabled = True
            Me.lbDisplayCount.Text = String.Format("{0}/{1}", _currentdisplayIndex + 1, _listOfDisplays.Count)
        End If
    End Sub

    Private Sub displayPrevNext(ByVal sender As Object,
                                ByVal e As System.EventArgs) Handles btDisplayNext.Click, btDisplayPrev.Click

        Dim bt As Button = CType(sender, Button)

        If bt.Tag.ToString = "next" Then
            If Not _listOfDisplays.Count - 1 = _currentdisplayIndex Then
                _currentdisplayIndex += 1
            End If

        Else
            If _currentdisplayIndex <> 0 Then
                _currentdisplayIndex -= 1
            End If
        End If

        updateDisplayInfos()
    End Sub

#End Region


End Class