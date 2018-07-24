Imports System.Management

Namespace wmi

    Public Class VideoController
        Private _wmiWrapper As cwmi
        Private _moc As ManagementObjectCollection

        Public Sub New(ByRef wmiWrapper As cwmi)
            _wmiWrapper = wmiWrapper
        End Sub

        Private Function getInstances() As Boolean
            If _wmiWrapper.isConnected Then

                Return _wmiWrapper.getResultsFor(_moc, _
                                          "Win32_VideoController", "", _
                                          New String() {"AdapterRAM", "Caption", "CurrentRefreshRate", "CurrentHorizontalResolution", "CurrentVerticalResolution", "VideoProcessor", _
                                                        "InstalledDisplayDrivers", "DriverVersion"})

            End If
        End Function

        Public Function selectAll() As List(Of Win32_VideoController)
            If Not getInstances() Then
                Return Nothing
            End If

            Dim listOfVideoController As New List(Of Win32_VideoController)

            Try
                For Each mo As Management.ManagementObject In _moc
                    Dim VideoController As Win32_VideoController = New Win32_VideoController()

                    With VideoController
                        .AdapterRAM = CType(mo.Item("AdapterRAM"), UInteger)
                        .Caption = CType(mo.Item("Caption"), String)
                        .CurrentRefreshRate = CType(mo.Item("CurrentRefreshRate"), UInteger)
                        .CurrentHorizontalResolution = CType(mo.Item("CurrentHorizontalResolution"), UInteger)
                        .CurrentVerticalResolution = CType(mo.Item("CurrentVerticalResolution"), UInteger)
                        .VideoProcessor = CType(mo.Item("VideoProcessor"), String)
                        .InstalledDisplayDrivers = CType(mo.Item("InstalledDisplayDrivers"), String)
                        .DriverVersion = CType(mo.Item("DriverVersion"), String)
                    End With

                    listOfVideoController.Add(VideoController)
                    VideoController = Nothing
                Next
            Finally
                _moc.Dispose()
            End Try

            Return listOfVideoController

        End Function
    End Class

End Namespace
