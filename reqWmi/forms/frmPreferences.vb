Public Class frmPreferences

    Public Sub New()
        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

        ' remplit cb choix Sites
        cbSite.Items.AddRange(cbatchScan.dicsiteNames.Values.ToArray)
    End Sub

    Private Sub form_load() Handles Me.Load
        Me.CenterToParent()

        With program.preferences
            Me.cbDebug.Checked = .cbDebug
            Me.cbErreur.Checked = .cbErreur
            Me.cbInfo.Checked = .cbInfo
            Me.cbSite.Text = .sSite
            'Me.tbServer.Text = .scanServer
            Me.tbVncPath.Text = .sVncPath
            Me.tbSccmPath.Text = .sSccmPath
            Me.cbSavePanelState.Checked = .bSavePanelState
            Me.cbSaveWindowPos.Checked = .bSaveWindowPos
            Me.cmbMajGraphsDelay.Text = .usMajGraphsDelay.ToString
            Me.cbSaveSession.Checked = .bSaveSessionTabs
            '
            ' base SQL
            '
            Me.tbDBServer.Text = .sDBServer
            Me.tbDBDataSource.Text = .sDBDataSource
            Me.tbDBUser.Text = .sDBUser
            Me.tbDBPassword.Text = .sDBPassword
            '
            ' graphs
            '
            Me.cbGraphAntialiasing.Checked = .bGraphAntialiasing
            Me.cbAnimateGraphs.Checked = .bAnimateGraph
            Me.tbPingTimeout.Text = CType(.uintPingTimeout, String)
        End With
    End Sub


    Private Sub btnSavePreferences_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePreferences.Click
        ' Si on a changé le délai de mise à jour des grahphs,
        ' on update l'intervalle du timer  dans frmMain
        'If program.preferences.usMajGraphsDelay.ToString <> Me.cmbMajGraphsDelay.Text Then
        '    program.frmMain.tmrUpdateGraphs.Interval = CType(Me.cmbMajGraphsDelay.Text, UShort) * 1000
        'End If

        With program.preferences
            .sSite = Me.cbSite.Text
            '.scanServer = Me.tbServer.Text
            .bSavePanelState = Me.cbSavePanelState.Checked
            .bSaveWindowPos = Me.cbSaveWindowPos.Checked
            .usMajGraphsDelay = CType(Me.cmbMajGraphsDelay.Text, UShort)
            .bSaveSessionTabs = Me.cbSaveSession.Checked
            '
            ' base SQL
            '
            .sDBServer = tbDBServer.Text
            .sDBDataSource = tbDBDataSource.Text
            .sDBUser = tbDBUser.Text
            .sDBPassword = tbDBPassword.Text
            '
            'graphs
            '
            .bGraphAntialiasing = cbGraphAntialiasing.Checked
            .bAnimateGraph = cbAnimateGraphs.Checked
            '
            ' Ping timeout
            '
            If IsNumeric(Me.tbPingTimeout.Text) Then
                If CUShort(Me.tbPingTimeout.Text) >= 1000 And CUShort(Me.tbPingTimeout.Text) <= 4000 Then
                    .uintPingTimeout = CUShort(Me.tbPingTimeout.Text)
                End If
            End If
        End With

        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub CheckBoxLogLevel_changed(ByVal sender As Object,
                                         ByVal e As System.EventArgs) Handles cbDebug.Click,
                                                                              cbErreur.Click,
                                                                              cbInfo.Click
        program.preferences.changeLogLevel(CType(sender, CheckBox))
    End Sub

    'Private Sub btVncPathChange_Click(ByVal sender As System.Object, _
    '                                  ByVal e As System.EventArgs) Handles btVncPathChange.Click
    '    Dim fileDialog As New FolderBrowserDialog
    '    Dim bVncFindOk As Boolean = False

    '    fileDialog.Description = "Sélectionnez le dossier VncViewer"
    '    fileDialog.ShowDialog()


    '    If fileDialog.SelectedPath <> "" Then
    '        Dim files As String() = System.IO.Directory.GetFiles(fileDialog.SelectedPath)


    '        ' vérifie si exécutable "vncviewer.exe" dans le répertoire sélectionné
    '        For Each file As String In files
    '            Dim fileName As String = IO.Path.GetFileName(file)

    '            If InStr("vncviewer.exe", fileName.ToLowerInvariant, CompareMethod.Binary) > 0 Then
    '                bVncFindOk = True
    '                Exit For
    '            End If
    '        Next

    '        If Not bVncFindOk Then
    '            MsgBox("Executable vncviewer.exe introuvable dans le répertoire sélectionné", MsgBoxStyle.Exclamation)
    '        End If
    '    End If

    '    If bVncFindOk Then
    '        tbVncPath.Text = fileDialog.SelectedPath
    '        program.preferences.sVncPath = fileDialog.SelectedPath
    '    End If

    '    fileDialog.Dispose()
    '    fileDialog = Nothing
    'End Sub

    Private Sub btVncPathChange_Click(ByVal sender As System.Object, _
                              ByVal e As System.EventArgs) Handles btVncPathChange.Click

        Dim sPath As String = getPathFor("vncViewer")

        If Not sPath Is Nothing Then
            If IO.Path.GetFileName(sPath) = "vncviewer.exe" Then
                tbVncPath.Text = sPath
                program.preferences.sVncPath = sPath
            ElseIf sPath <> "" Then
                MsgBox("L'éxécutable doit s'appeler vncviewer.exe")
            End If
        End If
    End Sub

    Private Sub btSccmViewerPathChange_Click(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) Handles btSccmViewerPathChange.Click

        Dim sPath As String = getPathFor("sccmViewer")

        If Not sPath Is Nothing Then
            If IO.Path.GetFileName(sPath) = "CmRcViewer.exe" Then
                tbSccmPath.Text = sPath
                program.preferences.sSccmPath = sPath
            ElseIf sPath <> "" Then
                MsgBox("L'éxécutable doit s'appeler CmRcViewer.exe")
            End If
        End If
    End Sub

    Private Function getPathFor(ByVal file As String) As String
        Dim path As String = Nothing

        Using fileDialog As New OpenFileDialog
            fileDialog.Title = String.Format("Sélectionnez l'exécutable pour : {0}", file)
            fileDialog.Multiselect = False
            fileDialog.ShowDialog()

            path = fileDialog.FileName
        End Using

        Return path
    End Function


End Class