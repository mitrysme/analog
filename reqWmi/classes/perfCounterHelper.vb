Public Class perfCounterHelper

    Public Shared Function getProcessorValue(ByRef performanceCounter As PerformanceCounter, ByVal stationName As String) As Single
        Return getCounterValue(performanceCounter, "Processor", "% Processor Time", "_Total", stationName)
    End Function

    Public Shared Function getMemoryAvailableBytes(ByRef performanceCounter As PerformanceCounter, _
                                                   ByVal stationName As String) As Single
        Return getCounterValue(performanceCounter, "Memory", "Available Bytes", Nothing, stationName)
    End Function

    Public Shared Function getNetworkBytesReceivedSec(ByRef performanceCounter As PerformanceCounter, _
                                                      ByVal stationName As String, _
                                                      ByVal instanceName As String) As Single

        Return getCounterValue(performanceCounter, "Network Interface", "Bytes Received/sec", instanceName, stationName)
    End Function

    Public Shared Function getNetworkBytesSentSec(ByRef performanceCounter As PerformanceCounter, _
                                                     ByVal stationName As String, _
                                                     ByVal instanceName As String) As Single

        Return getCounterValue(performanceCounter, "Network Interface", "Bytes Sent/sec", instanceName, stationName)
    End Function

    Public Shared Function getDiskTransfersSec(ByRef PerformanceCounter As PerformanceCounter, _
                                               ByVal stationName As String, _
                                               ByVal instanceName As String) As Single

        Return getCounterValue(PerformanceCounter, "LogicalDisk", "Disk Transfers/sec", "_Total", stationName)
    End Function

    Public Shared Function getDiskBytesReadSec(ByRef performanceCounter As PerformanceCounter, _
                                               ByVal stationName As String, _
                                               ByVal instanceName As String) As Single

        Return getCounterValue(performanceCounter, "LogicalDisk", "Disk Read Bytes/sec", "_Total", stationName)
    End Function

    Public Shared Function getNetworkInterfaceCurrentBandwith(ByRef performanceCounteras As PerformanceCounter, _
                                                              ByVal stationName As String, _
                                                              ByVal instanceName As String) As Single


    End Function

    Public Shared Function getDiskBytesWriteSec(ByRef performanceCounter As PerformanceCounter, _
                                               ByVal stationName As String, _
                                               ByVal instanceName As String) As Single

        Return getCounterValue(performanceCounter, "LogicalDisk", "Disk Write Bytes/sec", "_Total", stationName)
    End Function


    ''' <summary>
    ''' retourne pourcentage libre mémoire
    ''' </summary>
    ''' <param name="totalPhysicalMemory">total mémoire sur la station</param>
    ''' <param name="memoryAvailableBytes">mémoire libre</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getFreeMemoryAsPercentage(ByVal totalPhysicalMemory As Single, _
                                                     ByVal memoryAvailableBytes As Single) As Single

        Dim r As Single = totalPhysicalMemory - memoryAvailableBytes
        r /= totalPhysicalMemory
        r *= 100

        Return r

    End Function

    Public Enum Units
        B
        KB
        MB
        GB
        ER
    End Enum

    Public Shared Function formatBytes(ByVal bytes As Single) As String

        Dim unit As Integer = 0
        While bytes > 1024
            bytes /= 1024
            unit += 1
        End While

        Dim s As String = CStr(Math.Round(bytes, 2))
        Dim sUnit As String = CType(unit, Units).ToString
        Dim res = String.Format("{0} {1}", s, sUnit)

        Return res

    End Function


    ''' <summary>
    ''' TODO : désactiver compteur si echec récupération value > n fois 
    ''' sur  P81AOPH124 le compteur network IO semble ne pas exister wmi corrompu ??? 
    ''' les autres compteurs fonctionnent, il faudrait pouvoir désactiver les compteurs séparément .... implémenter disconnect() ??
    ''' pas la peine de s'obstiner si le compteur n'existe pas etc ... ( exception " la catégorie n'existe pas )
    ''' </summary>
    ''' <param name="pc"></param>
    ''' <param name="categoryName"></param>
    ''' <param name="counterName"></param>
    ''' <param name="instanceName"></param>
    ''' <param name="stationName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getCounterValue(ByRef pc As PerformanceCounter, _
                               ByVal categoryName As String, _
                               ByVal counterName As String, _
                               ByVal instanceName As String, _
                               ByVal stationName As String) As Single

        With pc
            .CategoryName = categoryName
            .CounterName = counterName
            .InstanceName = instanceName
            .MachineName = stationName
        End With
    
        Return pc.NextValue

    End Function

End Class
