<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrinterScan
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
        Me.printerDataGridView = New System.Windows.Forms.DataGridView()
        Me.scPrinterScan = New System.Windows.Forms.SplitContainer()
        Me.cbSiteSelect = New System.Windows.Forms.ComboBox()
        Me.cbFilterSNMPKO = New System.Windows.Forms.CheckBox()
        Me.cbPrinterModeList = New System.Windows.Forms.ComboBox()
        Me.cbPrintServerList = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tbPrinterSearch = New System.Windows.Forms.TextBox()
        Me.tbLineCount = New System.Windows.Forms.TextBox()
        Me.lbLineCount = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.printerDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scPrinterScan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scPrinterScan.Panel1.SuspendLayout()
        Me.scPrinterScan.Panel2.SuspendLayout()
        Me.scPrinterScan.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'printerDataGridView
        '
        Me.printerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.printerDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.printerDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.printerDataGridView.Name = "printerDataGridView"
        Me.printerDataGridView.Size = New System.Drawing.Size(814, 409)
        Me.printerDataGridView.TabIndex = 0
        '
        'scPrinterScan
        '
        Me.scPrinterScan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.scPrinterScan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scPrinterScan.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.scPrinterScan.Location = New System.Drawing.Point(0, 0)
        Me.scPrinterScan.Name = "scPrinterScan"
        Me.scPrinterScan.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scPrinterScan.Panel1
        '
        Me.scPrinterScan.Panel1.Controls.Add(Me.Label3)
        Me.scPrinterScan.Panel1.Controls.Add(Me.Label2)
        Me.scPrinterScan.Panel1.Controls.Add(Me.Label1)
        Me.scPrinterScan.Panel1.Controls.Add(Me.lbLineCount)
        Me.scPrinterScan.Panel1.Controls.Add(Me.tbLineCount)
        Me.scPrinterScan.Panel1.Controls.Add(Me.cbSiteSelect)
        Me.scPrinterScan.Panel1.Controls.Add(Me.cbFilterSNMPKO)
        Me.scPrinterScan.Panel1.Controls.Add(Me.cbPrinterModeList)
        Me.scPrinterScan.Panel1.Controls.Add(Me.cbPrintServerList)
        Me.scPrinterScan.Panel1.Controls.Add(Me.PictureBox1)
        Me.scPrinterScan.Panel1.Controls.Add(Me.tbPrinterSearch)
        '
        'scPrinterScan.Panel2
        '
        Me.scPrinterScan.Panel2.Controls.Add(Me.printerDataGridView)
        Me.scPrinterScan.Size = New System.Drawing.Size(818, 510)
        Me.scPrinterScan.SplitterDistance = 93
        Me.scPrinterScan.TabIndex = 1
        '
        'cbSiteSelect
        '
        Me.cbSiteSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSiteSelect.FormattingEnabled = True
        Me.cbSiteSelect.Location = New System.Drawing.Point(302, 58)
        Me.cbSiteSelect.Name = "cbSiteSelect"
        Me.cbSiteSelect.Size = New System.Drawing.Size(204, 21)
        Me.cbSiteSelect.TabIndex = 20
        '
        'cbFilterSNMPKO
        '
        Me.cbFilterSNMPKO.AutoSize = True
        Me.cbFilterSNMPKO.Location = New System.Drawing.Point(14, 38)
        Me.cbFilterSNMPKO.Name = "cbFilterSNMPKO"
        Me.cbFilterSNMPKO.Size = New System.Drawing.Size(103, 17)
        Me.cbFilterSNMPKO.TabIndex = 19
        Me.cbFilterSNMPKO.Text = "Filtrer SNMP KO"
        Me.cbFilterSNMPKO.UseVisualStyleBackColor = True
        '
        'cbPrinterModeList
        '
        Me.cbPrinterModeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPrinterModeList.FormattingEnabled = True
        Me.cbPrinterModeList.Location = New System.Drawing.Point(302, 34)
        Me.cbPrinterModeList.Name = "cbPrinterModeList"
        Me.cbPrinterModeList.Size = New System.Drawing.Size(204, 21)
        Me.cbPrinterModeList.TabIndex = 18
        '
        'cbPrintServerList
        '
        Me.cbPrintServerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPrintServerList.FormattingEnabled = True
        Me.cbPrintServerList.Location = New System.Drawing.Point(302, 10)
        Me.cbPrintServerList.Name = "cbPrintServerList"
        Me.cbPrintServerList.Size = New System.Drawing.Size(204, 21)
        Me.cbPrintServerList.TabIndex = 17
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.My.Resources.Resources.magnifier
        Me.PictureBox1.Location = New System.Drawing.Point(600, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'tbPrinterSearch
        '
        Me.tbPrinterSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPrinterSearch.Location = New System.Drawing.Point(634, 21)
        Me.tbPrinterSearch.Name = "tbPrinterSearch"
        Me.tbPrinterSearch.Size = New System.Drawing.Size(165, 20)
        Me.tbPrinterSearch.TabIndex = 0
        '
        'tbLineCount
        '
        Me.tbLineCount.Location = New System.Drawing.Point(77, 7)
        Me.tbLineCount.Name = "tbLineCount"
        Me.tbLineCount.Size = New System.Drawing.Size(40, 20)
        Me.tbLineCount.TabIndex = 21
        '
        'lbLineCount
        '
        Me.lbLineCount.AutoSize = True
        Me.lbLineCount.Location = New System.Drawing.Point(11, 10)
        Me.lbLineCount.Name = "lbLineCount"
        Me.lbLineCount.Size = New System.Drawing.Size(58, 13)
        Me.lbLineCount.TabIndex = 22
        Me.lbLineCount.Text = "Nb. Lignes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(247, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Serveur"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(247, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Modèle"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(247, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Site"
        '
        'frmPrinterScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 510)
        Me.Controls.Add(Me.scPrinterScan)
        Me.Name = "frmPrinterScan"
        Me.Text = "Scan Impr."
        CType(Me.printerDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scPrinterScan.Panel1.ResumeLayout(False)
        Me.scPrinterScan.Panel1.PerformLayout()
        Me.scPrinterScan.Panel2.ResumeLayout(False)
        CType(Me.scPrinterScan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scPrinterScan.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents printerDataGridView As DataGridView
    Friend WithEvents scPrinterScan As SplitContainer
    Friend WithEvents tbPrinterSearch As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cbPrintServerList As ComboBox
    Friend WithEvents cbPrinterModeList As ComboBox
    Friend WithEvents cbFilterSNMPKO As CheckBox
    Friend WithEvents cbSiteSelect As ComboBox
    Friend WithEvents tbLineCount As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lbLineCount As Label
End Class
