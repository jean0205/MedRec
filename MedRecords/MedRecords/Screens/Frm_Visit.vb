Public Class Frm_Visit
    Dim util As New Util
    Dim patientId As Integer

    Dim patient As PatientE

    'database objects
    Dim dbService As New ServiceDB
    Dim dbPatient As New PatientEDB
    Dim dbAllergies As New AllergyDB
    Dim dbMedications As New MedicationsDB
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
        loadAllergies()
        LoadTest()
        LoadMedications()
    End Sub




#Region "Metodos argando Datos del paciente"
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
        Try
            dgvAllergies.Columns.Clear()
            dgvAllergies.DataSource = dbAllergies.GetallergiesList(patient.Id).
                                                OrderByDescending(Function(r) r.NatureOfReaction).ToList
            dgvAllergies.RowsDefaultCellStyle.BackColor = Color.Beige
            For Each row As DataGridViewRow In dgvAllergies.Rows.Cast(Of DataGridViewRow).
                        Where(Function(r) r.Cells("NatureOfReaction").Value = "MODERATE").ToList
                row.DefaultCellStyle.BackColor = Color.Bisque
            Next
            For Each row As DataGridViewRow In dgvAllergies.Rows.Cast(Of DataGridViewRow).
                        Where(Function(r) r.Cells("NatureOfReaction").Value = "SEVERE").ToList
                row.DefaultCellStyle.BackColor = Color.Salmon
            Next
            util.addBottomColumns(dgvAllergies, "DetailsColAllergy", "Details")
            util.addBottomColumns(dgvAllergies, "DeleteColAllergy", "Delete")
            Dim indexList As New List(Of Integer)(New Integer() {0, 1, 4, 5})
            util.hideDGVColumns(dgvAllergies, indexList)
            dgvAllergies.Columns(2).HeaderText = "Allergen"
            dgvAllergies.Columns("DetailsColAllergy").Width = 60
            dgvAllergies.Columns("DeleteColAllergy").Width = 60
            addContextMenu(dgvAllergies, "New Allergy")
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub LoadMedications()
        Try
            dgvMedications.Columns.Clear()
            dgvMedications.DataSource = dbMedications.GetMedicationsList(patient.Id).
                                                OrderByDescending(Function(r) r.id).ToList
            dgvMedications.RowsDefaultCellStyle.BackColor = Color.Beige
            For Each row As DataGridViewRow In dgvMedications.Rows.Cast(Of DataGridViewRow).
                        Where(Function(r) r.Cells("Active").Value = True).ToList
                row.DefaultCellStyle.BackColor = Color.Salmon
            Next
            util.addBottomColumns(dgvMedications, "DetailsColMedi", "Details")
            util.addBottomColumns(dgvMedications, "DeleteColMedi", "Delete")
            Dim indexList As New List(Of Integer)(New Integer() {0, 1, 2, 7, 8, 9})
            util.hideDGVColumns(dgvMedications, indexList)
            'dgvMedications.Columns(2).HeaderText = "Allergen"
            dgvMedications.Columns("DetailsColMedi").Width = 60
            dgvMedications.Columns("DeleteColMedi").Width = 60
            addContextMenu(dgvMedications, "New Medication")
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub LoadTest()
        Try
            dgvTests.Columns.Clear()
            dgvTests.DataSource = dbTest.GetTestList(patient.Id).
                                                OrderByDescending(Function(r) r.TestDate).ToList
            dgvTests.RowsDefaultCellStyle.BackColor = Color.Beige
            util.addBottomColumns(dgvTests, "DetailsColTest", "Details")
            util.addBottomColumns(dgvTests, "FileColTest", "File")
            util.addBottomColumns(dgvTests, "DeleteColTest", "Delete")
            Dim indexList As New List(Of Integer)(New Integer() {0, 1, 2, 7, 8, 9})
            util.hideDGVColumns(dgvTests, indexList)
            dgvTests.Columns("TestDate").HeaderText = "Date"
            dgvTests.Columns("DetailsColTest").Width = 60
            dgvTests.Columns("FileColTest").Width = 60
            dgvTests.Columns("DeleteColTest").Width = 60
            addContextMenu(dgvTests, "New Test/Complementary")
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub lblFirstName_Click(sender As Object, e As EventArgs) Handles lblFirstName.Click

    End Sub

#End Region
#Region "Otros Metodos"
    Sub addContextMenu(dgv As DataGridView, item As String)
        Dim _contextmenu As New ContextMenuStrip
        _contextmenu.Items.Add(item)
        AddHandler _contextmenu.ItemClicked, AddressOf contextmenu_click
        dgv.ContextMenuStrip = _contextmenu
    End Sub
    Private Sub contextmenu_click(ByVal sender As System.Object,
                                 ByVal e As ToolStripItemClickedEventArgs)
        Select Case e.ClickedItem.Text
            Case "New Medical Problem"
                Dim frm As New Frm_MedicalProblems(patient.Id)
                frm.ShowDialog()
               ' loadMedicalProblems()
            Case "New Allergy"
                Dim frm As New Frm_Allergy(patient.Id)
                frm.ShowDialog()
                loadAllergies()
            Case "New Medication"
                Dim frm As New Frm_Medications(patient.Id, 0)
                frm.ShowDialog()
                LoadMedications()
            Case "New Surgery"
                Dim frm As New FrmSurgery(patient.Id)
                frm.ShowDialog()
                'loadSurgeries()
            Case "New Test/Complementary"
                Dim frm As New Frm_Test(patient.Id)
                frm.ShowDialog()
                LoadTest()
            Case "New Pregnancy"
                Dim frm As New Frm_Pregnancy(patient.Id)
                frm.ShowDialog()
                'loadPregnancies()
        End Select
    End Sub
#End Region

#Region "Eventos"
    Private Sub DgvCellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvAllergies.CellPainting,
             dgvMedications.CellPainting, dgvTests.CellPainting
        Try
            Dim senderGrid As DataGridView = CType(sender, DataGridView)
            If e.RowIndex < 0 Then
                Exit Sub
            End If
            If e.ColumnIndex >= 0 Then
                If senderGrid.Columns(e.ColumnIndex).Name = "DeleteCol" Or senderGrid.Columns(e.ColumnIndex).Name = "DeleteColAllergy" Or
                     senderGrid.Columns(e.ColumnIndex).Name = "DeleteColMedi" Or senderGrid.Columns(e.ColumnIndex).Name = "DeleteColSurg" Or
                     senderGrid.Columns(e.ColumnIndex).Name = "DeleteColTest" Or senderGrid.Columns(e.ColumnIndex).Name = "DeleteColPreg" Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                    Dim w = My.Resources.delete.Width
                    Dim h = My.Resources.delete.Height
                    Dim x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2
                    Dim y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2
                    e.Graphics.DrawImage(My.Resources.delete, New Rectangle(x, y, w, h))
                    e.Handled = True
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "DetailsCol" Or senderGrid.Columns(e.ColumnIndex).Name = "DetailsColAllergy" Or
                    senderGrid.Columns(e.ColumnIndex).Name = "DetailsColMedi" Or senderGrid.Columns(e.ColumnIndex).Name = "DetailsColSurg" Or
                    senderGrid.Columns(e.ColumnIndex).Name = "DetailsColTest" Or senderGrid.Columns(e.ColumnIndex).Name = "DetailsColPreg" Then
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
#End Region

End Class