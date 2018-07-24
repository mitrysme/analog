Partial Class lvServices
    Inherits baseLv

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    'Component overrides dispose to clean up the component list.
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

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ContextMenuStripServices = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemStart = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemStop = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemTypeStart = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemAutoStart = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemManualStart = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemDisabled = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStripServices.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStripServices
        '
        Me.ContextMenuStripServices.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemStart, Me.ToolStripMenuItemStop, Me.ToolStripMenuItemTypeStart})
        Me.ContextMenuStripServices.Name = "ContextMenuStripServices"
        Me.ContextMenuStripServices.Size = New System.Drawing.Size(139, 70)
        '
        'ToolStripMenuItemStart
        '
        Me.ToolStripMenuItemStart.Image = Global.My.Resources.Resources.control
        Me.ToolStripMenuItemStart.Name = "ToolStripMenuItemStart"
        Me.ToolStripMenuItemStart.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripMenuItemStart.Text = "Démarrer"
        '
        'ToolStripMenuItemStop
        '
        Me.ToolStripMenuItemStop.Image = Global.My.Resources.Resources.control_stop_square
        Me.ToolStripMenuItemStop.Name = "ToolStripMenuItemStop"
        Me.ToolStripMenuItemStop.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripMenuItemStop.Text = "Arrêter"
        '
        'ToolStripMenuItemTypeStart
        '
        Me.ToolStripMenuItemTypeStart.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemAutoStart, Me.ToolStripMenuItemManualStart, Me.ToolStripMenuItemDisabled})
        Me.ToolStripMenuItemTypeStart.Name = "ToolStripMenuItemTypeStart"
        Me.ToolStripMenuItemTypeStart.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripMenuItemTypeStart.Text = "Démarrage"
        '
        'ToolStripMenuItemAutoStart
        '
        Me.ToolStripMenuItemAutoStart.Name = "ToolStripMenuItemAutoStart"
        Me.ToolStripMenuItemAutoStart.Size = New System.Drawing.Size(146, 22)
        Me.ToolStripMenuItemAutoStart.Text = "Automatique"
        '
        'ToolStripMenuItemManualStart
        '
        Me.ToolStripMenuItemManualStart.Name = "ToolStripMenuItemManualStart"
        Me.ToolStripMenuItemManualStart.Size = New System.Drawing.Size(146, 22)
        Me.ToolStripMenuItemManualStart.Text = "Manuel"
        '
        'ToolStripMenuItemDisabled
        '
        Me.ToolStripMenuItemDisabled.Name = "ToolStripMenuItemDisabled"
        Me.ToolStripMenuItemDisabled.Size = New System.Drawing.Size(146, 22)
        Me.ToolStripMenuItemDisabled.Text = "Désactivé"
        Me.ContextMenuStripServices.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStripServices As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemStop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemTypeStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemAutoStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemManualStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemDisabled As System.Windows.Forms.ToolStripMenuItem

End Class
