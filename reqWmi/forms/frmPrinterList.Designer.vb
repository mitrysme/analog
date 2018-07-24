<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrinterList
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ProgressBarPrinter = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvPrinterList = New System.Windows.Forms.DataGridView()
        Me.tbCurrentProfile = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvPrinterList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tbCurrentProfile)
        Me.Panel1.Controls.Add(Me.ProgressBarPrinter)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(441, 38)
        Me.Panel1.TabIndex = 0
        '
        'ProgressBarPrinter
        '
        Me.ProgressBarPrinter.Location = New System.Drawing.Point(3, 9)
        Me.ProgressBarPrinter.Name = "ProgressBarPrinter"
        Me.ProgressBarPrinter.Size = New System.Drawing.Size(48, 23)
        Me.ProgressBarPrinter.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBarPrinter.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(195, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Profil :"
        '
        'dgvPrinterList
        '
        Me.dgvPrinterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrinterList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrinterList.Location = New System.Drawing.Point(0, 38)
        Me.dgvPrinterList.Name = "dgvPrinterList"
        Me.dgvPrinterList.Size = New System.Drawing.Size(441, 266)
        Me.dgvPrinterList.TabIndex = 1
        '
        'tbCurrentProfile
        '
        Me.tbCurrentProfile.Location = New System.Drawing.Point(237, 6)
        Me.tbCurrentProfile.Name = "tbCurrentProfile"
        Me.tbCurrentProfile.ReadOnly = True
        Me.tbCurrentProfile.Size = New System.Drawing.Size(191, 20)
        Me.tbCurrentProfile.TabIndex = 3
        '
        'frmPrinterList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 304)
        Me.Controls.Add(Me.dgvPrinterList)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmPrinterList"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvPrinterList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvPrinterList As DataGridView
    Friend WithEvents ProgressBarPrinter As ProgressBar
    Friend WithEvents tbCurrentProfile As TextBox
End Class
