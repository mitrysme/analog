Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class cMysqlPrinterTable
    Private _printerID As Integer
    Private _printerLDAPPrinterName As String
    Private _printerLDAPPortname As String ' IP
    Private _printerLDAPShortserverName As String
    Private _printerLDAPDescription As String
    Private _printerLDAPLocation As String
    Private _printerLDAPDriverName As String
    Private _printerLDAPShareName As String
    Private _PrinterDateScan As DateTime
    Private _PrinterErrMessage As String
    Private _printerSNMPSerial As String
    Private _printerSNMPHostname As String
    Private _printerSNMPModel As String
    Private _columnNameToIndexCache As Dictionary(Of String, Integer)

#Region "properties"
    Public Property sprinterLDAPPrinterName() As String
        Get
            Return _printerLDAPPrinterName
        End Get
        Set(value As String)
            _printerLDAPPrinterName = value
        End Set
    End Property

    Public Property sprinterLDAPPortName As String
        Get
            Return _printerLDAPPortname
        End Get
        Set(value As String)
            _printerLDAPPortname = value
        End Set
    End Property

    Public Property sprinterLDAPShortserverName As String
        Get
            Return _printerLDAPShortserverName
        End Get
        Set(value As String)
            _printerLDAPShortserverName = value
        End Set
    End Property

    Public Property sprinterLDAPDescription As String
        Get
            Return _printerLDAPDescription
        End Get
        Set(value As String)
            _printerLDAPDescription = value
        End Set
    End Property

    Public Property sprinterLDAPLocation As String
        Get
            Return _printerLDAPLocation
        End Get
        Set(value As String)
            _printerLDAPLocation = value
        End Set
    End Property

    Public Property sprinterLDAPDriverName As String
        Get
            Return _printerLDAPDriverName
        End Get
        Set(value As String)
            _printerLDAPDriverName = value
        End Set
    End Property

    Public Property sprinterLDAPShareName As String
        Get
            Return _printerLDAPShareName
        End Get
        Set(value As String)
            _printerLDAPShareName = value
        End Set
    End Property

    Public Property datePrinterDateScan As DateTime
        Get
            Return _PrinterDateScan
        End Get
        Set(value As DateTime)
            _PrinterDateScan = value
        End Set
    End Property

    Public Property sPrinterErrMessage As String
        Get
            Return _PrinterErrMessage
        End Get
        Set(value As String)
            _PrinterErrMessage = value
        End Set
    End Property

    Public Property sprinterSNMPSerial As String
        Get
            Return _printerSNMPSerial
        End Get
        Set(value As String)
            _printerSNMPSerial = value
        End Set
    End Property

    Public Property sprinterSNMPHostname As String
        Get
            Return _printerSNMPHostname
        End Get
        Set(value As String)
            _printerSNMPHostname = value
        End Set
    End Property

    Public Property sprinterSNMPModel As String
        Get
            Return _printerSNMPModel
        End Get
        Set(value As String)
            _printerSNMPModel = value
        End Set
    End Property
