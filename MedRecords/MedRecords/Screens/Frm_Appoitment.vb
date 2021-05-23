Public Class Frm_Appoitment
    Dim dbAppoitment As New AppointmentDB
    Dim dbPatient As New PatientEDB
    Dim util As New Util
    Dim apptId As Integer
    Dim patientId As Integer
    Dim visitId As Integer
    Dim updating As Boolean = False
    Dim appt As New Appoitmets
    Dim patient As New PatientE


    'crear un appoitment para un paciente
    Sub New(patientId As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        Try
            Me.patientId = patientId
            Me.visitId = 0
            Me.updating = False
            patient = dbPatient.GetPatientById(patientId)
            lblPatientName.Text = patient.FirstName & " " & patient.LastName
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    'actualizar un appoitment
    Sub New(ApptId As Integer, updating As Boolean)
        InitializeComponent()
        Try
            Me.apptId = ApptId
            Me.updating = updating
            Me.visitId = 0
            appt = dbAppoitment.GetAppoitmentsByiD(ApptId)
            patient = dbPatient.GetPatientById(appt.Patientid)
            lblPatientName.Text = patient.FirstName & " " & patient.LastName
            dtpDate.Value = appt.AppoitmentTime
            txtComments.Text = appt.Comments
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Private Sub Frm_Appoitment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If updating Then
            loadappoitment()
        End If
        getAppoitmentByDate()
    End Sub
    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        saveUpdateAppoitment()
    End Sub

    Sub loadappoitment()
        Try

        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub saveUpdateAppoitment()
        Try
            Dim newAppoitment As New Appoitmets
            newAppoitment.id = apptId
            newAppoitment.Patientid = patientId
            newAppoitment.AppoitmentTime = dtpDate.Value
            newAppoitment.Comments = txtComments.Text.ToUpper
            If updating Then
                dbAppoitment.updateAppoitmentTimeandComments(newAppoitment)
                util.InformationMessage("Appoitment successfully updated", "Appoitment")
            Else
                dbAppoitment.insertAppoitment(newAppoitment)
                updating = False
                util.InformationMessage("Appoitment successfully saved", "Appoitment")
            End If
            Me.Close()
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub getAppoitmentByDate()
        Try
            dgv1.Rows.Clear()
            util.paintDGVRows(dgv1, Color.Beige, Color.Bisque)
            Dim appoitmentList = New List(Of Appoitmets)
            appoitmentList = dbAppoitment.GetAppoitmentsByDate(dtpDate.Value.Date)
            For Each app As Appoitmets In appoitmentList.OrderBy(Function(r) r.AppoitmentTime)
                dgv1.Rows.Add()
                dgv1.Rows(dgv1.Rows.Count - 1).Cells("PatientCol").Value = app.PatientName
                dgv1.Rows(dgv1.Rows.Count - 1).Cells("TimeCol").Value = app.AppoitmentTime.ToString("hh:mm tt")
                If app.AppoitmentTime.Hour = dtpDate.Value.Hour Then
                    dgv1.Rows(dgv1.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next
            dgv1.CurrentCell = Nothing

        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        getAppoitmentByDate()
    End Sub
End Class