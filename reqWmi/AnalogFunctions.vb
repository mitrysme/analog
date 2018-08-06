Imports System.Security.Principal
Imports System.Net.Mail

Namespace Analog.functions

    Public Class misc
        Public Shared Function dateConvert(ByVal dateToConvert As String) As String
            If dateToConvert = "" Or Nothing Then
                Return String.Empty
            End If

            Dim Annee, Mois, Jour, dateConvertie As String
            Annee = Mid(dateToConvert, 1, 4)
            Mois = Mid(dateToConvert, 5, 2)
            Jour = Mid(dateToConvert, 7, 2)
            dateConvertie = String.Format("{0}/{1}/{2}", Jour, Mois, Annee)
            Return dateConvertie
        End Function


        ''' <summary>
        ''' Envoi Mail
        ''' fonction bloquante => TODO utiliser sendAsync ( voir pour callBack)
        ''' </summary>
        ''' <param name="pFrom"></param>
        ''' <param name="pTo"></param>
        ''' <param name="pSubject"></param>
        ''' <param name="pContent"></param>
        ''' <remarks></remarks>
        Public Shared Function SendMail(ByVal pFrom As String,
                                        ByVal pTo As String,
                                        ByVal pSubject As String,
                                        ByVal pContent As String) As Boolean

            Dim _smtpClient As New SmtpClient(program.preferences.sMailServer)
            Dim _smtpCred As New System.Net.NetworkCredential

            _smtpCred.UserName = program.preferences.sMailNTAccount
            _smtpClient.Credentials = _smtpCred

            Try
                _smtpClient.Send(pFrom, pTo, pSubject, pContent)
                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function


        Public Shared Function OpenEmail(ByVal EmailAddress As String,
                                         Optional ByVal Subject As String = "",
                                         Optional ByVal Body As String = "") _
                                         As Boolean

            Dim bAns As Boolean = True
            Dim sParams As String
            sParams = EmailAddress
            If LCase(Strings.Left(sParams, 7)) <> "mailto:" Then _
                sParams = "mailto:" & sParams

            If Subject <> "" Then sParams = sParams &
                  "?subject=" & Subject
            Try
                System.Diagnostics.Process.Start(sParams)
            Catch
                bAns = False
            End Try

            Return bAns

        End Function

        Public Shared Function CreateAleatoire(ByVal intBufferLenght As Integer) As String
            Dim randomizer As New Random
            Dim i As Integer
            Dim Dictionnaire As String
            Dim sb As New System.Text.StringBuilder

            Dictionnaire = "abcdefghijklmnopqrstuvwxyz1234567890"

            For i = 0 To intBufferLenght - 1
                sb.Append(Mid(Dictionnaire, randomizer.Next(1, Len(Dictionnaire)), 1))
            Next

            Return sb.ToString
        End Function

        ' ouverture partage administratif
        Public Shared Sub openShellExplorer(ByVal diskType As String, _
                                            ByVal diskPart As String, _
                                            ByVal stationName As String)
            ' on essaie d'ouvrir le disque en disque$ uniquement si c'est un disque réseau 
            If diskType = "Local" Then
                Dim path As String = String.Format("\\{0}\{1}$", stationName, diskPart.Substring(0, 1))

                Try
                    Shell("explorer" & " " & path, AppWinStyle.NormalFocus)
                Catch ex As Exception
                    MsgBox("Impossible d'ouvrir le dossier", MsgBoxStyle.Exclamation)
                End Try
            Else
                MsgBox("Ouverture Disque réseau en c$ impossible", MsgBoxStyle.Exclamation)
            End If
        End Sub

        ' obtient le SID d'un compte utilisateur 
        Public Shared Function getUserSID(ByVal userName As String, _
                                          ByRef errMsg As String, _
                                          ByRef sid As SecurityIdentifier) As Boolean

            Debug.Assert(Not userName.Contains(CChar(".")))


            Dim ntAccount As New NTAccount(userName)

            Try
                sid = CType(ntAccount.Translate(GetType(System.Security.Principal.SecurityIdentifier)), System.Security.Principal.SecurityIdentifier)
            Catch ex As Exception
                errMsg = ex.Message
                Return False
            End Try

            Return True
        End Function
    End Class

End Namespace


