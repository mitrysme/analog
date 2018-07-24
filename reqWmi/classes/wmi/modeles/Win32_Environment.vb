Namespace wmi

    Public Class Win32_Environment
        Private m_Caption As String

        Private m_Description As String

        Private m_InstallDate As DateTime

        Private m_Name As String

        Private m_status As String

        Private m_SystemVariable As Boolean

        Private m_UserName As String

        Private m_VariableValue As String

        Public Sub New()
        End Sub

        Public Property Caption() As String
            Get
                Return m_Caption
            End Get
            Set(ByVal value As String)
                Me.m_Caption = value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return m_Description
            End Get
            Set(ByVal value As String)
                Me.m_Description = value
            End Set
        End Property

        Public Property InstallDate() As DateTime
            Get
                Return m_InstallDate
            End Get
            Set(ByVal value As DateTime)
                Me.m_InstallDate = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                Me.m_Name = value
            End Set
        End Property

        Public Property Status() As String
            Get
                Return m_status
            End Get
            Set(ByVal value As String)
                Me.m_status = value
            End Set
        End Property

        Public Property SystemVariable() As Boolean
            Get
                Return m_SystemVariable
            End Get
            Set(ByVal value As Boolean)
                Me.m_SystemVariable = value
            End Set
        End Property

        Public Property UserName() As String
            Get
                Return m_UserName
            End Get
            Set(ByVal value As String)
                Me.m_UserName = value
            End Set
        End Property

        Public Property VariableValue() As String
            Get
                Return m_VariableValue
            End Get
            Set(ByVal value As String)
                Me.m_VariableValue = value
            End Set
        End Property


    End Class

End Namespace
