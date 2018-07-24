<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetailPing
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvPing = New System.Windows.Forms.DataGridView
        Me.CAsyncPinger_pingDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateTimePickerTimeFrom = New System.Windows.Forms.DateTimePicker
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.DateTimePickerTo = New System.Windows.Forms.DateTimePicker
        Me.DateTimePickerTimeTo = New System.Windows.Forms.DateTimePicker
        Me.ckbFilterByDate = New System.Windows.Forms.CheckBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.tbPingSent = New System.Windows.Forms.TextBox
        Me.tbMaxRoundTrip = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.tbMinRoundtrip = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.tbAvgRoundtrip = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.tbPercentLost = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.tbPingLOst = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.ckbLostPacketFilter = New System.Windows.Forms.CheckBox
        CType(Me.dgvPing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAsyncPinger_pingDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvPing
        '
        Me.dgvPing.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPing.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPing.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPing.DataSource = Me.CAsyncPinger_pingDataBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPing.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPing.Location = New System.Drawing.Point(0, 120)
        Me.dgvPing.Name = "dgvPing"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPing.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPing.Size = New System.Drawing.Size(445, 386)
        Me.dgvPing.TabIndex = 0
        '
        'CAsyncPinger_pingDataBindingSource
        '
        Me.CAsyncPinger_pingDataBindingSource.DataSource = GetType(cAsyncPinger.pingData)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.ckbFilterByDate)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.ckbLostPacketFilter)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(445, 120)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DateTimePickerTimeFrom)
        Me.GroupBox1.Controls.Add(Me.DateTimePickerFrom)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DateTimePickerTo)
        Me.GroupBox1.Controls.Add(Me.DateTimePickerTimeTo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(329, 79)
        Me.GroupBox1.TabIndex = 84
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtrer par date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "De :"
        '
        'DateTimePickerTimeFrom
        '
        Me.DateTimePickerTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePickerTimeFrom.Location = New System.Drawing.Point(237, 21)
        Me.DateTimePickerTimeFrom.Name = "DateTimePickerTimeFrom"
        Me.DateTimePickerTimeFrom.ShowUpDown = True
        Me.DateTimePickerTimeFrom.Size = New System.Drawing.Size(80, 20)
        Me.DateTimePickerTimeFrom.TabIndex = 1
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(63, 21)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(170, 20)
        Me.DateTimePickerFrom.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "A :"
        '
        'DateTimePickerTo
        '
        Me.DateTimePickerTo.Location = New System.Drawing.Point(63, 42)
        Me.DateTimePickerTo.Name = "DateTimePickerTo"
        Me.DateTimePickerTo.Size = New System.Drawing.Size(170, 20)
        Me.DateTimePickerTo.TabIndex = 3
        '
        'DateTimePickerTimeTo
        '
        Me.DateTimePickerTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePickerTimeTo.Location = New System.Drawing.Point(237, 43)
        Me.DateTimePickerTimeTo.Name = "DateTimePickerTimeTo"
        Me.DateTimePickerTimeTo.ShowUpDown = True
        Me.DateTimePickerTimeTo.Size = New System.Drawing.Size(80, 20)
        Me.DateTimePickerTimeTo.TabIndex = 4
        '
        'ckbFilterByDate
        '
        Me.ckbFilterByDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckbFilterByDate.Appearance = System.Windows.Forms.Appearance.Button
        Me.ckbFilterByDate.AutoSize = True
        Me.ckbFilterByDate.Location = New System.Drawing.Point(172, 89)
        Me.ckbFilterByDate.Name = "ckbFilterByDate"
        Me.ckbFilterByDate.Size = New System.Drawing.Size(40, 23)
        Me.ckbFilterByDate.TabIndex = 83
        Me.ckbFilterByDate.Text = "Date"
        Me.ckbFilterByDate.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.tbPingSent)
        Me.Panel2.Controls.Add(Me.tbMaxRoundTrip)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.tbMinRoundtrip)
        Me.Panel2.Controls.Add(Me.Label30)
        Me.Panel2.Controls.Add(Me.tbAvgRoundtrip)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label31)
        Me.Panel2.Controls.Add(Me.tbPercentLost)
        Me.Panel2.Controls.Add(Me.Label32)
        Me.Panel2.Controls.Add(Me.tbPingLOst)
        Me.Panel2.Controls.Add(Me.Label33)
        Me.Panel2.Location = New System.Drawing.Point(347, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(94, 113)
        Me.Panel2.TabIndex = 82
        '
        'tbPingSent
        '
        Me.tbPingSent.Location = New System.Drawing.Point(3, 18)
        Me.tbPingSent.Name = "tbPingSent"
        Me.tbPingSent.Size = New System.Drawing.Size(44, 20)
        Me.tbPingSent.TabIndex = 70
        '
        'tbMaxRoundTrip
        '
        Me.tbMaxRoundTrip.Location = New System.Drawing.Point(46, 18)
        Me.tbMaxRoundTrip.Name = "tbMaxRoundTrip"
        Me.tbMaxRoundTrip.Size = New System.Drawing.Size(45, 20)
        Me.tbMaxRoundTrip.TabIndex = 76
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(3, 38)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 15)
        Me.Label18.TabIndex = 75
        Me.Label18.Text = "Perdu"
        '
        'tbMinRoundtrip
        '
        Me.tbMinRoundtrip.Location = New System.Drawing.Point(46, 53)
        Me.tbMinRoundtrip.Name = "tbMinRoundtrip"
        Me.tbMinRoundtrip.Size = New System.Drawing.Size(45, 20)
        Me.tbMinRoundtrip.TabIndex = 78
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(3, 73)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(44, 15)
        Me.Label30.TabIndex = 73
        Me.Label30.Text = "% perte"
        '
        'tbAvgRoundtrip
        '
        Me.tbAvgRoundtrip.Location = New System.Drawing.Point(46, 88)
        Me.tbAvgRoundtrip.Name = "tbAvgRoundtrip"
        Me.tbAvgRoundtrip.Size = New System.Drawing.Size(45, 20)
        Me.tbAvgRoundtrip.TabIndex = 77
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(3, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 15)
        Me.Label17.TabIndex = 74
        Me.Label17.Text = "Envoyé"
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label31.Location = New System.Drawing.Point(46, 3)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(45, 15)
        Me.Label31.TabIndex = 80
        Me.Label31.Text = "Max."
        '
        'tbPercentLost
        '
        Me.tbPercentLost.Location = New System.Drawing.Point(3, 88)
        Me.tbPercentLost.Name = "tbPercentLost"
        Me.tbPercentLost.Size = New System.Drawing.Size(44, 20)
        Me.tbPercentLost.TabIndex = 71
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label32.Location = New System.Drawing.Point(46, 73)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(45, 15)
        Me.Label32.TabIndex = 79
        Me.Label32.Text = "Moy."
        '
        'tbPingLOst
        '
        Me.tbPingLOst.Location = New System.Drawing.Point(3, 53)
        Me.tbPingLOst.Name = "tbPingLOst"
        Me.tbPingLOst.Size = New System.Drawing.Size(44, 20)
        Me.tbPingLOst.TabIndex = 72
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.Location = New System.Drawing.Point(46, 38)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(45, 15)
        Me.Label33.TabIndex = 81
        Me.Label33.Text = "Min."
        '
        'ckbLostPacketFilter
        '
        Me.ckbLostPacketFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckbLostPacketFilter.Appearance = System.Windows.Forms.Appearance.Button
        Me.ckbLostPacketFilter.AutoSize = True
        Me.ckbLostPacketFilter.Location = New System.Drawing.Point(221, 89)
        Me.ckbLostPacketFilter.Name = "ckbLostPacketFilter"
        Me.ckbLostPacketFilter.Size = New System.Drawing.Size(120, 23)
        Me.ckbLostPacketFilter.TabIndex = 0
        Me.ckbLostPacketFilter.Text = "Filtrer Paquets Perdus"
        Me.ckbLostPacketFilter.UseVisualStyleBackColor = True
        '
        'frmDetailPing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 509)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvPing)
        Me.Name = "frmDetailPing"
        Me.Text = "frmDetailPing"
        CType(Me.dgvPing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAsyncPinger_pingDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvPing As System.Windows.Forms.DataGridView
    Friend WithEvents CAsyncPinger_pingDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ckbLostPacketFilter As System.Windows.Forms.CheckBox
    Friend WithEvents DateTimePickerTimeFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerTimeTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbPingSent As System.Windows.Forms.TextBox
    Friend WithEvents tbPingLOst As System.Windows.Forms.TextBox
    Friend WithEvents tbPercentLost As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tbMaxRoundTrip As System.Windows.Forms.TextBox
    Friend WithEvents tbMinRoundtrip As System.Windows.Forms.TextBox
    Friend WithEvents tbAvgRoundtrip As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ckbFilterByDate As System.Windows.Forms.CheckBox
End Class
