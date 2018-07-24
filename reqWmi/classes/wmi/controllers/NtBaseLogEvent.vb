Imports System.Management

Namespace wmi
    Public MustInherit Class NtBaseLogEvent
        Protected _wmiWrapper As cwmi
        Protected _moc As ManagementObjectCollection ' COM Wrapper => disposer ...
        Protected _listOfWin32LogEvents As New List(Of Win32_NTLogEvent)

        Protected Const FILTER_EVENTS_BEFORE_NUM_DAYS As UShort = 15

        Public ReadOnly Property listOfWin32LogEvents() As List(Of Win32_NTLogEvent)
            Get
                Return _listOfWin32LogEvents
            End Get
        End Property

        Public Sub New(ByRef wmiWrapper As cwmi)
            _wmiWrapper = wmiWrapper
        End Sub

        Protected Function getWqlProperties() As String()
            If program.isServerMode Then
                Return New String() {"eventcode", "sourcename", "insertionStrings", "logfile"}
            Else
                Return New String() {"timegenerated", "Message", "Type", "eventcode", "sourcename", "user", "insertionStrings", "logfile"}
            End If
        End Function

        Protected MustOverride Function getInstances() As Boolean

        Public Shared Function isEventOlderThanXDay(ByRef e As Win32_NTLogEvent) As Boolean
            ' parfois log corrompu et date absente ou invalide
            If e.TimeGenerated Is Nothing Then
                Return False
            End If

            Dim dateEvent As DateTime = ManagementDateTimeConverter.ToDateTime(e.TimeGenerated)
            Dim datediff As Long = DateAndTime.DateDiff(DateInterval.Day, dateEvent, Date.Now)

            Return datediff > FILTER_EVENTS_BEFORE_NUM_DAYS
        End Function


        ''' <summary>
        ''' Requete wmi ( managementObjectCollection)
        ''' et création d'une liste d'objets métiers ( plus de liaison COM )
        ''' </summary>
        ''' <remarks></remarks>
        Public Function selectAll() As Boolean
            If Not getInstances() Then
                log.addLogEntry(New cLogEntry(String.Format("Pas d'instance de classe disponible"), cLogEntry.enumDebugLevel.DEBUG))
                Return False
            End If

            Dim sw As New Stopwatch
            sw.Start()

            Try
                For Each mo As ManagementObject In _moc
                    Dim logEvent As Win32_NTLogEvent = New Win32_NTLogEvent()

                    For Each pData As PropertyData In mo.Properties
                        If mo.Item(pData.Name) IsNot Nothing Then
                            logEvent.GetType.GetProperty(pData.Name).SetValue(logEvent, pData.Value, Nothing)
                        End If
                    Next

                    _listOfWin32LogEvents.Add(logEvent)
                    logEvent = Nothing
                Next
            Catch ex As Exception
                log.addLogEntry(New cLogEntry("Erreur analyse log", cLogEntry.enumDebugLevel.ERREUR, _wmiWrapper.stationName, Nothing, Nothing))
            Finally
                _moc.Dispose()
            End Try

            sw.Stop()

            If Not program.isServerMode Then
                log.addLogEntry(New cLogEntry(String.Format("Parsing {0} ( {1} ms )", Me.GetType.Name, sw.ElapsedMilliseconds),
                                              cLogEntry.enumDebugLevel.INFO,
                                              _wmiWrapper.stationName,
                                              Nothing,
                                              Nothing))
            End If

            Return True
        End Function
    End Class

End Namespace
