Imports System.Runtime.InteropServices
Imports System.Text

Public Class Frm_Visit
    Dim util As New Util
    Dim patientId As Integer
    Dim visitId As Integer = 0
    Dim appoitmentId As Integer = 0
    Dim outstanding As Decimal = 0
    Dim savedVisit As Boolean = False
    Dim visitNumber As Integer = 0
    Dim patient As New PatientE
    Dim visit As New VisitE
    Dim visitList As New List(Of VisitE)

    'database objects
    Dim dbService As New ServiceDB
    Dim dbPatient As New PatientEDB
    Dim dbAllergies As New AllergyDB
    Dim dbMedications As New MedicationsDB
    Dim dbTest As New TestComplementDB
    Dim dbVisit As New VisitDB
    Dim dbAppoitment As New AppointmentDB

    Sub New(visitId As Integer, patientId As Integer)

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
    Sub New(patientId As Integer, appoitmentId As Integer, app As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.patientId = patientId
        Me.appoitmentId = appoitmentId
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
            'leyendo lalista de visitas del[aciente
            visitList = dbVisit.GetPatientVisitList(patientId)
            visitNumber = visitList.Count
            lblTotalVisits.Text = visitNumber
            'leyendo outstandings
            outstanding = dbVisit.GetPatientOutstanding(patientId)
            lblOustanding.Text = outstanding.ToString("C2")
            loadAll()
        Else
            loadVisit(dbVisit.GetVisitById(visitId))
            gbVisits.Visible = False
            EnableChanges(False)
            savedVisit = True
            ibtnEditVisit.Visible = True
            ibtnSave.Visible = False
        End If
        chkPaperRecord.Checked = patient.PaperRecord

    End Sub
    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        updatedVisit()

    End Sub
    Private Sub IconButton2_Click(sender As Object, e As EventArgs) Handles ibtnFoward.Click
        If visitNumber > 1 Then
            visitNumber -= 1
            loadVisit(visitList(visitNumber - 1))
            lblCurrentVisit.Text = visitNumber
            EnableChanges(False)
            If visitNumber = visitList.Count Then
                EnableChanges(True)
            End If
        End If
    End Sub

    Private Sub IconButton3_Click(sender As Object, e As EventArgs) Handles ibtnBack.Click
        If visitNumber < visitList.Count Then
            visitNumber += 1
            loadVisit(visitList(visitNumber - 1))
            lblCurrentVisit.Text = visitNumber
            EnableChanges(False)
            If visitNumber = visitList.Count Then
                EnableChanges(True)
            End If
        End If
    End Sub
    Private Sub ibtnEditVisit_Click(sender As Object, e As EventArgs) Handles ibtnEditVisit.Click
        Try
            If util.yesOrNot("Do you want to change a past Visit?", "Change past Visit") Then
                EnableChanges(True)
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        Dim frm As New Frm_PatientFilevb(patient)
        frm.ShowDialog()
    End Sub




#Region "Metodos argando Datos del paciente"
    Sub EnableChanges(change As Boolean)
        Try
            ibtnSave.Visible = change
            dtpDateVisit.Enabled = change
            For Each txt As TextBox In util.FindAllTextBoxIterative(Me)
                txt.Enabled = change
            Next
            For Each Rtxt As RichTextBox In util.FindAllTextRichBoxIterative(Me)
                Rtxt.Enabled = change
            Next
            If change = False Then
                gbVisits.BackColor = Color.FromArgb(210, 44, 44)
                ibtnBack.BackColor = Color.FromArgb(210, 44, 44)
                ibtnFoward.BackColor = Color.FromArgb(210, 44, 44)
            Else
                ibtnBack.BackColor = Color.FromArgb(28, 33, 53)
                ibtnFoward.BackColor = Color.FromArgb(28, 33, 53)
                gbVisits.BackColor = Color.FromArgb(28, 33, 53)
                lblOustanding.Text = outstanding.ToString("C2")
            End If
            dgvservices.Enabled = change
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub loadAll()
        Try
            loadPatientInfo()
            loadServices()
            loadAllergies()
            LoadTest()
            LoadMedications()
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub loadVisit(visit As VisitE)
        Try
            visitId = visit.Id
            loadAll()
            dtpDateVisit.Value = visit.VisitDate
            txtRespiratoryRate.Text = If(visit.RespiratoryRate > 0, visit.RespiratoryRate, String.Empty)
            txtHeartRate.Text = If(visit.HeartRate > 0, visit.HeartRate, String.Empty)
            txtPressure1.Text = If(visit.BloodPAlta > 0, visit.BloodPAlta, String.Empty)
            txtPressure2.Text = If(visit.BloodPBaja > 0, visit.BloodPBaja, String.Empty)
            txtSpo2.Text = If(visit.SpO2 > 0, visit.SpO2, String.Empty)
            txtTemperature.Text = If(visit.Temperature > 0, visit.Temperature, String.Empty)
            txtComplain.Text = visit.PatientComplain
            txtPhysicalExam.Text = visit.PhysicalExam
            txtDiagnosis.Text = visit.Diagnosis
            txtPlan.Text = visit.Plan
            lblTotalServices.Text = visit.ServiceTotal.ToString("C2")
            txtOtherServices.Text = visit.otherServices
            txtOSCgarges.Text = visit.OSCharges.ToString("C2")
            txtDisscount.Text = visit.Disscount.ToString("C2")
            txtPaid.Text = visit.Paid.ToString("C2")
            lblOustanding.Text = visit.Oustanding.ToString("C2")
            lblToPay.Text = visit.ToPay.ToString("C2")
            If Not IsNothing(visit.ServicesId) Then
                For Each row As DataGridViewRow In dgvservices.Rows
                    If visit.ServicesId.Split(",").ToList.Contains(row.Cells("Id").Value) Then
                        row.Cells("Select").Value = True
                        row.DefaultCellStyle.BackColor = Color.Salmon
                    End If
                Next

            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
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
            addContextMenu(dgvservices, "Reset")
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
            For Each row As DataGridViewRow In dgvMedications.Rows.Cast(Of DataGridViewRow).
                        Where(Function(r) r.Cells("VisitId").Value = visitId).ToList
                row.DefaultCellStyle.ForeColor = Color.Blue
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
            For Each row As DataGridViewRow In dgvTests.Rows.Cast(Of DataGridViewRow).
                        Where(Function(r) r.Cells("VisitId").Value = visitId).ToList
                row.DefaultCellStyle.ForeColor = Color.Blue
            Next
            addContextMenu(dgvTests, "New Test/Complementary")
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub updatedVisit()
        Try
            Dim oustanding As Decimal = CDec(lblOustanding.Text)
            If CDec(txtOSCgarges.Text) > 0 AndAlso txtOtherServices.TextLength = 0 Then
                util.InformationMessage("Please enter the other services for wich you are charging $" & CDec(txtOSCgarges.Text), "Other services")
                Exit Sub
            End If
            If oustanding > 0 Then
                If Not util.yesOrNot("The Patient have an outstanding amount of: $" & oustanding & " Do you want to save the visit anyway?", "Outstanding") Then
                    Exit Sub
                End If
            End If
            If CDec(lblTotalServices.Text) = 0 Then
                If Not util.yesOrNot("You have no services selected. Do you want to save the visit anyway?", "No Services") Then
                    Exit Sub
                End If
            End If
            If CDec(txtPaid.Text) = 0 Then
                If Not util.yesOrNot("You have no paid amount. Do you want to save the visit anyway?", "No Paid") Then
                    Exit Sub
                End If
            End If
            visit = New VisitE
            visit.Id = visitId
            visit.ServicesId = String.Join(",", getServicesId)
            visit.VisitDate = dtpDateVisit.Value
            visit.RespiratoryRate = If(txtRespiratoryRate.TextLength > 0, txtRespiratoryRate.Text, 0)
            visit.HeartRate = If(txtHeartRate.TextLength > 0, txtHeartRate.Text, 0)
            visit.BloodPAlta = If(txtPressure1.TextLength > 0, txtPressure1.Text, 0)
            visit.BloodPBaja = If(txtPressure2.TextLength > 0, txtPressure2.Text, 0)
            visit.SpO2 = If(txtSpo2.TextLength > 0, txtSpo2.Text, 0)
            visit.Temperature = If(txtTemperature.TextLength > 0, txtTemperature.Text, 0.00)
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
            visit.Oustanding = CDec(lblOustanding.Text) - outstanding
            dbVisit.updateVisit(visit)
            savedVisit = True
            dbAppoitment.updateAppoitmentVisitId(appoitmentId, visitId)
            util.InformationMessage("The visit was Sucessfully Saved", "Visit Saved")

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
            Case "Reset"
                ResetServices()
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
                If senderGrid.Columns(e.ColumnIndex).Name = "FileColTest" Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                    Dim w = My.Resources.pdf.Width
                    Dim h = My.Resources.pdf.Height
                    Dim x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2
                    Dim y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2
                    e.Graphics.DrawImage(My.Resources.pdf, New Rectangle(x, y, w, h))
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
                    If dbTest.getTestDocument(rowId).Length > 0 Then
                        Dim frm As New Frm_FileViewer(rowId)
                        frm.Show()
                    Else
                        util.InformationMessage("No file was attached to this test", "No File")
                    End If
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
            Dim rowId As Integer = e.RowIndex
            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn Then
                If senderGrid.Columns(e.ColumnIndex).Name = "Select" Then
                    senderGrid.Update()
                    senderGrid.Refresh()
                    senderGrid.Rows(rowId).Cells("Select").Value = Not senderGrid.Rows(rowId).Cells("Select").Value
                    getFeesCalculations()
                End If
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Private Sub txtOSCgarges_KeyUp(sender As Object, e As KeyEventArgs) Handles txtOSCgarges.KeyUp, txtDisscount.KeyUp
        Try
            getFeesCalculations()
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Private Sub txtOSCgarges_MouseEnter(sender As Object, e As EventArgs) Handles txtOSCgarges.MouseEnter, txtDisscount.MouseEnter, txtPaid.MouseEnter
        Try
            Dim txt As TextBox = CType(sender, TextBox)
            If txt.Text = "0.00" Or txt.Text = "$0.00" Then
                txt.Clear()
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Private Sub txtOSCgarges_MouseLeave(sender As Object, e As EventArgs) Handles txtOSCgarges.MouseLeave, txtDisscount.MouseLeave, txtPaid.MouseLeave
        Try
            Dim txt As TextBox = CType(sender, TextBox)
            If txt.TextLength = 0 Then
                txt.Text = "0.00"
            Else
                txt.Text = CDec(txt.Text).ToString("N2")
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Private Sub txtPaid_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPaid.KeyUp
        Try
            getFeesCalculations()
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub getFeesCalculations()
        Try
            Dim serviceTotal As Decimal = dgvservices.Rows.Cast(Of DataGridViewRow).
                       Where(Function(r) r.Cells("Select").Value = True).
                       Sum(Function(q) CDec(q.Cells("Cost").Value))
            lblTotalServices.Text = serviceTotal.ToString("C2")
            Dim osCharges As Decimal = If(txtOSCgarges.TextLength = 0, 0.00, CDec(txtOSCgarges.Text))
            Dim toDisscount As Decimal = If(txtDisscount.TextLength = 0, 0.00, CDec(txtDisscount.Text))
            Dim toPaid As Decimal = serviceTotal + (osCharges - toDisscount)
            lblToPay.Text = toPaid.ToString("C2")
            Dim paid As Decimal = If(txtPaid.TextLength = 0, 0.00, CDec(txtPaid.Text))
            Dim outanding As Decimal = CDec(lblToPay.Text) - paid + outstanding
            lblOustanding.Text = outanding.ToString("C2")
            lblOustanding.ForeColor = If(outanding > 0, Color.Red, Color.Yellow)
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub ResetServices()
        Try
            For Each row As DataGridViewRow In dgvservices.Rows
                row.Cells("Select").Value = False
            Next
            dgvservices.Update()
            getFeesCalculations()
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Private Sub Frm_Visit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Not savedVisit Then
                If util.yesOrNot("This visit have not been saved and will be deleted if you close this screen. Do you want To continue?", "Delete Visit") Then
                    dbVisit.DeleteVisit(visitId)
                    dbMedications.DeleteMedicationByVisitId(visitId)
                    dbTest.DeleteTestByVisitId(visitId)
                Else
                    'loadVisit(visitList(visitList.Count - 1))
                    'EnableChanges(True)
                    'lblCurrentVisit.Text = visitList.Count
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub




#End Region

#Region "Voice Notes"
    Dim FLocation As String
    Dim hh, mm, ss As Integer
    <DllImport("winmm.dll")>
    Private Shared Function mciSendString(ByVal command As String, ByVal buffer As StringBuilder, ByVal bufferSize As Integer, ByVal hwndCallback As IntPtr) As Integer
    End Function

    Private Sub IconButton3_Click_1(sender As Object, e As EventArgs) Handles ibtnStop.Click
        Dim fl As New FolderBrowserDialog

        Timer1.Stop()
        ibtnStop.Enabled = False
        ibtnStart.Enabled = True
        'ProgressBar1.Visible = False

        Try
            fl.ShowDialog()
            FLocation = fl.SelectedPath & "\v1.wav"
            mciSendString("save capture " & FLocation, Nothing, 0, 0)
            mciSendString("close capture", Nothing, 0, 0)
            MsgBox("Your voice has been recorded and storend at " & fl.SelectedPath & "\v1.wav", MsgBoxStyle.Information, "Voice Recorder")

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub IconButton2_Click_1(sender As Object, e As EventArgs) Handles ibtnStart.Click
        Try
            Dim i As Integer
            i = mciSendString("open new type waveaudio alias capture", Nothing, 0, 0)
            Console.WriteLine(i)
            i = mciSendString("record capture", Nothing, 0, 0)
            Console.WriteLine(i)


            lblDuration.Text = "00:00:00"
            Timer1.Start()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim shh, smm, sss As String
        ss += 1
        If ss = 59 Then
            ss = 0 : mm += 1
            If mm >= 59 Then
                mm = 0 : hh += 1
            End If
        End If
        If hh < 10 Then shh = "0" & hh Else shh = hh
        If mm < 10 Then smm = "0" & mm Else smm = mm
        If ss < 10 Then sss = "0" & ss Else sss = ss
        lblDuration.Text = shh & ":" & smm & ":" & sss
    End Sub
#End Region
End Class