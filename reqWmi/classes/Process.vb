Imports System.Management
Imports AnalogEnums.enums

Namespace wmi
    Public Class Process

        Private _dicNewProcess As New Dictionary(Of Integer, Boolean)

        ''' <summary>
        ''' Vidage dico new processes
        ''' </summary>
        ''' <remarks>
        ''' A utiliser lors de la déco d'une station 
        ''' on accède à _dicNewprocess (shared) depuis plusieurs threads
        ''' Absolument pas thread safe => crash à prévoir 
        ''' </remarks>
        Public Sub clearDicNewProcesses()
            _dicNewProcess.Clear()
        End Sub

        ''' <summary>
        ''' Création dictionnaire processInfos
        ''' </summary>
        ''' <param name="_dico"></param>
        ''' <returns>Boolean</returns>
        ''' <remarks></remarks>
        Public Function enumerate(ByRef _dico As Dictionary(Of String, cProcessInfos), _
                                         ByRef station As cstation) As Boolean

            Dim processList As ManagementObjectCollection = Nothing

            If station.wmi.getResultsFor(processList, "Win32_Process", Nothing, Nothing) Then

                Try
                    For Each it As ManagementObject In processList
                        Dim processInfos As New cProcessInfos

                        With processInfos
                            .pid = CUInt(it.Item(WmiInfoProcess.ProcessId.ToString))
                            .name = CStr(it.Item(WmiInfoProcess.Name.ToString))
                            .usertime = CLng(it.Item(WmiInfoProcess.UserModeTime.ToString))
                            .kernelTime = CLng(it.Item(WmiInfoProcess.KernelModeTime.ToString))
                            .threadCount = CUInt(it.Item(WmiInfoProcess.ThreadCount.ToString))
                            .pageFaults = CUInt(it.Item(WmiInfoProcess.PageFaults.ToString))
                            .WorkingSetSize = CUInt(it.Item(WmiInfoProcess.WorkingSetSize.ToString))
                            .VirtualSize = CULng(it.Item(WmiInfoProcess.VirtualSize.ToString))
                            .Priority = CUInt(it.Item(WmiInfoProcess.Priority.ToString))
                            .ParentProcessId = CUInt(it.Item(WmiInfoProcess.ParentProcessId.ToString))
                        End With

                        If _dicNewProcess.ContainsKey(CInt(it.Item(WmiInfoProcess.ProcessId.ToString))) = False Then
                            With processInfos
                                .path = CStr(it.Item(WmiInfoProcess.ExecutablePath.ToString))
                                .userName = getProcessOwner(it, station.stationName)
                            End With

                            _dicNewProcess.Add(CInt(it.Item(WmiInfoProcess.ProcessId.ToString)), False)
                        End If

                        ' Set true so that the process is marked as existing
                        _dicNewProcess(CInt(it.Item(WmiInfoProcess.ProcessId.ToString))) = True
                        Dim sKey As String = CStr(it.Item(WmiInfoProcess.ProcessId.ToString))
                        If _dico.ContainsKey(sKey) = False Then
                            _dico.Add(sKey, processInfos)
                        End If
                    Next
                Catch ex As Exception
                    Return False
                Finally
                    If processList IsNot Nothing Then
                        processList.Dispose()
                    End If
                End Try

                Dim nbProcesses As Integer = _dico.Count

                ' Remove all processes that not exist anymore
                Dim _dicoTemp As Dictionary(Of Integer, Boolean) = _dicNewProcess
                For Each it As System.Collections.Generic.KeyValuePair(Of Integer, Boolean) In _dicoTemp
                    If it.Value = False Then
                        _dicNewProcess.Remove(it.Key)
                    End If
                Next

                Return True
            Else
                Return False ' impossible de récupérer les processes
            End If
        End Function

        ''' <summary>
        ''' récupère le owner du process passé en param
        ''' </summary>
        ''' <param name="it"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getProcessOwner(ByVal it As ManagementObject, ByVal stationName As String) As String
            Dim s1(1) As String
            Dim username As String = ""

            Try

                Call it.InvokeMethod("getowner", s1)

                If Len(s1(0)) + Len(s1(1)) > 0 Then
                    username = String.Format("{0}\{1}", s1(1), s1(0))
                End If
            Catch ex As System.Management.ManagementException
                If ex.ErrorCode = ManagementStatus.NotFound Then
                    log.addLogEntry(New cLogEntry(String.Format("Impossible d'obtenir le owner du Process, il n'existe pas (fermé ? )... Path : {0}, Exception : {1}", it.Path.ToString, ex.Message), cLogEntry.enumDebugLevel.DEBUG, stationName))
                End If
            Catch ex As Exception
                log.addLogEntry(New cLogEntry(String.Format("Impossible de récupérer le Owner du Process, Exception : {0}  Path : {1}", ex.Message, it.Path.ToString), cLogEntry.enumDebugLevel.DEBUG, stationName))
            End Try

            Return username
        End Function

        ' YAPM
        Public Shared Function KillProcess(ByVal process As cProcessInfos, _
                                           ByRef msgError As String, _
                                           ByRef station As cstation) As Boolean
            ' confirmation
            Dim text As String = "Etes vous sur de vouloir tuer le process : " & process.name
            Dim result As DialogResult
            result = MessageBox.Show(text, "Kill Process", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If Not result = Windows.Forms.DialogResult.Yes Then
                Return True
            End If

            Try
                Dim _theProcess As Management.ManagementObject = Nothing
                Dim _colProcess As ManagementObjectCollection = Nothing

                If station.wmi.getResultsFor(_colProcess, "Win32_Process", Nothing, Nothing) Then
                    For Each pp As Management.ManagementObject In _colProcess
                        If CInt(pp("ProcessId")) = process.pid Then
                            _theProcess = pp
                            Exit For
                        End If
                    Next
                End If

                If _theProcess IsNot Nothing Then
                    Dim ret As WmiProcessReturnCode
                    ret = CType(_theProcess.InvokeMethod("Terminate", Nothing), WmiProcessReturnCode)
                    msgError = ret.ToString
                    Return (ret = WmiProcessReturnCode.SuccessfulCompletion)
                Else
                    msgError = "Process inconnu"
                    Return False
                End If
            Catch ex As Exception
                msgError = ex.Message
                Return False
            End Try

        End Function
    End Class

End Namespace
