' Gestion des processes
'
' implémentation adaptée de YAPM, merci à l'auteur
'

Imports System.Management
Imports AnalogEnums.enums

Public Class lvProcess
    Inherits baseLv

    Private _dicoNew As New Dictionary(Of String, cProcessInfos)
    Private _dico As New Dictionary(Of String, cProcessInfos)
    Private _dicoDel As New Dictionary(Of String, cProcessInfos)
    Private _station As cstation
    Private WithEvents _processConnection As cProcessConnection
    'Private WithEvents _processConnection As New cProcessConnection(Me, New cProcessConnection.HasEnumeratedEventHandler(AddressOf updateitems), _station)

    Public ReadOnly Property processConnection() As cProcessConnection
        Get
            Return _processConnection
        End Get
    End Property

    'Public Overrides Sub dispose()

    'End Sub

    Public Sub New()
        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        '
        ' image liste pour icones programmes
        _IMG = New ImageList
        _IMG.ImageSize = New Size(16, 16)
        _IMG.ColorDepth = ColorDepth.Depth32Bit
        _IMG.Images.Add("noIcon", My.Resources.application_blue16)
        Me.SmallImageList = _IMG
        ' menu contextuel listviewProcess
        Me.ContextMenuStripProcess.RenderMode = ToolStripRenderMode.System
        Me.ContextMenuStrip = Me.ContextMenuStripProcess
    End Sub

    Public Sub initConexion(ByRef station As cstation)
        _processConnection = New cProcessConnection(Me, New cProcessConnection.HasEnumeratedEventHandler(AddressOf updateitemsProcess), station)
        _station = station
    End Sub

    Public Sub asyncUpdate()
        ' Create a buffer of subitems if necessary
        If _columnsName Is Nothing Then
            Call CreateSubItemsBuffer()
        End If

        _processConnection.asyncUpdate()
    End Sub


    ''' <summary>
    ''' Vide Process
    ''' </summary>
    ''' <remarks>
    ''' modif 11/10/2013 appel clearDicNewProcesses 
    ''' a voir si corrige problemes infos processes qui disparaissent lors de la deco/reco Station
    ''' </remarks>
    Public Sub ClearItems()
        _dico.Clear()
        _dicoDel.Clear()
        _dicoNew.Clear()

        If _station IsNot Nothing Then
            log.addLogEntry(New cLogEntry(String.Format("Vidage dico _newProcesses"), cLogEntry.enumDebugLevel.DEBUG, _station.stationName))
            _processConnection.processWmi.clearDicNewProcesses()
        End If

        _IMG.Images.Clear()
        _IMG.Images.Add("noIcon", My.Resources.application_blue16)

        Me.Items.Clear()
    End Sub

    Public Sub updateitemsProcess(ByVal Dico As Dictionary(Of String, cProcessInfos))
        'If Not Success Then
        '    log.addLogEntry(New cLogEntry(String.Format("MAJ process KO : {0}", errorMessage), cLogEntry.enumDebugLevel.ERREUR, _station.stationName))
        '    Exit Sub
        'End If

        ' Now add all items with isKilled = true to _dicoDel dictionnary
        For Each z As cProcessInfos In _dico.Values
            If z.isKilled Then
                _dicoDel.Add(z.pid.ToString, Nothing)
            End If
        Next

        ' Now add new items to dictionnary
        For Each pair As System.Collections.Generic.KeyValuePair(Of String, cProcessInfos) In Dico
            If Not (_dico.ContainsKey(pair.Key)) Then
                ' Add to dico
                _dicoNew.Add(pair.Key, New cProcessInfos(pair.Value))
            End If
        Next


        ' Now remove deleted items from dictionnary
        For Each z As String In _dico.Keys
            If Dico.ContainsKey(z) = False Then
                ' Remove from dico
                _dico.Item(z).isKilled = True  ' Will be deleted next time
            End If
        Next

        ' Now remove all deleted items from listview and _dico
        For Each z As String In _dicoDel.Keys
            Me.Items.RemoveByKey(z)
            _dico.Remove(z)
        Next
        _dicoDel.Clear()

        ' Merge _dico and _dicoNew
        For Each z As String In _dicoNew.Keys
            Dim _it As cProcessInfos = _dicoNew.Item(z)
            _dico.Add(z.ToString, _it)
        Next

        ' Ajoute les items au listview
        Me.BeginUpdate()
        For Each z As String In _dicoNew.Keys

            ' Add to listview
            Dim _subItems() As String
            ReDim _subItems(Me.Columns.Count - 1)
            For x As Integer = 1 To _subItems.Length - 1
                _subItems(x) = ""
            Next
            AddItemWithIcon(z).SubItems.AddRange(_subItems)
        Next
        Me.EndUpdate()
        _dicoNew.Clear()


        ' Now refresh all subitems of the listview
        Dim isub As ListViewItem.ListViewSubItem
        Dim it As ListViewItem
        For Each it In Me.Items
            Dim x As Integer = 0
            Dim _item As cProcessInfos = _dico.Item(it.Name) ' idem new cProcessInfos(_dico.item(it.name)) ?
            If Dico.ContainsKey(it.Name) Then
                _item.merge(Dico.Item(it.Name), _station)
            End If

            For Each isub In it.SubItems
                '@todo getinfos devrait renvoyer boolean à vrai si les infos ont changé ( ne fait rien sinon ), voir YAPM
                isub.Text = _item.getInfos(_columnsName(x))
                x += 1
            Next
        Next

        ' Sort items
        Me.Sort()
        MyBase.updateItems()
    End Sub

    Private Function AddItemWithIcon(ByVal key As String) As ListViewItem
        Dim item As ListViewItem = Me.Items.Add(key)
        Dim proc As cProcessInfos = _dico.Item(key)
        item.Name = key

        Try
            Dim Path As String = proc.path

            If IO.File.Exists(Path) Then
                Dim icon As Icon = functions.GetIcon(Path, True)
                Dim bImg As Bitmap = icon.ToBitmap

                native.api.nativeFunctions.DestroyIcon(icon.Handle) ' correction leak GDI

                Me.SmallImageList.Images.Add(Path, bImg)

                item.ImageKey = Path
            Else
                item.ImageKey = "noIcon"
            End If
        Catch ex As Exception
            item.ImageKey = "noIcon"
        End Try

        item.Tag = key

        Return item
    End Function

    ' Get the selected item
    Public Function GetSelectedItem() As cProcessInfos
        If Me.SelectedItems.Count > 0 Then
            Return _dico.Item(Me.SelectedItems.Item(0).Name)
        Else
            Return Nothing
        End If
    End Function

    Private Sub ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
                                                                           Handles KillToolStripMenuItem.Click,
                                                                           InfosToolStripMenuItem.Click,
                                                                           InternetToolStripMenuItem.Click

        'ToolStripMenuItem

        Dim toolstripMenuItem = CType(sender, ToolStripMenuItem)

        Select Case toolstripMenuItem.Name

            Case "KillToolStripMenuItem"
                Dim process As cProcessInfos = GetSelectedItem()
                If Not process Is Nothing Then
                    Dim msgError As String = ""
                    If Not wmi.Process.KillProcess(process, msgError, _station) Then
                        MsgBox("Impossible de tuer le process" & vbNewLine & "Message : " & msgError)
                    End If
                End If
            Case "InternetToolStripMenuItem"
                Dim process As cProcessInfos = GetSelectedItem()
                If Not process Is Nothing Then
                    Dim processName = process.name
                    Dim sSearchString As String = "google.com/search?hl=fr&q=ITEM"
                    Dim sSearchStringItem = sSearchString.Replace("ITEM", processName)
                    Shell("C:\Program Files\Internet Explorer\IEXPLORE.EXE" & " " & sSearchStringItem, AppWinStyle.NormalFocus)
                End If
        End Select
    End Sub
End Class
