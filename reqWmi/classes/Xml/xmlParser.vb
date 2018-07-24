Imports System.Xml

Public Class xmlParser
    Private _xmlDoc As XmlDocument

    Public ReadOnly Property xmlDoc() As XmlDocument
        Get
            Return _xmlDoc
        End Get
    End Property

    Public Sub New()

    End Sub

    Public Sub load()
        _xmlDoc = New XmlDocument
        _xmlDoc.Load("c:\lstStation.xml")
    End Sub





End Class
