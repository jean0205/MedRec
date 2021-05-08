Imports System.Data.SqlClient

Public Class MedicationsDB

    Dim conString As String = My.Settings.connectString


    '########### SELETC PATIENT ####################
    Function GetMedicationsList(patientId As Integer) As List(Of Medications)
        Dim medicationList As New List(Of Medications)
        Dim query As String = "SELECT [Id],[PatientId],[VisitId],[Name],[Dosis],[Reason],[Duration]
                                      ,[Active],[SavedBy],[SavedTime]
                                  FROM [dbo].[Medications]
                                  WHERE PatientId=@PatientId"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read
                    Dim medication As New Medications
                    If Not reader.IsDBNull(0) Then
                        medication.id = reader(0)
                    End If
                    If Not reader.IsDBNull(1) Then
                        medication.Patientid = reader(1)
                    End If
                    If Not reader.IsDBNull(2) Then
                        medication.VisitId = reader(2)
                    End If
                    If Not reader.IsDBNull(3) Then
                        medication.Name = reader(3)
                    End If
                    If Not reader.IsDBNull(4) Then
                        medication.Dosis = reader(4)
                    End If
                    If Not reader.IsDBNull(5) Then
                        medication.Reason = reader(5)
                    End If
                    If Not reader.IsDBNull(5) Then
                        medication.Reason = reader(5)
                    End If
                    If Not reader.IsDBNull(6) Then
                        medication.Duration = reader(6)
                    End If
                    If Not reader.IsDBNull(7) Then
                        medication.Active = reader(7)
                    End If
                    If Not reader.IsDBNull(8) Then
                        medication.SavedBy = reader(8)
                    End If
                    If Not reader.IsDBNull(9) Then
                        medication.SavedTime = reader(9)
                    End If
                    medicationList.Add(medication)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return medicationList
    End Function
    Function GetMedicationById(id As Integer) As Medications
        Dim medication As New Medications
        Dim query As String = "SELECT [Id],[PatientId],[VisitId],[Name],[Dosis],[Reason],[Duration]
                                      ,[Active],[SavedBy],[SavedTime]
                                  FROM [dbo].[Medications]
                                  WHERE Id=@Id"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read
                    If Not reader.IsDBNull(0) Then
                    medication.id = reader(0)
                End If
                If Not reader.IsDBNull(1) Then
                    medication.Patientid = reader(1)
                End If
                If Not reader.IsDBNull(2) Then
                    medication.VisitId = reader(2)
                End If
                If Not reader.IsDBNull(3) Then
                    medication.Name = reader(3)
                End If
                If Not reader.IsDBNull(4) Then
                    medication.Dosis = reader(4)
                End If
                If Not reader.IsDBNull(5) Then
                    medication.Reason = reader(5)
                End If
                If Not reader.IsDBNull(5) Then
                    medication.Reason = reader(5)
                End If
                If Not reader.IsDBNull(6) Then
                    medication.Duration = reader(6)
                End If
                If Not reader.IsDBNull(7) Then
                    medication.Active = reader(7)
                End If
                If Not reader.IsDBNull(8) Then
                    medication.SavedBy = reader(8)
                End If
                If Not reader.IsDBNull(9) Then
                    medication.SavedTime = reader(9)
                End If
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return medication
    End Function

    '########### INSERT PATIENT ####################
    Sub insertMedication(ByVal medication As Medications)
        Dim query As String = "INSERT INTO [dbo].[Medications]
                                   ([PatientId],[VisitId],[Name],[Dosis],[Reason],[Duration],[Active]
                                   ,[SavedBy],[SavedTime])
                             VALUES
                                   (@PatientId, @VisitId, @Name, @Dosis, @Reason, @Duration, @Active, @SavedBy, @SavedTime)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = medication.PatientId
                command.Parameters.AddWithValue("@VisitId", SqlDbType.Int).Value = medication.VisitId
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = medication.Name
                command.Parameters.AddWithValue("@Dosis", SqlDbType.VarChar).Value = medication.Dosis
                command.Parameters.AddWithValue("@Reason", SqlDbType.VarChar).Value = medication.Reason
                command.Parameters.AddWithValue("@Duration", SqlDbType.VarChar).Value = medication.Duration
                command.Parameters.AddWithValue("@Active", SqlDbType.Bit).Value = medication.Active
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = medication.SavedBy
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = medication.SavedTime
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
    Sub updateMedication(ByVal medication As Medications)
        Dim query As String = "UPDATE [dbo].[Medications]
                               SET [Name] = @Name, [Dosis] = @Dosis, [Reason] = @Reason,[Duration] = @Duration, 
                                   [Active] = @Active, [SavedBy] = @SavedBy, [SavedTime] = @SavedTime
		                           WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = medication.id
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = medication.Name
                command.Parameters.AddWithValue("@Dosis", SqlDbType.VarChar).Value = medication.Dosis
                command.Parameters.AddWithValue("@Reason", SqlDbType.VarChar).Value = medication.Reason
                command.Parameters.AddWithValue("@Duration", SqlDbType.VarChar).Value = medication.Duration
                command.Parameters.AddWithValue("@Active", SqlDbType.Bit).Value = medication.Active
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = medication.SavedBy
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = medication.SavedTime
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
    Sub DeleteMedication(ByVal id As Integer)
        Dim query As String = "DELETE FROM [dbo].[Medications]
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
