﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHddInfos
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
        Me.lstHddInfos = New System.Windows.Forms.ListView
        Me.SuspendLayout()
        '
        'lstHddInfos
        '
        Me.lstHddInfos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstHddInfos.Location = New System.Drawing.Point(0, 0)
        Me.lstHddInfos.Name = "lstHddInfos"
        Me.lstHddInfos.Size = New System.Drawing.Size(683, 266)
        Me.lstHddInfos.TabIndex = 0
        Me.lstHddInfos.UseCompatibleStateImageBehavior = False
        '
        'frmHddInfos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 266)
        Me.Controls.Add(Me.lstHddInfos)
        Me.Name = "frmHddInfos"
        Me.Text = "frmHddInfos"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstHddInfos As System.Windows.Forms.ListView
End Class
