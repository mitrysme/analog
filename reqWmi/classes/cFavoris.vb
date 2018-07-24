Imports System.Collections
Imports System.Xml.Serialization
Imports System.IO
' voir http://msdn.microsoft.com/fr-fr/library/58a18dwa(v=VS.90).aspx
Imports System.Configuration ' config


Public Class cFavoris
    Public stationName As String
    Public note As String
    Public nbErrDisk As Nullable(Of Integer) = Nothing
    Public nbErrNetwork As Nullable(Of Integer) = Nothing
    Public nbErrShutdown As Nullable(Of Integer) = Nothing
    Public nbErrBsod As Nullable(Of Integer) = Nothing
    Public favorisDate As Date

    Public Sub New(ByVal stationName As String, Optional ByVal note As String = "")
        Me.stationName = stationName
        Me.note = note
    End Sub

    ' nécessaire pour sérialisation
    Public Sub New()
       
    End Sub
End Class

Public Class cColFavoris
    Implements ICollection

    <XmlAttribute()> _
    Private _colFavoris As New List(Of cFavoris)
    ' ne pas utiliser System.AppDomain.CurrentDomain.BaseDirectory car si lancement depuis Partage réseau tente d'écrire les fichiers de config sur le serveur ( pb droit etc )
    ' doit créer le fichier en local dans local settings\application data\...
    'Private Shared _favorisPath As String = String.Concat(System.Windows.Forms.Application.LocalUserAppDataPath, "\", "favoris.xml") ' stocke le fichier favoris dans le rép courant de l'application

    Private Shared _favorisPath As String = getUserAppDataPathWhithoutVersion() & "favoris.xml"

    Public Sub CopyTo(ByVal array As System.Array, ByVal index As Integer) Implements System.Collections.ICollection.CopyTo
        ' pas implémenté
    End Sub

  
#Region "properties"
    Default Public Overloads ReadOnly _
Property Item(ByVal index As Integer) As cFavoris
        Get
            Return CType(_colFavoris(index), cFavoris)
        End Get
    End Property

    Public Shared ReadOnly Property favorisPath() As String
        Get
            Return _favorisPath
        End Get
    End Property


    Public ReadOnly Property Count() As Integer Implements System.Collections.ICollection.Count
        Get
            Return _colFavoris.Count
        End Get
    End Property

    Public ReadOnly Property IsSynchronized() As Boolean Implements System.Collections.ICollection.IsSynchronized
        Get
            ' pas implémenté
        End Get
    End Property

    Public ReadOnly Property SyncRoot() As Object Implements System.Collections.ICollection.SyncRoot
        Get
            Return Me
        End Get
    End Property
#End Region

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return _colFavoris.GetEnumerator
    End Function


    ''' <summary>
    ''' Ajouter un favoris dans la collection
    ''' </summary>
    ''' <param name="newFavoris"></param>
    ''' <returns></returns>
    ''' <remarks>renvoie -1 si ajout impossible</remarks>
    Public Function Add(ByVal newFavoris As cFavoris) As Integer
        ' recherche dans la collection si la station n'existe pas déja...
        Dim exist As Boolean = False

        For Each favoris In _colFavoris
            If favoris.stationName = newFavoris.stationName Then
                exist = True
                Exit For
            End If
        Next

        If Not exist Then
            _colFavoris.Add(newFavoris)
            Return _colFavoris.Count
        Else
            MsgBox("La station " & newFavoris.stationName & " existe déjà dans vos favoris")
            Return -1
        End If
    End Function

    Public Function removeFavorisByStationName(ByVal stationName As String) As Boolean
        Dim removed As Boolean = False
        For Each favoris As cFavoris In _colFavoris
            If favoris.stationName = stationName Then
                _colFavoris.Remove(favoris)
                removed = True
                Exit For
            End If
        Next
        Return removed
    End Function

    ''' <summary>
    ''' Cherche si un favoris existe
    ''' </summary>
    ''' <param name="stationName">Nom de la station</param>
    ''' <returns>boolean</returns>
    ''' <remarks></remarks>
    Public Function favorisExist(ByVal stationName As String) As Boolean
        Dim exist As Boolean = False
        For Each favoris As cFavoris In _colFavoris
            If favoris.stationName = stationName Then
                exist = True
                Exit For
            End If
        Next

        Return exist
    End Function

    Public Sub writeToXml()
        Dim xml As New XmlSerializer(Me.GetType)

        Using writer As TextWriter = New StreamWriter(_favorisPath)
            xml.Serialize(writer, Me)
            writer.Close() ' sauvegarde du fichier 
        End Using

    End Sub

    Private Shared Function getUserAppDataPathWhithoutVersion() As String
        Dim  _atestAppPath As String() = System.Windows.Forms.Application.LocalUserAppDataPath.Split(CChar(IO.Path.DirectorySeparatorChar))
        Dim _UserAppDataPathWhithoutVersion As String = ""

        For i As Integer = 0 To _atestAppPath.Count - 2
            _UserAppDataPathWhithoutVersion += _atestAppPath(i)
            _UserAppDataPathWhithoutVersion += IO.Path.DirectorySeparatorChar
        Next

        Return _UserAppDataPathWhithoutVersion
    End Function

End Class
