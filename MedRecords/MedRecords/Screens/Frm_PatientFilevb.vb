Imports System.Reflection
Public Class Frm_PatientFilevb
    Dim util As New Util
    Dim dbPatient As New PatientEDB
    Dim dbMedicalProblems As New MedicalProblemsDB
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
    End Sub

#Region "Metodos"
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
            lblRegistrationDate.Text = patient.RegistrationDate.ToString("dd-MMM-yyyy:hh:mm")
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

        End Select
    End Sub
    Private Sub DgvCellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvMedicalProblems.CellPainting
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
                If senderGrid.Columns(e.ColumnIndex).Name = "DetailsCol" Then
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

    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicalProblems.CellContentClick
        Try
            If e.RowIndex < 0 Or e.ColumnIndex < 0 Then
                Exit Sub
            End If
            Dim senderGrid = DirectCast(sender, DataGridView)
            Dim problemId As Integer = CInt(senderGrid.Rows(e.RowIndex).Cells("Id").Value)
            'buttom Form
            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If senderGrid.Columns(e.ColumnIndex).Name = "DeleteCol" Then
                    If util.yesOrNot("Do you want to delete the selected Medical Problem/Ilness", "Delete Medical Problem") Then
                        dbMedicalProblems.DeleteIlness(problemId)
                        util.InformationMessage("Medical Problem/Ilness successfully deleted", "Medical Problem/Ilness Daleted")
                        loadMedicalProblems()
                    End If
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "DetailsCol" Then
                    Dim frm As New Frm_MedicalProblems(problemId, True)
                    frm.ShowDialog()
                    loadMedicalProblems()
                End If
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
#End Region
End Class