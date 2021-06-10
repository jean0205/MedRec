Public Class Frm_Expenses

    Dim util As New Util
    Dim db As New SamsDB
    Dim dtAll As New DataTable
    Dim dtMonth As New DataTable
    Private Async Sub Frm_Sams_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            AddHandler txtExpense.KeyPress, AddressOf util.txtOnlyLetters_KeyPress
            AddHandler txtCost.KeyPress, AddressOf util.txtOnlyDecimalNumber_KeyPress
            dtAll = Await db.GetExpensesAll()
            loadExpenses(dtAll)
            dtMonth = Await db.GetExpensesMonth(Today)

            'autocomplete
            txtExpense.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtExpense.AutoCompleteSource = AutoCompleteSource.CustomSource
            Dim Collection As AutoCompleteStringCollection = New AutoCompleteStringCollection()
            Collection.AddRange(dtAll.AsEnumerable.Select(Function(r) r("Expense").ToString.TrimEnd.ToUpper).Distinct.ToArray)
            txtExpense.AutoCompleteCustomSource = Collection
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        insertExpense()
    End Sub

    Sub loadExpenses(dt As DataTable)
        Try
            dgv1.Columns.Clear()
            dgv1.DataSource = dt
            util.paintDGVRows(dgv1, Color.Beige, Color.Bisque)
            util.addBottomColumns(dgv1, "DeleteCol", "Delete")
            dgv1.Columns(0).Visible = False
            dgv1.Columns("DeleteCol").Width = 120
            dgv1.Columns(1).DefaultCellStyle.Format = "dd-MMM-yyyy"
            dgv1.Columns(3).DefaultCellStyle.Format = "C2"
            lblServices.Text = dt.Rows.Count.ToString("N0")
            lblTotal.Text = dt.AsEnumerable.Sum(Function(r) CDec(r("Cost"))).ToString("C2")
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub


    Async Sub insertExpense()
        Try
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If txt.TextLength = 0 Then
                    util.InformationMessage("Please enter the required information", "Missing Information")
                    Exit Sub
                End If
            Next
            db.insertExpense(txtExpense.Text.ToUpper, dtpDate.Value.Date, txtCost.Text)
            util.InformationMessage("Information successfully saved", "Saved")
            dtMonth = New DataTable
            dtMonth = Await db.GetExpensesMonth(dtpDate.Value.Date)
            loadExpenses(dtMonth)
            clean()

            'autocomplete surgery
            dtAll = New DataTable
            dtAll = Await db.GetExpensesAll()
            Dim Collection As AutoCompleteStringCollection = New AutoCompleteStringCollection()
            Collection.AddRange(dtAll.AsEnumerable.Select(Function(r) r("Expense").ToString.TrimEnd.ToUpper).Distinct.ToArray)
            txtExpense.AutoCompleteCustomSource = Collection
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub clean()
        For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
            txt.Clear()
        Next
        'dtpDate.Value = Today
    End Sub

    Private Async Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        Try
            If e.RowIndex < 0 Or e.ColumnIndex < 0 Then
                Exit Sub
            End If
            Dim senderGrid = DirectCast(sender, DataGridView)
            Dim rowId As Integer = CInt(senderGrid.Rows(e.RowIndex).Cells("Id").Value)

            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If senderGrid.Columns(e.ColumnIndex).Name = "DeleteCol" Then
                    If util.yesOrNot("Do you want to delete the selected expense", "Delete expense") Then
                        db.DeleteExpense(rowId)
                        util.InformationMessage("Expense sucessfully deleted", "Delete expense")
                        loadExpenses(Await db.GetExpensesMonth(dtpDate.Value.Date))
                    End If
                End If
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub DgvCellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgv1.CellPainting
        Try
            Dim senderGrid As DataGridView = CType(sender, DataGridView)
            If e.RowIndex < 0 Then
                Exit Sub
            End If
            If e.ColumnIndex >= 0 Then
                If senderGrid.Columns(e.ColumnIndex).Name = "DeleteCol" Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                    Dim w = My.Resources.delete.Width
                    Dim h = My.Resources.delete.Height
                    Dim x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2
                    Dim y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2
                    e.Graphics.DrawImage(My.Resources.delete, New Rectangle(x, y, w, h))
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub


    Private Async Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        Try
            dtMonth = New DataTable
            dtMonth = Await db.GetExpensesMonth(dtpDate.Value.Date)
            loadExpenses(dtMonth)

        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Async Sub dtpPeriod_ValueChanged_1(sender As Object, e As EventArgs) Handles dtpPeriod1.ValueChanged, dtpPeriod2.ValueChanged
        Try
            Dim dtPeriod = New DataTable
            dtPeriod = Await db.GetExpensesPeriod(dtpPeriod1.Value.Date, dtpPeriod2.Value.Date)
            loadExpenses(dtPeriod)
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Private Sub IconButton8_Click(sender As Object, e As EventArgs) Handles IconButton8.Click
        util.exportToExcel(dgv1.DataSource)
    End Sub
End Class