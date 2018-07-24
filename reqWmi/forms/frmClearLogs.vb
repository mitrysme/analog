Public Class frmClearLogs
    Private _station As String
    Private WithEvents _wmiNTEventLogFile As wmi.ntEventLogFile
    'Private _bClearSystemLog As Boolean
    'Private _bClearAppLog As Boolean
    Private _bDone As Boolean
    '  Private _processingLogName As String ' nom du fichier log en cours de traitement
    Private listOfLogsToClear As New List(Of String)

    Private Delegate Sub _degupdateControlFromOtherThread()


    Public Sub New(ByVal stationName As String)
        InitializeComponent()

        _station = stationName
        _wmiNTEventLogFile = New wmi.ntEventLogFile(stationName)

        AddHandler _wmiNTEventLogFile.processCompleted, AddressOf processCompletedHandler
        AddHandler _wmiNTEventLogFile.processError, AddressOf processErrorHandler

        Me.CenterToParent()
        Me.Text = String.Format("Analog : {0} : Effacer logs", stationName)
    End Sub

    Private Sub btnClearLogsOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLogsOK.Click
        If _bDone Then
            Me.Close()
        End If

        If cbClearApplicationLog.Checked Then listOfLogsToClear.Add(wmi.ntEventLogFile.APPLICATION_LOG_NAME)
        If cbClearSystemLog.Checked Then listOfLogsToClear.Add(wmi.ntEventLogFile.SYSTEM_LOG_NAME)

        If listOfLogsToClear.Count = 0 Then Me.Close()

        startClear()
    End Sub

    Private Sub ChangefrmFromOtherThread()

        If Me.InvokeRequired Then
            Me.Invoke(New _degupdateControlFromOtherThread(AddressOf ChangefrmFromOtherThread), Nothing)
        Else
            Me.cbClearApplicationLog.Enabled = False
            Me.cbClearSystemLog.Enabled = False
            Me.btnClearLogsCancel.Visible = False
            Me.btnClearLogsOK.Text = "terminer"
        End If

    End Sub

    Private Sub startClear()
        If listOfLogsToClear.Count = 0 Then
            _bDone = True
            ChangefrmFromOtherThread()
            Return
        End If

        setProgressIcon(listOfLogsToClear.First, False, False)
        ' _processingLogName = listOfLogsToClear.First
        _wmiNTEventLogFile.clearLogs(listOfLogsToClear.First)
    End Sub

    Private Sub setProgressIcon(ByVal logName As String, ByVal completed As Boolean, ByVal errorH As Boolean)
        Dim pb As New PictureBox

        Select Case logName
            Case wmi.ntEventLogFile.APPLICATION_LOG_NAME
                pb = Me.pbProcessApplicationLog
            Case wmi.ntEventLogFile.SYSTEM_LOG_NAME
                pb = Me.pbProcessSystemLog
        End Select

        If completed And Not errorH Then
            pb.Image = My.Resources.ok16
        ElseIf errorH Then
            pb.Image = My.Resources.cross_circle16
        Else
            pb.Image = My.Resources.processAnimate2
        End If

    End Sub

    Private Sub processCompletedHandler(ByVal logName As String)
        setProgressIcon(listOfLogsToClear.First, True, False)
        listOfLogsToClear.RemoveAt(0)
        startClear()
    End Sub

    Private Sub processErrorHandler(ByVal logName As String, ByVal errorName As String)
        setProgressIcon(listOfLogsToClear.First, False, True)
        listOfLogsToClear.RemoveAt(0)
        startClear()
    End Sub

    Private Sub frmClosingHandler() Handles Me.FormClosing
        RemoveHandler _wmiNTEventLogFile.processCompleted, AddressOf processCompletedHandler
        RemoveHandler _wmiNTEventLogFile.processError, AddressOf processErrorHandler
    End Sub

    Private Sub btnClearLogsCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLogsCancel.Click
        Me.Close()
    End Sub
End Class