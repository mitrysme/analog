Imports System.Management

Public Class wmiSmart
    Private _wmiWrapper As cwmi
    Private _stationName As String

    ' cache infos SMART
    Private _hashDriveIdToPNPName As New Hashtable ' cache pour association driveId/PNPName ( k => driveId, v => PNPName )
    Private _hashPNPIdToSmart As New Hashtable ' cache pour association PNPID/SMART ( k=> PNPID, v => SMART)
    Private _hashPNPIdToFailurePredictStatus As New Hashtable '  cache pour association PNPID/FailurePredictStatus ( k=> PNPID, v => FailurePredictStatus(bool) )
    Private _hashErrMessage As New Hashtable ' msgs erreurs pour chaque disque
    Private _hashSmartEnabled As New Hashtable ' smart actif ou pas ( k=> PNPID, v => boolean )
    '
    Private _control As Control
    Private _deg As [Delegate]

    Public ReadOnly Property errorMessage(ByVal driveId As String) As String
        Get
            Dim msg As Object = _hashErrMessage.Item(DiskPNPNameForDriveletter(driveId))
            If Not msg Is Nothing Then
                Return msg.ToString
            Else
                Return String.Empty
            End If
        End Get
    End Property

    'Public ReadOnly Property smartFailurePredictStatus(ByVal driveId As String) As Boolean
    '    Get
    '        Return CType(_hashPNPIdToFailurePredictStatus(DiskPNPNameForDriveletter(driveId)), Boolean)
    '    End Get
    'End Property

    ''' <summary>
    ''' renvoie OK si failurePredictStatus est False KO sinon
    ''' NA si non dispo
    ''' </summary>
    ''' <param name="driveId">Disque à analyser</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property smartFailurePredictStatusAsString(ByVal driveId As String) As String
        Get
            If driveId = "" Or _hashPNPIdToFailurePredictStatus.Count = 0 Then
                Return "NA"
            Else
                Dim o As Object = _hashPNPIdToFailurePredictStatus(DiskPNPNameForDriveletter(driveId))

                If o Is Nothing Then
                    Return "NA"
                Else
                    If CType(_hashPNPIdToFailurePredictStatus(DiskPNPNameForDriveletter(driveId)), Boolean) Then
                        Return "KO"
                    Else
                        Return "OK"
                    End If
                End If
            End If
        End Get
    End Property

    Public Enum enumSmartAttribute As Byte
        RawReadErrorRate = 1
        ThroughputPerformance = 2
        SpinUpTime = 3
        iStopCount = 4
        ReallocatedSectorCount = 5
        ReadChannelMargin = 6
        SeekErrorRate = 7
        SeekTimePerformance = 8
        PowerOnHoursCount = 9
        SpinRetryCount = 10
        CalibrationRetryCount = 11
        PowerCycleCount = 12
        EndtoEndError = 184
        CommandTimeout = 188
        PoweroffRetractCount = 192
        LoadCycleCount = 193
        Temperature = 194
        HardwareECCRecovered = 195
        ReallocationEventCount = 196
        CurrentPendingSectorCount = 197
        OfflineScanUncorrectableSectorCount = 198
        UltraDMACRCErrorCount = 199
        SoftReadErrorRate = 201
        DiskShift = 220
    End Enum

    Public Structure SMARTAttribute
        Public status As Integer
        Public value As Integer
        Public rawvalue As Integer
        Public worst As Integer
        Public threshold As Integer
    End Structure

    Public Structure SMART
        ' nombre de propriétés examinées : 11
        Public RawReadErrorRate As SMARTAttribute
        Public ReallocatedSectorCount As SMARTAttribute
        Public SpinRetryCount As SMARTAttribute
        Public EndToEndError As SMARTAttribute ' 184
        Public CommandTimeout As SMARTAttribute ' 188
        Public HardwareECCRecovered As SMARTAttribute ' 195
        Public ReallocationEventCount As SMARTAttribute ' 196
        Public CurrentPendingSectorCount As SMARTAttribute ' 197 ( probational count dans l'étude GOOGLE ) 
        Public OfflineScanUncorrectableSectorCount As SMARTAttribute ' 198
        Public Temperature As SMARTAttribute
        Public SeekErrorRate As SMARTAttribute
    End Structure

    Public Sub New(ByVal stationName As String)
        _stationName = stationName
        _wmiWrapper = New cwmi(_stationName)
    End Sub

    ''' <summary>
    ''' retourne identifiant PNP du disque physique pour le lecteur passé en paramètre
    ''' </summary>
    ''' <param name="TargetDrive">du genre "c:"</param>
    ''' <returns>[string] PNPName </returns>
    ''' <remarks>Mis en cache dans Hashtable si trouvé</remarks>
    Private Function DiskPNPNameForDriveletter(ByVal TargetDrive As String, Optional ByVal escapeOutputString As Boolean = True) As String
        If _hashDriveIdToPNPName.Contains(TargetDrive) Then
            Return _hashDriveIdToPNPName.Item(TargetDrive).ToString
        End If

        Dim errMessage As String = Nothing
        Dim disks As ManagementObjectCollection = Nothing
        Dim partitions As ManagementObjectCollection = Nothing
        Dim logicalDisks As ManagementObjectCollection = Nothing

        Try
            If _wmiWrapper.connect(errMessage) Then

                _wmiWrapper.getResultsFor(disks, "Win32_DiskDrive", Nothing, New String() {"Caption", "DeviceID", "PNPDeviceID"})

                For Each disk As ManagementObject In disks
                    _wmiWrapper.getRelatedResultsFor(partitions, "Win32_DiskDrive.DeviceID='" & disk.Item("DeviceID").ToString & "'", "Win32_DiskDriveToDiskPartition")

                    For Each partition As ManagementObject In partitions
                        _wmiWrapper.getRelatedResultsFor(logicalDisks, "Win32_DiskPartition.DeviceID='" & partition.Item("DeviceID").ToString & "'", "Win32_LogicalDiskToPartition")

                        For Each logicalDisk As ManagementObject In logicalDisks
                            If TargetDrive.Substring(0, 1) = logicalDisk.Item("DeviceID").ToString.Substring(0, 1) Then
                                Dim PNPDeviceId As String = disk.Item("PNPDEviceId").ToString

                                ' echappement nécessaire pour utilisation dans requete WQL 
                                If escapeOutputString Then
                                    PNPDeviceId = PNPDeviceId.Replace("\", "\\")
                                End If

                                _hashDriveIdToPNPName.Add(TargetDrive, PNPDeviceId)
                                Return PNPDeviceId
                            End If
                        Next
                    Next
                Next
            End If
        Finally
            If Not disks Is Nothing Then disks.Dispose()
            If Not partitions Is Nothing Then partitions.Dispose()
            If Not logicalDisks Is Nothing Then logicalDisks.Dispose()
        End Try

        Return Nothing ' berk
    End Function

    ''' <summary>
    ''' Mets à jour le listView
    ''' </summary>
    ''' <param name="_deg"></param>
    ''' <param name="smart"></param>
    ''' <param name="errMessage"></param>
    ''' <remarks></remarks>
    Private Sub updateControl(ByVal _deg As [Delegate], ByVal smart As SMART, ByVal errMessage As String)
        If _control IsNot Nothing Then
            If _control.Created AndAlso Not _control.Disposing Then
                _control.Invoke(_deg, smart, errMessage)
            End If
        End If
    End Sub

    Private Function setSmartfailurePredictStatus(ByVal targetDrive As String, _
                                                  ByVal PNPDeviceId As String, _
                                                  ByRef bSMARTPredictStatus As Boolean) As Boolean

        ' Dim PNPDeviceId As String = DiskPNPNameForDriveletter(targetDrive)
        Dim mocSmartFailurePredictStatus As ManagementObjectCollection = Nothing
        Dim moPredictStatus As ManagementObject = Nothing

        Try
            Dim errMessage As String = ""
            If _wmiWrapper.connect(errMessage, "\root\wmi") Then
                If _wmiWrapper.getResultsFor(mocSmartFailurePredictStatus, "MSStorageDriver_FailurePredictStatus", "instanceName like '%" & PNPDeviceId & "%'", New String() {"PredictFailure"}) Then
                    If mocSmartFailurePredictStatus IsNot Nothing Then
                        moPredictStatus = CType(mocSmartFailurePredictStatus(0), ManagementObject)
                        bSMARTPredictStatus = CType(moPredictStatus.Item("PredictFailure"), Boolean)
                    End If
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            program.log.addLogEntry(New cLogEntry("Impossible de déterminer status SMART", cLogEntry.enumDebugLevel.ERREUR, _stationName, "", ex, False))

            Return False
        Finally
            If Not moPredictStatus Is Nothing Then moPredictStatus.Dispose()
            If Not mocSmartFailurePredictStatus Is Nothing Then mocSmartFailurePredictStatus.Dispose()
        End Try

        Return True
    End Function

    Public Function setSmartfailurePredictStatus(ByVal targetDrive As Object) As Boolean

        Dim sTargetDrive As String = CStr(targetDrive)
        Dim PNPDeviceId As String = DiskPNPNameForDriveletter(targetDrive.ToString)
        Dim bSMARTFailurePredict As Boolean

        If setSmartfailurePredictStatus(sTargetDrive, PNPDeviceId, bSMARTFailurePredict) Then
            _hashPNPIdToFailurePredictStatus.Add(PNPDeviceId, bSMARTFailurePredict)
        End If
    End Function

    Private Function setSmartThresholdValues(ByVal targetDrive As String, _
                                             ByVal PNPDeviceId As String, _
                                             ByRef baSMARTThresholvalues As Byte()) As Boolean

        Dim mocSmartThreshold As ManagementObjectCollection = Nothing
        'Dim PNPDeviceId As String = DiskPNPNameForDriveletter(targetDrive)

        If _wmiWrapper.getResultsFor(mocSmartThreshold, "MSStorageDriver_FailurePredictThresholds", "instanceName like '%" & PNPDeviceId & "%'", Nothing) Then
            If mocSmartThreshold IsNot Nothing Then
                Dim mo As ManagementObject = CType(mocSmartThreshold(0), ManagementObject)
                baSMARTThresholvalues = CType(mo.Properties("vendorSpecific").Value, Byte())

                mocSmartThreshold.Dispose()
                mo.Dispose()
            End If

            Return True
        End If

        Return False
    End Function

    Private Function setSMARTData(ByVal targetdrive As String, _
                                  ByVal PNPDeviceId As String, _
                                  ByRef baSMARTData As Byte(), _
                                  ByRef bSMARTActive As Boolean) As Boolean

        Dim mocSMARTData As ManagementObjectCollection = Nothing
        Dim mo As ManagementObject = Nothing

        Try
            If _wmiWrapper.getResultsFor(mocSMARTData, "MSStorageDriver_FailurePredictData", "instanceName like '%" & PNPDeviceId & "%'", Nothing) Then
                If mocSMARTData IsNot Nothing Then
                    mo = CType(mocSMARTData(0), ManagementObject)

                    baSMARTData = CType(mo.Properties("vendorSpecific").Value, Byte())
                    bSMARTActive = CType(mo.Properties("active").Value, Boolean)
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            If Not mo Is Nothing Then mo.Dispose()
            If Not mocSMARTData Is Nothing Then mocSMARTData.Dispose()
        End Try
 
        Return True
    End Function

    Public Sub updateSmartLvAsyncThreadWork(ByVal driveId As Object)
        Dim errMessage As String = String.Empty

        Dim smart As SMART = setSMARTInfos(driveId, errMessage)

        If _control IsNot Nothing Then
            If _control.Created AndAlso Not _control.Disposing Then
                _control.Invoke(_deg, smart, errMessage)
            End If
        End If

        '_control.Invoke(_deg, smart, errMessage)
    End Sub

    Public Sub updateSmartLvAsync(ByVal control As Control, ByVal deg As [Delegate], ByVal driveId As String)
        _control = control
        _deg = deg

        Threading.ThreadPool.QueueUserWorkItem(AddressOf updateSmartLvAsyncThreadWork, driveId)
    End Sub

    Private Function setSMARTInfos(ByVal targetDrive As Object, _
                                   ByRef errMessage As String) As SMART

        Dim sTargetDrive As String = CStr(targetDrive)
        Dim PNPDeviceId As String = DiskPNPNameForDriveletter(targetDrive.ToString)
        Dim structSMART As SMART = Nothing

        Dim bSMARTActive As Boolean
        Dim baSMARTThresholvalues As Byte() = Nothing
        Dim baSMARTData As Byte() = Nothing

        If _wmiWrapper.connect(errMessage, "\root\wmi") Then
            If setSMARTData(sTargetDrive, PNPDeviceId, baSMARTData, bSMARTActive) Then
                If bSMARTActive Then
                    If setSmartThresholdValues(sTargetDrive, PNPDeviceId, baSMARTThresholvalues) Then
                        structSMART = getSMARTAsStruct(baSMARTData, baSMARTThresholvalues)
                    Else
                        errMessage = "Impossible de récupérer valeurs Thresholds SMART"
                    End If

                    If Not _hashPNPIdToFailurePredictStatus.ContainsKey(PNPDeviceId) Then
                        setSmartfailurePredictStatus(targetDrive)
                    End If

                Else ' 
                    errMessage = "SMART non actif"
                End If
            Else
                errMessage = "Impossible de récupérer données SMART"
            End If
        End If

        Return structSMART

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="baSMARTData"></param>
    ''' <param name="baSMARTThresholvalues"></param>
    ''' <returns></returns>
    ''' <remarks>
    '''  La valeur Raw devrait être égale à :CInt(smartData(i + 5)) + 256 * CInt(smartData(i + 6)))  
    '''  ne semble pas juste pour tous les disques ( obtient pas les mêmes résultats que HDTUNE )
    ''' ... calcul différent en fonction du constructeur ?
    ''' </remarks>
    Private Function getSMARTAsStruct(ByVal baSMARTData As Byte(), _
                                      ByVal baSMARTThresholvalues As Byte()) As SMART

        Dim smart As New SMART

        Dim i As Integer = 0

        For i = 2 To 199 Step 12
            Select Case baSMARTData(i) ' SMART attribute
                Case enumSmartAttribute.RawReadErrorRate '1
                    smart.RawReadErrorRate.value = baSMARTData(i + 3)
                    smart.RawReadErrorRate.worst = baSMARTData(i + 4)
                    smart.RawReadErrorRate.threshold = baSMARTThresholvalues(i + 1)
                Case enumSmartAttribute.ReallocatedSectorCount '5
                    smart.ReallocatedSectorCount.value = baSMARTData(i + 3)
                    smart.ReallocatedSectorCount.worst = baSMARTData(i + 4)
                    smart.ReallocatedSectorCount.threshold = baSMARTThresholvalues(i + 1)
                Case enumSmartAttribute.SeekErrorRate ' 7
                    smart.SeekErrorRate.value = baSMARTData(i + 3)
                    smart.SeekErrorRate.worst = baSMARTData(i + 4)
                    smart.SeekErrorRate.threshold = baSMARTThresholvalues(i + 1)
                Case enumSmartAttribute.SpinRetryCount '10
                    smart.SpinRetryCount.value = baSMARTData(i + 3)
                    smart.SpinRetryCount.worst = baSMARTData(i + 4)
                    smart.SpinRetryCount.threshold = baSMARTThresholvalues(i + 1)
                Case enumSmartAttribute.EndtoEndError ' 184
                    smart.EndToEndError.value = baSMARTData(i + 3)
                    smart.EndToEndError.worst = baSMARTData(i + 4)
                    smart.EndToEndError.threshold = baSMARTThresholvalues(i + 1)
                Case enumSmartAttribute.CommandTimeout '188
                    smart.CommandTimeout.value = baSMARTData(i + 3)
                    smart.CommandTimeout.worst = baSMARTData(i + 4)
                    smart.CommandTimeout.threshold = baSMARTThresholvalues(i + 1)
                Case enumSmartAttribute.Temperature '194
                    smart.Temperature.value = baSMARTData(i + 3)
                    smart.Temperature.worst = baSMARTData(i + 4)
                    smart.Temperature.threshold = baSMARTThresholvalues(i + 1)
                Case enumSmartAttribute.HardwareECCRecovered '195
                    smart.HardwareECCRecovered.value = baSMARTData(i + 3)
                    smart.HardwareECCRecovered.worst = baSMARTData(i + 4)
                    smart.HardwareECCRecovered.threshold = baSMARTThresholvalues(i + 1)
                Case enumSmartAttribute.ReallocationEventCount ' 196
                    smart.ReallocationEventCount.value = baSMARTData(i + 3)
                    smart.ReallocationEventCount.worst = baSMARTData(i + 4)
                    smart.ReallocationEventCount.threshold = baSMARTThresholvalues(i + 1)
                Case enumSmartAttribute.CurrentPendingSectorCount ' 197
                    smart.CurrentPendingSectorCount.value = baSMARTData(i + 3)
                    smart.CurrentPendingSectorCount.worst = baSMARTData(i + 4)
                    smart.CurrentPendingSectorCount.threshold = baSMARTThresholvalues(i + 1)
                Case enumSmartAttribute.OfflineScanUncorrectableSectorCount ' 198
                    smart.OfflineScanUncorrectableSectorCount.value = baSMARTData(i + 3)
                    smart.OfflineScanUncorrectableSectorCount.worst = baSMARTData(i + 4)
                    smart.OfflineScanUncorrectableSectorCount.threshold = baSMARTThresholvalues(i + 1)
            End Select
        Next

        Return smart
    End Function
End Class
