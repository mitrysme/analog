Namespace wmi

    Public Class Win32_DiskDrive
        Private m_Availability As UShort

        Private m_BytesPerSector As UInteger

        Private m_Capabilities As UShort()

        Private m_CapabilityDescriptions As String()

        Private m_Caption As String

        Private m_CompressionMethod As String

        Private m_ConfigManagerErrorCode As UInteger

        Private m_ConfigManagerUserConfig As Boolean

        Private m_CreationClassName As String

        Private m_DefaultBlockSize As ULong

        Private m_Description As String

        Private m_DeviceID As String

        Private m_ErrorCleared As Boolean

        Private m_ErrorDescription As String

        Private m_ErrorMethodology As String

        Private m_FirmwareRevision As String

        Private m_Index As UInteger

        Private m_InstallDate As String

        Private m_InterfaceType As String

        Private m_LastErrorCode As UInteger

        Private m_Manufacturer As String

        Private m_MaxBlockSize As ULong

        Private m_MaxMediaSize As ULong

        Private m_MediaLoaded As Boolean

        Private m_MediaType As String

        Private m_MinBlockSize As ULong

        Private m_Model As String

        Private m_Name As String

        Private m_NeedsCleaning As Boolean

        Private m_NumberOfMediaSupported As UInteger

        Private m_Partitions As UInteger

        Private m_PNPDeviceID As String

        Private m_PowerManagementCapabilities As UShort()

        Private m_PowerManagementSupported As Boolean

        Private m_SCSIBus As UInteger

        Private m_SCSILogicalUnit As UShort

        Private m_SCSIPort As UShort

        Private m_SCSITargetId As UShort

        Private m_SectorsPerTrack As UInteger

        Private m_SerialNumber As String

        Private m_Signature As UInteger

        Private m_Size As ULong

        Private m_Status As String

        Private m_StatusInfo As UShort

        Private m_SystemCreationClassName As String

        Private m_SystemName As String

        Private m_TotalCylinders As ULong

        Private m_TotalHeads As UInteger

        Private m_TotalSectors As ULong

        Private m_TotalTracks As ULong

        Private m_TracksPerCylinder As UInteger

        Private m_MyPath As String

        Public Sub New()
        End Sub

        Public Property Availability() As UShort
            Get
                Return Me.m_Availability
            End Get
            Set(ByVal value As UShort)
                Me.m_Availability = value
            End Set
        End Property

        Public Property BytesPerSector() As UInteger
            Get
                Return Me.m_BytesPerSector
            End Get
            Set(ByVal value As UInteger)
                Me.m_BytesPerSector = value
            End Set
        End Property

        Public Property Capabilities() As UShort()
            Get
                Return Me.m_Capabilities
            End Get
            Set(ByVal value As UShort())
                Me.m_Capabilities = value
            End Set
        End Property

        Public Property CapabilityDescriptions() As String()
            Get
                Return Me.m_CapabilityDescriptions
            End Get
            Set(ByVal value As String())
                Me.m_CapabilityDescriptions = value
            End Set
        End Property

        Public Property Caption() As String
            Get
                Return Me.m_Caption
            End Get
            Set(ByVal value As String)
                Me.m_Caption = value
            End Set
        End Property

        Public Property CompressionMethod() As String
            Get
                Return Me.m_CompressionMethod
            End Get
            Set(ByVal value As String)
                Me.m_CompressionMethod = value
            End Set
        End Property

        Public Property ConfigManagerErrorCode() As UInteger
            Get
                Return Me.m_ConfigManagerErrorCode
            End Get
            Set(ByVal value As UInteger)
                Me.m_ConfigManagerErrorCode = value
            End Set
        End Property

        Public Property ConfigManagerUserConfig() As Boolean
            Get
                Return Me.m_ConfigManagerUserConfig
            End Get
            Set(ByVal value As Boolean)
                Me.m_ConfigManagerUserConfig = value
            End Set
        End Property

        Public Property CreationClassName() As String
            Get
                Return Me.m_CreationClassName
            End Get
            Set(ByVal value As String)
                Me.m_CreationClassName = value
            End Set
        End Property

        Public Property DefaultBlockSize() As ULong
            Get
                Return Me.m_DefaultBlockSize
            End Get
            Set(ByVal value As ULong)
                Me.m_DefaultBlockSize = value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return Me.m_Description
            End Get
            Set(ByVal value As String)
                Me.m_Description = value
            End Set
        End Property

        Public Property DeviceID() As String
            Get
                Return Me.m_DeviceID
            End Get
            Set(ByVal value As String)
                Me.m_DeviceID = value
            End Set
        End Property

        Public Property ErrorCleared() As Boolean
            Get
                Return Me.m_ErrorCleared
            End Get
            Set(ByVal value As Boolean)
                Me.m_ErrorCleared = value
            End Set
        End Property

        Public Property ErrorDescription() As String
            Get
                Return Me.m_ErrorDescription
            End Get
            Set(ByVal value As String)
                Me.m_ErrorDescription = value
            End Set
        End Property

        Public Property ErrorMethodology() As String
            Get
                Return Me.m_ErrorMethodology
            End Get
            Set(ByVal value As String)
                Me.m_ErrorMethodology = value
            End Set
        End Property

        Public Property FirmwareRevision() As String
            Get
                Return Me.m_FirmwareRevision
            End Get
            Set(ByVal value As String)
                Me.m_FirmwareRevision = value
            End Set
        End Property

        Public Property Index() As UInteger
            Get
                Return Me.m_Index
            End Get
            Set(ByVal value As UInteger)
                Me.m_Index = value
            End Set
        End Property

        Public Property InstallDate() As String
            Get
                Return Me.m_InstallDate
            End Get
            Set(ByVal value As String)
                Me.m_InstallDate = value
            End Set
        End Property

        Public Property InterfaceType() As String
            Get
                Return Me.m_InterfaceType
            End Get
            Set(ByVal value As String)
                Me.m_InterfaceType = value
            End Set
        End Property

        Public Property LastErrorCode() As UInteger
            Get
                Return Me.m_LastErrorCode
            End Get
            Set(ByVal value As UInteger)
                Me.m_LastErrorCode = value
            End Set
        End Property

        Public Property Manufacturer() As String
            Get
                Return Me.m_Manufacturer
            End Get
            Set(ByVal value As String)
                Me.m_Manufacturer = value
            End Set
        End Property

        Public Property MaxBlockSize() As ULong
            Get
                Return Me.m_MaxBlockSize
            End Get
            Set(ByVal value As ULong)
                Me.m_MaxBlockSize = value
            End Set
        End Property

        Public Property MaxMediaSize() As ULong
            Get
                Return Me.m_MaxMediaSize
            End Get
            Set(ByVal value As ULong)
                Me.m_MaxMediaSize = value
            End Set
        End Property

        Public Property MediaLoaded() As Boolean
            Get
                Return Me.m_MediaLoaded
            End Get
            Set(ByVal value As Boolean)
                Me.m_MediaLoaded = value
            End Set
        End Property

        Public Property MediaType() As String
            Get
                Return Me.m_MediaType
            End Get
            Set(ByVal value As String)
                Me.m_MediaType = value
            End Set
        End Property

        Public Property MinBlockSize() As ULong
            Get
                Return Me.m_MinBlockSize
            End Get
            Set(ByVal value As ULong)
                Me.m_MinBlockSize = value
            End Set
        End Property

        Public Property Model() As String
            Get
                Return Me.m_Model
            End Get
            Set(ByVal value As String)
                Me.m_Model = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return Me.m_Name
            End Get
            Set(ByVal value As String)
                Me.m_Name = value
            End Set
        End Property

        Public Property NeedsCleaning() As Boolean
            Get
                Return Me.m_NeedsCleaning
            End Get
            Set(ByVal value As Boolean)
                Me.m_NeedsCleaning = value
            End Set
        End Property

        Public Property NumberOfMediaSupported() As UInteger
            Get
                Return Me.m_NumberOfMediaSupported
            End Get
            Set(ByVal value As UInteger)
                Me.m_NumberOfMediaSupported = value
            End Set
        End Property

        Public Property Partitions() As UInteger
            Get
                Return Me.m_Partitions
            End Get
            Set(ByVal value As UInteger)
                Me.m_Partitions = value
            End Set
        End Property

        Public Property PNPDeviceID() As String
            Get
                Return Me.m_PNPDeviceID
            End Get
            Set(ByVal value As String)
                Me.m_PNPDeviceID = value
            End Set
        End Property

        Public Property PowerManagementCapabilities() As UShort()
            Get
                Return Me.m_PowerManagementCapabilities
            End Get
            Set(ByVal value As UShort())
                Me.m_PowerManagementCapabilities = value
            End Set
        End Property

        Public Property PowerManagementSupported() As Boolean
            Get
                Return Me.m_PowerManagementSupported
            End Get
            Set(ByVal value As Boolean)
                Me.m_PowerManagementSupported = value
            End Set
        End Property

        Public Property SCSIBus() As UInteger
            Get
                Return Me.m_SCSIBus
            End Get
            Set(ByVal value As UInteger)
                Me.m_SCSIBus = value
            End Set
        End Property

        Public Property SCSILogicalUnit() As UShort
            Get
                Return Me.m_SCSILogicalUnit
            End Get
            Set(ByVal value As UShort)
                Me.m_SCSILogicalUnit = value
            End Set
        End Property

        Public Property SCSIPort() As UShort
            Get
                Return Me.m_SCSIPort
            End Get
            Set(ByVal value As UShort)
                Me.m_SCSIPort = value
            End Set
        End Property

        Public Property SCSITargetId() As UShort
            Get
                Return Me.m_SCSITargetId
            End Get
            Set(ByVal value As UShort)
                Me.m_SCSITargetId = value
            End Set
        End Property

        Public Property SectorsPerTrack() As UInteger
            Get
                Return Me.m_SectorsPerTrack
            End Get
            Set(ByVal value As UInteger)
                Me.m_SectorsPerTrack = value
            End Set
        End Property

        Public Property SerialNumber() As String
            Get
                Return Me.m_SerialNumber
            End Get
            Set(ByVal value As String)
                Me.m_SerialNumber = value
            End Set
        End Property

        Public Property Signature() As UInteger
            Get
                Return Me.m_Signature
            End Get
            Set(ByVal value As UInteger)
                Me.m_Signature = value
            End Set
        End Property

        Public Property Size() As ULong
            Get
                Return Me.m_Size
            End Get
            Set(ByVal value As ULong)
                Me.m_Size = value
            End Set
        End Property

        Public Property Status() As String
            Get
                Return Me.m_Status
            End Get
            Set(ByVal value As String)
                Me.m_Status = value
            End Set
        End Property

        Public Property StatusInfo() As UShort
            Get
                Return Me.m_StatusInfo
            End Get
            Set(ByVal value As UShort)
                Me.m_StatusInfo = value
            End Set
        End Property

        Public Property SystemCreationClassName() As String
            Get
                Return Me.m_SystemCreationClassName
            End Get
            Set(ByVal value As String)
                Me.m_SystemCreationClassName = value
            End Set
        End Property

        Public Property SystemName() As String
            Get
                Return Me.m_SystemName
            End Get
            Set(ByVal value As String)
                Me.m_SystemName = value
            End Set
        End Property

        Public Property TotalCylinders() As ULong
            Get
                Return Me.m_TotalCylinders
            End Get
            Set(ByVal value As ULong)
                Me.m_TotalCylinders = value
            End Set
        End Property

        Public Property TotalHeads() As UInteger
            Get
                Return Me.m_TotalHeads
            End Get
            Set(ByVal value As UInteger)
                Me.m_TotalHeads = value
            End Set
        End Property

        Public Property TotalSectors() As ULong
            Get
                Return Me.m_TotalSectors
            End Get
            Set(ByVal value As ULong)
                Me.m_TotalSectors = value
            End Set
        End Property

        Public Property TotalTracks() As ULong
            Get
                Return Me.m_TotalTracks
            End Get
            Set(ByVal value As ULong)
                Me.m_TotalTracks = value
            End Set
        End Property

        Public Property TracksPerCylinder() As UInteger
            Get
                Return Me.m_TracksPerCylinder
            End Get
            Set(ByVal value As UInteger)
                Me.m_TracksPerCylinder = value
            End Set
        End Property

        Public Property MyPath() As String
            Get
                Return Me.m_MyPath
            End Get
            Set(ByVal value As String)
                Me.m_MyPath = value
            End Set
        End Property
    End Class

End Namespace
