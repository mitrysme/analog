Imports System.Management

Namespace wmi

    Public Class DiskDrive
        Private _wmiWrapper As cwmi
        Private _moc As ManagementObjectCollection

        Public Sub New(ByRef wmiWrapper As cwmi)
            _wmiWrapper = wmiWrapper
        End Sub

        Private Function getInstances() As Boolean
            If _wmiWrapper.isConnected Then

                Return _wmiWrapper.getResultsFor(_moc, _
                                          "Win32_DiskDrive", "", _
                                          New String() {"Manufacturer", "Model", "Name", "Partitions", "Caption", "Description", "DeviceID", "Status"})

            End If

        End Function

        Public Function selectAll() As List(Of wmi.Win32_DiskDrive)
            If Not getInstances() Then
                Return Nothing
            End If

            Dim listOfDiskDrive As New List(Of Win32_DiskDrive)

            ' exception possible pendant énumération ( réseau KO )
            Try
                For Each mo As Management.ManagementObject In _moc
                    Dim diskDrive As Win32_DiskDrive = New Win32_DiskDrive()

                    With diskDrive
                        .Manufacturer = CType(mo.Item("Manufacturer"), String)
                        .Model = CType(mo.Item("Model"), String)
                        .Name = CType(mo.Item("Name"), String)
                        .Partitions = CType(mo.Item("Partitions"), UInteger)
                        .Caption = CType(mo.Item("Caption"), String)
                        .Description = CType(mo.Item("Description"), String)
                        .DeviceID = CType(mo.Item("DeviceID"), String)
                        .Status = CType(mo.Item("Status"), String)
                    End With

                    listOfDiskDrive.Add(diskDrive)
                    diskDrive = Nothing
                Next
            Finally
                _moc.Dispose()
            End Try

            Return listOfDiskDrive
        End Function
    End Class

End Namespace
