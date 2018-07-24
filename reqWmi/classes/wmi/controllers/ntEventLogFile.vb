Imports System.Management

Namespace wmi
    Public Class ntEventLogFile
        Private _stationName As String

        Public Const SYSTEM_LOG_NAME As String = "SysEvent.Evt"
        Public Const APPLICATION_LOG_NAME As String = "AppEvent.Evt"

        Public Event processError(ByVal logName As String, ByVal errorName As String)
        Public Event processCompleted(ByVal logName As String)

        Public Sub New(ByVal stationName As String)
            _stationName = stationName
        End Sub

        Public Sub clearLogs(ByVal logName As String)
            clearlog(logName)
        End Sub

        Private Sub clearlog(ByVal logName As String)
            Dim obs As New ManagementOperationObserver

            Dim path As New ManagementPath
            With path
                .Server = _stationName
                .NamespacePath = "root\cimv2"
                .ClassName = "Win32_NTEventlogFile"
                .RelativePath = String.Format("Win32_NTEventlogFile.Name='C:\WINDOWS\system32\config\{0}'", logName)
            End With
           
            Using o As ManagementObject = New ManagementObject(path)
                Try
                    ' peut bloquer si station KO
                    o.InvokeMethod(obs, "clearEventLog", Nothing)
                Catch ex As Exception
                    RaiseEvent processError(logName, ex.Message)
                    Exit Sub
                End Try
            End Using

            AddHandler obs.Completed, AddressOf watcherCompletedHandler

        End Sub

        Private Sub watcherCompletedHandler(ByVal sender As Object, ByVal e As CompletedEventArgs)
            Dim mo As ManagementOperationObserver = CType(sender, ManagementOperationObserver)

            If e.Status = ManagementStatus.NoError Then
                RaiseEvent processCompleted("test")
            Else
                RaiseEvent processError(Nothing, e.Status.ToString)
            End If

            RemoveHandler mo.Completed, AddressOf watcherCompletedHandler
        End Sub
    End Class
End Namespace

