Imports System.IO

Public Class clog
    Private _colLogEntries As New List(Of cLogEntry)
    Private _logDiskWriter As StreamWriter ' StreamWriter pour écriture log sur disque
    Private _syncDiskWriter As TextWriter ' wrapper threadSafe

    Const MAX_LOG_ENTRY As Integer = 100

    Public Event eventLogItemAdded(ByVal logentry As cLogEntry)

    Public ReadOnly Property colLogEntries() As List(Of cLogEntry)
        Get
            Return _colLogEntries
        End Get
    End Property

    ''' <summary>
    '''
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        If program.isServerMode Then
            Try
                _logDiskWriter = New StreamWriter(String.Concat(program.applicationPath, "\logScan.txt"), True)
                _syncDiskWriter = StreamWriter.Synchronized(_logDiskWriter)
            Catch ex As IO.IOException
                _logDiskWriter = Nothing
                _syncDiskWriter = Nothing
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Ajoute une entrée de log dans la collection
    ''' </summary>
    ''' <param name="logEntry"></param>
    ''' <remarks></remarks>
    Public Sub addLogEntry(ByVal logEntry As cLogEntry)


        ' limite le nombre d'entrées dans le log si le programme n'est pas en mode serveur
        If Not program.isServerMode Then
            If _colLogEntries.Count > MAX_LOG_ENTRY Then _colLogEntries.RemoveAt(0)
            If Not toLog(logEntry) Then
                Exit Sub
            End If
        End If

        SyncLock _colLogEntries
            _colLogEntries.Add(logEntry)
        End SyncLock

        If program.isServerMode And logEntry.serverLogMessage Then
            If Not _syncDiskWriter Is Nothing Then
                _syncDiskWriter.WriteLine(logEntry.dateLogEntry & " " & logEntry.message)
            End If
        End If

        RaiseEvent eventLogItemAdded(logEntry)
    End Sub

    ''' <summary>
    ''' </summary>
    ''' <param name="logEntry"></param>
    ''' <returns>renvoie vrai si l'entrée doit être loguée</returns>
    ''' <remarks>
    ''' TODO : pourquoi tester logentry passé en paramètre + settings preferences ....
    ''' </remarks>
    Private Function toLog(ByVal logEntry As cLogEntry) As Boolean
        If logEntry Is Nothing Then
            Return True
        Else
            Select Case logEntry.debugLevel
                Case cLogEntry.enumDebugLevel.DEBUG
                    If program.preferences.cbDebug Then
                        Return True
                    End If
                Case cLogEntry.enumDebugLevel.ERREUR
                    If program.preferences.cbErreur Then
                        Return True
                    End If
                Case cLogEntry.enumDebugLevel.INFO
                    If program.preferences.cbInfo Then
                        Return True
                    End If
            End Select
        End If

        Return False
    End Function

    ''' <summary>
    ''' Ferme streamWriter
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub dispose()
        If Not _logDiskWriter Is Nothing Then
            _logDiskWriter.Close()
            _logDiskWriter.Dispose()
        End If
    End Sub

End Class
