Option Strict On

Imports System.Windows.Forms
Imports System.Net

Public Class frmError

    Private _theExeption As Exception
    Private _canClose As Boolean = False


    Public Sub New(ByVal e As Exception)

        InitializeComponent()

        _theExeption = e

        '
        ' Si erreur grave dans message exception 
        ' on ne laisse pas la possibilité de continuer
        '
        If Not _theExeption.Message Is Nothing Then
            If _theExeption.Message.Contains("Erreur grave") Then
                Me.cmdIgnore.Enabled = False
            End If
        End If

        '
        ' calcul uptime application 
        '
        Dim tsUptimeApp As TimeSpan = Date.Now - program.applicationStartDate
        Dim sCrashUptime As String = String.Format("Jours : {0} ; Heures : {1} ; Minutes : {2} ; Secondes : {3}", _
                                                   tsUptimeApp.Days, tsUptimeApp.Hours, tsUptimeApp.Minutes, tsUptimeApp.Seconds)
        '
        '
        ' Create a log
        '
        Dim s As String = ""
        s &= "System informations : "
        s &= vbNewLine & vbTab & "Name : " & My.Computer.Info.OSFullName
        s &= vbNewLine & vbTab & "Platform : " & My.Computer.Info.OSPlatform
        s &= vbNewLine & vbTab & "Version : " & My.Computer.Info.OSVersion.ToString
        s &= vbNewLine & vbTab & "UICulture : " & My.Computer.Info.InstalledUICulture.ToString
        's &= vbNewLine & vbTab & "Processor count : " & Program.PROCESSOR_COUNT.ToString
        's &= vbNewLine & vbTab & "Physical memory : " & GetFormatedSize(My.Computer.Info.AvailablePhysicalMemory) & "/" & GetFormatedSize(My.Computer.Info.TotalPhysicalMemory)
        's &= vbNewLine & vbTab & "Virtual memory : " & GetFormatedSize(My.Computer.Info.AvailableVirtualMemory) & "/" & GetFormatedSize(My.Computer.Info.TotalVirtualMemory)
        s &= vbNewLine & vbTab & "Screen : " & My.Computer.Screen.Bounds.ToString
        s &= vbNewLine & vbTab & "IntPtr.Size : " & IntPtr.Size.ToString
        s &= vbNewLine & vbNewLine
        s &= "Application informations : "
        s &= vbNewLine & vbTab & "Path : " & My.Application.Info.DirectoryPath
        s &= vbNewLine & vbTab & "Version : " & My.Application.Info.Version.ToString
        s &= vbNewLine & vbTab & "Ram Utilisée (Megas) : " & CInt(System.Diagnostics.Process.GetCurrentProcess.WorkingSet64 / 1024 / 1024)
        s &= vbNewLine & vbTab & "Nombre de handles : " & Process.GetCurrentProcess.HandleCount.ToString
        ' s &= vbNewLine & vbTab & "Nombre d'objets GDI : " & native.api.nativeFunctions.GetGuiResources(CLng(Process.GetCurrentProcess.Handle), 0)
        s &= vbNewLine & vbTab & "Nb. Onglets : " & program.frmMdiContainer.windowManager.GetAllWindows(True).Count.ToString
        s &= vbNewLine & vbTab & "Uptime application : " & sCrashUptime
        s &= vbNewLine & vbNewLine
        s &= "Erreur : "
        s &= vbNewLine & vbTab & "Message : " & e.Message
        s &= vbNewLine & vbTab & "Source : " & e.Source
        s &= vbNewLine & vbTab & "StackTrace : " & e.StackTrace
        s &= vbNewLine & vbTab & "Target : " & e.TargetSite.ToString
        s &= vbNewLine & vbNewLine
        'Debug.Print(System.Diagnostics.Process.GetCurrentProcess.Handle)

        '
        ' Affiche détails innerException si présente
        '
        If Not e.InnerException Is Nothing Then
            s &= "Inner Exception : "
            s &= vbNewLine & vbTab & "Message : " & e.InnerException.Message
            s &= vbNewLine & vbTab & "Source : " & e.InnerException.Source
            s &= vbNewLine & vbTab & "StackTrace : " & e.InnerException.StackTrace
            s &= vbNewLine & vbTab & "Target : " & e.InnerException.TargetSite.ToString
            s &= vbNewLine & vbNewLine
        End If

        '
        ' Infos Sur nombre threads en cours
        '
        Dim availableWorkerThread, availableThreadPoolThreadcount, maxThreadPoolThreadcount, maxIothreadPoolcount As Integer
     
        System.Threading.ThreadPool.GetAvailableThreads(availableWorkerThread, availableThreadPoolThreadcount)
        System.Threading.ThreadPool.GetMaxThreads(maxThreadPoolThreadcount, maxIothreadPoolcount)

        Dim activeThreadcount As Integer = maxThreadPoolThreadcount - availableWorkerThread

        s &= "Etat ThreadPool : " & vbNewLine & vbNewLine
        s &= String.Format("maxThreadPoolthreadCount : {0}, availablethreadPoolcount : {1}, activethreadcount : {2}", maxThreadPoolThreadcount, availableWorkerThread, activeThreadcount)
        s &= vbNewLine
        '
        ' affiche 50 dernieres entrées log 
        ' Ne fonctionne plus depuis ajout gestionnaire tabMDI
        '
        's &= vbNewLine
        's &= " ========================= 50 Dernières entrées log lvlog ==============="
        's &= vbNewLine

        'Dim lvi As ListView.ListViewItemCollection = program.frmMain.lvLog.Items

        'If lvi.Count > 0 Then
        '    Dim lviCount As Integer = lvi.Count - 1
        '    Dim c As Integer = 0

        '    For i As Integer = lviCount To 0 Step -1
        '        s &= lvi(i).Text & vbNewLine
        '        c += 1

        '        If c >= 50 Then Exit For
        '    Next
        'End If


        ' liste les assemblys chargés 
        s &= vbNewLine & vbNewLine
        s &= "============================ loaded Assemblys ============================="
        s &= vbNewLine & vbNewLine
        Dim aFullName() As String
        For Each assembly In AppDomain.CurrentDomain.GetAssemblies
            aFullName = Split(assembly.FullName, ",")

            s &= "Fullname : " & aFullName(0) & vbNewLine
            s &= "Version  : " & aFullName(1) & vbNewLine
            s &= "Culture  : " & aFullName(2) & vbNewLine
            s &= "PublicKeyToken : " & aFullName(3) & vbNewLine
            ' s &= "Location : " & assembly.Location & vbNewLine

            s &= vbNewLine
        Next

        s &= "Infos diverses : "
        s &= vbNewLine & vbTab & "Elapsed time : " & program.ElapsedTime
        s &= vbNewLine & vbNewLine

        Me.txtReport.Text = s
    End Sub


    Private Sub cmdIgnore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIgnore.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Envoi mail de Crash
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdSend_Click(ByVal sender As System.Object,
                              ByVal e As System.EventArgs) Handles btSend.Click

        Dim fromUser As String = String.Format("{0}@{1}", Environment.UserName, Environment.UserDomainName)
        Dim toUser As String = "dimitri.darcam.exterieur@chu-bordeaux.fr"

        ' rajout des commentaires dans le rapport
        Me.txtReport.Text &= "Commentaires : "
        Me.txtReport.Text &= vbNewLine
        Me.txtReport.Text &= Me.txtCommentaires.Text

        If Analog.functions.misc.SendMail(fromUser, toUser, "Crash Analog", Me.txtReport.Text) Then
            MsgBox("Le message a été envoyé, merci")
            btSend.Enabled = False
        Else
            MsgBox("Erreur envoi message")
        End If
    End Sub

    Private Sub cmdQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuit.Click
        program.AnalogExit()
        Application.Exit()
    End Sub
End Class
