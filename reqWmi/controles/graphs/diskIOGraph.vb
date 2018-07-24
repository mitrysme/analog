Public Class diskIOGraph : Inherits baseGraphControl
    Private _diskBytesReadSec As PerformanceCounter
    Private _diskWriteReadSec As PerformanceCounter

    Public Event valueUpdated(ByVal r As Single, ByVal w As Single)

    Public Sub New()
        MyBase.New()
       
        _graphType = enumGraphType.curve
        _scaleMode = scaleMode.relative
    End Sub

    Protected Overrides Sub initPerfCounter()
        _diskBytesReadSec = New PerformanceCounter
        _diskWriteReadSec = New PerformanceCounter
    End Sub


    Protected Overrides Sub closePerfCounter()
        If Not _initialised Then Exit Sub

        With _diskBytesReadSec
            .Close()
            .Dispose()
        End With
        With _diskWriteReadSec
            .Close()
            .Dispose()
        End With

        _initialised = False
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.dispose(disposing)

        closePerfCounter()
    End Sub

    ''' <summary>
    ''' Total disk IO
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    Protected Overrides Function getCounterValue() As Single
        MyBase.getCounterValue()

        Dim readBytes As Single = perfCounterHelper.getDiskBytesReadSec(_diskBytesReadSec, _stationName, Nothing)
        Dim writeBytes As Single = perfCounterHelper.getDiskBytesWriteSec(_diskWriteReadSec, _stationName, Nothing)
        Dim totalBytes As Single = readBytes + writeBytes

        RaiseEvent valueUpdated(readBytes, writeBytes)

        Return totalBytes
    End Function
End Class
