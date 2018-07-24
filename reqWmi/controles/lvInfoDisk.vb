Imports System.Management

Public Class lvInfoDisk
    Inherits baseLv

    Public Sub updateitemsForStation(ByRef station As cstation)

        For Each logicalDisk As wmi.Win32_LogicalDisk In station.listOfLogicalDisk ' crash si un lecteur réseau est déconnecté/innacessible
            Dim driveTypeAsTring As String
            If logicalDisk.DriveType = 3 Then
                driveTypeAsTring = "Local"
            Else
                driveTypeAsTring = "Réseau"
            End If

            Dim LVI As New ListViewItem(driveTypeAsTring)

            With LVI.SubItems
                .Add(logicalDisk.Name)
                .Add(Format(Convert.ToUInt64(logicalDisk.Size) / frmMain.GIGA_OCTETS, "#.00") & " Go")
                .Add(Format(Convert.ToUInt64(logicalDisk.FreeSpace) / frmMain.GIGA_OCTETS, "#.00") & " Go")
                .Add(Math.Truncate(wmi.LogicalDisk.getFreeDiskSpaceAsPercentage(logicalDisk.Size, logicalDisk.FreeSpace)).ToString & " %")
                .Add(logicalDisk.VolumeDirty.ToString)
            End With

            Me.Items.Add(LVI)
        Next

    End Sub

    Public Sub updateitemsForStation(ByVal hddTotalSpace As Integer, ByVal hddFreeSpace As Integer)

        If hddTotalSpace = 0 Or hddFreeSpace = 0 Then
            Return
        End If

        'For Each logicalDisk As wmi.Win32_LogicalDisk In station.listOfLogicalDisk ' crash si un lecteur réseau est déconnecté/innacessible
        '    Dim driveTypeAsTring As String
        '    If logicalDisk.DriveType = 3 Then
        '        driveTypeAsTring = "Local"
        '    Else
        '        driveTypeAsTring = "Réseau"
        '    End If

        Dim LVI As New ListViewItem("")

        With LVI.SubItems
            .Add("")
            .Add(hddTotalSpace.ToString & " Go")
            .Add(hddFreeSpace & " Go")
            .Add(Math.Truncate(wmi.LogicalDisk.getFreeDiskSpaceAsPercentage(CULng(hddTotalSpace), CULng(hddFreeSpace))).ToString & " %")
            '.Add(logicalDisk.VolumeDirty.ToString)
        End With

        Me.Items.Add(LVI)
        ' Next

    End Sub

    Public Function getSelectedItemsDriveInfos(ByRef diskPart As String, ByRef diskType As String) As Boolean
        If Me.SelectedItems.Count = 0 Then Return False

        ' nom et type de la partition
        diskPart = CType(Me.SelectedItems.Item(0).SubItems(1).Text, String)
        diskType = CType(Me.SelectedItems.Item(0).SubItems(0).Text, String)

        Return True
    End Function


End Class
