Imports System.Data.SqlClient

Public Class AppointmentDB
    Dim conString As String = My.Settings.connectString
    'SELECT APPOITMENT
    Function GetAppoitmentsByToday(appDate As Date) As List(Of Appoitmets)
        Dim appList As New List(Of Appoitmets)
        Dim query As String = "SELECT App.Id,[PatientId],p.[First Name],P.[Last Name],p.Phone1,
	                               [IsAppointment],[AppointmentTime],[StartTime],[EndTime],[Completed],[Comments]
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
                    If Not reader.IsDBNull(2) AndAlso Not reader.IsDBNull(3) Then
                        appt.PatientName = reader(2).ToString & " " & reader(2).ToString
                    End If
                    If Not reader.IsDBNull(4) Then
                        appt.Phone = reader(4)
                    End If
                    If Not reader.IsDBNull(5) Then
                        appt.Appoitment = reader(5)
                    End If
                    If Not reader.IsDBNull(6) Then
                        appt.StartTime = reader(6)
                    End If
                    If Not reader.IsDBNull(7) Then
                        appt.EndTime = reader(7)
                    End If
                    If Not reader.IsDBNull(8) Then
                        appt.Completed = reader(8)
                    End If
                    If Not reader.IsDBNull(9) Then
                        appt.Comments = reader(9)
                    End If
                    appList.Add(appt)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return appList
    End Function

    '########### INSERT Appoitment ####################
    Sub insertAppoitment(ByVal app As Appoitmets)
        Dim query As String = "INSERT INTO [dbo].[Appointment]
                                   ([PatientId],[IsAppointment],[AppointmentTime],[StartTime]
                                   ,[EndTime],[Completed],[Comments])
                             VALUES
                                   (@PatientId, @IsAppointment, @AppointmentTime, @StartTime, @EndTime, @Completed, @Comments)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = app.Patientid
                command.Parameters.AddWithValue("@IsAppointment", SqlDbType.Bit).Value = app.Appoitment
                command.Parameters.AddWithValue("@AppointmentTime", SqlDbType.DateTime).Value = app.AppoitmentTime
                command.Parameters.AddWithValue("@StartTime", SqlDbType.DateTime).Value = app.StartTime
                command.Parameters.AddWithValue("@EndTime", SqlDbType.DateTime).Value = app.EndTime
                command.Parameters.AddWithValue("@Completed", SqlDbType.Bit).Value = app.Completed
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
End Class
