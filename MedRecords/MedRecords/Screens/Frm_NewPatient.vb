Imports System.Reflection

Public Class Frm_NewPatient
    Dim util As New Util
    Dim dbPatient As New PatientEDB
    Dim dbUsers As New UserDB
    Dim patient As New PatientE
    Dim patientId As Integer
    Dim updating As Boolean = False
    Dim patientList As New List(Of PatientE)
    Dim userId As Integer

    Sub New(userId As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        Me.userId = userId
    End Sub

    Private Sub Frm_NewPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadList()
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
    Function MissingInfo() As Boolean
        Try
            If txtFirstName.TextLength = 0 Then
                util.ErrorMessage("Please enter the patient First name.", "Missing Information")
                Return True
            End If
            If txtLastName.TextLength = 0 Then
                util.ErrorMessage("Please enter the patient Last name.", "Missing Information")
                Return True
            End If
            If cmbSex.Text.Length = 0 Then
                util.ErrorMessage("Please enter the patient Sex.", "Missing Information")
                Return True
            End If
            If dtpDOB.Value.Date = Today Then
                util.ErrorMessage("Please enter the patient Date of Birth.", "Missing Information")
                Return True
            End If
            If cmbParish.Text.Length = 0 Then
                util.ErrorMessage("Please enter the patient Parish.", "Missing Information")
                Return True
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
        Return False
    End Function
    Sub savePatient(updating As Boolean)
        Try
            If MissingInfo() Then
                Exit Sub
            End If
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
            loadList()
            Me.updating = False
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub loadList()
        Try
            patientList = New List(Of PatientE)
            patientList = dbPatient.GetPatientList(True).OrderByDescending(Function(r) r.RegistrationDate).ToList
            loadPatientsList(patientList)
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub loadPatientsList(list As List(Of PatientE))
        Try
            dgv1.Columns.Clear()
            dgv1.DataSource = list
            dgv1.Columns("FirstName").HeaderText = "First Name"
            dgv1.Columns("LastName").HeaderText = "Last Name"
            dgv1.Columns("OthersNames").HeaderText = "Others Names"
            dgv1.Columns("RegistrationDate").HeaderText = "Regist. Date"

            dgv1.Columns("DatOB").DefaultCellStyle.Format = "dd-MMM-yyyy"
            dgv1.Columns("RegistrationDate").DefaultCellStyle.Format = "dd-MMM-yyyy (hh:mm)"
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
                        loadList()
                    End If
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "MedHistCol" Then
                    If Not checkAccess() Then
                        Exit Sub
                    End If
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
    Function checkAccess() As Boolean
        Try
            Dim user As New Users
            user = dbUsers.GetUserById(userId)
            If Not user.GetType().GetProperties().Where(Function(r) r.Name = "PatientFile").First.GetValue(user) Then
                util.ErrorMessage("You have not access to this feature in the application." & vbLf & " Please contact your system administrator", "No Access")
                Return False
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
        Return True
    End Function
    Private Sub chkFind_Click(sender As Object, e As EventArgs) Handles chkFind.Click
        Try
            If chkFind.Checked Then
                cleanAfterInsert()
                txtFirstName.BackColor = Color.LightGreen
                txtLastName.BackColor = Color.LightGreen
                txtFirstName.Select()
            Else
                loadList()
                cleanAfterInsert()
                txtFirstName.BackColor = Color.White
                txtLastName.BackColor = Color.White
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    ' HACER UNA FUNCION DE BUSCAR PACIENTES COMO LA QUE HICE PARA KIOSK
    Private Sub txtFirstName_KeyUp(sender As Object, e As KeyEventArgs) Handles txtOthersNames.KeyUp, txtLastName.KeyUp, txtFirstName.KeyUp
        Dim txt As TextBox = CType(sender, TextBox)
        Dim list As New List(Of PatientE)
        If chkFind.Checked Then
            If txt.Name = "txtFirstName" Then
                If txt.TextLength > 0 Or txtLastName.TextLength > 0 Then
                    If patientList.Where(Function(r) r.FirstName.ToString.ToUpper.Contains(txt.Text.ToUpper) Or
                                             r.LastName.ToString.ToUpper.Contains(txtLastName.Text.ToUpper)).Any Then
                        list = patientList.Where(Function(r) r.FirstName.ToString.ToUpper.Contains(txt.Text.ToUpper) AndAlso
                                                    r.LastName.ToString.ToUpper.Contains(txtLastName.Text.ToUpper)).ToList
                        loadPatientsList(list.OrderByDescending(Function(r) r.RegistrationDate).ToList)
                    End If
                Else
                    loadList()
                End If
            End If
            If txt.Name = "txtLastName" Then
                If txt.TextLength > 0 Or txtFirstName.TextLength > 0 Then
                    If patientList.Where(Function(r) r.FirstName.ToString.ToUpper.Contains(txtFirstName.Text.ToUpper) Or
                                             r.LastName.ToString.ToUpper.Contains(txt.Text.ToUpper)).Any Then
                        list = patientList.Where(Function(r) r.FirstName.ToString.ToUpper.Contains(txtFirstName.Text.ToUpper) AndAlso
                                                    r.LastName.ToString.ToUpper.Contains(txt.Text.ToUpper)).ToList
                        loadPatientsList(list.OrderByDescending(Function(r) r.RegistrationDate).ToList)
                    End If
                Else
                    loadList()
                End If
            End If
        End If
    End Sub

    Private Sub Escape(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(27) Then
            cleanAfterInsert()
        End If
    End Sub
#End Region
End Class