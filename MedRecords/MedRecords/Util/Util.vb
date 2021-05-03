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

End Class
