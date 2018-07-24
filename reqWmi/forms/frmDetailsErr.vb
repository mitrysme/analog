Imports functions
Imports System.Management
Imports System.ComponentModel
Imports System.Text.RegularExpressions


Public Class frmDetailsErr
    Private _activeFilter As wmi.NtLogEvent.ntLogErrType = Nothing
    Private _arrayCheckBoxFilterControl() As CheckBox
    Private _nbEvent As Integer
    Private _firstEventDate As DateTime
    Private _lastEventDate As DateTime
    Private _station As cstation

    Public ReadOnly Property stationName() As String
        Get
            Return _station.stationName
        End Get
    End Property

    Public Sub New(ByRef station As cstation, ByVal bFilterByDate As Boolean)
        ' Cet appel est requis par le Concepteur Windows Form.
        _station = station
        InitializeComponent()
        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        Me.Text = String.Format("Analog : {0} - Logs ", station.stationName)
        Me.LvDetailsErr1.FullRowSelect = True
        Me.LvDetailsErr1.MultiSelect = False
        Me.cbLogFilterByDate.Checked = bFilterByDate
        ' menu contextuel 
        Me.ContextMenuStripLogItem.RenderMode = ToolStripRenderMode.System
        Me.LvDetailsErr1.ContextMenuStrip = ContextMenuStripLogItem
    End Sub

    Private Sub frmDetailsErr_load() Handles Me.Load
        Me.CenterToParent()

        setArrayCheckBoxFilterControl()

        updateItems()
        setInfosLog()
        setColorsTxt()
    End Sub

    Private Sub setInfosLog()
        ' duplication de code moche ' voir degUpdateInfos dans frmMain
        With _station.ntSystemLog.getNtSystemLogErrorCount(_station.gInfoStation.OsInstallDevice, Me.cbLogFilterByDate.Checked)
            If Not IsNothing(.iNumDiskBlockErrorOnSystemDisk) Then Me.txtbErrDisque.Text = .iNumDiskBlockErrorOnSystemDisk.ToString
            If Not IsNothing(.iNumNetworkError) Then Me.txtbErrNetwork.Text = .iNumNetworkError.ToString
            If Not IsNothing(.iNumShutdownError) Then Me.txtbErrReboot.Text = .iNumShutdownError.ToString
            If Not IsNothing(.iNumBsobError) Then Me.txtbBsod.Text = .iNumBsobError.ToString
            If Not IsNothing(.iNumDiskPredictFail) Then Me.tbHdFailure.Text = .iNumDiskPredictFail.ToString
            If Not IsNothing(.iNumControllerError) Then Me.tbErrControleur.Text = .iNumControllerError.ToString
            If Not IsNothing(.iNumFtDiskError) Then Me.tbftDiskError.Text = .iNumFtDiskError.ToString
            If Not IsNothing(.iNumNtfsError) Then Me.tbNtfsError.Text = .iNumNtfsError.ToString
        End With

        With _station.NtApplicationLog
            Me.tbErrApplication.Text = .countApplicationErrors(Me.cbLogFilterByDate.Checked).ToString
            Me.tbErrOffice.Text = .countOfficeErrors(Me.cbLogFilterByDate.Checked).ToString
        End With

        tbNbEvent.Text = _nbEvent.ToString
        tbEvntFirst.Text = _firstEventDate.ToLongDateString

    End Sub

    ''' <summary>
    ''' Passe le background des textBox en rouge si valeurs > 0 ; vert sinon
    ''' </summary>
    ''' <remarks>
    ''' TODO : Doublon avec fonction dans frmMain => factoriser
    ''' </remarks>
    Private Sub setColorsTxt()
        For Each Control As Control In Me.GroupBoxResults.Controls
            If TypeOf (Control) Is TextBox Then
                If Control.Text <> "" Then
                    If CDbl(Control.Text) > 0 Then
                        Control.BackColor = Color.Red
                    Else
                        Control.BackColor = Color.LightGreen
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub setArrayCheckBoxFilterControl()
        ReDim _arrayCheckBoxFilterControl(0)

        Dim i As Integer = 0
        For Each ctrl As Control In GroupBoxResults.Controls
            If TypeOf (ctrl) Is CheckBox Then
                ReDim Preserve _arrayCheckBoxFilterControl(UBound(_arrayCheckBoxFilterControl) + 1)
                _arrayCheckBoxFilterControl(i) = CType(ctrl, CheckBox)
                i += 1
            End If

        Next
        ReDim Preserve _arrayCheckBoxFilterControl(UBound(_arrayCheckBoxFilterControl) - 1)
    End Sub

    ''' <summary>
    ''' MAJ list view
    ''' </summary>
    ''' <remarks>
    ''' TODO
    ''' Utiliser dictionnaire k > reCordNumber, nt-log-event
    ''' et eviter de coller insertion string dans un item.tag 
    ''' </remarks>
    Private Sub updateItems()
        _firstEventDate = Nothing
        _nbEvent = Nothing

        Me.LvDetailsErr1.Items.Clear()

        ' on Merge les evts systeme et application dans la meme liste pour affichage dans le meme listview
        Dim listMergeSystemAndApplicationLog As New List(Of wmi.Win32_NTLogEvent)
        With listMergeSystemAndApplicationLog
            .AddRange(_station.ntSystemLog.listOfWin32LogEvents)
            .AddRange(_station.NtApplicationLog.listOfWin32LogEvents)
        End With

        _nbEvent = listMergeSystemAndApplicationLog.Count

        Dim listOfListViewItem As New List(Of ListViewItem)

        For Each Win32_NTLogEvent In listMergeSystemAndApplicationLog
            ' si type évènement est filtré passe
            If getActivefilterType() <> Nothing Then
                If Not isEventFiltered(Win32_NTLogEvent) Then
                    Continue For
                End If
            End If

            If Me.cbLogFilterByDate.Checked Then
                If wmi.NtBaseLogEvent.isEventOlderThanXDay(Win32_NTLogEvent) Then
                    Continue For
                End If
            End If


            Dim item As New ListViewItem(Analog.functions.misc.dateConvert(Win32_NTLogEvent.TimeGenerated))

            With item.SubItems
                ' Vu sur P29DNRA127 win32_NTLogEvent.timegenerated = nothing, on teste donc ... 
                If Win32_NTLogEvent.TimeGenerated Is Nothing Then
                    .Add("NA")
                Else
                    .Add(ManagementDateTimeConverter.ToDateTime(Win32_NTLogEvent.TimeGenerated).ToLongTimeString)
                End If
                '
                If Win32_NTLogEvent.Message IsNot Nothing Then
                    .Add(Regex.Replace(Win32_NTLogEvent.Message, "[\x00-\x1f]", "").Trim())
                End If
                .Add(Win32_NTLogEvent.Type)
                .Add(Win32_NTLogEvent.User)
                .Add(Win32_NTLogEvent.EventCode.ToString)
                .Add(Win32_NTLogEvent.SourceName)
            End With

            item.Tag = Win32_NTLogEvent.InsertionStrings

            listOfListViewItem.Add(item)

            _nbEvent = listOfListViewItem.Count

            ' calcul First /last Event Date
            If Win32_NTLogEvent.TimeGenerated IsNot Nothing Then
                Dim eventDateTime As DateTime = ManagementDateTimeConverter.ToDateTime(Win32_NTLogEvent.TimeGenerated)

                If Not eventDateTime = Nothing Then
                    If _firstEventDate = Nothing Then
                        _firstEventDate = eventDateTime
                    Else
                        If DateTime.Compare(eventDateTime, _firstEventDate) < 0 Then
                            _firstEventDate = eventDateTime
                        End If
                    End If
                End If
            End If
        Next

        With Me.LvDetailsErr1
            .SuspendLayout()
            .Items.AddRange(listOfListViewItem.ToArray)
            .ResumeLayout()
        End With

    End Sub

    ''' <summary>
    ''' Gestionnaire filtres log
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' TODO serait mieux avec affectation dynamique addhandler ou une truc dans le genre
    ''' </remarks>
    Private Sub cbFilterLog_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFilterHddblockHs.Click,
                                                                                                 cbFilterHddErrControl.Click,
                                                                                                 cbFilterBsod.Click,
                                                                                                 cbFilterErrNetwork.Click,
                                                                                                 cbFilterErrShutdown.Click,
                                                                                                 cbFilterHddDriverFail.Click,
                                                                                                 cbFilterFtdiskErr.Click,
                                                                                                 cbFilterNtfsErr.Click,
                                                                                                 cbFilterApplicationErr.Click,
                                                                                                 cbFilterOfficeErr.Click

        For Each cb As CheckBox In _arrayCheckBoxFilterControl
            If cb.Name <> CType(sender, CheckBox).Name Then cb.Checked = False
        Next

        _activeFilter = getActivefilterType()
        updateItems()
    End Sub

    Private Sub cbLogFilterByDate_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbLogFilterByDate.Click
        updateItems()
        setInfosLog()
        setColorsTxt()
    End Sub

    Private Function isEventFiltered(ByVal NTLogEvt As wmi.Win32_NTLogEvent) As Boolean
        Return getLogEventErrorType(NTLogEvt) = getActivefilterType()
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NTLogEvt"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' TODO  refactorisation  mutualiser code avec NTLOGEVENT::setStatsOnLogError
    ''' </remarks>
    Private Function getLogEventErrorType(ByVal NTLogEvt As wmi.Win32_NTLogEvent) As wmi.NtLogEvent.ntLogErrType
        ' Log Application
        If NTLogEvt.SourceName.ToUpperInvariant = "APPLICATION ERROR" Or
            NTLogEvt.SourceName.ToUpperInvariant = "APPLICATION HANG" Then
            Return wmi.NtLogEvent.ntLogErrType.applicationError
        ElseIf NTLogEvt.SourceName.ToUpperInvariant.Contains("MICROSOFT OFFICE") And NTLogEvt.Type.ToUpperInvariant = "ERREUR" And NTLogEvt.EventCode = 1000 Then
            Return wmi.NtLogEvent.ntLogErrType.officeError
        End If
     
        ' Log Systeme
        Select Case NTLogEvt.EventCode
            Case 7
                If NTLogEvt.SourceName.ToUpperInvariant = "DISK" Then
                    ' Ajoute l'erreur disque uniquement si se situe sur le disque Système
                    ' on ne s'occupe pas des clefs USB, disque externes moisis etc....
                    ' CRITICAL reference variable globale program.station => NOTHING en mode server
                    If wmi.NtLogEvent.isErrBlockOnOsInstallDevice(NTLogEvt, _station.gInfoStation.OsInstallDevice) Then
                        Return wmi.NtLogEvent.ntLogErrType.DiskBlockErrorOnSystemDisk
                    End If
                End If
            Case 1003 ' erreur DHCP
                If NTLogEvt.SourceName.ToUpperInvariant = "DHCP" Then
                    Return wmi.NtLogEvent.ntLogErrType.NetworkError
                End If
            Case 5719 ' erreur Netlogon
                If NTLogEvt.SourceName.ToUpperInvariant = "NETLOGON" Then
                    Return wmi.NtLogEvent.ntLogErrType.NetworkError
                End If
            Case 1001
                If NTLogEvt.SourceName.ToUpperInvariant = "SAVE DUMP" Or
                       NTLogEvt.SourceName = "Microsoft-Windows-WER-SystemErrorReporting" Then
                    Return wmi.NtLogEvent.ntLogErrType.BsodError
                End If
            Case 6008
                Return wmi.NtLogEvent.ntLogErrType.ShutdownError
            Case 9 Or 11
                If NTLogEvt.SourceName.ToUpperInvariant = "ATAPI" Then
                    Return wmi.NtLogEvent.ntLogErrType.ControllerError
                End If
            Case 52
                If NTLogEvt.SourceName.ToUpperInvariant = "DISK" Then
                    Return wmi.NtLogEvent.ntLogErrType.DiskPredictFail
                End If
            Case 55
                If NTLogEvt.SourceName.ToUpperInvariant = "NTFS" Then
                    Return wmi.NtLogEvent.ntLogErrType.ntfsErr
                End If
            Case 57
                If NTLogEvt.SourceName.ToUpperInvariant = "FTDISK" Then
                    Return wmi.NtLogEvent.ntLogErrType.ftDiskErr
                End If
        End Select

    End Function

    Private Function getActivefilterType() As wmi.NtLogEvent.ntLogErrType
        For Each cb As CheckBox In _arrayCheckBoxFilterControl
            If cb.Checked Then
                Select Case cb.Name
                    Case "cbFilterHddblockHs"
                        Return wmi.NtLogEvent.ntLogErrType.DiskBlockErrorOnSystemDisk
                    Case "cbFilterHddErrControl"
                        Return wmi.NtLogEvent.ntLogErrType.ControllerError
                    Case "cbFilterHddDriverFail"
                        Return wmi.NtLogEvent.ntLogErrType.DiskPredictFail
                    Case "cbFilterErrNetwork"
                        Return wmi.NtLogEvent.ntLogErrType.NetworkError
                    Case "cbFilterErrShutdown"
                        Return wmi.NtLogEvent.ntLogErrType.ShutdownError
                    Case "cbFilterBsod"
                        Return wmi.NtLogEvent.ntLogErrType.BsodError
                    Case "cbFilterFtdiskErr"
                        Return wmi.NtLogEvent.ntLogErrType.ftDiskErr
                    Case "cbFilterNtfsErr"
                        Return wmi.NtLogEvent.ntLogErrType.ntfsErr
                    Case "cbFilterApplicationErr"
                        Return wmi.NtLogEvent.ntLogErrType.applicationError
                    Case "cbFilterOfficeErr"
                        Return wmi.NtLogEvent.ntLogErrType.officeError
                    Case Else
                        Return Nothing
                End Select
            End If
        Next
    End Function

