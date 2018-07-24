Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class cMysqlDisplaysTable
    Public displayId As Integer

    Public stationName As String

    Public monitorName As String

    Public monitorSn As String

    Public monitorDisplayName As String

    Public Shared Function getDataTable() As DataTable
        Dim dt As New DataTable
        Dim query As String = "SELECT station_name,monitor_name, monitor_sn,monitor_display_name FROM displays"

        ' dt = New DataTable("displays")

        Using mysqlAdapter As New MySqlDataAdapter(query, cMysqlConnection.getDBConnectionString)
            mysqlAdapter.Fill(dt)
        End Using

        Return dt
    End Function

    Public Shared Function save(ByVal listOfmonitorEDIDInfo As List(Of cMonitorInfo.monitorEdidInfo), ByVal stationName As String) As Integer
        ' TODO
        ' On efface tout et on réécrit 
        ' il faudrait faire plus intelligent ...
        ' Comparer liste dans base et résultat scan si  changement -->  modif / Update de la BDD si nécessaire ...
        '
        delete(stationName)

        If Not listOfmonitorEDIDInfo Is Nothing Then
            If listOfmonitorEDIDInfo.Count > 0 Then
                For Each monitorinfo As cMonitorInfo.monitorEdidInfo In listOfmonitorEDIDInfo
                    insert(monitorinfo, stationName)
                Next
            End If
        End If
    End Function

    ''' <summary>
    ''' efface tous les ecrans associés à la station passée en paramètre
    ''' </summary>
    ''' <param name="stationName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function delete(ByVal stationName As String) As Integer
        Dim query As String = String.Format("DELETE FROM displays WHERE station_name='{0}'", stationName)

        Return MySqlHelper.ExecuteNonQuery(cMysqlConnection.getDBConnectionString, query)
    End Function

    Public Shared Function selectdisplaysForStation(ByVal stationName As String) As List(Of cMonitorInfo.monitorEdidInfo)
        Dim query As String = String.Format("SELECT station_name, monitor_name, monitor_sn,  monitor_display_name  FROM displays WHERE station_name ='{0}'", stationName)
        Dim listOfMonitor As New List(Of cMonitorInfo.monitorEdidInfo)

        Using reader As MySqlDataReader = MySqlHelper.ExecuteReader(cMysqlConnection.getDBConnectionString, query)
            If reader.HasRows Then
                While reader.Read
                    Dim display As New cMonitorInfo.monitorEdidInfo

                    With display
                        If Not reader.IsDBNull(1) Then .monitorName = reader.GetString(1)
                        If Not reader.IsDBNull(2) Then .serialNumber = reader.GetString(2)
                        If Not reader.IsDBNull(3) Then .displayName = reader.GetString(3)
                    End With

                    listOfMonitor.Add(display)
                End While
            End If
        End Using

        Return listOfMonitor
    End Function


    Public Shared Function insert(ByVal monitorEDIDInfo As cMonitorInfo.monitorEdidInfo, ByVal stationName As String) As Integer

        Dim query As String = " INSERT INTO displays(station_name,monitor_name,monitor_sn,monitor_display_name)" _
                      & " VALUES(@sStation_Name, @sMonitor_Name, @sMonitor_Sn, @sMonitor_Display_Name)"

        Dim mysqlParams As New List(Of MySqlParameter)

        With mysqlParams
            .Add(New MySqlParameter("@sStation_name", stationName))
            .Add(New MySqlParameter("@sMonitor_Name", monitorEDIDInfo.monitorName))
            .Add(New MySqlParameter("@sMonitor_Sn", monitorEDIDInfo.serialNumber))
            .Add(New MySqlParameter("@sMonitor_Display_Name", monitorEDIDInfo.displayName))
        End With

        Return MySqlHelper.ExecuteNonQuery(cMysqlConnection.getDBConnectionString, query, mysqlParams.ToArray)
    End Function

End Class
