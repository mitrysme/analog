<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddFavoris
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
        Me.tbStationName = New System.Windows.Forms.TextBox
        Me.lbStationName = New System.Windows.Forms.Label
        Me.tbNote = New System.Windows.Forms.TextBox
        Me.LbNote = New System.Windows.Forms.Label
        Me.btnAjouter = New System.Windows.Forms.Button
        Me.btnAnnuler = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'tbStationName
        '
        Me.tbStationName.Location = New System.Drawing.Point(91, 12)
        Me.tbStationName.Name = "tbStationName"
        Me.tbStationName.ReadOnly = True
        Me.tbStationName.Size = New System.Drawing.Size(189, 20)
        Me.tbStationName.TabIndex = 0
        '
        'lbStationName
        '
        Me.lbStationName.AutoSize = True
        Me.lbStationName.Location = New System.Drawing.Point(12, 12)
        Me.lbStationName.Name = "lbStationName"
        Me.lbStationName.Size = New System.Drawing.Size(40, 13)
        Me.lbStationName.TabIndex = 1
        Me.lbStationName.Text = "Station"
        '
        'tbNote
        '
        Me.tbNote.Location = New System.Drawing.Point(91, 62)
        Me.tbNote.Multiline = True
        Me.tbNote.Name = "tbNote"
        Me.tbNote.Size = New System.Drawing.Size(189, 103)
        Me.tbNote.TabIndex = 2
        '
        'LbNote
        '
        Me.LbNote.AutoSize = True
        Me.LbNote.Location = New System.Drawing.Point(12, 62)
        Me.LbNote.Name = "LbNote"
        Me.LbNote.Size = New System.Drawing.Size(30, 13)
        Me.LbNote.TabIndex = 3
        Me.LbNote.Text = "Note"
        '
        'btnAjouter
        '
        Me.btnAjouter.Location = New System.Drawing.Point(124, 171)
        Me.btnAjouter.Name = "btnAjouter"
        Me.btnAjouter.Size = New System.Drawing.Size(75, 23)
        Me.btnAjouter.TabIndex = 4
        Me.btnAjouter.Text = "Ajouter"
        Me.btnAjouter.UseVisualStyleBackColor = True
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Location = New System.Drawing.Point(205, 171)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.btnAnnuler.TabIndex = 5
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = True
        '
        'frmAddFavoris
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 198)
        Me.Controls.Add(Me.btnAnnuler)
        Me.Controls.Add(Me.btnAjouter)
        Me.Controls.Add(Me.LbNote)
        Me.Controls.Add(Me.tbNote)
        Me.Controls.Add(Me.lbStationName)
        Me.Controls.Add(Me.tbStationName)
        Me.Name = "frmAddFavoris"
        Me.Text = "Ajouter Favoris"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbStationName As System.Windows.Forms.TextBox
    Friend WithEvents lbStationName As System.Windows.Forms.Label
    Friend WithEvents tbNote As System.Windows.Forms.TextBox
    Friend WithEvents LbNote As System.Windows.Forms.Label
    Friend WithEvents btnAjouter As System.Windows.Forms.Button
    Friend WithEvents btnAnnuler As System.Windows.Forms.Button
End Class
