﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Ce code a été généré par un outil.
'     Version du runtime :4.0.30319.42000
'
'     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
'     le code est régénéré.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "Fonctionnalité Enregistrement automatique My.Settings"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("<?xml version=""1.0"" encoding=""utf-16""?>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"<ArrayOfString xmlns:xsi=""http://www.w3."& _ 
            "org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" />")>  _
        Public Property LastUsedStation() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("LastUsedStation"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("LastUsedStation") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property bGetStatDisque() As Boolean
            Get
                Return CType(Me("bGetStatDisque"),Boolean)
            End Get
            Set
                Me("bGetStatDisque") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property bGetPrograms() As Boolean
            Get
                Return CType(Me("bGetPrograms"),Boolean)
            End Get
            Set
                Me("bGetPrograms") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property bLogErreur() As Boolean
            Get
                Return CType(Me("bLogErreur"),Boolean)
            End Get
            Set
                Me("bLogErreur") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property bLogDebug() As Boolean
            Get
                Return CType(Me("bLogDebug"),Boolean)
            End Get
            Set
                Me("bLogDebug") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Tous")>  _
        Public Property sSite() As String
            Get
                Return CType(Me("sSite"),String)
            End Get
            Set
                Me("sSite") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property sScanServer() As String
            Get
                Return CType(Me("sScanServer"),String)
            End Get
            Set
                Me("sScanServer") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("c$\analogScanData")>  _
        Public Property sScanServerDataFolder() As String
            Get
                Return CType(Me("sScanServerDataFolder"),String)
            End Get
            Set
                Me("sScanServerDataFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\Program Files\RealVNC\VNC4\vncviewer.exe")>  _
        Public Property sVncPath() As String
            Get
                Return CType(Me("sVncPath"),String)
            End Get
            Set
                Me("sVncPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property bRemenberPosAndSize() As Boolean
            Get
                Return CType(Me("bRemenberPosAndSize"),Boolean)
            End Get
            Set
                Me("bRemenberPosAndSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0|0|0|0")>  _
        Public Property sFrmMainPosAndSize() As String
            Get
                Return CType(Me("sFrmMainPosAndSize"),String)
            End Get
            Set
                Me("sFrmMainPosAndSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property cPanelState() As String
            Get
                Return CType(Me("cPanelState"),String)
            End Get
            Set
                Me("cPanelState") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property bSaveWindowPos() As Boolean
            Get
                Return CType(Me("bSaveWindowPos"),Boolean)
            End Get
            Set
                Me("bSaveWindowPos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property bSavePanelState() As Boolean
            Get
                Return CType(Me("bSavePanelState"),Boolean)
            End Get
            Set
                Me("bSavePanelState") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property bTransparency() As Boolean
            Get
                Return CType(Me("bTransparency"),Boolean)
            End Get
            Set
                Me("bTransparency") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property bLogPanelCollapse() As Boolean
            Get
                Return CType(Me("bLogPanelCollapse"),Boolean)
            End Get
            Set
                Me("bLogPanelCollapse") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("502")>  _
        Public Property iLogPanelSplitterDistance() As Integer
            Get
                Return CType(Me("iLogPanelSplitterDistance"),Integer)
            End Get
            Set
                Me("iLogPanelSplitterDistance") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property blogInfo() As Boolean
            Get
                Return CType(Me("blogInfo"),Boolean)
            End Get
            Set
                Me("blogInfo") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property bGetLogAnalyze() As Boolean
            Get
                Return CType(Me("bGetLogAnalyze"),Boolean)
            End Get
            Set
                Me("bGetLogAnalyze") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property shortMajGraphDelay() As UShort
            Get
                Return CType(Me("shortMajGraphDelay"),UShort)
            End Get
            Set
                Me("shortMajGraphDelay") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property bUpgrade() As Boolean
            Get
                Return CType(Me("bUpgrade"),Boolean)
            End Get
            Set
                Me("bUpgrade") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("myanalog")>  _
        Public Property sDBServer() As String
            Get
                Return CType(Me("sDBServer"),String)
            End Get
            Set
                Me("sDBServer") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("analog")>  _
        Public Property sDBDatasource() As String
            Get
                Return CType(Me("sDBDatasource"),String)
            End Get
            Set
                Me("sDBDatasource") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("analog")>  _
        Public Property sDBUser() As String
            Get
                Return CType(Me("sDBUser"),String)
            End Get
            Set
                Me("sDBUser") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("analog")>  _
        Public Property sDBPassword() As String
            Get
                Return CType(Me("sDBPassword"),String)
            End Get
            Set
                Me("sDBPassword") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("server=analog;User Id=analog;database=analog")>  _
        Public ReadOnly Property analogConnectionString() As String
            Get
                Return CType(Me("analogConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property bActiveComments() As Boolean
            Get
                Return CType(Me("bActiveComments"),Boolean)
            End Get
            Set
                Me("bActiveComments") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sColDataGridViewState() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("sColDataGridViewState"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("sColDataGridViewState") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property bShowDeletedComputers() As Boolean
            Get
                Return CType(Me("bShowDeletedComputers"),Boolean)
            End Get
            Set
                Me("bShowDeletedComputers") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property bShowScanKO() As Boolean
            Get
                Return CType(Me("bShowScanKO"),Boolean)
            End Get
            Set
                Me("bShowScanKO") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property bGraphAntialiasing() As Boolean
            Get
                Return CType(Me("bGraphAntialiasing"),Boolean)
            End Get
            Set
                Me("bGraphAntialiasing") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property bAnimateGraph() As Boolean
            Get
                Return CType(Me("bAnimateGraph"),Boolean)
            End Get
            Set
                Me("bAnimateGraph") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property sTabOpenList() As String
            Get
                Return CType(Me("sTabOpenList"),String)
            End Get
            Set
                Me("sTabOpenList") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property bSaveSessionTabs() As Boolean
            Get
                Return CType(Me("bSaveSessionTabs"),Boolean)
            End Get
            Set
                Me("bSaveSessionTabs") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\Program Files\Microsoft Configuration Manager\AdminConsole\bin\i386\CmRcViewer"& _ 
            ".exe")>  _
        Public Property sSccmPath() As String
            Get
                Return CType(Me("sSccmPath"),String)
            End Get
            Set
                Me("sSccmPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property bfilterDatescan() As Boolean
            Get
                Return CType(Me("bfilterDatescan"),Boolean)
            End Get
            Set
                Me("bfilterDatescan") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1000")>  _
        Public Property uintPingTimeout() As UShort
            Get
                Return CType(Me("uintPingTimeout"),UShort)
            End Get
            Set
                Me("uintPingTimeout") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("contacttest@domaint.test")>  _
        Public ReadOnly Property sConcactURL() As String
            Get
                Return CType(Me("sConcactURL"),String)
            End Get
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.My.MySettings
            Get
                Return Global.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
