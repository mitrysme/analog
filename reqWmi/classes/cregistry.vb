Imports Microsoft.Win32 ' registre
Imports System.Security.Permissions
Imports System.Security.AccessControl ' pour permissions registre
Imports structs

'
' TODO : Encapsuler tous les types registryKey dans des USING ... END USING 
' registryKey est disposable à partir de .net 4.0 
'

Public Class cregistry

    ''' <summary>
    ''' Récupère la liste des programmes installées dans le registre
    ''' piqué et adapté d'ici : http://www.vbforums.com/showthread.php?t=592497
    ''' </summary>
    ''' <param name="stationName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetInstalledComponents(ByVal stationName As String,
                                                  ByRef colInstalledPrograms As List(Of cPrograms.InstalledProgram)) As Boolean

        Dim uninstallkey As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"
        Dim strReturnString As String = ""

        Try
            Using rk As RegistryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, stationName).
                OpenSubKey(uninstallkey, RegistryKeyPermissionCheck.ReadSubTree, RegistryRights.ReadKey)

                Dim skname() = rk.GetSubKeyNames
                Dim Regkey As String = Nothing
                For counter As Integer = 0 To skname.Length - 1
                    Using sk As RegistryKey = rk.OpenSubKey(skname(counter))
                        If sk Is Nothing Then
                            log.addLogEntry(New cLogEntry(String.Format("Cle registre corrompue , impossible d'ouvrir : {0}",
                                                                        skname(counter)
                                                                        ),
                                                          cLogEntry.enumDebugLevel.ERREUR, stationName, "cregistry", Nothing
                                                          )
                                            )
                            Continue For
                        End If

                        If CStr(sk.GetValue("DisplayName")) <> "" Then
                            Dim program As New cPrograms.InstalledProgram
                            With program
                                .DisplayName = CStr(sk.GetValue("DisplayName"))
                                .DisplayVersion = CStr(sk.GetValue("DisplayVersion"))
                                .Publisher = CStr(sk.GetValue("Publisher"))
                                .filtered = False
                                .InstallDate = CStr(sk.GetValue("InstallDate"))
                                .UninstallString = CStr(sk.GetValue("UninstallString"))
                            End With
                            If Not colInstalledPrograms.Contains(program) Then
                                colInstalledPrograms.Add(program)
                            End If
                        End If
                    End Using
                Next
            End Using

            Return True
        Catch ex As Exception
            log.addLogEntry(New cLogEntry("Impossible de récupérer programmes", cLogEntry.enumDebugLevel.ERREUR, stationName, "cregistry", ex))
            Return False
        End Try
    End Function

    Public Shared Function getLogonServer(ByVal stationName As String,
                                          ByVal userSID As String) As String

        If stationName = Nothing Or userSID = Nothing Then
            Return "NA"
        End If

        ' Dim rkUserProfile As RegistryKey = Nothing
        Dim sLogonServer As String = Nothing

        Try
            Using rkUserProfile As RegistryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.Users, stationName).OpenSubKey(userSID).OpenSubKey("Volatile environment")
                sLogonServer = CStr(rkUserProfile.GetValue("LOGONSERVER"))
            End Using
        Catch ex As Exception
            log.addLogEntry(New cLogEntry("Erreur lecture HKCU\Users", cLogEntry.enumDebugLevel.ERREUR, stationName, "cregistry", ex))
            sLogonServer = "NA"
        End Try

        Return sLogonServer
    End Function

    Public Shared Function getPrinterListByProfile(ByVal stationName As String,
                                             ByVal userSID As String,
                                             ByRef errMsg As String,
                                             ByRef printersList As List(Of String)) As Boolean

        Dim subkey As String = String.Format("{0}\Software\microsoft\Windows NT\CurrentVersion\PrinterPorts", userSID)

        Try
            Using rkUserProfile As RegistryKey = RegistryKey.
                OpenRemoteBaseKey(RegistryHive.Users, stationName).
                OpenSubKey(subkey, RegistryKeyPermissionCheck.ReadSubTree, RegistryRights.ReadKey)

                For Each keyName As String In rkUserProfile.GetValueNames
                    printersList.Add(keyName)
                Next

            End Using

            Return True
        Catch ex As Exception
            errMsg = ex.Message
            Return False
        End Try

    End Function

    Public Shared Function getDefaultPrinterByProfile(ByVal stationName As String,
                                                      ByVal userSID As String,
                                                      ByRef errMsg As String,
                                                      ByRef defaultPrinterName As String) As Boolean

        Dim subkey As String = String.Format("{0}\Software\microsoft\Windows NT\CurrentVersion\Windows", userSID)

        Try
            Using rkUserProfile As RegistryKey = RegistryKey.
                OpenRemoteBaseKey(RegistryHive.Users, stationName).
                OpenSubKey(subkey, RegistryKeyPermissionCheck.ReadSubTree, RegistryRights.ReadKey)

                defaultPrinterName = rkUserProfile.GetValue("Device").ToString

                Return True
            End Using
        Catch ex As Exception
            errMsg = ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Recupère la liste des profils dans le registre 
    ''' recupére une liste de SID compte utilisateur domaine
    ''' traduit les SIDs en login  et renvoie une liste 
    ''' </summary>
    ''' <param name="stationName"></param>
    ''' <param name="errMsg"></param>
    ''' <param name="dicprofileList"></param>
    ''' <returns></returns>
    Public Shared Function getSIDProfileList(ByVal stationName As String,
                                             ByRef errMsg As String,
                                             ByRef dicprofileList As Dictionary(Of String, String)) As Boolean

        Dim subkey As String = "Software\Microsoft\Windows NT\CurrentVersion\ProfileList"
        Dim profileSIDList As New List(Of String)

        Try
            Using rkUserProfile As RegistryKey = RegistryKey.
                    OpenRemoteBaseKey(RegistryHive.LocalMachine, stationName).
                    OpenSubKey(subkey, RegistryKeyPermissionCheck.ReadSubTree, RegistryRights.ReadKey)

                For Each keyName As String In rkUserProfile.GetSubKeyNames
                    If Not keyName.Contains(".bak") And
                        keyName.StartsWith("S-1-5-21") Then
                        profileSIDList.Add(keyName)
                    End If
                Next
            End Using


        Catch ex As Exception
            errMsg = ex.Message
            Return False
        End Try

        For Each SID As String In profileSIDList
            Dim userSID As New System.Security.Principal.SecurityIdentifier(SID)
            Dim accountName As String = Nothing

            Try
                accountName = userSID.Translate(GetType(System.Security.Principal.NTAccount)).ToString
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try

            '
            ' On ne remonte que les comptes de domaine , filtre comptes locaux qui doivent etre nomMachine\nomCompte
            '

            If Not String.IsNullOrEmpty(accountName) Then
                If accountName.Contains(Environment.UserDomainName) Then
                    dicprofileList.Add(accountName, SID)
                End If
            End If
        Next

        Return True

    End Function

    Public Shared Sub getNetworkDriverInfos(ByVal stationName As String,
                                         ByVal index As UInt32,
                                         ByRef driverVersion As String,
                                         ByRef driverDate As Date,
                                         ByRef driverDesc As String,
                                         ByRef driverManufacturer As String)

        ' voir http://technet.microsoft.com/fr-fr/library/cc780532%28v=ws.10%29.aspx
        Dim sControlSetKeyName As String = "{4D36E972-E325-11CE-BFC1-08002bE10318}"
        Dim subkey As String = "SYSTEM\CurrentControlSet\control\class\{4D36E972-E325-11CE-BFC1-08002bE10318}"
        Dim sIndex As String
        Dim ci As System.Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture
        ' conversion dates en français 

        If index < 10 Then
            sIndex = "000" & CStr(index)
        Else
            sIndex = "00" & CStr(index)
        End If

        Try
            Using rkSystem As RegistryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, stationName).OpenSubKey(subkey, RegistryKeyPermissionCheck.ReadSubTree, RegistryRights.ReadKey)
                If Not rkSystem Is Nothing Then
                    Using rkPNPInfos As RegistryKey = rkSystem.OpenSubKey(sIndex)
                        If Not rkPNPInfos Is Nothing Then
                            With rkPNPInfos
                                driverVersion = Trim(.GetValue("DriverVersion").ToString)
                                driverDate = Date.ParseExact(.GetValue("DriverDate").ToString, "M-d-yyyy", System.Globalization.CultureInfo.InvariantCulture)
                                driverDesc = .GetValue("driverDesc").ToString
                                driverManufacturer = .GetValue("ProviderName").ToString
                            End With
                        End If
                    End Using
                End If
            End Using
        Catch ex As Exception
            log.addLogEntry(New cLogEntry("Erreur récupération infos Driver dans registre ", cLogEntry.enumDebugLevel.ERREUR, stationName, "cregistry", ex))
        End Try
    End Sub

    ''' <summary>
    ''' Récupère le socle utilisé dans le registre
    ''' </summary>
    ''' <param name="stationName"></param>
    ''' <returns>Retourne String "NA" si echec</returns>
    ''' <remarks></remarks>
    Public Shared Function GetSocleName(ByVal stationName As String) As String
        Dim socle As String

        Try
            Dim key As String = "SYSTEM\Setup\"
            Using rk As RegistryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, stationName).OpenSubKey(key, RegistryKeyPermissionCheck.ReadSubTree, RegistryRights.ReadKey)
                Dim res As Array = CType(rk.GetValue("OEMDuplicatorString"), Array)

                If res IsNot Nothing Then
                    socle = res.GetValue(0).ToString
                    Return socle
                Else
                    socle = "NA"
                End If
            End Using

        Catch ex As Exception
            socle = "NA"
        End Try

        Return socle
    End Function

    ''' <summary>
    ''' Récupère la valeur de la variable d'environement passée en param
    ''' </summary>
    ''' <param name="stationName">Nom de la station</param>
    ''' <param name="varName">nom de la var à récupérer (voir registre)</param>
    ''' <returns>False si requete KO</returns>
    ''' <remarks></remarks>
    Public Shared Function GetEnvironmentVariablesByName(ByVal stationName As String, ByVal varName As String, ByRef res As Object) As Boolean
        Try
            Dim envkey As String = "SYSTEM\CurrentControlSet\Control\Session Manager\Environment"
            Using rk As RegistryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, stationName).OpenSubKey(envkey, RegistryKeyPermissionCheck.ReadSubTree, RegistryRights.ReadKey)
                res = rk.GetValue(varName)
            End Using


            Return True
        Catch ex As Exception
            log.addLogEntry(New cLogEntry("Erreur récupération variable d'environement : " & varName, cLogEntry.enumDebugLevel.ERREUR, stationName, "cregistry", ex))
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Change la valeur pour la cle de registre vnc query connect
    ''' </summary>
    ''' <remarks>
    ''' Throw exception
    ''' </remarks>
    Public Shared Sub SetVNCQueryConnect(ByVal stationName As String)
        Dim vnc4Key As String = "SOFTWARE\RealVNC\WInVNC4"
        Using rk As RegistryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, stationName) _
                                             .OpenSubKey(vnc4Key, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl)

            If rk Is Nothing Then
                MsgBox("la clé n'existe pas ")
            Else
                Dim keyValue As Integer = CInt(rk.GetValue("QueryConnect"))
                Dim texte As String = "Query Connect " & stationName & vbCrLf & "Valeur actuelle : " & rk.GetValue("QueryConnect").ToString & vbCrLf & "Changer la valeur ?"
                Dim titre As String = "QueryConnect"
                Dim choix As DialogResult = MessageBox.Show(texte, titre, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If choix = DialogResult.Yes Then
                    If keyValue = 1 Then
                        rk.SetValue("QueryConnect", 0)
                    Else
                        rk.SetValue("QueryConnect", 1)
                    End If
                End If
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Confirmation prise de main SCCM 
    ''' </summary>
    ''' <param name="stationName"></param>
    Public Shared Sub SetSCCMViewerQueryConnect(ByVal stationName As String)

        Dim SCMKey As String = "SOFTWARE\Microsoft\SMS\Client\Client Components\Remote Control"

        Using rk As RegistryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, stationName, RegistryView.Registry64) _
                                             .OpenSubKey(SCMKey, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl)

            If rk Is Nothing Then
                MsgBox("la clé n'existe pas ")
            Else
                Dim keyValue As Integer = CInt(rk.GetValue("Permission Required"))
                Dim texte As String = String.Format("Validation User pour  {0}{1} Valeur actuelle : {2}{1} Changer la valeur ? ",
                                                    stationName, Environment.NewLine, keyValue.ToString, Environment.NewLine)
                Dim choix As DialogResult = MessageBox.Show(texte, "Scm Validation User", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If choix = DialogResult.Yes Then
                    If keyValue = 1 Then
                        rk.SetValue("Permission Required", 0)
                    Else
                        rk.SetValue("Permission Required", 1)
                    End If
                End If
            End If

        End Using

    End Sub

    ''' <summary>
    ''' Change la valeur pour la cle de registre vncNotify
    ''' Affichage notification en cas de connexion
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function SetVNCNotification(ByVal stationName As String, ByRef errMessage As String) As Boolean
        Dim vnc4Key As String = "SOFTWARE\RealVNC\WinVNC4"
        Dim rk As RegistryKey = Nothing
        Dim subkeys() As String = Nothing
        Dim keyNotifyName As String = "ConnNotifyTimeout"

        Try
            rk = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, stationName) _
                            .OpenSubKey(vnc4Key, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl)

            subkeys = rk.GetValueNames ' pas de sous clé, 31 valeurs
        Catch ex As Exception
            If Not rk Is Nothing Then rk.Close()
            rk = Nothing
            errMessage = "Erreur ouverture cle VNC"
            Return False
        End Try

        ' la cle existe déja
        If subkeys.Contains(keyNotifyName) Then
            Dim oKey = rk.GetValue(keyNotifyName)

            If oKey IsNot Nothing Then
                ' récup valeur clé
                Dim keyValue As Integer = CInt(oKey)
                Dim nextValue As Integer

                If keyValue = 4 Then
                    nextValue = 0
                Else
                    nextValue = 4
                End If

                Dim texte = String.Format("Notify Connection {0}" & Environment.NewLine & " valeur actuelle : {1} " & vbNewLine & " Passer à {2}", stationName, keyValue.ToString, nextValue.ToString)
                Dim titre As String = "VNC Connection Notify"
                Dim choix As DialogResult = MessageBox.Show(texte, titre, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If choix = DialogResult.Yes Then rk.SetValue(keyNotifyName, nextValue, RegistryValueKind.String)
            End If 'oKey IsNot Nothing 
        Else ' la cle n'existe pas
            Dim texte As String = "La cle n'existe pas, voulez vous la créer ? " & Environment.NewLine & "Valeur par défaut : 4"
            Dim titre As String = "VNC Connection Notify"
            Dim choix As DialogResult = MessageBox.Show(texte, titre, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If choix = DialogResult.Yes Then
                Try
                    rk.SetValue(keyNotifyName, 4, RegistryValueKind.String)
                Catch ex As Exception
                    errMessage = ex.Message
                    Return False
                End Try

                Return True
            Else
                Return True
            End If
        End If

        rk.Close()

        Return True
    End Function

#Region "Displays"
    ''' <summary>
    ''' retourne tous les sous clés de SYSTEM\CurrentControlSet\Enum\DISPLAY
    ''' </summary>
    ''' <param name="stationName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getAllMonitors(ByVal stationName As String) As String()
        Dim key As String = "SYSTEM\CurrentControlSet\Enum\DISPLAY"

        Using rk As RegistryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, stationName).OpenSubKey(key, False)
            Return rk.GetSubKeyNames
        End Using
    End Function

    ''' <summary>
    ''' Retourne liste de tous les devices actifs ( sous cle control présente )
    ''' dictionnaire k=>Display, v=> registryKey (pnpDevice Actif)
    ''' </summary>
    ''' <param name="stationName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getAllActiveMonitorKeys(ByVal stationName As String) As Dictionary(Of String, RegistryKey)
        Dim arrRegActiveMonitors As New Dictionary(Of String, RegistryKey)
        Dim key As String = "SYSTEM\CurrentControlSet\Enum\DISPLAY"

        Using rk As RegistryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, stationName).OpenSubKey(key, False)
            If Not rk Is Nothing Then
                Dim arrDisplay As String() = rk.GetSubKeyNames

                For Each display As String In arrDisplay
                    Dim monitor As RegistryKey = rk.OpenSubKey(display)
                    Dim singleMonitorId As Integer = 0

                    'liste les PNPdeviceID dnas chaque monitor
                    Dim arrPNPDeviceID As String() = monitor.GetSubKeyNames

                    For Each PNPDeviceId As String In arrPNPDeviceID
                        Dim isActiveMonitor As Boolean = False
                        Dim pnpDevice As RegistryKey = monitor.OpenSubKey(PNPDeviceId)

                        ' teste si le moniteur est actif
                        ' => contient la sous clé control
                        For Each s As String In pnpDevice.GetSubKeyNames
                            If s = "Control" Then
                                isActiveMonitor = True
                            End If
                        Next

                        If isActiveMonitor Then

                            ' si plusieurs PNPDevice actif pour le même DISPLAY 
                            ' on crée un nom DISPLAY unique ( clé dico ... ) 
                            If Not arrRegActiveMonitors.ContainsKey(display) Then
                                arrRegActiveMonitors.Add(display, pnpDevice)
                            Else
                                Dim singleDisplay = display & "_" & CStr(singleMonitorId)
                                arrRegActiveMonitors.Add(singleDisplay, pnpDevice)
                                singleMonitorId += 1
                            End If
                        End If
                    Next
                Next
            End If
        End Using


        Return arrRegActiveMonitors
    End Function

    Public Shared Function getEdidKeys(ByVal stationName As String) As Dictionary(Of String, Byte())
        Dim listOfEDIDValue As New Dictionary(Of String, Byte())

        'listOfEDIDValue = getAllActiveMonitorKeys(stationName)
        For Each regActiveMonitor In getAllActiveMonitorKeys(stationName)
            Dim success As Boolean = False
            Dim edidvalue = getEDIDfromPnpKey(regActiveMonitor.Value, success)
            If success Then
                listOfEDIDValue.Add(regActiveMonitor.Key, edidvalue)
            End If
        Next

        Return listOfEDIDValue
    End Function

    Private Shared Function getEDIDfromPnpKey(ByVal rk As RegistryKey, ByRef success As Boolean) As Byte()
        Using sk As RegistryKey = rk.OpenSubKey("Device Parameters")

            Dim edid As Byte() = Nothing
            success = True

            Try
                edid = CType(sk.GetValue("EDID"), Byte())
            Catch ex As Exception
                success = False
            End Try

            If edid IsNot Nothing Then
                Return edid
            Else
                success = False ' BAD_EDID ou cle n'existe pas
            End If

            Return edid

        End Using
    End Function

    ''' <summary>
    ''' Récupère chaine EDID
    ''' </summary>
    ''' <remarks></remarks> 
    Public Shared Function getEdidKey(ByVal stationName As String, ByVal pnpId As String) As Byte()
        Dim key As String = "SYSTEM\CurrentControlSet\Enum\" & pnpId & "\Device Parameters"
        Using rk As RegistryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, stationName).OpenSubKey(key, False)
            If rk Is Nothing Then
                Return Nothing
            Else
                Return CType(rk.GetValue("EDID"), Byte())
            End If
        End Using
    End Function

#End Region

End Class
