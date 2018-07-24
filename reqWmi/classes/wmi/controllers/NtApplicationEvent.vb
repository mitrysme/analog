Imports System.Management

Namespace wmi

    Public Class NtApplicationEvent
        Inherits NtBaseLogEvent

        Public Sub New(ByRef wmiWrapper As cwmi)
            MyBase.New(wmiWrapper)
        End Sub

        ''' <summary>
        ''' Sélectionne instances de la classe
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' Sélectionne tous les evènements de type erreur application
        ''' ainsi que les erreurs office
        ''' </remarks>
        Protected Overrides Function getInstances() As Boolean
            If _wmiWrapper.isConnected Then

                Return _wmiWrapper.getResultsFor(_moc, _
                                          "Win32_NTLogEvent", "Logfile = 'Application' and type='Erreur'", _
                                          getWqlProperties())
            End If
        End Function

        Public Function countOfficeErrors(ByVal filterByDate As Boolean) As Integer
            Dim errCount As Integer = 0

            For Each e As Win32_NTLogEvent In Me.listOfWin32LogEvents
                    If e.SourceName.Contains("Microsoft Office") And e.Type.ToLowerInvariant = "erreur" And e.EventCode = 1000 Then
                        If Not filterByDate Then
                            errCount += 1
                        Else
                            If Not isEventOlderThanXDay(e) Then
                                errCount += 1
                            End If
                        End If

                    End If
                Next

            Return errCount
        End Function

        Public Function countApplicationErrors(ByVal filterByDate As Boolean) As Integer
            Dim errCount As Integer = 0

            For Each e As Win32_NTLogEvent In Me.listOfWin32LogEvents
                If e.Logfile = "Application" And e.SourceName = "Application Error" Or
                    e.Logfile = "Application" And e.SourceName = "Application Hang" Then
                    If Not filterByDate Then
                        errCount += 1
                    Else
                        If Not isEventOlderThanXDay(e) Then
                            errCount += 1
                        End If
                    End If
                End If
            Next


                Return errCount
        End Function
    End Class
End Namespace