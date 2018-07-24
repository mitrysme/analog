Public Class cPrinterScanner

    Private _ldapPrinterList As List(Of ldapWrapper.ldapPrinterProperties) = Nothing
    Private _cmysqlPrinterTable As New cMysqlPrinterTable

    Public ReadOnly Property ldapPrinterLIst As List(Of ldapWrapper.ldapPrinterProperties)
        Get
            If _ldapPrinterList Is Nothing Then
                _ldapPrinterList = ldapWrapper.getLDAPPrinterINfosList
            End If
            Return _ldapPrinterList
        End Get
    End Property

    ''' <summary>
    ''' Efface les imprimantes qui sont dans la base et qui n'existent plus dans AD.
    ''' </summary>
    Public Sub deletePrintersFromDB()
        Dim printerDBLIst As List(Of cMysqlPrinterTable) = _cmysqlPrinterTable.selectAll


        For Each printer As cMysqlPrinterTable In printerDBLIst
            Dim ldapPrinter As ldapWrapper.ldapPrinterProperties = ldapPrinterLIst.FirstOrDefault(Function(x)
                                                                                                      Return x.printerName = printer.sprinterLDAPPrinterName AndAlso
                                                                                                      x.shortServerName = printer.sprinterLDAPShortserverName
                                                                                                  End Function
                                                                                                       )

            If ldapPrinter.Equals(CType(Nothing, ldapWrapper.ldapPrinterProperties)) Then
                _cmysqlPrinterTable.delete(printer.sprinterLDAPPrinterName,
                                           printer.sprinterLDAPShortserverName)
            End If

        Next

    End Sub

    Public Sub scanPrinters()

        '  Dim listLdapProperties = ldapPrinterLIst

        For Each lprop As ldapWrapper.ldapPrinterProperties In ldapPrinterLIst
            ' le port peut  commencer par :
            ' rien
            ' IP_
            ' IP2_
            ' USB001 
            ' XPSPort:
            ' FILE:

            Dim sPrinterSNMPSerial As String = Nothing
            Dim sPrinterSNMPModel As String = Nothing
            Dim sPrinterSNMPHostname As String = Nothing
            Dim sPrinterErrMessage As String = Nothing
            Dim sprinterLDAPPortName As String = Nothing

            If lprop.portname.StartsWith("IP_") Then
                sprinterLDAPPortName = lprop.portname.Substring(3)
            ElseIf lprop.portname.StartsWith("IP2_") Then
                sprinterLDAPPortName = lprop.portname.Substring(4)
            ElseIf lprop.portname.StartsWith("USB00") Then
                sPrinterErrMessage = "USB_PORT"
            ElseIf lprop.portname.EndsWith(":") Then
                sprinterLDAPPortName = lprop.portname.Remove(lprop.portname.Length - 1)
            ElseIf lprop.portname.Contains("XPSPort:") Or
                    lprop.portname.Contains("LPT1:") Or
                    lprop.portname.Contains("FILE:") Or
                    String.IsNullOrEmpty(lprop.portname) Then
                sPrinterErrMessage = "Invalid Port"
            Else
                sprinterLDAPPortName = lprop.portname
            End If

            If String.IsNullOrEmpty(sPrinterErrMessage) Then

                Dim snmpGet As New snmpGet(sprinterLDAPPortName)

                If network.ping(sprinterLDAPPortName, 300) Then

                    sPrinterSNMPSerial = snmpGet.getSNMPSerial(lprop.driverName)
                    sPrinterSNMPModel = snmpGet.getSNMPModel
                    sPrinterSNMPHostname = snmpGet.getSNMPHostName

                    'Console.WriteLine(String.Format("{0};{1};{2};{3};{4};{5};{6}",
                    '                                lprop.printerName,
                    '                                sPrinterSNMPHostname,
                    '                                lprop.shortServerName,
                    '                                sprinterLDAPPortName,
                    '                                lprop.driverName,
                    '                                sPrinterSNMPSerial,
                    '                                sPrinterSNMPModel)
                    '                                )
                Else
                    sPrinterErrMessage = "PING KO"

                    'Console.WriteLine(String.Format("{0}; ------- PING KO ------- LDAP PORT : {1} - CORRECTED PORT : {2}", lprop.printerName, lprop.portname, sprinterLDAPPortName))
                End If
            End If



            Dim cMysqlPrinter As New cMysqlPrinterTable

            With cMysqlPrinter
                .datePrinterDateScan = DateTime.Now
                .sPrinterErrMessage = sPrinterErrMessage
                .sprinterLDAPDescription = lprop.description
                .sprinterLDAPDriverName = lprop.driverName
                .sprinterLDAPLocation = lprop.location
                .sprinterLDAPPortName = lprop.portname
                .sprinterLDAPPrinterName = lprop.printerName
                .sprinterLDAPShareName = lprop.shareName
                .sprinterLDAPShortserverName = lprop.shortServerName
                .sprinterSNMPHostname = sPrinterSNMPHostname
                .sprinterSNMPModel = sPrinterSNMPModel
                .sprinterSNMPSerial = sPrinterSNMPSerial
            End With

            cMysqlPrinter.save()
        Next

        'Dim ldapProperties As New ldapWrapper.ldapPrinterProperties
        'ldapWrapper.getLDAPPrinterINfos("10.32.2.135", ldapProperties)
        'Dim snmpGetter As New snmpGet("10.32.2.135") ' OKI B6300
        'snmpGetter.getNNMPWalkMIB()
    End Sub

End Class
