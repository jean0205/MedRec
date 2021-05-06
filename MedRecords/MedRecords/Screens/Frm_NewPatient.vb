Imports System.Reflection

Public Class Frm_NewPatient
    Dim util As New Util

    'validar todos los texbox
    'solo numeros en el telefono
    'cuando escriba en los campos de arribafiltrar el datagridview

    Private Sub dtpDOB_ValueChanged(sender As Object, e As EventArgs) Handles dtpDOB.ValueChanged
        Try
            lblAge.Text = util.CalculateAge(Today, dtpDOB.Value.Date)
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click

    End Sub

#Region "Metodos"
    Sub savePatient()
        Try
            Dim patient As New PatientE
            Dim properties As List(Of PropertyInfo) = patient.GetType().GetProperties().ToList
            patient.Active = True
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).First.SetValue()
                End If
            Next


        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
#End Region
End Class