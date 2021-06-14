Imports System.Data.SqlClient
Imports System.Reflection

Public Class SurgeryDB
    Dim conString As String = My.Settings.connectString


    '########### SELETC SURGERY ####################
    Function GetSurgeryList(patientId As Integer) As List(Of Surgery)
        Dim surgeryList As New List(Of Surgery)
        Dim query As String = "SELECT *
                              FROM [dbo].[Surgery]
                              WHERE PatientId=@PatientId"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim surgery As New Surgery
                Dim properties As List(Of PropertyInfo) = surgery.GetType().GetProperties().ToList
                While reader.Read
                    surgery = New Surgery
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(properties.IndexOf(prop)) Then
                            prop.SetValue(surgery, reader(properties.IndexOf(prop)))
                        End If
                    Next
                    surgeryList.Add(surgery)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return surgeryList
    End Function
    Function GetSurgeryById(id As Integer) As Surgery
        Dim surgery As New Surgery
        Dim query As String = "SELECT *
                              FROM [dbo].[Surgery]
                              WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim properties As List(Of PropertyInfo) = surgery.GetType().GetProperties().ToList
                While reader.Read
                    surgery = New Surgery
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(properties.IndexOf(prop)) Then
                            prop.SetValue(surgery, reader(properties.IndexOf(prop)))
                        End If
                    Next
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return surgery
    End Function

    '########### INSERT SURGERY ####################
    Sub insertSurgery(ByVal surgery As Surgery)
        Dim query As String = "INSERT INTO [dbo].[Surgery]
                                   ([PatientId],[Name],[Reason],[Date],[Comments]
                                   ,[SavedBy],[SavedTime])
                             VALUES
                                   (@PatientId, @Name, @Reason, @Date, @Comments, @SavedBy, @SavedTime)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = surgery.Patientid
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = surgery.Name
                command.Parameters.AddWithValue("@Reason", SqlDbType.VarChar).Value = surgery.Reason
                command.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = surgery.SurgeryDate
                command.Parameters.AddWithValue("@Comments", SqlDbType.VarChar).Value = surgery.Comments
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = Form1.user.User
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = surgery.SavedTime
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

    '########### UPDATE SURGERY ####################
    Sub updateSurgery(ByVal surgery As Surgery)
        Dim query As String = "UPDATE [dbo].[Surgery]
                               SET [Name] = @Name, [Reason] = @Reason, [Date] = @Date, [Comments] = @Comments, 
                                   [SavedBy] = @SavedBy, [SavedTime] = @SavedTime
	                               WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = surgery.id
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = surgery.Name
                command.Parameters.AddWithValue("@Reason", SqlDbType.VarChar).Value = surgery.Reason
                command.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = surgery.SurgeryDate
                command.Parameters.AddWithValue("@Comments", SqlDbType.VarChar).Value = surgery.Comments
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = Form1.user.User
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = surgery.SavedTime
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
    Sub DeleteSurgery(ByVal id As Integer)
        Dim query As String = "DELETE FROM [dbo].[Surgery]
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
