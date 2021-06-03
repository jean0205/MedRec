Public Class Frm_Users
    Dim util As New Util
    Dim db As New UserDB
    Private Sub Frm_Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler txtName.KeyPress, AddressOf util.txtOnlyLetters_KeyPress
        AddHandler txtUserName.KeyPress, AddressOf util.txtOnlyLetters_KeyPress
        loadUsersList()
    End Sub

    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        insertUser()
        cleanInterface()
        loadUsersList()
    End Sub


    Sub insertUser()
        Try
            Dim user As New Users
            user.Name = txtName.Text
            user.User = txtUserName.Text
            user.Password = txtPassword.Text
            user.Users = False
            user.PatientFile = False
            user.Visits = False
            user.Sams = False
            user.Reports = False
            user.Backup = False
            user.Restore = False
            user.Services = False
            user.Surgeries = False
            user.Expenses = False
            db.insertUser(user)
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub cleanInterface()
        Try
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                txt.Clear()
            Next
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub loadUsersList()
        Try
            dgv1.Columns.Clear()
            dgv1.DataSource = db.GetUserList()
            util.paintDGVRows(dgv1, Color.Beige, Color.Bisque)
            util.addBottomColumns(dgv1, "UpdateCol", "Update")
            util.addBottomColumns(dgv1, "DeleteCol", "Delete")
            dgv1.Columns(0).Visible = False
            dgv1.Columns(1).Visible = False
            dgv1.Columns(3).Visible = False
            'dgvMedicalProblems.Columns(2).HeaderText = "Medical Problem"
            'dgvMedicalProblems.Columns(3).HeaderText = "Date"
            dgv1.Columns("UpdateCol").Width = 60
            dgv1.Columns("DeleteCol").Width = 60

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
                If senderGrid.Columns(e.ColumnIndex).Name = "UpdateCol" Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                    Dim w = My.Resources.update.Width
                    Dim h = My.Resources.update.Height
                    Dim x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2
                    Dim y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2
                    e.Graphics.DrawImage(My.Resources.update, New Rectangle(x, y, w, h))
                    e.Handled = True
                End If

            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

End Class