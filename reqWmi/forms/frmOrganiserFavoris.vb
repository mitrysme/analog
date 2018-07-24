Imports System.Reflection

Public Class frmOrganiserFavoris

    Public Sub New()

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me.lvStationsFavoris.ContextMenuStrip = ContextMenuStriplvFavoris
    End Sub

    Private Sub frmOrganiserFavoris_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        updateLvFavoris()
    End Sub

    Private Sub updateLvFavoris()
        Dim arrayLVI(program.preferences.colFavoris.Count - 1) As ListViewItem
        Dim index As Integer = 0

        For Each favoris As cFavoris In program.preferences.colFavoris
            Dim LVI As New ListViewItem
            With LVI
                .Text = favoris.favorisDate.ToShortDateString
                .SubItems.Add(favoris.stationName)
                .SubItems.Add(favoris.nbErrDisk.ToString)
                .SubItems.Add(favoris.nbErrNetwork.ToString)
                .SubItems.Add(favoris.nbErrShutdown.ToString)
                .SubItems.Add(favoris.nbErrBsod.ToString)
                .Tag = favoris.note
            End With
            arrayLVI(index) = LVI

            If index Mod 2 = 0 Then
                LVI.BackColor = Color.Beige
            End If

            index += 1
        Next

        With Me.lvStationsFavoris
            .BeginUpdate()
            .Items.AddRange(arrayLVI)
            .EndUpdate()
        End With
    End Sub

    Private Sub lvStationsFavoris_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvStationsFavoris.SelectedIndexChanged
        Dim lv As ListView = CType(sender, ListView)
        If lv.SelectedItems.Count > 0 Then
            tbNote.Text = lv.SelectedItems.Item(0).Tag.ToString
        End If
    End Sub

    ''' <summary>
    ''' Supprimer un favoris
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SupprimerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerToolStripMenuItem.Click
        If Me.lvStationsFavoris.SelectedItems.Count = 0 Then Exit Sub

        Dim stationName As String = Me.lvStationsFavoris.SelectedItems(0).SubItems(1).Text

        ' vire le favoris de la collection et réécrit fichier XML
        With program.preferences.colFavoris
            .removeFavorisByStationName(stationName)
            .writeToXml()
        End With

        program.frmMdiContainer.reloadMenuFavorisFromPreferences()

        ' vire la ligne du listView
        Me.lvStationsFavoris.SelectedItems(0).Remove()
    End Sub

    Private Sub ScannerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScannerToolStripMenuItem.Click
        Dim stationName As String = Me.lvStationsFavoris.SelectedItems(0).SubItems(1).Text

        program.frmMdiContainer.addTab(stationName)
    End Sub
End Class