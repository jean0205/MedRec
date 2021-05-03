Public Class Frm_Main
    Dim util As New Util

#Region "Botones"
    Private Sub ibtnPatients_Click(sender As Object, e As EventArgs) Handles ibtnPatients.Click
        Dim frm As New Frm_NewPatient
        frm.ShowDialog()
    End Sub

    Private Sub ibtnServices_Click(sender As Object, e As EventArgs) Handles ibtnServices.Click
        Dim frm As New Frm_Services
        frm.ShowDialog()
    End Sub

    Private Sub ibtnSurgeries_Click(sender As Object, e As EventArgs) Handles ibtnSurgeries.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblTime.Text = Now.ToLongTimeString
        lblDate.Text = Now.ToLongDateString
    End Sub

    Private Sub ibtnNew_Click(sender As Object, e As EventArgs) Handles ibtnNew.Click

    End Sub
#End Region

End Class