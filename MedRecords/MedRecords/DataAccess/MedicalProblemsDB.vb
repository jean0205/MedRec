Imports System.Data.SqlClient

Public Class MedicalProblemsDB
    Dim conString As String = My.Settings.connectString

    '########### SELETC PATIENT ####################
    Function GetIlnessList(patientId As Integer) As List(Of MedicalProblems)
        Dim ilnessList As New List(Of MedicalProblems)
        Dim query As String = "SELECT [Id],[PatientId],[Name],[ProblemDate],[Reason],[Comments],[Gynecologic]
                                      ,[SavedBy],[SavedTime]
                                  FROM [dbo].[MedicalProblems]
                                    where PatientId=@PatientId and Gynecologic=@Gynecologic"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
            command.Parameters.AddWithValue("@Gynecologic", SqlDbType.Bit).Value = False
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read
                    Dim ilness As New MedicalProblems
                    If Not reader.IsDBNull(0) Then
                        ilness.id = reader(0)
                    End If
                    If Not reader.IsDBNull(1) Then
                        ilness.PatientId = reader(1)
                    End If
                    If Not reader.IsDBNull(2) Then
                        ilness.Name = reader(2)
                    End If
                    If Not reader.IsDBNull(3) Then
                        ilness.ProblemDate = reader(3)
                    End If
                    If Not reader.IsDBNull(4) Then
                        ilness.Reason = reader(4)
                    End If
                    If Not reader.IsDBNull(5) Then
                        ilness.Comments = reader(5)
                    End If
                    If Not reader.IsDBNull(6) Then
                        ilness.isGynecologic = reader(6)
                    End If
                    If Not reader.IsDBNull(7) Then
                        ilness.SavedBy = reader(7)
                    End If
                    If Not reader.IsDBNull(8) Then
                        ilness.SavedTime = reader(8)
                    End If
                    ilnessList.Add(ilness)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return ilnessList
    End Function
    Function GetGynecroblemsList(patientId As Integer) As List(Of MedicalProblems)
        Dim ilnessList As New List(Of MedicalProblems)
        Dim query As String = "SELECT [Id],[PatientId],[Name],[ProblemDate],[Reason],[Comments],[Gynecologic]
                                      ,[SavedBy],[SavedTime]
                                  FROM [dbo].[MedicalProblems]
                                    where PatientId=@PatientId and Gynecologic=@Gynecologic"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
            command.Parameters.AddWithValue("@Gynecologic", SqlDbType.Bit).Value = True
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read
                    Dim ilness As New MedicalProblems
                    If Not reader.IsDBNull(0) Then
                        ilness.id = reader(0)
                    End If
                    If Not reader.IsDBNull(1) Then
                        ilness.PatientId = reader(1)
                    End If
                    If Not reader.IsDBNull(2) Then
                        ilness.Name = reader(2)
                    End If
                    If Not reader.IsDBNull(3) Then
                        ilness.ProblemDate = reader(3)
                    End If
                    If Not reader.IsDBNull(4) Then
                        ilness.Reason = reader(4)
                    End If
                    If Not reader.IsDBNull(5) Then
                        ilness.Comments = reader(5)
                    End If
                    If Not reader.IsDBNull(6) Then
                        ilness.isGynecologic = reader(6)
                    End If
                    If Not reader.IsDBNull(7) Then
                        ilness.SavedBy = reader(7)
                    End If
                    If Not reader.IsDBNull(8) Then
                        ilness.SavedTime = reader(8)
                    End If
                    ilnessList.Add(ilness)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return ilnessList
    End Function
    Function GetIlnessById(id As Integer) As MedicalProblems
        Dim ilness As New MedicalProblems
        Dim query As String = "SELECT [Id],[PatientId],[Name],[ProblemDate],[Reason],[Comments],[Gynecologic]
                                      ,[SavedBy],[SavedTime]
                                  FROM [dbo].[MedicalProblems]
                                    where Id=@Id"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read
                    If Not reader.IsDBNull(0) Then
                        ilness.id = reader(0)
                    End If
                    If Not reader.IsDBNull(1) Then
                        ilness.PatientId = reader(1)
                    End If
                    If Not reader.IsDBNull(2) Then
                        ilness.Name = reader(2)
                    End If
                    If Not reader.IsDBNull(3) Then
                        ilness.ProblemDate = reader(3)
                    End If
                    If Not reader.IsDBNull(4) Then
                        ilness.Reason = reader(4)
                    End If
                    If Not reader.IsDBNull(5) Then
                        ilness.Comments = reader(5)
                    End If
                    If Not reader.IsDBNull(6) Then
                        ilness.isGynecologic = reader(6)
                    End If
                    If Not reader.IsDBNull(7) Then
                        ilness.SavedBy = reader(7)
                    End If
                    If Not reader.IsDBNull(8) Then
                        ilness.SavedTime = reader(8)
                    End If
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return ilness
    End Function

    '########### INSERT PATIENT ####################
    Sub insertIlness(ByVal ilness As MedicalProblems)
        Dim query As String = "INSERT INTO [dbo].[MedicalProblems]
                                   ([PatientId],[Name],[ProblemDate],[Reason],[Comments],[Gynecologic],[SavedBy]
                                   ,[SavedTime])
                             VALUES
                                   (@PatientId, @Name, @ProblemDate, @Reason, @Comments, @Gynecologic, @SavedBy, @SavedTime)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = ilness.PatientId
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = ilness.Name
                command.Parameters.AddWithValue("@ProblemDate", SqlDbType.Date).Value = ilness.ProblemDate
                command.Parameters.AddWithValue("@Reason", SqlDbType.VarChar).Value = ilness.Reason
                command.Parameters.AddWithValue("@Comments", SqlDbType.VarChar).Value = ilness.Comments
                command.Parameters.AddWithValue("@Gynecologic", SqlDbType.Bit).Value = ilness.isGynecologic
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = Form1.user.User
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = ilness.SavedTime
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

    '########### UPDATE PATIENT ####################
    Sub updateIlness(ByVal ilness As MedicalProblems)
        Dim query As String = "UPDATE [dbo].[MedicalProblems]
                                   SET [Name] = @Name, [ProblemDate] = @ProblemDate, [Reason] = @Reason, 
                                      [Comments] = @Comments, [Gynecologic] = @Gynecologic, [SavedBy] = @SavedBy, [SavedTime] = @SavedTime
                                 WHERE 
                                 Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = ilness.id
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = ilness.Name
                command.Parameters.AddWithValue("@ProblemDate", SqlDbType.Date).Value = ilness.ProblemDate
                command.Parameters.AddWithValue("@Reason", SqlDbType.VarChar).Value = ilness.Reason
                command.Parameters.AddWithValue("@Comments", SqlDbType.VarChar).Value = ilness.Comments
                command.Parameters.AddWithValue("@Gynecologic", SqlDbType.Bit).Value = ilness.isGynecologic
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = Form1.user.User
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = ilness.SavedTime
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

    '########### DELETE PATIENT ####################
    Sub DeleteIlness(ByVal id As Integer)
        Dim query As String = "DELETE FROM [dbo].[MedicalProblems]
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
