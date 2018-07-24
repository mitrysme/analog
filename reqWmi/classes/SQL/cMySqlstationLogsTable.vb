Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class cMySqlStationLogsTable
    Private _log_id As Integer

    Private _stationName As String

    Private _errDisk As Integer

    Private _driverPredictFail As Integer

    Private _errNetwork As Integer

    Private _errBsod As Integer

    Private _errApplication As Integer

    Private _errOffice As Integer

    Public Shared Function save(ByRef station As cstation) As Integer
        If isStationLogsExist(station.stationName) Then
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
        ' FIXME => moche 
        ' CRITICAL => stocke 0 dans la base si la valeur est sensée etre NULL , en cas de ping KO par exemple
        Dim systemLogErrorCount = station.ntSystemLog.getNtSystemLogErrorCount(station.gInfoStation.OsInstallDevice)

        Dim query As String = " INSERT INTO station_logs(log_id,station_name,err_disk,driver_predict_fail,err_network,err_reboot,err_bsod,err_application,err_office)" _
                      & " VALUES(@slog_id, @sStation_name, @iErr_Disk,@iDriver_predict_fail,@ierr_network,@ierr_reboot,@ierr_bsod,@ierr_application,@ierr_office)"

        Dim mysqlParams As New List(Of MySqlParameter)

        With mysqlParams
            .Add(New MySqlParameter("@slog_id", Nothing))
            .Add(New MySqlParameter("@sStation_name", station.stationName))
            .Add(New MySqlParameter("@iErr_Disk", systemLogErrorCount.iNumDiskBlockErrorOnSystemDisk))
            .Add(New MySqlParameter("@iDriver_predict_fail", systemLogErrorCount.iNumDiskPredictFail))
            .Add(New MySqlParameter("@ierr_network", systemLogErrorCount.iNumNetworkError))
            .Add(New MySqlParameter("@ierr_reboot", systemLogErrorCount.iNumShutdownError))
            .Add(New MySqlParameter("@ierr_bsod", systemLogErrorCount.iNumBsobError))
            .Add(New MySqlParameter("@ierr_application", Nothing))
            .Add(New MySqlParameter("@ierr_office", Nothing))
        End With

        Return MySqlHelper.ExecuteNonQuery(cMysqlConnection.getDBConnectionString, query, mysqlParams.ToArray)
    End Function

    Private Shared Function Update(ByRef station As cstation) As Integer
        ' FIXME => moche 
        Dim systemLogErrorCount = station.ntSystemLog.getNtSystemLogErrorCount(station.gInfoStation.OsInstallDevice)
        Dim query As String = String.Format("UPDATE station_logs " _
                                            & "SET err_disk=@iErr_Disk, driver_predict_fail=@iDriver_predict_fail, err_network=@ierr_network, err_reboot=@ierr_reboot," _
                                            & " err_bsod=@ierr_bsod, err_application=@ierr_application,err_office=@ierr_office" _
                                            & " WHERE station_name='{0}'", station.stationName)

        Dim mysqlParams As New List(Of MySqlParameter)

        With mysqlParams
            .Add(New MySqlParameter("@iErr_Disk", systemLogErrorCount.iNumDiskBlockErrorOnSystemDisk.ToString))
            .Add(New MySqlParameter("@iDriver_predict_fail", systemLogErrorCount.iNumDiskPredictFail))
            .Add(New MySqlParameter("@ierr_network", systemLogErrorCount.iNumNetworkError))
            .Add(New MySqlParameter("@ierr_reboot", systemLogErrorCount.iNumShutdownError))
            .Add(New MySqlParameter("@ierr_bsod", systemLogErrorCount.iNumBsobError))
            .Add(New MySqlParameter("@ierr_application", Nothing))
            .Add(New MySqlParameter("@ierr_office", Nothing))
        End With

        Return MySqlHelper.ExecuteNonQuery(cMysqlConnection.getDBConnectionString, query, mysqlParams.ToArray)
    End Function

    ''' <summary>
    ''' Vérifie si station passée en paramètre est stockée dans la base 
    ''' </summary>
    ''' <param name="StationName">Nom de la station</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' fixme => executeReader non protégé => crash si base KO 
    ''' </remarks>
    Public Shared Function isStationLogsExist(ByVal StationName As String) As Boolean
        Dim exist As Boolean
        Dim query As String = String.Format("SELECT COUNT(*) from station_logs where station_name ='{0}'", StationName)

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
