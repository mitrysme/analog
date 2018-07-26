<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAPropos
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblVersionName = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblContactURL = New System.Windows.Forms.LinkLabel()
        Me.btLicense = New System.Windows.Forms.Button()
        Me.btOK = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbRelease = New System.Windows.Forms.Label()
        Me.lbReleaseName = New System.Windows.Forms.Label()
        Me.lblAuteur = New System.Windows.Forms.Label()
        Me.lblAuteurName = New System.Windows.Forms.Label()
        Me.lblSiteGIT = New System.Windows.Forms.Label()
        Me.lblSiteGITName = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(91, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Analog"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(3, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(48, 13)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Version :"
        '
        'lblVersionName
        '
        Me.lblVersionName.AutoSize = True
        Me.lblVersionName.Location = New System.Drawing.Point(68, 0)
        Me.lblVersionName.Name = "lblVersionName"
        Me.lblVersionName.Size = New System.Drawing.Size(0, 13)
        Me.lblVersionName.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(231, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Programme diffusé sous licence GNU GPL v3.0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Contact :"
        '
        'lblContactURL
        '
        Me.lblContactURL.AutoSize = True
        Me.lblContactURL.Location = New System.Drawing.Point(68, 80)
        Me.lblContactURL.Name = "lblContactURL"
        Me.lblContactURL.Size = New System.Drawing.Size(0, 13)
        Me.lblContactURL.TabIndex = 5
        '
        'btLicense
        '
        Me.btLicense.Location = New System.Drawing.Point(126, 297)
        Me.btLicense.Name = "btLicense"
        Me.btLicense.Size = New System.Drawing.Size(75, 23)
        Me.btLicense.TabIndex = 6
        Me.btLicense.Text = "License"
        Me.btLicense.UseVisualStyleBackColor = True
        '
        'btOK
        '
        Me.btOK.Location = New System.Drawing.Point(207, 297)
        Me.btOK.Name = "btOK"
        Me.btOK.Size = New System.Drawing.Size(75, 23)
        Me.btOK.TabIndex = 7
        Me.btOK.Text = "Ok"
        Me.btOK.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(11, 199)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(262, 95)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Remerciement :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Alain Descotes  YAPM  - GPL v 3.0 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Derek Lakin      XpCollapsi" &
    "blePanel - CPOL " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Carlos Moya     MDIWindowManager - BSD" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "msinadinovic    SNMP#N" &
    "ET - LGPL"
        '
        'lbRelease
        '
        Me.lbRelease.AutoSize = True
        Me.lbRelease.Location = New System.Drawing.Point(3, 20)
        Me.lbRelease.Name = "lbRelease"
        Me.lbRelease.Size = New System.Drawing.Size(52, 13)
        Me.lbRelease.TabIndex = 9
        Me.lbRelease.Text = "Release :"
        '
        'lbReleaseName
        '
        Me.lbReleaseName.AutoSize = True
        Me.lbReleaseName.Location = New System.Drawing.Point(68, 20)
        Me.lbReleaseName.Name = "lbReleaseName"
        Me.lbReleaseName.Size = New System.Drawing.Size(0, 13)
        Me.lbReleaseName.TabIndex = 10
        '
        'lblAuteur
        '
        Me.lblAuteur.AutoSize = True
        Me.lblAuteur.Location = New System.Drawing.Point(3, 40)
        Me.lblAuteur.Name = "lblAuteur"
        Me.lblAuteur.Size = New System.Drawing.Size(44, 13)
        Me.lblAuteur.TabIndex = 11
        Me.lblAuteur.Text = "Auteur :"
        '
        'lblAuteurName
        '
        Me.lblAuteurName.AutoSize = True
        Me.lblAuteurName.Location = New System.Drawing.Point(68, 40)
        Me.lblAuteurName.Name = "lblAuteurName"
        Me.lblAuteurName.Size = New System.Drawing.Size(75, 13)
        Me.lblAuteurName.TabIndex = 12
        Me.lblAuteurName.Text = "Dimitri Darcam"
        '
        'lblSiteGIT
        '
        Me.lblSiteGIT.AutoSize = True
        Me.lblSiteGIT.Location = New System.Drawing.Point(3, 60)
        Me.lblSiteGIT.Name = "lblSiteGIT"
        Me.lblSiteGIT.Size = New System.Drawing.Size(31, 13)
        Me.lblSiteGIT.TabIndex = 13
        Me.lblSiteGIT.Text = "Site :"
        '
        'lblSiteGITName
        '
        Me.lblSiteGITName.AutoSize = True
        Me.lblSiteGITName.Location = New System.Drawing.Point(68, 60)
        Me.lblSiteGITName.Name = "lblSiteGITName"
        Me.lblSiteGITName.Size = New System.Drawing.Size(177, 13)
        Me.lblSiteGITName.TabIndex = 14
        Me.lblSiteGITName.Text = "https://github.com/mitrysme/analog"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.47917!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.52084!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbReleaseName, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSiteGITName, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbRelease, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSiteGIT, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblContactURL, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblVersion, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAuteurName, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblVersionName, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAuteur, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(14, 56)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(268, 100)
        Me.TableLayoutPanel1.TabIndex = 15
        '
        'frmAPropos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(297, 328)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btOK)
        Me.Controls.Add(Me.btLicense)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAPropos"
        Me.Text = "frmAPropos"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblVersionName As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblContactURL As System.Windows.Forms.LinkLabel
    Friend WithEvents btLicense As System.Windows.Forms.Button
    Friend WithEvents btOK As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbRelease As System.Windows.Forms.Label
    Friend WithEvents lbReleaseName As System.Windows.Forms.Label
    Friend WithEvents lblAuteur As Label
    Friend WithEvents lblAuteurName As Label
    Friend WithEvents lblSiteGIT As Label
    Friend WithEvents lblSiteGITName As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
