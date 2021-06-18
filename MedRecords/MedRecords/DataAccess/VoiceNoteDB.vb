Imports System.Data.SqlClient
Imports System.Reflection

Public Class VoiceNoteDB
    Dim conString As String = My.Settings.connectString
    Sub insertVoiceNoteVisit(ByVal voice As VoiceNote)
        Dim query As String = "INSERT INTO [dbo].[VoiceNotes]
                                       ([PatientId],[VisitId],[Name],[Duration],[File],[RecordDate])
                                 VALUES
                                       (@PatientId, @VisitId, @Name, @Duration,@File, @RecordDate)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = voice.PatientId
                command.Parameters.AddWithValue("@VisitId", SqlDbType.Int).Value = voice.VisitId
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = voice.Name
                command.Parameters.AddWithValue("@Duration", SqlDbType.Decimal).Value = voice.Duration
                command.Parameters.AddWithValue("@File", SqlDbType.VarBinary).Value = voice.File
                command.Parameters.AddWithValue("@RecordDate", SqlDbType.DateTime).Value = voice.RecordDate
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
    Sub insertVoiceNotePatient(ByVal voice As VoiceNote)
        Dim query As String = "INSERT INTO [dbo].[VoiceNotes]
                                       ([PatientId],[Name],[Duration],[File],[RecordDate])
                                 VALUES
                                       (@PatientId, @Name,@Duration, @File, @RecordDate)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = voice.PatientId
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = voice.Name
                command.Parameters.AddWithValue("@Duration", SqlDbType.Decimal).Value = voice.Duration
                command.Parameters.AddWithValue("@File", SqlDbType.VarBinary).Value = voice.File
                command.Parameters.AddWithValue("@RecordDate", SqlDbType.DateTime).Value = voice.RecordDate
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

    Function GetVoiceListVisit(patientId As Integer, visitId As Integer) As List(Of VoiceNote)
        Dim voiceList As New List(Of VoiceNote)
        Dim query As String = "SELECT *
	                              FROM [dbo].[VoiceNotes]
	                              where PatientId= @PatientId and VisitId= @VisitId"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
            command.Parameters.AddWithValue("@VisitId", SqlDbType.Int).Value = visitId
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim voice As New VoiceNote
                Dim properties As List(Of PropertyInfo) = voice.GetType().GetProperties().ToList
                While reader.Read
                    voice = New VoiceNote
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(reader.GetOrdinal(prop.Name)) Then
                            prop.SetValue(voice, reader(prop.Name))
                        End If
                    Next
                    voiceList.Add(voice)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return voiceList
    End Function
    Function GetVoiceListPatient(patientId As Integer, visitId As Integer) As List(Of VoiceNote)
        Dim voiceList As New List(Of VoiceNote)
        Dim query As String = "SELECT *
	                              FROM [dbo].[VoiceNotes]
	                              where PatientId= @PatientId"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
            command.Parameters.AddWithValue("@VisitId", SqlDbType.Int).Value = visitId
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim voice As New VoiceNote
                Dim properties As List(Of PropertyInfo) = voice.GetType().GetProperties().ToList
                While reader.Read
                    voice = New VoiceNote
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(reader.GetOrdinal(prop.Name)) Then
                            prop.SetValue(voice, reader(prop.Name))
                        End If
                    Next
                    voiceList.Add(voice)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return voiceList
    End Function
    Sub updateVoiceName(ByVal test As TestComplement)
        Dim query As String = "UPDATE [dbo].[VoiceNotes]
                                    SET [Name] = @Name
		                            WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = test.Id
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = test.Name
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
    Sub DeleteVoiceById(ByVal id As Integer)
        Dim query As String = "DELETE FROM [dbo].[VoiceNotes]
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
    Sub DeleteVoiceByVisitId(ByVal VisitId As Integer)
        Dim query As String = "DELETE FROM [dbo].[VoiceNotes]
                               WHERE VisitId= @VisitId"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@VisitId", SqlDbType.Int).Value = VisitId
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
