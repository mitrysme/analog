Imports System.Management
Imports AnalogEnums.enums

Public Class cProcessInfos
    Private _Pid As UInteger ' PID du Process
    Private _Name As String ' Nom Process
    Private _Owner As String ' user name and domain name under which the process is running.
    Private _Path As String
    Private _userName As String
    Private _userTime As Long
    Private _kernelTime As Long
    Private _threadCount As UInteger
    Private _pageFaults As UInteger
    Private _cpuUsage As Double
    Private _isKilled As Boolean
    ' new 
    Private _VirtualSize As ULong
    Private _WorkingSetSize As ULong
    Private _ParentProcessId As UInt32
    Private _Priority As UInt32

#Region "properties"
    Public Property pid() As UInteger
        Get
            Return _Pid
        End Get
        Set(ByVal value As UInteger)
            _Pid = value
        End Set
    End Property
    Public Property name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property
    Public Property path() As String
        Get
            Return _Path
        End Get
        Set(ByVal value As String)
            _Path = value
        End Set
    End Property
    Public Property userName() As String
        Get
            Return _userName
        End Get
        Set(ByVal value As String)
            _userName = value
        End Set
    End Property
    Public Property isKilled() As Boolean
        Get
            Return _isKilled
        End Get
        Set(ByVal value As Boolean)
            _isKilled = value
        End Set
    End Property
    Public Property usertime() As Long
        Get
            Return _userTime
        End Get
        Set(ByVal value As Long)
            _userTime = value
        End Set
    End Property
    Public Property kernelTime() As Long
        Get
            Return _kernelTime
        End Get
        Set(ByVal value As Long)
            _kernelTime = value
        End Set
    End Property
    Public ReadOnly Property totalCpuTime() As Long
        Get
            Return _userTime + _kernelTime
        End Get
    End Property
    Public Property threadCount() As UInteger
        Get
            Return _threadCount
        End Get
        Set(ByVal value As UInteger)
            _threadCount = value
        End Set
    End Property
    Public Property pageFaults() As UInteger
        Get
            Return _pageFaults
        End Get
        Set(ByVal value As UInteger)
            _pageFaults = value
        End Set
    End Property
    Public ReadOnly Property cpuUsage() As Double
        Get
            Return _cpuUsage
        End Get
    End Property
    Public Property VirtualSize() As ULong
        Get
            Return _VirtualSize
        End Get
        Set(ByVal value As ULong)
            _VirtualSize = value
        End Set
    End Property
    Public Property WorkingSetSize() As ULong
        Get
            Return _WorkingSetSize
        End Get
        Set(ByVal value As ULong)
            _WorkingSetSize = value
        End Set
    End Property
    Public Property ParentProcessId() As UInt32
        Get
            Return _ParentProcessId
        End Get
        Set(ByVal value As UInt32)
            _ParentProcessId = value
        End Set
    End Property
    Public Property Priority() As UInt32
        Get
            Return _Priority
        End Get
        Set(ByVal value As UInt32)
            _Priority = value
        End Set
    End Property
#End Region

    Public Sub New(ByVal processInfos As cProcessInfos)
        With processInfos
            _Pid = .pid
            _Path = .path
            _Name = .name
            _userName = .userName
            _userTime = .usertime
            _kernelTime = .kernelTime
            _threadCount = .threadCount
            _pageFaults = .pageFaults
            _isKilled = .isKilled
            _VirtualSize = .VirtualSize
            _WorkingSetSize = .WorkingSetSize
            _ParentProcessId = .ParentProcessId
            _Priority = .Priority
        End With
    End Sub


    Public Sub New()
        '
    End Sub


    Public Function getInfos(ByVal item As String) As String
        Select Case (item.ToUpperInvariant)
            Case "PID"
                Return CStr(_Pid)
            Case "NAME"
                Return CStr(_Name)
            Case "USERNAME"
                Return _userName
            Case "TOTALCPU"
                Return getFormattedTotalCpuTime(totalCpuTime)
            Case "PATH"
                Return _Path
            Case "THREADS"
                Return CStr(_threadCount)
            Case "PAGE FAULTS"
                Return CStr(_pageFaults)
            Case "CPU"
                Return GetFormatedPercentage(Me.cpuUsage)
            Case "UTIL. MEMOIRE (KO)"
                Return CStr(Int((_WorkingSetSize) / 1024))
            Case "VIRTUALSIZE"
                Return CStr(Int((_VirtualSize) / 1024) + 1)
            Case "PARENT PROCESS"
                Return CStr(_ParentProcessId)
            Case "PRIORITE"
                Return CStr(_Priority)
            Case Else
                Return "N/A"
        End Select

    End Function

    Private Function getFormattedTotalCpuTime(ByVal totalCpuTime As Long) As String
        Dim ts As Date = New Date(totalCpuTime)
        Dim totCpuTimeFormat = String.Format("{0:00}", ts.Hour) & ":" & _
                String.Format("{0:00}", ts.Minute) & ":" & _
                String.Format("{0:00}", ts.Second) & ":" & _
                String.Format("{000}", ts.Millisecond)

        Return totCpuTimeFormat
    End Function

    ' Get a formated percentage
    Public Shared Function GetFormatedPercentage(ByVal p As Double, Optional ByVal digits As Integer = 3, Optional ByVal force0 As Boolean = False) As String
        If force0 OrElse p > 0 Then
            Dim d100 As Double = p * 100
            Dim d As Double = Math.Round(d100, digits)
            Dim tr As Double = Math.Truncate(d)
            Dim lp As Integer = CInt(tr)
            Dim rp As Integer = CInt((d100 - tr) * 10 ^ digits)

            Return CStr(IIf(lp < 10, "0", "")) & CStr(lp) & "." & CStr(IIf(rp < 10, "00", "")) & CStr(IIf(rp < 100 And rp >= 10, "0", "")) & CStr(rp)
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' MAJ des valeurs non fixées
    ''' </summary>
    ''' <param name="processInfos"></param>
    ''' <remarks></remarks>
    Public Sub merge(ByRef processInfos As cProcessInfos, ByRef station As cstation)
        _userTime = processInfos.usertime
        _kernelTime = processInfos.kernelTime
        _WorkingSetSize = processInfos.WorkingSetSize
        _Priority = processInfos.Priority
        Call refreshCpuUsage(station)
    End Sub

    Private Sub refreshCpuUsage(ByRef station As cstation)

        Dim nbProc As Integer = CInt(station.gInfoStation.numberOfProcessors)

        Static oldDate As Long = Date.Now.Ticks
        Static oldProcTime As Long = Me.totalCpuTime

        Dim currDate As Long = Date.Now.Ticks
        Dim proctime As Long = Me.totalCpuTime

        Dim diff As Long = currDate - oldDate
        Dim procDiff As Long = proctime - oldProcTime

        oldProcTime = proctime
        oldDate = currDate

        If diff > 0 AndAlso nbProc > 0 Then
            _cpuUsage = procDiff / diff / nbProc
        Else
            _cpuUsage = 0
        End If
    End Sub

End Class
