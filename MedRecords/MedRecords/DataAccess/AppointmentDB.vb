Imports System.Data.SqlClient

Public Class AppointmentDB
    Dim conString As String = My.Settings.connectString
    'SELECT APPOITMENT
    Function GetAppoitmentsByDate(appDate As Date) As List(Of Appoitmets)
        Dim appList As New List(Of Appoitmets)
        Dim query As String = "SELECT App.Id,[PatientId],VisitId, p.[First Name],P.[Last Name],p.Phone1,
	                               [AppointmentTime],[StartTime],[EndTime],[Completed],[Comments]
                              FROM [dbo].[Appointment] App inner join Patient P on App.PatientId=p.Id
                              where CAST(AppointmentTime AS date)=@AppointmentTime"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@AppointmentTime", SqlDbType.DateTime).Value = appDate
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read
                    Dim appt As New Appoitmets
                    If Not reader.IsDBNull(0) Then
                        appt.id = reader(0)
                    End If
                    If Not reader.IsDBNull(1) Then
                        appt.Patientid = reader(1)
                    End If
                    If Not reader.IsDBNull(2) Then
                        appt.VisitId = reader(2)
                    End If
                    If Not reader.IsDBNull(3) AndAlso Not reader.IsDBNull(4) Then
                        appt.PatientName = reader(3).ToString & " " & reader(4).ToString
                    End If
                    If Not reader.IsDBNull(5) Then
                        appt.Phone = reader(5)
                    End If
                    If Not reader.IsDBNull(6) Then
                        appt.AppoitmentTime = reader(6)
                    End If
                    If Not reader.IsDBNull(7) Then
                        appt.StartTime = reader(7)
                    End If
                    If Not reader.IsDBNull(8) Then
                        appt.EndTime = reader(8)
                    End If
                    If Not reader.IsDBNull(9) Then
                        appt.Completed = reader(9)
                    End If
                    If Not reader.IsDBNull(10) Then
                        appt.Comments = reader(10)
                    End If
                    appList.Add(appt)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return appList
    End Function
    Function GetAppoitmentsByiD(Id As Integer) As Appoitmets
        Dim appt As New Appoitmets
        Dim query As String = "SELECT App.Id,[PatientId],VisitId, p.[First Name],P.[Last Name],p.Phone1,
	                            [AppointmentTime],[StartTime],[EndTime],[Completed],[Comments]
                              FROM [dbo].[Appointment] App inner join Patient P on App.PatientId=p.Id
                               WHERE App.Id=@Id"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Id
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                If reader.Read Then
                    If Not reader.IsDBNull(0) Then
                        appt.id = reader(0)
                    End If
                    If Not reader.IsDBNull(1) Then
                        appt.Patientid = reader(1)
                    End If
                    If Not reader.IsDBNull(2) Then
                        appt.VisitId = reader(2)
                    End If
                    If Not reader.IsDBNull(3) AndAlso Not reader.IsDBNull(4) Then
                        appt.PatientName = reader(3).ToString & " " & reader(4).ToString
                    End If
                    If Not reader.IsDBNull(5) Then
                        appt.Phone = reader(5)
                    End If
                    If Not reader.IsDBNull(6) Then
                        appt.AppoitmentTime = reader(6)
                    End If
                    If Not reader.IsDBNull(7) Then
                        appt.StartTime = reader(7)
                    End If
                    If Not reader.IsDBNull(8) Then
                        appt.EndTime = reader(8)
                    End If
                    If Not reader.IsDBNull(9) Then
                        appt.Completed = reader(9)
                    End If
                    If Not reader.IsDBNull(10) Then
                        appt.Comments = reader(10)
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return appt
    End Function

    '########### INSERT Appoitment ####################
    Sub insertAppoitment(ByVal app As Appoitmets)
        Dim query As String = "INSERT INTO [dbo].[Appointment]
                                   ([PatientId],[AppointmentTime],[Comments])
                             VALUES
                                   (@PatientId,@AppointmentTime, @Comments)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = app.Patientid
                command.Parameters.AddWithValue("@AppointmentTime", SqlDbType.DateTime).Value = app.AppoitmentTime
                command.Parameters.AddWithValue("@Comments", SqlDbType.VarChar).Value = app.Comments
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
    '########### UPDATE APPOITMENT ####################
    Sub updateAppoitmentTimeandComments(ByVal appoitment As Appoitmets)
        Dim query As String = "UPDATE [dbo].[Appointment]
                               SET [AppointmentTime] = @AppointmentTime, [Comments] = @Comments
                             WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = appoitment.id
                command.Parameters.AddWithValue("@AppointmentTime", SqlDbType.DateTime).Value = appoitment.AppoitmentTime
                command.Parameters.AddWithValue("@Comments", SqlDbType.VarChar).Value = appoitment.Comments
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
    Sub chekIn(appId As Integer)
        Dim query As String = "UPDATE [dbo].[Appointment]
                               SET  [StartTime] = @StartTime		                            
                             WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = appId
                command.Parameters.AddWithValue("@StartTime", SqlDbType.DateTime).Value = Now
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
    Sub checkOut(appId As Integer)
        Dim query As String = "UPDATE [dbo].[Appointment]
                               SET [EndTime] = @EndTime, [Completed] = @Completed
                             WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = appId
                command.Parameters.AddWithValue("@EndTime", SqlDbType.DateTime).Value = Now
                command.Parameters.AddWithValue("@Completed", SqlDbType.Bit).Value = True
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
    Sub updateAppoitmentVisitId(id As Integer, visitId As Integer)
        Dim query As String = "UPDATE [dbo].[Appointment]
                               SET [VisitId] = @VisitId
                             WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
                command.Parameters.AddWithValue("@VisitId", SqlDbType.Int).Value = visitId
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


    '########### DELETE APPOITMENT ####################
    Sub DeleteIAppoitment(ByVal id As Integer)
        Dim query As String = "DELETE FROM [dbo].[Appointment]
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
