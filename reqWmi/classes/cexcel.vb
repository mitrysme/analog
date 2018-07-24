Imports Microsoft.Office.Interop
Imports System.Diagnostics
Imports System.Data

Public Class cexcel
    Private _dataToExport As DataSet
    Private _errMessage As String
    Private _xlApp As Excel.Application
    Private _xlWb As Excel.Workbook
    Private _xlWs As Excel.Worksheet

    Public Event lineProcess(ByVal linenumber As Integer)
    Public Event exportKO(ByVal message As String)


    Public Sub New(ByVal ds As DataSet)
        _dataToExport = ds
    End Sub

    Public Sub export()
        Try
            exportToExcel()
        Catch ex As System.Runtime.InteropServices.COMException
            RaiseEvent exportKO("Ouverture Excel Impossible")
        Catch ex As Exception
            RaiseEvent exportKO("Une erreur est survenue pendant l'export")
        Finally
            disposeExcelObjects()
        End Try
    End Sub

    Public Sub exportToExcel()

        Dim _xl As New Excel.Application
  
        ' à virer probleme avec office en anglais sur réseau VMWARE
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")


        _xlWb = _xl.Workbooks.Add()
        _xlWs = CType(_xlWb.Sheets(1), Excel.Worksheet)

        ' entêtes des colonnes
        With _xlWs
            .Cells(1, 1) = "Date Scan"
            .Cells(1, 2) = "Station"
            .Cells(1, 3) = "Modèle"
            .Cells(1, 4) = "Sn"
            .Cells(1, 5) = "Ram"
            .Cells(1, 6) = "ErrDisque"
            .Cells(1, 7) = "ErrRéseau"
            .Cells(1, 8) = "ErrReboot"
            .Cells(1, 9) = "ErrBsod"
            .Cells(1, 10) = "socle"
            .Cells(1, 11) = "free c:\"
            '.Cells(1, 12) = "Erreur"
            'colonnes de 12 à 20 => ecrans
            .Cells(1, 12) = "MonitorName(1)" ' => firstDisplayColumn
            .Cells(1, 13) = "MonitorDisplay(1)"
            .Cells(1, 14) = "MonitorSerial(1)"
            .Cells(1, 15) = "MonitorName(2)"
            .Cells(1, 16) = "MonitorDisplay(2)"
            .Cells(1, 17) = "MonitorSerial(2)"
            .Cells(1, 18) = "MonitorName(3)"
            .Cells(1, 19) = "MonitorDisplay(3)"
            .Cells(1, 20) = "MonitorSerial(3)"
            .Cells(1, 21) = "Erreur"
        End With

        Dim counter As Integer = 2 ' compteur Row
        For Each row As DataRow In _dataToExport.Tables(0).Rows
            With _xlWs
                .Cells(counter, 1) = row("datescan")
                .Cells(counter, 2) = row("station_name")
                .Cells(counter, 3) = row("modele")
                .Cells(counter, 4) = row("serialnumber")
                .Cells(counter, 5) = functions.convRamAsUlongToString(row("ram"))
                .Cells(counter, 6) = row("err_disk")
                .Cells(counter, 7) = row("err_network")
                .Cells(counter, 8) = row("err_reboot")
                .Cells(counter, 9) = row("err_bsod")
                .Cells(counter, 10) = row("socle")
                .Cells(counter, 11) = row("freespaceondisk")
                .Cells(counter, 21) = row("err_message")

                ' Ajout infos Ecrans
                Dim firstDisplayColumn As Integer = 12
                For Each childrow As DataRow In row.GetChildRows("displays")
                    .Cells(counter, firstDisplayColumn) = childrow("monitor_name")
                    .Cells(counter, firstDisplayColumn + 1) = childrow("monitor_display_name")
                    .Cells(counter, firstDisplayColumn + 2) = childrow("monitor_sn")

                    firstDisplayColumn += 3
                Next

            End With

            counter += 1
            RaiseEvent lineProcess(counter - 2)
        Next

        _xl.Visible = True

      
        disposeExcelObjects()
    End Sub

    Private Sub disposeExcelObjects()
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(_xlApp)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(_xlWb)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(_xlWs)
            _xlApp = Nothing
            _xlWb = Nothing
            _xlWs = Nothing
        Catch ex As Exception
            _xlApp = Nothing
            _xlWb = Nothing
            _xlWs = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

End Class
