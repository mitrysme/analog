Imports System.Collections
Imports System.Windows.Forms

''' <summary>
''' classe pour tri listview
''' </summary>
''' <remarks>
''' voir http://www.devx.com/dotnet/Article/34199/1763/page/1
''' pour implémentation d'un objet sortableListView
''' voir http://www.windows-tech.info/3/3c5b5bbf534ca1ea.php pour ruse tryparse
'''</remarks>
Public Class ListViewColumnSorter
    Implements System.Collections.IComparer

    Private ColumnToSort As Integer
    Private OrderOfSort As SortOrder
    Private ObjectCompare As CaseInsensitiveComparer

#Region "getter/setter"
    Public Property SortColumn() As Integer
        Set(ByVal Value As Integer)
            ColumnToSort = Value
        End Set
        Get
            Return ColumnToSort
        End Get
    End Property

    Public Property Order() As SortOrder
        Set(ByVal Value As SortOrder)
            OrderOfSort = Value
        End Set
        Get
            Return OrderOfSort
        End Get
    End Property
#End Region

    Public Sub New(ByVal column_number As Integer, ByVal sort_order As SortOrder)
        ' Initialize the column to '0'.
        ColumnToSort = column_number

        ' Initialize the sort order to 'none'.
        OrderOfSort = sort_order

        ' Initialize the CaseInsensitiveComparer object.
        ObjectCompare = New CaseInsensitiveComparer()
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim listviewX As ListViewItem
        Dim listviewY As ListViewItem

        ' Cast the objects to be compared to ListViewItem objects.
        listviewX = CType(x, ListViewItem)
        listviewY = CType(y, ListViewItem)

        Dim idx As Integer = SortColumn
        If idx < 0 Then Return 0

        Dim xValue As String = ""
        Dim yValue As String = ""
        xValue = ItemString(listviewX, idx)
        yValue = ItemString(listviewY, idx)

        'teste si les items à comparer sont de type numérique ( si cast OK )
        Dim xnumber, ynumber As Double
        Dim itemIsNumeric As Boolean = Double.TryParse(xValue, xnumber)
        itemIsNumeric = itemIsNumeric And Double.TryParse(yValue, ynumber)

        ' teste si les items à comparer sont de type date ( si cast OK )
        Dim xdate, ydate As Date
        Dim itemIsDate As Boolean = Date.TryParse(xValue, xdate)
        itemIsDate = itemIsDate And Date.TryParse(yValue, ydate)

        ' compare les subItems , méthode choisie en fonction du type d'item
        ' @fixme risque de crasher si un item de type numérique ou date  est manquant
        If OrderOfSort = SortOrder.Ascending Then
            If itemIsNumeric Then
                Return xnumber.CompareTo(ynumber)
            ElseIf itemIsDate Then
                Return xdate.CompareTo(ydate)
            Else
                Return String.Compare(xValue, yValue)
            End If
        Else
            If itemIsNumeric Then
                Return -xnumber.CompareTo(ynumber)
            ElseIf itemIsDate Then
                Return -xdate.CompareTo(ydate)
            Else
                Return -String.Compare(xValue, yValue)
            End If
        End If
    End Function

    ' Return a string representing this item's sub-item.
    Private Function ItemString(ByVal listview_item As ListViewItem, ByVal idx As Integer) As String
        Dim slvw As ListView = listview_item.ListView

        ' Make sure the item has the needed sub-item.
        ' empêche de crasher si subitem vide (numéro de version dans programmes par ex)
        Dim value As String = ""
        If idx <= listview_item.SubItems.Count - 1 Then
            value = listview_item.SubItems(idx).Text
        End If

        ' Return the sub-item's value.
        If slvw.Columns(idx).TextAlign = HorizontalAlignment.Right Then
            ' Pad so numeric values sort properly.
            Return value.PadLeft(20)
        Else
            Return value
        End If
    End Function
End Class
