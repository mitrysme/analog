Public Class frmNetworkInterfacesDetails
    Inherits frmBaseDynDetails

    Private _listOfNetworkAdapter As List(Of cgInfosStation.networkAdapter)

    Public Sub frm_load() Handles Me.Load
        Me.CenterToParent()
    End Sub


    Public Sub New(ByRef listOfNetworkAdapter As List(Of cgInfosStation.networkAdapter))
        MyBase.New()
        textBoxTitle = "Interface"
        Text = "Interfaces - Detail"
        _listOfNetworkAdapter = listOfNetworkAdapter
        MyBase.drawForm()
    End Sub

    Protected Overrides Function getDatas() As System.Collections.ICollection
        Return Me._listOfNetworkAdapter
    End Function

End Class
