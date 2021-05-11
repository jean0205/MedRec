Public Class Frm_Visit
    Dim util As New Util
    Dim patientId As Integer

    Dim patient As PatientE

    'database objects
    Dim dbService As New ServiceDB
    Dim dbPatient As New PatientEDB
    Dim dbAllergies As New AllergyDB
    Dim dbMedications As New MedicalProblemsDB
    Dim dbTest As New TestComplementDB


    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub New(patientId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.patientId = patientId
        Me.patient = dbPatient.GetPatientById(patientId)
    End Sub
    Private Sub Frm_Visit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler txtSpo2.KeyPress, AddressOf util.txtOnlyIntegersNumber_KeyPress

        loadPatientInfo()
        loadServices()
    End Sub




#Region "Metodos"
    Sub loadPatientInfo()
        Try
            lblFirstName.Text = patient.FirstName
            lblLastName.Text = patient.LastName
            dtpDOB.Value = patient.DatOB
            lblAge.Text = util.CalculateAge(Today, patient.DatOB)
            lblSex.Text = patient.Sex
            ' chkPaperRecord.Checked = patient.PaperRecord

        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub loadServices()
        Try
            dgvservices.Columns.Clear()
            dgvservices.DataSource = dbService.GetSeriveList
            util.paintDGVRows(dgvservices, Color.Beige, Color.Bisque)
            util.addCheckBoxColumns(dgvservices, "Select", "Select")
            Dim indexList As New List(Of Integer)(New Integer() {0, 2})
            util.hideDGVColumns(dgvservices, indexList)
            dgvservices.Columns("Select").Width = 60
            dgvservices.Columns("Cost").DefaultCellStyle.Format = "C2"
            dgvservices.Columns(1).ReadOnly = True
            dgvservices.Columns(3).ReadOnly = True
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub loadAllergies()

    End Sub
    Sub LoadMedications()

    End Sub
    Sub LoadTest()

    End Sub

    Private Sub lblFirstName_Click(sender As Object, e As EventArgs) Handles lblFirstName.Click

    End Sub

#End Region
End Class