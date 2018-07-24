Public Class frmSmart
    Private _driveId As String '  disque pour lequel les données SMART doivent etre affichées
    Public Delegate Sub degUpdateItems(ByRef smart As wmiSmart.SMART, ByVal errMessage As String) ' delegate pour update données SMART
    Private Delegate Sub degSetProgressBarVisible(ByVal bool As Boolean)
    Private WithEvents _smart As wmiSmart

    Public Sub New(ByVal driveId As String,
                   ByVal smart As wmiSmart,
                   ByVal stationName As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.x
        Me.CenterToParent()
        Me.Text = String.Format("Analog : {0} - Données SMART", stationName)
        _smart = smart
        _driveId = driveId
    End Sub

    Private Sub frmLoad() Handles Me.Load
        _smart.updateSmartLvAsync(Me.LvSmart, New degUpdateItems(AddressOf updateItems), _driveId)
        Me.frmSmartProgressBar.Visible = True
        Me.LvSmart.FullRowSelect = True
    End Sub

    ''' <summary>
    ''' Mise à jour listView
    ''' </summary>
    ''' <param name="smart"></param>
    ''' <param name="errMessage"></param>
    ''' <remarks>
    ''' TODO
    ''' Serait bien de fermer le form automatiquement après affichage du msg erreur mais 
    ''' control.invoke plante dans wmiSmart ( control = nothing .... )
    '''</remarks>
    Private Sub updateItems(ByRef smart As wmiSmart.SMART, ByVal errMessage As String)
        If errMessage <> String.Empty Then
            MsgBox(errMessage, MsgBoxStyle.Exclamation)
            Me.frmSmartProgressBar.Visible = False
            Exit Sub
        End If

        ' SMART Failure Predict STATUS
        tbSmartFailurePredictStatus.Text = _smart.smartFailurePredictStatusAsString(_driveId)

        If tbSmartFailurePredictStatus.Text = "KO" Then
            tbSmartFailurePredictStatus.BackColor = Color.Red
        ElseIf tbSmartFailurePredictStatus.Text = "OK" Then
            tbSmartFailurePredictStatus.BackColor = Color.LightGreen
        End If

        ' Maj du ListView
        ' TODO => très moche
        Dim arrayListViewItem() As System.Windows.Forms.ListViewItem
        ReDim arrayListViewItem(10)

        Dim LVIRawReadErrorRate As New ListViewItem("(01) ReadErrorRate")
        LVIRawReadErrorRate.Tag = "01"
        LVIRawReadErrorRate.SubItems.Add(smart.RawReadErrorRate.value.ToString)
        LVIRawReadErrorRate.SubItems.Add(smart.RawReadErrorRate.worst.ToString)
        LVIRawReadErrorRate.SubItems.Add(smart.RawReadErrorRate.threshold.ToString)

        Dim LVIReallocatedSectorCount As New ListViewItem("(05) ReallocatedSectorCount")
        LVIReallocatedSectorCount.Tag = "05"
        LVIReallocatedSectorCount.SubItems.Add(smart.ReallocatedSectorCount.value.ToString)
        LVIReallocatedSectorCount.SubItems.Add(smart.ReallocatedSectorCount.worst.ToString)
        LVIReallocatedSectorCount.SubItems.Add(smart.ReallocatedSectorCount.threshold.ToString)

        Dim LVISeekErrorRate As New ListViewItem("(07) SeekErrorRate")
        LVISeekErrorRate.Tag = "07"
        LVISeekErrorRate.SubItems.Add(smart.SeekErrorRate.value.ToString)
        LVISeekErrorRate.SubItems.Add(smart.SeekErrorRate.worst.ToString)
        LVISeekErrorRate.SubItems.Add(smart.SeekErrorRate.threshold.ToString)

        Dim LVISpinRetryCount As New ListViewItem("(10) SpinRetryCount")
        LVISpinRetryCount.Tag = "10"
        LVISpinRetryCount.SubItems.Add(smart.SpinRetryCount.value.ToString)
        LVISpinRetryCount.SubItems.Add(smart.SpinRetryCount.worst.ToString)
        LVISpinRetryCount.SubItems.Add(smart.SpinRetryCount.threshold.ToString)

        Dim LVIEndtoEndError As New ListViewItem("(184) EndtoEndError")
        LVIEndtoEndError.Tag = "184"
        LVIEndtoEndError.SubItems.Add(smart.EndToEndError.value.ToString)
        LVIEndtoEndError.SubItems.Add(smart.EndToEndError.worst.ToString)
        LVIEndtoEndError.SubItems.Add(smart.EndToEndError.threshold.ToString)

        Dim LVICommandTimeout As New ListViewItem("(188) CommandTimeout")
        LVICommandTimeout.Tag = "188"
        LVICommandTimeout.SubItems.Add(smart.CommandTimeout.value.ToString)
        LVICommandTimeout.SubItems.Add(smart.CommandTimeout.worst.ToString)
        LVICommandTimeout.SubItems.Add(smart.CommandTimeout.threshold.ToString)

        Dim LVITemperature As New ListViewItem("(194) Temperature")
        LVITemperature.Tag = "194"
        LVITemperature.SubItems.Add(smart.Temperature.value.ToString)
        LVITemperature.SubItems.Add(smart.Temperature.worst.ToString)
        LVITemperature.SubItems.Add(smart.Temperature.threshold.ToString)

        Dim LVIHardwareECCRecovered As New ListViewItem("(195) HardwareECCRecovered")
        LVIHardwareECCRecovered.Tag = "195"
        LVIHardwareECCRecovered.SubItems.Add(smart.HardwareECCRecovered.value.ToString)
        LVIHardwareECCRecovered.SubItems.Add(smart.HardwareECCRecovered.worst.ToString)
        LVIHardwareECCRecovered.SubItems.Add(smart.HardwareECCRecovered.threshold.ToString)

        Dim LVIReallocationEventCount As New ListViewItem("(196) ReallocationEventCount")
        LVIReallocationEventCount.Tag = "196"
        LVIReallocationEventCount.SubItems.Add(smart.ReallocationEventCount.value.ToString)
        LVIReallocationEventCount.SubItems.Add(smart.ReallocationEventCount.worst.ToString)
        LVIReallocationEventCount.SubItems.Add(smart.ReallocationEventCount.threshold.ToString)

        Dim LVICurrentPendingSectorCount As New ListViewItem("(197) CurrentPendingSectorCount")
        LVICurrentPendingSectorCount.Tag = "197"
        LVICurrentPendingSectorCount.SubItems.Add(smart.CurrentPendingSectorCount.value.ToString)
        LVICurrentPendingSectorCount.SubItems.Add(smart.CurrentPendingSectorCount.worst.ToString)
        LVICurrentPendingSectorCount.SubItems.Add(smart.CurrentPendingSectorCount.threshold.ToString)

        Dim LVIOfflineScanUncorrectableSectorCount As New ListViewItem("(198) OfflineScanUncorrectableSectorCount")
        LVIOfflineScanUncorrectableSectorCount.Tag = "198"
        LVIOfflineScanUncorrectableSectorCount.SubItems.Add(smart.OfflineScanUncorrectableSectorCount.value.ToString)
        LVIOfflineScanUncorrectableSectorCount.SubItems.Add(smart.OfflineScanUncorrectableSectorCount.worst.ToString)
        LVIOfflineScanUncorrectableSectorCount.SubItems.Add(smart.OfflineScanUncorrectableSectorCount.threshold.ToString)

        arrayListViewItem(0) = LVIRawReadErrorRate
        arrayListViewItem(1) = LVIReallocatedSectorCount
        arrayListViewItem(2) = LVISeekErrorRate
        arrayListViewItem(3) = LVISpinRetryCount
        arrayListViewItem(4) = LVIEndtoEndError
        arrayListViewItem(5) = LVICommandTimeout
        arrayListViewItem(6) = LVITemperature
        arrayListViewItem(7) = LVIHardwareECCRecovered
        arrayListViewItem(8) = LVIReallocationEventCount
        arrayListViewItem(9) = LVICurrentPendingSectorCount
        arrayListViewItem(10) = LVIOfflineScanUncorrectableSectorCount

        Me.LvSmart.Items.AddRange(arrayListViewItem)

        Me.frmSmartProgressBar.Visible = False
    End Sub

    Private Sub lvSmartIndexchanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvSmart.SelectedIndexChanged
        If LvSmart.SelectedItems.Count > 0 Then
            If LvSmart.SelectedItems(0).Tag Is Nothing Then
                Me.rtbDetailParamSmart.Text = "NA"
                Exit Sub
            End If

            Dim tag As String = LvSmart.SelectedItems(0).Tag.ToString

            Select Case tag
                Case "01"
                    Me.rtbDetailParamSmart.Text = "*CRITIQUE* Indique le taux d’erreur matérielle lors de la lecture de la surface du disque." _
                    & vbNewLine & "Une valeur élevée indique un problème soit avec la surface du disque, soit avec les têtes de lecture/écriture."
                Case "05"
                    Me.rtbDetailParamSmart.Text = "*CRITIQUE* Nombre de secteurs réalloués. Quand le disque dur obtient une erreur de lecture/écriture/vérification sur un secteur," _
                    & vbNewLine & "il note ce secteur comme réalloué et transfère les données vers une zone réservée spéciale (la zone de réserve). " _
                    & vbNewLine & "Ce processus est aussi connu sous le nom de remapping et les secteurs réalloués sont appelés remaps. C’est pourquoi, sur les disques modernes, " _
                    & vbNewLine & "on ne peut pas voir de « mauvais » blocs lorsqu’on teste la surface du disque (tous les mauvais secteurs sont cachés dans les secteurs réalloués). " _
                    & vbNewLine & "Cependant, plus il y a de secteurs réalloués, plus la vitesse d’écriture/lecture diminue."
                Case "07"
                    Me.rtbDetailParamSmart.Text = "Taux d’erreurs d’accès des têtes magnétiques. S’il y a une défaillance du système de positionnement mécanique, " _
                    & vbNewLine & "un endommagement du servomécanisme ou une dilatation thermique du disque dur, le nombre d’erreurs de recherche augmente. " _
                    & vbNewLine & "Une augmentation du nombre d’erreurs d’accès indique que l’état de la surface du disque et le sous-système mécanique se dégradent."
                Case "10"
                    Me.rtbDetailParamSmart.Text = "Nombre d’essais de relancement de la rotation. Cet attribut stocke le nombre total d’essais de relancement de la rotation pour " _
                    & vbNewLine & "atteindre la pleine vitesse de fonctionnement (à condition que la 1re tentative soit un échec). Une augmentation de cet attribut est signe de " _
                    & vbNewLine & "problèmes au niveau du sous-système mécanique du disque dur."
                Case "184"
                    Me.rtbDetailParamSmart.Text = "NA"
                Case "188"
                    Me.rtbDetailParamSmart.Text = "NA"
                Case "194"
                    Me.rtbDetailParamSmart.Text = "Température interne actuelle."
                Case "195"
                    Me.rtbDetailParamSmart.Text = "Temps entre les erreurs corrigées par code correcteur (?) (augmente et diminue, une faible valeur est probablement mauvais)."
                Case "196"
                    Me.rtbDetailParamSmart.Text = "CRITIQUE* Nombre d’opérations de réallocation (remap). La valeur brute de cet attribut est le nombre total de tentatives de transfert" _
                    & vbNewLine & "de données entre un secteur réalloué et un secteur de réserve. Les essais fructueux et les échecs sont tous comptés au même titre."
                Case "197"
                    Me.rtbDetailParamSmart.Text = "*CRITIQUE* Nombre de secteurs « instables » (en attente de réallocation). Quand des secteurs instables sont lus avec succès," _
                    & vbNewLine & "cette valeur est diminuée. Si des erreurs se produisent à la lecture d’un secteur, le disque va tenter de récupérer les données, puis de les" _
                    & vbNewLine & "transférer vers la zone de réserve et va marquer le secteur comme réalloué."
                Case "198"
                    Me.rtbDetailParamSmart.Text = "*CRITIQUE* Nombre total d’erreurs incorrigibles à la lecture/écriture d’un secteur. Une augmentation de cette valeur indique des défauts" _
                    & vbNewLine & "de la surface du disque et/ou des problèmes avec le sous-système mécanique."
                Case Else
                    Me.rtbDetailParamSmart.Text = "NA"
            End Select

        End If

    End Sub


End Class