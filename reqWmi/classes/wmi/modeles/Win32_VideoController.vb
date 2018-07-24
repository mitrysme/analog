Imports System.Management

Namespace wmi

    Public Class Win32_VideoController
        Private m_AcceleratorCapabilities As UShort()

        Private m_AdapterCompatibility As String

        Private m_AdapterDACType As String

        Private m_AdapterRAM As UInteger

        Private m_Availability As UShort

        Private m_CapabilityDescriptions As String()

        Private m_Caption As String

        Private m_ColorTableEntries As UInteger

        Private m_ConfigManagerErrorCode As UInteger

        Private m_ConfigManagerUserConfig As Boolean

        Private m_CreationClassName As String

        Private m_CurrentBitsPerPixel As UInteger

        Private m_CurrentHorizontalResolution As UInteger

        Private m_CurrentNumberOfColors As ULong

        Private m_CurrentNumberOfColumns As UInteger

        Private m_CurrentNumberOfRows As UInteger

        Private m_CurrentRefreshRate As UInteger

        Private m_CurrentScanMode As UShort

        Private m_CurrentVerticalResolution As UInteger

        Private m_Description As String

        Private m_DeviceID As String

        Private m_DeviceSpecificPens As UInteger

        Private m_DitherType As UInteger

        Private m_DriverDate As String

        Private m_DriverVersion As String

        Private m_ErrorCleared As Boolean

        Private m_ErrorDescription As String

        Private m_ICMIntent As UInteger

        Private m_ICMMethod As UInteger

        Private m_InfFilename As String

        Private m_InfSection As String

        Private m_InstallDate As String

        Private m_InstalledDisplayDrivers As String

        Private m_LastErrorCode As UInteger

        Private m_MaxMemorySupported As UInteger

        Private m_MaxNumberControlled As UInteger

        Private m_MaxRefreshRate As UInteger

        Private m_MinRefreshRate As UInteger

        Private m_Monochrome As Boolean

        Private m_Name As String

        Private m_NumberOfColorPlanes As UShort

        Private m_NumberOfVideoPages As UInteger

        Private m_PNPDeviceID As String

        Private m_PowerManagementCapabilities As UShort()

        Private m_PowerManagementSupported As Boolean

        Private m_ProtocolSupported As UShort

        Private m_ReservedSystemPaletteEntries As UInteger

        Private m_SpecificationVersion As UInteger

        Private m_Status As String

        Private m_StatusInfo As UShort

        Private m_SystemCreationClassName As String

        Private m_SystemName As String

        Private m_SystemPaletteEntries As UInteger

        Private m_TimeOfLastReset As String

        Private m_VideoArchitecture As UShort

        Private m_VideoMemoryType As UShort

        Private m_VideoMode As UShort

        Private m_VideoModeDescription As String

        Private m_VideoProcessor As String

        Private m_MyPath As String

        Public Sub New()
        End Sub

        Public Property AcceleratorCapabilities() As UShort()
            Get
                Return Me.m_AcceleratorCapabilities
            End Get
            Set(ByVal value As UShort())
                Me.m_AcceleratorCapabilities = value
            End Set
        End Property

        Public Property AdapterCompatibility() As String
            Get
                Return Me.m_AdapterCompatibility
            End Get
            Set(ByVal value As String)
                Me.m_AdapterCompatibility = value
            End Set
        End Property

        Public Property AdapterDACType() As String
            Get
                Return Me.m_AdapterDACType
            End Get
            Set(ByVal value As String)
                Me.m_AdapterDACType = value
            End Set
        End Property

        Public Property AdapterRAM() As UInteger
            Get
                Return Me.m_AdapterRAM
            End Get
            Set(ByVal value As UInteger)
                Me.m_AdapterRAM = value
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

        Public Property ColorTableEntries() As UInteger
            Get
                Return Me.m_ColorTableEntries
            End Get
            Set(ByVal value As UInteger)
                Me.m_ColorTableEntries = value
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

        Public Property CurrentBitsPerPixel() As UInteger
            Get
                Return Me.m_CurrentBitsPerPixel
            End Get
            Set(ByVal value As UInteger)
                Me.m_CurrentBitsPerPixel = value
            End Set
        End Property

        Public Property CurrentHorizontalResolution() As UInteger
            Get
                Return Me.m_CurrentHorizontalResolution
            End Get
            Set(ByVal value As UInteger)
                Me.m_CurrentHorizontalResolution = value
            End Set
        End Property

        Public Property CurrentNumberOfColors() As ULong
            Get
                Return Me.m_CurrentNumberOfColors
            End Get
            Set(ByVal value As ULong)
                Me.m_CurrentNumberOfColors = value
            End Set
        End Property

        Public Property CurrentNumberOfColumns() As UInteger
            Get
                Return Me.m_CurrentNumberOfColumns
            End Get
            Set(ByVal value As UInteger)
                Me.m_CurrentNumberOfColumns = value
            End Set
        End Property

        Public Property CurrentNumberOfRows() As UInteger
            Get
                Return Me.m_CurrentNumberOfRows
            End Get
            Set(ByVal value As UInteger)
                Me.m_CurrentNumberOfRows = value
            End Set
        End Property

        Public Property CurrentRefreshRate() As UInteger
            Get
                Return Me.m_CurrentRefreshRate
            End Get
            Set(ByVal value As UInteger)
                Me.m_CurrentRefreshRate = value
            End Set
        End Property

        Public Property CurrentScanMode() As UShort
            Get
                Return Me.m_CurrentScanMode
            End Get
            Set(ByVal value As UShort)
                Me.m_CurrentScanMode = value
            End Set
        End Property

        Public Property CurrentVerticalResolution() As UInteger
            Get
                Return Me.m_CurrentVerticalResolution
            End Get
            Set(ByVal value As UInteger)
                Me.m_CurrentVerticalResolution = value
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

        Public Property DeviceSpecificPens() As UInteger
            Get
                Return Me.m_DeviceSpecificPens
            End Get
            Set(ByVal value As UInteger)
                Me.m_DeviceSpecificPens = value
            End Set
        End Property

        Public Property DitherType() As UInteger
            Get
                Return Me.m_DitherType
            End Get
            Set(ByVal value As UInteger)
                Me.m_DitherType = value
            End Set
        End Property

        Public Property DriverDate() As String
            Get
                Return Me.m_DriverDate
            End Get
            Set(ByVal value As String)
                Me.m_DriverDate = value
            End Set
        End Property

        Public Property DriverVersion() As String
            Get
                Return Me.m_DriverVersion
            End Get
            Set(ByVal value As String)
                Me.m_DriverVersion = value
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

        Public Property ICMIntent() As UInteger
            Get
                Return Me.m_ICMIntent
            End Get
            Set(ByVal value As UInteger)
                Me.m_ICMIntent = value
            End Set
        End Property

        Public Property ICMMethod() As UInteger
            Get
                Return Me.m_ICMMethod
            End Get
            Set(ByVal value As UInteger)
                Me.m_ICMMethod = value
            End Set
        End Property

        Public Property InfFilename() As String
            Get
                Return Me.m_InfFilename
            End Get
            Set(ByVal value As String)
                Me.m_InfFilename = value
            End Set
        End Property

        Public Property InfSection() As String
            Get
                Return Me.m_InfSection
            End Get
            Set(ByVal value As String)
                Me.m_InfSection = value
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

        Public Property InstalledDisplayDrivers() As String
            Get
                Return Me.m_InstalledDisplayDrivers
            End Get
            Set(ByVal value As String)
                Me.m_InstalledDisplayDrivers = value
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

        Public Property MaxMemorySupported() As UInteger
            Get
                Return Me.m_MaxMemorySupported
            End Get
            Set(ByVal value As UInteger)
                Me.m_MaxMemorySupported = value
            End Set
        End Property

        Public Property MaxNumberControlled() As UInteger
            Get
                Return Me.m_MaxNumberControlled
            End Get
            Set(ByVal value As UInteger)
                Me.m_MaxNumberControlled = value
            End Set
        End Property

        Public Property MaxRefreshRate() As UInteger
            Get
                Return Me.m_MaxRefreshRate
            End Get
            Set(ByVal value As UInteger)
                Me.m_MaxRefreshRate = value
            End Set
        End Property

        Public Property MinRefreshRate() As UInteger
            Get
                Return Me.m_MinRefreshRate
            End Get
            Set(ByVal value As UInteger)
                Me.m_MinRefreshRate = value
            End Set
        End Property

        Public Property Monochrome() As Boolean
            Get
                Return Me.m_Monochrome
            End Get
            Set(ByVal value As Boolean)
                Me.m_Monochrome = value
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

        Public Property NumberOfColorPlanes() As UShort
            Get
                Return Me.m_NumberOfColorPlanes
            End Get
            Set(ByVal value As UShort)
                Me.m_NumberOfColorPlanes = value
            End Set
        End Property

        Public Property NumberOfVideoPages() As UInteger
            Get
                Return Me.m_NumberOfVideoPages
            End Get
            Set(ByVal value As UInteger)
                Me.m_NumberOfVideoPages = value
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

        Public Property ProtocolSupported() As UShort
            Get
                Return Me.m_ProtocolSupported
            End Get
            Set(ByVal value As UShort)
                Me.m_ProtocolSupported = value
            End Set
        End Property

        Public Property ReservedSystemPaletteEntries() As UInteger
            Get
                Return Me.m_ReservedSystemPaletteEntries
            End Get
            Set(ByVal value As UInteger)
                Me.m_ReservedSystemPaletteEntries = value
            End Set
        End Property

        Public Property SpecificationVersion() As UInteger
            Get
                Return Me.m_SpecificationVersion
            End Get
            Set(ByVal value As UInteger)
                Me.m_SpecificationVersion = value
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

        Public Property SystemPaletteEntries() As UInteger
            Get
                Return Me.m_SystemPaletteEntries
            End Get
            Set(ByVal value As UInteger)
                Me.m_SystemPaletteEntries = value
            End Set
        End Property

        Public Property TimeOfLastReset() As String
            Get
                Return Me.m_TimeOfLastReset
            End Get
            Set(ByVal value As String)
                Me.m_TimeOfLastReset = value
            End Set
        End Property

        Public Property VideoArchitecture() As UShort
            Get
                Return Me.m_VideoArchitecture
            End Get
            Set(ByVal value As UShort)
                Me.m_VideoArchitecture = value
            End Set
        End Property

        Public Property VideoMemoryType() As UShort
            Get
                Return Me.m_VideoMemoryType
            End Get
            Set(ByVal value As UShort)
                Me.m_VideoMemoryType = value
            End Set
        End Property

        Public Property VideoMode() As UShort
            Get
                Return Me.m_VideoMode
            End Get
            Set(ByVal value As UShort)
                Me.m_VideoMode = value
            End Set
        End Property

        Public Property VideoModeDescription() As String
            Get
                Return Me.m_VideoModeDescription
            End Get
            Set(ByVal value As String)
                Me.m_VideoModeDescription = value
            End Set
        End Property

        Public Property VideoProcessor() As String
            Get
                Return Me.m_VideoProcessor
            End Get
            Set(ByVal value As String)
                Me.m_VideoProcessor = value
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
