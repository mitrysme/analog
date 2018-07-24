Imports structs
Imports System.Management

Public Class lvPrograms
    Inherits baseLv

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.ContextMenuStrip = Me.ContextMenuStripPrograms
        Me.ContextMenuStrip.RenderMode = ToolStripRenderMode.System
    End Sub

    Private Sub tsUninstallString_Click() Handles ToolStripMenuItemCopyUninstallString.Click
        If Me.SelectedItems.Count > 0 Then
            Dim selectedSubItem As ListViewItem.ListViewSubItem = Me.SelectedItems(0).SubItems(4)
            Dim uninstallString As String = selectedSubItem.Text
            ' copie dans le press-papier
            Clipboard.SetData(DataFormats.Text, CType(uninstallString, Object))
        End If
    End Sub

    ''' <summary>
    ''' MAJ ITEMS
    ''' </summary>
    ''' <remarks>cather erreurs sur enumération ( classe corrompue ... )</remarks>
    Public Sub updateitemsForStation(ByRef programs As List(Of cPrograms.InstalledProgram))
        Dim arrayListViewItem() As System.Windows.Forms.ListViewItem
        Dim index As Integer = 0
        ReDim arrayListViewItem(cPrograms.getProgramFilteredCount(programs) - 1)

        Me.Items.Clear()
        Me.Cursor = Cursors.WaitCursor

        For Each program As cPrograms.InstalledProgram In programs
            If Not program.filtered Then
                Dim item As New ListViewItem(program.DisplayName)

                With item.SubItems
                    .Add(CType(program.DisplayVersion, String))
                    .Add(program.Publisher)
                    .Add(Analog.functions.misc.dateConvert(program.InstallDate))
                    .Add(program.UninstallString)
                End With

                arrayListViewItem(index) = item
                index += 1
                item = Nothing
            End If
        Next

        Me.Cursor = Cursors.Arrow

        Me.BeginUpdate()
        Me.Items.AddRange(arrayListViewItem)
        Me.EndUpdate()
    End Sub

    Public Sub filterProgramsDiff(ByVal programsFromDb As List(Of cPrograms.InstalledProgram))
        Dim programMatchExact, programVersionDiffer As Boolean

        For Each it As ListViewItem In Me.Items
            programMatchExact = False
            programVersionDiffer = False

            Dim listViewProgramName As String = it.Text
            Dim listViewProgramVersion As String = it.SubItems(1).Text

            Dim listOfMatchingPrograms As List(Of cPrograms.InstalledProgram) = programsFromDb.Where(Function(x) x.DisplayName = listViewProgramName).ToList

            For Each MatchingProgramFoundInDB As cPrograms.InstalledProgram In listOfMatchingPrograms
                If listViewProgramName = MatchingProgramFoundInDB.DisplayName And listViewProgramVersion = MatchingProgramFoundInDB.DisplayVersion Then
                    programMatchExact = True
                    Exit For
                Else
                    programVersionDiffer = True
                End If
            Next

            If Not programMatchExact Then

                If programVersionDiffer Then
                    it.BackColor = Color.Orange
                Else
                    it.BackColor = Color.Red
                End If
            End If
        Next
    End Sub

    Public Sub restoreItemscolor()
        For Each it As ListViewItem In Me.Items
            it.BackColor = Color.White
        Next
    End Sub

End Class
