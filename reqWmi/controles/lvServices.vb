''' <summary>
''' Gestion des services
''' </summary>
''' <remarks>
''' Méthodes dérivées De YAPM ( invokeMethods ) 
''' </remarks>
''' 
Public Class lvServices
    Inherits baseLv

    Public Sub New()
        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me.ContextMenuStrip = Me.ContextMenuStripServices
        Me.ContextMenuStripServices.RenderMode = ToolStripRenderMode.System
        ' image liste pour icones programmes
        _IMG = New ImageList
        _IMG.ImageSize = New Size(16, 16)
        _IMG.ColorDepth = ColorDepth.Depth32Bit
        _IMG.Images.Add("serviceIcon", My.Resources.process32)
        Me.SmallImageList = _IMG
    End Sub

    Public Enum serviceStartType
        Automatic = 0
        Disabled = 1
        Manual = 2
    End Enum

    Public Sub updateItemsForStation(ByRef station As cstation)
        If Not station.listOfService Is Nothing Then
            For Each service As wmi.Win32_Service In station.listOfService
                Dim LVI As New ListViewItem(service.DisplayName)

                Dim startedAsString As String
                If service.Started Then
                    startedAsString = "Démarré"
                Else
                    startedAsString = ""
                End If
                Dim processIdAsString As String
                If service.ProcessId = 0 Then
                    processIdAsString = "NA"
                Else
                    processIdAsString = CStr(service.ProcessId)
                End If

                With LVI.SubItems
                    .Add(service.Description)
                    .Add(startedAsString)
                    .Add(service.StartMode)
                    .Add(service.StartName)
                    .Add(service.PathName)
                    .Add(service.ServiceType)
                    .Add(processIdAsString)
                End With

                LVI.Tag = service.Name ' Nom du service pour invokeMethods
                LVI.ImageKey = "serviceIcon"

                Me.Items.Add(LVI)
            Next
        End If
    End Sub

#Region "gestion menu LvService"
    ''' <summary>
    ''' Stoppe le service sélectionné dans le list view
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripItemStop_click(ByVal sender As Object,
                                        ByVal e As System.EventArgs) Handles ToolStripMenuItemStop.Click
        Dim errMsg, name As String
        Dim selectedItem As ListViewItem = GetSelectedItem()

        If Not selectedItem Is Nothing Then
            name = CType(selectedItem.Tag, String)
            errMsg = Nothing

            If Not wmiStopService(name, errMsg) Then
                MsgBox("Une erreur s'est produite" & vbLf & "Message : " & errMsg, MsgBoxStyle.Exclamation)
            Else
                ' La requete a réussi on mets à jour l'item correspondant dans le LV 
                ' TODO => refaire requete wmi pour vérifier état service ...
                selectedItem.SubItems(2).Text = ""
            End If
        End If
    End Sub

    'Private Function getStationObject() As cstation
    '    Dim station As cstation = Nothing

    '    Dim activefrmain As frmMain = CType(program.frmMdiContainer.getActiveFrm, frmMain).station
    '    Return frmMain.station
    'End Function


    ''' <summary>
    ''' Change Type démarrage d'un service
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripItemSetStartType(ByVal sender As Object,
                                          ByVal e As System.EventArgs) Handles ToolStripMenuItemAutoStart.Click,
                                                                               ToolStripMenuItemDisabled.Click,
                                                                               ToolStripMenuItemManualStart.Click

        Dim selectedItem As ListViewItem = GetSelectedItem()
        Dim toolstripmenuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        If Not selectedItem Is Nothing Then
            Dim startType As serviceStartType
            Dim name As String = CType(selectedItem.Tag, String)
            Dim errMsg As String = Nothing

            Select Case toolstripmenuItem.Text
                Case "Automatique"
                    startType = serviceStartType.Automatic
                Case "Manuel"
                    startType = serviceStartType.Manual
                Case "Désactivé"
                    startType = serviceStartType.Disabled
                Case Else
                    log.addLogEntry(New cLogEntry("Type de démarrage non défini", cLogEntry.enumDebugLevel.DEBUG))
                    Exit Sub
            End Select

            If Not SetServiceStartType(name, startType, errMsg) Then
                MsgBox("Une erreur s'est produite" & vbLf & "Message : " & errMsg, MsgBoxStyle.Exclamation)
            Else
                selectedItem.SubItems(3).Text = startType.ToString
            End If

        End If
    End Sub

    ''' <summary>
    ''' Démarre le service sélectionné dans le listview
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' TODO
    ''' Il faudrait vraiment faire une nouvelle requête pour vérifier que le service est bien démarré à la fin de l'opération :
    ''' pour le service "Performance logs and alert", si on le démarre, il s'arrête tout de suite s'il n'a rien à faire,
    ''' si on fait la manip depuis la mmc windows , un message est affiché expliquant le service a démarré mais s'est arrêté
    ''' de suite car il n'avait rien à faire ... 
    ''' Dans l'implémentation actuelle, le service est afficher comme démarré à la fin de l'opération ( fonction renvoie true ... )
    ''' </remarks>
    Private Sub ToolStripItemStart_click(ByVal sender As Object,
                                         ByVal e As System.EventArgs) Handles ToolStripMenuItemStart.Click

        Dim errMsg, name As String
        Dim selectedItem As ListViewItem

        selectedItem = GetSelectedItem()

        If Not selectedItem Is Nothing Then
            name = CType(selectedItem.Tag, String)
            errMsg = Nothing

            If Not wmiStartService(name, errMsg) Then
                MsgBox("Une erreur s'est produite" & vbLf & "Message : " & errMsg, MsgBoxStyle.Exclamation)
            Else
                selectedItem.SubItems(2).Text = "Démarré"
            End If
        End If
    End Sub
#End Region

    ''' <summary>
    ''' Retourne 1er Item sélectionné dans le listView
    ''' </summary>
    ''' <returns>Object</returns>
    ''' <remarks>
    ''' </remarks>
    Public Function GetSelectedItem() As ListViewItem
        If Me.SelectedItems.Count > 0 Then
            Return Me.SelectedItems.Item(0)
        Else
            Return Nothing
        End If
    End Function

#Region "Méthodes services"
    ''' <summary>
    ''' Arrete un service
    ''' </summary>
    ''' <param name="name">nom du service à arreter</param>
    ''' <param name="errMsg">Msg Erreur</param>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Private Shared Function wmiStopService(ByVal name As String, _
                                           ByRef errMsg As String) As Boolean
        Dim _colService As Management.ManagementObjectCollection = Nothing

        Try
            Dim res As AnalogEnums.enums.WmiServiceReturnCode = AnalogEnums.enums.WmiServiceReturnCode.AccessDenied
            Dim station As cstation = CType(program.frmMdiContainer.getActiveFrm, frmMain).station

            If station.wmi.getResultsFor(_colService, "Win32_Service", Nothing, New String() {"Name"}) Then
                For Each srv As Management.ManagementObject In _colService
                    If CStr(srv.GetPropertyValue("Name")) = name Then
                        res = CType(srv.InvokeMethod("StopService", Nothing), AnalogEnums.enums.WmiServiceReturnCode)
                    End If
                Next
            End If

            errMsg = res.ToString
            Return (res = AnalogEnums.enums.WmiServiceReturnCode.Success)

        Catch ex As Exception
            errMsg = ex.Message
            Return False
        Finally
            If _colService IsNot Nothing Then
                _colService.Dispose()
            End If
        End Try
    End Function

    ''' <summary>
    ''' Démarre un service
    ''' </summary>
    ''' <param name="name">nom du service à démarrer</param>
    ''' <param name="errMsg">Msg d'erreur</param>
    ''' <returns>boolean</returns>
    ''' <remarks></remarks>
    Private Shared Function wmiStartService(ByVal name As String, ByRef errMsg As String) As Boolean
        Dim _colService As Management.ManagementObjectCollection = Nothing

        Try
            Dim res As AnalogEnums.enums.WmiServiceReturnCode = AnalogEnums.enums.WmiServiceReturnCode.AccessDenied
            Dim station As cstation = CType(program.frmMdiContainer.getActiveFrm, frmMain).station

            If station.wmi.getResultsFor(_colService, "Win32_Service", Nothing, New String() {"Name"}) Then
                For Each srv As Management.ManagementObject In _colService
                    If CStr(srv.GetPropertyValue("Name")) = name Then
                        res = CType(srv.InvokeMethod("StartService", Nothing), AnalogEnums.enums.WmiServiceReturnCode)
                    End If
                Next
            End If

            errMsg = res.ToString
            Return (res = AnalogEnums.enums.WmiServiceReturnCode.Success)

        Catch ex As Exception
            errMsg = ex.Message
            Return False
        Finally
            If _colService IsNot Nothing Then
                _colService.Dispose()
            End If
        End Try
    End Function

    Private Sub cleanOnDispoe() Handles Me.Disposed
        _IMG.Dispose()
    End Sub

    ''' <summary>
    ''' Changement type démarrage service
    ''' </summary>
    ''' <param name="name">nom du Service</param>
    ''' <param name="type">Type de démarrage</param>
    ''' <param name="errMsg"></param>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Shared Function SetServiceStartType(ByVal name As String, _
                                               ByVal type As serviceStartType, _
                                               ByRef errMsg As String) As Boolean

        Dim _colService As Management.ManagementObjectCollection = Nothing

        Try
            Dim res As AnalogEnums.enums.WmiServiceReturnCode = AnalogEnums.enums.WmiServiceReturnCode.AccessDenied
            Dim station As cstation = CType(program.frmMdiContainer.getActiveFrm, frmMain).station

            If station.wmi.getResultsFor(_colService, "Win32_Service", Nothing, New String() {"Name"}) Then
                For Each srv As Management.ManagementObject In _colService
                    If CStr(srv.GetPropertyValue("Name")) = name Then
                        Dim inParams As Management.ManagementBaseObject = srv.GetMethodParameters("ChangeStartMode")
                        inParams("StartMode") = type.ToString
                        Dim outParams As Management.ManagementBaseObject = srv.InvokeMethod("ChangeStartMode", inParams, Nothing)
                        res = CType(outParams("ReturnValue"), AnalogEnums.enums.WmiServiceReturnCode)
                        Exit For
                    End If
                Next
            End If

            errMsg = res.ToString
            Return (res = AnalogEnums.enums.WmiServiceReturnCode.Success)

        Catch ex As Exception
            errMsg = ex.Message
            Return False
        Finally
            If Not _colService Is Nothing Then
                _colService.Dispose()
            End If
        End Try
    End Function
#End Region

End Class
