' cette classe est la bonne
' le leak semble fortement maitrisé ...

Public Class cCommentaireDisplayList
    Private _dicIdsComments As New Dictionary(Of Integer, Integer)
    Private _panel As TableLayoutPanel
    Private _bEditing As Boolean ' vrai si en cours d'édition d'un commentaire
    Private _bLoaded As Boolean ' vrai si commentaires ont été chargés
    Private _toolTip As ToolTip

    Public ReadOnly Property bediting() As Boolean
        Get
            Return _bEditing
        End Get
    End Property
    Public ReadOnly Property bLoaded() As Boolean
        Get
            Return _bLoaded
        End Get
    End Property

    Public Sub New(ByRef panel As DBTableLayoutPanel)
        _panel = panel
    End Sub

    Public Sub displayComment(ByRef listOfCommentaires As List(Of cCommentaire))
        _bLoaded = True

        Dim nbComments As Integer = listOfCommentaires.Count

        ' ToolTips
        _toolTip = New ToolTip
        With _toolTip
            .AutoPopDelay = 5000
            .InitialDelay = 500
            .ReshowDelay = 500
        End With

        Dim counter As Integer = 0
        For Each c As cCommentaire In listOfCommentaires
            _dicIdsComments.Add(counter, c.id)
            counter += 1
        Next

        Dim aControl((nbComments * 2) - 1) As Control ' tableau de controles à ajouter

        For i = 0 To nbComments - 1

            ' Ajoute panel controles
            Dim panelControls As New FlowLayoutPanel
            With panelControls
                .Dock = DockStyle.Fill
                .Height = 30
                .BorderStyle = BorderStyle.Fixed3D
                .BackColor = Color.Lavender
                .FlowDirection = FlowDirection.LeftToRight
                .Name = String.Format("{0}_panelControls", i)
                .Margin = New Padding(0)
                .Tag = i
            End With

            Dim btEdit As New Button
            Dim btErase As New Button
            Dim btSave As New Button
            Dim userDateInfo As New Label

            With userDateInfo
                .Name = String.Format("{0}_userDateInfo", i)
                .TextAlign = ContentAlignment.MiddleCenter
                .Padding = New Padding(0, 5, 0, 5)
                .Font = New Font("Tahoma", 9.0!, FontStyle.Bold)
                .AutoSize = False
                .Size = New Size(300, 28)
                .BackColor = Color.Transparent
                .Text = listOfCommentaires(i).user & "  " & listOfCommentaires(i).dtDate.ToLongDateString
            End With
            With btEdit
                .Name = String.Format("{0}_btEdit", i)
                .Tag = i
                .BackColor = Color.White
                .BackgroundImage = Global.My.Resources.clipboard_edit
                .BackgroundImageLayout = ImageLayout.Stretch
                .Size = New System.Drawing.Size(27, 27)
                .Margin = New Padding(1, 0, 1, 0)
                .Padding = New Padding(0)
            End With
            With btErase
                .Name = String.Format("{0}_btErase", i)
                .Tag = i
                .BackColor = Color.White
                .BackgroundImage = Global.My.Resources.delete
                .BackgroundImageLayout = ImageLayout.Stretch
                .Size = New System.Drawing.Size(27, 27)
                .Margin = New Padding(1, 0, 1, 0)
                .Padding = New Padding(0)
            End With
            With btSave
                .Name = String.Format("{0}_btSave", i)
                .Tag = i
                .BackColor = Color.White
                .BackgroundImage = Global.My.Resources.save32
                .BackgroundImageLayout = ImageLayout.Stretch
                .Size = New System.Drawing.Size(27, 27)
                .Margin = New Padding(1, 0, 1, 0)
                .Padding = New Padding(0)
                .Enabled = False
            End With
            panelControls.SuspendLayout()
            With panelControls.Controls
                .Add(userDateInfo)
                .Add(btEdit)
                .Add(btErase)
                .Add(btSave)
            End With
            panelControls.ResumeLayout()
            ' bulles
            With _toolTip
                .SetToolTip(btEdit, "Editer")
                .SetToolTip(btSave, "Sauver")
                .SetToolTip(btErase, "Effacer")
            End With

            aControl(i * 2) = panelControls

            Dim rtb As New RichTextBox
            With rtb
                .Dock = DockStyle.Fill
                .BorderStyle = BorderStyle.Fixed3D
                .ReadOnly = True
                .WordWrap = True
                .Name = String.Format("{0}_rtbComment", i)
                .Tag = i
                .Text = listOfCommentaires(i).texte
                .AcceptsTab = True
                '.Height = (rtb.GetLineFromCharIndex(rtb.Text.Length) + 1) * rtb.Font.Height + 1 + rtb.Margin.Vertical
                .Height = (rtb.Lines.Count + 1) * rtb.Font.Height + 1 + rtb.Margin.Vertical
                .Margin = New Padding(0)
            End With

            AddHandler rtb.LinkClicked, AddressOf Link_Clicked

            aControl(i * 2 + 1) = rtb

            AddHandler btEdit.Click, AddressOf btClickHandler
            AddHandler btErase.Click, AddressOf btClickHandler
            AddHandler btSave.Click, AddressOf btClickHandler
            AddHandler rtb.TextChanged, AddressOf rtb_TextChanged
            AddHandler rtb.Click, AddressOf rtb_click
        Next

        With _panel
            .Hide()
            .SuspendLayout()
            .Controls.AddRange(aControl)
            .ResumeLayout()
            .Show()
        End With
    End Sub

    Public Sub dispose()
        If _bLoaded Then
            _panel.SuspendLayout()

            _toolTip.RemoveAll()
            _toolTip.Dispose()
            _toolTip = Nothing

            For x = _panel.Controls.Count - 1 To 0 Step -1
                Dim c As Control = _panel.Controls(x)

                If TypeOf (c) Is FlowLayoutPanel Then
                    For i = c.Controls.Count - 1 To 0 Step -1
                        If TypeOf (c) Is Button Then
                            RemoveHandler c.Controls(i).Click, AddressOf btClickHandler
                        End If

                        c.Controls(i).Dispose()
                    Next
                    c.Dispose()
                    c = Nothing
                ElseIf TypeOf (c) Is RichTextBox Then
                    RemoveHandler CType(c, RichTextBox).LinkClicked, AddressOf Link_Clicked
                Else
                    RemoveHandler c.Click, AddressOf rtb_click
                    RemoveHandler c.TextChanged, AddressOf rtb_TextChanged

                    c.Dispose()
                    c = Nothing
                End If
            Next

            _panel.Controls.Clear()
            _panel.ResumeLayout()

            _bEditing = False
            _bLoaded = False
            _dicIdsComments.Clear()
        End If
    End Sub

    Private Function getCommentaireID(ByVal tag As Integer) As Integer
        Dim commentaireId As Integer

        Dim valueFind As Boolean = _dicIdsComments.TryGetValue(tag, commentaireId)

        If valueFind Then
            Return commentaireId
        Else
            Return Nothing
        End If
    End Function

    Private Sub btClickHandler(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim bt As Button = CType(sender, Button)
        Dim tag As Integer = CInt(bt.Tag)
        Dim btName As String = bt.Name.Split(CChar("_"))(1)

        Select Case btName
            Case "btEdit"
                commentEdit(tag, bt)
            Case "btErase"
                commentErase(tag)
            Case "btSave"
                commentSave(tag, bt)
        End Select

    End Sub

    Private Sub Link_Clicked(sender As Object,
                             e As System.Windows.Forms.LinkClickedEventArgs)

        Try
            System.Diagnostics.Process.Start(e.LinkText)
        Catch ex As Exception
            MsgBox(String.Format("Impossible d'ouvrir la ressource : {0},     Erreur : {1}", e.LinkText, ex.Message),
                   MsgBoxStyle.Exclamation
                   )
        End Try

    End Sub 'Link_Clicked

    Private Sub CommentErase(ByVal tag As Integer)
        If _bEditing Then
            MsgBox("Une opération d'édition est en cours ! ", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' confirmation
        Dim result As DialogResult
        result = MessageBox.Show("Etes vous sur ?", "Effacer commentaire", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = Windows.Forms.DialogResult.Yes Then
            Dim nbRows = cMysqlcommentaires.eraseCommentaire(getCommentaireID(tag))

            _panel.Controls.RemoveByKey(String.Format("{0}_panelControls", tag))
            _panel.Controls.RemoveByKey(String.Format("{0}_rtbComment", tag))
        Else
            Exit Sub
        End If
    End Sub

    Private Sub commentSave(ByVal tag As Integer, ByRef bt As Button)
        Dim textToUpdate As String = ""

        Dim rtb As RichTextBox = CType(_panel.Controls(String.Format("{0}_rtbComment", tag)), RichTextBox)
        textToUpdate = rtb.Text

        cMysqlcommentaires.updateCommentaire(textToUpdate, getCommentaireID(tag))

        bt.Enabled = False
        With rtb
            .ReadOnly = True
            .BackColor = SystemColors.Control
        End With

        ' remets bouton commentaire sur edit
        Dim btEdit As Button = CType(_panel.Controls.Find(String.Format("{0}_btEdit", tag), True)(0), Button)
        btEdit.BackgroundImage = Global.My.Resources.clipboard_edit
        _bEditing = False
    End Sub

    Private Sub commentEdit(ByVal tag As Integer, ByRef bt As Button)
        Static Dim savCommentaire As String = ""
 
        Dim rtb As RichTextBox = CType(_panel.Controls(String.Format("{0}_rtbComment", tag)), RichTextBox)
        Dim btSave As Button = CType(_panel.Controls.Find(String.Format("{0}_btSave", tag), True)(0), Button)

        If _bEditing Then
            If Not rtb.ReadOnly Then
                With rtb
                    .ReadOnly = True
                    .BackColor = SystemColors.Control
                    .Text = savCommentaire
                End With

                _bEditing = False
                ' bouton  annuler => Editer 
                bt.BackgroundImage = Global.My.Resources.clipboard_edit
                _toolTip.SetToolTip(bt, "Editer")

                btSave.Enabled = False
            Else
                MsgBox("Vous ne pouvez pas editer plusieurs commentaire à la fois ! ", MsgBoxStyle.Exclamation)
            End If

            Exit Sub
        End If

        _bEditing = True

        ' bouton  Editer => annuler
        bt.BackgroundImage = Global.My.Resources.arrow_undo
        _toolTip.SetToolTip(bt, "Annuler")

        ' active le rtb en écriture
        With rtb
            .ReadOnly = False
            .BackColor = Color.White
        End With

        ' sauve le commentaire avant édition
        savCommentaire = rtb.Text
    End Sub

    Private Sub rtb_click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim rtb As RichTextBox = CType(sender, RichTextBox)

        ' 
        If rtb.ReadOnly Then
            Dim frm As Form = program.frmMdiContainer.getActiveFrm()
            If TypeOf frm Is frmMain Then
                Dim frmMain As frmMain = CType(frm, frmMain)
                frmMain.LayoutPanelCommentaires.Focus()
            Else
                Throw New Exception("Tentative de mettre le focus sur un commentaire, mais le form en cours n'est pas celui attendu .... ")
            End If

            'program.frmMain.LayoutPanelCommentaires.Focus()
        End If

    End Sub

    Private Sub rtb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' redimensionnement du rtb
        Dim rtb As RichTextBox = CType(sender, RichTextBox)
        Dim tag As String = rtb.Tag.ToString
        'rtb.Height = (rtb.GetLineFromCharIndex(rtb.Text.Length) + 1) * rtb.Font.Height + 1 + rtb.Margin.Vertical
        rtb.Height = (rtb.Lines.Count + 1) * rtb.Font.Height + 1 + rtb.Margin.Vertical
        ' Le texte a changé => Active le bouton sauver 
        Dim bt As Button = CType(_panel.Controls.Find(String.Format("{0}_btSave", tag), True)(0), Button)
        bt.Enabled = True
    End Sub
End Class
