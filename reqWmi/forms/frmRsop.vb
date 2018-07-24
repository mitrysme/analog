Public Class frmRsop
    Private _stationName As String
    Private _userName As String
    Private _cgpo As cGpo

    Private Delegate Sub degShowMessage(ByVal msg As String)
    Private Delegate Sub degWorkDone(ByVal dicGpoComputer As Dictionary(Of String, cGpo.structRsopGpo), _
                                  ByVal dicGpoUser As Dictionary(Of String, cGpo.structRsopGpo), _
                                  ByVal sLogonServer As String, _
                                  ByVal sComputerDN As String, _
                                  ByVal sUserDN As String)

    Public Sub New(ByVal stationName As String, ByVal userName As String)
        InitializeComponent()

        With Me.ToolStripProgressBar1
            .Visible = False
            .Style = ProgressBarStyle.Marquee
        End With

        With Me.mlTbRsop
            .ReadOnly = True
            .BackColor = Color.White
        End With
     
        Me.Text = "Analog : Stratégies de groupe"
     
        If stationName = String.Empty Then
            Me.Close()
            Exit Sub
        End If

        _stationName = stationName
        _userName = userName
        _cgpo = New cGpo(_stationName, _userName)

        AddHandler _cgpo.message, AddressOf showMessage
        AddHandler _cgpo.workDone, AddressOf workDone
    End Sub

    Public Sub frm_load() Handles Me.Load
        Me.CenterToParent()
        Me.ToolStripProgressBar1.Visible = True
        getGpoList()
    End Sub

    Private Sub getGpoList()
        Dim t As New Threading.Thread(AddressOf _cgpo.getGpoList)
        t.Start()
    End Sub

    Private Sub showMessage(ByVal msg As String)
        If Me.InvokeRequired Then
            Me.Invoke(New degShowMessage(AddressOf showMessage), msg)
        Else
            Me.mlTbRsop.Text += msg
            Me.mlTbRsop.Text += Environment.NewLine
        End If
    End Sub

    Private Sub workDone(ByVal dicGpoComputer As Dictionary(Of String, cGpo.structRsopGpo), _
                         ByVal dicGpoUser As Dictionary(Of String, cGpo.structRsopGpo), _
                         ByVal sLogonServer As String, _
                         ByVal sComputerDN As String, _
                         ByVal sUserDN As String)

        If Me.InvokeRequired Then
            Me.Invoke(New degWorkDone(AddressOf workDone), dicGpoComputer, dicGpoUser, sLogonServer, sComputerDN, sUserDN)
        Else
            '
            ' ----------------  Affichage Stratégies Computer --------------------------
            '
            With Me.mlTbRsop
                .Text += Environment.NewLine
                .Text += "Paramètre de l'ordinateur" & Environment.NewLine
                .Text += "-------------------------" & Environment.NewLine

                If Not sComputerDN Is Nothing Then
                    .Text += vbTab & sComputerDN & Environment.NewLine & Environment.NewLine
                End If
                If Not sLogonServer Is Nothing Then
                    .Text += vbTab & "LogonServer  : " & sLogonServer & Environment.NewLine & Environment.NewLine
                End If

                .Text += "Objets Stratégie de groupe appliqués" & Environment.NewLine
                .Text += "------------------------------------" & Environment.NewLine & Environment.NewLine

            End With

            '
            ' Objets stratégies appliqués
            '
            For Each i As KeyValuePair(Of String, cGpo.structRsopGpo) In dicGpoComputer
                If i.Value.enabled And i.Value.filterAllowed Then
                    Me.mlTbRsop.Text += String.Format("{0}{1}{2}", vbTab, i.Value.name, Environment.NewLine)
                End If
            Next

            '
            ' Objets stratégies refusés ( filtre WMI ... )
            '
            With Me.mlTbRsop
                .Text += Environment.NewLine
                .Text += "Les objets stratégie de groupe n'ont pas été appliqués car ils ont été refusés" & Environment.NewLine
                .Text += "------------------------------------" & Environment.NewLine & Environment.NewLine
            End With

            For Each i As KeyValuePair(Of String, cGpo.structRsopGpo) In dicGpoComputer
                If i.Value.enabled And Not i.Value.filterAllowed Then

                    Me.mlTbRsop.Text += String.Format("{0}{1}{2}", vbTab, i.Value.name, Environment.NewLine)
                    Me.mlTbRsop.Text += String.Format("{0}{0} Filtre OK : {1}{2}", vbTab, i.Value.filterAllowed.ToString, Environment.NewLine)
                    Me.mlTbRsop.Text += String.Format("{0}{0} Filtre WMI : {1}{2}", vbTab, i.Value.filterWmiDescription, Environment.NewLine)
                End If
            Next

            '
            '  Objets stratégies désactivés
            '
            With Me.mlTbRsop
                .Text += Environment.NewLine
                .Text += "Objets stratégie de groupe désactivés" & Environment.NewLine
                .Text += "------------------------------------" & Environment.NewLine & Environment.NewLine
            End With

            For Each i As KeyValuePair(Of String, cGpo.structRsopGpo) In dicGpoComputer
                If Not i.Value.enabled Then
                    Me.mlTbRsop.Text += String.Format("{0}{1}{2}", vbTab, i.Value.name, Environment.NewLine)
                End If
            Next


            '
            ' ----------------------  affichage stratégies User ----------------------------------
            '

            If Not dicGpoUser Is Nothing Then
                If dicGpoUser.Count > 0 Then
                    With Me.mlTbRsop
                        .Text += Environment.NewLine
                        .Text += "Paramètre de l'Utilisateur : " & _cgpo.userName & Environment.NewLine
                        .Text += "------------------------------------" & Environment.NewLine
                        If Not sUserDN Is Nothing Then
                            .Text += vbTab & sUserDN & Environment.NewLine
                        End If
                        .Text += Environment.NewLine
                        .Text += "Objets Stratégie de groupe appliqués" & Environment.NewLine
                        .Text += "------------------------------------" & Environment.NewLine & Environment.NewLine
                    End With

                    '
                    ' Objets stratégie appliqués
                    '
                    For Each i As KeyValuePair(Of String, cGpo.structRsopGpo) In dicGpoUser
                        If i.Value.enabled And i.Value.filterAllowed Then
                            Me.mlTbRsop.Text += String.Format("{0}{1}{2}", vbTab, i.Value.name, Environment.NewLine)
                        End If
                    Next

                    '
                    ' Objets stratégies refusés ( filtre WMI ... )
                    '
                    With Me.mlTbRsop
                        .Text += Environment.NewLine
                        .Text += "Les objets stratégie de groupe n'ont pas été appliqués car ils ont été refusés" & Environment.NewLine
                        .Text += "------------------------------------" & Environment.NewLine & Environment.NewLine
                    End With

                    For Each i As KeyValuePair(Of String, cGpo.structRsopGpo) In dicGpoUser
                        If i.Value.enabled And Not i.Value.filterAllowed Then
                            Me.mlTbRsop.Text += String.Format("{0}{1}{2}", vbTab, i.Value.name, Environment.NewLine)
                            Me.mlTbRsop.Text += String.Format("{0}{0} Filtre OK : {1}{2}", vbTab, i.Value.filterAllowed.ToString, Environment.NewLine)
                            Me.mlTbRsop.Text += String.Format("{0}{0} Filtre WMI : {1}{2}", vbTab, i.Value.filterWmiDescription, Environment.NewLine)
                        End If
                    Next

                    '
                    ' Objets stratégies désactivés ( filtre WMI ... )
                    '
                    With Me.mlTbRsop
                        .Text += Environment.NewLine
                        .Text += "Objets stratégie de groupe désactivés" & Environment.NewLine
                        .Text += "------------------------------------" & Environment.NewLine & Environment.NewLine
                    End With

                    For Each i As KeyValuePair(Of String, cGpo.structRsopGpo) In dicGpoUser
                        If Not i.Value.enabled Then
                            Me.mlTbRsop.Text += String.Format("{0}{1}{2}", vbTab, i.Value.name, Environment.NewLine)
                            Me.mlTbRsop.Text += String.Format("{0}{0} Filtre OK : {1}{2}", vbTab, i.Value.filterAllowed.ToString, Environment.NewLine)
                            Me.mlTbRsop.Text += String.Format("{0}{0} Filtre WMI : {1}{2}", vbTab, i.Value.filterWmiDescription, Environment.NewLine)
                        End If
                    Next

                    Me.mlTbRsop.Text += Environment.NewLine & Environment.NewLine

                End If
            End If

            Me.ToolStripProgressBar1.Visible = False
        End If

    End Sub

    Private Sub frm_close() Handles MyBase.FormClosing
        RemoveHandler _cgpo.message, AddressOf showMessage
        RemoveHandler _cgpo.workDone, AddressOf workDone
    End Sub

End Class