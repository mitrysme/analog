Namespace wmi

    Public Class Win32_LogicalDisk
        Private m_Access As UShort

        Private m_Availability As UShort

        Private m_BlockSize As ULong

        Private m_Caption As String

        Private m_Compressed As Boolean

        Private m_ConfigManagerErrorCode As UInteger

        Private m_ConfigManagerUserConfig As Boolean

        Private m_CreationClassName As String

        Private m_Description As String

        Private m_DeviceID As String

        Private m_DriveType As UInteger

        Private m_ErrorCleared As Boolean

        Private m_ErrorDescription As String

        Private m_ErrorMethodology As String

        Private m_FileSystem As String

        Private m_FreeSpace As ULong

        Private m_InstallDate As String

        Private m_LastErrorCode As UInteger

        Private m_MaximumComponentLength As UInteger

        Private m_MediaType As UInteger

        Private m_Name As String

        Private m_NumberOfBlocks As ULong

        Private m_PNPDeviceID As String

        Private m_PowerManagementCapabilities As UShort()

        Private m_PowerManagementSupported As Boolean

        Private m_ProviderName As String

        Private m_Purpose As String

        Private m_QuotasDisabled As Boolean

        Private m_QuotasIncomplete As Boolean

        Private m_QuotasRebuilding As Boolean

        Private m_Size As ULong

        Private m_Status As String

        Private m_StatusInfo As UShort

        Private m_SupportsDiskQuotas As Boolean

        Private m_SupportsFileBasedCompression As Boolean

        Private m_SystemCreationClassName As String

        Private m_SystemName As String

        Private m_VolumeDirty As Boolean

        Private m_VolumeName As String

        Private m_VolumeSerialNumber As String

        Private m_MyPath As String

        Public Sub New()
        End Sub

        Public Property Access() As UShort
            Get
                Return Me.m_Access
            End Get
            Set(ByVal value As UShort)
                Me.m_Access = value
            End Set
        End Property

        Public Property Availability() As UShort
            Get
                Return Me.m_Availability
            End Get
            Set(ByVal value As UShort)
                Me.m_Availability = value
            End Set
        End Property

        Public Property BlockSize() As ULong
            Get
                Return Me.m_BlockSize
            End Get
            Set(ByVal value As ULong)
                Me.m_BlockSize = value
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

        Public Property Compressed() As Boolean
            Get
                Return Me.m_Compressed
            End Get
            Set(ByVal value As Boolean)
                Me.m_Compressed = value
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

        Public Property DriveType() As UInteger
            Get
                Return Me.m_DriveType
            End Get
            Set(ByVal value As UInteger)
                Me.m_DriveType = value
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

        Public Property FileSystem() As String
            Get
                Return Me.m_FileSystem
            End Get
            Set(ByVal value As String)
                Me.m_FileSystem = value
            End Set
        End Property

        Public Property FreeSpace() As ULong
            Get
                Return Me.m_FreeSpace
            End Get
            Set(ByVal value As ULong)
                Me.m_FreeSpace = value
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

        Public Property LastErrorCode() As UInteger
            Get
                Return Me.m_LastErrorCode
            End Get
            Set(ByVal value As UInteger)
                Me.m_LastErrorCode = value
            End Set
        End Property

        Public Property MaximumComponentLength() As UInteger
            Get
                Return Me.m_MaximumComponentLength
            End Get
            Set(ByVal value As UInteger)
                Me.m_MaximumComponentLength = value
            End Set
        End Property

        Public Property MediaType() As UInteger
            Get
                Return Me.m_MediaType
            End Get
            Set(ByVal value As UInteger)
                Me.m_MediaType = value
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

        Public Property NumberOfBlocks() As ULong
            Get
                Return Me.m_NumberOfBlocks
            End Get
            Set(ByVal value As ULong)
                Me.m_NumberOfBlocks = value
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

        Public Property ProviderName() As String
            Get
                Return Me.m_ProviderName
            End Get
            Set(ByVal value As String)
                Me.m_ProviderName = value
            End Set
        End Property

        Public Property Purpose() As String
            Get
                Return Me.m_Purpose
            End Get
            Set(ByVal value As String)
                Me.m_Purpose = value
            End Set
        End Property

        Public Property QuotasDisabled() As Boolean
            Get
                Return Me.m_QuotasDisabled
            End Get
            Set(ByVal value As Boolean)
                Me.m_QuotasDisabled = value
            End Set
        End Property

        Public Property QuotasIncomplete() As Boolean
            Get
                Return Me.m_QuotasIncomplete
            End Get
            Set(ByVal value As Boolean)
                Me.m_QuotasIncomplete = value
            End Set
        End Property

        Public Property QuotasRebuilding() As Boolean
            Get
                Return Me.m_QuotasRebuilding
            End Get
            Set(ByVal value As Boolean)
                Me.m_QuotasRebuilding = value
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

        Public Property SupportsDiskQuotas() As Boolean
            Get
                Return Me.m_SupportsDiskQuotas
            End Get
            Set(ByVal value As Boolean)
                Me.m_SupportsDiskQuotas = value
            End Set
        End Property

        Public Property SupportsFileBasedCompression() As Boolean
            Get
                Return Me.m_SupportsFileBasedCompression
            End Get
            Set(ByVal value As Boolean)
                Me.m_SupportsFileBasedCompression = value
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

        Public Property VolumeDirty() As Boolean
            Get
                Return Me.m_VolumeDirty
            End Get
            Set(ByVal value As Boolean)
                Me.m_VolumeDirty = value
            End Set
        End Property

        Public Property VolumeName() As String
            Get
                Return Me.m_VolumeName
            End Get
            Set(ByVal value As String)
                Me.m_VolumeName = value
            End Set
        End Property

        Public Property VolumeSerialNumber() As String
            Get
                Return Me.m_VolumeSerialNumber
            End Get
            Set(ByVal value As String)
                Me.m_VolumeSerialNumber = value
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

