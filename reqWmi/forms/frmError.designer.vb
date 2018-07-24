<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmError
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmError))
        Me.txtReport = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdQuit = New System.Windows.Forms.Button
        Me.cmdIgnore = New System.Windows.Forms.Button
        Me.btSend = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCommentaires = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtReport
        '
        Me.txtReport.Location = New System.Drawing.Point(12, 132)
        Me.txtReport.Multiline = True
        Me.txtReport.Name = "txtReport"
        Me.txtReport.ReadOnly = True
        Me.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReport.Size = New System.Drawing.Size(641, 136)
        Me.txtReport.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(641, 82)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'cmdQuit
        '
        Me.cmdQuit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdQuit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdQuit.Location = New System.Drawing.Point(532, 422)
        Me.cmdQuit.Name = "cmdQuit"
        Me.cmdQuit.Size = New System.Drawing.Size(121, 23)
        Me.cmdQuit.TabIndex = 4
        Me.cmdQuit.Text = "Fermer"
        Me.cmdQuit.UseVisualStyleBackColor = True
        '
        'cmdIgnore
        '
        Me.cmdIgnore.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdIgnore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdIgnore.Location = New System.Drawing.Point(452, 422)
        Me.cmdIgnore.Name = "cmdIgnore"
        Me.cmdIgnore.Size = New System.Drawing.Size(74, 23)
        Me.cmdIgnore.TabIndex = 6
        Me.cmdIgnore.Text = "Ignorer"
        Me.cmdIgnore.UseVisualStyleBackColor = True
        '
        'btSend
        '
        Me.btSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSend.Image = Global.My.Resources.Resources.up16
        Me.btSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btSend.Location = New System.Drawing.Point(15, 422)
        Me.btSend.Name = "btSend"
        Me.btSend.Size = New System.Drawing.Size(119, 23)
        Me.btSend.TabIndex = 7
        Me.btSend.Text = "Envoyer"
        Me.btSend.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Message d'erreur :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 276)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Commentaires : "
        '
        'txtCommentaires
        '
        Me.txtCommentaires.Location = New System.Drawing.Point(15, 299)
        Me.txtCommentaires.Multiline = True
        Me.txtCommentaires.Name = "txtCommentaires"
        Me.txtCommentaires.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCommentaires.Size = New System.Drawing.Size(638, 78)
        Me.txtCommentaires.TabIndex = 9
        '
        'frmError
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 457)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCommentaires)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btSend)
        Me.Controls.Add(Me.cmdIgnore)
        Me.Controls.Add(Me.cmdQuit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtReport)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmError"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "analog"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtReport As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdQuit As System.Windows.Forms.Button
    Friend WithEvents cmdIgnore As System.Windows.Forms.Button
    Friend WithEvents btSend As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCommentaires As System.Windows.Forms.TextBox

End Class
