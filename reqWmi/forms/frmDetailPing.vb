Public Class frmDetailPing
    'Private _pinger As cAsyncPinger
    Private _bindingSource As BindingSource = New BindingSource
    Private _stationName As String
    Private _pingData As List(Of cAsyncPinger.pingData)

    Public ReadOnly Property stationName() As String
        Get
            Return _stationName
        End Get
    End Property

    Public Sub frm_load() Handles Me.Load
        Me.CenterToParent()
    End Sub

    Public Sub New(ByVal pingData As List(Of cAsyncPinger.pingData), ByVal stationName As String)
        InitializeComponent()


        _pingData = pingData
        _stationName = stationName
        _bindingSource.DataSource = _pingData

        Me.Text = String.Format("Analog : {0} - Detail Ping ", _stationName)

        With dgvPing
            .AutoGenerateColumns = True
            .DataSource = _bindingSource
            .Columns(0).DefaultCellStyle.Format = "dd'/'MM'/'yyyy HH:mm:ss tt"
            .Columns("dateSent").HeaderText = "Envoyé à"
            .Columns("roundTripTime").HeaderText = "temps Réponse ms"
            .Columns("address").HeaderText = "address"
            .Columns("bufferLenght").HeaderText = "Tampon"
            .Columns(0).Width = 130
            .Columns(1).Width = 130
        End With

        'activateDatetimePicker(False)
        Me.MaximumSize = New Size(500, 1200)

        ' Me.dgvPing.AutoResizeColumns()
        updateStats()
    End Sub

    'Private Sub activateDatetimePicker(ByVal active As Boolean)
    '    Me.DateTimePickerFrom.Enabled = active
    '    Me.DateTimePickerTimeTo.Enabled = active
    '    Me.DateTimePickerTimeFrom.Enabled = active
    '    Me.DateTimePickerTo.Enabled = active
    'End Sub

    Private Sub cellFormatingEvent_Handler(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles dgvPing.CellFormatting
        If dgvPing.Columns(e.ColumnIndex).Name = "roundTripTime" Then
            If e.Value Is Nothing Then
                e.Value = "timeout"
                dgvPing.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
            ElseIf CInt(e.Value) = 0 Then
                e.Value = "<1"
            End If
        End If
    End Sub

    Private Sub updateStats()
        Dim pinglost As Integer = 0
        Dim pingData As List(Of cAsyncPinger.pingData) = CType(_bindingSource.DataSource, List(Of cAsyncPinger.pingData))

        Dim aroundtrip As New List(Of Integer)

        Dim totalPingRoundTrip As Double = 0
        For Each Pdata As cAsyncPinger.pingData In pingData
            If Pdata.roundTripTime Is Nothing Then
                pinglost += 1
            Else
                aroundtrip.Add(CInt(Pdata.roundTripTime))
            End If
        Next

        Me.tbPingSent.Text = pingData.Count.ToString
        Me.tbPingLOst.Text = pinglost.ToString

        If aroundtrip.Count > 0 Then
            Me.tbAvgRoundtrip.Text = aroundtrip.Average.ToString
            Me.tbMaxRoundTrip.Text = aroundtrip.Max.ToString
            Me.tbMinRoundtrip.Text = aroundtrip.Min.ToString
        Else
            Me.tbAvgRoundtrip.Text = "0"
            Me.tbMaxRoundTrip.Text = "0"
            Me.tbMinRoundtrip.Text = "0"
        End If
       
        If Not pingData.Count = 0 Or pinglost = 0 Then
            Me.tbPercentLost.Text = ((pinglost * 100) / (pingData.Count + pinglost)).ToString
        Else
            Me.tbPercentLost.Text = "0"
        End If
    End Sub

    Private Sub frm_closing() Handles Me.FormClosing
        _bindingSource.Dispose()
    End Sub


    Private Sub activatefilter() Handles ckbLostPacketFilter.CheckedChanged, ckbFilterByDate.CheckedChanged
        If Not (ckbFilterByDate.Checked Or ckbLostPacketFilter.Checked) Then
            _bindingSource.DataSource = _pingData
        Else
            If ckbFilterByDate.Checked Then
                Dim fromDate As DateTime = DateTimePickerFrom.Value
                Dim fromTime As DateTime = DateTimePickerTimeFrom.Value
                Dim toDate As DateTime = DateTimePickerTo.Value
                Dim toTime As DateTime = DateTimePickerTimeTo.Value
                Dim dateAndtimefilterFrom As DateTime = New DateTime(fromDate.Year, fromDate.Month, fromDate.Day, fromTime.Hour, fromTime.Minute, fromTime.Second)
                Dim dateAndTimeFilterTo As DateTime = New DateTime(toDate.Year, toDate.Month, toDate.Day, toTime.Hour, toTime.Minute, toTime.Second)

                _bindingSource.DataSource = cAsyncPinger.filterPingData(ckbLostPacketFilter.Checked, ckbFilterByDate.Checked, _pingData, dateAndtimefilterFrom, dateAndTimeFilterTo)
            Else
                _bindingSource.DataSource = cAsyncPinger.filterPingData(ckbLostPacketFilter.Checked, ckbFilterByDate.Checked, _pingData)
            End If
        End If

        updateStats()
    End Sub
End Class