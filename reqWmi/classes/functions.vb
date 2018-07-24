Imports System.Text
Imports System.IO
Imports program
Imports System.Runtime.InteropServices
Imports System.Reflection

Public Module functions
    Public Function FindControl(ByVal ControlName As String, ByVal CurrentControl As Control) As Control
        Dim ctr As Control

        For Each ctr In CurrentControl.Controls
            If ctr.Name = ControlName Then
                Return ctr
            Else
                ctr = FindControl(ControlName, ctr)
                If Not ctr Is Nothing Then
                    Return ctr
                End If
            End If
        Next
        Return Nothing ' ça va faire mal si ça se produit
    End Function

    Public Function getFilesInDirectory(ByVal path As String) As String()
        Dim lstFiles As String()
        lstFiles = IO.Directory.GetFiles(path)
        Return lstFiles
    End Function

    ' Return file name from a path
    Public Function GetFileName(ByVal _path As String) As String
        Dim i As Integer = InStrRev(_path, "\", , CompareMethod.Binary)
        If i > 0 Then
            Return Right(_path, _path.Length - i)
        Else
            Return vbNullString
        End If
    End Function

    Public Function getFileCreationDate(ByVal path As String) As Date
        Dim dateCreation As Date = IO.Directory.GetCreationTime(path)
        Return dateCreation
    End Function

    Public Function convStringToUlong(ByVal value As String) As ULong
        Return CULng((CDbl(value) * 1048576) - 1)
    End Function

    Public Function convRamAsUlongToString(ByVal value As Object) As String
        If Not value Is Nothing Then

            Dim ram As ULong

            If ULong.TryParse(value.ToString, ram) Then
                Return CStr(Int((ram) / 1048576) + 1)
            End If

        End If

        Return ""
    End Function

    ''' <summary>
    ''' retourne utilisateur logué sous la forme domain\user
    ''' </summary>
    ''' <returns>string</returns>
    ''' <remarks>
    ''' Qu'est ce qui ce passe en Workgroup ?? => ça plante ....
    ''' </remarks>
    Public Function getDomainUserIdentity(Optional ByVal withoutDomain As Boolean = False) As String
        Static Dim domain, user As String

        Try
            If domain = String.Empty Or user = String.Empty Then
                domain = System.Environment.GetEnvironmentVariable("USERDOMAIN")
                user = System.Environment.GetEnvironmentVariable("USERNAME")
            End If
        Catch ex As Exception
            MsgBox("Impossible de déterminer identité utilisateur, le programme ne peut continuer !", MsgBoxStyle.Critical)
            Application.Exit()
        End Try

        If withoutDomain Then
            Return user
        Else
            Return String.Concat(domain, "\", user)
        End If
    End Function
    'obtenir les icônes qui sont associées aux fichier
    ' voir http://support.microsoft.com/kb/319340/fr
    Public Function GetIcon(ByVal fName As String, Optional ByVal small As Boolean = True) _
               As System.Drawing.Icon

        Const SHGFI_ICON As Integer = &H100
        Const SHGFI_SMALLICON As Integer = &H1
        'Const SHGFI_LARGEICON As Integer = &H0

        Dim hImgSmall As Integer
        Dim hImgLarge As Integer
        Dim shinfo As structs.analogStructs.SHFileInfo
        shinfo = New structs.analogStructs.SHFileInfo()

        If System.IO.File.Exists(fName) = False Then Return Nothing

        If small Then
            'hImgSmall = Analog.functions.misc.SHGetFileInfo(fName, 0, shinfo, _
            '    Marshal.SizeOf(shinfo), _
            '     SHGFI_ICON Or SHGFI_SMALLICON)
            hImgSmall = native.api.nativeFunctions.SHGetFileInfo(fName, 0, shinfo, _
                Marshal.SizeOf(shinfo), _
                SHGFI_ICON Or SHGFI_SMALLICON)
        Else
            hImgLarge = native.api.nativeFunctions.SHGetFileInfo(fName, 0, _
                shinfo, Marshal.SizeOf(shinfo), _
                SHGFI_ICON Or SHGFI_SMALLICON)
        End If

        Dim img As System.Drawing.Icon = Nothing
        Try
            'If shinfo.hIcon.IsNotNull Then
            img = System.Drawing.Icon.FromHandle(shinfo.hIcon)
            'End If
        Catch ex As Exception
            ' Can't retrieve icon
        End Try

        Return img

    End Function
End Module
