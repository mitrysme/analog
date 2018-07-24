<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClearLogs
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
        Me.cbClearSystemLog = New System.Windows.Forms.CheckBox
        Me.cbClearApplicationLog = New System.Windows.Forms.CheckBox
        Me.btnClearLogsOK = New System.Windows.Forms.Button
        Me.btnClearLogsCancel = New System.Windows.Forms.Button
        Me.pbProcessApplicationLog = New System.Windows.Forms.PictureBox
        Me.pbProcessSystemLog = New System.Windows.Forms.PictureBox
        CType(Me.pbProcessApplicationLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbProcessSystemLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbClearSystemLog
        '
        Me.cbClearSystemLog.AutoSize = True
        Me.cbClearSystemLog.Checked = True
        Me.cbClearSystemLog.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbClearSystemLog.Location = New System.Drawing.Point(26, 9)
        Me.cbClearSystemLog.Name = "cbClearSystemLog"
        Me.cbClearSystemLog.Size = New System.Drawing.Size(118, 17)
        Me.cbClearSystemLog.TabIndex = 0
        Me.cbClearSystemLog.Text = "Effacer log systeme"
        Me.cbClearSystemLog.UseVisualStyleBackColor = True
        '
        'cbClearApplicationLog
        '
        Me.cbClearApplicationLog.AutoSize = True
        Me.cbClearApplicationLog.Checked = True
        Me.cbClearApplicationLog.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbClearApplicationLog.Location = New System.Drawing.Point(26, 32)
        Me.cbClearApplicationLog.Name = "cbClearApplicationLog"
        Me.cbClearApplicationLog.Size = New System.Drawing.Size(132, 17)
        Me.cbClearApplicationLog.TabIndex = 1
        Me.cbClearApplicationLog.Text = "Effacer log Application"
        Me.cbClearApplicationLog.UseVisualStyleBackColor = True
        '
        'btnClearLogsOK
        '
        Me.btnClearLogsOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearLogsOK.Location = New System.Drawing.Point(283, 62)
        Me.btnClearLogsOK.Name = "btnClearLogsOK"
        Me.btnClearLogsOK.Size = New System.Drawing.Size(81, 27)
        Me.btnClearLogsOK.TabIndex = 2
        Me.btnClearLogsOK.Text = "OK"
        Me.btnClearLogsOK.UseVisualStyleBackColor = True
        '
        'btnClearLogsCancel
        '
        Me.btnClearLogsCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearLogsCancel.Location = New System.Drawing.Point(202, 62)
        Me.btnClearLogsCancel.Name = "btnClearLogsCancel"
        Me.btnClearLogsCancel.Size = New System.Drawing.Size(81, 27)
        Me.btnClearLogsCancel.TabIndex = 3
        Me.btnClearLogsCancel.Text = "Abandonner"
        Me.btnClearLogsCancel.UseVisualStyleBackColor = True
        '
        'pbProcessApplicationLog
        '
        Me.pbProcessApplicationLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbProcessApplicationLog.Location = New System.Drawing.Point(241, 28)
        Me.pbProcessApplicationLog.Name = "pbProcessApplicationLog"
        Me.pbProcessApplicationLog.Size = New System.Drawing.Size(16, 21)
        Me.pbProcessApplicationLog.TabIndex = 5
        Me.pbProcessApplicationLog.TabStop = False
        '
        'pbProcessSystemLog
        '
        Me.pbProcessSystemLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbProcessSystemLog.Location = New System.Drawing.Point(241, 9)
        Me.pbProcessSystemLog.Name = "pbProcessSystemLog"
        Me.pbProcessSystemLog.Size = New System.Drawing.Size(16, 21)
        Me.pbProcessSystemLog.TabIndex = 4
        Me.pbProcessSystemLog.TabStop = False
        '
        'frmClearLogs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 91)
        Me.Controls.Add(Me.pbProcessApplicationLog)
        Me.Controls.Add(Me.pbProcessSystemLog)
        Me.Controls.Add(Me.btnClearLogsCancel)
        Me.Controls.Add(Me.btnClearLogsOK)
        Me.Controls.Add(Me.cbClearApplicationLog)
        Me.Controls.Add(Me.cbClearSystemLog)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmClearLogs"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "frmClearLogs"
        CType(Me.pbProcessApplicationLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbProcessSystemLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbClearSystemLog As System.Windows.Forms.CheckBox
    Friend WithEvents cbClearApplicationLog As System.Windows.Forms.CheckBox
    Friend WithEvents btnClearLogsOK As System.Windows.Forms.Button
    Friend WithEvents btnClearLogsCancel As System.Windows.Forms.Button
    Friend WithEvents pbProcessSystemLog As System.Windows.Forms.PictureBox
    Friend WithEvents pbProcessApplicationLog As System.Windows.Forms.PictureBox
End Class
