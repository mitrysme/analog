Imports System.Management

Namespace wmi

    Public Class LogicalDisk
        Private _wmiWrapper As cwmi
        Private _moc As ManagementObjectCollection

        Public Sub New(ByRef wmiWrapper As cwmi)
            _wmiWrapper = wmiWrapper
        End Sub

        Private Function getInstances() As Boolean
            If _wmiWrapper.isConnected Then

                ' si requete échoue , teste sans propriété volumedirty => absente sous win2000
                If Not _wmiWrapper.getResultsFor(_moc, _
                                           "Win32_LogicalDisk", "DriveType=3 OR DriveType=4", _
                                           New String() {"Drivetype", "Size", "DriveType", "Freespace", "name", "VolumeDirty"}) Then

                    _wmiWrapper.getResultsFor(_moc, _
                                           "Win32_LogicalDisk", "DriveType=3 OR DriveType=4", _
                                           New String() {"Drivetype", "Size", "DriveType", "Freespace", "name"})

                End If

                If Not _moc Is Nothing Then
                    Return True
                Else
                    Return False
                End If

            Else
                Return False
            End If
        End Function

        Public Shared Function getFreeDiskSpaceAsPercentage(ByVal diskSize As ULong, ByVal diskFree As ULong) As Single
            Dim tailledisque As Single = CDec(diskSize / frmMain.GIGA_OCTETS)
            Dim placeRestante As Single = CDec(diskFree / frmMain.GIGA_OCTETS)

            If tailledisque = 0 Or placeRestante = 0 Then
                Return Nothing
            End If

            Dim pourcentageRestant As Single = (placeRestante / tailledisque) * 100

            Return pourcentageRestant
        End Function

        Public Function selectAll() As List(Of Win32_LogicalDisk)
            If Not getInstances() Then
                Return Nothing
            End If

            Dim listOfLogicalDisk As New List(Of Win32_LogicalDisk)

            Try
                For Each mo As Management.ManagementObject In _moc
                    Dim LogicalDisk As Win32_LogicalDisk = New Win32_LogicalDisk()

                    ' Dim p As PropertyDataCollection = mo.Properties


                    With LogicalDisk
                        .DriveType = CType(mo.Item("DriveType"), UInteger)
                        .Size = CType(mo.Item("Size"), ULong)
                        .DriveType = CType(mo.Item("DriveType"), UInteger)
                        .FreeSpace = CType(mo.Item("Freespace"), ULong)
                        .Name = CType(mo.Item("name"), String)
                    End With

                    listOfLogicalDisk.Add(LogicalDisk)
                    LogicalDisk = Nothing
                Next
            Finally
                _moc.Dispose()
            End Try

            Return listOfLogicalDisk

        End Function
    End Class

End Namespace
