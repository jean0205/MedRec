Public Class Form1
    Dim user As New Users
    Dim db As New UserDB
    Dim util As New Util
    Dim dbMain As New MainDB

    Private Sub txtpass_MouseEnter(sender As Object, e As EventArgs) Handles txtuser.MouseEnter, txtpass.MouseEnter
        Dim txt As TextBox = CType(sender, TextBox)
        If txt.Text = "User" Or txt.Text = "Password" Then
            txt.Clear()
        End If
    End Sub

    Private Sub txtpass_MouseLeave(sender As Object, e As EventArgs) Handles txtuser.MouseLeave, txtpass.MouseLeave
        Dim txt As TextBox = CType(sender, TextBox)
        If txt.Text = String.Empty Then
            If txt.Name = "txtuser" Then
                txt.Text = "User"
            Else
                txt.Text = "Password"
            End If

        End If
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        Me.Close()
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        If db.validLoging(txtuser.Text.ToUpper, txtpass.Text) Then
            user = db.GetUserByUserName(txtuser.Text.ToUpper)
            Dim frm As New Frm_Main(user)
            frm.Show()
            Me.Hide()
        Else
            util.ErrorMessage("Wrong user and password combination", "Wrong loging information")
        End If
    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then

            button1.PerformClick()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtuser.Select()
    End Sub

    'Private Sub ibtnRestore_Click(sender As Object, e As EventArgs) Handles ibtnRestore.Click
    '    If Not checkAccess("Restore") Then
    '        Exit Sub
    '    End If
    '    RestoreDataBase()
    'End Sub

End Class
