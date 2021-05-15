Public Class Frm_Visit
    Dim util As New Util
    Dim patientId As Integer
    Dim visitId As Integer = 0

    Dim patient As New PatientE
    Dim visit As New VisitE

    'database objects
    Dim dbService As New ServiceDB
    Dim dbPatient As New PatientEDB
    Dim dbAllergies As New AllergyDB
    Dim dbMedications As New MedicationsDB
    Dim dbTest As New TestComplementDB
    Dim dbVisit As New VisitDB


    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub New(patientId As Integer, visitId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.visitId = visitId
        Me.patientId = patientId
        Me.patient = dbPatient.GetPatientById(patientId)
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
        AddHandler txtHeartRate.KeyPress, AddressOf util.txtOnlyIntegersNumber_KeyPress
        AddHandler txtPressure1.KeyPress, AddressOf util.txtOnlyIntegersNumber_KeyPress
        AddHandler txtPressure2.KeyPress, AddressOf util.txtOnlyIntegersNumber_KeyPress
        AddHandler txtRespiratoryRate.KeyPress, AddressOf util.txtOnlyIntegersNumber_KeyPress
        AddHandler txtTemperature.KeyPress, AddressOf util.txtOnlyDecimalNumber_KeyPress
        AddHandler txtDisscount.KeyPress, AddressOf util.txtOnlyDecimalNumber_KeyPress
        AddHandler txtOSCgarges.KeyPress, AddressOf util.txtOnlyDecimalNumber_KeyPress
        AddHandler txtPaid.KeyPress, AddressOf util.txtOnlyDecimalNumber_KeyPress

        'Create the visit to get the id
        If visitId = 0 Then
            dbVisit.createVisit(patientId)
            Me.visitId = dbVisit.GetVisitId
        End If
        loadPatientInfo()
        loadServices()
        loadAllergies()
        LoadTest()
        LoadMedications()
    End Sub
    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        updatedVisit()
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
            dgvMedications.DataSource = dbMedications.GetMedicationsListVisitView(patient.Id).
                                                OrderByDescending(Function(r) r.id).ToList
            dgvMedications.RowsDefaultCellStyle.BackColor = Color.Beige
            For Each row As DataGridViewRow In dgvMedications.Rows.Cast(Of DataGridViewRow).
                        Where(Function(r) r.Cells("Active").Value = True).ToList
                row.DefaultCellStyle.BackColor = Color.Salmon
            Next
            util.addBottomColumns(dgvMedications, "DetailsColMedi", "Details")
            util.addBottomColumns(dgvMedications, "DeleteColMedi", "Delete")
            Dim indexList As New List(Of Integer)(New Integer() {0, 1, 2, 8, 9, 10})
            util.hideDGVColumns(dgvMedications, indexList)
            'dgvMedications.Columns(2).HeaderText = "Allergen"
            dgvMedications.Columns("DetailsColMedi").Width = 60
            dgvMedications.Columns("DeleteColMedi").Width = 60
            For Each row As DataGridViewRow In dgvMedications.Rows
                If CDate(row.Cells("VisitDate").Value) <> Date.MinValue Then
                    row.Cells("VisitDate").Style.Format = "dd-MMM-yyyy"
                End If
            Next
            addContextMenu(dgvMedications, "New Medication")
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub LoadTest()
        Try
            dgvTests.Columns.Clear()
            dgvTests.DataSource = dbTest.GetTestListVisitView(patient.Id).
                                                OrderByDescending(Function(r) r.TestDate).ToList
            dgvTests.RowsDefaultCellStyle.BackColor = Color.Beige
            util.addBottomColumns(dgvTests, "DetailsColTest", "Details")
            util.addBottomColumns(dgvTests, "FileColTest", "File")
            util.addBottomColumns(dgvTests, "DeleteColTest", "Delete")
            Dim indexList As New List(Of Integer)(New Integer() {0, 1, 2, 6, 7, 8, 9, 10})
            util.hideDGVColumns(dgvTests, indexList)
            dgvTests.Columns("TestDate").HeaderText = "Date"
            dgvTests.Columns("VisitDate").HeaderText = "Visit"
            dgvTests.Columns("DetailsColTest").Width = 60
            dgvTests.Columns("FileColTest").Width = 60
            dgvTests.Columns("DeleteColTest").Width = 60
            For Each row As DataGridViewRow In dgvTests.Rows
                If CDate(row.Cells("VisitDate").Value) <> Date.MinValue Then
                    row.Cells("VisitDate").Style.Format = "dd-MMM-yyyy"
                End If
            Next
            addContextMenu(dgvTests, "New Test/Complementary")
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub updatedVisit()
        Try
            visit = New VisitE
            visit.Id = visitId
            visit.ServicesId = getServicesId()
            visit.VisitDate = dtpDateVisit.Value
            visit.RespiratoryRate = txtRespiratoryRate.Text
            visit.HeartRate = txtHeartRate.Text
            visit.BloodPAlta = txtPressure1.Text
            visit.BloodPBaja = txtPressure2.Text
            visit.SpO2 = txtSpo2.Text
            visit.Temperature = txtTemperature.Text
            visit.PatientComplain = txtComplain.Text.ToUpper
            visit.PhysicalExam = txtPhysicalExam.Text.ToUpper
            visit.Diagnosis = txtDiagnosis.Text.ToUpper
            visit.Plan = txtPlan.Text.ToUpper
            visit.ServiceTotal = lblTotalServices.Text
            visit.otherServices = txtOtherServices.Text.ToUpper
            visit.OSCharges = txtOSCgarges.Text
            visit.Disscount = txtDisscount.Text
            visit.ToPay = lblToPay.Text
            visit.Paid = txtPaid.Text
            visit.Oustanding = lblOustanding.Text



        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Function getServicesId() As List(Of Integer)
        Dim idList As New List(Of Integer)
        Try
            idList = dgvservices.Rows.Cast(Of DataGridViewRow).Where(Function(q) q.Cells(4).Value = True).Select(Function(r) CInt(r.Cells("Id").Value)).ToList

        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
        Return idList
    End Function

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
            Case "New Allergy"
                Dim frm As New Frm_Allergy(patient.Id)
                frm.ShowDialog()
                loadAllergies()
            Case "New Medication"
                Dim frm As New Frm_Medications(patient.Id, visitId)
                frm.ShowDialog()
                LoadMedications()
            Case "New Test/Complementary"
                Dim frm As New Frm_Test(patient.Id, visitId)
                frm.ShowDialog()
                LoadTest()
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
    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAllergies.CellContentClick,
            dgvMedications.CellContentClick, dgvTests.CellContentClick
        Try
            If e.RowIndex < 0 Or e.ColumnIndex < 0 Then
                Exit Sub
            End If
            Dim senderGrid = DirectCast(sender, DataGridView)
            Dim rowId As Integer = CInt(senderGrid.Rows(e.RowIndex).Cells("Id").Value)
            'buttom Form

            'ALLERGIES
            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If senderGrid.Columns(e.ColumnIndex).Name = "DeleteColAllergy" Then
                    If util.yesOrNot("Do you want to delete the selected Allergy", "Delete Allergy") Then
                        dbAllergies.DeleteIAllergy(rowId)
                        util.InformationMessage("Allergy successfully deleted", "Allergy Deleted")
                        loadAllergies()
                    End If
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "DetailsColAllergy" Then
                    Dim frm As New Frm_Allergy(rowId, True)
                    frm.ShowDialog()
                    loadAllergies()
                End If
            End If
            'MEDICATIONS
            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If senderGrid.Columns(e.ColumnIndex).Name = "DeleteColMedi" Then
                    If util.yesOrNot("Do you want to delete the selected Medication", "Delete Medication") Then
                        dbMedications.DeleteMedication(rowId)
                        util.InformationMessage("Medication successfully deleted", "Medication Deleted")
                        LoadMedications()
                    End If
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "DetailsColMedi" Then
                    Dim frm As New Frm_Medications(rowId, True)
                    frm.ShowDialog()
                    LoadMedications()
                End If
            End If
            'Test 
            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If senderGrid.Columns(e.ColumnIndex).Name = "DeleteColTest" Then
                    If util.yesOrNot("Do you want to delete the selected Test", "Delete Test") Then
                        dbTest.DeleteTest(rowId)
                        util.InformationMessage("Test successfully deleted", "Test Deleted")
                        LoadTest()
                    End If
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "DetailsColTest" Then
                    Dim frm As New Frm_Test(rowId, True)
                    frm.ShowDialog()
                    LoadTest()
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "FileColTest" Then
                    Dim frm As New Frm_FileViewer(rowId)
                    frm.Show()
                End If
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub dgvservices_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvservices.CellContentClick
        Try
            If e.RowIndex < 0 Or e.ColumnIndex < 0 Then
                Exit Sub
            End If
            Dim senderGrid = DirectCast(sender, DataGridView)
            Dim rowId As Integer = CInt(senderGrid.Rows(e.RowIndex).Cells("Id").Value)
            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn Then
                If senderGrid.Columns(e.ColumnIndex).Name = "Select" Then
                    Dim serviceTotal As Decimal = dgvservices.Rows.Cast(Of DataGridViewRow).Where(Function(r) r.Cells("Id").Value = True).Sum(Function(q) CDec(q.Cells("").Value))
                End If
            End If

        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub




#End Region

End Class