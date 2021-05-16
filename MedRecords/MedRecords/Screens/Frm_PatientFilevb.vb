﻿Imports System.Reflection
Public Class Frm_PatientFilevb
    Dim util As New Util
    'DB OBJECTS
    Dim dbPatient As New PatientEDB
    Dim dbMedicalProblems As New MedicalProblemsDB
    Dim dbAllergy As New AllergyDB
    Dim dbMedications As New MedicationsDB
    Dim dbSurgery As New SurgeryDB
    Dim dbTest As New TestComplementDB
    Dim dbPregnancy As New PregnacyDB
    Dim dbVisits As New VisitDB
    Dim dbServices As New ServiceDB

    Dim patient As New PatientE

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub New(patient As PatientE)

        ' This call is required by the designer.
        InitializeComponent()
        Me.patient = patient
        patientBasicInfo()
    End Sub
    Private Sub Frm_PatientFilevb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadMedicalProblems()
        loadAllergies()
        loadMedications()
        loadSurgeries()
        loadTest()
        loadPregnancies()
        loadVisitHistory()
    End Sub
    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        Dim frm As New Frm_Visit(patient.Id)
        frm.ShowDialog()
    End Sub

#Region "CargandoHistoria"
    Sub patientBasicInfo()
        Try
            Dim properties As List(Of PropertyInfo) = patient.GetType().GetProperties().ToList
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    txt.Text = properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).First.GetValue(patient).ToString.ToUpper
                End If
            Next
            lblParish.Text = patient.Parish
            lblSex.Text = patient.Sex
            dtpDOB.Value = patient.DatOB
            If patient.PaperRecord Then
                chkPaperRecord.Checked = True
                chkPaperRecord.BackColor = Color.DarkGreen
            End If
            lblAge.Text = util.CalculateAge(Today, patient.DatOB)
            lblId.Text = patient.Id
            lblRegistrationDate.Text = patient.RegistrationDate.ToString("dd-MMM-yyyy  (hh:mm)")
            Dim oustanding As Decimal = dbVisits.GetPatientOutstanding(patient.Id)
            lblOustandingBill.Text = oustanding.ToString("C2")
            lblOustandingBill.ForeColor = If(CDec(oustanding) > 0, Color.Yellow, Color.Gainsboro)
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    '########### MEDICAL PROBLEMS ###############
    Sub loadMedicalProblems()
        Try
            dgvMedicalProblems.Columns.Clear()
            dgvMedicalProblems.DataSource = dbMedicalProblems.GetIlnessList(patient.Id).
                                                OrderByDescending(Function(r) r.ProblemDate).ToList
            util.paintDGVRows(dgvMedicalProblems, Color.Beige, Color.Bisque)
            util.addBottomColumns(dgvMedicalProblems, "DetailsCol", "Details")
            util.addBottomColumns(dgvMedicalProblems, "DeleteCol", "Delete")
            Dim indexList As New List(Of Integer)(New Integer() {0, 1, 6, 7, 8})
            util.hideDGVColumns(dgvMedicalProblems, indexList)
            dgvMedicalProblems.Columns(2).HeaderText = "Medical Problem"
            dgvMedicalProblems.Columns(3).HeaderText = "Date"
            dgvMedicalProblems.Columns("DetailsCol").Width = 60
            dgvMedicalProblems.Columns("DeleteCol").Width = 60
            addContextMenu(dgvMedicalProblems, "New Medical Problem")
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    '########### Allergiews ###############
    Sub loadAllergies()
        Try
            dgvAllergies.Columns.Clear()
            dgvAllergies.DataSource = dbAllergy.GetallergiesList(patient.Id).
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

    '########### MEDICATIONS ###############
    Sub loadMedications()
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
            Dim indexList As New List(Of Integer)(New Integer() {0, 1, 2, 7, 8, 9, 10})
            util.hideDGVColumns(dgvMedications, indexList)
            'dgvMedications.Columns(2).HeaderText = "Allergen"
            dgvMedications.Columns("DetailsColMedi").Width = 60
            dgvMedications.Columns("DeleteColMedi").Width = 60
            addContextMenu(dgvMedications, "New Medication")
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    '########### SURGERY ###############
    Sub loadSurgeries()
        Try
            dgvSurgeries.Columns.Clear()
            dgvSurgeries.DataSource = dbSurgery.GetSurgeryList(patient.Id).
                                                OrderByDescending(Function(r) r.SurgeryDate).ToList
            dgvSurgeries.RowsDefaultCellStyle.BackColor = Color.Beige
            For Each row As DataGridViewRow In dgvSurgeries.Rows.Cast(Of DataGridViewRow).
                        Where(Function(r) r.Cells("DoneByMe").Value = True).ToList
                row.DefaultCellStyle.BackColor = Color.Salmon
            Next
            util.addBottomColumns(dgvSurgeries, "DetailsColSurg", "Details")
            util.addBottomColumns(dgvSurgeries, "DeleteColSurg", "Delete")
            Dim indexList As New List(Of Integer)(New Integer() {0, 1, 6, 7, 8, 9})
            util.hideDGVColumns(dgvSurgeries, indexList)
            dgvSurgeries.Columns("SurgeryDate").HeaderText = "Date"
            dgvSurgeries.Columns("DetailsColSurg").Width = 60
            dgvSurgeries.Columns("DeleteColSurg").Width = 60
            addContextMenu(dgvSurgeries, "New Surgery")
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    '########### Test complementarios ###############
    Sub loadTest()
        Try
            dgvTests.Columns.Clear()
            dgvTests.DataSource = dbTest.GetTestList(patient.Id).
                                                OrderByDescending(Function(r) r.TestDate).ToList
            dgvTests.RowsDefaultCellStyle.BackColor = Color.Beige
            util.addBottomColumns(dgvTests, "DetailsColTest", "Details")
            util.addBottomColumns(dgvTests, "FileColTest", "File")
            util.addBottomColumns(dgvTests, "DeleteColTest", "Delete")
            Dim indexList As New List(Of Integer)(New Integer() {0, 1, 2, 7, 8, 9, 10})
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

    '########### PREGNANCIES ###############
    Sub loadPregnancies()
        Try
            dgvPregnancies.Columns.Clear()
            dgvPregnancies.DataSource = dbPregnancy.GetPregnancyList(patient.Id).
                                                OrderByDescending(Function(r) r.PregnancyDate).ToList
            dgvPregnancies.RowsDefaultCellStyle.BackColor = Color.Beige
            util.addBottomColumns(dgvPregnancies, "DetailsColPreg", "Details")
            util.addBottomColumns(dgvPregnancies, "DeleteColPreg", "Delete")
            Dim indexList As New List(Of Integer)(New Integer() {0, 1, 6, 7})
            util.hideDGVColumns(dgvPregnancies, indexList)
            dgvPregnancies.Columns("PregnancyDate").HeaderText = "Date"
            dgvPregnancies.Columns("DetailsColPreg").Width = 60
            dgvPregnancies.Columns("DeleteColPreg").Width = 60
            addContextMenu(dgvPregnancies, "New Pregnancy")
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub loadVisitHistory()
        Try
            dgvVisitsHistory.Columns.Clear()
            dgvVisitsHistory.DataSource = dbVisits.GetPatientVisitList(patient.Id).
                                                OrderByDescending(Function(r) r.VisitDate).ToList
            lblAmountOfVisits.Text = dgvVisitsHistory.Rows.Count
            util.paintDGVRows(dgvVisitsHistory, Color.Beige, Color.Bisque)
            util.addBottomColumns(dgvVisitsHistory, "DetailsColHist", "Details")
            util.insertTextColumn(dgvVisitsHistory, "ServicesCol", "Services", 4)
            Dim indexList As New List(Of Integer)(New Integer() {0, 1, 2, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14})
            util.hideDGVColumns(dgvVisitsHistory, indexList)
            dgvVisitsHistory.Columns(3).HeaderText = "Visit Time"
            dgvVisitsHistory.Columns(3).DefaultCellStyle.Format = "dd-MMM-yyyy  (hh:mm)"
            dgvVisitsHistory.Columns("DetailsColHist").Width = 60
            addContextMenu(dgvMedicalProblems, "New Visit")

        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

