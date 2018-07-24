Public Class frmDisplayDetails
    Inherits frmBaseDynDetails

    Private _listOfmonitorEdidInfo As List(Of cMysqlDisplaysTable)

    Public Sub New(ByRef listOfmonitorEdidInfo As List(Of cMysqlDisplaysTable))
        MyBase.New()
        textBoxTitle = "Ecran"
        Text = "Ecrans - Detail"
        _listOfmonitorEdidInfo = listOfmonitorEdidInfo
        MyBase.drawForm()
    End Sub

    Protected Overrides Function getDatas() As System.Collections.ICollection
        Return Me._listOfmonitorEdidInfo
    End Function

End Class
