Imports System.IO
Imports System.Reflection

Public Class Frm_Main
    Dim util As New Util
    Dim dbMain As New MainDB
    Dim dtPatients As New DataTable
    Dim dbAppoitments As New AppointmentDB
    Dim dbUsers As New UserDB
    Dim appoitmentList As New List(Of Appoitmets)
    Dim userId As Integer = 0
    Dim backupPath As String = String.Empty
    Public Property user As New Users

    Sub New(user As Users)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.userId = user.id
    End Sub

    Private Async Sub Frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'AddHandler txtFirstName.KeyPress, AddressOf util.txtOnlyIntegersNumber_KeyPress
        Await getPatientList()
        loadAppoitmentsByDate()

    End Sub

#Region "Botones"
    Private Sub ibtnPatients_Click(sender As Object, e As EventArgs) Handles ibtnPatients.Click

        Dim frm As New Frm_NewPatient
        frm.ShowDialog()
    End Sub
    Private Sub ibtnVisits_Click(sender As Object, e As EventArgs) Handles ibtnVisits.Click
        If Not checkAccess("Visits") Then
            Exit Sub
        End If
        Dim frm As New Frm_VisitHistory
        frm.Show()
    End Sub

    Private Sub ibtnServices_Click(sender As Object, e As EventArgs) Handles ibtnServices.Click
        If Not checkAccess("Services") Then
            Exit Sub
        End If
        Dim frm As New Frm_Services
        frm.ShowDialog()
    End Sub

    Private Sub ibtnSurgeries_Click(sender As Object, e As EventArgs) Handles ibtnSurgeries.Click
        If Not checkAccess("Surgeries") Then
            Exit Sub
        End If
        Dim frm As New Frm_Surgeries()
        frm.Show()
    End Sub
    Private Sub ibtnSams_Click(sender As Object, e As EventArgs) Handles ibtnSams.Click
        If Not checkAccess("Sams") Then
            Exit Sub
        End If
        Dim frm As New Frm_Sams()
        frm.Show()
    End Sub
    Private Sub ibtnExpenses_Click(sender As Object, e As EventArgs) Handles ibtnExpenses.Click
        If Not checkAccess("Expenses") Then
            Exit Sub
        End If
        Dim frm As New Frm_Expenses()
        frm.Show()
    End Sub
    Private Sub IconButton3_Click(sender As Object, e As EventArgs) Handles IconButton3.Click
        If Not checkAccess("Users") Then
            Exit Sub
        End If
        Dim frm As New Frm_Users(user)
        frm.Show()
    End Sub
    Private Sub ibtnReports_Click(sender As Object, e As EventArgs) Handles ibtnReports.Click
        If Not checkAccess("Reports") Then
            Exit Sub
        End If
        Dim frm As New Frm_InvoicesReport
        frm.Show()
    End Sub

    Private Sub ibtnBackup_Click(sender As Object, e As EventArgs) Handles ibtnBackup.Click
        If Not checkAccess("Backup") Then
            Exit Sub
        End If
        SaveBackup()
    End Sub
    Private Sub ibtnRestore_Click(sender As Object, e As EventArgs) Handles ibtnRestore.Click
        If Not checkAccess("Restore") Then
            Exit Sub
        End If
        RestoreDataBase()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblTime.Text = Now.ToLongTimeString
        lblDate.Text = Now.ToLongDateString
    End Sub

    Private Sub ibtnNew_Click(sender As Object, e As EventArgs) Handles ibtnNewAppointment.Click
        loadPatientsTuSearch()
        panelAddAppointment.Visible = True
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles ibtnNewPatient.Click
        Dim frm As New Frm_NewPatient
        frm.ShowDialog()
    End Sub

    Private Sub ibtnClosePanel_Click(sender As Object, e As EventArgs) Handles ibtnClosePanel.Click
        panelAddAppointment.Visible = False
    End Sub
#End Region

