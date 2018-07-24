Imports structs.analogStructs

Public Class frmInfoLDAPUser

    Private _ldapWrapper As New ldapWrapper
    Private _user As String = String.Empty
    Private _cancel As Boolean = False
    Private _lock As New Object

    Private Delegate Sub degFrmUpdate(ByRef structLdapUser As StructLdapUser)
    Private Delegate Sub degToolTripProgressBar(ByVal b As Boolean)

    Public Property user() As String
        Get
            Return _user
        End Get
        Set(ByVal value As String)
            _user = value
        End Set
    End Property

    Private Sub frm_load() Handles Me.Load
        setWindowTitle()
        Me.CenterToParent()
    End Sub

    Private Sub setWindowTitle(Optional ByVal user As String = "")
        Me.Text = String.Format("Analog : Infos Utilisateur : {0}", user)
    End Sub

    Public Sub getUserInfosAsync()
        Me.reset()

        System.Threading.ThreadPool.QueueUserWorkItem(AddressOf getUserInfos)
    End Sub

    Private Sub setToolTripProgressVisible(ByVal b As Boolean)
        SyncLock _lock
            If Not _cancel Then
                If Me.InvokeRequired Then
                    Me.BeginInvoke(New degToolTripProgressBar(AddressOf setToolTripProgressVisible), b)
                Else
                    Me.ToolStripProgressBarLDAP.Visible = b
                End If
            End If
        End SyncLock
   
    End Sub

    ' raz du form
    Private Sub reset()
        Me.tbLdapUserSearch.Clear()
        Me.lvLDAPGroups.Items.Clear()
        clear(Me.TabUserLdapInfos.TabPages("tabUserInfos"))
    End Sub

    ' sur threadPool
    Private Sub getUserInfos()
        If Trim(_user) = String.Empty Then
            MsgBox("Utilisateur invalide")
            Exit Sub
        End If

        setToolTripProgressVisible(True)

        If _ldapWrapper.searchForLDAPUser(_user) Then
            Dim structLdapUser As New structs.analogStructs.StructLdapUser
            _ldapWrapper.getLdapUserAccountInfos(structLdapUser)

            SyncLock _lock
                If Not _cancel Then
                    Me.BeginInvoke(New degFrmUpdate(AddressOf frmUpdate), structLdapUser)
                End If
            End SyncLock
        Else
            MsgBox("Utilisateur non trouvé ! ", MsgBoxStyle.Exclamation)
        End If

        setToolTripProgressVisible(False)
    End Sub

    Private Sub closingHandler() Handles MyBase.FormClosing
        SyncLock _lock
            _cancel = True
        End SyncLock
    End Sub

    Private Sub frmUpdate(ByRef structLdapUser As StructLdapUser)
        setWindowTitle(_user)

        setUserLdapInfos(structLdapUser)
        setUserLdapgroups()
    End Sub

    Private Sub setUserLdapInfos(ByRef StructLdapUser As StructLdapUser)
        With StructLdapUser
            Me.tbLdapAccountComments.Text = .description
            Me.tbLdapAccountMail.Text = .mail
            Me.tbLdapAccountSN.Text = .sn
            Me.tbLdapAccountgivenName.Text = .givenName
            Me.tbLdapAccountFullName.Text = .name
            Me.tbLdapAccountLogonScriptPath.Text = .LogonScriptPath
            Me.tbLdapAccountSID.Text = .SID
            Me.tbLastLogonDateTime.Text = .lastLogonDate & " " & .lastLogonTime
            '
            ' options Compte
            '
            Me.cbDisabledAccount.Checked = .accountDisabled
            Me.cbExpiredPassword.Checked = .pwdExpired
            Me.cbUserCannotChangePassword.Checked = .cannotChangePassword
            Me.cbPasswordNeverExpire.Checked = .pwdNeverExpire
        End With
    End Sub

    Private Sub setUserLdapgroups()
        If Trim(_user) <> "" Then
            Dim groupList As New List(Of String)
            Dim errMsg As String = ""

            _ldapWrapper.getUserLDAPGroups(groupList, errMsg)
            updategroupItems(groupList)
        End If
    End Sub

    Private Sub updategroupItems(ByVal listOfGroups As List(Of String))
        For Each group As String In listOfGroups
            Dim name As String = ""
            Dim folder As String = ""

            ldapWrapper.parseStringLDAPGroupToNameAndFolder(group, name, folder)

            Dim LVI As New ListViewItem(name)
            LVI.SubItems.Add(folder)

            Me.lvLDAPGroups.Items.Add(LVI)
        Next
    End Sub

    Private Sub clear(ByRef ct As Control)
        For Each c As Control In ct.Controls
            If c.HasChildren Then
                clear(c)
            End If

            If TypeOf (c) Is TextBox Then
                Dim tb = CType(c, TextBox)
                tb.Clear()
            ElseIf TypeOf (c) Is CheckBox Then
                Dim cb = CType(c, CheckBox)
                cb.Checked = False
            End If
        Next

        Me.lvLDAPGroups.Items.Clear()
    End Sub

    ''' <summary>
    ''' détecte touche entrée au niveau form et lance la requete
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub analog_keyPressed(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            _ldapWrapper.razUser()
            _user = Me.tbLdapUserSearch.Text
            getUserInfosAsync()
        End If
    End Sub
End Class