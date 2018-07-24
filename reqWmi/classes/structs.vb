Imports System.Runtime.InteropServices ' pour marshalAS

Namespace structs
    Public Class analogStructs


        Public Structure BatchResult
            Public dateScan As DateTime
            Public stationName As String
            Public modele As String
            Public constructeur As String
            Public osName As String
            Public sn As String
            Public ram As ULong
            Public errDisk As Nullable(Of Integer)
            Public driverPredictFail As Nullable(Of Integer)
            Public errNetwork As Nullable(Of Integer)
            Public errReboot As Nullable(Of Integer)
            Public errBsod As Nullable(Of Integer)
            Public socle As String
            Public freeSpaceOnSystemDisk As String
            Public errMessage As String
            Public listMonitorEdidInfo As List(Of cMonitorInfo.monitorEdidInfo)
            Public smartStatus As String
            Public towerCase As Boolean ' vrai si boitier tour ML450/VL350
            Public hddTotalSpace As Integer
            Public bdeleted As Boolean

            Public Sub New(ByRef station As cstation)
                With station
                    Dim systemLogErrorCount = station.ntSystemLog.getNtSystemLogErrorCount(station.gInfoStation.OsInstallDevice)

                    dateScan = .dateScan
                    stationName = .stationName
                    modele = .gInfoStation.model
                    constructeur = .gInfoStation.manufacturer
                    osName = .gInfoStation.operatingSystem
                    sn = .gInfoStation.serialNumber
                    ram = .gInfoStation.totalPhysicalMemory
                    errDisk = systemLogErrorCount.iNumDiskBlockErrorOnSystemDisk
                    driverPredictFail = systemLogErrorCount.iNumDiskPredictFail
                    errNetwork = systemLogErrorCount.iNumNetworkError
                    errReboot = systemLogErrorCount.iNumShutdownError
                    errBsod = systemLogErrorCount.iNumBsobError
                    socle = station.socle
                    freeSpaceOnSystemDisk = CType(station.freeSpaceOnSystemDisk, String)
                    errMessage = station.errorMessage
                    smartStatus = .smart.smartFailurePredictStatusAsString(.gInfoStation.systemDrive)
                    towerCase = .gInfoStation.towercase
                End With
            End Sub
        End Structure

        Public Structure optionScan
            Public nbErrDisk As Boolean
            Public nbErrNetowrk As Boolean
            Public nbErrShutdown As Boolean
            Public statdisk As Boolean
        End Structure

        Public Structure favoris
            Public stationName As String
            Public note As String
        End Structure

        'YAPM
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure SHFileInfo
            Public hIcon As IntPtr            ' : icon
            Public iIcon As IntPtr            ' : icondex
            Public dwAttributes As Integer    ' : SFGAO_ flags
            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
            Public szDisplayName As String
            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
            Public szTypeName As String
        End Structure

        Public Structure StructLdapUser
            Public userPrincipal As String
            Public description As String
            Public givenName As String
            Public name As String
            Public mail As String
            Public displayName As String
            Public sn As String ' surname => nom
            Public lastLogonDate As String
            Public lastLogonTime As String
            Public pwdLastSetDate As String
            Public pwdLastSetTime As String
            Public LogonScriptPath As String
            Public SID As String
            Public accountDisabled As Boolean
            Public pwdExpired As Boolean
            Public pwdNeverExpire As Boolean
            Public cannotChangePassword As Boolean
            Public blockedAccount As Boolean
        End Structure
    End Class
End Namespace