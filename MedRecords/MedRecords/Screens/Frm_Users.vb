Public Class Frm_Users
    Dim util As New Util
    Dim db As New UserDB
    Dim user As New Users
    Dim updating As Boolean = False
    Dim userId As Integer = 0

    Sub New(user As Users)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.user = user

    End Sub
    Private Sub Frm_Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler txtName.KeyPress, AddressOf util.txtOnlyLetters_KeyPress
        AddHandler txtUserName.KeyPress, AddressOf util.txtOnlyLetters_KeyPress
        loadUsersList()
    End Sub

    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
            If txt.TextLength = 0 Then
                util.ErrorMessage("Please enter UserName, Name and Password beforetosabe the user", "Missing Information")
                Exit Sub
            End If
        Next
        If Not updating Then
            insertUser()
        Else
            updateUser(userId)
        End If
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
    Sub updateUser(id As Integer)
        Try
            db.updateUserandPassword(id, txtName.Text, txtUserName.Text, txtPassword.Text)
            util.InformationMessage("User sucessfully updated", "Update User")
            userId = 0
            updating = False
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

    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        Try
            If e.RowIndex < 0 Or e.ColumnIndex < 0 Then
                Exit Sub
            End If
            Dim senderGrid = DirectCast(sender, DataGridView)
            Dim rowId As Integer = CInt(senderGrid.Rows(e.RowIndex).Cells("Id").Value)
            Dim selectedUser As New Users
            selectedUser = db.GetUserById(rowId)
            userId = rowId
            'buttom Form
            'medical problems
            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If senderGrid.Columns(e.ColumnIndex).Name = "DeleteCol" Then
                    If user.User = selectedUser.User Then
                        util.InformationMessage("You can not deleteyour same user", "Same User")
                        userId = 0
                        Exit Sub
                    End If
                    If util.yesOrNot("Do you want to delete the selected user", "Delete User") Then
                        db.DeleteUser(rowId)
                        util.InformationMessage("User sucessfully deleted", "Delete User")
                        userId = 0
                        loadUsersList()
                    End If

                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "UpdateCol" Then
                    txtName.Text = senderGrid.Rows(e.RowIndex).Cells("Name").Value.ToString
                    txtUserName.Text = senderGrid.Rows(e.RowIndex).Cells("User").Value.ToString
                    txtPassword.Text = senderGrid.Rows(e.RowIndex).Cells("Password").Value.ToString
                    updating = True
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

    Private Sub dgv1_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseUp
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then
            Exit Sub
        End If
        Dim senderGrid = DirectCast(sender, DataGridView)
        Dim rowId As Integer = CInt(senderGrid.Rows(e.RowIndex).Cells("Id").Value)
        Dim selectedUser As New Users
        selectedUser = db.GetUserById(rowId)
        userId = rowId
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn Then
            If senderGrid.Columns(e.ColumnIndex).Name = "Users" Then
                senderGrid.Rows(e.RowIndex).Cells("Users").Value = Not senderGrid.Rows(e.RowIndex).Cells("Users").Value
                selectedUser.Users = senderGrid.Rows(e.RowIndex).Cells("Users").Value
            End If
            If senderGrid.Columns(e.ColumnIndex).Name = "PatientFile" Then
                senderGrid.Rows(e.RowIndex).Cells("PatientFile").Value = Not senderGrid.Rows(e.RowIndex).Cells("PatientFile").Value
                selectedUser.PatientFile = senderGrid.Rows(e.RowIndex).Cells("PatientFile").Value
            End If
            If senderGrid.Columns(e.ColumnIndex).Name = "Visits" Then
                senderGrid.Rows(e.RowIndex).Cells("Visits").Value = Not senderGrid.Rows(e.RowIndex).Cells("Visits").Value
                selectedUser.Visits = senderGrid.Rows(e.RowIndex).Cells("Visits").Value
            End If
            If senderGrid.Columns(e.ColumnIndex).Name = "Services" Then
                senderGrid.Rows(e.RowIndex).Cells("Services").Value = Not senderGrid.Rows(e.RowIndex).Cells("Services").Value
                selectedUser.Services = senderGrid.Rows(e.RowIndex).Cells("Services").Value
            End If
            If senderGrid.Columns(e.ColumnIndex).Name = "Expenses" Then
                senderGrid.Rows(e.RowIndex).Cells("Expenses").Value = Not senderGrid.Rows(e.RowIndex).Cells("Expenses").Value
                selectedUser.Expenses = senderGrid.Rows(e.RowIndex).Cells("Expenses").Value
            End If
            If senderGrid.Columns(e.ColumnIndex).Name = "Surgeries" Then
                senderGrid.Rows(e.RowIndex).Cells("Surgeries").Value = Not senderGrid.Rows(e.RowIndex).Cells("Surgeries").Value
                selectedUser.Surgeries = senderGrid.Rows(e.RowIndex).Cells("Surgeries").Value
            End If
            If senderGrid.Columns(e.ColumnIndex).Name = "Reports" Then
                senderGrid.Rows(e.RowIndex).Cells("Reports").Value = Not senderGrid.Rows(e.RowIndex).Cells("Reports").Value
                selectedUser.Reports = senderGrid.Rows(e.RowIndex).Cells("Reports").Value
            End If
            If senderGrid.Columns(e.ColumnIndex).Name = "Sams" Then
                senderGrid.Rows(e.RowIndex).Cells("Sams").Value = Not senderGrid.Rows(e.RowIndex).Cells("Sams").Value
                selectedUser.Sams = senderGrid.Rows(e.RowIndex).Cells("Sams").Value
            End If
            If senderGrid.Columns(e.ColumnIndex).Name = "Backup" Then
                senderGrid.Rows(e.RowIndex).Cells("Backup").Value = Not senderGrid.Rows(e.RowIndex).Cells("Backup").Value
                selectedUser.Backup = senderGrid.Rows(e.RowIndex).Cells("Backup").Value
            End If
            If senderGrid.Columns(e.ColumnIndex).Name = "Restore" Then
                senderGrid.Rows(e.RowIndex).Cells("Restore").Value = Not senderGrid.Rows(e.RowIndex).Cells("Restore").Value
                selectedUser.Restore = senderGrid.Rows(e.RowIndex).Cells("Restore").Value
            End If
            db.updateUserAccess(selectedUser)
            loadUsersList()
        End If
    End Sub
End Class