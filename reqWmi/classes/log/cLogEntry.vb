Imports System.Text.RegularExpressions

Public Class cLogEntry
    Public stationName As String
    Public origine As String
    Public dateLogEntry As Date
    Public message As String
    Public exception As Exception
    Public debugLevel As cLogEntry.enumDebugLevel
    Public serverLogMessage As Boolean

    Public Enum enumDebugLevel
        INFO = 0
        DEBUG = 1
        ERREUR = 2
    End Enum

    Public Sub New(ByVal message As String, _
                ByVal debugLevel As cLogEntry.enumDebugLevel, _
                Optional ByVal stationName As String = "", _
                Optional ByVal origine As String = "", _
                Optional ByVal exception As Exception = Nothing, _
                Optional ByVal serverLogMessage As Boolean = False)

        Me.stationName = stationName
        Me.origine = origine
        Me.message = message
        Me.exception = exception
        Me.debugLevel = debugLevel
        Me.dateLogEntry = Date.Now
        Me.serverLogMessage = serverLogMessage
    End Sub

    Public Sub New(ByVal message As String)
        Me.message = message
        Me.dateLogEntry = Date.Now
    End Sub

    Public Function getFormattedEntry() As String
        Dim stb As New System.Text.StringBuilder
        stb.Append(String.Format("{0} [{1}] [{2}] {3}", Me.dateLogEntry.ToString, stationName, debugLevel.ToString, message))

        If Not exception Is Nothing Then
            If exception.Message <> "" Then
                stb.Append(String.Format("EXCEPTION : {0}", Regex.Replace(exception.Message.ToString, "[\x00-\x1f]", "").Trim))
            Else
                stb.Append(String.Format("EXCEPTION : {0}", exception.GetType.ToString))
            End If
        End If

        Return stb.ToString
    End Function

End Class
