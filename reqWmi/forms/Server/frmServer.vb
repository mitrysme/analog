Imports program
Imports System.ComponentModel ' backgroundworker

Public Class frmServer
    Private Delegate Sub dgUpdateLvLog(ByVal logentry As cLogEntry)

    Public Sub New()
        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        AddHandler log.eventLogItemAdded, AddressOf updateLvLog
    End Sub

    Private Sub frmServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim batch As New cbatchScan
        Dim t As New Threading.Thread(AddressOf batch.startScan)

        t.Name = "batch Thread"
        t.Start()
    End Sub

    Private Sub updateLvLog(ByVal logEntry As cLogEntry)
        If Me.InvokeRequired Then
            Dim updater As New dgUpdateLvLog(AddressOf updateLvLog)
            Me.BeginInvoke(updater, New Object() {logEntry})
        Else
            Me.lbServerLog.Items.Add(logEntry.getFormattedEntry)
        End If
    End Sub
End Class