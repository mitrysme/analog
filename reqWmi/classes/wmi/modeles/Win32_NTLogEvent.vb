Namespace wmi

    Public Class Win32_NTLogEvent

        Private m_Category As UShort

        Private m_CategoryString As String

        Private m_ComputerName As String

        Private m_Data As UShort()

        Private m_EventCode As UShort

        Private m_EventIdentifier As UInteger

        Private m_EventType As UShort

        Private m_InsertionStrings As String()

        Private m_Logfile As String

        Private m_Message As String

        Private m_RecordNumber As UInteger

        Private m_SourceName As String

        Private m_TimeGenerated As String

        Private m_TimeWritten As String

        Private m_Type As String

        Private m_User As String

        Private m_MyPath As String

        Public Sub New()
        End Sub

        Public Property Category() As UShort
            Get
                Return Me.m_Category
            End Get
            Set(ByVal value As UShort)
                Me.m_Category = value
            End Set
        End Property

        Public Property CategoryString() As String
            Get
                Return Me.m_CategoryString
            End Get
            Set(ByVal value As String)
                Me.m_CategoryString = value
            End Set
        End Property

        Public Property ComputerName() As String
            Get
                Return Me.m_ComputerName
            End Get
            Set(ByVal value As String)
                Me.m_ComputerName = value
            End Set
        End Property

        Public Property Data() As UShort()
            Get
                Return Me.m_Data
            End Get
            Set(ByVal value As UShort())
                Me.m_Data = value
            End Set
        End Property

        Public Property EventCode() As UShort
            Get
                Return Me.m_EventCode
            End Get
            Set(ByVal value As UShort)
                Me.m_EventCode = value
            End Set
        End Property

        Public Property EventIdentifier() As UInteger
            Get
                Return Me.m_EventIdentifier
            End Get
            Set(ByVal value As UInteger)
                Me.m_EventIdentifier = value
            End Set
        End Property

        Public Property EventType() As UShort
            Get
                Return Me.m_EventType
            End Get
            Set(ByVal value As UShort)
                Me.m_EventType = value
            End Set
        End Property

        Public Property InsertionStrings() As String()
            Get
                Return Me.m_InsertionStrings
            End Get
            Set(ByVal value As String())
                Me.m_InsertionStrings = value
            End Set
        End Property

        Public Property Logfile() As String
            Get
                Return Me.m_Logfile
            End Get
            Set(ByVal value As String)
                Me.m_Logfile = value
            End Set
        End Property

        Public Property Message() As String
            Get
                Return Me.m_Message
            End Get
            Set(ByVal value As String)
                Me.m_Message = value
            End Set
        End Property

        Public Property RecordNumber() As UInteger
            Get
                Return Me.m_RecordNumber
            End Get
            Set(ByVal value As UInteger)
                Me.m_RecordNumber = value
            End Set
        End Property

        Public Property SourceName() As String
            Get
                Return Me.m_SourceName
            End Get
            Set(ByVal value As String)
                Me.m_SourceName = value
            End Set
        End Property

        Public Property TimeGenerated() As String
            Get
                Return Me.m_TimeGenerated
            End Get
            Set(ByVal value As String)
                Me.m_TimeGenerated = value
            End Set
        End Property

        Public Property TimeWritten() As String
            Get
                Return Me.m_TimeWritten
            End Get
            Set(ByVal value As String)
                Me.m_TimeWritten = value
            End Set
        End Property

        Public Property Type() As String
            Get
                Return Me.m_Type
            End Get
            Set(ByVal value As String)
                Me.m_Type = value
            End Set
        End Property

        Public Property User() As String
            Get
                Return Me.m_User
            End Get
            Set(ByVal value As String)
                Me.m_User = value
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