#End Region
#Region "Otros Metodos"

#End Region


#Region "Eventos"
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
                loadMedicalProblems()
            Case "New Allergy"
                Dim frm As New Frm_Allergy(patient.Id)
                frm.ShowDialog()
                loadAllergies()
            Case "New Medication"
                Dim frm As New Frm_Medications(patient.Id, 0)
                frm.ShowDialog()
                loadMedications()
            Case "New Surgery"
                Dim frm As New FrmSurgery(patient.Id)
                frm.ShowDialog()
                loadSurgeries()
            Case "New Test/Complementary"
                Dim frm As New Frm_Test(patient.Id, 0)
                frm.ShowDialog()
                loadTest()
            Case "New Pregnancy"
                Dim frm As New Frm_Pregnancy(patient.Id)
                frm.ShowDialog()
                loadPregnancies()
            Case "New Pregnancy"
                Dim frm As New Frm_Visit(patient.Id)
                frm.ShowDialog()
                loadVisitHistory()
                getServicesName()
        End Select
    End Sub
    Private Sub DgvCellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvMedicalProblems.CellPainting, dgvAllergies.CellPainting,
             dgvMedications.CellPainting, dgvSurgeries.CellPainting, dgvTests.CellPainting, dgvPregnancies.CellPainting,
             dgvVisitsHistory.CellPainting
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
                    senderGrid.Columns(e.ColumnIndex).Name = "DetailsColTest" Or senderGrid.Columns(e.ColumnIndex).Name = "DetailsColPreg" Or
                    senderGrid.Columns(e.ColumnIndex).Name = "DetailsColHist" Then
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

    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicalProblems.CellContentClick, dgvAllergies.CellContentClick,
            dgvMedications.CellContentClick, dgvSurgeries.CellContentClick, dgvTests.CellContentClick, dgvPregnancies.CellContentClick,
            dgvVisitsHistory.CellContentClick
        Try
            If e.RowIndex < 0 Or e.ColumnIndex < 0 Then
                Exit Sub
            End If
            Dim senderGrid = DirectCast(sender, DataGridView)
            Dim rowId As Integer = CInt(senderGrid.Rows(e.RowIndex).Cells("Id").Value)
            'buttom Form
            'medical problems
            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If senderGrid.Columns(e.ColumnIndex).Name = "DeleteCol" Then
                    If util.yesOrNot("Do you want to delete the selected Medical Problem/Ilness", "Delete Medical Problem") Then
                        dbMedicalProblems.DeleteIlness(rowId)
                        util.InformationMessage("Medical Problem/Ilness successfully deleted", "Medical Problem/Ilness Deleted")
                        loadMedicalProblems()
                    End If
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "DetailsCol" Then
                    Dim frm As New Frm_MedicalProblems(rowId, True)
                    frm.ShowDialog()
                    loadMedicalProblems()
                End If
            End If
            'ALLERGIES
            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If senderGrid.Columns(e.ColumnIndex).Name = "DeleteColAllergy" Then
                    If util.yesOrNot("Do you want to delete the selected Allergy", "Delete Allergy") Then
                        dbAllergy.DeleteIAllergy(rowId)
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
                        loadMedications()
                    End If
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "DetailsColMedi" Then
                    Dim frm As New Frm_Medications(rowId, True)
                    frm.ShowDialog()
                    loadMedications()
                End If
            End If
            'SURGERY
            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If senderGrid.Columns(e.ColumnIndex).Name = "DeleteColSurg" Then
                    If util.yesOrNot("Do you want to delete the selected Surgery", "Delete Surgery") Then
                        dbSurgery.DeleteSurgery(rowId)
                        util.InformationMessage("Surgery successfully deleted", "Surgery Deleted")
                        loadSurgeries()
                    End If
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "DetailsColSurg" Then
                    Dim frm As New FrmSurgery(rowId, True)
                    frm.ShowDialog()
                    loadSurgeries()
                End If
            End If
            'Test 
            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If senderGrid.Columns(e.ColumnIndex).Name = "DeleteColTest" Then
                    If util.yesOrNot("Do you want to delete the selected Test", "Delete Test") Then
                        dbTest.DeleteTest(rowId)
                        util.InformationMessage("Test successfully deleted", "Test Deleted")
                        loadTest()
                    End If
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "DetailsColTest" Then
                    Dim frm As New Frm_Test(rowId, True)
                    frm.ShowDialog()
                    loadTest()
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "FileColTest" Then
                    Dim frm As New Frm_FileViewer(rowId)
                    frm.Show()
                End If
            End If
            'PREGNANCY
            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If senderGrid.Columns(e.ColumnIndex).Name = "DeleteColPreg" Then
                    If util.yesOrNot("Do you want to delete the selected Pregnancy", "Delete Pregnancy") Then
                        dbPregnancy.DeletePregnancy(rowId)
                        util.InformationMessage("Pregnancy successfully deleted", "Pregnancy Deleted")
                        loadPregnancies()
                    End If
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "DetailsColPreg" Then
                    Dim frm As New Frm_Pregnancy(rowId, True)
                    frm.ShowDialog()
                    loadPregnancies()
                End If
            End If
            'Visit History
            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If senderGrid.Columns(e.ColumnIndex).Name = "DetailsColHist" Then
                    Dim patientId As Integer = CInt(senderGrid.Rows(e.RowIndex).Cells("PatientId").Value)
                    Dim frm As New Frm_Visit(rowId, patientId)
                    frm.ShowDialog()
                    loadVisitHistory()
                    getServicesName()
                End If
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            If TabControl1.SelectedIndex = 3 Then
                getServicesName()
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub getServicesName()
        Try
            'getting services names
            Dim serviceList As New List(Of Service)
            serviceList = dbServices.GetSeriveList
            For Each row As DataGridViewRow In dgvVisitsHistory.Rows
                Dim idList As New List(Of String)
                If Not IsNothing(row.Cells("ServicesId").Value) Then
                    idList = row.Cells("ServicesId").Value.ToString.Split(",").ToList
                    For Each id As Integer In idList
                        row.Cells("ServicesCol").Value &= serviceList.Where(Function(r) r.Id = id).Select(Function(q) q.Name).First
                        If idList.IndexOf(id) < idList.Count - 1 Then
                            row.Cells("ServicesCol").Value &= " / "
                        End If
                    Next
                End If
                If CDec(row.Cells("Oustanding").Value) > 0 Then
                    row.DefaultCellStyle.ForeColor = Color.Red
                ElseIf CDec(row.Cells("Oustanding").Value) < 0 Then
                    row.DefaultCellStyle.ForeColor = Color.Blue
                Else
                    row.DefaultCellStyle.ForeColor = Color.Black
                End If
            Next
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

