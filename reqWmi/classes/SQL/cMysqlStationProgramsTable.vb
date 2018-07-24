Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class cMysqlStationProgramsTable

    Private _programName As String
    Private _programVersion As String
    Private _programInstallDate As Date
    Private Shared _columnNameToIndexCache As Dictionary(Of String, Integer)

    Public Shared Function save(ByVal listOfprograms As List(Of cPrograms.InstalledProgram), ByVal stationName As String) As Integer
        deleteAllProgramForStation(stationName) ' => brutal  

        Dim bStringQuery As New System.Text.StringBuilder

        bStringQuery.Append(" INSERT INTO station_programs( station_name, program_name, program_version, program_date_install, program_publisher) VALUES ")

        For Each p As cPrograms.InstalledProgram In listOfprograms

            If Not p.DisplayName Is Nothing Then p.DisplayName = MySqlHelper.EscapeString(p.DisplayName)
            If Not p.DisplayVersion Is Nothing Then p.DisplayVersion = MySqlHelper.EscapeString(p.DisplayVersion)
            If Not p.InstallDate Is Nothing Then p.InstallDate = MySqlHelper.EscapeString(p.InstallDate)
            If Not p.Publisher Is Nothing Then p.Publisher = MySqlHelper.EscapeString(p.Publisher)

            bStringQuery.Append(String.Format("('{0}','{1}','{2}','{3}','{4}'), ", stationName, p.DisplayName, p.DisplayVersion, p.InstallDate, p.Publisher))

        Next

        bStringQuery.Remove(bStringQuery.Length - 2, 1)

        Return MySqlHelper.ExecuteNonQuery(cMysqlConnection.getDBConnectionString, bStringQuery.ToString)

    End Function

    Public Shared Sub selectProgramsforStation(ByVal stationName As String, ByRef listOfPrograms As List(Of cPrograms.InstalledProgram))
        Dim query As String = String.Format("SELECT station_name, program_name, program_version, program_date_install, program_publisher" _
                                            & " FROM station_programs WHERE station_name = '{0}'", MySqlHelper.EscapeString(stationName))

        Using reader As MySqlDataReader = MySqlHelper.ExecuteReader(cMysqlConnection.getDBConnectionString, query)
            If reader.HasRows Then

                If _columnNameToIndexCache Is Nothing Then
                    _columnNameToIndexCache = New Dictionary(Of String, Integer)

                    For i As Integer = 0 To reader.FieldCount - 1
                        _columnNameToIndexCache.Add(reader.GetName(i), i)
                    Next
                End If

                While reader.Read
                    Dim p As New cPrograms.InstalledProgram

                    With p
                        .InstallDate = reader.GetString(_columnNameToIndexCache("program_date_install"))
                        .DisplayName = reader.GetString(_columnNameToIndexCache("program_name"))
                        .DisplayVersion = reader.GetString(_columnNameToIndexCache("program_version"))
                        .Publisher = reader.GetString(_columnNameToIndexCache("program_publisher"))
                    End With

                    listOfPrograms.Add(p)

                End While
            End If
        End Using
    End Sub

    Public Shared Function deleteAllProgramForStation(ByVal stationName As String) As Integer
        Dim query As String = String.Format("DELETE FROM station_programs WHERE station_name = '{0}'", stationName)

        Return MySqlHelper.ExecuteNonQuery(cMysqlConnection.getDBConnectionString, query)
    End Function
End Class
