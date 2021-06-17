Imports System.IO

Public Class Frm_InvoicesReport
    Dim _month As Date = Date.Now
    Dim _FromDate As Date = Date.Now
    Dim _toDate As Date = Date.Now
    Dim dtVisits As New DataTable
    Dim listPatients As New List(Of PatientE)
    Dim dbServices As New ServiceDB
    Dim util As New Util
    Dim dbVisits As New VisitDB
    Dim dtCharts As New DataTable
    Dim loaded As Boolean = False


    Private Async Sub Frm_InvoicesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            dtVisits = Await dbVisits.GetVisitTabledASH
            listPatients = Await dbVisits.GetPatientListAsync(True)
            _month = dtpMonth.Value.Date
            Label1.Text = _month.ToString("MMM-yyyy")
            doChartsMonthly(dtVisits)

            'date range
            dtp1.Value = dtVisits.AsEnumerable.Where(Function(r) Not IsDBNull(r("VisitDate"))).
            Select(Function(x) CDate(x("VisitDate"))).FirstOrDefault
            loaded = True
            dtp2.Value = dtVisits.AsEnumerable.Where(Function(r) Not IsDBNull(r("VisitDate"))).
            Select(Function(x) CDate(x("VisitDate"))).Last
            ageDistributions(listPatients)
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        dtpMonth.Value = dtpMonth.Value.AddMonths(-1)
    End Sub

    Private Sub IconButton2_Click(sender As Object, e As EventArgs) Handles IconButton2.Click
        dtpMonth.Value = dtpMonth.Value.AddMonths(1)
    End Sub
    Private Sub dtpMonth_ValueChanged(sender As Object, e As EventArgs) Handles dtpMonth.ValueChanged
        _month = dtpMonth.Value.Date
        Label1.Text = _month.ToString("MMM-yyyy")
        doChartsMonthly(dtVisits)
    End Sub
    Private Sub dtpPeriod_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged, dtp2.ValueChanged
        If Not loaded Then
            Exit Sub
        End If
        _FromDate = dtp1.Value.Date
        _toDate = dtp2.Value.Date
        Label3.Text = dtp1.Value.Date.ToString("dd-MMM-yyyy") & "  <---->  " & dtp2.Value.Date.ToString("dd-MMM-yyyy")
        If dtVisits.AsEnumerable.Where(Function(r) CDate(r("VisitDate")).Date >= _FromDate AndAlso CDate(r("VisitDate")).Date <= _toDate).Any Then
            Dim dt As New DataTable
            dt = dtVisits.AsEnumerable.Where(Function(r) CDate(r("VisitDate")).Date >= _FromDate AndAlso CDate(r("VisitDate")).Date <= _toDate).CopyToDataTable
            patienVisitServicesChart(dt)
            getTotalCharts(dt)
            getBreakDownChartsIssueToUpload(dt)

        End If

    End Sub

    Sub doChartsMonthly(dt As DataTable)
        Try
            If dt.AsEnumerable.Where(Function(r) CDate(r("VisitDate")).Year =
                                                   _month.Year AndAlso CDate(r("VisitDate")).Month = _month.Month).Any Then

                dtCharts = dt.AsEnumerable.Where(Function(r) CDate(r("VisitDate")).Year =
                                                   _month.Year AndAlso CDate(r("VisitDate")).Month = _month.Month).CopyToDataTable
                MonthlyVisits(dtCharts)
                MonthlyServices(dtCharts)
                MonthlyMoney(dtCharts)
            Else
                util.ErrorMessage("No Records for this period", "No Records")
                chartMonthly.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    'Patient-visit-services
    Sub patienVisitServicesChart(dt As DataTable)
        Try
            Chart3.Visible = True
            Dim vendorList As New List(Of String)({"Patients", "Visits", "Services"})
            Dim cantLst As New List(Of Decimal)
            Dim patients As Integer = dt.AsEnumerable.Select(Function(r) r("PatientId")).Distinct.Count
            Dim visits As Integer = dt.AsEnumerable.Select(Function(r) r("Id")).Distinct.Count
            Dim services As Integer = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("ServicesId"))).Select(Function(r) r("ServicesId").ToString.Split(",")).ToList.SelectMany(Function(x) x).Count
            cantLst.Add(patients)
            cantLst.Add(visits)
            cantLst.Add(services)
            If cantLst.Any Then
                Chart3.Series(0).Points.DataBindXY(vendorList, cantLst)
            End If
        Catch ex As Exception
            Chart3.Visible = False
            util.ErrorMessage(ex.Message, "Error getting Patients-Visits-Services")
        End Try
    End Sub
    'Services Totals
    Sub getTotalCharts(dt As DataTable)
        Try
            ChartTotals.Visible = True
            Dim services As New List(Of Service)
            services = dbServices.GetSeriveList
            Dim servLis As New List(Of String)
            servLis = services.Select(Function(r) r.Name).ToList
            Dim listCant As New List(Of Integer)
            For Each serid As String In services.Select(Function(r) r.Id).ToList
                listCant.Add(dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("ServicesId"))).Where(Function(r) r("ServicesId").ToString.Split(",").Contains(serid)).Count)
            Next
            'listCant.Reverse()
            If listCant.Any Then
                ChartTotals.Series(0).Points.DataBindXY(servLis, listCant)
            End If
        Catch ex As Exception
            ChartTotals.Visible = False
            util.ErrorMessage(ex.Message, "Error getting Totals")
        End Try
    End Sub
    Sub getBreakDownChartsIssueToUpload(dt As DataTable)
        Try
            ChartBreakDown.Visible = True
            Dim visitsNumbers As New List(Of Integer)
            Dim cantLst As New List(Of String)
            Dim patientsGroup = dt.AsEnumerable.GroupBy(Function(x) x("PatientId"))
            For Each group In patientsGroup
                If Not visitsNumbers.Contains(group.Count) Then
                    visitsNumbers.Add(group.Count)
                    cantLst.Add(patientsGroup.Where(Function(x) x.Count = group.Count).Count & " [Patient(s) " & group.Count & " Visit(s)]")
                End If
            Next
            If cantLst.Any Then
                ChartBreakDown.Series(0).Points.DataBindXY(cantLst, visitsNumbers)
            End If
        Catch ex As Exception
            ChartBreakDown.Visible = False
            util.ErrorMessage(ex.Message, "Error getting Break-Down")
        End Try
    End Sub

    Sub MonthlyVisits(dt As DataTable)
        Try
            chartMonthly.Visible = True
            Dim listImportedDays As New List(Of Integer)
            Dim listImpotedCant As New List(Of Integer)
            listImportedDays = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("VisitDate"))).Select(Function(r) CDate(r("VisitDate")).Day).Distinct.ToList
            Dim daysGorup = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("VisitDate"))).GroupBy(Function(r) CDate(r("VisitDate")).Day)
            For Each group In daysGorup
                listImpotedCant.Add(group.Count)
            Next
            chartMonthly.ChartAreas(0).AxisX.Minimum = 0
            chartMonthly.ChartAreas(0).AxisX.Maximum = Date.DaysInMonth(_month.Year, _month.Month) + 1
            If listImpotedCant.Count > 0 AndAlso listImportedDays.Count > 0 Then
                chartMonthly.Series(0).Points.DataBindXY(listImportedDays, listImpotedCant)
            End If
        Catch ex As Exception
            chartMonthly.Visible = False
            util.ErrorMessage(ex.Message, "Error loading History")
        End Try
    End Sub
    Sub MonthlyServices(dt As DataTable)
        Try
            chartMonthly.Visible = True
            Dim listImportedDays As New List(Of Integer)
            Dim listImpotedCant As New List(Of Integer)
            listImportedDays = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("VisitDate")) AndAlso Not IsDBNull(x("ServicesId"))).Select(Function(r) CDate(r("VisitDate")).Day).Distinct.ToList
            Dim daysGorup = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("VisitDate")) AndAlso Not IsDBNull(x("ServicesId"))).GroupBy(Function(r) CDate(r("VisitDate")).Day)
            For Each group In daysGorup
                listImpotedCant.Add(group.AsEnumerable.Where(Function(x) Not IsDBNull(x("ServicesId"))).
                                    Select(Function(r) r("ServicesId").ToString.Split(",")).ToList.SelectMany(Function(x) x).Count)
            Next
            chartMonthly.ChartAreas(0).AxisX.Minimum = 0
            chartMonthly.ChartAreas(0).AxisX.Maximum = Date.DaysInMonth(_month.Year, _month.Month) + 1
            If listImpotedCant.Count > 0 AndAlso listImportedDays.Count > 0 Then
                chartMonthly.Series(1).Points.DataBindXY(listImportedDays, listImpotedCant)
            End If
        Catch ex As Exception
            chartMonthly.Visible = False
            util.ErrorMessage(ex.Message, "Error loading History")
        End Try
    End Sub
    Sub MonthlyMoney(dt As DataTable)
        Try
            chartMonthly.Visible = True
            Dim listImportedDays As New List(Of Integer)
            Dim listImpotedCant As New List(Of Decimal)
            listImportedDays = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("VisitDate")) AndAlso Not IsDBNull(x("Paid"))).Select(Function(r) CDate(r("VisitDate")).Day).Distinct.ToList
            Dim daysGorup = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("VisitDate")) AndAlso Not IsDBNull(x("Paid"))).GroupBy(Function(r) CDate(r("VisitDate")).Day)
            For Each group In daysGorup
                listImpotedCant.Add(group.Where(Function(x) Not IsDBNull(x("Paid"))).Sum(Function(r) CDec(r("Paid"))))
            Next
            chartMonthly.ChartAreas(0).AxisX.Minimum = 0
            chartMonthly.ChartAreas(0).AxisX.Maximum = Date.DaysInMonth(_month.Year, _month.Month) + 1
            If listImpotedCant.Count > 0 AndAlso listImportedDays.Count > 0 Then
                chartMonthly.Series(2).Points.DataBindXY(listImportedDays, listImpotedCant)
            End If
        Catch ex As Exception
            chartMonthly.Visible = False
            util.ErrorMessage(ex.Message, "Error loading History")
        End Try
    End Sub

    Sub ageDistributions(list As List(Of PatientE))
        Try
            Dim ageList As New List(Of Integer)
            ageList = list.Select(Function(r) util.CalculateAge(Today, r.DatOB)).Distinct.ToList

            Dim cantList As New List(Of Integer)
            cantList.Add(ageList.Where(Function(r As Integer) r < 20).Count)
            cantList.Add(ageList.Where(Function(r As Integer) r >= 20 And r < 30).Count)
            cantList.Add(ageList.Where(Function(r As Integer) r >= 30 And r < 40).Count)
            cantList.Add(ageList.Where(Function(r As Integer) r >= 40 And r < 50).Count)
            cantList.Add(ageList.Where(Function(r As Integer) r >= 50 And r < 60).Count)
            cantList.Add(ageList.Where(Function(r As Integer) r >= 60 And r < 70).Count)
            cantList.Add(ageList.Where(Function(r As Integer) r >= 70 And r < 80).Count)
            cantList.Add(ageList.Where(Function(r As Integer) r >= 80).Count)

            Dim ageGroups As New List(Of String)({"Less Than 20 [" & cantList(0) & "]",
                                                "Between 20' and 30 [" & cantList(1) & "]",
                                                 "Between 30' and 40 [" & cantList(2) & "]",
                                                 "Between 40' and 50 [" & cantList(3) & "]",
                                                 "Between 50' and 60 [" & cantList(4) & "]",
                                                 "Between 60' and 70 [" & cantList(5) & "]",
                                                 "Between 70' and 80 [" & cantList(6) & "]",
                                                 "Over 80 [" & cantList(7) & "]"})
            ChartAgeDist.Series(0).Points.DataBindXY(ageGroups.Where(Function(r As String) CInt(r.Substring(r.IndexOf("[") + 1, r.IndexOf("]") - r.IndexOf("[") - 1)) <> 0).ToList,
                                                     cantList.Where(Function(r As Integer) r <> 0).ToList)

        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error getting Age Distributions")
        End Try
    End Sub





    '    Dim db As New InvoiceDB
    '    Dim invoice As New Invoice
    '    Dim helper As New UtilAndRecurrent
    '    Dim invoiceId As Integer = 0
    '    Dim dtVendors As New DataTable
    '    Dim dtInvoices As New DataTable
    '    Dim loadAll As Boolean = True
    '    Dim _month As Date = Date.Now
    '    Sub New()


    '        ' This call is required by the designer.
    '        InitializeComponent()

    '        ' Add any initialization after the InitializeComponent() call.
    '        If Not db.getAccessTable.AsEnumerable.Where(Function(r) r("Access") = 5 AndAlso r("User").ToString.ToUpper = helper.userWorking).Any Then
    '            helper.ErrorMessage("You have not access to this Module in SIMIS", "Error")
    '            Me.Close()
    '        End If
    '    End Sub
    '    Private Sub Frm_InvoicesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '        AddHandler txtId.KeyPress, AddressOf helper.txtOnlyIntegersNumber_KeyPress
    '        getHistory()
    '    End Sub

    '    Async Sub getHistory()
    '        Try
    '            dtInvoices = Await db.getInvoicesHistoryAsync
    '            fillUpCMBStatus(dtInvoices)
    '            loadHistorytoDGV(dtInvoices)
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub
    '    Sub loadHistorytoDGV(dt As DataTable)
    '        Try
    '            dgv1.Columns.Clear()
    '            dgv1.DataSource = Nothing
    '            dgv1.DataSource = dt
    '            dgv1.Columns(1).Visible = False
    '            dgv1.Columns(11).Visible = False
    '            dgv1.Columns(12).Visible = False
    '            dgv1.Columns(13).Visible = False

    '            helper.addBottomColumns(dgv1, "InvoiceCol", "Invoice")
    '            helper.addBottomColumns(dgv1, "CommentsCol", "Comt.")
    '            helper.paintDGVRows(dgv1, Color.Beige, Color.Bisque)
    '            Headers()
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub
    '    


    '#Region "Tab 2 DASBOARD"
    '    Dim dtCharts As New DataTable
    '    Dim back As Boolean = False
    '    Dim foward As Boolean = False
    '    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) 
    '        Try
    '            If TabControl1.SelectedIndex = 1 Then
    '                Label3.Text = MonthName(Now.Month) & " - " & Now.Year
    '                doCharts(dtInvoices)
    '            End If
    '        Catch ex As Exception

    '        End Try
    '    End Sub
    '    Sub doCharts(dtInvoices As DataTable)
    '        Try
    '            If dtInvoices.AsEnumerable.Where(Function(r) CBool(r("Active")) = True AndAlso CDate(r("ImportedDate")).Year =
    '                                                   _month.Year AndAlso CDate(r("ImportedDate")).Month = _month.Month).Any Then

    '                dtCharts = dtInvoices.AsEnumerable.Where(Function(r) CBool(r("Active")) = True AndAlso CDate(r("ImportedDate")).Year =
    '                                                                  _month.Year AndAlso CDate(r("ImportedDate")).Month = _month.Month).CopyToDataTable
    '                getTotalCharts(dtCharts)
    '                getBalancesCharts(dtCharts)
    '                getBreakDownChartsIssueToUpload(dtCharts)
    '                invoiceMonthHistoryImported(dtCharts)
    '                invoiceMonthHistoryApproved(dtCharts)
    '                invoiceMonthProcessed(dtCharts)
    '                invoiceMonthAuthorized(dtCharts)
    '                getVendorTop10(dtCharts)
    '            Else
    '                helper.ErrorMessage("No Records for this period", "No Records")
    '                Chart1.Visible = False
    '                Chart2.Visible = False
    '                Chart3.Visible = False
    '                ChartBreakDown.Visible = False
    '                ChartTotals.Visible = False
    '            End If

    '        Catch ex As Exception

    '        End Try
    '    End Sub
    '    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) 
    '        _month = dtp1.Value
    '        doCharts(dtInvoices)
    '    End Sub
    '    Private Sub IconButton1_Click(sender As Object, e As EventArgs) 
    '        back = True
    '        foward = False
    '        _month = _month.AddMonths(-1)
    '        Label3.Text = MonthName(_month.Month) & " - " & _month.Year
    '        doCharts(dtInvoices)
    '    End Sub

    '    Private Sub ibtnChartDataEntry_Click(sender As Object, e As EventArgs) 
    '        back = False
    '        foward = True
    '        _month = _month.AddMonths(1)
    '        Label3.Text = MonthName(_month.Month) & " - " & _month.Year
    '        doCharts(dtInvoices)
    '    End Sub

    '    Sub invoiceMonthHistoryImported(dt As DataTable)
    '        Try
    '            Chart1.Visible = True
    '            Dim listImportedDays As New List(Of Integer)
    '            Dim listImpotedCant As New List(Of Integer)
    '            listImportedDays = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("ImportedDate"))).Select(Function(r) CDate(r("ImportedDate")).Day).Distinct.ToList
    '            Dim daysGorup = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("ImportedDate"))).GroupBy(Function(r) CDate(r("ImportedDate")).Day)
    '            For Each group In daysGorup
    '                listImpotedCant.Add(group.Count)
    '            Next
    '            Chart1.ChartAreas(0).AxisX.Minimum = 0
    '            Chart1.ChartAreas(0).AxisX.Maximum = Date.DaysInMonth(_month.Year, _month.Month) + 1
    '            If listImpotedCant.Count > 0 AndAlso listImportedDays.Count > 0 Then
    '                Chart1.Series(0).Points.DataBindXY(listImportedDays, listImpotedCant)
    '            End If
    '        Catch ex As Exception
    '            Chart1.Visible = False
    '            ' helper.ErrorMessage(ex.Message, "Error loading History")
    '        End Try
    '    End Sub
    '    Sub invoiceMonthHistoryApproved(dt As DataTable)
    '        Try
    '            Chart1.Visible = True
    '            Dim listImportedDays As New List(Of Integer)
    '            Dim listImpotedCant As New List(Of Integer)
    '            listImportedDays = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("ApprovedDate"))).Select(Function(r) CDate(r("ApprovedDate")).Day).Distinct.ToList
    '            Dim daysGorup = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("ApprovedDate"))).GroupBy(Function(r) CDate(r("ApprovedDate")).Day)
    '            For Each group In daysGorup
    '                listImpotedCant.Add(group.Count)
    '            Next
    '            Chart1.ChartAreas(0).AxisX.Minimum = 0
    '            Chart1.ChartAreas(0).AxisX.Maximum = Date.DaysInMonth(_month.Year, _month.Month) + 1
    '            If listImpotedCant.Count > 0 AndAlso listImportedDays.Count > 0 Then
    '                Chart1.Series(1).Points.DataBindXY(listImportedDays, listImpotedCant)
    '            End If
    '        Catch ex As Exception
    '            Chart1.Visible = False
    '            'helper.ErrorMessage(ex.Message, "Error loading History")
    '        End Try
    '    End Sub
    '    Sub invoiceMonthProcessed(dt As DataTable)
    '        Try
    '            Chart1.Visible = True
    '            Dim listImportedDays As New List(Of Integer)
    '            Dim listImpotedCant As New List(Of Integer)
    '            listImportedDays = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("EnterDate"))).Select(Function(r) CDate(r("EnterDate")).Day).Distinct.ToList
    '            Dim daysGorup = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("EnterDate"))).GroupBy(Function(r) CDate(r("EnterDate")).Day)
    '            For Each group In daysGorup
    '                listImpotedCant.Add(group.Count)
    '            Next
    '            Chart1.ChartAreas(0).AxisX.Minimum = 0
    '            Chart1.ChartAreas(0).AxisX.Maximum = Date.DaysInMonth(_month.Year, _month.Month) + 1
    '            If listImpotedCant.Count > 0 AndAlso listImportedDays.Count > 0 Then
    '                Chart1.Series(2).Points.DataBindXY(listImportedDays, listImpotedCant)
    '            End If
    '        Catch ex As Exception
    '            Chart1.Visible = False
    '            ' helper.ErrorMessage(ex.Message, "Error loading History")
    '        End Try
    '    End Sub
    '    Sub invoiceMonthAuthorized(dt As DataTable)
    '        Try
    '            Chart1.Visible = True
    '            Dim listImportedDays As New List(Of Integer)
    '            Dim listImpotedCant As New List(Of Integer)
    '            listImportedDays = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("AuthorizedDate"))).Select(Function(r) CDate(r("AuthorizedDate")).Day).Distinct.ToList
    '            Dim daysGorup = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("AuthorizedDate"))).GroupBy(Function(r) CDate(r("AuthorizedDate")).Day)
    '            For Each group In daysGorup
    '                listImpotedCant.Add(group.Count)
    '            Next
    '            Chart1.ChartAreas(0).AxisX.Minimum = 0
    '            Chart1.ChartAreas(0).AxisX.Maximum = Date.DaysInMonth(_month.Year, _month.Month) + 1
    '            If listImpotedCant.Count > 0 AndAlso listImportedDays.Count > 0 Then
    '                Chart1.Series(3).Points.DataBindXY(listImportedDays, listImpotedCant)
    '            End If
    '        Catch ex As Exception
    '            Chart1.Visible = False
    '            ' helper.ErrorMessage(ex.Message, "Error loading History")
    '        End Try
    '    End Sub
    '    Sub getTotalCharts(dt As DataTable)
    '        Try
    '            ChartTotals.Visible = True
    '            Dim uploads As Integer = dt.AsEnumerable.Where(Function(r) Not IsDBNull(r("Active")) AndAlso CBool(r("Active"))).Count
    '            Dim approved As Integer = dt.AsEnumerable.Where(Function(r) Not IsDBNull(r("Approved")) AndAlso CBool(r("Approved"))).Count
    '            Dim processed As Integer = dt.AsEnumerable.Where(Function(r) Not IsDBNull(r("EnterBy"))).Count
    '            Dim authorized As Integer = dt.AsEnumerable.Where(Function(r) Not IsDBNull(r("AuthorizedBy"))).Count
    '            Dim vendors As Integer = dt.AsEnumerable.Where(Function(r) Not IsDBNull(r("VendorNo"))).Select(Function(q) q("VendorNo").ToString.ToUpper).Distinct.Count

    '            Dim listNames As New List(Of String)({"Inv. Uploads", "Inv. Appr.", "Inv. Proc.", "Inv. Auth.", "Vendors"})
    '            listNames.Reverse()
    '            Dim listCant As New List(Of Integer)({uploads, approved, processed, authorized, vendors})
    '            listCant.Reverse()
    '            If listCant.Any Then
    '                ChartTotals.Series(0).Points.DataBindXY(listNames, listCant)
    '            End If

    '        Catch ex As Exception
    '            ChartTotals.Visible = False
    '            ' helper.ErrorMessage(ex.Message, "Error getting Totals")
    '        End Try
    '    End Sub
    '    Sub getBalancesCharts(dt As DataTable)
    '        Try
    '            Chart2.Visible = True
    '            Dim totalDueBalance As Decimal = dt.AsEnumerable.Sum(Function(r) CDec(r("BanlanceDue")))
    '            Dim totalPaidBalance As Decimal = dt.AsEnumerable.Sum(Function(r) CDec(r("BlancePaid")))
    '            Dim listNames As New List(Of String)({"Due Balance", "Paid Balance"})
    '            listNames.Reverse()
    '            Dim listCant As New List(Of Integer)({totalDueBalance, totalPaidBalance})
    '            listCant.Reverse()
    '            If listCant.Any Then
    '                Chart2.Series(0).Points.DataBindXY(listNames, listCant)
    '            End If
    '        Catch ex As Exception
    '            Chart2.Visible = False
    '            'helper.ErrorMessage(ex.Message, "Error getting Totals")
    '        End Try
    '    End Sub
    '    Sub getVendorTop10(dt As DataTable)
    '        Try
    '            Chart3.Visible = True
    '            Dim vendorList As New List(Of String)
    '            Dim cantLst As New List(Of Decimal)
    '            Dim daysGroup As IEnumerable(Of IGrouping(Of String, DataRow))
    '            daysGroup = Enumerable.Empty(Of IGrouping(Of String, DataRow))

    '            daysGroup = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("VendorNo"))).GroupBy(Function(r) r("VendorNo").ToString)

    '            For Each group In daysGroup.OrderByDescending(Function(r) r.Sum(Function(x) CDec(x("BlancePaid")))).Take(10)
    '                vendorList.Add("[" & db.GetVendorName(group.Key.TrimEnd) & "]" & " = " & group.Sum(Function(x) CDec(x("BlancePaid"))).ToString("C2"))
    '                cantLst.Add(group.Count)
    '            Next
    '            If cantLst.Any Then
    '                Chart3.Series(0).Points.DataBindXY(vendorList, cantLst)
    '            End If
    '        Catch ex As Exception
    '            Chart3.Visible = False
    '            'helper.ErrorMessage(ex.Message, "Error getting Break-Down")
    '        End Try
    '    End Sub
    '    Sub getBreakDownChartsIssueToUpload(dt As DataTable)
    '        Try
    '            ChartBreakDown.Visible = True
    '            Dim vendorsList As New List(Of String)
    '            Dim cantLst As New List(Of Integer)
    '            Dim daysGroup As IEnumerable(Of IGrouping(Of Integer, DataRow))
    '            daysGroup = Enumerable.Empty(Of IGrouping(Of Integer, DataRow))
    '            If rbtnIssuUpload.Checked Then
    '                daysGroup = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("DateIssue")) AndAlso Not IsDBNull(x("ImportedDate"))).
    '                                            GroupBy(Function(x) helper.daysBetweenDates(CDate(x("DateIssue")), CDate(x("ImportedDate"))))
    '            ElseIf rbtnUploadApproved.Checked Then
    '                daysGroup = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("ImportedDate")) AndAlso Not IsDBNull(x("ApprovedDate"))).
    '                                            GroupBy(Function(x) helper.daysBetweenDates(CDate(x("ImportedDate")), CDate(x("ApprovedDate"))))
    '            ElseIf rbtnApprovedProcessed.Checked Then
    '                daysGroup = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("ApprovedDate")) AndAlso Not IsDBNull(x("EnterDate"))).
    '                                            GroupBy(Function(x) helper.daysBetweenDates(CDate(x("ApprovedDate")), CDate(x("EnterDate"))))
    '            ElseIf rbtnProccAuth.Checked Then
    '                daysGroup = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("EnterDate")) AndAlso Not IsDBNull(x("AuthorizedDate"))).
    '                                            GroupBy(Function(x) helper.daysBetweenDates(CDate(x("EnterDate")), CDate(x("AuthorizedDate"))))
    '            End If
    '            For Each group In daysGroup.OrderBy(Function(r) r.Key)
    '                vendorsList.Add("[" & group.Key & " Days]" & " = " & group.Count & " Inv.")
    '                cantLst.Add(group.Count)
    '            Next
    '            If cantLst.Any Then
    '                ChartBreakDown.Series(0).Points.DataBindXY(vendorsList, cantLst)
    '            End If
    '        Catch ex As Exception
    '            ChartBreakDown.Visible = False
    '            'helper.ErrorMessage(ex.Message, "Error getting Break-Down")
    '        End Try
    '    End Sub

    '    Private Sub rbtnIssuUpload_MouseClick(sender As Object, e As MouseEventArgs) 
    '        Try
    '            Dim rbtn As RadioButton = CType(sender, RadioButton)
    '            If rbtn.Checked Then
    '                getBreakDownChartsIssueToUpload(dtCharts)
    '            End If
    '        Catch ex As Exception
    '            'helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub

    '    Private Sub Frm_InvoicesReport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    '        Try
    '            'My.Application.OpenForms.Cast(Of Form)() _
    '            '  .Except({Me}) _
    '            '  .ToList() _
    '            '  .ForEach(Sub(form) form.Close())
    '            My.Application.OpenForms.Cast(Of Form)() _
    '              .Where(Function(r) r.Name = "frmPDFViewer") _
    '              .ToList() _
    '              .ForEach(Sub(form) form.Close())
    '            Dim myFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Invoices\"
    '            If Directory.Exists(myFolder) Then
    '                Dim files() As String = IO.Directory.GetFiles(myFolder, "*.*")
    '                If files.Length > 0 Then
    '                    FileSystem.Kill(myFolder & "*.*")
    '                End If
    '            End If
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub


    '#End Region
End Class