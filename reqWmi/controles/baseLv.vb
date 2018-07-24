Public Class baseLv
    Inherits System.Windows.Forms.ListView

    Private m_SortingColumn As ColumnHeader

    Protected _columnsName() As String
    Protected _IMG As ImageList

    Private tempListView As New ListView


    ' ========================================
    ' Public
    ' ========================================
    Public Sub New()
        MyBase.New()
        ' Set double buffered property to true
        Me.DoubleBuffered = True
    End Sub

    Public Overridable Sub updateItems()
        ' Maj du ListView
    End Sub

    Public Overridable Sub updateItems(ByVal Success As Boolean, ByVal Dico As Dictionary(Of String, cProcessInfos), ByVal errorMessage As String)
        ' Maj du ListView pour Process
    End Sub

    'Public Overridable Sub updateItemsbyCol(ByVal items As System.Management.ManagementObjectCollection)

    ' YAPM
    Protected Overrides Sub OnColumnClick(ByVal e As ColumnClickEventArgs)
        MyBase.OnColumnClick(e)

        If Me.VirtualMode Then
            Exit Sub
        End If

        ' Get the new sorting column.
        Dim new_sorting_column As ColumnHeader = _
            Me.Columns(e.Column)

        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        ' Create a comparer.
        Me.ListViewItemSorter = New ListViewColumnSorter(e.Column, sort_order)

        ' Sort.
        Me.Sort()
    End Sub

    Friend Sub CreateSubItemsBuffer()
        ' Get column names
        Dim _size As Integer = Me.Columns.Count - 1

        ReDim _columnsName(_size)
        For x As Integer = 0 To _size
            _columnsName(x) = Me.Columns.Item(x).Text.Replace("< ", "").Replace("> ", "")
        Next
    End Sub

    Public Overloads Sub dispose()
        MyBase.Dispose()


        If Not Me.ContextMenuStrip Is Nothing Then Me.ContextMenuStrip.Dispose()

        If Not _IMG Is Nothing Then _IMG.Dispose()


    End Sub

End Class
