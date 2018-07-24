''' <summary>
''' Class permettant de rendre transparente (partiellement)
''' une fenetre en cas de déplacement de celle ci.
''' </summary>
Public Class _Cls_ScreenOpac
    Private Ptr_Screen As Form = Nothing
    Private Timer_Opacity As System.Windows.Forms.Timer
    Private Sens As Integer = 0
    Public Property MaFenetre() As Form
        Get
            Return Ptr_Screen
        End Get
        Set(ByVal value As Form)
            Ptr_Screen = value
            ' ----- Détourner l'evenement "Location Change" c'est à dire que la fenetre est en mouvement
            AddHandler Ptr_Screen.LocationChanged, AddressOf Me.MoveScreen
            ' ----- Creation d'un Timer pour la gestion
            ' ----- de la transparence progressive.
            Timer_Opacity = New System.Windows.Forms.Timer()
            Timer_Opacity.Interval = 50
            Timer_Opacity.Enabled = False
            AddHandler Timer_Opacity.Tick, AddressOf Gestion_Affichage
        End Set
    End Property
    Private Sub Gestion_Affichage(ByVal sender As Object, ByVal e As EventArgs)
        If Ptr_Screen Is Nothing Then
            Return
        End If
        ' ----- Etat du bouton
        Dim mbs As MouseButtons = Control.MouseButtons
        If (mbs And MouseButtons.Left) = 0 Then
            Sens = -1
        End If
        ' ----- Partiellement transparent
        If (Ptr_Screen.Opacity < 0.4F) AndAlso (Sens > 0) Then
            Return
        End If
        ' ----- Totallement opaque  
        If (Ptr_Screen.Opacity > 0.95F) AndAlso (Sens < 0) Then
            Timer_Opacity.Enabled = False
            Ptr_Screen.Opacity = 1
            Return
        End If
        Ptr_Screen.Opacity = Ptr_Screen.Opacity - (0.1F * Sens)
        Return
    End Sub
    Private Sub MoveScreen(ByVal sender As Object, ByVal e As EventArgs)
        ' ----- le bouton gauche est cliqué
        Dim mbs As MouseButtons = Control.MouseButtons
        If (mbs And MouseButtons.Left) <> 0 Then
            If Timer_Opacity.Enabled = False Then
                Timer_Opacity.Enabled = True
                Sens = 1
            End If
        End If
    End Sub
End Class
