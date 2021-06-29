Public Class Frm_Services
    Dim util As New Util
    Dim updating As Boolean = False
    Dim serviceId As Integer = 0
    'DB OBJECTS
    Dim dbService As New ServiceDB
    Dim service As Service
    Private Sub Frm_Services_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler txtServiceCost.KeyPress, AddressOf util.txtOnlyDecimalNumber_KeyPress
        loadServices()
    End Sub
    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        saveService(updating)
    End Sub
    Sub loadServices()
        Try
            dgv1.Columns.Clear()
            dgv1.DataSource = dbService.GetSeriveList
            util.paintDGVRows(dgv1, Color.Beige, Color.Bisque)
            util.addBottomColumns(dgv1, "Update", "Update")
            util.addBottomColumns(dgv1, "Delete", "Delete")
            Dim indexList As New List(Of Integer)(New Integer() {0})
            util.hideDGVColumns(dgv1, indexList)
            dgv1.Columns(1).HeaderText = "Service Name"
            dgv1.Columns("Update").Width = 60
            dgv1.Columns("Delete").Width = 60
            dgv1.Columns("Cost").DefaultCellStyle.Format = "N2"
            Me.updating = False
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub saveService(updating As Boolean)
        Try
            Dim service As New Service
            service.Name = txtServiceName.Text.ToUpper
            service.Description = txtServiceDescription.Text.ToUpper
            service.Cost = CDec(txtServiceCost.Text)
            If updating Then
                service.Id = serviceId
                dbService.updateService(service)
            Else
                dbService.insertService(service)
            End If
            Me.updating = False
            cleanAfterInsert()
            util.InformationMessage("Service successfully saved", "New Service")
            loadServices()
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub cleanAfterInsert()
        Try
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                txt.Clear()
            Next
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub fillUpInfoToUpdate()
        Try
            txtServiceName.Text = service.Name
            txtServiceDescription.Text = service.Description
            txtServiceCost.Text = service.Cost.ToString("C2")
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub DgvCellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgv1.CellPainting
        Try
            Dim senderGrid As DataGridView = CType(sender, DataGridView)
            If e.RowIndex < 0 Then
                Exit Sub
            End If
            If e.ColumnIndex >= 0 Then
                If senderGrid.Columns(e.ColumnIndex).Name = "Delete" Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                    Dim w = My.Resources.delete.Width
                    Dim h = My.Resources.delete.Height
                    Dim x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2
                    Dim y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2
                    e.Graphics.DrawImage(My.Resources.delete, New Rectangle(x, y, w, h))
                    e.Handled = True
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "Update" Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                    Dim w = My.Resources.update.Width
                    Dim h = My.Resources.update.Height
                    Dim x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2
                    Dim y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2
                    e.Graphics.DrawImage(My.Resources.update, New Rectangle(x, y, w, h))
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
            serviceId = CInt(senderGrid.Rows(e.RowIndex).Cells("Id").Value)
            service = dbService.GetServiceById(serviceId)
            'buttom Form
            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If senderGrid.Columns(e.ColumnIndex).Name = "Delete" Then
                    If util.yesOrNot("Do you want to delete the selected Service", "Delete Service") Then
                        dbService.DeleteService(serviceId)
                        util.InformationMessage("Service successfully deleted", "Service Daleted")
                        loadServices()
                    End If
                End If
                If senderGrid.Columns(e.ColumnIndex).Name = "Update" Then
                    updating = True
                    fillUpInfoToUpdate()
                End If
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub Escape(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(27) Then
            cleanAfterInsert()
        End If
    End Sub
End Class