Imports System.IO

Public Class cleanStationWin7
    Inherits CleanStation

    Private Const WIN7_USER_PROFIL_FOLDER As String = "users"
    Private Const WIN7_REL_PATH_TO_USER_TEMP_FOLDER As String = "AppData\Local\Temp"
    Private Const WIN7_PATH_TO_INTERNET_TEMP_FOLDER As String = "AppData\Local\Microsoft\Windows\Temporary Internet Files\Low\Content.IE5"
    Private Const WIN7_PATH_TO_COOKIES_FOLDER As String = "AppData\Roaming\Microsoft\Windows\Cookies"

    Public Sub New(ByVal station As String)
        MyBase.new(station)
    End Sub

    Protected Overrides Function getBaseUserProfilePath() As String
        Return Path.Combine(sStationBasePath, WIN7_USER_PROFIL_FOLDER)
    End Function

    Protected Overrides Function getPathToTempFolder(ByVal profil As String) As String
        Return Path.Combine(profil, WIN7_REL_PATH_TO_USER_TEMP_FOLDER)
    End Function


    Protected Overrides Function getPathToCookiesFolder(ByVal profil As String) As String
        Return Path.Combine(profil, WIN7_PATH_TO_COOKIES_FOLDER)
    End Function



End Class
