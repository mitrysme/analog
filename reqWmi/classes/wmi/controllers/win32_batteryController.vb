Imports System.Management

Namespace wmi
    Public Class win32_batteryController
        Private _wmiWrapper As cwmi
        Private _moc As ManagementObjectCollection

        Public Sub New(ByRef wmiWrapper As cwmi)
            _wmiWrapper = wmiWrapper
        End Sub

        Private Function getInstances() As Boolean
            If _wmiWrapper.isConnected Then

                Return _wmiWrapper.getResultsFor(_moc, _
                                          "Win32_Battery", "", _
                                          New String() {"availability", "BatteryStatus", "EstimatedChargeRemaining", "EstimatedRunTime", "status"})

            End If
        End Function

        Public Function selectAll() As List(Of win32_battery)
            If Not getInstances() Then
                Return Nothing
            End If

            Dim listOfBattery As New List(Of win32_battery)

            Try
                For Each mo As Management.ManagementObject In _moc
                    Dim win32_battery As win32_battery = New win32_battery()

                    With win32_battery
                        .EstimatedChargeRemaining = CType(mo.Item("EstimatedChargeRemaining"), UInt16)
                        .estimatedRunTime = CType(mo.Item("estimatedRunTime"), UInt32)
                        .availability = CType(mo.Item("availability"), UInt16)
                        .status = CType(mo.Item("status"), String)
                        .batteryStatus = CType(mo.Item("BatteryStatus"), UInt16)
                    End With

                    listOfBattery.Add(win32_battery)
                    win32_battery = Nothing
                Next
            Finally
                _moc.Dispose()
            End Try

            Return listOfBattery
        End Function
    End Class

End Namespace

