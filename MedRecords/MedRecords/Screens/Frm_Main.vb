Public Class Frm_Main
    Dim util As New Util
    Dim dbMain As New MainDB
    Dim dtPatients As New DataTable

    Private Async Sub Frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'AddHandler txtFirstName.KeyPress, AddressOf util.txtOnlyIntegersNumber_KeyPress
        Await getPatientList()

    End Sub

#Region "Botones"
    Private Sub ibtnPatients_Click(sender As Object, e As EventArgs) Handles ibtnPatients.Click
        Dim frm As New Frm_NewPatient
        frm.ShowDialog()
    End Sub
    Private Sub ibtnVisits_Click(sender As Object, e As EventArgs) Handles ibtnVisits.Click
        Dim frm As New Frm_Visit
        frm.ShowDialog()
    End Sub

    Private Sub ibtnServices_Click(sender As Object, e As EventArgs) Handles ibtnServices.Click
        Dim frm As New Frm_Services
        frm.ShowDialog()
    End Sub

    Private Sub ibtnSurgeries_Click(sender As Object, e As EventArgs) Handles ibtnSurgeries.Click

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
    Sub loadPatientsTuSearch()
        Try
            dgv2.Columns.Clear()
            dgv2.DataSource = Nothing
            dgv2.DataSource = dtPatients
            util.paintDGVRows(dgv2, Color.Beige, Color.Bisque)
            util.addBottomColumns(dgv2, "SetVisit", "Schedule Visit")
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








#End Region

End Class