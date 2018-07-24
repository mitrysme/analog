Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class cMysqlcommentaires

    Public Shared Function getCommentairesForStation(ByVal station As String) As List(Of cCommentaire)
        Dim mySqlCnx As cMysqlConnection = New cMysqlConnection
        Dim cmd As IDbCommand = New MySqlClient.MySqlCommand("SELECT * from commentaire WHERE commentaire_stationId='" & station & "' ORDER BY commentaire_date DESC")
        Dim listOfcommentaires As New List(Of cCommentaire)

        cmd.Connection = mySqlCnx.sqlCnx

        If mySqlCnx.openSQLConnection Then
            Try
                Using reader As IDataReader = cmd.ExecuteReader

                    While reader.Read
                        Dim texte, user, stationid As String
                        Dim id As Integer
                        Dim dtDate As DateTime

                        id = CInt(reader.GetString(0))
                        texte = reader.GetString(1)
                        dtDate = CType(reader.GetString(2), DateTime)
                        user = reader.GetString(3)
                        stationid = reader.GetString(4)

                        listOfcommentaires.Add(New cCommentaire(id, texte, dtDate, user, stationid))
                    End While
                End Using
            Finally
                mySqlCnx.closeSqlConnection()
                mySqlCnx = Nothing
            End Try
        End If

        Return listOfcommentaires
    End Function

    Public Shared Function searchCommentairesFor(ByVal searchExpr As String) As List(Of cCommentaire)
        Dim escapedSearchExpr = MySqlClient.MySqlHelper.EscapeString(searchExpr)
        Dim mySqlCnx As cMysqlConnection = New cMysqlConnection
        Dim listOfcommentaires As New List(Of cCommentaire)

        Dim sqlQuery As String = "SELECT * from commentaire WHERE MATCH(commentaire_texte) AGAINST('" & escapedSearchExpr & "')"

        If mySqlCnx.openSQLConnection Then
            Try
                Using reader As IDataReader = MySqlClient.MySqlHelper.ExecuteReader(mySqlCnx.sqlCnx, sqlQuery)
                    Dim texte, user, stationid As String
                    Dim id As Integer
                    Dim dtDate As DateTime

                    stationid = Nothing

                    While reader.Read()
                        id = CInt(reader.GetString(0))
                        texte = reader.GetString(1)
                        dtDate = CType(reader.GetString(2), DateTime)
                        user = reader.GetString(3)
                        If Not reader.IsDBNull(4) Then
                            stationid = reader.GetString(4)
                        End If

                        listOfcommentaires.Add(New cCommentaire(id, texte, dtDate, user, stationid))
                    End While
                End Using
            Finally
                mySqlCnx.closeSqlConnection()
                mySqlCnx = Nothing
            End Try
        End If

        Return listOfcommentaires
    End Function

    Public Shared Function sendCommentaire(ByVal texte As String, _
                                           Optional ByVal stationName As String = Nothing) As Integer

        Dim mySqlCnx As cMysqlConnection = New cMysqlConnection
        Dim cmd As IDbCommand = New MySqlClient.MySqlCommand("INSERT INTO commentaire (commentaire_texte,commentaire_date,commentaire_user,commentaire_stationId)" _
                                                             & "VALUES(@sCommentaire, @sdate, @sUser, @sStation)")
        Dim nbrows As Integer = 0

        cmd.Connection = mySqlCnx.sqlCnx

        With cmd.Parameters
            .Add(New MySqlClient.MySqlParameter("@sCommentaire", texte))
            .Add(New MySqlClient.MySqlParameter("@sdate", Date.Now))
            .Add(New MySqlClient.MySqlParameter("@sUser", functions.getDomainUserIdentity(True)))
            .Add(New MySqlClient.MySqlParameter("@sStation", stationName))
        End With

        If mySqlCnx.openSQLConnection Then
            Try
                nbrows = cmd.ExecuteNonQuery
            Finally
                mySqlCnx.closeSqlConnection()
                mySqlCnx = Nothing
            End Try
        End If

        Return nbrows
    End Function

    ''' <summary>
    ''' Mets à jour un commentaire
    ''' </summary>
    ''' <param name="texte">Texte du commentaire à éditer</param>
    ''' <param name="commentaireID"></param>
    ''' <returns>Nombre de lignes affectées par la commande</returns>
    ''' <remarks></remarks>
    Public Shared Function updateCommentaire(ByVal texte As String, ByVal commentaireID As Integer) As Integer
        Dim mySqlCnx As cMysqlConnection = New cMysqlConnection
        Dim escapedTexte = MySqlClient.MySqlHelper.EscapeString(texte)
        Dim cmd As IDbCommand = New MySqlClient.MySqlCommand(String.Format("UPDATE commentaire SET commentaire_texte='{0}' WHERE commentaire_id='{1}'", escapedTexte, commentaireID))
        Dim nbRows As Integer = 0

        cmd.Connection = mySqlCnx.sqlCnx

        If mySqlCnx.openSQLConnection Then
            Try
                nbRows = cmd.ExecuteNonQuery

                If nbRows = 0 Then
                    MsgBox(String.Format("{0} lignes éditées", nbRows))
                End If
            Catch ex As Exception
                MsgBox("Erreur lors de la mise à jour du commentaire" & vbNewLine & "Message : " & ex.Message, MsgBoxStyle.Critical)
            Finally
                mySqlCnx.closeSqlConnection()
                mySqlCnx = Nothing
            End Try
        End If

        Return nbRows
    End Function

    ''' <summary>
    ''' Retourne les 3 derniers commentaires
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getLastComments() As List(Of cCommentaire)
        Dim mySqlCnx As cMysqlConnection = New cMysqlConnection
        Dim cmd As IDbCommand = New MySqlClient.MySqlCommand("SELECT * from commentaire  ORDER BY commentaire_date DESC LIMIT 0,50")
        Dim listOfcommentaires As New List(Of cCommentaire)

        cmd.Connection = mySqlCnx.sqlCnx

        If mySqlCnx.openSQLConnection Then
            Try
                Using reader As IDataReader = cmd.ExecuteReader

                    While reader.Read
                        Dim texte, user, stationid As String
                        Dim id As Integer
                        Dim dtDate As DateTime

                        id = CInt(reader.GetString(0))
                        texte = reader.GetString(1)
                        dtDate = CType(reader.GetString(2), DateTime)
                        user = reader.GetString(3)
                        If Not reader.IsDBNull(4) Then
                            stationid = reader.GetString(4)
                        Else
                            stationid = Nothing
                        End If

                        listOfcommentaires.Add(New cCommentaire(id, texte, dtDate, user, stationid))
                    End While
                End Using
            Finally
                mySqlCnx.closeSqlConnection()
                mySqlCnx = Nothing
            End Try
        End If

        Return listOfcommentaires
    End Function

    Public Shared Function eraseCommentaire(ByVal commentaireID As Integer) As Integer
        Dim mySqlCnx As cMysqlConnection = New cMysqlConnection
        Dim cmd As IDbCommand = New MySqlClient.MySqlCommand(String.Format("DELETE FROM commentaire  WHERE commentaire_id='{0}'", commentaireID))
        Dim nbrows As Integer = 0

        cmd.Connection = mySqlCnx.sqlCnx

        If mySqlCnx.openSQLConnection Then
            Try
                nbrows = cmd.ExecuteNonQuery

                If nbrows = 0 Then
                    MsgBox(String.Format("{0} lignes éditées", nbrows))
                End If
            Catch ex As Exception
                MsgBox("Impossible d'effacer le  commentaire", MsgBoxStyle.Critical)
            Finally
                mySqlCnx.closeSqlConnection()
                mySqlCnx = Nothing
            End Try
        End If

        Return nbrows
    End Function
End Class

