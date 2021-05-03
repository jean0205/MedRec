Public Class Frm_NewPatient
    Dim util As New Util

    'validar todos los texbox
    'solo numeros en el telefono
    'cuando escriba en los campos de arribafiltrar el datagridview

    Private Sub dtpDOB_ValueChanged(sender As Object, e As EventArgs) Handles dtpDOB.ValueChanged
        Try
            lblAge.Text = util.CalculateAge(Today, dtpDOB.Value.Date)
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error 01")
        End Try
    End Sub


End Class