Public Class cpuGraph : Inherits baseGraphControl
    Public Event valueUpdated(ByVal v As Single)

    Public Sub New()
        MyBase.New()
        _graphType = enumGraphType.curve
    End Sub

    Protected Overrides Function getCounterValue() As Single
        MyBase.getCounterValue()

        Dim cpuCounterUsage As Single = perfCounterHelper.getProcessorValue(_perfCounter, _stationName)

        RaiseEvent valueUpdated(CType(Math.Round(cpuCounterUsage), Single))

        Return cpuCounterUsage
    End Function
End Class
