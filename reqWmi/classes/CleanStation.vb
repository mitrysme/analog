Imports System.Threading
Imports System.IO

Public Class CleanStation
    Public station As String ' Station à cleaner
    Private pathToUsersProfils As String '  chemin UNC vers répertoire profils de la station c:\windows\Do And Settings
    Private nbDeletedFiles As Integer
    Private nbUnableToDeleteFiles As Integer
    Private nbProfils As Integer ' nombre de profils à traiter
    Private processingSummaryInfos As Hashtable
    Private colProfils As List(Of String) = Nothing ' collection path profils à netoyer
    Protected sStationBasePath As String = Nothing

    Public Event finishedCleaning(ByVal processingSummaryInfos As Hashtable)  ' à émettre quand clean fini
    Public Event unableToDeleteFile(ByVal file As String)
    Public Event processingFile(ByVal processingFile As String) ' reporte fichier effacé
    Public Event progressChanged() ' reporte progrès
    Public Event ProcessingProfil(ByVal profil As String) ' reporte le profil en cours de traitement
    Public Event processingError(ByVal errMessage As String)
    Public Event setProgressBarMaxValue(ByVal value As Integer)

    Private Const WINXP_PROFILE_FOLDER As String = "Documents and Settings"
    Private Const WINXP_REL_PATH_TO_USER_TEMP_FOLDER As String = "Local Settings\Temp"
    Private Const WINXP_PATH_TO_INTERNET_TEMP_FOLDER As String = "Local Settings\Temporary Internet Files\Content.IE5"
    Private Const WINXP_PATH_TO_COOKIES_FOLDER As String = "cookies"

    ' pas sous SEVEN ----
    Private Const WINXP_PATH_TO_JAVALOGS As String = "Application Data\Sun\Java\Deployment\log" ' pas vu sous win7
    Private Const WINXP_PATH_TO_COOKIE_FLASH As String = "Application Data\Macromedia\Flash Player\#SharedObjects" ' pas sous win7
    ' pas sous SEVEN

    Private Const WINXP_PATH_TO_PREFETCH As String = "WINDOWS\Prefetch"

    ' \\S11aurge12\c$\Documents and Settings\gabinsc\Application Data\Sun\Java\Deployment\log

    Protected Overridable Function getBaseUserProfilePath() As String
        Return Path.Combine(sStationBasePath, WINXP_PROFILE_FOLDER)
    End Function


    Public Sub New(ByVal station As String)
        Me.station = station
        Me.sStationBasePath = String.Format("\\{0}\c$", station)
        Me.nbDeletedFiles = 0
        Me.nbUnableToDeleteFiles = 0
        Me.colProfils = New List(Of String)
    End Sub

    ' retourne une collection des profils à analyser
    ' correspond au path complet des dossiers dans documents and settings
    Private Function getProfils() As System.Collections.Generic.List(Of String)
        Dim ignoreProfils() As String = {"All Users", "Default User", "LocalService", "NetworkService", "Default", "Public"}

        For Each Profil In System.IO.Directory.GetDirectories(getBaseUserProfilePath())
            If Not ignoreProfils.Contains(Path.GetFileName(Profil)) Then
                colProfils.Add(Profil)
            End If
        Next

        Return colProfils
    End Function

    ' efface fichier temps de tous les profils
    Public Sub deleteTempFilesFromAllProfiles()
        Try
            ' calcul du nombre de profils à effacer 
            ' informe le form
            Me.colProfils = getProfils()
            RaiseEvent setProgressBarMaxValue(colProfils.Count)

            ' parcours tous les profils utilisateurs
            For Each profil As String In colProfils
                RaiseEvent progressChanged()
                RaiseEvent ProcessingProfil(System.IO.Path.GetFileName(profil))

                ' efface les fichiers dans le dossier temp
                deleteFilesFromDirectory(getPathToTempFolder(profil))
                ' efface les dossiers dans le dossier temp
                deleteFoldersFromDirectory(getPathToTempFolder(profil))
                ' efface les fichiers dans le dossier Content.IE5
                deleteFilesFromDirectory(getPathToTempInternetFolder(profil))
                'efface les dossiers dans le dossier Content.IE5
                deleteFoldersFromDirectory(getPathToTempInternetFolder(profil))
                'efface les cookies
                deleteFilesFromDirectory(getPathToCookiesFolder(profil))

                If Me.GetType.Name = "CleanStation" Then
                    'efface logs Java
                    deleteFilesFromDirectory(getPathToJavaLogs(profil))
                    'efface cookies flash
                    deleteFoldersFromDirectory(getPathToCookieFlash(profil))
                End If
            Next

            ' efface fichiers prefetch
            deleteFilesFromDirectory(getPathToPrefethFolder(), New String(0) {"Layout.ini"})

            RaiseEvent finishedCleaning(Me.getSummaryInfos())
            ' FIXME : NOTE 
            ' si on rencontre un acces refusé sur un fichier
            ' exception de type System.UnauthorizedAccessException ( fichier en lecture seule ou pb permission NTFS )
            ' l'exception est catchée dans le dernier bloc et le traitement s'arrete avec un popup d'erreur 
            ' logué dans fichiers non supprimés et continuer 
            ' essayer de faire un seul bloc catch pour toutes les opérations ( duplication de code )
        Catch ex As IO.IOException
            Dim msg As String = "Erreur IO, abandon traitement, vérifiez que la machine est toujours connectée"
            RaiseEvent processingError(msg)
        Catch ex As ThreadAbortException
            'Dim msg As String = "Opération Abandonnée"
            'RaiseEvent processingError(msg)
        Catch ex As Exception
            Dim msg As String = "Une erreur est survenue" & vbCrLf & "Message : " & ex.Message
            RaiseEvent processingError(msg)
        End Try
    End Sub

    ' renvoie informations sur le traitement effectué
    Private Function getSummaryInfos() As Hashtable
        processingSummaryInfos = New Hashtable

        With processingSummaryInfos
            .Add("nbDeletedFiles", Me.nbDeletedFiles)
            .Add("nbUnabletoDeleteFiles", Me.nbUnableToDeleteFiles)
            .Add("nbProfils", Me.colProfils.Count)
        End With
      
        Return processingSummaryInfos
    End Function

    ' OK 
    Protected Overridable Function getPathToTempFolder(ByVal profil As String) As String
        Return Path.Combine(profil, WINXP_REL_PATH_TO_USER_TEMP_FOLDER)
    End Function

    Protected Overridable Function getPathToTempInternetFolder(ByVal profil As String) As String
        Return Path.Combine(profil, WINXP_PATH_TO_INTERNET_TEMP_FOLDER)
    End Function

    Protected Overridable Function getPathToCookiesFolder(ByVal profil As String) As String
        Return Path.Combine(profil, WINXP_PATH_TO_COOKIES_FOLDER)
    End Function

    Private Function getPathToPrefethFolder() As String
        Return Path.Combine(sStationBasePath, WINXP_PATH_TO_PREFETCH)
    End Function

    Private Function getPathToJavaLogs(ByVal profil As String) As String
        Return Path.Combine(profil, WINXP_PATH_TO_JAVALOGS)
    End Function

    Private Function getPathToCookieFlash(ByVal profil As String) As String
        Return Path.Combine(profil, WINXP_PATH_TO_COOKIE_FLASH)
    End Function

    ' efface tous les fichiers dans le rep donné en param
    ' si un fichier est en readonly => impossible d'effacer
    ' possible de changer attribut lecture seule et de réessayer => à faire
    Private Sub deleteFilesFromDirectory(ByVal directory As String)
        If System.IO.Directory.Exists(directory) Then
            Try
                For Each files As String In System.IO.Directory.GetFiles(directory)
                    RaiseEvent processingFile(files)
                    System.IO.File.Delete(files)
                    Me.nbDeletedFiles += 1
                Next
            Catch ex As System.Exception
                RaiseEvent unableToDeleteFile(ex.Message.ToString())
                Me.nbUnableToDeleteFiles += 1
            End Try
        End If
    End Sub


    ''' <summary>
    ''' efface fichiers dans repertoire
    ''' </summary>
    ''' <param name="directory">chemin du dossier à traiter</param>
    ''' <param name="aDontDeleteTheseFiles">fichiers à ne pas effacer</param>
    ''' <remarks></remarks>
    Private Sub deleteFilesFromDirectory(ByVal directory As String, ByVal aDontDeleteTheseFiles As Array)
        If System.IO.Directory.Exists(directory) Then
            For Each files As String In System.IO.Directory.GetFiles(directory)
                Dim bDontDelete = False
                For Each dontDeletefile As String In aDontDeleteTheseFiles
                    If GetFileName(files).ToLowerInvariant = dontDeletefile.ToLowerInvariant Then
                        bDontDelete = True
                    End If
                Next

                If Not bDontDelete Then
                    Try
                        RaiseEvent processingFile(files)
                        System.IO.File.Delete(files)
                        Me.nbDeletedFiles += 1
                    Catch ex As System.Exception
                        RaiseEvent unableToDeleteFile(ex.Message.ToString())
                        Me.nbUnableToDeleteFiles += 1
                    End Try
                End If
            Next
        End If
    End Sub

    Private Sub deleteFoldersFromDirectory(ByVal directory As String)

        ' parcours tous les sous dossiers dans rep temp et les supprime
        If System.IO.Directory.Exists(directory) Then
            For Each folder In System.IO.Directory.GetDirectories(directory)
                Try
                    'CODE ORIGINAL A RESTAURER
                    RaiseEvent processingFile(folder)
                    System.IO.Directory.Delete(folder, True) ' true => récursivité sinon rep doit être vide avant suppression
                    Me.nbDeletedFiles += 1
                Catch ex As System.IO.DirectoryNotFoundException
                    ' loguer ? => comportement dans dossier temps IE5 très bizzare ...
                    ' si le dossier contient des noms longs dans Temp internet files ,
                    ' la fonction récursive échoue,
                    ' chercher 'long path in .net , solutions documentées ( win32 api kernel.dll )
                Catch ex As System.Exception
                    RaiseEvent unableToDeleteFile(ex.Message.ToString())
                    Me.nbUnableToDeleteFiles += 1
                End Try
            Next
        End If
    End Sub
End Class
