Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class cMysqlStation
    Private Shared _dicFieldsNameToIndex As Dictionary(Of String, Integer)

    ''' <summary>
    ''' Sauvegarde ou update Station dans BDD
    ''' </summary>
    ''' <param name="station">Objet station à sauvegarder</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function save(ByRef station As cstation) As Boolean
        Try
            If cMySqlStationTable.save(station) > 0 Then
                If station.errorMessage = "" Then
                    log.addLogEntry(New cLogEntry("SQL :  sauvegarde station", cLogEntry.enumDebugLevel.INFO, station.stationName, "", Nothing, False))

                    cMySqlStationInfosTable.save(station)
                    cMySqlStationLogsTable.save(station)
                    cMysqlDisplaysTable.save(station.edidInfo.listMonitorEdidInfo, station.stationName)
                End If
            End If


        Catch ex As Exception
            log.addLogEntry(New cLogEntry("SQL : Erreur sauvegarde station", cLogEntry.enumDebugLevel.ERREUR, station.stationName, "", ex, False))

            Return False
        End Try

        Return True
    End Function

    ''' <summary>
    ''' Cherche une station dans la base et retourne un BatchResult
    ''' retourne true si station trouvée
    ''' </summary>
    ''' <param name="stationName">Nom de la station à chercher</param>
    ''' <param name="batchResult"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getStationBatchResultFromDB(ByVal stationName As String, ByRef batchResult As structs.analogStructs.BatchResult) As Boolean
        Dim query As String = "SELECT station.station_name,datescan, deleted, serialnumber, ram, osname, constructeur, freespaceondisk, hdd_total_space, socle, " _
        & "err_message, modele, err_disk, driver_predict_fail,err_network,err_reboot,err_bsod, towercase" _
        & " FROM station" _
        & " LEFT JOIN station_infos ON station.station_name = station_infos.station_name" _
        & " LEFT JOIN station_logs ON station.station_name = station_logs.station_name" _
        & " WHERE station.station_name = '" & stationName & "'"

        Dim Batchresults As New structs.analogStructs.BatchResult

        Try
            Using reader As MySqlDataReader = MySqlHelper.ExecuteReader(cMysqlConnection.getDBConnectionString, query)
                If reader.HasRows Then

                    If _dicFieldsNameToIndex Is Nothing Then
                        _dicFieldsNameToIndex = New Dictionary(Of String, Integer)

                        For i As Integer = 0 To reader.FieldCount - 1
                            _dicFieldsNameToIndex.Add(reader.GetName(i), i)
                        Next
                    End If

                    reader.Read()

                    With batchResult
                        .dateScan = CType(reader.GetString(_dicFieldsNameToIndex("datescan")), DateTime)
                        .stationName = reader.GetString(_dicFieldsNameToIndex("station_name"))

                        If Not reader.IsDBNull(_dicFieldsNameToIndex("err_message")) Then .errMessage = reader.GetString(_dicFieldsNameToIndex("err_message"))

                        If .errMessage Is Nothing Then
                            If Not reader.IsDBNull(_dicFieldsNameToIndex("serialnumber")) Then .sn = reader.GetString(_dicFieldsNameToIndex("serialnumber"))
                            If Not reader.IsDBNull(_dicFieldsNameToIndex("ram")) Then .ram = CType(reader.GetValue(_dicFieldsNameToIndex("ram")), ULong)
                            If Not reader.IsDBNull(_dicFieldsNameToIndex("osname")) Then .osName = reader.GetString(_dicFieldsNameToIndex("osname"))
                            If Not reader.IsDBNull(_dicFieldsNameToIndex("modele")) Then .modele = reader.GetString(_dicFieldsNameToIndex("modele"))
                            If Not reader.IsDBNull(_dicFieldsNameToIndex("constructeur")) Then .constructeur = reader.GetString(_dicFieldsNameToIndex("constructeur"))
                            If Not reader.IsDBNull(_dicFieldsNameToIndex("socle")) Then .socle = reader.GetString(_dicFieldsNameToIndex("socle"))
                            If Not reader.IsDBNull(_dicFieldsNameToIndex("freespaceondisk")) Then .freeSpaceOnSystemDisk = reader.GetString(_dicFieldsNameToIndex("freespaceondisk"))
                            If Not reader.IsDBNull(_dicFieldsNameToIndex("err_disk")) Then .errDisk = CType(reader.GetValue(_dicFieldsNameToIndex("err_disk")), Integer)
                            If Not reader.IsDBNull(_dicFieldsNameToIndex("driver_predict_fail")) Then .driverPredictFail = CType(reader.GetValue(_dicFieldsNameToIndex("driver_predict_fail")), Integer)
                            If Not reader.IsDBNull(_dicFieldsNameToIndex("err_network")) Then .errNetwork = CType(reader.GetString(_dicFieldsNameToIndex("err_network")), Integer)
                            If Not reader.IsDBNull(_dicFieldsNameToIndex("err_reboot")) Then .errReboot = CType(reader.GetString(_dicFieldsNameToIndex("err_reboot")), Integer)
                            If Not reader.IsDBNull(_dicFieldsNameToIndex("err_bsod")) Then .errBsod = CType(reader.GetString(_dicFieldsNameToIndex("err_bsod")), Integer)
                            If Not reader.IsDBNull(_dicFieldsNameToIndex("hdd_total_space")) Then .hddTotalSpace = CType(reader.GetString(_dicFieldsNameToIndex("hdd_total_space")), Integer)
                            If Not reader.IsDBNull(_dicFieldsNameToIndex("towercase")) Then .towerCase = CType(reader.GetString(_dicFieldsNameToIndex("towercase")), Boolean)
                            If Not reader.IsDBNull(_dicFieldsNameToIndex("deleted")) Then .bdeleted = reader.GetBoolean(_dicFieldsNameToIndex("deleted"))
                        End If
                    End With

                    Return True
                Else ' if reader.hasRow
                    Return False
                End If
            End Using
        Catch ex As Exception
            program.log.addLogEntry(New cLogEntry("Erreur récupération Batch Résult", cLogEntry.enumDebugLevel.ERREUR, stationName, "", ex, False))

            Return False
        End Try

    End Function

End Class
