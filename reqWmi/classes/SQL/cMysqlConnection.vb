Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class cMysqlConnection
    Private _sqlCnx As MySqlClient.MySqlConnection

    Public ReadOnly Property sqlCnx() As MySqlClient.MySqlConnection
        Get
            Return _sqlCnx
        End Get
    End Property

    Public Sub New()
        _sqlCnx = New MySqlConnection(getDBConnectionString())
    End Sub

    Public Function getMySqlConnection() As MySqlClient.MySqlConnection
        Return New MySqlConnection(getDBConnectionString)
    End Function

    Public Shared Function getDBConnectionString() As String
        Dim DBserver, DBdatabase, DBUser, DBPAssword As String
        With program.preferences
            DBserver = .sDBServer
            DBdatabase = .sDBDataSource
            DBUser = .sDBUser
            DBPAssword = .sDBPassword
        End With

        Return String.Format("Database={0};Data Source={1};User Id={2};Password={3};Pooling=true;Min Pool Size=1; Connection Timeout=10", DBdatabase, DBserver, DBUser, DBPAssword)

    End Function

    'Public Shared Function getMysqlConnection() As MySqlConnection
    '    Return New MySqlConnection(getDBConnectionString())
    'End Function

    ''' <summary>
    ''' Ouvre Cnx Mysql
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' Utiliser le polling et ne pas gérer à la main les Cnxs => perfs ...
    ''' </remarks>
    Public Function openSQLConnection() As Boolean
        Try
            _sqlCnx.Open()
        Catch ex As MySqlClient.MySqlException
            Select Case ex.Number
                Case 0
                    MessageBox.Show("Impossible de se connecter au serveur", "Analog", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Case 1045
                    MessageBox.Show("Impossible de se connecter à la base données, " & vbNewLine & "Utilisateur/Mot de passe invalide", "Analog", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Case Else
                    MessageBox.Show("Impossible de se connecter à la base données" & vbNewLine & "Message : " & ex.Message & vbNewLine & "Code erreur : " & ex.Number, "Analog", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select

            Return False
        End Try

        Return True
    End Function

    Public Function closeSqlConnection() As Boolean
        Try
            _sqlCnx.Close()
        Catch ex As MySqlClient.MySqlException
            MessageBox.Show("Erreur lors de la fermeture de la connection")

            Return False
        End Try

        Return True
    End Function

End Class
