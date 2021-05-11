Imports System.Reflection

Public Class Frm_NewPatient
    Dim util As New Util
    Dim dbPatient As New PatientEDB
    Dim patient As New PatientE
    Dim patientId As Integer
    Dim updating As Boolean = False

    'validar todos los texbox
    'solo numeros en el telefono
    'cuando escriba en los campos de arribafiltrar el datagridview

    Private Sub Frm_NewPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadPatientsList()

    End Sub
    Private Sub dtpDOB_ValueChanged(sender As Object, e As EventArgs) Handles dtpDOB.ValueChanged
        Try
            lblAge.Text = util.CalculateAge(Today, dtpDOB.Value.Date)
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        savePatient(updating)
    End Sub
    Private Sub ibtnCancel_Click(sender As Object, e As EventArgs)
        cleanAfterInsert()
    End Sub

#Region "Metodos"
    Sub savePatient(updating As Boolean)
        Try
            Dim newPatient As New PatientE
            Dim properties As List(Of PropertyInfo) = newPatient.GetType().GetProperties().ToList
            newPatient.Active = True
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).First.SetValue(newPatient, txt.Text.ToUpper)
                End If
            Next
            newPatient.Parish = cmbParish.Text
            newPatient.Sex = cmbSex.Text.ToUpper
            newPatient.DatOB = dtpDOB.Value
            newPatient.PaperRecord = chkPaperRecord.Checked
            newPatient.RegistrationDate = Now
            newPatient.SavedBy = "Jean".ToUpper
            newPatient.SavedTime = Now
            If updating Then
                newPatient.Id = patientId
                dbPatient.UpdatePatient(newPatient)
            Else
                dbPatient.insertPatient(newPatient)
            End If
            cleanAfterInsert()
            util.InformationMessage("Patient successfully saved", "New Patient")
            loadPatientsList()
            updating = False
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub loadPatientsList()
        Try
            dgv1.Columns.Clear()
            dgv1.DataSource = dbPatient.GetPatientList(True).OrderByDescending(Function(r) r.RegistrationDate).ToList
            util.paintDGVRows(dgv1, Color.Beige, Color.Bisque)
            util.addBottomColumns(dgv1, "MedHistCol", "Med. Hist.")
            util.addBottomColumns(dgv1, "UpdateCol", "Update")
            util.addBottomColumns(dgv1, "DeleteCol", "Delete")
            Dim indexList As New List(Of Integer)(New Integer() {0, 1, 12, 13, 15, 16})
            util.hideDGVColumns(dgv1, indexList)
            Dim paperRecordList As New List(Of DataGridViewRow)
            paperRecordList = dgv1.Rows.Cast(Of DataGridViewRow).Where(Function(r) r.Cells("PaperRecord").Value = True).ToList
            For Each row As DataGridViewRow In paperRecordList
                row.DefaultCellStyle.BackColor = Color.LightGreen
            Next
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub cleanAfterInsert()
        Try
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                txt.Clear()
            Next
            cmbParish.SelectedItem = Nothing
            cmbSex.SelectedItem = Nothing
            dtpDOB.Value = Today
            chkPaperRecord.Checked = False
            updating = False
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub getPatientById(id As Integer)
        Try
            patient = dbPatient.GetPatientById(id)
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub fillUpInfoToUpdate()
        Try
            Dim properties As List(Of PropertyInfo) = patient.GetType().GetProperties().ToList
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    txt.Text = properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).First.GetValue(patient).ToString.ToUpper
                End If
            Next
            cmbParish.SelectedItem = patient.Parish
            cmbSex.SelectedItem = patient.Sex
            dtpDOB.Value = patient.DatOB
            chkPaperRecord.Checked = patient.PaperRecord
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub



#End Region
#Region "Events"
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
                If senderGrid.Columns(e.ColumnIndex).Name = "MedHistCol" Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                    Dim w = My.Resources.medHistory.Width
                    Dim h = My.Resources.medHistory.Height
                    Dim x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2
                    Dim y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2
                    e.Graphics.DrawImage(My.Resources.medHistory, New Rectangle(x, y, w, h))
                    e.Handled = True
                End If
            End If
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
            patientId = CInt(senderGrid.Rows(e.RowIndex).Cells("Id").Value)
            getPatientById(patientId)
            'buttom Form
            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If senderGrid.Columns(e.ColumnIndex).Name = "DeleteCol" Then
                    If util.yesOrNot("Do you want to delete the selected Patient", "Delete Patient") Then
                        dbPatient.DeletePatient(patientId)
                        util.InformationMessage("Patient successfully deleted", "Patient Daleted")
                        loadPatientsList()
                    End If
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "MedHistCol" Then
                    Dim frm As New Frm_PatientFilevb(patient)
                    frm.ShowDialog()
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "UpdateCol" Then
                    updating = True
                    fillUpInfoToUpdate()
                End If
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub chkFind_Click(sender As Object, e As EventArgs) Handles chkFind.Click
        Try
            If chkFind.Checked Then
                cleanAfterInsert()
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    ' HACER UNA FUNCION DE BUSCAR PACIENTES COMO LA QUE HICE PARA KIOSK
    Private Sub txtFirstName_KeyUp(sender As Object, e As KeyEventArgs) Handles txtOthersNames.KeyUp, txtLastName.KeyUp, txtFirstName.KeyUp
        If chkFind.Checked Then

        End If
    End Sub
    Private Sub Escape(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(27) Then
            cleanAfterInsert()
        End If
    End Sub


#End Region
End Class