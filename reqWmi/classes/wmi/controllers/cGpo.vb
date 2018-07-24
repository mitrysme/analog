Imports System.Management

Public Class cGpo
    Private _stationName As String
    Private _userName As String
    ' events
    Public Event message(ByVal msg As String)
    Public Event workDone(ByVal dic As Dictionary(Of String, structRsopGpo), _
                          ByVal dic As Dictionary(Of String, structRsopGpo), _
                          ByVal slogonServer As String, _
                          ByVal sComputerDN As String, _
                          ByVal sUserDN As String)

    Public ReadOnly Property userName() As String
        Get
            Return _userName
        End Get
    End Property

    ' Valeurs possibles pour les flags à passer à la methode rsopCreateSession
    Public Enum RsopCreateSessionFlags
        FLAG_NO_USER = 1
        FLAG_NO_COMPUTER = 2
        FLAG_FORCE_CREATENAMESPACE = 4
    End Enum

    ' Valeurs possibles pour extendedInfos renvoyés par RsopCreateSession
    Public Enum RsopCreateSessionHresult
        RSOP_USER_ACCESS_DENIED = 1
        RSOP_COMPUTER_ACCESS_DENIED = 2
        RSOP_TEMPNAMESPACE_EXISTS = 4
    End Enum

    Public Structure structRsopGpo
        Public name As String
        Public GuidName As String
        Public Id As String
        Public accessDenied As Boolean
        Public enabled As Boolean
        Public fileSystemPath As String
        Public filterAllowed As Boolean
        Public filterId As String
        Public version As String
        Public filterWmiDescription As String
    End Structure

    Public Sub New(ByVal stationName As String, _
                   Optional ByVal userName As String = "")
        _stationName = stationName
        _userName = userName
    End Sub

    ' Public Sub getGpolist(byref dicGpo As Dictionary(Of String, structRsopGpo), 


    Public Sub getGpoList()
        Dim wmiWrapper As New cwmi(_stationName)
        Dim dicGpoComputer As New Dictionary(Of String, structRsopGpo)
        Dim dicGpoUser As New Dictionary(Of String, structRsopGpo)
        Dim sid As System.Security.Principal.SecurityIdentifier = Nothing
        Dim sLogonServer As String = Nothing
        Dim sComputerDN As String = Nothing
        Dim sUserDN As String = Nothing

        Dim inputArgs As ManagementBaseObject = Nothing
        Dim outParams As ManagementBaseObject = Nothing

        ' on récupère le DN LDAP du computer
        ' a voir exception ....
        sComputerDN = ldapWrapper.getComputerDN(_stationName)

        Using mc As ManagementClass = New ManagementClass(New ManagementPath(String.Format("\\{0}\root\rsop:RsopLoggingModeProvider", _stationName)), _
                                                          New ObjectGetOptions(Nothing, TimeSpan.MaxValue, True))

            inputArgs = mc.GetMethodParameters("RsopCreateSession")

            If _userName <> "" And _userName <> "NA" Then
                '
                ' Utilisateur est logué on fait une requete LDAP 
                ' pour récupérer le DN du user
                '
                sUserDN = ldapWrapper.getUserDN(userName)

                ' Récup du SID du user
                Dim errMessage As String = ""

                RaiseEvent message("Récupération SID Utilisateur ...")
                If Not Analog.functions.misc.getUserSID(_userName, errMessage, sid) Then
                    RaiseEvent message(String.Format("Impossible de déterminer le SID pour utilisateur : {0}, Erreur : {1}", _userName, errMessage))
                End If
            End If

            '
            ' Si on n'a pas pu récupérer le SID de l'utilisateur 
            ' on ne demande pas les GPO user
            ' On n'essaie pas non plus de savoir sur quel controleur de domaine s'est authentifié l'utilisateur ....
            '
            If Not sid Is Nothing Then
                inputArgs("flags") = Nothing
                RaiseEvent message(String.Format("Récupération Infos Controleur de Domaine...", _stationName))
                sLogonServer = cregistry.getLogonServer(_stationName, sid.ToString)
            Else
                inputArgs("flags") = RsopCreateSessionFlags.FLAG_NO_USER
            End If

            inputArgs("UserSid") = sid

            '
            ' La fonction renvoie : 
            '
            ' ExtendedInfo 
            ' hResult 
            ' nameSpace  
            '
            RaiseEvent message(String.Format("Création de la session RSOP pour {0} ...", _stationName))
            outParams = mc.InvokeMethod("RsopCreateSession", inputArgs, Nothing)

            If CUInt(outParams.Properties("hResult").Value) = 0 Then
                Dim sNameSpace As String = CStr(outParams.Properties("nameSpace").Value).Substring(3)
                wmiWrapper.connect(Nothing, sNameSpace & "\computer")

                Dim moc As ManagementObjectCollection = Nothing


                RaiseEvent message("Récupération données RSOP ...")
                wmiWrapper.getResultsFor(moc, "RSOP_GPO", Nothing, Nothing)


                Using moc
                    Dim sGpo As New structRsopGpo

                    For Each mo As ManagementObject In moc
                        With sGpo
                            .name = mo.Item("Name").ToString
                            .GuidName = mo.Item("GUIDName").ToString
                            .Id = mo.Item("ID").ToString
                            .accessDenied = CBool(mo.Item("Accessdenied"))
                            .enabled = CBool(mo.Item("enabled"))
                            .fileSystemPath = mo.Item("fileSystemPath").ToString
                            .filterAllowed = CBool(mo.Item("filterAllowed"))
                            .filterId = mo.Item("filterId").ToString
                            .version = mo.Item("Version").ToString

                            If Not String.IsNullOrEmpty(.filterId) Then
                                .filterWmiDescription = getGpoDecFromGUID(.filterId)
                            End If
                        End With

                        If Not dicGpoComputer.ContainsKey(sGpo.name) Then
                            dicGpoComputer.Add(sGpo.name, sGpo)
                        Else
                            log.addLogEntry(New cLogEntry(String.Format("L'élément  {0} a déjà été ajouté dans la collection dicGpoComputer! Corruption wmi ?? ", sGpo.name), cLogEntry.enumDebugLevel.DEBUG))
                        End If
                    Next
                End Using

                ' 
                ' Code pour récupération GPO User
                '
                If Not sid Is Nothing Then
                    Using moc

                        With wmiWrapper
                            .connect(Nothing, String.Concat(sNameSpace, "\user"))
                            .getResultsFor(moc, "RSOP_GPO", Nothing, Nothing)
                        End With

                        Dim sGpo As New structRsopGpo

                        For Each mo As ManagementObject In moc
                            With sGpo
                                .name = mo.Item("Name").ToString
                                .GuidName = mo.Item("GUIDName").ToString
                                .Id = mo.Item("ID").ToString
                                .accessDenied = CBool(mo.Item("Accessdenied"))
                                .enabled = CBool(mo.Item("enabled"))
                                .fileSystemPath = mo.Item("fileSystemPath").ToString
                                .filterAllowed = CBool(mo.Item("filterAllowed"))
                                .filterId = mo.Item("filterId").ToString
                                .version = mo.Item("Version").ToString

                                If Not String.IsNullOrEmpty(.filterId) Then
                                    .filterWmiDescription = getGpoDecFromGUID(.filterId)
                                End If
                            End With

                            If Not dicGpoUser.ContainsKey(sGpo.name) Then
                                dicGpoUser.Add(sGpo.name, sGpo)
                            Else
                                log.addLogEntry(New cLogEntry(String.Format("L'élément  {0} a déjà été ajouté dans la collection dicGpoUser! Corruption wmi ?? ", sGpo.name), cLogEntry.enumDebugLevel.DEBUG))
                            End If
                        Next
                    End Using
                End If

                '
                ' Création dictionnaires GPO filtrées / actifs / désactivés
                ' Computer
                '
                wmiWrapper.disconnect()
                wmiWrapper = Nothing

                RaiseEvent workDone(dicGpoComputer, dicGpoUser, sLogonServer, sComputerDN, sUserDN)
            Else
                RaiseEvent message(String.Format("Erreur lors de la récupération des résultats , hresult : {0}", outParams.Properties("hResult").Value.ToString))
            End If

        End Using
    End Sub

    Public Function getGpoDecFromGUID(ByVal sWmiFilterGuid As String) As String

        Static htCacheGpoGuid As New Hashtable

        If htCacheGpoGuid.ContainsKey(sWmiFilterGuid) Then
            Return htCacheGpoGuid(sWmiFilterGuid).ToString
        End If

        Dim sWmiFilterGuidDescription As String = Nothing
        Dim wmiWrapper As New cwmi(_stationName)
        Dim moc As ManagementObjectCollection = Nothing

        wmiWrapper.connect(Nothing, Nothing, "root\directory\LDAP")

        Dim iStart As Integer = sWmiFilterGuid.IndexOf("{")
        Dim iEnd As Integer = sWmiFilterGuid.IndexOf("}")
        Dim sFilter As String = sWmiFilterGuid.Substring(iStart, iEnd - (iStart - 1))

        If wmiWrapper.getResultsFor(moc, "ads_msWMI_Som", String.Format("DS_cn='{0}'", sFilter), New String() {"DS_msWMI_Name"}) Then
            For Each mo As ManagementObject In moc
                sWmiFilterGuidDescription = mo.Item("DS_msWMI_Name").ToString
            Next
        End If

        If Not String.IsNullOrEmpty(sWmiFilterGuidDescription) Then
            htCacheGpoGuid.Add(sWmiFilterGuid, sWmiFilterGuidDescription)
        End If

        wmiWrapper.disconnect()

        If Not moc Is Nothing Then
            moc.Dispose()
        End If

        Return sWmiFilterGuidDescription
    End Function

End Class