#Region "Metodos"
    Sub SaveBackup()
        Try
            Dim ofd As SaveFileDialog = New SaveFileDialog
            ofd.DefaultExt = "bak"
            ofd.FileName = "BackUp" & Now.ToString("dd-MMMM-yyyy-hh-mm-ss")

            ofd.Filter = "All files|*.*|BAK files|*.BAK"
            ofd.Title = "Select Folder"
            If ofd.ShowDialog() <> DialogResult.Cancel Then
                Dim fdirectory As New FileInfo(ofd.FileName)
                Dim fName As New FileInfo(ofd.FileName)
                Dim folder As String = fdirectory.Directory.ToString()
                Dim name As String = fName.Name
                Dim ext As String = fName.Extension
                backupPath = fName.ToString.Replace("\", "\\")
                backupPath = backupPath.Insert(0, "'")
                backupPath = backupPath & "'"
                dbMain.backupDatabase(backupPath)
                util.InformationMessage("Back-Up successfully done", "Data base Back-up")
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub RestoreDataBase()
        Try
            If util.yesOrNot("Are you sure you want to restore the Data Base?", "Data base Restore") Then
                Dim ofd As OpenFileDialog = New OpenFileDialog
                ofd.DefaultExt = "bak"
                ofd.Filter = "All files|*.*|BAK files|*.BAK"
                ofd.Title = "Select Folder"
                If ofd.ShowDialog() <> DialogResult.Cancel Then
                    Dim fdirectory As New FileInfo(ofd.FileName)
                    Dim fName As New FileInfo(ofd.FileName)
                    Dim folder As String = fdirectory.Directory.ToString()
                    Dim name As String = fName.Name
                    Dim ext As String = fName.Extension
                    backupPath = fName.ToString.Replace("\", "\\")
                    dbMain.RestoreDatabase(backupPath)
                    util.InformationMessage("Data Base successfully restored", "Data base Restored")
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Function checkAccess(field As String) As Boolean
        Try
            user = New Users
            user = dbUsers.GetUserById(userId)
            If Not user.GetType().GetProperties().Where(Function(r) r.Name = field).First.GetValue(user) Then
                util.ErrorMessage("You have not access to this feature in the application." & vbLf & " Please contact your system administrator", "No Access")
                Return False
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
        Return True
    End Function
    Sub loadAppoitmentsByDate()
        Try
            appoitmentList = New List(Of Appoitmets)
            appoitmentList = dbAppoitments.GetAppoitmentsByDate(dtpDate.Value.Date).OrderBy(Function(r) r.AppoitmentTime).ToList
            dgv1.Columns.Clear()
            dgv1.DataSource = Nothing
            dgv1.DataSource = appoitmentList
            util.paintDGVRows(dgv1, Color.Beige, Color.Bisque)

            If dtpDate.Value.Date = Today Then
                util.addBottomColumns(dgv1, "CheckInCol", "Check-In")
                util.addBottomColumns(dgv1, "CheckOutCol", "Check-Out")
                dgv1.Columns("CheckInCol").Width = 60
                dgv1.Columns("CheckOutCol").Width = 60
            End If
            If dtpDate.Value.Date >= Today Then
                util.addBottomColumns(dgv1, "UpdateCol", "Update")
                util.addBottomColumns(dgv1, "DeleteCol", "Delete")
                dgv1.Columns("UpdateCol").Width = 60
                dgv1.Columns("DeleteCol").Width = 60
            End If
            If dtpDate.Value.Date <= Today Then
                util.addBottomColumns(dgv1, "VisitCol", "Process Visit")
                dgv1.Columns("VisitCol").Width = 120
            End If

            Dim indexList As New List(Of Integer)(New Integer() {0, 1, 2, 8})
            util.hideDGVColumns(dgv1, indexList)
            dgv1.Columns(3).HeaderText = "Patient Name"
            dgv1.Columns(5).HeaderText = "Appoitment Time"
            dgv1.Columns(6).HeaderText = "Check-In Time"
            dgv1.Columns(7).HeaderText = "Check-Out Time"
            dgv1.Columns("AppoitmentTime").DefaultCellStyle.Format = "hh:mm tt"
            dgv1.Columns("AppoitmentTime").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            For Each row As DataGridViewRow In dgv1.Rows
                If row.Cells("StartTime").Value.ToString <> "1/1/0001 12:00:00 AM" Then
                    row.Cells("StartTime").Style.Format = "hh:mm tt"
                End If
                If row.Cells("EndTime").Value.ToString <> "1/1/0001 12:00:00 AM" Then
                    row.Cells("EndTime").Style.Format = "hh:mm tt"
                End If
                If row.Cells("StartTime").Value.ToString <> "1/1/0001 12:00:00 AM" AndAlso row.Cells("EndTime").Value.ToString = "1/1/0001 12:00:00 AM" Then
                    row.DefaultCellStyle.BackColor = Color.Salmon
                End If
            Next
            dgv1.CurrentCell = Nothing
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub loadPatientsTuSearch()
        Try
            dgv2.Columns.Clear()
            dgv2.DataSource = Nothing
            dgv2.DataSource = dtPatients
            util.paintDGVRows(dgv2, Color.Beige, Color.Bisque)
            util.addBottomColumns(dgv2, "SetVisit", "Schedule Appoitment")
            Dim indexList As New List(Of Integer)(New Integer() {0})
            util.hideDGVColumns(dgv2, indexList)
            'dgv2.Columns(2).HeaderText = "Medical Problem"
            'dgvMedicalProblems.Columns(3).HeaderText = "Date"
            dgv2.Columns("SetVisit").Width = 60
            dgv2.Columns("Date OB").DefaultCellStyle.Format = "dd-MMM-yyyy"
            dgv2.CurrentCell = Nothing
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Private Async Function getPatientList() As Task
        Try
            dtPatients = Await dbMain.GetPatientList(True)
            dtPatients = dtPatients.AsEnumerable.OrderBy(Function(r) r("First Name")).CopyToDataTable
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Function
#End Region
#Region "Eventos Importantes"
    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        Try
            loadAppoitmentsByDate()
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick, dgv2.CellContentClick
        Try
            If e.RowIndex < 0 Or e.ColumnIndex < 0 Then
                Exit Sub
            End If
            Dim senderGrid = DirectCast(sender, DataGridView)
            Dim rowId As Integer = CInt(senderGrid.Rows(e.RowIndex).Cells("Id").Value)
            'buttom Form
            'medical problems
            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If senderGrid.Name = "dgv1" Then
                    loadAppoitmentsByDate()
                    Dim appoitment As New Appoitmets
                    appoitment = appoitmentList(e.RowIndex)
                    If senderGrid.Columns(e.ColumnIndex).Name = "DeleteCol" Then
                        If appoitment.VisitId = 0 Then
                            If util.yesOrNot("Do you want to delete the selected Appoitment", "Delete Appoitment") Then
                                dbAppoitments.DeleteIAppoitment(rowId)
                                util.InformationMessage("Appoitment  successfully deleted", "Appoitment Deleted")
                                loadAppoitmentsByDate()
                            End If
                        Else
                            util.InformationMessage("Tis appoitment can not be deleted because a visit was processed.", "Appoitment Not Deleted")
                        End If

                    End If
                    If senderGrid.Columns(e.ColumnIndex).Name = "CheckInCol" Then
                        If util.yesOrNot("Do you want to check-In the selected Appoitment", "check-In Appoitment") Then
                            dbAppoitments.chekIn(rowId)
                            util.InformationMessage("Check-In successfully done", "check-In")
                            loadAppoitmentsByDate()
                        End If
                    End If
                    If senderGrid.Columns(e.ColumnIndex).Name = "CheckOutCol" Then
                        If util.yesOrNot("Do you want to check-Out the selected Appoitment", "check-Out Appoitment") Then
                            dbAppoitments.checkOut(rowId)
                            util.InformationMessage("check-Out successfully done", "check-Out")
                            loadAppoitmentsByDate()
                        End If
                    End If
                    If senderGrid.Columns(e.ColumnIndex).Name = "UpdateCol" Then
                        Dim frm As New Frm_Appoitment(rowId, True)
                        frm.ShowDialog()
                        loadAppoitmentsByDate()
                    End If
                    If senderGrid.Columns(e.ColumnIndex).Name = "VisitCol" Then
                        Dim patientId As Integer = CInt(senderGrid.Rows(e.RowIndex).Cells("PatientId").Value)
                        If Not checkAccess("Visits") Then
                            Exit Sub
                        End If
                        If appoitment.VisitId = 0 Then
                            Dim frm As New Frm_Visit(patientId, rowId, True)
                            frm.ShowDialog()
                            loadAppoitmentsByDate()
                        Else
                            Dim frm As New Frm_Visit(appoitment.VisitId, patientId)
                            frm.ShowDialog()
                        End If
                    End If
                Else
                    If senderGrid.Columns(e.ColumnIndex).Name = "SetVisit" Then
                        Dim patientId As Integer = CInt(senderGrid.Rows(e.RowIndex).Cells("Id").Value)
                        Dim frm As New Frm_Appoitment(patientId)
                        frm.ShowDialog()
                        loadAppoitmentsByDate()
                    End If
                End If
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Private Sub txtFirstName_KeyUp(sender As Object, e As KeyEventArgs) Handles txtLastName.KeyUp, txtFirstName.KeyUp
        Try
            Dim txt As TextBox = CType(sender, TextBox)

            If txtFirstName.TextLength = 0 AndAlso txtLastName.TextLength = 0 Then
                dgv2.Columns.Clear()
                dgv2.DataSource = dtPatients
                util.addBottomColumns(dgv2, "SetVisit", "Schedule Visit")
            Else
                Dim toFind As String = txtFirstName.Text.ToUpper & txtLastName.Text.ToUpper
                dgv2.DataSource = Nothing
                dgv2.Columns.Clear()

                If txtFirstName.TextLength > 0 And txtLastName.TextLength = 0 Then
                    dgv2.DataSource = dtPatients.AsEnumerable.Where(Function(r) (r("First Name").ToUpper & r("Last Name").ToUpper & r("Others Name").ToUpper).Contains(toFind.ToUpper)).CopyToDataTable
                ElseIf txtFirstName.TextLength = 0 And txtLastName.TextLength > 0 Then
                    dgv2.DataSource = dtPatients.AsEnumerable.Where(Function(r) (r("First Name").ToUpper & r("Last Name").ToUpper & r("Others Name").ToUpper).Contains(toFind.ToUpper)).CopyToDataTable
                ElseIf txtFirstName.TextLength > 0 And txtLastName.TextLength > 0 Then
                    dgv2.DataSource = dtPatients.AsEnumerable.Where(Function(r) r("First Name").ToUpper.Contains(txtFirstName.Text.ToUpper) AndAlso r("Last Name").ToUpper.Contains(txtLastName.Text.ToUpper)).CopyToDataTable
                End If
                util.addBottomColumns(dgv2, "SetVisit", "Schedule Visit")
            End If
            dgv2.Columns(0).Visible = False
            dgv2.Columns("Date OB").DefaultCellStyle.Format = "dd-MMM-yyyy"
            dgv2.CurrentCell = Nothing
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
#End Region

#Region "Eventos sin importancia"
    Private Panel1Captured As Boolean
    Private Panel1Grabbed As Point
    Private Sub PanelEmployee_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panelAddAppointment.MouseDown
        Panel1Captured = True
        Panel1Grabbed = e.Location
    End Sub
    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panelAddAppointment.MouseMove
        If (Panel1Captured) Then panelAddAppointment.Location = panelAddAppointment.Location + e.Location - Panel1Grabbed
    End Sub
    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panelAddAppointment.MouseUp
        Panel1Captured = False
    End Sub

    Private Sub DgvCellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgv1.CellPainting, dgv2.CellPainting
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
                If senderGrid.Columns(e.ColumnIndex).Name = "CheckInCol" Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                    Dim w = My.Resources.chekin.Width
                    Dim h = My.Resources.chekin.Height
                    Dim x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2
                    Dim y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2
                    e.Graphics.DrawImage(My.Resources.chekin, New Rectangle(x, y, w, h))
                    e.Handled = True
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "CheckOutCol" Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                    Dim w = My.Resources.checkout.Width
                    Dim h = My.Resources.checkout.Height
                    Dim x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2
                    Dim y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2
                    e.Graphics.DrawImage(My.Resources.checkout, New Rectangle(x, y, w, h))
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
                If senderGrid.Columns(e.ColumnIndex).Name = "VisitCol" Or senderGrid.Columns(e.ColumnIndex).Name = "SetVisit" Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                    Dim w = My.Resources.visit.Width
                    Dim h = My.Resources.visit.Height
                    Dim x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2
                    Dim y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2
                    e.Graphics.DrawImage(My.Resources.visit, New Rectangle(x, y, w, h))
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub IconButton2_Click(sender As Object, e As EventArgs) Handles IconButton2.Click
        dtpDate.Value = dtpDate.Value.AddDays(1)
    End Sub

    Private Sub IconButton1_Click_1(sender As Object, e As EventArgs) Handles IconButton1.Click
        dtpDate.Value = dtpDate.Value.AddDays(-1)
    End Sub



    Private Sub Frm_Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If My.Application.OpenForms.Cast(Of Form).Any Then
            My.Application.OpenForms.Cast(Of Form).Except({Me}) _
           .ToList() _
           .ForEach(Sub(form) form.Close())
        End If

    End Sub



















#End Region

End Class