#End Region

    Private Shared Function getSafeString(ByRef reader As MySqlDataReader,
                                          ByRef colIndex As Integer) As String
        If reader.IsDBNull(colIndex) Then
            Return String.Empty
        Else
            Return reader.GetString(colIndex)
        End If
    End Function

    Public Sub save()
        If isPrinterExist(_printerLDAPPrinterName, _printerLDAPShortserverName) Then
            update()
        Else
            insert()
        End If
    End Sub

    Public Function update() As Integer
        Dim query As String = "UPDATE printers 
                                        SET  
                                    printer_snmp_hostname=@_printerSNMPHostname, 
                                    printer_snmp_model=@_printerSNMPModel,
                                    printer_snmp_serial=@_printerSNMPSerial, 
                                    printer_ldap_printername=@_printerLDAPPrinterName,
                                    printer_ldap_location=@_printerLDAPLocation, 
                                    printer_ldap_shortservername=@_printerLDAPshortServerName,
                                    printer_ldap_port_ip=@_printerLDAPPortName, 
                                    printer_ldap_description=@_printerLDAPDescription,
                                    printer_ldap_sharename=@_printerLDAPShareName,
                                    printer_ldap_drivername=@_printerLDAPDriverName, 
                                    printer_datescan=@_printerDateScan,printer_err_message=@_printerErrMessage 
                                        WHERE 
                                    printer_ldap_printername=@_printerLDAPPrinterName
                                        AND 
                                    printer_ldap_shortservername=@_printerLDAPshortServerName"

        Dim mysqlParams As New List(Of MySqlParameter)

        With mysqlParams
            .Add(New MySqlParameter("@_printerSNMPHostname", _printerSNMPHostname))
            .Add(New MySqlParameter("@_printerSNMPModel", _printerSNMPModel))
            .Add(New MySqlParameter("@_printerSNMPSerial", _printerSNMPSerial))
            .Add(New MySqlParameter("@_printerLDAPPrinterName", _printerLDAPPrinterName))
            .Add(New MySqlParameter("@_printerLDAPLocation", _printerLDAPLocation))
            .Add(New MySqlParameter("@_printerLDAPshortServerName", _printerLDAPShortserverName))
            .Add(New MySqlParameter("@_printerLDAPPortName", _printerLDAPPortname))
            .Add(New MySqlParameter("@_printerLDAPDescription", _printerLDAPDescription))
            .Add(New MySqlParameter("@_printerLDAPShareName", _printerLDAPShareName))
            .Add(New MySqlParameter("@_printerLDAPDriverName", _printerLDAPDriverName))
            .Add(New MySqlParameter("@_printerDateScan", _PrinterDateScan))
            .Add(New MySqlParameter("@_printerErrMessage", _PrinterErrMessage))
        End With


        Return MySqlHelper.ExecuteNonQuery(cMysqlConnection.getDBConnectionString, query, mysqlParams.ToArray)
    End Function

    Public Function insert() As Integer
        Dim query As String = " INSERT INTO printers (printer_id,printer_snmp_hostname,printer_snmp_model,printer_snmp_serial,printer_ldap_printername,printer_ldap_location, printer_ldap_shortservername,
                                printer_ldap_port_ip,printer_ldap_description,printer_ldap_sharename,printer_ldap_drivername,printer_datescan, printer_err_message)
                                 VALUES (@sprinter_id,@_printerSNMPHostname,@_printerSNMPModel,@_printerSNMPSerial,@_printerLDAPPrinterName,@_printerLDAPLocation,@_printerLDAPshortServerName,@_printerLDAPPortName,
                                @_printerLDAPDescription,@_printerLDAPShareName,@_printerLDAPDriverName,@_printerDateScan,@_PrinterErrMessage)"

        Dim mysqlParams As New List(Of MySqlParameter)

        With mysqlParams
            .Add(New MySqlParameter("@sprinter_id", Nothing)) ' auto_increment
            .Add(New MySqlParameter("@_printerSNMPHostname", _printerSNMPHostname))
            .Add(New MySqlParameter("@_printerSNMPModel", _printerSNMPModel))
            .Add(New MySqlParameter("@_printerSNMPSerial", _printerSNMPSerial))
            .Add(New MySqlParameter("@_printerLDAPPrinterName", _printerLDAPPrinterName))
            .Add(New MySqlParameter("@_printerLDAPLocation", _printerLDAPLocation))
            .Add(New MySqlParameter("@_printerLDAPshortServerName", _printerLDAPShortserverName))
            .Add(New MySqlParameter("@_printerLDAPPortName", _printerLDAPPortname))
            .Add(New MySqlParameter("@_printerLDAPDescription", _printerLDAPDescription))
            .Add(New MySqlParameter("@_printerLDAPShareName", _printerLDAPShareName))
            .Add(New MySqlParameter("@_printerLDAPDriverName", _printerLDAPDriverName))
            .Add(New MySqlParameter("@_printerDateScan", _PrinterDateScan))
            .Add(New MySqlParameter("@_printerErrMessage", _PrinterErrMessage))
        End With

        Return MySqlHelper.ExecuteNonQuery(cMysqlConnection.getDBConnectionString, query, mysqlParams.ToArray)

    End Function

    Public Function selectAll() As List(Of cMysqlPrinterTable)


        Dim printerList As New List(Of cMysqlPrinterTable)
        Dim query As String = "SELECT printer_id,printer_snmp_model,printer_snmp_hostname,printer_ldap_printername,printer_ldap_location,printer_ldap_shortservername,
                                printer_ldap_port_ip, printer_ldap_description,printer_ldap_sharename,printer_ldap_drivername,printer_datescan,printer_err_message,
                                printer_snmp_serial FROM printers"

        Using reader As MySqlDataReader = MySqlHelper.ExecuteReader(cMysqlConnection.getDBConnectionString, query)
            If reader.HasRows Then

                If _columnNameToIndexCache Is Nothing Then
                    _columnNameToIndexCache = New Dictionary(Of String, Integer)

                    For i As Integer = 0 To reader.FieldCount - 1
                        _columnNameToIndexCache.Add(reader.GetName(i), i)
                    Next
                End If

                While reader.Read
                    Dim cMysqlPrinterTable As New cMysqlPrinterTable

                    cMysqlPrinterTable._printerID = reader.GetUInt16(_columnNameToIndexCache("printer_id"))
                    cMysqlPrinterTable._printerSNMPModel = getSafeString(reader, _columnNameToIndexCache("printer_snmp_model"))
                    cMysqlPrinterTable._printerSNMPHostname = getSafeString(reader, _columnNameToIndexCache("printer_snmp_hostname"))
                    cMysqlPrinterTable._printerLDAPPrinterName = getSafeString(reader, _columnNameToIndexCache("printer_ldap_printername"))
                    cMysqlPrinterTable._printerLDAPLocation = getSafeString(reader, _columnNameToIndexCache("printer_ldap_location"))
                    cMysqlPrinterTable._printerLDAPShortserverName = getSafeString(reader, _columnNameToIndexCache("printer_ldap_shortservername"))
                    cMysqlPrinterTable._printerLDAPPortname = getSafeString(reader, _columnNameToIndexCache("printer_ldap_port_ip"))
                    cMysqlPrinterTable._printerLDAPDescription = getSafeString(reader, _columnNameToIndexCache("printer_ldap_description"))
                    cMysqlPrinterTable._printerLDAPShareName = getSafeString(reader, _columnNameToIndexCache("printer_ldap_sharename"))
                    cMysqlPrinterTable._printerLDAPDriverName = getSafeString(reader, _columnNameToIndexCache("printer_ldap_drivername"))
                    cMysqlPrinterTable._PrinterDateScan = CType(reader.GetString(_columnNameToIndexCache("printer_datescan")), DateTime)
                    cMysqlPrinterTable._PrinterErrMessage = getSafeString(reader, _columnNameToIndexCache("printer_err_message"))
                    cMysqlPrinterTable._printerSNMPSerial = getSafeString(reader, _columnNameToIndexCache("printer_snmp_serial"))

                    printerList.Add(cMysqlPrinterTable)
                End While
            End If
        End Using

        Return printerList
    End Function

    Public Function delete(ByVal ldapPrintername As String,
                           ByVal ldapShortServerName As String) As Integer

        Dim query As String = "DELETE FROM printers where printer_ldap_printername=@ldapPrinterName and printer_ldap_shortservername=@ldapShortServerName"

        Dim mysqlparams As New List(Of MySqlParameter)

        With mysqlparams
            .Add(New MySqlParameter("@ldapPrintername", ldapPrintername))
            .Add(New MySqlParameter("@ldapShortServerName", ldapShortServerName))
        End With

        Return MySqlHelper.ExecuteNonQuery(cMysqlConnection.getDBConnectionString, query, mysqlparams.ToArray)
    End Function

    Public Function isPrinterExist(ByVal ldapPrinterName As String,
                                   ByVal ldapShortServerName As String) As Boolean
        Dim exist As Boolean
        Dim query As String = "SELECT COUNT(*) FROM printers where printer_ldap_printername=@ldapPrinterName AND printer_ldap_shortservername=@ldapShortServerName"

        Dim mysqlparams As New List(Of MySqlParameter)

        With mysqlparams
            .Add(New MySqlParameter("@ldapPrinterName", ldapPrinterName))
            .Add(New MySqlParameter("@ldapShortServerName", ldapShortServerName))
        End With

        Using reader As MySqlDataReader = MySqlHelper.ExecuteReader(cMysqlConnection.getDBConnectionString, query, mysqlparams.ToArray)
            If reader.HasRows Then
                reader.Read()
                exist = reader.GetBoolean(0)
            Else
                exist = False
            End If
        End Using

        Return exist

    End Function

End Class
