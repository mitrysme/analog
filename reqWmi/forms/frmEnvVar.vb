Imports System.ComponentModel

Public Class frmEnvVar

    Private WithEvents _bw As BackgroundWorker
    Private _station As cstation

    Public Sub New(ByRef station As cstation)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _station = station
        Me.Text = String.Format("Analog : {0}  -  Variables d'environnement", _station.stationName)
    End Sub

    Private Sub frm_load() Handles Me.Load
        If Not _station.wmi.isConnected Then
            MsgBox("Vous n'êtes pas connecté", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If

        Me.CenterToParent()

        _bw = New BackgroundWorker
        _bw.WorkerSupportsCancellation = True

        Me.ToolStripProgressBar.Visible = True

        _bw.RunWorkerAsync()
    End Sub

    ''' <summary>
    ''' abandonne le worker si fermeture form pendant exécution
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub frm_closing() Handles MyBase.FormClosing
        If Not _bw Is Nothing Then
            _bw.CancelAsync()
        End If
    End Sub

    Private Sub bw_doWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles _bw.DoWork
        Dim environmentController As New wmi.Environment(_station.wmi)

        e.Result = environmentController.selectAll

        If _bw.CancellationPending Then e.Cancel = True
    End Sub

    Private Sub bw_workCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles _bw.RunWorkerCompleted
        If e.Cancelled Then
            Exit Sub
        End If

        Dim listOfEnvVar As List(Of wmi.Win32_Environment) = CType(e.Result, List(Of wmi.Win32_Environment))
        updateItems(listOfEnvVar)

        Me.ToolStripProgressBar.Visible = False

        _bw.Dispose()
    End Sub

    Private Sub updateItems(ByRef listOfEnvVar As List(Of wmi.Win32_Environment))
        Dim listOfListViewItem As New List(Of ListViewItem)

        If listOfEnvVar IsNot Nothing Then
            ' Classe win32_environment remonte +-  20 variables TEMP/TMP identiques .... hack pour corriger
            Dim oneTEMPVarOnly As Boolean = False
            Dim oneTMPVarOnly As Boolean = False

            For Each envVar In listOfEnvVar
                If envVar.Name = "TEMP" And oneTEMPVarOnly Then
                    Continue For
                ElseIf envVar.Name = "TMP" And oneTMPVarOnly Then
                    Continue For
                End If

                Dim LVI As New ListViewItem(envVar.Name)

                LVI.SubItems.Add(envVar.VariableValue.Replace("%SystemRoot%", _station.gInfoStation.windowsDirectory))
                listOfListViewItem.Add(LVI)

                If envVar.Name = "TEMP" Then oneTEMPVarOnly = True
                If envVar.Name = "TMP" Then oneTMPVarOnly = True
            Next

            Me.lvEnvVar.Items.AddRange(listOfListViewItem.ToArray)
        End If
    End Sub

End Class