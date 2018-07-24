Public MustInherit Class frmBaseDynDetails
    Private _panel As FlowLayoutPanel
    Protected textBoxTitle As String

    Protected MustOverride Function getDatas() As System.Collections.ICollection

    Public Sub New()
        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me.AutoSize = True
        Me.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
        '
        _panel = New FlowLayoutPanel
        With _panel
            .Name = "fPanel"
            .Dock = DockStyle.Fill
            .AutoSize = True
        End With

        Me.Controls.Add(_panel)
    End Sub

    Protected Sub drawForm()
        Dim data = getDatas()
        Dim count As Integer = 1
        Dim ws As New Stopwatch

        For Each i In data
            Dim type As Type = i.GetType
            Dim fields = type.GetFields

            Dim gpBox As New GroupBox
            With gpBox
                .Text = String.Format("{0} {1} / {2}", textBoxTitle, count.ToString, data.Count.ToString)
                .AutoSize = True
            End With

            Dim panel As New TableLayoutPanel
            With panel
                .ColumnCount = 2
                .AutoSize = True
                .Dock = DockStyle.Fill
            End With

            Dim control As New List(Of Control)

            For j As Integer = 0 To fields.Count - 1
                Dim propertyName As String = fields(j).Name
                Dim fieldValue As Object = fields(j).GetValue(i)

                If propertyName = "NetworkSpeed" Then
                    If fieldValue IsNot Nothing Then
                        fieldValue = perfCounterHelper.formatBytes(CType(fieldValue, Single))
                    End If
                End If

                If fieldValue IsNot Nothing Then
                    If IsArray(fieldValue) Then

                        Dim afieldValue As Array = CType(fieldValue, Array)
                        fieldValue = afieldValue(0).ToString ' TODO caster

                    ElseIf TypeOf (fieldValue) Is Boolean Then

                        If CBool(fieldValue) Then
                            fieldValue = "OUI"
                        Else
                            fieldValue = "NON"
                        End If

                    End If
                End If

                Dim label = New Label
                label.Text = propertyName
                Dim tb = New TextBox
                With tb
                    tb.Width = 140
                    tb.ReadOnly = True
                    tb.BackColor = Color.White
                    tb.Text = CStr(fieldValue)
                End With

                control.Add(label)
                control.Add(tb)
            Next

            panel.Controls.AddRange(control.ToArray)
            gpBox.Controls.Add(panel)
            _panel.Controls.Add(gpBox)

            count += 1
        Next
    End Sub

End Class
