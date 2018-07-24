Imports System.Management

Namespace wmi

    Public Class Environment
        Private _wmiWrapper As cwmi
        Private _moc As ManagementObjectCollection

        Public Sub New(ByRef wmiWrapper As cwmi)
            _wmiWrapper = wmiWrapper
        End Sub

        Private Function getInstances() As Boolean
            If _wmiWrapper.isConnected Then
                Return _wmiWrapper.getResultsFor(_moc, "Win32_Environment", Nothing, New String() {"Name", "VariableValue"})
            End If
        End Function

        Public Function selectAll() As List(Of Win32_Environment)
            If Not getInstances() Then
                Return Nothing
            End If

            Dim listOfEnvVar As New List(Of Win32_Environment)

            Try
                For Each mo As Management.ManagementObject In _moc
                    Dim envVar As Win32_Environment = New Win32_Environment
                    With envVar
                        .Name = CType(mo.Item("Name"), String)
                        .VariableValue = CType(mo.Item("VariableValue"), String)
                    End With

                    listOfEnvVar.Add(envVar)
                    envVar = Nothing
                Next
            Finally
                _moc.Dispose()
            End Try

            Return listOfEnvVar
        End Function

    End Class

End Namespace