#End Region

    Private Sub _SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then
            Exit Sub
        End If
        manualSizes()
    End Sub
    Private Sub _SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        manualSizes()

    End Sub

    Sub manualSizes()
        gbLeft1.Size = New Size(Me.Size.Width * 0.69, TabControl1.Size.Height * 0.5)
        dgvMedicalProblems.Size = New Size(gbLeft1.Size.Width - 10, gbLeft1.Height - 30)
        gbRight1.Location = New Point(gbLeft1.Location.X + gbLeft1.Size.Width + 5, gbRight1.Location.Y)
        gbRight1.Size = New Size(Me.Size.Width * 0.28, TabControl1.Size.Height * 0.5)
        dgvAllergies.Size = New Size(gbRight1.Size.Width - 10, gbRight1.Height - 30)

        gbLeft2.Location = New Point(gbLeft1.Location.X, gbLeft1.Location.Y + gbLeft1.Size.Height + 5)
        gbLeft2.Size = New Size(Me.Size.Width * 0.4855, TabControl1.Size.Height * 0.42)
        dgvSurgeries.Size = New Size(gbLeft2.Size.Width - 10, gbLeft2.Size.Height - 30)
        GbRight2.Location = New Point(gbLeft2.Location.X + gbLeft2.Size.Width + 5, gbLeft2.Location.Y)
        GbRight2.Size = New Size(Me.Size.Width * 0.4855, TabControl1.Size.Height * 0.42)
        dgvMedications.Size = New Size(GbRight2.Size.Width - 10, GbRight2.Size.Height - 30)

        gbtest.Size = New Size(Me.Size.Width * 0.49, TabControl1.Size.Height - 45)
        dgvTests.Size = New Size(gbtest.Size.Width - 10, gbtest.Size.Height - 30)

        gbpregnancy.Size = New Size(dgvTests.Size.Width / 2, gbpregnancy.Size.Height)
        gbAnticoncept.Size = New Size(dgvTests.Size.Width / 2, gbAnticoncept.Size.Height)

        gbpregnancy.Location = New Point(gbtest.Location.X + gbtest.Size.Width + 1, gbtest.Location.Y)
        gbAnticoncept.Location = New Point(gbpregnancy.Location.X + gbpregnancy.Size.Width + 1, gbpregnancy.Location.Y)

        dgvPregnancies.Size = New Size(gbpregnancy.Size.Width - 10, gbpregnancy.Size.Height - 30)
        dgvContraceptive.Size = New Size(gbAnticoncept.Size.Width - 10, gbAnticoncept.Size.Height - 30)


        gbgynecol.Location = New Point(gbtest.Location.X + gbtest.Size.Width + 1, gbgynecol.Location.Y)
        gbgynecol.Size = New Size(Me.Size.Width * 0.49, gbtest.Size.Height - gbpregnancy.Size.Height - 5)
    End Sub
End Class