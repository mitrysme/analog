Imports System.Net

Public Class frmWebBrowser
    Private WithEvents _wb As WebBrowser
    Private _pingPanel As New Panel
    Private _pingOptionsPanel As New Panel
    Private WithEvents _btMaximize As New Button
    Private WithEvents _btReload As New Button
    Private WithEvents _btNavBack As New Button
    Private WithEvents _btNavNext As New Button
    Private _lvping As New ListView
    Private _bDNSLookupOk As Boolean
    Private _hostname As String

    Private _lblDNSLookup As New Label

    Private _txtbPngSend As New TextBox
    Private _txtbPngLost As New TextBox
    Private _txtbPercentLost As New TextBox
    Private _txtbMaxRoundTrip As New TextBox
    Private _txtbMinRoundTrip As New TextBox
    Private _txtbAvgRoudtrip As New TextBox
    ' TXTB INFOS LDAP
    Private _txtbLDAPPrinterName As New TextBox
    Private _txtbLDAPPrinterLocation As New TextBox
    Private _txtbLDAPPrinterShortServerName As New TextBox
    Private _txtbLDAPPrinterPortName As New TextBox
    Private _txtbLDAPPrinterDescription As New TextBox
    Private _txtbLDAPPrinterShareName As New TextBox
    Private _txtbLDAPPrinterDriverName As New TextBox


    Private _lblPngSend As New Label
    Private _lblPingLost As New Label
    Private _lblPercentLost As New Label
    Private _lblMaxRoundTrip As New Label
    Private _lblMinRoundTrip As New Label
    Private _lblAvgRoudtrip As New Label
    ' LBL INFOS LDAP
    Private _lblLDAPPrinterName As New Label
    Private _lblLDAPPrinterLocation As New Label
    Private _lblLDAPPrinterShortServerName As New Label
    Private _lblLDAPPrinterPortName As New Label
    Private _lblLDAPPrinterDescription As New Label
    Private _lblLDAPPrinterShareName As New Label
    Private _lblLDAPPrinterDriverName As New Label



    Private _layout As New TableLayoutPanel
    Private WithEvents _timer As New Timer
    Private _panelMaxHeight As Integer = 250 ' const
    Private _panelMinHeight As Integer = 30
    Private _animateDirection As Integer
    Private _pinger As cAsyncPinger
    Private Delegate Sub _degUpdatePing(ByVal pingResults As cAsyncPinger.pingResults)

    Public Sub New(ByVal printerName As String,
                   ByVal ldapPrinterProps As ldapWrapper.ldapPrinterProperties)

        ' Add any initialization after the InitializeComponent() call.
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.Name = printerName
        Me.Text = printerName
        Me.Icon = program.tabicons.iconPrinter

        _btMaximize.Size = New System.Drawing.Size(44, 20)
        _btMaximize.Text = "+"

        _btNavBack.Size = New System.Drawing.Size(35, 20)
        _btNavNext.Size = New System.Drawing.Size(35, 20)
        _btReload.Size = New System.Drawing.Size(35, 20)

        _btNavBack.Image = My.Resources.arrow_180_medium
        _btNavNext.Image = My.Resources.arrow_000_medium
        _btReload.Image = My.Resources.refresh16

        _btNavBack.Enabled = False
        _btNavNext.Enabled = False

        ' 
        ' test la résolution DNS 
        ' SI lookup DNS KO => on tente de se connecter avec le nom du port récupéré dans AD
        ' appel bloquant sur thread UI ... 
        ' il existe version async de getHostAddresses ....
        '
        Dim printerAdress As Net.IPAddress = Nothing

        Try
            printerAdress = Dns.GetHostAddresses(printerName).First
        Catch ex As Exception
            Debug.Print("resolution dns Printer KO")
        End Try

        If printerAdress Is Nothing Then
            _bDNSLookupOk = False

            Dim printerPortName As String = ldapPrinterProps.portname

            ' résolution DNS KO et pas de port d'impression .. 
            ' forçage scan imprimante sans file LDAP et hostname n'existe pas ...
            If printerPortName Is Nothing Then
                MsgBox("Impossible de continuer, Résolution DNS impossible , auncun port d'impression défini ! ", MsgBoxStyle.Exclamation, "Erreur !")
            Else
                If Not IPAddress.TryParse(printerPortName, printerAdress) Then
                    Dim printerPortNameCleanup As String = printerPortName.Substring(3) ' vire IP_{0.0.0.0}
                    IPAddress.TryParse(printerPortNameCleanup, printerAdress)
                End If

                If printerAdress IsNot Nothing Then
                    printerName = printerAdress.ToString
                End If
            End If
        Else
            _bDNSLookupOk = True
        End If

        _hostname = printerName

        _pinger = New cAsyncPinger(printerName, _lvping, New _degUpdatePing(AddressOf updatePing), 32)
        _pinger.bsetPingData = False
        _pinger.startPing()

        _timer.Interval = 20

        _wb = New WebBrowser
        _wb.Dock = DockStyle.Fill
        _wb.Navigate(String.Format("http://{0}", printerName))
        '
        Me.Controls.Add(_wb)

        '
        ' Label LDAPPrinterName
        '
        _lblLDAPPrinterName.Text = "Nom"
        _lblLDAPPrinterName.TextAlign = ContentAlignment.MiddleLeft
        '
        ' Label LDAPPrinterLocation
        '
        _lblLDAPPrinterLocation.Text = "Localisation"
        _lblLDAPPrinterLocation.TextAlign = ContentAlignment.MiddleLeft
        '
        ' Label LDAPPrinterShortServerName
        '
        _lblLDAPPrinterShortServerName.Text = "Serveur"
        _lblLDAPPrinterShortServerName.TextAlign = ContentAlignment.MiddleLeft
        '
        ' Label LDAPPrinterPortName
        '
        _lblLDAPPrinterPortName.Text = "Port"
        _lblLDAPPrinterPortName.TextAlign = ContentAlignment.MiddleLeft
        '
        ' Label LDAPPrinterDescription
        '
        _lblLDAPPrinterDescription.Text = "Description"
        _lblLDAPPrinterDescription.TextAlign = ContentAlignment.MiddleLeft
        '
        ' Label LDAPPrinterShareName
        '
        _lblLDAPPrinterShareName.Text = "Nom Partage"
        _lblLDAPPrinterShareName.TextAlign = ContentAlignment.MiddleLeft
        '
        ' Label LDAPPrinterDriverName
        '
        _lblLDAPPrinterDriverName.Text = "Nom Driver"
        _lblLDAPPrinterDriverName.TextAlign = ContentAlignment.MiddleLeft
        '
        ' Label Ping envoyé
        '
        _lblPngSend.Text = "Envoyé"
        _lblPngSend.Anchor = AnchorStyles.Left
        _lblPngSend.TextAlign = ContentAlignment.MiddleCenter
        _lblPngSend.Size = New System.Drawing.Size(44, 20)
        '
        ' Label Ping Perdu
        '
        _lblPingLost.Text = "Perdu"
        _lblPingLost.TextAlign = ContentAlignment.MiddleCenter
        _lblPingLost.Anchor = AnchorStyles.Left
        _lblPingLost.Size = New System.Drawing.Size(44, 20)
        '
        ' label Perte
        '
        _lblPercentLost.Text = "% Perte"
        _lblPercentLost.TextAlign = ContentAlignment.MiddleCenter
        _lblPercentLost.Anchor = AnchorStyles.Left
        _lblPercentLost.Size = New System.Drawing.Size(44, 20)
        '
        ' Label Maxroundtrip
        '
        _lblMaxRoundTrip.Text = "Max"
        _lblMaxRoundTrip.TextAlign = ContentAlignment.MiddleCenter
        _lblMaxRoundTrip.Anchor = AnchorStyles.Left
        _lblMaxRoundTrip.Size = New System.Drawing.Size(44, 20)
        '
        ' Label minRoundTrip
        '
        _lblMinRoundTrip.Text = "Min"
        _lblMinRoundTrip.TextAlign = ContentAlignment.MiddleCenter
        _lblMinRoundTrip.Anchor = AnchorStyles.Left
        _lblMinRoundTrip.Size = New System.Drawing.Size(44, 20)
        '
        ' Label avgrounttrip
        '
        _lblAvgRoudtrip.Text = "Moy."
        _lblAvgRoudtrip.TextAlign = ContentAlignment.MiddleCenter
        _lblAvgRoudtrip.Anchor = AnchorStyles.Left
        _lblAvgRoudtrip.Size = New System.Drawing.Size(44, 20)
        '
        ' Label Dns Lookup
        '
        '
        _lblDNSLookup.Text = "DNS"
        _lblDNSLookup.TextAlign = ContentAlignment.MiddleCenter
        _lblDNSLookup.BorderStyle = BorderStyle.FixedSingle
        _lblDNSLookup.Size = New System.Drawing.Size(44, 20)
        _lblDNSLookup.Anchor = AnchorStyles.Left
        _lblDNSLookup.BackColor = Color.LightGreen
        '
        ' textBoxes
        ' 
        _txtbPngLost.Size = New System.Drawing.Size(44, 20)
        _txtbPngSend.Size = New System.Drawing.Size(44, 20)
        _txtbPercentLost.Size = New System.Drawing.Size(44, 20)
        _txtbMaxRoundTrip.Size = New System.Drawing.Size(44, 20)
        _txtbMinRoundTrip.Size = New System.Drawing.Size(44, 20)
        _txtbAvgRoudtrip.Size = New System.Drawing.Size(44, 20)
        '
        ' textBoxesLDAP
        '
        _txtbLDAPPrinterDescription.ReadOnly = True
        _txtbLDAPPrinterDescription.BackColor = System.Drawing.SystemColors.Info
        _txtbLDAPPrinterDriverName.ReadOnly = True
        _txtbLDAPPrinterDriverName.BackColor = System.Drawing.SystemColors.Info
        _txtbLDAPPrinterDriverName.Size = New System.Drawing.Size(200, 20)
        _txtbLDAPPrinterLocation.ReadOnly = True
        _txtbLDAPPrinterLocation.BackColor = System.Drawing.SystemColors.Info
        _txtbLDAPPrinterName.ReadOnly = True
        _txtbLDAPPrinterName.BackColor = System.Drawing.SystemColors.Info
        _txtbLDAPPrinterPortName.ReadOnly = True
        _txtbLDAPPrinterPortName.BackColor = System.Drawing.SystemColors.Info
        _txtbLDAPPrinterShareName.ReadOnly = True
        _txtbLDAPPrinterShareName.BackColor = System.Drawing.SystemColors.Info
        _txtbLDAPPrinterShareName.Size = New System.Drawing.Size(200, 20)
        _txtbLDAPPrinterShortServerName.ReadOnly = True
        _txtbLDAPPrinterShortServerName.BackColor = System.Drawing.SystemColors.Info
        _txtbLDAPPrinterShortServerName.Size = New System.Drawing.Size(200, 20)
        _txtbLDAPPrinterLocation.Size = New System.Drawing.Size(500, 20)
        _txtbLDAPPrinterLocation.BackColor = System.Drawing.SystemColors.Info
        _txtbLDAPPrinterDescription.Size = New System.Drawing.Size(500, 20)
        _txtbLDAPPrinterDescription.BackColor = System.Drawing.SystemColors.Info
        '
        '
        ' Table layout panel
        '
        _layout.Dock = DockStyle.Left
        _layout.Width = 1000
        _layout.GrowStyle = TableLayoutPanelGrowStyle.AddColumns
        _layout.Controls.Add(_btMaximize, 0, 0)
        _layout.Controls.Add(_btNavBack, 1, 0)
        _layout.Controls.Add(_btNavNext, 2, 0)
        _layout.Controls.Add(_btReload, 3, 0)
        _layout.Controls.Add(_lblPngSend, 4, 0)
        _layout.Controls.Add(_txtbPngSend, 5, 0)
        _layout.Controls.Add(_lblPingLost, 6, 0)
        _layout.Controls.Add(_txtbPngLost, 7, 0)
        _layout.Controls.Add(_lblPercentLost, 8, 0)
        _layout.Controls.Add(_txtbPercentLost, 9, 0)
        _layout.Controls.Add(_lblMaxRoundTrip, 10, 0)
        _layout.Controls.Add(_txtbMaxRoundTrip, 11, 0)
        _layout.Controls.Add(_lblMinRoundTrip, 12, 0)
        _layout.Controls.Add(_txtbMinRoundTrip, 13, 0)
        _layout.Controls.Add(_lblAvgRoudtrip, 14, 0)
        _layout.Controls.Add(_txtbAvgRoudtrip, 15, 0)
        _layout.Controls.Add(_lblDNSLookup, 16, 0)
        '
        ' Ajout des infos LDAP
        '
        ' PrinterName
        _layout.Controls.Add(_lblLDAPPrinterName, 0, 1)
        _layout.Controls.Add(_txtbLDAPPrinterName, 1, 1)
        _layout.SetColumnSpan(_txtbLDAPPrinterName, 2)
        ' PrinterLocation
        _layout.Controls.Add(_lblLDAPPrinterLocation, 0, 2)
        _layout.Controls.Add(_txtbLDAPPrinterLocation, 1, 2)
        _layout.SetColumnSpan(_txtbLDAPPrinterLocation, 12)
        ' printer Description
        _layout.Controls.Add(_lblLDAPPrinterDescription, 0, 3)
        _layout.Controls.Add(_txtbLDAPPrinterDescription, 1, 3)
        _layout.SetColumnSpan(_txtbLDAPPrinterDescription, 12)
        ' Printer ShortServerName
        _layout.Controls.Add(_lblLDAPPrinterShortServerName, 0, 4)
        _layout.Controls.Add(_txtbLDAPPrinterShortServerName, 1, 4)
        _layout.SetColumnSpan(_txtbLDAPPrinterShortServerName, 12)
        ' Printer portName
        _layout.Controls.Add(_lblLDAPPrinterPortName, 0, 5)
        _layout.Controls.Add(_txtbLDAPPrinterPortName, 1, 5)
        _layout.SetColumnSpan(_txtbLDAPPrinterPortName, 2)
        ' printer Sharename
        _layout.Controls.Add(_lblLDAPPrinterShareName, 0, 6)
        _layout.Controls.Add(_txtbLDAPPrinterShareName, 1, 6)
        _layout.SetColumnSpan(_txtbLDAPPrinterShareName, 12)
        ' printerDriverName
        _layout.Controls.Add(_lblLDAPPrinterDriverName, 0, 7)
        _layout.Controls.Add(_txtbLDAPPrinterDriverName, 1, 7)
        _layout.SetColumnSpan(_txtbLDAPPrinterDriverName, 12)
        '
        ' LvPing
        '
        _lvping.View = View.Details
        _lvping.HeaderStyle = ColumnHeaderStyle.None
        _lvping.ForeColor = Color.White
        _lvping.Width = 350
        _lvping.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {New System.Windows.Forms.ColumnHeader})
        _lvping.Columns(0).Width = 280
        _lvping.BackColor = Color.Black
        _lvping.Dock = DockStyle.Right
        _lvping.Size = New System.Drawing.Size(313, 129)

        '
        ' Ping options Panel
        '
        _pingOptionsPanel.BackColor = Color.Aqua
        _pingOptionsPanel.Dock = DockStyle.Right

        _pingPanel.Controls.Add(_lvping)
        _pingPanel.Controls.Add(_layout)

        With _pingPanel
            .Dock = DockStyle.Top
            .Height = 30
            .BorderStyle = BorderStyle.Fixed3D
        End With

        ' 
        ' Remplissage infos LDAP
        '
        _txtbLDAPPrinterLocation.Text = ldapPrinterProps.location
        _txtbLDAPPrinterName.Text = ldapPrinterProps.printerName
        _txtbLDAPPrinterDescription.Text = ldapPrinterProps.description
        _txtbLDAPPrinterShareName.Text = ldapPrinterProps.shareName
        _txtbLDAPPrinterShortServerName.Text = ldapPrinterProps.shortServerName
        _txtbLDAPPrinterPortName.Text = ldapPrinterProps.portname
        _txtbLDAPPrinterDriverName.Text = ldapPrinterProps.driverName

        setDnsLabelLookupColor(_bDNSLookupOk)

        Me.Controls.Add(_pingPanel)
    End Sub



    Private Sub resizeEventHandler(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.Width < 1250 Then
            _pingOptionsPanel.Visible = False
        Else
            _pingOptionsPanel.Visible = True
        End If
    End Sub

    Private Sub btMaximize_click() Handles _btMaximize.Click
        If _pingPanel.Height = _panelMinHeight Then
            _btMaximize.Text = "-"
            _animateDirection = 15
        Else
            _btMaximize.Text = "+"
            _animateDirection = -15
        End If

        _timer.Start()
        _timer.Enabled = True
    End Sub

    Private Sub btReload_click() Handles _btReload.Click
        _wb.Refresh()
    End Sub

    Private Sub btNavBack_click() Handles _btNavBack.Click
        _wb.GoBack()
    End Sub

    Private Sub btNavNext_click() Handles _btNavNext.Click
        _wb.GoForward()
    End Sub

    Private Sub canGoforwar_Handler() Handles _wb.CanGoBackChanged
        _btNavBack.Enabled = _wb.CanGoBack
    End Sub

    Private Sub canGoBackwardChanged_Handler() Handles _wb.CanGoForwardChanged
        _btNavNext.Enabled = _wb.CanGoForward
    End Sub

    Private Sub setDnsLabelLookupColor(ByVal ok As Boolean)
        _lblDNSLookup.BackColor = If(ok, Color.LightGreen, Color.Red)
    End Sub

    Private Sub timerAnimateTick() Handles _timer.Tick
        Dim height As Integer = _pingPanel.Height + _animateDirection

        If height >= _panelMaxHeight Then
            height = _panelMaxHeight
            _timer.Enabled = False
        ElseIf height <= _panelMinHeight Then
            height = _panelMinHeight
            _timer.Enabled = False
        End If

        _pingPanel.Height = height
    End Sub

    Private Sub frm_closing() Handles MyBase.FormClosing
        _wb.Dispose()
        _pinger.stopPing()
        _timer.Stop()
        _timer.Dispose()
    End Sub


    Public Sub updatePing(ByVal pingResults As cAsyncPinger.pingResults)
        ' 3 heures max historique ping dans le LV
        If _lvping.Items.Count > cAsyncPinger.MAX_LV_PING_HISTORY Then
            _lvping.Items.RemoveAt(0)
        End If

        If Not Me.Disposing Then
            If CBool(pingResults.lost) Then
                If _txtbPngLost.BackColor <> Color.Red Then
                    _txtbPngLost.BackColor = Color.Red
                End If
            End If

            With _lvping
                .SuspendLayout()
                .Items.Add(New ListViewItem(pingResults.text))
                .Items(_lvping.Items.Count - 1).EnsureVisible()
                .ResumeLayout()
            End With

            '
            ' Maj TextBoxes stats ping
            '
            With pingResults
                _txtbPngSend.Text = .sent.ToString
                _txtbPngLost.Text = .lost.ToString
                _txtbAvgRoudtrip.Text = .avgRoundtripTime.ToString
                _txtbMaxRoundTrip.Text = .maxRoundtrip.ToString
                _txtbMinRoundTrip.Text = .minRoundTrip.ToString
                _txtbPercentLost.Text = .lostPercentage.ToString
            End With
        End If
    End Sub

End Class