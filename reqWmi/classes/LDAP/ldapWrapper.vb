Imports System.DirectoryServices
Imports System.DirectoryServices.ActiveDirectory

Public Class ldapWrapper

    Private _sr As SearchResult = Nothing

    'Public Shared Function FriendlyDomainToLdapDomain(ByVal friendlyDomainName As String) As String

    '    Dim ldapPath As String = Nothing
    '    Try
    '        Dim objContext As DirectoryContext = New DirectoryContext(DirectoryContextType.Domain, friendlyDomainName)
    '        Dim objDomain As Domain = Domain.GetDomain(objContext)

    '        ldapPath = objDomain.Name
    '    Catch e As DirectoryServicesCOMException
    '        ldapPath = e.Message.ToString()
    '    End Try

    '    Return ldapPath
    'End Function

    Public Sub razUser()
        _sr = Nothing
    End Sub

    Public Structure ldapPrinterProperties
        Public printerName As String
        Public location As String
        Public shortServerName As String
        Public portname As String
        Public description As String
        Public shareName As String
        Public driverName As String
    End Structure



    ' bitMask pour property userAccountControl
    Public Enum LdapUserAccountFlags
        Script = 1
        AccountDisabled = 2
        HomeDirectoryRequred = 8
        LockedOut = 16
        PasswordNotRequred = 32
        CannotChangePassword = 64
        EncryptedTextPasswordAllowed = 128
        TemporaryDuplicateAccount = 256
        NormalAccount = 512
        InterdomainTrustAccount = 2048
        WorkstationTrustAccount = 4096
        ServerTrustAccount = 8192
        NeverExpirePassword = 65536
        MNSLogonAccount = 131072
        SmartcardRequired = 262144
        TrustedForDelegation = 524288
        NotDelegated = 1048576
        UseDESKeyOnly = 2097152
        DontRequirePreAuth = 4194304
        PasswordExpired = 8388608
        TrustedToAuthForDelegation = 16777216
    End Enum

    ' Serverless LDAP binding 
    Private Shared Function getLDAPPath() As String
        Static ldapPath As String

        If ldapPath IsNot Nothing Then Return ldapPath

        Using de As DirectoryEntry = New DirectoryEntry("LDAP://RootDSE")
            ldapPath = de.Properties("defaultNamingContext")(0).ToString
        End Using

        Return ldapPath
    End Function

    Private Function getPropertieValueAsString(ByRef sr As SearchResult, ByVal pn As String) As String
        If sr.Properties.Contains(pn) Then
            Dim p As Object = sr.Properties(pn)(0)
            Return CType(p, String)
        Else
            Return String.Empty
        End If
    End Function

    ''' <summary>
    ''' Cherche un Utilisateur sur le Domaine
    ''' </summary>
    ''' <param name="userName"></param>
    ''' <returns>SearchResult</returns>
    ''' <remarks>
    ''' renvoie faux si utilisateur non trouvé
    ''' </remarks>
    Public Function searchForLDAPUser(ByVal userName As String) As Boolean
        Using ent As DirectoryEntry = New DirectoryEntry(String.Format("LDAP://{0}", getLDAPPath))
            Using dirSearcher As DirectorySearcher = New DirectorySearcher
                dirSearcher.SearchRoot = ent
                dirSearcher.Filter = String.Format("(sAMAccountName={0})", userName)
                _sr = dirSearcher.FindOne
            End Using
        End Using

        Return _sr IsNot Nothing
    End Function

    ''' <summary>
    ''' Renvoie les paramètres pour les files imprimantes déclarées dans AD 
    ''' </summary>
    ''' <param name="printerName">Nom de l'imprimante</param>
    ''' <param name="LDAPPrinterProps"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' TODO : si plusieurs files retournées pour un nom 
    ''' afficher un menu déroulant avec le nom des différentes files
    ''' lors de la sélection afficher les infos pour la file correspondant 
    ''' charger les différents files remontées dans un dico de type k => fileNme , v=> ldapPrinterProperties
    ''' </remarks>
    Public Shared Function getLDAPPrinterINfos(ByVal printerName As String,
                                               ByRef LDAPPrinterProps As ldapPrinterProperties) As Boolean

        Using de As DirectoryEntry = New DirectoryEntry(String.Format("LDAP://{0}", getLDAPPath))
            Using dirSearcher As DirectorySearcher = New DirectorySearcher(de)

                dirSearcher.Filter = ("(&(objectCategory=printQueue)(printername=" & printerName & "*))")

                Dim result As SearchResult = dirSearcher.FindOne

                If result Is Nothing Then
                    Return False
                End If

                Dim fields As ResultPropertyCollection = result.Properties

                With LDAPPrinterProps
                    .description = getFieldValueIfExist(fields, "description")
                    .portname = getFieldValueIfExist(fields, "portname")
                    .location = getFieldValueIfExist(fields, "location")
                    .driverName = getFieldValueIfExist(fields, "drivername")
                    .shareName = getFieldValueIfExist(fields, "printsharename")
                    .printerName = getFieldValueIfExist(fields, "printername")
                    .shortServerName = getFieldValueIfExist(fields, "shortservername")
                End With

            End Using
        End Using

        Return True
    End Function

    Private Shared Function getFieldValueIfExist(ByVal fields As ResultPropertyCollection,
                                                 ByVal fieldPropertyName As String) As String

        If fields(fieldPropertyName).Count > 0 Then
            Return fields(fieldPropertyName).Item(0).ToString
        Else
            Return String.Empty
        End If
    End Function

    Public Sub getLdapUserAccountInfos(ByRef StructLdapUser As structs.analogStructs.StructLdapUser)

        Dim results As SearchResult = _sr
        ' flags paramètres compte AD ( bitmask)
        Dim userAccountControl As Integer = CType(results.Properties("useraccountcontrol")(0), Integer)
        '
        ' lastLogon
        ' si ne s'est jamais logué , lastLogontimeStamp = ""
        '
        Dim LastLogonTimeStamp As String = getPropertieValueAsString(results, "lastlogon") ' timeStamp
        Dim lastLogonDate, lastLogonTime As String

        If Not LastLogonTimeStamp = String.Empty Then
            lastLogonDate = Date.FromFileTime(CLng(LastLogonTimeStamp)).ToShortDateString
            lastLogonTime = Date.FromFileTime(CLng(LastLogonTimeStamp)).ToShortTimeString
        Else
            lastLogonDate = "jamais"
            lastLogonTime = ""
        End If
        '
        ' pwdLastSet
        '
        Dim pwdlastset As String = getPropertieValueAsString(results, "pwdlastset") 'TimeStamp
        Dim pwdlastsetDate As String = Date.FromFileTime(CLng(pwdlastset)).ToShortDateString
        Dim pwdlastsettime As String = Date.FromFileTime(CLng(pwdlastset)).ToShortTimeString

        Dim tempStructLdapUser As structs.analogStructs.StructLdapUser = Nothing
        With tempStructLdapUser
            .userPrincipal = getPropertieValueAsString(results, "userprincipalname")
            .description = getPropertieValueAsString(results, "description")
            .givenName = getPropertieValueAsString(results, "givenName")
            .displayName = getPropertieValueAsString(results, "displayName")
            .name = getPropertieValueAsString(results, "name")
            .sn = getPropertieValueAsString(results, "sn")
            .mail = getPropertieValueAsString(results, "mail")
            .LogonScriptPath = getPropertieValueAsString(results, "scriptpath")
            .SID = ConvertByteToStringSid(CType(results.Properties("objectsid")(0), Byte()))
            .lastLogonDate = lastLogonDate
            .lastLogonTime = lastLogonTime
            .pwdLastSetDate = pwdlastsetDate
            .pwdLastSetTime = pwdlastsettime
            .accountDisabled = isUserAccountControlFlagSet(userAccountControl, LdapUserAccountFlags.AccountDisabled)
            .pwdNeverExpire = isUserAccountControlFlagSet(userAccountControl, LdapUserAccountFlags.NeverExpirePassword)
            .cannotChangePassword = isUserAccountControlFlagSet(userAccountControl, LdapUserAccountFlags.CannotChangePassword)
            .blockedAccount = isUserAccountControlFlagSet(userAccountControl, LdapUserAccountFlags.LockedOut)
            .pwdExpired = isUserAccountControlFlagSet(userAccountControl, LdapUserAccountFlags.PasswordExpired)
            ' MsgBox("Date création objet : " & getPropertieValueAsString(results, "WhenCreated")) ' todo à rajouter dans UI
        End With

        StructLdapUser = tempStructLdapUser
    End Sub

    Public Shared Function getComputerDNWithoutFilter(ByVal sComputerName As String) As SearchResult

        Dim ldapComputerDN As String = Nothing
        Dim sr As SearchResult

        Using mySearcher As DirectorySearcher = New DirectorySearcher(New DirectoryEntry(String.Format("LDAP://{0}", getLDAPPath)))
            mySearcher.Filter = ("(&(objectCategory=computer)(name=" & sComputerName & "))")
            sr = mySearcher.FindOne()
        End Using

        Return sr

    End Function

    Public Shared Function getComputerDN(ByVal sComputerName As String) As String
        Dim ldapComputerDN As String = Nothing

        Using mySearcher As DirectorySearcher = New DirectorySearcher(New DirectoryEntry(String.Format("LDAP://{0}", getLDAPPath)))
            mySearcher.Filter = ("(&(objectCategory=computer)(samaccountname=" & sComputerName & "$))")

            Dim sr As SearchResult = mySearcher.FindOne

            If Not sr Is Nothing Then
                Using de As DirectoryEntry = sr.GetDirectoryEntry
                    With de
                        ldapComputerDN = .Properties("distinguishedName").Value.ToString()
                        'sMemberOfValue = .Properties("memberof").Value.ToString()
                    End With
                End Using
            End If
        End Using

        Return ldapComputerDN
    End Function

    ''' Renvoie DN - distinguishedName pour un user
    Public Shared Function getUserDN(ByVal sUserName As String) As String
        Dim ldapUserDN As String = Nothing

        Dim sSimpleUserName As String = Split(sUserName, "\")(1)

        Using mySearcher As DirectorySearcher = New DirectorySearcher(New DirectoryEntry(String.Format("LDAP://{0}", getLDAPPath)))
            mySearcher.Filter = ("(&(objectCategory=user)(samaccountname=" & sSimpleUserName & "))")

            Dim sr As SearchResult = mySearcher.FindOne

            If Not sr Is Nothing Then
                Using de As DirectoryEntry = sr.GetDirectoryEntry
                    ldapUserDN = de.Properties("distinguishedName").Value.ToString()
                End Using
            End If
        End Using

        Return ldapUserDN
    End Function

    Public Shared Function getLDAPPrinterINfosList() As List(Of ldapPrinterProperties)
        Dim printerList As New List(Of ldapPrinterProperties)

        Using mySearcher As DirectorySearcher = New DirectorySearcher(New DirectoryEntry(String.Format("LDAP://{0}", getLDAPPath)))

            With mySearcher
                .Filter = "(objectCategory=printQueue)"
                .PageSize = 1000
                .SearchScope = SearchScope.Subtree
            End With

            Using src As SearchResultCollection = mySearcher.FindAll ' 3075 objets imprimante

                For Each result As SearchResult In src

                    Dim fields As ResultPropertyCollection = result.Properties
                    Dim LDAPPrinterProps As ldapPrinterProperties

                    With LDAPPrinterProps
                        .description = getFieldValueIfExist(fields, "description")
                        .portname = getFieldValueIfExist(fields, "portname")
                        .location = getFieldValueIfExist(fields, "location")
                        .driverName = getFieldValueIfExist(fields, "drivername")
                        .shareName = getFieldValueIfExist(fields, "printsharename")
                        .printerName = getFieldValueIfExist(fields, "printername")
                        .shortServerName = getFieldValueIfExist(fields, "shortservername")
                    End With

                    '
                    ' retrouver toutes les propriétés pour objectCategory=printQueue
                    '
                    'For Each propName As String In myresult.Properties.PropertyNames
                    '    Dim rpvc As ResultPropertyValueCollection = myresult.Properties(propName)
                    '    For Each propvalue As Object In rpvc
                    '        Debug.Print("Property  :" & propName & " : " & propvalue.ToString)
                    '    Next
                    'Next

                    printerList.Add(LDAPPrinterProps)

                Next
            End Using
        End Using

        Return printerList

    End Function


    ''' <summary>
    ''' Récupère dans l'AD les ordis à scanner
    ''' on récupérer toutes les machines dans OU=ordisChu
    ''' on vérifie que la première lettre de la station commence par une des lettres des sites ( pel, Sa ,etc )
    ''' si c'est le cas on ajoute dans le tableau de stations
    ''' test le 24/11/2011 => 9347 récupérées
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDomainStationList(ByVal sOU As String) As ArrayList

        Dim stationList As New ArrayList

        'OrdisCHU

        ' binding LDAP sur les différentes OU dans lesquelles récupérer les station
        ' Dim MySearcher As DirectorySearcher = New DirectorySearcher(New DirectoryEntry(String.Format("LDAP://{0},DC=chu-bordeaux,DC=fr", sOU)))

        Dim MySearcher As DirectorySearcher = New DirectorySearcher(New DirectoryEntry(String.Format("LDAP://{0},{1}", sOU, getLDAPPath)))

        ' FILTRE LDAP => uniquement objets de type computer et avec compte actif voir => http://www.groupsrv.com/dotnet/about230274.html
        With MySearcher
            .Filter = ("(&(objectCategory=computer)(!(userAccountControl:1.2.840.113556.1.4.803:=2)))")
            .PageSize = 1000
            .SearchScope = SearchScope.Subtree
        End With

        Dim MyResult As System.DirectoryServices.SearchResult
        Dim stationName As String
        Dim statioNameFirstLetter As String
        Dim aFirstLettersBySite As String() = {"P", "S", "L", "C", "H", "X", "D"}

        Try
            For Each MyResult In MySearcher.FindAll()
                stationName = MyResult.GetDirectoryEntry().Name.Substring(3).ToUpperInvariant
                statioNameFirstLetter = stationName.Substring(0, 1).ToUpperInvariant

                ' If aFirstLettersBySite.Contains(statioNameFirstLetter) Then
                stationList.Add(MyResult.GetDirectoryEntry().Name.Substring(3))
                'End If
            Next
        Finally
            If Not MySearcher Is Nothing Then
                MySearcher.Dispose()
                MySearcher = Nothing
            End If
        End Try

        log.addLogEntry(New cLogEntry("Nombre de stations trouvées sur DC : " & stationList.Count.ToString, cLogEntry.enumDebugLevel.INFO, "", "", Nothing, True))

        Return stationList
    End Function

    Public Sub getUserLDAPGroups(ByRef groupList As List(Of String), _
                                 ByRef ErrMsg As String)

        Dim listOfGroups As New List(Of String)
        Dim groups As ResultPropertyValueCollection = _sr.Properties("memberOf")

        Dim i As Integer

        For i = 0 To groups.Count - 1
            groupList.Add(groups.Item(i).ToString)
        Next
    End Sub

    Public Shared Sub parseStringLDAPGroupToNameAndFolder(ByVal groupString As String, _
                                                          ByRef name As String, _
                                                          ByRef folder As String)

        Dim domain As String
        Dim aString As String() = groupString.Split(CChar(","))

        name = aString(0).Substring(3)
        domain = String.Format("{0}.{1}", aString(2).Substring(3), aString(3).Substring(3))
        folder = String.Format("{0}\{1}", domain, aString(1).Substring(3))
    End Sub

    Private Function ConvertByteToStringSid(ByVal sidBytes() As Byte) As String
        Return New Security.Principal.SecurityIdentifier(sidBytes, 0).ToString
    End Function

    Private Function isUserAccountControlFlagSet(ByRef userAccountControl As Integer, _
                                                ByVal flagToTest As Integer) As Boolean

        Dim result As Integer = userAccountControl And flagToTest

        Return result = flagToTest
    End Function

End Class
