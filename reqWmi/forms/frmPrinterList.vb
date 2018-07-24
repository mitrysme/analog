Imports System.Data

Public Class frmPrinterList

    Private _stationName As String
    Private _currentProfile As String
    Private _sc As Threading.SynchronizationContext
    Private _lastErrMsg As String = Nothing
    Private _DefaultPrinterBitmap As Bitmap = My.Resources.ok16
    Private _dt As New DataTable
    Private _strPrinterLIst As List(Of strPrinter)

    Public Sub New(ByVal stationName As String,
                   ByVal currentProfile As String)

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        _stationName = stationName
        _currentProfile = currentProfile

        _sc = Threading.SynchronizationContext.Current
    End Sub

    Public Structure strPrinter
        Public printerName As String
        Public serverName As String
        Public defaultPrinter As Boolean
    End Structure

    Private Sub frm_load() Handles Me.Load
        setWindowTitle()
        Me.ProgressBarPrinter.Visible = False
        Me.CenterToParent()
        Me.tbCurrentProfile.Text = _currentProfile

        setDatagridView()

        _dt.Columns.Add("printerName")
        _dt.Columns.Add("printerServerName")
        _dt.Columns.Add("defaultPrinter")

        dgvPrinterList.DataSource = _dt

        System.Threading.Tasks.Task.Factory.StartNew(AddressOf getData)
    End Sub

    Private Sub setbindingsource()

        If _strPrinterLIst Is Nothing Then
            Debug.Print("setbindingsource() La liste d'imprimantes est vide .... abandon ...")
            Exit Sub
        End If

        _dt.Rows.Clear()

        For Each strPrinter As strPrinter In _strPrinterLIst
            _dt.Rows.Add(strPrinter.printerName, strPrinter.serverName, strPrinter.defaultPrinter)
        Next

        Me.dgvPrinterList.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.AllCells)
        dgvPrinterList.Refresh()

    End Sub

    Private Sub getData()

        _strPrinterLIst = getPrinterList()
        _sc.Post(Sub() setbindingsource(), Nothing)

    End Sub

    Private Sub setDatagridView()
        Me.dgvPrinterList.ReadOnly = True
        Me.dgvPrinterList.AllowUserToAddRows = False
        Me.dgvPrinterList.AutoGenerateColumns = False
        Me.dgvPrinterList.RowHeadersVisible = False

        Dim colPrinterName As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        colPrinterName.DataPropertyName = "printerName"
        colPrinterName.HeaderText = "Imprimante"

        Dim colPrinterserverName As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        colPrinterserverName.HeaderText = "serveur"
        colPrinterserverName.DataPropertyName = "printerServerName"

        Dim colPrinterInterface As DataGridViewButtonColumn = New DataGridViewButtonColumn
        colPrinterInterface.HeaderText = "Interface"
        colPrinterInterface.UseColumnTextForButtonValue = True
        colPrinterInterface.Text = "+"

        Dim colPrinterDefault As DataGridViewImageColumn = New DataGridViewImageColumn(False)
        colPrinterDefault.DefaultCellStyle.NullValue = Nothing
        colPrinterDefault.HeaderText = "defaut"

        Dim colPrinterDefaultHidden As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        colPrinterDefaultHidden.Visible = False
        colPrinterDefaultHidden.DataPropertyName = "defaultPrinter"

        dgvPrinterList.Columns.AddRange(New DataGridViewColumn() {colPrinterName, colPrinterserverName, colPrinterInterface, colPrinterDefault, colPrinterDefaultHidden})

        Me.dgvPrinterList.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.AllCells)
        Me.dgvPrinterList.AutoResizeColumn(2, DataGridViewAutoSizeColumnMode.AllCells)
    End Sub

    Private Sub cellFormatingEvent_Handler(ByVal sender As Object,
                                           ByVal e As DataGridViewCellFormattingEventArgs) Handles dgvPrinterList.CellFormatting

        If e.ColumnIndex = 3 Then
            Dim imageCell As DataGridViewImageCell = CType(dgvPrinterList.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewImageCell)

            If CType(dgvPrinterList.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value, Boolean) = True Then
                imageCell.Value = _DefaultPrinterBitmap
            Else
                imageCell.Value = Nothing
            End If

        End If

    End Sub

    Private Sub cellButtonClick_Handler(ByVal sender As Object,
                                        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrinterList.CellClick

        If e.ColumnIndex = 2 And e.RowIndex >= 0 Then
            Dim printerName As String = dgvPrinterList.Rows(e.RowIndex).Cells(0).Value.ToString

            Dim ldapPrinterProps As New ldapWrapper.ldapPrinterProperties

            If ldapWrapper.getLDAPPrinterINfos(printerName, ldapPrinterProps) Or
                ((Control.ModifierKeys And Keys.Control) = Keys.Control) Then
                program.frmMdiContainer.addTabPrinter(printerName, ldapPrinterProps)
            End If

        End If

    End Sub

    Private Sub closing_Handler() Handles Me.Closing
        _dt.Dispose()
        _DefaultPrinterBitmap.Dispose()
        Me.dgvPrinterList.Dispose()
    End Sub

    Private Sub setWindowTitle(Optional ByVal stationName As String = "")
        Me.Text = String.Format("Analog : {0} : Infos Imprimantes", _stationName)
    End Sub

    Private Sub setProgressBarvisible(ByVal bvisible As Object)
        Me.ProgressBarPrinter.Visible = CBool(bvisible)
    End Sub


    Private Function getPrinterList() As List(Of strPrinter)

        If String.IsNullOrEmpty(_currentProfile) Then
            Return Nothing
        End If

        Dim printerlist As New List(Of String)
        Dim defaultPrinterName As String = Nothing
        Dim dicprofileList As New Dictionary(Of String, String)
        Dim ListOfstrPrinterLIst As New List(Of strPrinter)

        Dim userSID As Security.Principal.SecurityIdentifier = Nothing
        Analog.functions.misc.getUserSID(_currentProfile, "", userSID)

        cregistry.getPrinterListByProfile(_stationName, userSID.ToString, _lastErrMsg, printerlist)
        cregistry.getDefaultPrinterByProfile(_stationName, userSID.ToString, _lastErrMsg, defaultPrinterName)

        ' 
        '  TODO : tester si erreur ( _lasterrMsg )
        '

        For Each printer As String In printerlist

            If printer.StartsWith("\\") Then ' imprimante réseau slt TODO => gere les imprimantes locales USB // , etc
                Dim serverName, printerName As String
                Dim isDefaultPrinter As Boolean

                '
                ' imprimante par défaut dans registre est sous la forme \\win8devclone.mitrysme.local\PDFCreator,winspool,Ne02:
                ' on parse cette chaine pour extraire uniquement le nom de l'imprimante (PDFCreator )
                ' 
                Dim parseddefaultPrinter = defaultPrinterName.Substring(2).Split(CChar("\")).Last.Split(CChar(",")).First

                Dim str1() As String = defaultPrinterName.Substring(2).Split(CChar("\"))
                Dim parsedDefaultServerName As String = defaultPrinterName.Substring(2).Split(CChar("\")).First
                Dim parsedDefaultPrinterName As String = defaultPrinterName.Substring(2).Split(CChar("\")).Last.Split(CChar(",")).First

                serverName = printer.Substring(2).Split(CChar("\")).First
                printerName = printer.Substring(2).Split(CChar("\")).Last

                If String.Equals(printerName, parseddefaultPrinter) And
                    String.Equals(serverName, parsedDefaultServerName) Then
                    isDefaultPrinter = True
                Else
                    isDefaultPrinter = False
                End If

                Dim strPrinterList As New strPrinter
                With strPrinterList
                    .printerName = printerName
                    .serverName = serverName
                    .defaultPrinter = isDefaultPrinter
                End With

                ListOfstrPrinterLIst.Add(strPrinterList)
            End If
        Next

        Return ListOfstrPrinterLIst
    End Function

End Class