Public Class psExec
    Public Shared Sub defrag(ByVal stationName As String,
                             Optional ByVal analyseOnly As Boolean = False)
        Dim prc As New System.Diagnostics.Process

        Dim cmdArgs As String = String.Empty
        If analyseOnly Then
            cmdArgs = String.Format("/k psexec \\{0} defrag c: -a", stationName)
        Else
            cmdArgs = String.Format("/k psexec \\{0} defrag c: -f -v", stationName)
        End If

        Dim psi As ProcessStartInfo = New ProcessStartInfo("cmd.exe", cmdArgs)

        prc.StartInfo = psi

        Try
            prc.Start()
        Catch ex As Exception
            MsgBox("Impossible de lancer le process, PsExec n'est peut être pas installé ?", MsgBoxStyle.Exclamation)
        Finally
            If Not prc Is Nothing Then
                prc.Dispose()
            End If
        End Try
    End Sub

    'Public Shared Sub openCMD(ByVal stationName As String)
    '    Dim prc As New System.Diagnostics.Process
    '    Dim cmdArgs As String = String.Empty

    '    cmdArgs = String.Format("/k psexec \\{0} cmd", stationName)

    '    Dim psi As ProcessStartInfo = New ProcessStartInfo("cmd.exe", cmdArgs)

    '    prc.StartInfo = psi

    '    Try
    '        prc.Start()
    '    Catch ex As Exception
    '        MsgBox("Impossible de lancer le process, PsExec n'est peut être pas installé ?", MsgBoxStyle.Exclamation)
    '    Finally
    '        If Not prc Is Nothing Then
    '            prc.Dispose()
    '        End If
    '    End Try
    'End Sub

    Public Shared Sub openRemotConsole(ByVal stationName As String)

        Dim prc As New System.Diagnostics.Process
        Dim cmdArgs As String = String.Format("/k psexec \\{0} cmd", stationName)
        Dim psi As ProcessStartInfo = New ProcessStartInfo("cmd", cmdArgs)

        prc.StartInfo = psi

        Try
            prc.Start()
        Catch ex As Exception
            MsgBox("Impossible de lancer le process, PsExec n'est peut être pas installé ?", MsgBoxStyle.Exclamation)
        Finally
            If Not prc Is Nothing Then
                prc.Dispose()
            End If
        End Try

    End Sub

    Public Shared Sub chkdsk(ByVal stationName As String, _
                             Optional ByVal bRepairFlag As Boolean = False)
        Dim prc As New System.Diagnostics.Process

        Dim cmdArgs As String = String.Empty
        If bRepairFlag Then
            cmdArgs = String.Format("/k psexec \\{0} chkdsk c: /F /R", stationName)
        Else
            cmdArgs = String.Format("/k psexec \\{0} chkdsk c: /F", stationName)
        End If

        Dim psi As ProcessStartInfo = New ProcessStartInfo("cmd.exe", cmdArgs)

        prc.StartInfo = psi

        Try
            prc.Start()
        Catch ex As Exception
            MsgBox("Impossible de lancer le process, PsExec n'est peut être pas installé ?", MsgBoxStyle.Exclamation)
        Finally
            If Not prc Is Nothing Then
                prc.Dispose()
            End If
        End Try
    End Sub

    Public Shared Sub shutdownOrReboot(ByVal stationName As String, _
                                       Optional ByVal bReboot As Boolean = False, _
                                       Optional ByVal bForce As Boolean = False)

        Dim sRebootFlag, sForceSwitch As String

        If bReboot Then
            sRebootFlag = "-r"
        Else
            sRebootFlag = "-s"
        End If

        If bForce Then
            sForceSwitch = "-f"
        Else
            sForceSwitch = ""
        End If

        Dim prc As New System.Diagnostics.Process

        Try
            With prc
                .StartInfo.UseShellExecute = True
                .StartInfo.FileName = "psexec"
                .StartInfo.Arguments = String.Format(" \\{0} shutdown {1} {2} -t 0 ", stationName, sRebootFlag, sForceSwitch)
                .Start()
            End With
        Catch ex As System.ComponentModel.Win32Exception
            MsgBox("Impossible de lancer le process, PsExec n'est peut être pas installé ?", MsgBoxStyle.Exclamation)
        Finally
            If Not prc Is Nothing Then
                prc.Dispose()
            End If
        End Try
    End Sub
End Class
