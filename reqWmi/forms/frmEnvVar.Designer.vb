<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnvVar
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
        Me.lvEnvVar = New System.Windows.Forms.ListView
        Me.ColumnHeaderVariable = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderValue = New System.Windows.Forms.ColumnHeader
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvEnvVar
        '
        Me.lvEnvVar.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderVariable, Me.ColumnHeaderValue})
        Me.lvEnvVar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvEnvVar.Location = New System.Drawing.Point(0, 0)
        Me.lvEnvVar.Name = "lvEnvVar"
        Me.lvEnvVar.Size = New System.Drawing.Size(634, 371)
        Me.lvEnvVar.TabIndex = 0
        Me.lvEnvVar.UseCompatibleStateImageBehavior = False
        Me.lvEnvVar.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderVariable
        '
        Me.ColumnHeaderVariable.Text = "Variable"
        Me.ColumnHeaderVariable.Width = 92
        '
        'ColumnHeaderValue
        '
        Me.ColumnHeaderValue.Text = "Valeur"
        Me.ColumnHeaderValue.Width = 208
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 349)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(634, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ToolStripProgressBar.Visible = False
        '
        'frmEnvVar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 371)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lvEnvVar)
        Me.Name = "frmEnvVar"
        Me.Text = "frmEnvVar"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvEnvVar As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeaderVariable As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
End Class
