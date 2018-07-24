<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSmart
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.frmSmartStatusStrip = New System.Windows.Forms.StatusStrip
        Me.frmSmartProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbSmartFailurePredictStatus = New System.Windows.Forms.TextBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.LvSmart = New baseLv
        Me.ID = New System.Windows.Forms.ColumnHeader
        Me.Valeur = New System.Windows.Forms.ColumnHeader
        Me.Pire = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderSeuil = New System.Windows.Forms.ColumnHeader
        Me.rtbDetailParamSmart = New System.Windows.Forms.RichTextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.frmSmartStatusStrip.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'frmSmartStatusStrip
        '
        Me.frmSmartStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.frmSmartProgressBar})
        Me.frmSmartStatusStrip.Location = New System.Drawing.Point(0, 334)
        Me.frmSmartStatusStrip.Name = "frmSmartStatusStrip"
        Me.frmSmartStatusStrip.Size = New System.Drawing.Size(412, 22)
        Me.frmSmartStatusStrip.TabIndex = 1
        Me.frmSmartStatusStrip.Text = "StatusStrip1"
        '
        'frmSmartProgressBar
        '
        Me.frmSmartProgressBar.Name = "frmSmartProgressBar"
        Me.frmSmartProgressBar.Size = New System.Drawing.Size(100, 16)
        Me.frmSmartProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.frmSmartProgressBar.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SMART :"
        '
        'tbSmartFailurePredictStatus
        '
        Me.tbSmartFailurePredictStatus.Location = New System.Drawing.Point(65, 6)
        Me.tbSmartFailurePredictStatus.Name = "tbSmartFailurePredictStatus"
        Me.tbSmartFailurePredictStatus.Size = New System.Drawing.Size(26, 20)
        Me.tbSmartFailurePredictStatus.TabIndex = 3
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 32)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.LvSmart)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.rtbDetailParamSmart)
        Me.SplitContainer1.Size = New System.Drawing.Size(412, 299)
        Me.SplitContainer1.SplitterDistance = 210
        Me.SplitContainer1.TabIndex = 4
        '
        'LvSmart
        '
        Me.LvSmart.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ID, Me.Valeur, Me.Pire, Me.ColumnHeaderSeuil})
        Me.LvSmart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvSmart.Location = New System.Drawing.Point(0, 0)
        Me.LvSmart.Name = "LvSmart"
        Me.LvSmart.Size = New System.Drawing.Size(412, 210)
        Me.LvSmart.TabIndex = 0
        Me.LvSmart.UseCompatibleStateImageBehavior = False
        Me.LvSmart.View = System.Windows.Forms.View.Details
        '
        'ID
        '
        Me.ID.Text = "ID"
        Me.ID.Width = 198
        '
        'Valeur
        '
        Me.Valeur.Text = "Valeur"
        Me.Valeur.Width = 89
        '
        'Pire
        '
        Me.Pire.Text = "Pire"
        '
        'ColumnHeaderSeuil
        '
        Me.ColumnHeaderSeuil.Text = "Seuil"
        '
        'rtbDetailParamSmart
        '
        Me.rtbDetailParamSmart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbDetailParamSmart.Location = New System.Drawing.Point(0, 0)
        Me.rtbDetailParamSmart.Name = "rtbDetailParamSmart"
        Me.rtbDetailParamSmart.Size = New System.Drawing.Size(412, 85)
        Me.rtbDetailParamSmart.TabIndex = 0
        Me.rtbDetailParamSmart.Text = ""
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.tbSmartFailurePredictStatus)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(412, 34)
        Me.Panel1.TabIndex = 5
        '
        'frmSmart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 356)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.frmSmartStatusStrip)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MaximizeBox = False
        Me.Name = "frmSmart"
        Me.Text = "frmSmart"
        Me.frmSmartStatusStrip.ResumeLayout(False)
        Me.frmSmartStatusStrip.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LvSmart As baseLv
    Friend WithEvents ID As System.Windows.Forms.ColumnHeader
    Friend WithEvents Valeur As System.Windows.Forms.ColumnHeader
    Friend WithEvents Pire As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderSeuil As System.Windows.Forms.ColumnHeader
    Friend WithEvents frmSmartStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents frmSmartProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbSmartFailurePredictStatus As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rtbDetailParamSmart As System.Windows.Forms.RichTextBox
End Class
