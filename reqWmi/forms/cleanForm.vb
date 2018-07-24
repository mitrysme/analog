Imports System.Threading

Public Class cleanForm

    Private _cleanStation As CleanStation
    Private _threadclean As Thread
    Private _stationName As String ' nom de la station à nettoyer 

    Delegate Sub logWriterCallBack(ByVal text As String)
    Delegate Sub logProcessingFileCallBack(ByVal processingFile As String)
    Delegate Sub logProgressChangedCallBack()
    Delegate Sub logProcessingProfilCallBack(ByVal profil As String)
    Delegate Sub closeFormCallBack()
    Delegate Sub showDialogOnGuiThreadCallBack(ByVal text As String)
    Delegate Sub setProgressBarMaxValueCallBack(ByVal value As Integer)
    Delegate Sub processingErrorCallBack(ByVal msg As String)

    Public ReadOnly Property busy() As Boolean
        Get
            Return isThreadBusy()
        End Get
    End Property

    Public Sub frm_load() Handles Me.Load
        Me.CenterToParent()
    End Sub

    Public Sub New(ByVal stationName As String, _
                   ByVal osVersion As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _stationName = stationName


        If String.Compare(osVersion, "5.1.2600") = 0 Then
            _cleanStation = New CleanStation(_stationName)
        Else
            _cleanStation = New cleanStationWin7(_stationName)
        End If

        '
        Me.Text = String.Format("Nettoyage : {0}", _stationName)
        Me.Name = String.Format("cleanfrm_{0}", _stationName)
        Me.tlstripStatus.Spring = True
        Me.btnAbortClean.Enabled = False
        Me.txtbStation.Text = _cleanStation.station
        Me.progressBar.Value = 0
        Me.progressBar.Minimum = 0
        Me.progressBar.Maximum = 0
    End Sub

    Private Function isThreadBusy() As Boolean
        If _threadclean Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnStartClean_Click(ByVal sender As Object,
                                    ByVal e As System.EventArgs) Handles btnStartClean.Click

        Dim mode As String = CType(sender, Button).Text

        If mode = "Démarrer" Then
            btnStartClean.Text = "Suspendre"
            btnAbortClean.Enabled = True

            AddHandler _cleanStation.finishedCleaning, AddressOf FinishedCleaningEventHandler
            AddHandler _cleanStation.unableToDeleteFile, AddressOf unableToDeleteFileEventHandler
            AddHandler _cleanStation.processingFile, AddressOf processingFileEventHandler
            AddHandler _cleanStation.progressChanged, AddressOf progressChangedEventHandler
            AddHandler _cleanStation.ProcessingProfil, AddressOf processingProfilEventHandler
            AddHandler _cleanStation.setProgressBarMaxValue, AddressOf setProgressBarMaxValueEventHandler
            AddHandler _cleanStation.processingError, AddressOf processingErrorHandler

            _threadclean = New Thread(AddressOf _cleanStation.deleteTempFilesFromAllProfiles)
            'threadclean.IsBackground = True ' devrait tuer le thread si fermeture du programme et nettoyage en cours 
            _threadclean.Name = "Thread clean"
            _threadclean.Start()
        ElseIf mode = "Suspendre" Then
            btnStartClean.Text = "Reprendre"
            If _threadclean.ThreadState = ThreadState.Running Then
                _threadclean.Suspend()
            End If
        ElseIf mode = "Reprendre" Then
            btnStartClean.Text = "Suspendre"
            If _threadclean.ThreadState = ThreadState.Suspended Then
                _threadclean.Resume()
            End If
        End If
    End Sub

    Private Sub btnAbortClean_Click(ByVal sender As System.Object,
                                    ByVal e As System.EventArgs) Handles btnAbortClean.Click
        Try
            _threadclean.Abort()
        Catch ex As ThreadStateException
            ' une exception est levée si on essaie abort sur un thread suspended
        Finally
            _threadclean = Nothing
            MsgBox("Opération abandonnée")
            Me.closeFormHandler()
        End Try
    End Sub

    ' exécuté dans le thread "thread clean" => invoke nécessaire
    Private Sub unableToDeleteFileEventHandler(ByVal file As String)
        If Me.InvokeRequired Then
            Dim logWriter As New logWriterCallBack(AddressOf unableToDeleteFileEventHandler)
            Me.Invoke(logWriter, New Object() {file})
        Else
            Me.lstCleanLog.Items.Add("impossible effacer : " & file)
        End If
    End Sub

    ' exécuté dans le thread "thread clean" => invoke nécessaire
    Private Sub processingFileEventHandler(ByVal processingFile As String)
        If Me.InvokeRequired Then
            Dim processingFileWriter As New logWriterCallBack(AddressOf processingFileEventHandler)
            Me.Invoke(processingFileWriter, New Object() {processingFile})
        Else
            Me.txtProcessingFile.Text = processingFile
        End If
    End Sub

    ' exécuté dans le thread "thread clean" => invoke nécessaire
    Private Sub progressChangedEventHandler()
        If Me.InvokeRequired Then
            Dim progressChangedWriter As New logProgressChangedCallBack(AddressOf progressChangedEventHandler)
            Me.Invoke(progressChangedWriter)
        Else
            Me.progressBar.Value += 1
        End If
    End Sub

    ' exécuté dans le thread "thread clean" => invoke nécessaire
    Private Sub processingProfilEventHandler(ByVal profil As String)
        If Me.InvokeRequired Then
            Dim processingProfilWriter As New logProcessingProfilCallBack(AddressOf processingProfilEventHandler)
            Me.Invoke(processingProfilWriter, New Object() {profil})
        Else
            Me.txtProfil.Text = profil
        End If
    End Sub

    ' traitement terminé affiche résultat  
    Private Sub FinishedCleaningEventHandler(ByVal processingSummaryInfos As Hashtable)
        Dim text As String = ""
        text += "Traitement " & _cleanStation.station & " terminé"
        text += vbCrLf & vbCrLf
        text += "Profils traités : " & processingSummaryInfos("nbProfils").ToString()
        text += vbCrLf
        text += "Fichiers effacés : " & processingSummaryInfos("nbDeletedFiles").ToString()
        text += vbCrLf
        text += "Fichiers non effacés : " & processingSummaryInfos("nbUnabletoDeleteFiles").ToString()

        MessageBox.Show(text, "Nettoyage", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification, False)

        ' Me.showDialogOnGuiThread(text)
        If _threadclean.IsAlive Then _threadclean = Nothing

        Me.closeFormHandler()
    End Sub

    Private Sub setProgressBarMaxValueEventHandler(ByVal value As Integer)
        If Me.InvokeRequired Then
            Dim ProgressBarMaxValueWriter As New setProgressBarMaxValueCallBack(AddressOf setProgressBarMaxValueEventHandler)
            Me.Invoke(ProgressBarMaxValueWriter, New Object() {value})
        Else
            Me.progressBar.Maximum = value
        End If
    End Sub

    ''' <summary>
    ''' Affiche Msg d'erreur si problème pendant cleanage
    ''' </summary>
    ''' <param name="msg">texte message erreur</param>
    ''' <remarks></remarks>
    Private Sub processingErrorHandler(ByVal msg As String)
        If Me.InvokeRequired Then
            Dim processingError As New processingErrorCallBack(AddressOf processingErrorHandler)
            Me.Invoke(processingError, New Object() {msg})
        Else
            MessageBox.Show(msg, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '@todo nécessaire ???
            If Not _threadclean Is Nothing Then
                If _threadclean.IsAlive Then _threadclean = Nothing
            End If

            Me.closeFormHandler()
        End If
    End Sub

    ''' <summary>
    ''' affiche les résultats du scan dans le thread GUI
    ''' si exécuté dans autre thread => non modal ..
    ''' </summary>
    ''' <param name="text">text à afficher</param>
    ''' <remarks></remarks>
    Private Sub showDialogOnGuiThread(ByVal text As String)
        If Me.InvokeRequired Then
            Dim showDialog As New showDialogOnGuiThreadCallBack(AddressOf showDialogOnGuiThread)
            Me.Invoke(showDialog, New Object() {text})
        Else
            MessageBox.Show(text, "Nettoyage", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification, False)
        End If
    End Sub

    Private Sub closeFormHandler()
        If Me.InvokeRequired Then
            Dim closeForm As New closeFormCallBack(AddressOf closeFormHandler)
            Me.Invoke(closeForm)
        Else
            Me.Close()
        End If
    End Sub

    ''' <summary>
    '''  Fermeture du formulaire
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cleanForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' si le thread est encore vivant et qu'il n'est pas en attente d'annulation
        ' on empêche la fermeture du formulaire
        ' TODO => donner la possibilité d'interrompre le traitement
        If Not _threadclean Is Nothing Then
            MsgBox("Nettoyage en cours, fermeture impossible...", MsgBoxStyle.Exclamation)
            e.Cancel = True
        Else
            RemoveHandler _cleanStation.finishedCleaning, AddressOf FinishedCleaningEventHandler
            RemoveHandler _cleanStation.unableToDeleteFile, AddressOf unableToDeleteFileEventHandler
            RemoveHandler _cleanStation.processingFile, AddressOf processingFileEventHandler
            RemoveHandler _cleanStation.progressChanged, AddressOf progressChangedEventHandler
            RemoveHandler _cleanStation.ProcessingProfil, AddressOf processingProfilEventHandler
            RemoveHandler _cleanStation.setProgressBarMaxValue, AddressOf setProgressBarMaxValueEventHandler
            RemoveHandler _cleanStation.processingError, AddressOf processingErrorHandler
        End If
    End Sub
End Class