Imports System.Data.SqlClient
Imports System.Reflection

Public Class PregnacyDB
    Dim conString As String = My.Settings.connectString


    '########### SELETC Pregnancy ####################
    Function GetPregnancyList(patientId As Integer) As List(Of Pregnacy)
        Dim pregnancyList As New List(Of Pregnacy)
        Dim query As String = "SELECT *
                              FROM [dbo].[Pregnacy]
                              WHERE PatientId=@PatientId"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim pregnancy As New Pregnacy
                Dim properties As List(Of PropertyInfo) = pregnancy.GetType().GetProperties().ToList
                While reader.Read
                    pregnancy = New Pregnacy
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(properties.IndexOf(prop)) Then
                            prop.SetValue(pregnancy, reader(properties.IndexOf(prop)))
                        End If
                    Next
                    pregnancyList.Add(pregnancy)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return pregnancyList
    End Function
    Function GetPregnancyById(id As Integer) As Pregnacy
        Dim pregnancy As New Pregnacy
        Dim query As String = "SELECT *
                              FROM [dbo].[Surgery]
                              WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim properties As List(Of PropertyInfo) = pregnancy.GetType().GetProperties().ToList
                While reader.Read
                    pregnancy = New Pregnacy
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(properties.IndexOf(prop)) Then
                            prop.SetValue(pregnancy, reader(properties.IndexOf(prop)))
                        End If
                    Next
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return pregnancy
    End Function

    '########### INSERT SURGERY ####################
    Sub insertPregnancy(ByVal pregnancy As Pregnacy)
        Dim query As String = "INSERT INTO [dbo].[Pregnacy]
                               ([PatientId],[PregnancyDate],[Normal],[CSection],[Miscarriage],[SavedBy],[SavedTime])
                         VALUES
                               (@PatientId, @PregnancyDate, @Normal, @CSection, @Miscarriage, @SavedBy, @SavedTime)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = pregnancy.PatientId
                command.Parameters.AddWithValue("@PregnancyDate", SqlDbType.Date).Value = pregnancy.PregnancyDate
                command.Parameters.AddWithValue("@Normal", SqlDbType.Bit).Value = pregnancy.Normal
                command.Parameters.AddWithValue("@CSection", SqlDbType.Bit).Value = pregnancy.CSection
                command.Parameters.AddWithValue("@Miscarriage", SqlDbType.Bit).Value = pregnancy.Miscarriage
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = pregnancy.SavedBy
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = pregnancy.SavedTime
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
    Sub updateSurgery(ByVal pregnancy As Pregnacy)
        Dim query As String = "UPDATE [dbo].[Pregnacy]
                               SET [PregnancyDate] = @PregnancyDate, [Normal] = @Normal, [CSection] = @CSection, 
                                    [Miscarriage] = @Miscarriage, 
                                    [SavedBy] = @SavedBy, [SavedTime] = @SavedTime
	                               WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = pregnancy.Id
                command.Parameters.AddWithValue("@PregnancyDate", SqlDbType.Date).Value = pregnancy.PregnancyDate
                command.Parameters.AddWithValue("@Normal", SqlDbType.Bit).Value = pregnancy.Normal
                command.Parameters.AddWithValue("@CSection", SqlDbType.Bit).Value = pregnancy.CSection
                command.Parameters.AddWithValue("@Miscarriage", SqlDbType.Bit).Value = pregnancy.Miscarriage
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = pregnancy.SavedBy
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = pregnancy.SavedTime
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
        Dim query As String = "DELETE FROM [dbo].[Pregnacy]
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
