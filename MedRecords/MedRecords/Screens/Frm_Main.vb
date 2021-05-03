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

    Private Sub ibtnNew_Click(sender As Object, e As EventArgs) Handles ibtnNewAppointment.Click
        panelAddAppointment.Visible = True
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles ibtnNewPatient.Click
        Dim frm As New Frm_NewPatient
        frm.ShowDialog()
    End Sub

    Private Sub ibtnClosePanel_Click(sender As Object, e As EventArgs) Handles ibtnClosePanel.Click
        panelAddAppointment.Visible = False
    End Sub
#End Region

#Region "Eventos sin importancia"
    Private Panel1Captured As Boolean
    Private Panel1Grabbed As Point
    Private Sub PanelEmployee_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panelAddAppointment.MouseDown
        Panel1Captured = True
        Panel1Grabbed = e.Location
    End Sub
    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panelAddAppointment.MouseMove
        If (Panel1Captured) Then panelAddAppointment.Location = panelAddAppointment.Location + e.Location - Panel1Grabbed
    End Sub
    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panelAddAppointment.MouseUp
        Panel1Captured = False
    End Sub
#End Region

End Class