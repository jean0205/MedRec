Public Class Frm_VisitHistory
    Dim util As New Util
    Dim db As New VisitDB
    Dim dtVisits As New DataTable
    Dim dtNames As New DataTable
    Dim dtDate As New DataTable
    Dim dtMonth As New DataTable
    Dim dtRange As New DataTable
    Dim dbServices As New ServiceDB
    Private Sub Frm_VisitHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getHistory()
    End Sub

    Async Sub getHistory()
        Try
            dtVisits = Await db.GetVisitTable
            getServicesName(dtVisits)
            fillUpCMBServices(dtVisits)
            loadHistorytoDGV(dtVisits)
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub getServicesName(dt As DataTable)
        Try
            'getting services names
            Dim serviceList As New List(Of Service)
            serviceList = dbServices.GetSeriveList
            For Each row As DataRow In dt.Rows
                Dim idList As New List(Of String)
                If Not String.IsNullOrEmpty(row("ServicesId").ToString) Then
                    idList = row("ServicesId").ToString.Split(",").ToList
                    row("ServicesId") = String.Empty
                    For Each id As Integer In idList
                        row("ServicesId") &= serviceList.Where(Function(r) r.Id = id).Select(Function(q) q.Name).First
                        If idList.IndexOf(id) < idList.Count - 1 Then
                            row("ServicesId") &= "/"
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub fillUpCMBServices(dt As DataTable)
        Try
            Dim statusList As New List(Of String)
            statusList = dt.AsEnumerable.Select(Function(r) r("ServicesId").ToString.Split("/")).ToList.SelectMany(Function(x) x.Distinct).Distinct.ToList
            statusList.Insert(0, "ALL SERVICES")
            cmbServices.DataSource = Nothing
            cmbServices.DataSource = statusList.Where(Function(r) Not String.IsNullOrEmpty(r)).Distinct.ToList
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub loadHistorytoDGV(dt As DataTable)
        Try
            dgv1.Columns.Clear()
            dgv1.DataSource = Nothing
            dgv1.DataSource = dt
            dgv1.Columns(0).Visible = False
            dgv1.Columns(1).Visible = False
            util.paintDGVRows(dgv1, Color.Beige, Color.Bisque)
            'headers
            dgv1.Columns(2).HeaderText = "Patient Name"
            dgv1.Columns(3).HeaderText = "Visit Date"
            dgv1.Columns(4).HeaderText = "Services"
            dgv1.Columns(5).HeaderText = "Services Total"
            dgv1.Columns(6).HeaderText = "Other Services"
            dgv1.Columns(7).HeaderText = "Other Services Charges"
            dgv1.Columns(9).HeaderText = "To Pay"

            'Formats
            dgv1.Columns(2).DefaultCellStyle.Format = "dd-MMM-yyyy (hh:mm)"
            dgv1.Columns(5).DefaultCellStyle.Format = "C2"
            dgv1.Columns(7).DefaultCellStyle.Format = "C2"
            dgv1.Columns(8).DefaultCellStyle.Format = "C2"
            dgv1.Columns(9).DefaultCellStyle.Format = "C2"
            dgv1.Columns(10).DefaultCellStyle.Format = "C2"
            dgv1.Columns(11).DefaultCellStyle.Format = "C2"

            'oustanding
            For Each row As DataGridViewRow In dgv1.Rows
                If Not IsDBNull(row.Cells("Oustanding").Value) AndAlso CDec(row.Cells("Oustanding").Value) > 0 Then
                    row.DefaultCellStyle.ForeColor = Color.Red
                ElseIf Not IsDBNull(row.Cells("Oustanding").Value) AndAlso CDec(row.Cells("Oustanding").Value) < 0 Then
                    row.DefaultCellStyle.ForeColor = Color.Blue
                End If
            Next

            If dt.AsEnumerable.Any Then
                lblVisits.Text = dt.Rows.Count
                lblPatients.Text = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("PatientId"))).Select(Function(r) r("PatientId")).Distinct.Count.ToString("N0")
                lblPaid.Text = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("Paid"))).Sum(Function(r) CDec(r("Paid"))).ToString("C2")
                lblOustanding.Text = dt.AsEnumerable.Where(Function(x) Not IsDBNull(x("Oustanding"))).Sum(Function(r) CDec(r("Oustanding"))).ToString("C2")
            End If

        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    '########### FILTERS
    Private Sub cmbServices_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbServices.SelectionChangeCommitted
        Try
            Dim cmb As ComboBox = CType(sender, ComboBox)
            ' Dim dt As New DataTable
            Dim dtfilterd As New DataTable

            If cmb.SelectedIndex > 0 Then
                dtfilterd = New DataTable
                If chkName.Visible Then
                    If dtNames.AsEnumerable.Where(Function(r) r("ServicesId").ToString.ToUpper.Split("/").ToList.Contains(cmb.SelectedItem.ToString.ToUpper)).Any Then
                        dtfilterd = dtNames.AsEnumerable.Where(Function(r) r("ServicesId").ToString.ToUpper.Split("/").
                                                             ToList.Contains(cmb.SelectedItem.ToString.ToUpper)).CopyToDataTable
                        loadHistorytoDGV(dtfilterd)
                    Else
                        dgv1.Columns.Clear()
                    End If
                ElseIf chkDate.Visible Then
                    If dtDate.AsEnumerable.Where(Function(r) r("ServicesId").ToString.ToUpper.Split("/").ToList.Contains(cmb.SelectedItem.ToString.ToUpper)).Any Then
                        dtfilterd = dtDate.AsEnumerable.Where(Function(r) r("ServicesId").ToString.ToUpper.Split("/").
                                                             ToList.Contains(cmb.SelectedItem.ToString.ToUpper)).CopyToDataTable
                        loadHistorytoDGV(dtfilterd)
                    Else
                        dgv1.Columns.Clear()
                    End If
                ElseIf chkPeriod.Visible Then
                    If dtMonth.AsEnumerable.Where(Function(r) r("ServicesId").ToString.ToUpper.Split("/").ToList.Contains(cmb.SelectedItem.ToString.ToUpper)).Any Then
                        dtfilterd = dtMonth.AsEnumerable.Where(Function(r) r("ServicesId").ToString.ToUpper.Split("/").
                                                             ToList.Contains(cmb.SelectedItem.ToString.ToUpper)).CopyToDataTable
                        loadHistorytoDGV(dtfilterd)
                    Else
                        dgv1.Columns.Clear()
                    End If
                ElseIf chkRange.Visible Then
                    If dtRange.AsEnumerable.Where(Function(r) r("ServicesId").ToString.ToUpper.Split("/").ToList.Contains(cmb.SelectedItem.ToString.ToUpper)).Any Then
                        dtfilterd = dtRange.AsEnumerable.Where(Function(r) r("ServicesId").ToString.ToUpper.Split("/").
                                                             ToList.Contains(cmb.SelectedItem.ToString.ToUpper)).CopyToDataTable
                        loadHistorytoDGV(dtfilterd)
                    Else
                        dgv1.Columns.Clear()
                    End If
                Else
                    If dtVisits.AsEnumerable.Where(Function(r) r("ServicesId").ToString.ToUpper.Split("/").
                                                             ToList.Contains(cmb.SelectedItem.ToString.ToUpper)).Any Then
                        loadHistorytoDGV(dtVisits.AsEnumerable.Where(Function(r) r("ServicesId").ToString.ToUpper.Split("/").
                                                                 ToList.Contains(cmb.SelectedItem.ToString.ToUpper)).CopyToDataTable)
                    Else
                        dgv1.Columns.Clear()
                    End If
                End If
                    Else
                If chkName.Visible Then
                    loadHistorytoDGV(dtNames)
                ElseIf chkPeriod.Visible Then
                    loadHistorytoDGV(dtMonth)
                ElseIf chkDate.Visible Then
                    loadHistorytoDGV(dtDate)
                ElseIf chkRange.Visible Then
                    loadHistorytoDGV(dtRange)
                Else
                    loadHistorytoDGV(dtVisits)
                End If
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub txtId_KeyUp(sender As Object, e As KeyEventArgs) Handles txtId.KeyUp
        Try
            Dim txt As TextBox = CType(sender, TextBox)
            If txt.TextLength > 3 Then
                If dtVisits.AsEnumerable.Where(Function(r) r(2).ToString.ToUpper.Contains(txt.Text.ToUpper)).Any Then
                    dtNames = dtVisits.AsEnumerable.Where(Function(r) r(2).ToString.ToUpper.Contains(txt.Text.ToUpper)).CopyToDataTable
                    loadHistorytoDGV(dtNames)
                    fillUpCMBServices(dtNames)
                Else
                    dgv1.Columns.Clear()
                    dgv1.DataSource = Nothing
                    dtNames = New DataTable
                    fillUpCMBServices(dtNames)
                End If
                chkName.Visible = True
                chkName.Checked = False
                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
                    If gb.Name <> "gbStatus" And gb.Name <> "gbId" Then
                        gb.Enabled = False
                    End If
                Next
            Else
                loadHistorytoDGV(dtVisits)
                fillUpCMBServices(dtVisits)
                chkName.Visible = False
                chkName.Checked = False
                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
                    gb.Enabled = True
                Next
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub dtpAuthDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        Try
            If dtVisits.AsEnumerable.Where(Function(r) CDate(r("VisitDate")).Date = dtpDate.Value.Date).Any Then
                dtDate = New DataTable
                dtDate = dtVisits.AsEnumerable.Where(Function(r) CDate(r("VisitDate")).Date = dtpDate.Value.Date).CopyToDataTable
                loadHistorytoDGV(dtDate)
                fillUpCMBServices(dtDate)
            Else
                dtDate = New DataTable
                dgv1.DataSource = Nothing
                fillUpCMBServices(dtDate)
            End If
            chkDate.Visible = True
            chkDate.Checked = False
            For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
                If gb.Name <> "gbDate" And gb.Name <> "gbStatus" Then
                    gb.Enabled = False
                End If
            Next
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub dtpPeriod_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriod.ValueChanged
        Try
            If dtVisits.AsEnumerable.Where(Function(r) CDate(r("VisitDate")).Date.Month = dtpPeriod.Value.Date.Month).Any Then
                dtMonth = New DataTable
                dtMonth = dtVisits.AsEnumerable.Where(Function(r) CDate(r("VisitDate")).Date.Month = dtpPeriod.Value.Date.Month).CopyToDataTable
                loadHistorytoDGV(dtMonth)
                fillUpCMBServices(dtMonth)
            Else
                dtMonth = New DataTable
                dgv1.DataSource = Nothing
                fillUpCMBServices(dtMonth)
            End If
            chkPeriod.Visible = True
            chkPeriod.Checked = False
            For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
                If gb.Name <> "gbPeriod" And gb.Name <> "gbStatus" Then
                    gb.Enabled = False
                End If
            Next
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub chkName_MouseClick(sender As Object, e As MouseEventArgs) Handles chkRange.MouseClick, chkPeriod.MouseClick, chkName.MouseClick, chkDate.MouseClick
        Dim chk As CheckBox = CType(sender, CheckBox)
        Try
            If chk.Checked Then
                loadHistorytoDGV(dtVisits)
                fillUpCMBServices(dtVisits)
                chk.Visible = False
                For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
                    gb.Enabled = True
                Next
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub IconButton3_Click(sender As Object, e As EventArgs) Handles IconButton3.Click
        dtpPeriod.Value = dtpPeriod.Value.AddMonths(-1)
    End Sub

    Private Sub IconButton4_Click(sender As Object, e As EventArgs) Handles IconButton4.Click
        dtpPeriod.Value = dtpPeriod.Value.AddMonths(1)
    End Sub

    Private Sub dtpRangFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpRangFrom.ValueChanged, dtpRangeTo.ValueChanged
        Try
            If dtVisits.AsEnumerable.Where(Function(r) CDate(r("VisitDate")).Date >= dtpRangFrom.Value.Date AndAlso
                                                          CDate(r("VisitDate")).Date <= dtpRangeTo.Value.Date).Any Then
                dtRange = New DataTable
                dtRange = dtVisits.AsEnumerable.Where(Function(r) CDate(r("VisitDate")).Date >= dtpRangFrom.Value.Date AndAlso
                                                          CDate(r("VisitDate")).Date <= dtpRangeTo.Value.Date).CopyToDataTable
                loadHistorytoDGV(dtRange)
                fillUpCMBServices(dtRange)
            Else
                dtRange = New DataTable
                dgv1.DataSource = Nothing
                fillUpCMBServices(dtRange)
            End If
            chkRange.Visible = True
            chkRange.Checked = False
            For Each gb As GroupBox In gb1.Controls.OfType(Of GroupBox)
                If gb.Name <> "gbStatus" And gb.Name <> "gbRange" Then
                    gb.Enabled = False
                End If
            Next
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
End Class