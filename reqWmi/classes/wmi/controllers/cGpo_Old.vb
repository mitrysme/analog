' semble ne pas etre la bonne méthode, voir :
'http://www.tek-tips.com/viewthread.cfm?qid=1138079



Imports System.Management

Public Class cGpo_Old
    Private _wmiWrapper As cwmi
    Private _moc As ManagementObjectCollection

    Public Sub New(ByRef wmiWrapper As cwmi)
        _wmiWrapper = wmiWrapper
    End Sub

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
    End Structure



    Public Function getActiveGpoList() As Dictionary(Of String, structRsopGpo)
        Dim moc As ManagementObjectCollection = Nothing
        Dim dicGpoComputer As New Dictionary(Of String, structRsopGpo)

        If _wmiWrapper.isConnected Then

            _wmiWrapper.getResultsFor(moc, _
                                      "RSOP_GPLink", _
                                      Nothing, _
                                      New String() {"GPO"})

        End If


        Dim listGpoName(moc.Count - 1) As String
        Dim iCounter As Integer = 0

        For Each I As ManagementObject In moc
            dicGpoComputer.Add(CStr(I.Item("GPO")).Substring(9), New structRsopGpo)
            iCounter += 1
        Next

        moc.Dispose()
        moc = Nothing

        For Each k As KeyValuePair(Of String, structRsopGpo) In dicGpoComputer
            Dim sGpo As New structRsopGpo

            _wmiWrapper.getResultsFor(moc, _
                                      "RSOP_GPO", _
                                      k.Key, _
                                      Nothing)

            Dim mo As ManagementObject = CType(moc(0), ManagementObject)

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
            End With

            Debug.Print("Nom : " & sGpo.name & "filtrage : " & sGpo.enabled.ToString)

        Next

        Return New Dictionary(Of String, structRsopGpo)
    End Function
End Class
