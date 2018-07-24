Imports System.Management

Namespace wmi

    Public Class Service
        Private _wmiWrapper As cwmi
        Private _moc As ManagementObjectCollection

        Public Sub New(ByRef wmiWrapper As cwmi)
            _wmiWrapper = wmiWrapper
        End Sub

        Private Function getInstances() As Boolean
            If _wmiWrapper.isConnected Then

                Return _wmiWrapper.getResultsFor(_moc, _
                                          "Win32_Service", _
                                          Nothing, _
                                          New String() {"Started", "DisplayName", "Description", "StartMode", "StartName", "PathName", "ServiceType", "Name", "ProcessId"})

            End If
        End Function


        ''' <summary>
        ''' Retourne le nombre de services démarrés dans la liste passée en paramètre
        ''' </summary>
        ''' <param name="listOfServices">Liste de service</param>
        ''' <returns>integer</returns>
        ''' <remarks></remarks>
        Public Shared Function getNumberOfStartedServices(ByRef listOfServices As List(Of Win32_Service)) As Integer
            Dim nbOfStartedService As Integer = 0

            For Each Service As Win32_Service In listOfServices
                If Service.Started Then
                    nbOfStartedService += 1
                End If
            Next

            Return nbOfStartedService
        End Function

        Public Function selectAll() As List(Of wmi.Win32_Service)
            If Not getInstances() Then
                Return Nothing
            End If

            Dim listOfservice As New List(Of Win32_Service)

            Try
                For Each mo As Management.ManagementObject In _moc
                    Dim service As Win32_Service = New Win32_Service

                    With service
                        .DisplayName = CType(mo.Item("DisplayName"), String)
                        .Description = CType(mo.Item("Description"), String)
                        '.State = CType(mo.Item("State"), String) ' état
                        .Started = CType(mo.Item("Started"), Boolean) ' démarré Y/N
                        .StartName = CType(mo.Item("StartName"), String) ' nom du compte sous lequel tourne le service
                        .StartMode = CType(mo.Item("StartMode"), String) ' type de démarrage ( auto, manuel , etc ... )
                        .PathName = CType(mo.Item("PathName"), String) ' Path
                        .ServiceType = CType(mo.Item("ServiceType"), String)
                        .ProcessId = CType(mo.Item("ProcessId"), UInt32) ' identifiant unique du service
                        .Name = CType(mo.Item("Name"), String)
                    End With

                    listOfservice.Add(service)
                    service = Nothing
                Next
            Catch ex As Exception
                log.addLogEntry(New cLogEntry("Erreur récupération infos services", cLogEntry.enumDebugLevel.ERREUR, _wmiWrapper.stationName, "wmi\controller\sercice", ex))
            Finally
                If _moc IsNot Nothing Then
                    _moc.Dispose()
                End If
            End Try

            Return listOfservice
        End Function

    End Class
End Namespace
