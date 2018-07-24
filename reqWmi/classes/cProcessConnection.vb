Imports System.Management
Imports AnalogEnums.enums
Imports System.Threading

Public Class cProcessConnection
    Private _control As Control
    Private _deg As [Delegate]
    Private _busy As Boolean = False
    Private _isCanceled As Boolean = False
    Private _asyncResult As IAsyncResult
    Private _station As cstation
    Private _lock As New Object
    Private _processWmi As wmi.Process
    Friend Shared _semEnumProcess As New Semaphore(1, 1)
    'Private _semEnumProcess As New Semaphore(1, 1) ' si un thread bloque ( getprocessOwner par exemple, tous les threads sont bloqués par ce sémaphore )

    Public Property isCanceled() As Boolean
        Get
            Return _isCanceled
        End Get
        Set(ByVal value As Boolean)
            _isCanceled = value
        End Set
    End Property
    Public ReadOnly Property processWmi() As wmi.Process
        Get
            Return _processWmi
        End Get
    End Property

    Public Property syncBusyFlag() As Boolean
        Get
            SyncLock _lock
                Return _busy
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            SyncLock _lock
                _busy = value
            End SyncLock
        End Set
    End Property

    ' délégués
    Public Delegate Sub HasEnumeratedEventHandler(ByVal Dico As Dictionary(Of String, cProcessInfos))

    Public Sub New(ByVal controlToInvoke As Control, _
                   ByVal deg As [Delegate], _
                   ByRef station As cstation) ' si on pouvait éviter de passer un objet cstation ...

        _control = controlToInvoke
        _deg = deg
        _station = station
        _processWmi = New wmi.Process
    End Sub

    Public Sub asyncUpdate()
        If Not syncBusyFlag Then
            ThreadPool.QueueUserWorkItem(AddressOf getWmiProcess)
        Else
            Debug.Print("Process connection est occupé, abandon ...")
        End If
    End Sub

    ' voir http://msdn.microsoft.com/fr-fr/library/0ka9477y%28VS.80%29.aspx ( RegisterWaitForSingleObject )

    Private Sub getWmiProcess()
        syncBusyFlag = True

        If _station Is Nothing Then
            'TODO un envoi log sans nom de station ne passe plus depuis ajout tabsMDI , à vérifier ...
            log.addLogEntry(New cLogEntry(" cProcessConnection station is nothing , exiting", cLogEntry.enumDebugLevel.DEBUG))
            Exit Sub
        End If

        If Not _station.wmi.isConnected Then
            log.addLogEntry(New cLogEntry(" cProcessConnection station non connectée, Exiting", cLogEntry.enumDebugLevel.DEBUG))
            Exit Sub
        End If

        _semEnumProcess.WaitOne()

        Dim dicProcess = New Dictionary(Of String, cProcessInfos)
        Dim success As Boolean = True

        success = _processWmi.enumerate(dicProcess, _station)

        If success Then
            If Not _isCanceled Then
                If Not _control.Disposing Then
                    Try
                        _asyncResult = _control.BeginInvoke(_deg, dicProcess)
                    Catch ex As Exception
                        Debug.Print("process => invoke failed")
                    End Try
                End If
            Else
                log.addLogEntry(New cLogEntry(" invoke lvProcess ( cprocessConnection ) abandonné", cLogEntry.enumDebugLevel.DEBUG))
            End If
        Else
            log.addLogEntry(New cLogEntry("Enumeration processes KO", cLogEntry.enumDebugLevel.ERREUR, _station.stationName))
        End If

        syncBusyFlag = False
        _semEnumProcess.Release()

        _isCanceled = False
    End Sub

    Public Function isInvokecompleted() As Boolean
        If _asyncResult Is Nothing Then
            Return True
        End If

        If _asyncResult.IsCompleted Or _asyncResult.CompletedSynchronously Then
            Return True
        Else
            log.addLogEntry(New cLogEntry(" isinvokeCompleted ==> false ", cLogEntry.enumDebugLevel.DEBUG))
            Return False
        End If
    End Function
End Class
