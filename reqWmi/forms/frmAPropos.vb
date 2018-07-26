Imports Analog.functions

Public Class frmAPropos
    Private Sub frmAPropos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        lblVersionName.Text = program.programVersion.ToString
        lbReleaseName.Text = program.releaseName
        lblContactURL.Text = program.preferences.sContactURL
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblContactURL.LinkClicked
        Dim link As LinkLabel = CType(sender, LinkLabel)
        Dim emailAddress As String = lblContactURL.Text
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLicense.Click
        Dim frmLicense = New License
        frmLicense.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOK.Click
        Me.Close()
    End Sub
End Class