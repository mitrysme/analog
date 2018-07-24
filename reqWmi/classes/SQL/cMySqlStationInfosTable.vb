Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class cMySqlStationInfosTable

    Private _infos_id As Integer
    Private _station_name As String
    Private _serialNumber As String
    Private _ram As Double
    Private _osName As String
    Private _modele As String
    Private _constructeur As String
    Private _socle As String
    Private _freeSpaceOnDisk As String
    Private _smartStatus As String
    Private _towerCase As Boolean
    Private _uptime As String
    Private _hdd_total_space As Integer
    Private _hdd_free_space_percent As Integer
    Private _userName As String

    Public Shared Function save(ByRef station As cstation) As Integer
        If isStationInfosExist(station.stationName) Then
            Return Update(station)
        Else
            Return Insert(station)
        End If
    End Function

    Private Shared Function Insert(ByRef station As cstation) As Integer
        Dim query As String = " INSERT INTO station_infos(infos_id,station_name ,serialnumber, ram, osname, modele ,constructeur,socle ,freespaceondisk," _
        & " smartstatus, towercase, uptime, hdd_total_space, hdd_free_space_percent, username)" _
        & " VALUES(@sInfosID, @sStationName, @sSerialNumber, @ulongRam, @sOsName, @sModele, @sConstructeur, @sScocle, @sFreeSpaceOnDisk ," _
        & "@sSmartStatus, @bTowerCase ,@sUptime, @ihdd_total_space, @ihdd_free_space_percent, @username)"

        Dim mysqlParams As New List(Of MySqlParameter)

        With mysqlParams
            .Add(New MySqlParameter("@sInfosID", Nothing)) ' auto_increment
            .Add(New MySqlParameter("@sStationName", station.stationName))
            .Add(New MySqlParameter("@sSerialNumber", station.gInfoStation.serialNumber))
            .Add(New MySqlParameter("@ulongRam", station.gInfoStation.totalPhysicalMemory))
            .Add(New MySqlParameter("@sOsName", station.gInfoStation.operatingSystem))
            .Add(New MySqlParameter("@sModele", station.gInfoStation.model))
            .Add(New MySqlParameter("@sConstructeur", station.gInfoStation.manufacturer))
            .Add(New MySqlParameter("@sScocle", station.socle))
            .Add(New MySqlParameter("@sFreeSpaceOnDisk", station.freeSpaceOnSystemDisk))
            .Add(New MySqlParameter("@sSmartStatus", station.smart.smartFailurePredictStatusAsString(station.gInfoStation.systemDrive)))
            .Add(New MySqlParameter("@bTowerCase", station.gInfoStation.towercase))
            .Add(New MySqlParameter("@sUptime", station.gInfoStation.uptime))
            .Add(New MySqlParameter("@ihdd_total_space", station.systemDiskTotalCapacity))
            .Add(New MySqlParameter("@ihdd_free_space_percent", station.systemDiskFreeSpaceAsPercentage / 100))
            .Add(New MySqlParameter("@username", station.gInfoStation.userName))
        End With

        Return MySqlHelper.ExecuteNonQuery(cMysqlConnection.getDBConnectionString, query, mysqlParams.ToArray)
    End Function

    Private Shared Function Update(ByRef station As cstation) As Integer
        Dim query As String = String.Format("UPDATE station_infos SET serialnumber=@sSerialNumber, ram=@ulongRam, osname=@sOsName, modele=@sModele, constructeur=@sConstructeur," _
                                            & " socle=@sScocle,freespaceondisk=@sFreeSpaceOnDisk, smartstatus= @sSmartStatus, towercase=@bTowerCase, uptime=@sUptime," _
                                            & " hdd_total_space=@ihdd_total_space, hdd_free_space_percent=@ihdd_free_space_percent,username=@sUserName" _
                                            & " WHERE station_name='{0}'", station.stationName)

        Dim mysqlParams As New List(Of MySqlParameter)

        With mysqlParams
            .Add(New MySqlParameter("@sSerialNumber", station.gInfoStation.serialNumber))
            .Add(New MySqlParameter("@ulongRam", station.gInfoStation.totalPhysicalMemory))
            .Add(New MySqlParameter("@sOsName", station.gInfoStation.operatingSystem))
            .Add(New MySqlParameter("@sModele", station.gInfoStation.model))
            .Add(New MySqlParameter("@sConstructeur", station.gInfoStation.manufacturer))
            .Add(New MySqlParameter("@sScocle", station.socle))
            .Add(New MySqlParameter("@sFreeSpaceOnDisk", station.freeSpaceOnSystemDisk))
            .Add(New MySqlParameter("@sSmartStatus", station.smart.smartFailurePredictStatusAsString(station.gInfoStation.systemDrive)))
            .Add(New MySqlParameter("@bTowerCase", station.gInfoStation.towercase))
            .Add(New MySqlParameter("@sUptime", station.gInfoStation.uptime))
            .Add(New MySqlParameter("@ihdd_total_space", station.systemDiskTotalCapacity))
            .Add(New MySqlParameter("@ihdd_free_space_percent", station.systemDiskFreeSpaceAsPercentage / 100))
            .Add(New MySqlParameter("@sUserName", station.gInfoStation.userName))
        End With

        Return MySqlHelper.ExecuteNonQuery(cMysqlConnection.getDBConnectionString, query, mysqlParams.ToArray)
    End Function

    Public Shared Function isStationInfosExist(ByVal stationName As String) As Boolean
        Dim exist As Boolean
        Dim query As String = String.Format("SELECT COUNT(*) FROM station_infos WHERE station_name ='{0}'", stationName)

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
