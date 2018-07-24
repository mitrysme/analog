Public Class frmServerPreferences

    Private Sub frmServerPreferences_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'With program.preferences
        '    If .getPathToFolderListStation <> "" Then
        '        Me.txtbPathListeStations.Text = .getPathToFolderListStation
        '    End If
        '    If .getPathToFolderScanResult <> "" Then
        '        Me.txtbPathFolderResults.Text = .getPathToFolderScanResult
        '    End If

        'End With
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not validateForm() Then
            MsgBox("Veuillez remplir tous les champs !!")
        Else
            'With program.preferences
            '    .getPathToFolderListStation = Me.txtbPathListeStations.Text
            '    .getPathToFolderScanResult = Me.txtbPathFolderResults.Text
            'End With

            program.preferences.savePreferences()
            Application.Exit()
        End If
    End Sub

    '@un peu léger :) ..
    Private Function validateForm() As Boolean
        Dim valideForm As Boolean = True

        If Me.txtbPathFolderResults.Text = "" Or _
        Me.txtbPathListeStations.Text = "" Then
            valideForm = False
        End If

        Return valideForm
    End Function

    Private Sub btnChangeFolderLIsteStation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeStationToScan.Click
        Dim folderDialog As New FolderBrowserDialog
        folderDialog.ShowDialog()
    
        If folderDialog.SelectedPath <> "" Then
            Me.txtbPathListeStations.Text = folderDialog.SelectedPath
        End If

        folderDialog.Dispose()
        folderDialog = Nothing
    End Sub

    ''' <summary>
    ''' Sélectionne Dossier dans lequel écrire le fichier de résultats
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnChangeResultsFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeResultsFolder.Click
        Dim folderDialog As New FolderBrowserDialog
        ' folderDialog.ShowNewFolderButton = False
        folderDialog.ShowDialog()

        If folderDialog.SelectedPath <> "" Then
            Me.txtbPathFolderResults.Text = folderDialog.SelectedPath
        End If
        folderDialog.Dispose()
        folderDialog = Nothing
    End Sub

End Class