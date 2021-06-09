Imports System.Data.SqlClient

Public Class PatientEDB
    Dim conString As String = My.Settings.connectString

    'Select the list of ptients
    Function GetPatientList(active As Boolean) As List(Of PatientE)
        Dim patientList As New List(Of PatientE)
        Dim query As String = "SELECT [Id],[First Name],[Last Name],[Others Name],[Address],[Parish]
                              ,[Sex],[Date OB],[Phone1],[Phone2],[Email],[Paper Record]
                              ,[Registration Date],[SavedBy],[SavedTime]
	                          FROM [dbo].[Patient]
	                          WHERE ACTIVE =@ACTIVE"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@ACTIVE", SqlDbType.Bit).Value = active
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read
                    Dim patient As New PatientE
                    If Not reader.IsDBNull(0) Then
                        patient.Id = reader(0)
                    End If
                    If Not reader.IsDBNull(1) Then
                        patient.FirstName = reader(1)
                    End If
                    If Not reader.IsDBNull(2) Then
                        patient.LastName = reader(2)
                    End If
                    If Not reader.IsDBNull(3) Then
                        patient.OthersNames = reader(3)
                    End If
                    If Not reader.IsDBNull(4) Then
                        patient.Address = reader(4)
                    End If
                    If Not reader.IsDBNull(5) Then
                        patient.Parish = reader(5)
                    End If
                    If Not reader.IsDBNull(6) Then
                        patient.Sex = reader(6)
                    End If
                    If Not reader.IsDBNull(7) Then
                        patient.DatOB = reader(7)
                    End If
                    If Not reader.IsDBNull(8) Then
                        patient.Phone1 = reader(8)
                    End If
                    If Not reader.IsDBNull(9) Then
                        patient.Phone2 = reader(9)
                    End If
                    If Not reader.IsDBNull(10) Then
                        patient.Email = reader(10)
                    End If
                    If Not reader.IsDBNull(11) Then
                        patient.PaperRecord = reader(11)
                    End If
                    If Not reader.IsDBNull(12) Then
                        patient.RegistrationDate = reader(12)
                    End If
                    If Not reader.IsDBNull(13) Then
                        patient.SavedBy = reader(13)
                    End If
                    If Not reader.IsDBNull(14) Then
                        patient.SavedTime = reader(14)
                    End If
                    patientList.Add(patient)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return patientList
    End Function
    Function GetPatientById(id As Integer) As PatientE
        Dim patient As New PatientE
        Dim query As String = "SELECT [Id],[First Name],[Last Name],[Others Name],[Address],[Parish]
                              ,[Sex],[Date OB],[Phone1],[Phone2],[Email],[Paper Record]
                              ,[Registration Date],[SavedBy],[SavedTime]
	                          FROM [dbo].[Patient]
	                          WHERE ACTIVE =@ACTIVE and Id=@Id"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@ACTIVE", SqlDbType.Bit).Value = True
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read
                    If Not reader.IsDBNull(0) Then
                        patient.Id = reader(0)
                    End If
                    If Not reader.IsDBNull(1) Then
                        patient.FirstName = reader(1)
                    End If
                    If Not reader.IsDBNull(2) Then
                        patient.LastName = reader(2)
                    End If
                    If Not reader.IsDBNull(3) Then
                        patient.OthersNames = reader(3)
                    End If
                    If Not reader.IsDBNull(4) Then
                        patient.Address = reader(4)
                    End If
                    If Not reader.IsDBNull(5) Then
                        patient.Parish = reader(5)
                    End If
                    If Not reader.IsDBNull(6) Then
                        patient.Sex = reader(6)
                    End If
                    If Not reader.IsDBNull(7) Then
                        patient.DatOB = reader(7)
                    End If
                    If Not reader.IsDBNull(8) Then
                        patient.Phone1 = reader(8)
                    End If
                    If Not reader.IsDBNull(9) Then
                        patient.Phone2 = reader(9)
                    End If
                    If Not reader.IsDBNull(10) Then
                        patient.Email = reader(10)
                    End If
                    If Not reader.IsDBNull(11) Then
                        patient.PaperRecord = reader(11)
                    End If
                    If Not reader.IsDBNull(12) Then
                        patient.RegistrationDate = reader(12)
                    End If
                    If Not reader.IsDBNull(13) Then
                        patient.SavedBy = reader(13)
                    End If
                    If Not reader.IsDBNull(14) Then
                        patient.SavedTime = reader(14)
                    End If
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return patient
    End Function


    '########### INSERT PATIENT ####################
    Sub insertPatient(ByVal patient As PatientE)
        Dim query As String = "INSERT INTO [dbo].[Patient]
                                   ([Active],[First Name],[Last Name],[Others Name],[Address],[Parish],[Sex]
                                   ,[Date OB],[Phone1],[Phone2],[Email],[Paper Record],[Registration Date]
                                   ,[SavedBy],[SavedTime])
                             VALUES
                                   (@Active, @FirstName, @LastName, @OthersName, @Address, @Parish, @Sex, @DateOB,
		                            @Phone1, @Phone2, @Email, @PaperRecord, @RegistrationDate, @SavedBy, @SavedTime)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Active", SqlDbType.Bit).Value = patient.Active
                command.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = patient.FirstName
                command.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = patient.LastName
                command.Parameters.AddWithValue("@OthersName", SqlDbType.VarChar).Value = patient.OthersNames
                command.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = patient.Address
                command.Parameters.AddWithValue("@Parish", SqlDbType.VarChar).Value = patient.Parish
                command.Parameters.AddWithValue("@Sex", SqlDbType.VarChar).Value = patient.Sex
                command.Parameters.AddWithValue("@DateOB", SqlDbType.Date).Value = patient.DatOB
                command.Parameters.AddWithValue("@Phone1", SqlDbType.VarChar).Value = patient.Phone1
                command.Parameters.AddWithValue("@Phone2", SqlDbType.VarChar).Value = patient.Phone2
                command.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = patient.Email
                command.Parameters.AddWithValue("@PaperRecord", SqlDbType.Bit).Value = patient.PaperRecord
                command.Parameters.AddWithValue("@RegistrationDate", SqlDbType.DateTime).Value = patient.RegistrationDate
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.Date).Value = patient.SavedBy
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.VarChar).Value = patient.SavedTime
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
    Sub UpdatePatient(ByVal patient As PatientE)
        Dim query As String = "UPDATE [dbo].[Patient]
                               SET [First Name] = @FirstName,[Last Name] = @LastName,[Others Name] = @OthersName, 
                                   [Address] = @Address, [Parish] = @Parish, [Sex] = @Sex, [Date OB] = @DateOB,[Phone1] = @Phone1,
                                   [Phone2] = @Phone2, [Email] = @Email, [Paper Record] = @PaperRecord, [SavedBy] = @SavedBy,
                                   [SavedTime] = @SavedTime
	                              WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = patient.Id
                command.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = patient.FirstName
                command.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = patient.LastName
                command.Parameters.AddWithValue("@OthersName", SqlDbType.VarChar).Value = patient.OthersNames
                command.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = patient.Address
                command.Parameters.AddWithValue("@Parish", SqlDbType.VarChar).Value = patient.Parish
                command.Parameters.AddWithValue("@Sex", SqlDbType.VarChar).Value = patient.Sex
                command.Parameters.AddWithValue("@DateOB", SqlDbType.Date).Value = patient.DatOB
                command.Parameters.AddWithValue("@Phone1", SqlDbType.VarChar).Value = patient.Phone1
                command.Parameters.AddWithValue("@Phone2", SqlDbType.VarChar).Value = patient.Phone2
                command.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = patient.Email
                command.Parameters.AddWithValue("@PaperRecord", SqlDbType.Bit).Value = patient.PaperRecord
                command.Parameters.AddWithValue("@RegistrationDate", SqlDbType.DateTime).Value = patient.RegistrationDate
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.Date).Value = patient.SavedBy
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.VarChar).Value = patient.SavedTime
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

    '########### Delete PATIENT ####################
    Sub DeletePatient(ByVal id As Integer)
        Dim query As String = "UPDATE [dbo].[Patient]
                               SET [Active] = @Active
                               WHERE Id= @Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
                command.Parameters.AddWithValue("@Active", SqlDbType.Int).Value = False
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

    'Patient Notes

    '########### INSERT PATIENT ####################
    Sub insertPatientNotes(patienId As Integer, comment As String)
        Dim query As String = "INSERT INTO [dbo].[PatientNotes]
                                   ([PatientId],[Coments])
                             VALUES
                                   (@PatientId, @Coments)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patienId
                command.Parameters.AddWithValue("@Coments", SqlDbType.VarChar).Value = comment
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
    Sub UpdatePatientNotes(Id As Integer, comment As String)
        Dim query As String = "UPDATE [dbo].[PatientNotes]
                                 SET [Coments] = @Coments
	                              WHERE PatientId=@PatientId"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = Id
                command.Parameters.AddWithValue("@Coments", SqlDbType.VarChar).Value = comment
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
    Function noteExist(patientId As Integer) As Boolean
        Dim query As String = "SELECT [Id]
	                          FROM [dbo].[PatientNotes]
	                          WHERE  PatientId=@PatientId"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Return reader.Read
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return False
    End Function
    Function getNotes(patientId As Integer) As String
        Dim notes As String = String.Empty
        Dim query As String = "SELECT [Coments]
	                          FROM [dbo].[PatientNotes]
	                          WHERE  PatientId=@PatientId"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                If reader.Read Then
                    notes = reader.GetString(0)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return notes
    End Function

End Class
