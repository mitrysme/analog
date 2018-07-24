Public Class frmExportDialog

    Private Delegate Sub degUpdateDialog(ByVal lineNumber As Integer)
    Private Delegate Sub degExportKODialog(ByVal message As String)

    'Private _itemsToExport As Integer
    Private _exportKO As Boolean ' true si probleme pendant export excel
    Private _iNbItemsToExport As Integer

    Public Sub New(ByVal iNbItemsToExport As Integer)
        InitializeComponent()

        _exportKO = False
        _iNbItemsToExport = iNbItemsToExport
        Me.pbExport.Minimum = 0
        Me.pbExport.Maximum = iNbItemsToExport
        Me.pbExport.Value = 0
    End Sub

    Public Sub setNbItemsToExport(ByVal i As Integer)
        Me.pbExport.Maximum = i
    End Sub

    Public Sub updateDialog(ByVal lineNumber As Integer)
        If InvokeRequired Then
            Dim d As New degUpdateDialog(AddressOf updateDialog)
            Me.Invoke(d, New Object() {lineNumber})
        Else
            Me.pbExport.Value = lineNumber
            Me.tbExport.Text = lineNumber & "/" & _iNbItemsToExport
            If lineNumber = _iNbItemsToExport Then
                Me.Close()
            End If
        End If
    End Sub

    ''' <summary>
    ''' export KO, ferme fenetre
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Public Sub exportKo(ByVal message As String)
        If InvokeRequired Then
            Dim d As New degExportKODialog(AddressOf exportKo)
            Me.Invoke(d, New Object() {message})
        Else
            MsgBox(message, MsgBoxStyle.Exclamation)
            _exportKO = True
            Me.Close()
        End If
    End Sub

    Private Sub form_closing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _exportKO Then
            If Me.pbExport.Value <> _iNbItemsToExport Then
                e.Cancel = True
            End If
        End If
    End Sub

End Class