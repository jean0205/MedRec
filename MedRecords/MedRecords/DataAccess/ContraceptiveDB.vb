Imports System.Data.SqlClient
Imports System.Reflection

Public Class ContraceptiveDB
    Dim conString As String = My.Settings.connectString
    '########### INSERT Contraceptive ####################
    Sub insertContraceptive(ByVal contraceptive As Contraceptive)
        Dim query As String = "INSERT INTO [dbo].[Contraceptive]
                                   ([PatientId],Method,[From],[To],[Results],[SavedBy],[SavedTime])
                             VALUES
                                   (@PatientId, @Method, @From, @To, @Results, @SavedBy, @SavedTime)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = contraceptive.PatientId
                command.Parameters.AddWithValue("@Method", SqlDbType.VarChar).Value = contraceptive.Method
                command.Parameters.AddWithValue("@From", SqlDbType.Date).Value = contraceptive.FromD
                command.Parameters.AddWithValue("@To", SqlDbType.Date).Value = contraceptive.ToDate
                command.Parameters.AddWithValue("@Results", SqlDbType.Bit).Value = contraceptive.Results
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = contraceptive.SavedBy
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = contraceptive.SavedTime
                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
    End Sub
    Function GetContraceptiveList(patientId As Integer) As List(Of Contraceptive)
        Dim contraceptiveList As New List(Of Contraceptive)
        Dim query As String = "SELECT *
                              FROM [dbo].[Contraceptive]
                              WHERE PatientId=@PatientId"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim contracetive As New Contraceptive
                Dim properties As List(Of PropertyInfo) = contracetive.GetType().GetProperties().ToList
                While reader.Read
                    contracetive = New Contraceptive
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(properties.IndexOf(prop)) Then
                            prop.SetValue(contracetive, reader(properties.IndexOf(prop)))
                        End If
                    Next
                    contraceptiveList.Add(contracetive)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return contraceptiveList
    End Function
    Function GetContraceptiveById(id As Integer) As Contraceptive
        Dim contraceptive As New Contraceptive
        Dim query As String = "SELECT *
                              FROM [dbo].[Contraceptive]
                              WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim properties As List(Of PropertyInfo) = contraceptive.GetType().GetProperties().ToList
                While reader.Read
                    contraceptive = New Contraceptive
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(properties.IndexOf(prop)) Then
                            prop.SetValue(contraceptive, reader(properties.IndexOf(prop)))
                        End If
                    Next
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return contraceptive
    End Function


    Sub updateContraceptive(ByVal contraceptive As Contraceptive)
        Dim query As String = "UPDATE [dbo].[Contraceptive]
                                SET  [Method] = @Method, [From] = @From, [To] = @To, 
                                    [Results] = @Results, [SavedBy] = @SavedBy, [SavedTime] = @SavedTime
	                               WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = contraceptive.Id
                command.Parameters.AddWithValue("@Method", SqlDbType.VarChar).Value = contraceptive.Method
                command.Parameters.AddWithValue("@From", SqlDbType.Date).Value = contraceptive.FromD
                command.Parameters.AddWithValue("@To", SqlDbType.Date).Value = contraceptive.ToDate
                command.Parameters.AddWithValue("@Results", SqlDbType.Bit).Value = contraceptive.Results
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = contraceptive.SavedBy
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = contraceptive.SavedTime
                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
    End Sub

    '########### DELETE SURGERY ####################
    Sub DeleteContraceptive(ByVal id As Integer)
        Dim query As String = "DELETE FROM [dbo].[Contraceptive]
                               WHERE Id= @Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
    End Sub
End Class
