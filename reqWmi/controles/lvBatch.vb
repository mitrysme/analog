Imports System.Management

Public Class lvBatch
    Inherits baseLv

    Private _previousSelectedItem As ListViewItem
    Private _colorPrevious As Color

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' évite flicker pour les hovers sur les lignes
        Me.DoubleBuffered = True
    End Sub

    ''' <summary>
    ''' Mise à jour de la liste de résultats 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub updateBatch(ByVal listBatchResult As List(Of structs.analogStructs.BatchResult))

        Dim sw As New Stopwatch
        sw.Start()

        Dim arrayListViewItem() As ListViewItem

        ReDim arrayListViewItem(listBatchResult.Count - 1)

        Items.Clear()

        Dim index As Integer = 0
        For Each batchResult As structs.analogStructs.BatchResult In listBatchResult
            Dim item As New ListViewItem(batchResult.dateScan.ToString) 'dateScan
            item.UseItemStyleForSubItems = False

            With item.SubItems
                .Add(batchResult.stationName) 'Station
                .Add(batchResult.modele) 'Modèle
                .Add(batchResult.constructeur) ' constructeur
                .Add(batchResult.osName) ' nom OS
                .Add(batchResult.sn) 'SN
                .Add(functions.convRamAsUlongToString(batchResult.ram)) ' ram
                .Add(batchResult.errDisk.ToString) 'ErrDisk
                .Add(batchResult.driverPredictFail.ToString) ' DiskPredictFail
                .Add(batchResult.errNetwork.ToString) 'ErrNetwork
                .Add(batchResult.errReboot.ToString) 'ErrReboot
                .Add(batchResult.errBsod.ToString) 'ErrReboot
                .Add(batchResult.socle) ' socle applicatif
                .Add(batchResult.freeSpaceOnSystemDisk)
                .Add(batchResult.smartStatus) ' Status Smart Disque systeme
                .Add(batchResult.errMessage) ' errMessage
            End With

            ' erreurs disques en rouge
            If Not batchResult.errDisk Is Nothing Then
                If CInt(batchResult.errDisk) > 0 Then
                    item.SubItems(7).BackColor = Color.Red
                End If
            End If
            ' erreurs BSOD en rouge
            If Not batchResult.errBsod Is Nothing Then
                If CInt(batchResult.errBsod) > 0 Then
                    item.SubItems(11).BackColor = Color.Red
                End If
            End If
            ' Boitier TOUR ML450/VL350 en orange
            If batchResult.towerCase Then
                item.SubItems(2).BackColor = Color.Orange
            End If

            arrayListViewItem(index) = item
            index += 1
            item = Nothing
        Next

        Me.BeginUpdate()
        Me.Items.AddRange(arrayListViewItem)
        Me.alternatecolors()
        Me.EndUpdate()

        sw.Stop()

    End Sub

    Private Sub lvResultScan_MouseDoubleClick(ByVal sender As Object,
                                              ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDoubleClick
        'program.frmMain.Focus()
        'program.frmMain.startScan(sender.Items(sender.SelectedIndices(0)).SubItems(1).Text)
    End Sub

    Protected Overrides Sub OnColumnClick(ByVal e As System.Windows.Forms.ColumnClickEventArgs)
        MyBase.OnColumnClick(e)
        Me.alternatecolors()
    End Sub

    Private Sub alternatecolors()
        Dim cp As Integer = 0
        For Each i As ListViewItem In Me.Items
            If cp Mod 2 = 0 Then
                setColorForAllSubItems(i, Color.Beige)
            Else
                setColorForAllSubItems(i, Color.White)
            End If
            cp += 1
        Next
    End Sub

    Private Sub setColorForAllSubItems(ByRef item As ListViewItem, ByRef c As Color)
        For Each s As ListViewItem.ListViewSubItem In item.SubItems
            If Not s.BackColor = Color.Red And Not s.BackColor = Color.Orange Then
                s.BackColor = c
            End If
        Next
    End Sub

    Private Sub LvBatch_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Dim item As ListViewItem = Me.GetItemAt(e.X, e.Y)

        If Not item Is Nothing Then

            'If the hovered item is the same as it was last time
            'we moved the mouse, we don't need to change anything
            If Not item Is _previousSelectedItem Then
                ' si item précédemment sélectionné, restaure couleur origine
                If Not _previousSelectedItem Is Nothing Then
                    setColorForAllSubItems(_previousSelectedItem, _colorPrevious)
                End If

                ' sauve la couleur de l'item avant de la changer
                _previousSelectedItem = item
                _colorPrevious = _previousSelectedItem.BackColor

                setColorForAllSubItems(item, Color.Lavender)
            End If
        Else
            'If we're not over top of an item we can reset the
            'previously highlighted item, if applicable
            If Not _previousSelectedItem Is Nothing Then
                setColorForAllSubItems(_previousSelectedItem, _colorPrevious)
                _previousSelectedItem = Nothing
            End If
        End If

    End Sub

    ''' <summary>
    ''' Supprime le hover quand on leave() le controle
    ''' </summary>
    ''' <remarks>
    ''' Devrait etre implémenté avec un handle ici mais ne marche pas ....
    ''' appelé depuis frmBatch 
    ''' TODO => avoir  
    '''</remarks>
    Public Sub leave_control()
        If Not _previousSelectedItem Is Nothing Then
            setColorForAllSubItems(_previousSelectedItem, _colorPrevious)
        End If
    End Sub

End Class
