Public Class freeMemoryGraph : Inherits baseGraphControl
    Public Event valueUpdated(ByVal v As Single)

    Public Sub New()
        MyBase.New()

        _graphType = enumGraphType.bar
    End Sub

    Protected Overrides Function getCounterValue() As Single
        MyBase.getCounterValue()

        Dim counterValue As Single = perfCounterHelper.getMemoryAvailableBytes(_perfCounter, _stationName)
        Dim totalPhysicalMemory As Single = Convert.ToSingle(_totPhyMemory)

        RaiseEvent valueUpdated(counterValue)

        Return perfCounterHelper.getFreeMemoryAsPercentage(totalPhysicalMemory, counterValue)
    End Function
End Class
