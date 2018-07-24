' TODO : disposer les perfCounter à la fin de vie de l'objet

Imports System.Threading
Imports System.Drawing.Drawing2D

Public MustInherit Class baseGraphControl : Inherits UserControl
    Private _aData As List(Of Single) = New List(Of Single) ' donnes a tracer
    Private _bDrawGrid As Boolean = False
    Private _gridOffsetPosition As Integer = 0 ' pour scroll grille
    Protected _graphType As enumGraphType
    Protected _scaleMode As scaleMode
    Protected _currentMaxValue As Single = 0
    Protected _stationName As String
    Protected _totPhyMemory As ULong ' pour calcul % freeRam dans freeMemoryGraph
    Protected _perfCounter As PerformanceCounter ' helper pour récup valeur perfCounters
    Protected _busy As Boolean
    Protected _title As String ' nom du graphique
    Protected _retryCount As Integer = 0
    Protected _initialised As Boolean = False


    Private Const MAX_RETRY_GET_PERFCOUNTER As Integer = 2

#Region "Property"
    Public Property retryCount() As Integer
        Get
            Return _retryCount
        End Get
        Set(ByVal value As Integer)
            _retryCount = value
        End Set
    End Property
    Public Property title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property
#End Region

    Public Enum enumGraphType
        curve
        bar
    End Enum

    Public Enum scaleMode
        absolute ' pourcentage 0-100 => CPU load
        relative
    End Enum

    ''' <summary>
    ''' Constructeur
    ''' </summary>
    ''' <remarks>
    ''' _perfCounter inutilisé pour ioGraph, diskGraph
    ''' </remarks>
    Public Sub New()
        Me.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
        Me.BackColor = Color.Black
        'Me.Font = SystemInformation.MenuFont
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.ResizeRedraw = True

        _busy = False

        ' trace grille par défaut
        _bDrawGrid = True
    End Sub

    Protected Overridable Sub initPerfCounter()
        _perfCounter = New PerformanceCounter
    End Sub

    Public Sub connectToStation(ByVal stationName As String, Optional ByVal totPhyRam As ULong = Nothing)
        _stationName = stationName
        _totPhyMemory = totPhyRam ' sers uniquement pour freeMemoryGraph 
    End Sub

    ''' <summary>
    ''' Update du controle dans thread
    ''' </summary>
    ''' <remarks>
    ''' Ne rajoute pas une mise à jour si  occupé ou maxRetry atteint
    ''' </remarks>
    Public Sub updateControl()
        If Not (_busy Or _retryCount > MAX_RETRY_GET_PERFCOUNTER) Then
            ThreadPool.QueueUserWorkItem(AddressOf updateControlAsync)
        End If
    End Sub

    ''' <summary>
    ''' Mise à jour du controle (threadPool)
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    Private Sub updateControlAsync()
        Dim sTempStationName = _stationName

        _busy = True
        Dim val As Single
        Dim success As Boolean = True

        Try
            val = getCounterValue()
        Catch ex As Exception
            success = False
            _retryCount += 1

            closePerfCounter()

            log.addLogEntry(New cLogEntry(String.Format("Impossible de récupérer valeur compteur : {0}", Me.title), cLogEntry.enumDebugLevel.DEBUG, sTempStationName, "basegraphControl", ex))
        Finally
            If success Then
                addData(val)
            Else
                If _retryCount > MAX_RETRY_GET_PERFCOUNTER Then
                    closePerfCounter()
                    log.addLogEntry(New cLogEntry(String.Format("Récupération valeur compteur {0} impossible, nombre essais maxi atteint => abandon...", Me.title), cLogEntry.enumDebugLevel.ERREUR, sTempStationName))
                End If
            End If

            _busy = False
        End Try
    End Sub

    ''' <summary>
    ''' récupération dans thread de la valeur du compteur ( .nextValue )
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    Protected Overridable Function getCounterValue() As Single

        If Not _initialised Then
            log.addLogEntry(New cLogEntry(String.Format("Initialisation PerfCounter : {0}", Me.Name), cLogEntry.enumDebugLevel.DEBUG, _stationName, "", Nothing))

            initPerfCounter()
            _initialised = True
        End If

    End Function

    ''' <summary>
    ''' Ajoute une valeur perfCounter dans le tableau _aData
    ''' et invalide le controle 
    ''' </summary>
    ''' <param name="d">valeur compteur</param>
    ''' <remarks></remarks>
    Private Sub addData(ByVal d As Single)
        ' FIX Affreux 
        ' TODO vérifier initialisation des compteurs lors d'un changement de station
        ' appel de clear en plein milieux de onPaint , etc ....
        ' c'est pas normal de récupérer un infini ici , exception avant ? ( compteur disposé ?? )
        If Single.IsInfinity(d) Then
            log.addLogEntry(New cLogEntry("FIXME : Valeur compteur erronée ( infini ), probablement compteur non initialisé, valeur ignorée ...", cLogEntry.enumDebugLevel.DEBUG, _stationName))
            Exit Sub
        End If

        Dim cr As Rectangle = Me.ClientRectangle
        Dim dataCount = _aData.Count

        SyncLock _aData
            If dataCount > cr.Width Then _aData.RemoveAt(0)
            _aData.Add(d)
        End SyncLock

        If _scaleMode = scaleMode.relative Then setHighestValue()

        If Not Me.DesignMode Then ' program.preferences = nothing in designMode ...
            If program.preferences.bAnimateGraph Then _gridOffsetPosition += 1
        End If

        Me.Invalidate()
    End Sub

    ''' <summary>
    ''' Mise à l'échelle Y pour mode relatif
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function calcVerticalPosition(ByVal value As Single) As Single
        Dim result As Single

        If _scaleMode = scaleMode.absolute Then
            result = value * Me.Height / 100
        ElseIf _scaleMode = scaleMode.relative Then
            If _currentMaxValue > 0 Then
                result = value * Me.Height / _currentMaxValue
            Else
                result = 0
            End If
        End If

        result = Me.Height - result

        Return Convert.ToSingle(result)
    End Function

    Private Function setHighestValue() As Single
        SyncLock _aData
            _currentMaxValue = _aData.Max
        End SyncLock
    End Function

    ''' <summary>
    ''' Dessin du controle
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' Dans mainThread
    ''' </remarks>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        MyBase.OnPaint(e)

        ' peint le controle dans Bitmap en mémoire
        Dim ibufferImage As Bitmap = New Bitmap(Me.Bounds.Width, Me.Bounds.Height)
        Dim gd As Graphics = Graphics.FromImage(ibufferImage)

        If Not Me.DesignMode Then ' program.preferences = nothing in designMode ...
            If program.preferences.bGraphAntialiasing Then
                gd.SmoothingMode = SmoothingMode.HighQuality
            Else
                gd.SmoothingMode = SmoothingMode.HighSpeed
            End If
        End If

        ' peint gradient sur fonds
        Dim baseBackground As LinearGradientBrush = New LinearGradientBrush(ClientRectangle, Color.Gray, Color.Black, LinearGradientMode.Vertical)
        gd.FillRectangle(baseBackground, ClientRectangle)

        ' peint grille
        drawGrid(gd)

        ' TODO [CRITICAL]
        ' _adata peut etre remis à 0 par appel à .clear depuis frmMain
        ' lors d'un changement de station
        ' si on se trouve à ce moment la dans onPaint => crash Overflow 

        Dim iaDataCount As Integer = _aData.Count

        If iaDataCount > 0 Then
            Dim cr As Rectangle = Me.ClientRectangle

            Using pen As Pen = New Pen(Color.FromArgb(205, Color.Aqua), 1)

                If _graphType = enumGraphType.curve Then
                    Dim aPoint(iaDataCount - 1) As System.Drawing.PointF

                    Dim currentValue As Integer = iaDataCount
                    Dim counterPoint = 0
                    Dim pointf = New PointF

                    For i = cr.Width To cr.Width - iaDataCount Step -1
                        If currentValue = 0 Then Exit For

                        pointf.X = i
                        pointf.Y = calcVerticalPosition(Convert.ToSingle(_aData(currentValue - 1)))

                        aPoint(counterPoint) = pointf
                        currentValue -= 1
                        counterPoint += 1
                    Next

                    If _aData.Count > 1 Then
                        gd.DrawCurve(pen, aPoint)
                    End If
                Else
                    Dim Ystart = cr.Height
                    Dim currentValue As Integer = iaDataCount

                    For i = cr.Width To cr.Width - iaDataCount Step -1
                        If currentValue = 0 Then Exit For

                        gd.DrawLine(pen, i, Ystart, i, calcVerticalPosition(Convert.ToSingle(_aData(currentValue - 1))))
                        currentValue -= 1
                    Next
                End If

            End Using
        End If

        ' affiche titre du graphique
        Using Brush As SolidBrush = New SolidBrush(Color.LightGray)
            gd.DrawString(Me.title, Me.Font, Brush, 0, 0)
        End Using

        e.Graphics.DrawImage(ibufferImage, 0, 0)

        e.Dispose()
        gd.Dispose()
        ibufferImage.Dispose()
    End Sub

    Private Sub drawGrid(ByRef g As Graphics)
        Dim cr As Rectangle = Me.ClientRectangle

        If _gridOffsetPosition >= 10 Then _gridOffsetPosition = 0

        Using pen As Pen = New Pen(Color.Green, 1)
            For i = cr.Width - _gridOffsetPosition To 0 Step -10
                g.DrawLine(pen, i, 0, i, cr.Height)
            Next

            For i = 0 To cr.Height Step 10
                g.DrawLine(pen, 0, i, cr.Width, i)
            Next
        End Using
    End Sub

    Public Sub clear()
        _aData.Clear()
        _retryCount = 0
        _currentMaxValue = 0
        Invalidate()
    End Sub

    Public Sub close()
        Me.closePerfCounter()
        log.addLogEntry(New cLogEntry(String.Format("Fermeture PerfCounter : {0}", Me.Name), cLogEntry.enumDebugLevel.DEBUG, _stationName, "", Nothing))
    End Sub

    Protected Overridable Sub closePerfCounter()
        If Not _perfCounter Is Nothing Then

            With _perfCounter
                .Close()
                .Dispose()
            End With

            _initialised = False
        End If
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        closePerfCounter()
    End Sub

    'Public Overloads Sub dispose()
    '    MyBase.Dispose()

    '    closePerfCounter()
    'End Sub

End Class
