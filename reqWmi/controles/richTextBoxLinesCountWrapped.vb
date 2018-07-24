Public Class richTextBoxLinesCountWrapped
    Inherits RichTextBox

    Private Const EM_GETLINECOUNT As Integer = &HBA
    Private Const EM_LINEINDEX As Integer = &HBB
    Private Const EM_LINELENGTH As Integer = &HC1



    Public Sub New()
        MyBase.new()
        'Since we'll want multiple lines allowed we'll add that to the constructor
        'Me.Multiline = True
        Me.ScrollBars = RichTextBoxScrollBars.Vertical
    End Sub

    Public ReadOnly Property LineCount() As Integer
        Get
            Dim msg As Message = Message.Create(Me.Handle, EM_GETLINECOUNT, IntPtr.Zero, IntPtr.Zero)
            MyBase.DefWndProc(msg)
            Return msg.Result.ToInt32()
        End Get
    End Property

    Public ReadOnly Property LineIndex(ByVal Index As Integer) As Integer
        Get
            Dim msg As Message = Message.Create(Me.Handle, EM_LINEINDEX, CType(Index, IntPtr), IntPtr.Zero)
            MyBase.DefWndProc(msg)
            Return msg.Result.ToInt32()
        End Get
    End Property

    Public ReadOnly Property LineLength(ByVal Index As Integer) As Integer
        Get
            Dim msg As Message = Message.Create(Me.Handle, EM_LINELENGTH, CType(Index, IntPtr), IntPtr.Zero)
            MyBase.DefWndProc(msg)
            Return msg.Result.ToInt32()
        End Get
    End Property


End Class
