Imports System.Runtime.InteropServices
Imports structs.analogStructs

Namespace native.api
    Public Class nativeFunctions
        ''' <summary>
        ''' obtenir les icônes qui sont associées aux fichier
        ''' voir http://support.microsoft.com/kb/319340/fr
        ''' </summary>
        ''' <param name="pszPath"></param>
        ''' <param name="dwFileAttributes"></param>
        ''' <param name="psfi"></param>
        ''' <param name="cbFileInfo"></param>
        ''' <param name="uFlags"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DllImport("shell32.dll", CharSet:=CharSet.Auto)> _
       Public Shared Function SHGetFileInfo(ByVal pszPath As String, _
                        ByVal dwFileAttributes As Integer, _
                        ByRef psfi As SHFileInfo, _
                        ByVal cbFileInfo As Integer, _
                        ByVal uFlags As Integer) As Integer
        End Function

        ''' <summary>
        ''' Detruit handle icone
        ''' </summary>
        ''' <param name="hIcon"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DllImport("user32.dll", SetLastError:=True)> _
        Public Shared Function DestroyIcon(ByVal hIcon As IntPtr) As Boolean
        End Function

        ''' <summary>
        ''' récupère ressources associées à un process ( User / GDI )
        ''' </summary>
        ''' <param name="hProcess">Handle du process</param>
        ''' <param name="uiFlags">0 => gdi Objects / 1 => user Objects</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function GetGuiResources(ByVal hProcess As Long, ByVal uiFlags As Long) As UInt32
        End Function

        ''' <summary>
        ''' Nombre de ticks depuis démarrage windows
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DllImport("kernel32.dll")>
        Public Shared Function GetTickCount() As Integer
        End Function


        <DllImport("dnsapi.dll", EntryPoint:="DnsFlushResolverCache")>
        Public Shared Function DnsFlushResolverCache() As UInt32
        End Function

    End Class

 
End Namespace