Public Class networkIOgraph : Inherits baseGraphControl

    Private _instancesNames() As String
    Private _netRcvCounters() As PerformanceCounter
    Private _netSentCounters() As PerformanceCounter
    'Private _initialised As Boolean
    Public Event valueUpdated(ByVal i As Single, ByVal o As Single)

    Public Sub New()
        MyBase.New()

        '_initialised = False
        _graphType = enumGraphType.curve
        _scaleMode = scaleMode.relative
    End Sub

    Protected Overrides Sub initPerfCounter()
        Dim performanceCounterCategory As PerformanceCounterCategory = New PerformanceCounterCategory("Network Interface", _stationName)
        _instancesNames = performanceCounterCategory.GetInstanceNames

        ReDim _netRcvCounters(_instancesNames.Length - 1)
        ReDim _netSentCounters(_instancesNames.Length - 1)

        For i = 0 To _instancesNames.Length - 1 Step 1
            _netRcvCounters(i) = New PerformanceCounter
        Next

        For i = 0 To _instancesNames.Length - 1 Step 1
            _netSentCounters(i) = New PerformanceCounter
        Next

        ' _initialised = True
    End Sub


    Protected Overrides Function getCounterValue() As Single
        MyBase.getCounterValue()

        Dim sRcv, sSen As Single

        ' additionne received/sent bytes pour toutes les interfaces réseaux
        For i = 0 To _instancesNames.Length - 1 Step 1
            sRcv += perfCounterHelper.getNetworkBytesReceivedSec(_netRcvCounters(i), _stationName, _instancesNames(i))
            sSen += perfCounterHelper.getNetworkBytesSentSec(_netSentCounters(i), _stationName, _instancesNames(i))
        Next

        RaiseEvent valueUpdated(sRcv, sSen)

        Return sRcv + sSen
    End Function

    Protected Overrides Sub closePerfCounter()
        If Not _initialised Then Exit Sub

        For Each counter As PerformanceCounter In _netRcvCounters
            With counter
                .Close()
                .Dispose()
            End With
        Next

        For Each counter As PerformanceCounter In _netSentCounters
            With counter
                .Close()
                .Dispose()
            End With
        Next

        _netRcvCounters = Nothing
        _netSentCounters = Nothing

        _initialised = False
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.dispose(disposing)
        closePerfCounter()
    End Sub

    'Public Overloads Sub dispose()
    '    MyBase.dispose()
    '    closePerfCounter()

    '    'If Not _initialised Then Exit Sub

    '    'For Each counter As PerformanceCounter In _netRcvCounters
    '    '    With counter
    '    '        .Close()
    '    '        .Dispose()
    '    '    End With
    '    'Next

    '    'For Each counter As PerformanceCounter In _netSentCounters
    '    '    With counter
    '    '        .Close()
    '    '        .Dispose()
    '    '    End With
    '    'Next

    '    '_netRcvCounters = Nothing
    '    '_netSentCounters = Nothing

    '    '_initialised = False
    'End Sub

    'Public Overloads Sub clear()
    '    MyBase.clear()

    '    If _initialised Then
    '        Array.Clear(_instancesNames, 0, _instancesNames.Length)
    '    End If

    'End Sub

End Class
