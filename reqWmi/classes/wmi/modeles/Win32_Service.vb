Imports System
Imports System.Management


Namespace wmi

    Public Class Win32_Service

        Private m_AcceptPause As Boolean

        Private m_AcceptStop As Boolean

        Private m_Caption As String

        Private m_CheckPoint As UInteger

        Private m_CreationClassName As String

        Private m_Description As String

        Private m_DesktopInteract As Boolean

        Private m_DisplayName As String

        Private m_ErrorControl As String

        Private m_ExitCode As UInteger

        Private m_InstallDate As String

        Private m_Name As String

        Private m_PathName As String

        Private m_ProcessId As UInteger

        Private m_ServiceSpecificExitCode As UInteger

        Private m_ServiceType As String

        Private m_Started As Boolean

        Private m_StartMode As String

        Private m_StartName As String

        Private m_State As String

        Private m_Status As String

        Private m_SystemCreationClassName As String

        Private m_SystemName As String

        Private m_TagId As UInteger

        Private m_WaitHint As UInteger

        Private m_MyPath As String

        Public Sub New()
            MyBase.New()

        End Sub

        Public Property AcceptPause() As Boolean
            Get
                Return Me.m_AcceptPause
            End Get
            Set(ByVal value As Boolean)
                Me.m_AcceptPause = value
            End Set
        End Property

        Public Property AcceptStop() As Boolean
            Get
                Return Me.m_AcceptStop
            End Get
            Set(ByVal value As Boolean)
                Me.m_AcceptStop = value
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

        Public Property CheckPoint() As UInteger
            Get
                Return Me.m_CheckPoint
            End Get
            Set(ByVal value As UInteger)
                Me.m_CheckPoint = value
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

        Public Property DesktopInteract() As Boolean
            Get
                Return Me.m_DesktopInteract
            End Get
            Set(ByVal value As Boolean)
                Me.m_DesktopInteract = value
            End Set
        End Property

        Public Property DisplayName() As String
            Get
                Return Me.m_DisplayName
            End Get
            Set(ByVal value As String)
                Me.m_DisplayName = value
            End Set
        End Property

        Public Property ErrorControl() As String
            Get
                Return Me.m_ErrorControl
            End Get
            Set(ByVal value As String)
                Me.m_ErrorControl = value
            End Set
        End Property

        Public Property ExitCode() As UInteger
            Get
                Return Me.m_ExitCode
            End Get
            Set(ByVal value As UInteger)
                Me.m_ExitCode = value
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

        Public Property Name() As String
            Get
                Return Me.m_Name
            End Get
            Set(ByVal value As String)
                Me.m_Name = value
            End Set
        End Property

        Public Property PathName() As String
            Get
                Return Me.m_PathName
            End Get
            Set(ByVal value As String)
                Me.m_PathName = value
            End Set
        End Property

        Public Property ProcessId() As UInteger
            Get
                Return Me.m_ProcessId
            End Get
            Set(ByVal value As UInteger)
                Me.m_ProcessId = value
            End Set
        End Property

        Public Property ServiceSpecificExitCode() As UInteger
            Get
                Return Me.m_ServiceSpecificExitCode
            End Get
            Set(ByVal value As UInteger)
                Me.m_ServiceSpecificExitCode = value
            End Set
        End Property

        Public Property ServiceType() As String
            Get
                Return Me.m_ServiceType
            End Get
            Set(ByVal value As String)
                Me.m_ServiceType = value
            End Set
        End Property

        Public Property Started() As Boolean
            Get
                Return Me.m_Started
            End Get
            Set(ByVal value As Boolean)
                Me.m_Started = value
            End Set
        End Property

        Public Property StartMode() As String
            Get
                Return Me.m_StartMode
            End Get
            Set(ByVal value As String)
                Me.m_StartMode = value
            End Set
        End Property

        Public Property StartName() As String
            Get
                Return Me.m_StartName
            End Get
            Set(ByVal value As String)
                Me.m_StartName = value
            End Set
        End Property

        Public Property State() As String
            Get
                Return Me.m_State
            End Get
            Set(ByVal value As String)
                Me.m_State = value
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

        Public Property TagId() As UInteger
            Get
                Return Me.m_TagId
            End Get
            Set(ByVal value As UInteger)
                Me.m_TagId = value
            End Set
        End Property

        Public Property WaitHint() As UInteger
            Get
                Return Me.m_WaitHint
            End Get
            Set(ByVal value As UInteger)
                Me.m_WaitHint = value
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