Imports System.Data.SqlClient

Public Class AllergyDB
    Dim conString As String = My.Settings.connectString


    '########### SELETC PATIENT ####################
    Function GetallergiesList(patientId As Integer) As List(Of Allergy)
        Dim allergyList As New List(Of Allergy)
        Dim query As String = "SELECT [Id],[PatientId],[Name],[Nature Of Reaction],[SavedBy],[SavedTime]
                                          FROM [dbo].[Allergy]
                                          Where  PatientId=@PatientId"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read
                    Dim allergy As New Allergy
                    If Not reader.IsDBNull(0) Then
                        allergy.id = reader(0)
                    End If
                    If Not reader.IsDBNull(1) Then
                        allergy.Patientid = reader(1)
                    End If
                    If Not reader.IsDBNull(2) Then
                        allergy.Name = reader(2)
                    End If
                    If Not reader.IsDBNull(3) Then
                        allergy.NatureOfReaction = reader(3)
                    End If
                    If Not reader.IsDBNull(4) Then
                        allergy.SavedBy = reader(4)
                    End If
                    If Not reader.IsDBNull(5) Then
                        allergy.SavedTime = reader(5)
                    End If
                    allergyList.Add(allergy)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return allergyList
    End Function
    Function GetAllergyById(id As Integer) As Allergy
        Dim allergy As New Allergy
        Dim query As String = "SELECT [Id],[PatientId],[Name],[Nature Of Reaction],[SavedBy],[SavedTime]
                                     FROM [dbo].[Allergy]
                                    where Id=@Id"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read
                    If Not reader.IsDBNull(0) Then
                        allergy.id = reader(0)
                    End If
                    If Not reader.IsDBNull(1) Then
                        allergy.Patientid = reader(1)
                    End If
                    If Not reader.IsDBNull(2) Then
                        allergy.Name = reader(2)
                    End If
                    If Not reader.IsDBNull(3) Then
                        allergy.NatureOfReaction = reader(3)
                    End If
                    If Not reader.IsDBNull(4) Then
                        allergy.SavedBy = reader(4)
                    End If
                    If Not reader.IsDBNull(5) Then
                        allergy.SavedTime = reader(5)
                    End If
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return allergy
    End Function

    '########### INSERT PATIENT ####################
    Sub insertAllergy(ByVal allergy As Allergy)
        Dim query As String = "INSERT INTO [dbo].[Allergy]
                                       ([PatientId],[Name],[Nature Of Reaction],[SavedBy],[SavedTime])
                                 VALUES
                                       (@PatientId, @Name, @NatureOfReaction, @SavedBy, @SavedTime)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = allergy.Patientid
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = allergy.Name
                command.Parameters.AddWithValue("@NatureOfReaction", SqlDbType.VarChar).Value = allergy.NatureOfReaction
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = allergy.SavedBy
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = allergy.SavedTime
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
    Sub updateAllergy(ByVal allergy As Allergy)
        Dim query As String = "UPDATE [dbo].[Allergy]
                                   SET  [Name] = @Name, [Nature Of Reaction] = @NatureOfReaction, 
                                        [SavedBy] = @SavedBy, [SavedTime] = @SavedTime
		                                WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = allergy.id
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = allergy.Name
                command.Parameters.AddWithValue("@NatureOfReaction", SqlDbType.VarChar).Value = allergy.NatureOfReaction
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = allergy.SavedBy
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = allergy.SavedTime
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
    Sub DeleteIAllergy(ByVal id As Integer)
        Dim query As String = "DELETE FROM [dbo].[Allergy]
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
