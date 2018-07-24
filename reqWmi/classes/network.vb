Imports System.Net.NetworkInformation

Public Class network
    ' Obtient le délai du Ping en millisecondes
    ' @todo voir si possible de faire un flush du cache dns avant de pinguer ( probleme si changé adresse récemment)
    Public Shared Function getPingTime(ByVal stationName As String, _
                                       ByRef errMsg As String, _
                                       ByRef pingReply As PingReply, _
                                       ByRef oPing As Ping, _
                                       ByVal intBufferLenght() As Byte) As Boolean

        Try
            pingReply = oPing.Send(stationName, 4000, intBufferLenght)
            If pingReply.Status = IPStatus.Success Then
                Return True
            Else
                errMsg = pingReply.Status.ToString
                Return False
            End If

        Catch ex As PingException

            If TypeOf (ex.InnerException) Is System.Net.Sockets.SocketException Then
                errMsg = ex.InnerException.Message
            End If

            Return False
        End Try

        Return True
    End Function

    ''' <summary>
    ''' ping station
    ''' </summary>
    ''' <param name="stationName"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' appelé par frmMain avant scan station
    ''' TODO catcher exception hote inconnu ( résolution DNS KO ) 
    ''' et remonter info UI
    ''' </remarks>
    Public Shared Function ping(ByVal stationName As String,
                                Optional ByVal timeout As Integer = 4000) As Boolean
        Dim reply As PingReply
        Dim monPing As New Ping

        Try
            reply = monPing.Send(stationName, timeout)
            If reply.Status = IPStatus.Success Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            monPing.Dispose()
        End Try

        Return True
    End Function
End Class
