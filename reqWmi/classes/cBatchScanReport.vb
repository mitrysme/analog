Imports System.IO

Public Class cBatchScanReport

    Private _arrStationNamesToDelete As ArrayList
    Private _arrStationNamesToUndelete As ArrayList
    Private _iNumberStationOnDC As Integer
    Private _dateScanStart As Date
    Private _dateScanStop As Date

    Public Property arrStationNamesToDelete() As ArrayList
        Get
            Return _arrStationNamesToDelete
        End Get
        Set(ByVal value As ArrayList)
            _arrStationNamesToDelete = value
        End Set
    End Property

    Public Property arrStationNamesToUndelete() As ArrayList
        Get
            Return _arrStationNamesToUndelete
        End Get
        Set(ByVal value As ArrayList)
            _arrStationNamesToUndelete = value
        End Set
    End Property

    Public Property dateScanStart() As Date
        Get
            Return _dateScanStart
        End Get
        Set(ByVal value As Date)
            _dateScanStart = value
        End Set
    End Property

    Public Property dateScanStop() As Date
        Get
            Return _dateScanStop
        End Get
        Set(ByVal value As Date)
            _dateScanStop = value
        End Set
    End Property

    Public Property iNumberStationOnDC() As Integer
        Get
            Return _iNumberStationOnDC
        End Get
        Set(ByVal value As Integer)
            _iNumberStationOnDC = value
        End Set
    End Property

    Public Sub renderReportToTxt()
        'Using w As StreamWriter = New StreamWriter(

        'End Using
        'Dim logDiskWriter As StreamWriter

        'logDiskWriter.Write(

    End Sub


End Class
