Namespace AnalogEnums
    Public Class enums

        ' propriétés classe WMI Win32_Process
        Public Enum WmiInfoProcess
            'Caption
            CommandLine
            'CreationClassName
            CreationDate
            'CSCreationClassName
            'CSName
            'Description
            ExecutablePath
            'ExecutionState
            'Handle
            HandleCount
            'InstallDate
            KernelModeTime
            MaximumWorkingSetSize
            MinimumWorkingSetSize
            Name
            'OSCreationClassName
            'OSName
            OtherOperationCount
            OtherTransferCount
            PageFaults
            PageFileUsage
            ParentProcessId
            PeakPageFileUsage
            PeakVirtualSize
            PeakWorkingSetSize
            Priority
            PrivatePageCount
            ProcessId
            QuotaNonPagedPoolUsage
            QuotaPagedPoolUsage
            QuotaPeakNonPagedPoolUsage
            QuotaPeakPagedPoolUsage
            ReadOperationCount
            ReadTransferCount
            'SessionId
            'Status
            TerminationDate
            ThreadCount
            UserModeTime
            VirtualSize
            WindowsVersion
            WorkingSetSize
            WriteOperationCount
            WriteTransferCount
        End Enum

        Public Enum WmiProcessReturnCode
            SuccessfulCompletion = 0
            AccessDenied = 2
            InsufficientPrivilege = 3
            UnknownFailure = 8
            PathNotFound = 9
            InvalidParameter = 21
        End Enum

        ''' <summary>
        ''' Code Retour Wmi service.invokeMethod
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum WmiServiceReturnCode
            Success = 0
            NotSupported = 1
            AccessDenied = 2
            DependentServicesRunning = 3
            InvalidServiceControl = 4
            ServiceCannotAcceptControl = 5
            ServiceNotActive = 6
            ServiceRequestTimeout = 7
            UnknownFailure = 8
            PathNotFound = 9
            ServiceAlreadyRunning = 10
            ServiceDatabaseLocked = 11
            ServiceDependencyDeleted = 12
            ServiceDependencyFailure = 13
            ServiceDisabled = 14
            ServiceLogonFailure = 15
            ServiceMarkedForDeletion = 16
            ServiceNoThread = 17
            StatusCircularDependency = 18
            StatusDuplicateName = 19
            StatusInvalidName = 20
            StatusInvalidParameter = 21
            StatusInvalidServiceAccount = 22
            StatusServiceExists = 23
            ServiceAlreadyPaused = 24
        End Enum
    End Class
End Namespace
