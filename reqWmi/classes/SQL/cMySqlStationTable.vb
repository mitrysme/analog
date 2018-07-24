Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class cMySqlStationTable
    Private _stationName As String
    Private _dateScan As DateTime
    Private _deleted As Boolean
    Private _errMessage As String
    Private _programHashCode As Int32
    Private _programDateScan As Date
    Private Shared _columnNameToIndexCache As Dictionary(Of String, Integer)

#Region "properties"

    Public ReadOnly Property stationName() As String
        Get
            Return _stationName
        End Get
    End Property
    Public ReadOnly Property dateScan() As DateTime
        Get
            Return _dateScan
        End Get
    End Property
    Public ReadOnly Property deleted() As Boolean
        Get
            Return _deleted
        End Get
    End Property
    Public ReadOnly Property errMessage() As String
        Get
            Return _errMessage
        End Get
    End Property
    Public ReadOnly Property programHashCode() As Int32
        Get
            Return _programHashCode
        End Get
    End Property

#End Region

    ''' <summary>
    ''' charge stations depuis la base
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' throws exception
    ''' </remarks>
    Public Shared Function selectAll(Optional ByVal deletedStations As Boolean = False, _
                                     Optional ByVal stationName As String = Nothing) As Dictionary(Of String, cMySqlStationTable)

        Dim filterDeletedStation As String = ""

        Dim dicOfStation As New Dictionary(Of String, cMySqlStationTable)
        Dim query As String = "SELECT station_name,datescan, deleted, err_message,program_hashcode, program_datescan FROM station"
        If deletedStations = False Then query += " WHERE deleted = 0"
        If stationName IsNot Nothing Then query += String.Format(" WHERE station_name = '{0}'", stationName)


        Using reader As MySqlDataReader = MySqlHelper.ExecuteReader(cMysqlConnection.getDBConnectionString, query)
            If reader.HasRows Then

                If _columnNameToIndexCache Is Nothing Then
                    _columnNameToIndexCache = New Dictionary(Of String, Integer)

                    For i As Integer = 0 To reader.FieldCount - 1
                        _columnNameToIndexCache.Add(reader.GetName(i), i)
                    Next
                End If

                While reader.Read
                    Dim cMysqlStationtable As New cMySqlStationTable

                    With cMysqlStationtable
                        ._dateScan = CType(reader.GetString(_columnNameToIndexCache("datescan")), DateTime)
                        ._stationName = reader.GetString(_columnNameToIndexCache("station_name"))
                        If Not reader.IsDBNull(_columnNameToIndexCache("program_hashcode")) Then ._programHashCode = reader.GetInt32(_columnNameToIndexCache("program_hashcode"))
                        ._programDateScan = CType(reader.GetString(_columnNameToIndexCache("datescan")), DateTime)
                        If Not reader.IsDBNull(_columnNameToIndexCache("deleted")) Then ._deleted = reader.GetBoolean(_columnNameToIndexCache("deleted"))
                        If Not reader.IsDBNull(_columnNameToIndexCache("err_message")) Then ._errMessage = reader.GetString(_columnNameToIndexCache("err_message"))
                    End With

                    dicOfStation.Add(cMysqlStationtable.stationName, cMysqlStationtable)
                End While
            End If
        End Using

        Return dicOfStation
    End Function

    Public Shared Function setDeletedStatus(ByVal arrStationNames As ArrayList, ByVal deleteStatus As Boolean) As Integer
        Dim inList As String = "" ' TODO => stringBuilder

        For i = 0 To arrStationNames.Count - 1
            Dim station = arrStationNames(i)
            inList += String.Format("'{0}'", station)

            If i < arrStationNames.Count - 1 Then
                inList += ","
            End If
        Next

        Dim query As String = String.Format("UPDATE station SET deleted=@bdeleted WHERE station_name IN ({0})", inList)

        Dim mysqlParams As New List(Of MySqlParameter)

        With mysqlParams
            .Add(New MySqlParameter("@bdeleted", deleteStatus))
        End With


        Return MySqlHelper.ExecuteNonQuery(cMysqlConnection.getDBConnectionString, query, mysqlParams.ToArray)
    End Function

    Public Shared Function save(ByRef station As cstation) As Integer
        If isStationExist(station.stationName) Then

            If station.errorMessage = String.Empty Then
                Return Update(station)
            Else
                Return 0
            End If
        Else
            Return Insert(station)
        End If
    End Function

    Private Shared Function Insert(ByRef station As cstation) As Integer
        Dim query As String = " INSERT INTO station (station_name,datescan,deleted,err_message, program_hashcode)" _
                            & " VALUES(@sStation_name, @sDateScan, @bDeleted, @sErr_Message, @sProgram_HashCode)"

        Dim mysqlParams As New List(Of MySqlParameter)

        With mysqlParams
            .Add(New MySqlParameter("@sStation_name", station.stationName))
            .Add(New MySqlParameter("@sDateScan", Date.Now))
            .Add(New MySqlParameter("@bDeleted", False))
            .Add(New MySqlParameter("@sErr_Message", station.errorMessage))
            .Add(New MySqlParameter("@sProgram_HashCode", station.programs.getProgramsHashCode))
        End With

        Return MySqlHelper.ExecuteNonQuery(cMysqlConnection.getDBConnectionString, query, mysqlParams.ToArray)
    End Function

    Public Shared Function Update(ByRef station As cstation) As Integer
        Dim query As String = String.Format("UPDATE station SET datescan=@sDateScan, err_message=@sErr_Message, program_hashcode=@sProgramsHashCode WHERE station_name='{0}'", station.stationName)

        Dim mysqlParams As New List(Of MySqlParameter)

        With mysqlParams
            .Add(New MySqlParameter("@sDateScan", Date.Now))
            .Add(New MySqlParameter("@bdeleted", False))
            .Add(New MySqlParameter("@sErr_Message", station.errorMessage))
            .Add(New MySqlParameter("@sProgramsHashCode", station.programs.getProgramsHashCode))
        End With

        Return MySqlHelper.ExecuteNonQuery(cMysqlConnection.getDBConnectionString, query, mysqlParams.ToArray)
    End Function

    Public Shared Function isStationExist(ByVal StationName As String) As Boolean
        Dim exist As Boolean
        Dim query As String = String.Format("SELECT COUNT(*) FROM station WHERE station_name ='{0}'", StationName)

        Using reader As MySqlDataReader = MySqlHelper.ExecuteReader(cMysqlConnection.getDBConnectionString, query)
            If reader.HasRows Then
                reader.Read()
                exist = reader.GetBoolean(0)
            Else
                exist = False
            End If
        End Using

        Return exist
    End Function

   
End Class
