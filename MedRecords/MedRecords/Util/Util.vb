Public Class Util

    'yes or not message
    Function yesOrNot(message As String, title As String) As Boolean
        Dim response As Boolean = False
        Try
            Dim buttons As MessageBoxButtons = MessageBoxButtons.YesNo
            Dim result As DialogResult = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                response = True
            Else
                response = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                                      "Error",
                                           MessageBoxButtons.OK,
                                              MessageBoxIcon.Error,
                                                  MessageBoxDefaultButton.Button1)
        End Try
        Return response
    End Function
    Sub ErrorMessage(message As String, title As String)
        Try
            MessageBox.Show(message,
                                title,
                                    MessageBoxButtons.OK,
                                       MessageBoxIcon.Error,
                                           MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                                      "Error",
                                           MessageBoxButtons.OK,
                                              MessageBoxIcon.Error,
                                                  MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Sub InformationMessage(message As String, title As String)
        Try
            MessageBox.Show(message,
                                title,
                                    MessageBoxButtons.OK,
                                       MessageBoxIcon.Information,
                                           MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                                      "Error",
                                           MessageBoxButtons.OK,
                                              MessageBoxIcon.Error,
                                                  MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Function CalculateAge(ByVal dateOfEntry As DateTime, ByVal dateOfBirth As DateTime) As Integer
        Dim age As Integer = 0
        age = dateOfEntry.Year - dateOfBirth.Year
        If dateOfEntry.DayOfYear < dateOfBirth.DayOfYear Then age = age - 1
        Return age
    End Function

    '################TXT KEY PRESS########################
    Public Sub txtOnlyIntegersNumber_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Sub txtOnlyDecimalNumber_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." AndAlso CType(sender, TextBox).Text.Length = 0 Then
            e.Handled = True
        ElseIf e.KeyChar = "." AndAlso Not CType(sender, TextBox).Text.Contains(".") Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Sub txtOnlyLetters_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


    '################DGV ########################
    Public Sub addBottomColumns(dgv As DataGridView, colName As String, colText As String)
        Try
            If Not dgv.Columns.Contains(colName) Then
                Dim btnOForm As New DataGridViewButtonColumn
                btnOForm.HeaderText = colText
                btnOForm.Name = colName
                btnOForm.UseColumnTextForButtonValue = True
                dgv.Columns.Add(btnOForm)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                                                 "Error",
                                                      MessageBoxButtons.OK,
                                                         MessageBoxIcon.Error,
                                                             MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Public Sub addCheckBoxColumns(dgv As DataGridView, colName As String, colText As String)
        Try
            If Not dgv.Columns.Contains(colName) Then
                Dim btnOForm As New DataGridViewCheckBoxColumn
                btnOForm.HeaderText = colText
                btnOForm.Name = colName
                dgv.Columns.Add(btnOForm)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                                                 "Error",
                                                      MessageBoxButtons.OK,
                                                         MessageBoxIcon.Error,
                                                             MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Public Sub insertTextColumn(dgv As DataGridView, colName As String, colText As String, colIndex As Integer)
        Try
            If Not dgv.Columns.Contains(colName) Then
                Dim btnOForm As New DataGridViewTextBoxColumn
                btnOForm.HeaderText = colText
                btnOForm.Name = colName
                dgv.Columns.Insert(colIndex, btnOForm)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                                                 "Error",
                                                      MessageBoxButtons.OK,
                                                         MessageBoxIcon.Error,
                                                             MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Public Sub paintDGVRows(dgv As DataGridView, color1 As Color, color2 As Color)
        Try
            dgv.RowsDefaultCellStyle.BackColor = color1
            dgv.AlternatingRowsDefaultCellStyle.BackColor = color2
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                                                 "Error",
                                                      MessageBoxButtons.OK,
                                                         MessageBoxIcon.Error,
                                                             MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Public Sub hideDGVColumns(dgv As DataGridView, colList As List(Of Integer))
        Try
            For Each col As Integer In colList
                dgv.Columns(col).Visible = False
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                                                 "Error",
                                                      MessageBoxButtons.OK,
                                                         MessageBoxIcon.Error,
                                                             MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    'devolver una lista con todos los textbox de un formulario, busca recursivamente
    Public Function FindAllTextBoxIterative(ByRef parent As Control) As List(Of TextBox)
        Dim list As New List(Of TextBox)
        Dim ContainerStack As New Stack(Of Control)
        ContainerStack.Push(parent)
        While ContainerStack.Count > 0
            For Each child As Control In ContainerStack.Pop().Controls
                If child.HasChildren Then ContainerStack.Push(child)
                If child.GetType Is GetType(TextBox) Then list.Add(child)
            Next
        End While
        Return list
    End Function
    Public Function FindAllTextRichBoxIterative(ByRef parent As Control) As List(Of RichTextBox)
        Dim list As New List(Of RichTextBox)
        Dim ContainerStack As New Stack(Of Control)
        ContainerStack.Push(parent)
        While ContainerStack.Count > 0
            For Each child As Control In ContainerStack.Pop().Controls
                If child.HasChildren Then ContainerStack.Push(child)
                If child.GetType Is GetType(RichTextBox) Then list.Add(child)
            Next
        End While
        Return list
    End Function



End Class
