Imports System.IO

Public Class Frm_InvoicesReport
    Private Sub Frm_InvoicesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
    '    Private Sub ibtnMoreInfo_Click(sender As Object, e As EventArgs) 
    '        dgv1.Columns(10).Visible = Not dgv1.Columns(10).Visible
    '        dgv1.Columns(15).Visible = Not dgv1.Columns(15).Visible
    '        dgv1.Columns(17).Visible = Not dgv1.Columns(17).Visible
    '        dgv1.Columns(19).Visible = Not dgv1.Columns(19).Visible
    '        ibtnMoreInfo.Text = If(ibtnMoreInfo.Text = "More Info.", "Less Info.", "More Info.")
    '    End Sub
    '    Sub Headers()
    '        Try
    '            dgv1.Columns(0).HeaderText = "Id"
    '            dgv1.Columns(2).HeaderText = "Inv. #"
    '            dgv1.Columns(3).HeaderText = "Vend. #"
    '            dgv1.Columns(4).HeaderText = "Vend. Name"
    '            dgv1.Columns(5).HeaderText = "Invoice Date"
    '            dgv1.Columns(6).HeaderText = "Invoice Amount"
    '            dgv1.Columns(7).HeaderText = "Amount Paid"
    '            dgv1.Columns(8).HeaderText = "Due Date"
    '            dgv1.Columns(9).HeaderText = "Up. By"
    '            dgv1.Columns(10).HeaderText = "Uploaded"
    '            dgv1.Columns(14).HeaderText = "Appr. By"
    '            dgv1.Columns(15).HeaderText = "Approved"
    '            dgv1.Columns(16).HeaderText = "Proc. By"
    '            dgv1.Columns(17).HeaderText = "Processed"
    '            dgv1.Columns(18).HeaderText = "Auth. By"
    '            dgv1.Columns(19).HeaderText = "Authorized"

    '            dgv1.Columns("DateIssue").DefaultCellStyle.Format = "dd-MMM-yyyy"
    '            dgv1.Columns("DateDue").DefaultCellStyle.Format = "dd-MMM-yyyy"
    '            dgv1.Columns("BanlanceDue").DefaultCellStyle.Format = "C2"
    '            dgv1.Columns("BlancePaid").DefaultCellStyle.Format = "C2"
    '            dgv1.Columns("ImportedDate").DefaultCellStyle.Format = "dd-MMM-yyyy HH:MM"
    '            dgv1.Columns("ApprovedDate").DefaultCellStyle.Format = "dd-MMM-yyyy HH:MM"
    '            dgv1.Columns("EnterDate").DefaultCellStyle.Format = "dd-MMM-yyyy HH:MM"
    '            For Each row As DataGridViewRow In dgv1.Rows
    '                If row.Cells("BanlanceDue").Value <> row.Cells("BlancePaid").Value Then
    '                    row.Cells("BanlanceDue").Style.BackColor = Color.LightSalmon
    '                    row.Cells("BlancePaid").Style.BackColor = Color.Salmon
    '                End If
    '                If Not IsDBNull(row.Cells("ApprovedBy").Value) AndAlso row.Cells("ImportedBy").Value = row.Cells("ApprovedBy").Value Then
    '                    row.Cells("ApprovedBy").Style.BackColor = Color.Salmon
    '                End If
    '            Next
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub
    '    Sub fillUpCMBStatus(dt As DataTable)
    '        Try
    '            Dim statusList As New List(Of String)
    '            statusList = dt.AsEnumerable.Select(Function(r) r("Status").ToString).Distinct.ToList
    '            statusList.Insert(0, "All Status")
    '            cmbSatus.DataSource = Nothing
    '            cmbSatus.DataSource = statusList
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub

    '    '##### TEXT BOX #######
    '    Private Sub txtId_KeyUp(sender As Object, e As KeyEventArgs) 
    '        Try
    '            Dim txt As TextBox = CType(sender, TextBox)
    '            If txt.TextLength > 0 Then
    '                If dtInvoices.AsEnumerable.Where(Function(r) r("Id").ToString.ToUpper.Contains(txt.Text.ToUpper)).Any Then
    '                    loadHistorytoDGV(dtInvoices.AsEnumerable.Where(Function(r) r("Id").ToString.ToUpper.Contains(txt.Text.ToUpper)).CopyToDataTable)
    '                Else
    '                    dgv1.Columns.Clear()
    '                    dgv1.DataSource = Nothing
    '                End If
    '                chkId.Visible = True
    '                chkId.Checked = False
    '                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                    If gb.Name <> "gbId" Then
    '                        gb.Enabled = False
    '                    End If
    '                Next
    '            Else
    '                loadHistorytoDGV(dtInvoices)
    '                chkId.Visible = False
    '                chkId.Checked = False
    '                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                    gb.Enabled = True
    '                Next
    '            End If
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub

    '    Private Sub txtNumbe_KeyUp(sender As Object, e As KeyEventArgs) 
    '        Try
    '            Dim txt As TextBox = CType(sender, TextBox)
    '            If txt.TextLength > 0 Then
    '                If dtInvoices.AsEnumerable.Where(Function(r) r("InvoiceNo").ToString.ToUpper.Contains(txt.Text.ToUpper)).Any Then
    '                    loadHistorytoDGV(dtInvoices.AsEnumerable.Where(Function(r) r("InvoiceNo").ToString.ToUpper.Contains(txt.Text.ToUpper)).CopyToDataTable)
    '                Else
    '                    dgv1.Columns.Clear()
    '                    dgv1.DataSource = Nothing
    '                End If
    '                chkNumber.Visible = True
    '                chkNumber.Checked = False
    '                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                    If gb.Name <> "gbNumber" Then
    '                        gb.Enabled = False
    '                    End If
    '                Next
    '            Else
    '                loadHistorytoDGV(dtInvoices)
    '                chkNumber.Visible = False
    '                chkNumber.Checked = False
    '                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                    gb.Enabled = True
    '                Next
    '            End If
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub

    '    Private Sub txtVendorNumber_KeyUp(sender As Object, e As KeyEventArgs) 
    '        Try
    '            Dim txt As TextBox = CType(sender, TextBox)
    '            If txt.TextLength > 0 Then
    '                If dtInvoices.AsEnumerable.Where(Function(r) r("VendorNo").ToString.ToUpper.Contains(txt.Text.ToUpper)).Any Then
    '                    loadHistorytoDGV(dtInvoices.AsEnumerable.Where(Function(r) r("VendorNo").ToString.ToUpper.Contains(txt.Text.ToUpper)).CopyToDataTable)
    '                Else
    '                    dgv1.Columns.Clear()
    '                    dgv1.DataSource = Nothing
    '                End If
    '                chkVendorNumber.Visible = True
    '                chkVendorNumber.Checked = False
    '                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                    If gb.Name <> "gbVendor" Then
    '                        gb.Enabled = False
    '                    End If
    '                Next
    '            Else
    '                loadHistorytoDGV(dtInvoices)
    '                chkVendorNumber.Visible = False
    '                chkVendorNumber.Checked = False
    '                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                    gb.Enabled = True
    '                Next
    '            End If
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub

    '    '########## Checks Box 
    '    Private Sub chkId_MouseClick(sender As Object, e As MouseEventArgs) 
    '        Try
    '            If chkId.Checked Then
    '                loadHistorytoDGV(dtInvoices)
    '                chkId.Visible = False
    '                txtId.Clear()
    '                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                    gb.Enabled = True
    '                Next
    '            End If
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub

    '    Private Sub chkNumber_MouseClick(sender As Object, e As MouseEventArgs) 
    '        Try
    '            If chkNumber.Checked Then
    '                loadHistorytoDGV(dtInvoices)
    '                chkNumber.Visible = False
    '                txtNumbe.Clear()
    '                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                    gb.Enabled = True
    '                Next
    '            End If
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub

    '    Private Sub chkVendorNumber_MouseClick(sender As Object, e As MouseEventArgs) 
    '        Try
    '            If chkVendorNumber.Checked Then
    '                loadHistorytoDGV(dtInvoices)
    '                chkVendorNumber.Visible = False
    '                txtVendorNumber.Clear()
    '                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                    gb.Enabled = True
    '                Next
    '            End If
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub

    '    Private Sub cmbSatus_SelectionChangeCommitted(sender As Object, e As EventArgs) 
    '        Try
    '            Dim cmb As ComboBox = CType(sender, ComboBox)
    '            If cmb.SelectedIndex > 0 Then
    '                Dim dt As New DataTable
    '                dt = dtInvoices.AsEnumerable.Where(Function(r) r("Status").ToString.ToUpper = cmb.SelectedItem.ToString.ToUpper).CopyToDataTable
    '                loadHistorytoDGV(dt)
    '                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                    If gb.Name <> "gbStatus" Then
    '                        gb.Enabled = False
    '                    End If
    '                Next
    '            Else
    '                loadHistorytoDGV(dtInvoices)
    '                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                    gb.Enabled = True
    '                Next
    '            End If
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub
    '    '###### date time pickers #########
    '    Private Sub dtpAuthDate_ValueChanged(sender As Object, e As EventArgs) 
    '        Try
    '            If dtInvoices.AsEnumerable.Where(Function(r) Not IsDBNull(r("AuthorizedDate")) AndAlso
    '                                                 CDate(r("AuthorizedDate")).Date = dtpAuthDate.Value.Date).Any Then
    '                loadHistorytoDGV(dtInvoices.AsEnumerable.Where(Function(r) Not IsDBNull(r("AuthorizedDate")) AndAlso
    '                                                 CDate(r("AuthorizedDate")).Date = dtpAuthDate.Value.Date).CopyToDataTable)
    '            Else
    '                dgv1.DataSource = Nothing
    '            End If
    '            chkAuthDate.Visible = True
    '            chkAuthDate.Checked = False
    '            For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                If gb.Name <> "gbDate" Then
    '                    gb.Enabled = False
    '                End If
    '            Next
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub

    '    Private Sub chkAuthDate_MouseClick(sender As Object, e As MouseEventArgs) 
    '        Try
    '            If chkAuthDate.Checked Then
    '                loadHistorytoDGV(dtInvoices)
    '                chkAuthDate.Visible = False
    '                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                    gb.Enabled = True
    '                Next
    '            End If
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub

    '    Private Sub IconButton3_Click(sender As Object, e As EventArgs) 
    '        dtpAuthPeriod.Value = dtpAuthPeriod.Value.AddMonths(-1)
    '    End Sub
    '    Private Sub IconButton4_Click(sender As Object, e As EventArgs) 
    '        dtpAuthPeriod.Value = dtpAuthPeriod.Value.AddMonths(1)
    '    End Sub

    '    Private Sub dtpAuthPeriod_ValueChanged(sender As Object, e As EventArgs) 
    '        Try
    '            If dtInvoices.AsEnumerable.Where(Function(r) Not IsDBNull(r("AuthorizedDate")) AndAlso
    '                                                 CDate(r("AuthorizedDate")).Date.Month = dtpAuthPeriod.Value.Date.Month).Any Then
    '                loadHistorytoDGV(dtInvoices.AsEnumerable.Where(Function(r) Not IsDBNull(r("AuthorizedDate")) AndAlso
    '                                                 CDate(r("AuthorizedDate")).Date.Month = dtpAuthPeriod.Value.Date.Month).CopyToDataTable)
    '            Else
    '                dgv1.DataSource = Nothing
    '            End If
    '            chkAuthPeriod.Visible = True
    '            chkAuthPeriod.Checked = False
    '            For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                If gb.Name <> "gbPeriod" Then
    '                    gb.Enabled = False
    '                End If
    '            Next
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub

    '    Private Sub chkAuthPeriod_MouseClick(sender As Object, e As MouseEventArgs) 
    '        Try
    '            If chkAuthPeriod.Checked Then
    '                loadHistorytoDGV(dtInvoices)
    '                chkAuthPeriod.Visible = False
    '                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                    gb.Enabled = True
    '                Next
    '            End If
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub

    '    Private Sub dtpAuthRangFrom_ValueChanged(sender As Object, e As EventArgs) 
    '        Try
    '            If dtInvoices.AsEnumerable.Where(Function(r) Not IsDBNull(r("AuthorizedDate")) AndAlso
    '                                                 CDate(r("AuthorizedDate")).Date >= dtpAuthRangFrom.Value.Date AndAlso
    '                                                 CDate(r("AuthorizedDate")).Date <= dtpAuthRangTo.Value.Date).Any Then
    '                loadHistorytoDGV(dtInvoices.AsEnumerable.Where(Function(r) Not IsDBNull(r("AuthorizedDate")) AndAlso
    '                                                 CDate(r("AuthorizedDate")).Date >= dtpAuthRangFrom.Value.Date AndAlso
    '                                                 CDate(r("AuthorizedDate")).Date <= dtpAuthRangTo.Value.Date).CopyToDataTable)
    '            Else
    '                dgv1.DataSource = Nothing
    '            End If
    '            chkAuthRange.Visible = True
    '            chkAuthRange.Checked = False
    '            For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                If gb.Name <> "gbRange" Then
    '                    gb.Enabled = False
    '                End If
    '            Next
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub
    '    Private Sub chkAuthRange_MouseClick(sender As Object, e As MouseEventArgs) 
    '        Try
    '            If chkAuthRange.Checked Then
    '                loadHistorytoDGV(dtInvoices)
    '                chkAuthRange.Visible = False
    '                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
    '                    gb.Enabled = True
    '                Next
    '            End If
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub
    '    Sub getInvoiceDocument(id As Integer)
    '        Try
    '            Dim myFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Invoices\"
    '            If Not Directory.Exists(myFolder) Then
    '                Directory.CreateDirectory(myFolder)
    '            End If
    '            'Dim files() As String = IO.Directory.GetFiles(myFolder, "*.*")
    '            'If files.Length > 0 Then
    '            '    FileSystem.Kill(myFolder & "*.*")
    '            'End If
    '            File.WriteAllBytes(myFolder & "Invoice" & id & ".PDF", db.getInvoiceDocument(id))
    '            Dim path As String = myFolder & "Invoice" & id & ".PDF"
    '            Dim pv As New frmPDFViewer
    '            pv.fpath = path
    '            pv.Show()
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub
    '    Private Sub Dgv1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) 
    '        Try
    '            Dim senderGrid As DataGridView = CType(sender, DataGridView)
    '            If e.RowIndex < 0 Then
    '                Exit Sub
    '            End If
    '            If e.ColumnIndex >= 0 Then
    '                If senderGrid.Columns(e.ColumnIndex).Name = "InvoiceCol" Then
    '                    e.Paint(e.CellBounds, DataGridViewPaintParts.All)
    '                    Dim w = My.Resources.invoice.Width
    '                    Dim h = My.Resources.invoice.Height
    '                    Dim x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2
    '                    Dim y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2
    '                    e.Graphics.DrawImage(My.Resources.invoice, New Rectangle(x, y, w, h))
    '                    e.Handled = True
    '                End If
    '                If senderGrid.Columns(e.ColumnIndex).Name = "CommentsCol" Then
    '                    e.Paint(e.CellBounds, DataGridViewPaintParts.All)
    '                    Dim w = My.Resources.comments_Reports.Width
    '                    Dim h = My.Resources.comments_Reports.Height
    '                    Dim x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2
    '                    Dim y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2
    '                    e.Graphics.DrawImage(My.Resources.comments_Reports, New Rectangle(x, y, w, h))
    '                    e.Handled = True
    '                End If
    '            End If
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub

    '    Private Sub dgv1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) 
    '        Try
    '            If e.RowIndex < 0 Or e.ColumnIndex < 0 Then
    '                Exit Sub
    '            End If
    '            Dim senderGrid = DirectCast(sender, DataGridView)
    '            Dim currentRow As DataGridViewRow = CType(sender, DataGridView).Rows(e.RowIndex)
    '            'buttom Form
    '            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
    '                If senderGrid.Columns(e.ColumnIndex).Name = "InvoiceCol" Then
    '                    invoiceId = CInt(currentRow.Cells("Id").Value)
    '                    getInvoiceDocument(invoiceId)
    '                End If
    '                If senderGrid.Columns(e.ColumnIndex).Name = "CommentsCol" Then
    '                    invoiceId = CInt(currentRow.Cells("Id").Value)
    '                    Dim frm As New Frm_InvoiceComments(invoiceId)
    '                    frm.Show()
    '                End If
    '            Else
    '                invoiceId = 0
    '            End If
    '        Catch ex As Exception
    '            helper.ErrorMessage(ex.Message, "Error")
    '        End Try
    '    End Sub


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