Imports SnmpSharpNet

' voir http://www.snmpsharpnet.com


' OID pour Sn  imprimante en général = 1.3.6.1.2.1.43.5.1.1.17.1
' OID POUR brother HL-8050N : 1.3.6.1.4.1.11.2.3.9.4.2.1.1.3.3.0
' OID pour oki B6300 :        1.3.6.1.4.1.2001.1.1.1.1.11.1.10.45.0
' OID pour lexMark T642 : 1.3.6.1.4.1.641.2.1.2.1.6.1 ' numéro de série sans caractères en plus , fonctionne avec OID général mais avec char()++ 


Public Class snmpGet
    Public community As String = "public"
    Private _hostname As String
    Private _snmp As SimpleSnmp
    Private _rootOID As String = "1.3.6.1.4.1"
    ' Private _requestOid() As String = New String() {"1.3.6.1.2.1.1.1.0", "1.3.6.1.2.1.1.2.0"}
    Private _requestOid() As String = New String() {"1.3.6.1.2.1.43.5.1.1.17.1"}
    Private Const DEFAULT_SNMP_TIMEOUT As Integer = 200 ' ms

    Public Property hostname() As String
        Get
            Return _hostname
        End Get
        Set(value As String)
            _hostname = value
        End Set
    End Property

    Public Sub New(ByVal hostname As String)
        _hostname = hostname
        _snmp = New SimpleSnmp(_hostname, community)
        _snmp.Timeout = DEFAULT_SNMP_TIMEOUT
    End Sub

    Public Function getOIDByprinterManufacturer(ByVal sprinterModel As String) As String

        Select Case True
            Case sprinterModel.Contains("B6300") Or 'OKI
                    sprinterModel.Contains("B6500")
                Return "1.3.6.1.4.1.2001.1.1.1.1.11.1.10.45.0"
            Case sprinterModel.Contains("8050N")
                Return "1.3.6.1.4.1.11.2.3.9.4.2.1.1.3.3.0"
            Case sprinterModel.Contains("T642") Or
                    sprinterModel.Contains("T630") Or
                    sprinterModel.Contains("T652") ' ou T630 ou T652 ...
                Return "1.3.6.1.4.1.641.2.1.2.1.6.1"
            Case Else
                Return "1.3.6.1.2.1.43.5.1.1.17.1"
        End Select

        Return Nothing

    End Function


    ''' <summary>
    ''' Ne fonctionne plus avec P20B03LX ( xerox 8560 ) fonctionnait avant modif function 
    ''' à retester avec un walk .... 
    ''' </summary>
    ''' <returns></returns>
    Public Function getSNMPSerial(ByVal printerModel As String) As String

        Dim result As New Dictionary(Of SnmpSharpNet.Oid, SnmpSharpNet.AsnType)
        Dim myOID() As String = New String() {getOIDByprinterManufacturer(printerModel)}

        ' ne génère pas d'exception , par défaut : snmp.SuppressExceptions = False
        result = _snmp.Get(SnmpVersion.Ver1, myOID)

        If result IsNot Nothing Then
            Return result.Values(0).ToString
        Else
            Return "NA"
        End If

    End Function

    Public Function getSNMPHostName() As String

        Dim result As New Dictionary(Of SnmpSharpNet.Oid, SnmpSharpNet.AsnType)
        Dim myOID() As String = New String() {"1.3.6.1.2.1.1.5.0"}

        result = _snmp.Get(SnmpVersion.Ver1, myOID)

        If result IsNot Nothing Then
            Return result.Values(0).ToString
        Else
            Return "NA"
        End If

    End Function

    Public Function getSNMPModel() As String

        Dim result As New Dictionary(Of SnmpSharpNet.Oid, SnmpSharpNet.AsnType)
        Dim myOID() As String = New String() {"1.3.6.1.2.1.25.3.2.1.3.1"}
        result = _snmp.Get(SnmpVersion.Ver1, myOID)

        If result IsNot Nothing Then
            Return result.Values(0).ToString
        Else
            Return "NA"
        End If

    End Function

    ''' <summary>
    '''  Affiche ensemble propriétés à partir d'un rootOID
    ''' </summary>
    Public Sub getNNMPWalkMIB()
        Dim host As String = "localhost"
        Dim community As String = "public"
        Dim requestOid() As String

        Dim result As Dictionary(Of Oid, AsnType)
        Dim rootOid As Oid = New Oid("1.3.6") ' tout l'arbre , à ne pas faire ....
        Dim nextOid As Oid = rootOid
        Dim keepGoing As Boolean = True
        requestOid = New String() {rootOid.ToString()}
        Dim snmp As SimpleSnmp = New SimpleSnmp(_hostname, community)
        ' snmp.SuppressExceptions = False

        If Not snmp.Valid Then
            Exit Sub
        End If
        While keepGoing
            result = snmp.GetNext(SnmpVersion.Ver1, New String() {nextOid.ToString()})
            If result IsNot Nothing Then

                Dim kvp As KeyValuePair(Of Oid, AsnType)
                For Each kvp In result
                    If rootOid.IsRootOf(kvp.Key) Then
                        Console.WriteLine("{0} :  ({1}) {2}", kvp.Key.ToString(),
                                              SnmpConstants.GetTypeName(kvp.Value.Type),
                                              kvp.Value.ToString())
                        Debug.Print("{0} :  ({1}) {2}", kvp.Key.ToString(),
                                              SnmpConstants.GetTypeName(kvp.Value.Type),
                                              kvp.Value.ToString())
                        nextOid = kvp.Key
                    Else
                        keepGoing = False
                    End If
                Next
            Else
                keepGoing = False
            End If
        End While
    End Sub




    'Dim host As String = "localhost"
    'Dim community As String = "public"
    'Dim requestOid() As String
    'Dim result As Dictionary(Of Oid, AsnType)
    '    requestOid = New String() {"1.3.6.1.2.1.1.1.0", "1.3.6.1.2.1.1.2.0"}
    '    Dim snmp As SimpleSnmp = New SimpleSnmp(host, community)
    'If Not snmp.Valid Then
    '        Console.WriteLine("Invalid hostname/community.")
    '        Exit Sub
    'End If
    '    result = snmp.Get(SnmpVersion.Ver1, requestOid)
    '    If result IsNot Nothing Then
    'Dim kvp As KeyValuePair(Of Oid, AsnType)
    'For Each kvp In result
    '            Console.WriteLine("{0}: ({1}) {2}", kvp.Key.ToString(), _
    '                              SnmpConstants.GetTypeName(kvp.Value.Type), _
    '                              kvp.Value.ToString())
    '        Next
    'Else
    '        Console.WriteLine("No results received.")
    '    End If
    'End Sub


End Class