#Region "ToolStrip"
    ''' <summary>
    ''' Recherche l'évènement sélectionné sur le site eventId.net
    ''' Ouvre Fenêtre IE
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EventIdMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
                                                                       Handles EventIdToolStripMenuItem.Click

        If Me.LvDetailsErr1.SelectedItems.Count > 0 Then
            Dim source As String = String.Empty
            Dim eventId As Integer = 0

            Dim LVI As ListViewItem = Me.LvDetailsErr1.SelectedItems(0)

            source = LVI.SubItems(6).Text
            eventId = CInt(LVI.SubItems(5).Text)

            Dim searchString As String = String.Format("http://www.eventid.net/display.asp?eventid={0}&source={1}&phase=1", eventId, source)
            Shell("C:\Program Files\Internet Explorer\IEXPLORE.EXE" & " " & searchString, AppWinStyle.NormalFocus)
        End If
    End Sub

    ''' <summary>
    ''' Ouverture winDbg
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' TODO : c$ en dur ... mieux avec ginfostation.osSystemDrive 
    ''' </remarks>
    Private Sub WinDbgToolStripMenuItem_Click(ByVal sender As Object,
                                              ByVal e As System.EventArgs) Handles WinDbgToolStripMenuItem.Click


        If LvDetailsErr1.SelectedItems.Count > 0 Then
            Dim lVI As ListViewItem = Me.LvDetailsErr1.SelectedItems(0)
            Dim insertionStrings() As String = CType(Me.LvDetailsErr1.SelectedItems(0).Tag, String())
            Dim dumpLocalPath As String = insertionStrings(1).ToString

            Dim dumpVncPath As String = "\\" & _station.stationName & "\c$" & dumpLocalPath.Substring(2)
            Dim winDbgFullPath As String = Environment.GetEnvironmentVariable("programFiles") & program.WINDBG_PATH

            Dim prc As New System.Diagnostics.Process()

            If Not System.IO.File.Exists(winDbgFullPath) Then
                MsgBox("Windbg ne semble pas installé, impossible de lancer ! ", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            With prc
                .StartInfo.FileName = winDbgFullPath
                .StartInfo.Arguments = "-z " & dumpVncPath
                .Start()
            End With
        End If
    End Sub
#End Region

    ''' <summary>
    ''' Active ou désactive entrées menu contextuel en fonction type evt
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ContextMenuStrip_opened(ByVal sender As Object, ByVal e As System.EventArgs) _
                                                                       Handles ContextMenuStripLogItem.Opened

        If Me.LvDetailsErr1.SelectedItems.Count > 0 Then
            Dim source As String = Me.LvDetailsErr1.SelectedItems(0).SubItems(6).Text

            If source.ToUpperInvariant = "SAVE DUMP" Or
               source = "Microsoft-Windows-WER-SystemErrorReporting" Then
                ContextMenuStripLogItem.Items.Item(1).Visible = True
            Else
                ContextMenuStripLogItem.Items.Item(1).Visible = False
            End If
        End If

    End Sub

End Class