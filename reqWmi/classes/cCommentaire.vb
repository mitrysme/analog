Public Class cCommentaire
    Private _id As Integer
    Private _texte As String
    Private _date As DateTime
    Private _user As String
    Private _stationId As String

#Region "getter/setter"
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property texte() As String
        Get
            Return _texte
        End Get
        Set(ByVal value As String)
            _texte = value
        End Set
    End Property
    Public Property dtDate() As DateTime
        Get
            Return _date
        End Get
        Set(ByVal value As DateTime)
            _date = value
        End Set
    End Property
    Public Property user() As String
        Get
            Return _user
        End Get
        Set(ByVal value As String)
            _user = value
        End Set
    End Property
    Public Property stationId() As String
        Get
            Return _stationId
        End Get
        Set(ByVal value As String)
            _stationId = value
        End Set
    End Property
#End Region

    Public Sub New(ByVal id As Integer, ByVal texte As String, ByVal dtDate As DateTime, ByVal user As String, ByVal stationId As String)
        _id = id
        _texte = texte
        _date = dtDate
        _user = user
        _stationId = stationId
    End Sub

    Public Sub New()
        '
    End Sub
End Class
