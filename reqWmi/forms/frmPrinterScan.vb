Imports System.Data
Imports MySql.Data.MySqlClient


Public Class frmPrinterScan
    Private _bindingSource As New BindingSource
    Private _datatable As New DataTable
    Private _initialized As Boolean = False
    Private WithEvents _timerDelaySearch As New Timer

    Private Sub frm_load() Handles Me.Load

        Dim errMessage As String = Nothing
        If Not setBindingSource(errMessage) Then
            MsgBox(String.Format("Une erreur est survenue ! {0} Message : {1}", Environment.NewLine, errMessage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        printerDataGridView.Columns(1).Frozen = True

        ' renommage des colonnes
        With printerDataGridView
            .Columns("printer_datescan").HeaderText = "DateScan"
            .Columns("printer_ldap_printername").HeaderText = "Nom LDAP"
            .Columns("printer_ldap_location").HeaderText = "Localisation"
            .Columns("printer_ldap_description").HeaderText = "Description"
            .Columns("printer_ldap_port_ip").HeaderText = "Port LDAP"
            .Columns("printer_ldap_sharename").HeaderText = "Nom Partage"
            .Columns("printer_ldap_shortservername").HeaderText = "Serveur"
            .Columns("printer_ldap_drivername").HeaderText = "Driver"
            .Columns("printer_snmp_model").HeaderText = "Modele SNMP"
            .Columns("printer_snmp_hostname").HeaderText = "Nom SNMP"
            .Columns("printer_snmp_serial").HeaderText = "Num. Serie SNMP"
            .Columns("printer_err_message").HeaderText = "Erreur SNMP"
        End With

        populateCbPrintServerList()
        populateCbPrinterModelLIst()

        _initialized = True
    End Sub

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()
        Me.Name = "Scan Impr."

        Me.Icon = program.tabicons.iconPrinterScan
        program.frmMdiContainer.forceTabRepaint()

        cbSiteSelect.Items.AddRange(cbatchScan.dicsiteNames.Values.ToArray)
        cbSiteSelect.SelectedIndex = cbSiteSelect.FindStringExact("Tous")

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        With Me.printerDataGridView
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

        '
        ' timer 250 ms pour delay recherche station
        '
        _timerDelaySearch.Interval = 500
    End Sub

    'a hériter d'un datagridView specialisé
    Private Sub loaded() Handles Me.Load
        Me.printerDataGridView.GetType.InvokeMember("DoubleBuffered",
                                                 Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty,
                                                 Nothing, printerDataGridView,
                                                 New Object() {True}
                                                 )

    End Sub

    Private Sub populateCbPrintServerList()
        Dim printerServerList As ArrayList = ldapWrapper.getDomainStationList("OU=Impression,OU=Serveurs")
        printerServerList.Sort()
        printerServerList.Insert(0, "Tous")

        cbPrintServerList.DataSource = printerServerList
    End Sub

    ''' <summary>
    ''' Gestion des filtres d'affichage
    ''' </summary>
    Private Sub onChangeFilter() Handles cbPrinterModeList.SelectedIndexChanged,
                                         cbPrintServerList.SelectedIndexChanged,
                                         cbFilterSNMPKO.CheckedChanged,
                                         cbSiteSelect.SelectedIndexChanged

        If Not _initialized Then Return

        Dim bFilterSNMPKO As Boolean
        Dim sFilterModel, sFilterServer, sFilterNameOrSerial As String
        Dim lFilterSQL As New List(Of String)

        sFilterNameOrSerial = clearInput(Me.tbPrinterSearch.Text)
        sFilterModel = CType(cbPrinterModeList.SelectedValue, DataRowView).Item("printer_ldap_drivername").ToString
        sFilterServer = cbPrintServerList.SelectedValue.ToString

        bFilterSNMPKO = cbFilterSNMPKO.Checked

        Dim sArgSQLFilterModel As String = String.Format("printer_ldap_drivername LIKE '%{0}%'", sFilterModel)
        Dim sArgSQLFilterServer As String = String.Format("printer_ldap_shortservername='{0}'", sFilterServer)
        Dim sArgSQLFilterSNMPKO As String = "printer_err_message Is  null"
        Dim sArgSQLFilterNameOrSerial As String = String.Format("printer_ldap_printername LIKE '%{0}%' OR printer_snmp_serial LIKE '%{0}%' OR printer_ldap_port_ip LIKE '%{0}%'", sFilterNameOrSerial)

        If Not sFilterModel = "Tous" Then
            lFilterSQL.Add(sArgSQLFilterModel)
        End If
        If Not sFilterServer = "Tous" Then
            lFilterSQL.Add(sArgSQLFilterServer)
        End If
        If bFilterSNMPKO Then
            lFilterSQL.Add(sArgSQLFilterSNMPKO)
        End If

        Dim sFilterSite As String = getSqlWhereFilterSite()
        If Not sFilterSite = String.Empty Then
            lFilterSQL.Add(sFilterSite)
        End If

        lFilterSQL.Add(sArgSQLFilterNameOrSerial)


        If lFilterSQL.Count = 0 Then
            _bindingSource.RemoveFilter()
            Return
        End If

        Dim filterString As String = ""
        For Each Filter As String In lFilterSQL
            If Not filterString = String.Empty Then
                filterString += " AND "
            End If

            filterString += String.Format("( {0} )", Filter)
        Next

        _bindingSource.Filter = filterString

        Me.printerDataGridView.Refresh()
        updateScanInfo()
    End Sub

    Private Function getSqlWhereFilterSite() As String
        Dim filterSiteSQL, filter As String
        filterSiteSQL = String.Empty

        Select Case (cbSiteSelect.Text)
            Case cbatchScan.dicsiteNames("PEL")
                filter = "'P%'"
            Case cbatchScan.dicsiteNames("SA")
                filter = "'S%'"
            Case cbatchScan.dicsiteNames("HL")
                filter = "'H%' OR printer_ldap_printername LIKE 'X%'"
            Case cbatchScan.dicsiteNames("DG")
                filter = "'D%'"
            Case cbatchScan.dicsiteNames("LCA")
                filter = "'L%' OR printer_ldap_printername LIKE 'C%'"
            Case Else
                filter = String.Empty
        End Select

        If filter <> "" Then filterSiteSQL = String.Format("printer_ldap_printername Like {0}", filter)

        Return filterSiteSQL
    End Function

    Private Sub populateCbPrinterModelLIst()
        Dim dtPrinterModelList As New DataTable

        dtPrinterModelList.Columns.Add("printer_ldap_drivername")
        dtPrinterModelList.Rows.Add("Tous")

        Dim query As String = "SELECT DISTINCT 
                                    printer_ldap_drivername
                               FROM 
                                    printers
                               GROUP BY 
                                    printer_ldap_drivername
                               HAVING (COUNT(printer_ldap_drivername)>5)
                               ORDER BY 
                               printer_ldap_drivername"

        Try
            Using mysqlAdapter As New MySqlDataAdapter(query, cMysqlConnection.getDBConnectionString)

                mysqlAdapter.Fill(dtPrinterModelList)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        cbPrinterModeList.DataSource = dtPrinterModelList
        cbPrinterModeList.DisplayMember = "printer_ldap_drivername"

    End Sub

    Private Sub updateScanInfo()
        Me.tbLineCount.Text = _bindingSource.Count.ToString
    End Sub

    Private Function setBindingSource(ByRef errMsg As String) As Boolean
        Dim query As String = "SELECT 
                                    printer_datescan,
                                    printer_ldap_printername,
                                    printer_ldap_shortservername,
                                    printer_ldap_port_ip, 
                                    printer_ldap_drivername,
                                    printer_ldap_location,
                                    printer_snmp_model,
                                    printer_snmp_hostname,
                                    printer_snmp_serial,
                                    printer_ldap_description,
                                    printer_ldap_sharename,
                                    printer_err_message
                               FROM 
                                    printers"

        Try
            Using mysqlAdapter As New MySqlDataAdapter(query, cMysqlConnection.getDBConnectionString)
                mysqlAdapter.Fill(_datatable)
            End Using
        Catch ex As Exception

            Return False
        Finally

        End Try

        _bindingSource.DataSource = _datatable ' nécessaire pour recherche 
        Me.printerDataGridView.DataSource = _datatable
        Me.printerDataGridView.Refresh()

        With printerDataGridView
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .AutoResizeColumns()
            .AllowUserToResizeColumns = True
            .AllowUserToOrderColumns = True
        End With

        updateScanInfo()

        Return True
    End Function

    'Private Sub setBindingSourceFilter()

    '    '_bindingSource.Filter = String.Format("printer_ldap_printername LIKE '%{0}%' OR printer_snmp_serial LIKE '%{0}%'", sFilter)

    '    ' printerDataGridView.Refresh()
    '    ' updateScanInfo()

    'End Sub

    Private Sub tbSearchPrinterHandler() Handles tbPrinterSearch.TextChanged
        If Not _timerDelaySearch.Enabled = True Then
            _timerDelaySearch.Enabled = True
        Else
            _timerDelaySearch.Stop()
            _timerDelaySearch.Start()
        End If
    End Sub


    Private Sub searchPrinter() Handles _timerDelaySearch.Tick
        _timerDelaySearch.Stop()


        ' setBindingSourceFilter()
        onChangeFilter()
    End Sub

    Private Sub rowLeave_Handler(ByVal sender As Object,
                                 ByVal e As DataGridViewCellEventArgs) Handles printerDataGridView.CellMouseLeave
        If e.RowIndex >= 0 Then
            CType(sender, DataGridView).Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
        End If
    End Sub

    Private Sub rowHover_Handler(ByVal sender As Object,
                                 ByVal e As DataGridViewCellEventArgs) Handles printerDataGridView.CellMouseEnter
        If e.RowIndex >= 0 Then
            CType(sender, DataGridView).Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
        End If
    End Sub

    Private Sub frm_closing() Handles Me.Closing
        _timerDelaySearch.Dispose()
        _datatable.Dispose()
        _bindingSource.Dispose()
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

    Private Sub cellDblClick_Handler() Handles printerDataGridView.CellDoubleClick
        If printerDataGridView.SelectedRows.Count > 0 Then
            Dim printerName As String = printerDataGridView.SelectedRows(0).Cells("printer_ldap_printername").Value.ToString

            If Not program.frmMdiContainer.isTabAlreadyOpened(printerName) Then
                program.frmMdiContainer.addTab(printerName)
            End If
        End If
    End Sub

    'Private Sub onChangeFilter(sender As Object, e As EventArgs) Handles cbPrintServerList.SelectedIndexChanged, cbPrinterModeList.SelectedIndexChanged, cbFilterSNMPKO.CheckedChanged

    'End Sub
End Class