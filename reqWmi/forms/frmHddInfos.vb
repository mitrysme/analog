Imports System.Management

Public Class frmHddInfos
    Private _stationName As String
    Private _listOfwmiDiskDrives As List(Of wmi.Win32_DiskDrive)

    Public ReadOnly Property stationName() As String
        Get
            Return _stationName
        End Get
    End Property

    Private Sub frmHddInfos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        initializeLstHddInfos()
        showInfos()
    End Sub

    Public Sub New(ByVal stationName As String, ByRef listOfWmiDiskDrives As List(Of wmi.Win32_DiskDrive))

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _stationName = stationName
        _listOfwmiDiskDrives = listOfWmiDiskDrives
        Me.Text = String.Format("Analog : {0} - Infos disque Dur", _stationName)
    End Sub

    ' à rentrer dans le designer
    Private Sub initializeLstHddInfos()
        With lstHddInfos
            .Clear()
            .Columns.Add("Fabricant", 80, HorizontalAlignment.Left)
            .Columns.Add("Modele", 80, HorizontalAlignment.Left)
            .Columns.Add("nom", 80, HorizontalAlignment.Left)
            .Columns.Add("Nb. Partitions", 80, HorizontalAlignment.Left)
            .Columns.Add("Titre", 80, HorizontalAlignment.Left)
            .Columns.Add("Description", 80, HorizontalAlignment.Left)
            .Columns.Add("Id", 80, HorizontalAlignment.Left)
            .Columns.Add("SMART status", 80, HorizontalAlignment.Left)
            .View = View.Details
        End With
    End Sub

    Private Sub showInfos()
        For Each diskDrive As wmi.Win32_DiskDrive In _listOfwmiDiskDrives
            Dim LVI As New ListViewItem

            With LVI
                .Text = diskDrive.Manufacturer
                .SubItems.Add(diskDrive.Model)
                .SubItems.Add(diskDrive.Name)
                .SubItems.Add(diskDrive.Partitions.ToString)
                .SubItems.Add(diskDrive.Caption)
                .SubItems.Add(diskDrive.Description)
                .SubItems.Add(diskDrive.DeviceID)
                .SubItems.Add(diskDrive.Status)
            End With
            Me.lstHddInfos.Items.Add(LVI)
        Next
    End Sub
End Class