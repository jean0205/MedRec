Imports System.Data.SqlClient
Imports System.Reflection

Public Class VisitDB

    Dim conString As String = My.Settings.connectString

    '########### Get PATIENT VISIT LIST ####################
    Function GetPatientVisitList(patientId As Integer) As List(Of VisitE)
        Dim visitLis As New List(Of VisitE)
        Dim query As String = "SELECT [Id],[PatientId],[ServicesId],[VisitDate],[RespiratoryRate],[HeartRate]
                                  ,[BloodPAlta],[BloodPBaja],[SpO2],[Temperature],[PhysicalExam],[PatientComplain]
                                  ,[Diagnosis],[Plan],[ServiceTotal],[OtherServices],[OSCharges],[Disscount],[ToPay],
                                   [Paid],[Oustanding]
                              FROM [dbo].[Visit]
                                  where PatientId =@PatientId"
        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim visit As New VisitE
                Dim properties As List(Of PropertyInfo) = visit.GetType().GetProperties().ToList
                While reader.Read
                    visit = New VisitE
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(properties.IndexOf(prop)) Then
                            prop.SetValue(visit, reader(properties.IndexOf(prop)))
                        End If
                    Next
                    visitLis.Add(visit)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return visitLis
    End Function

    'GET VISIT BY ID
    Function GetVisitById(visitId As Integer) As VisitE
        Dim visit As New VisitE
        Dim query As String = "SELECT [Id],[PatientId],[ServicesId],[VisitDate],[RespiratoryRate],[HeartRate]
                                  ,[BloodPAlta],[BloodPBaja],[SpO2],[Temperature],[PhysicalExam],[PatientComplain]
                                  ,[Diagnosis],[Plan],[ServiceTotal],[OtherServices],[OSCharges],[Disscount],[ToPay],
                                   [Paid],[Oustanding]
                              FROM [dbo].[Visit]
                                  where Id =@Id"
        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = visitId
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim properties As List(Of PropertyInfo) = visit.GetType().GetProperties().ToList
                If reader.Read Then
                    visit = New VisitE
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(properties.IndexOf(prop)) Then
                            prop.SetValue(visit, reader(properties.IndexOf(prop)))
                        End If
                    Next
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return visit
    End Function

    '########### CREATE VISIT FIRST TIME ####################
    Sub createVisit(patientId As Integer)
        Dim query As String = "INSERT INTO [dbo].[Visit]
                                   ([PatientId],[VisitDate])
                             VALUES
                                   (@PatientId, @VisitDate)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
                command.Parameters.AddWithValue("@VisitDate", SqlDbType.DateTime).Value = Now
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

    'GET VISITID PARA SALVAR MEDICAMENTOS Y COMPLEMENTARIOS
    Function GetVisitId() As Integer
        Dim query As String = "SELECT max(Id) 
                                FROM [MedicalRecords].[dbo].[Visit]"
        Dim visitId As Integer = 0
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    Dim reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read Then
                        visitId = reader(0)
                    End If
                    reader.Close()
                    connection.Close()
                    command.Dispose()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
        Return visitId
    End Function

    '########### UPDATE VISIT ####################
    Sub updateVisit(ByVal visit As VisitE)
        Dim query As String = "UPDATE [dbo].[Visit]
                       SET [ServicesId] = @ServicesId, [VisitDate] = @VisitDate, [RespiratoryRate] = @RespiratoryRate, [HeartRate] = @HeartRate, 
                           [BloodPAlta] = @BloodPAlta, [BloodPBaja] = @BloodPBaja, [SpO2] = @SpO2, 
	                       [Temperature] = @Temperature, [PhysicalExam] = @PhysicalExam, [PatientComplain] = @PatientComplain,
	                       [Diagnosis] = @Diagnosis, [Plan] = @Plan, [ServiceTotal] = @ServiceTotal, [OtherServices] = @OtherServices, 
	                       [OSCharges] = @OSCharges, [Disscount] = @Disscount, [ToPay] = @ToPay, [Paid] = @Paid, [Oustanding] = @Oustanding
                     WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = visit.Id
                command.Parameters.AddWithValue("@ServicesId", SqlDbType.VarChar).Value = visit.ServicesId
                command.Parameters.AddWithValue("@VisitDate", SqlDbType.DateTime).Value = visit.VisitDate
                command.Parameters.AddWithValue("@RespiratoryRate", SqlDbType.Int).Value = visit.RespiratoryRate
                command.Parameters.AddWithValue("@HeartRate", SqlDbType.Int).Value = visit.HeartRate
                command.Parameters.AddWithValue("@BloodPAlta", SqlDbType.Int).Value = visit.BloodPAlta
                command.Parameters.AddWithValue("@BloodPBaja", SqlDbType.Int).Value = visit.BloodPBaja
                command.Parameters.AddWithValue("@SpO2", SqlDbType.Int).Value = visit.SpO2
                command.Parameters.AddWithValue("@Temperature", SqlDbType.Decimal).Value = visit.Temperature
                command.Parameters.AddWithValue("@PhysicalExam", SqlDbType.VarChar).Value = visit.PhysicalExam
                command.Parameters.AddWithValue("@PatientComplain", SqlDbType.VarChar).Value = visit.PatientComplain
                command.Parameters.AddWithValue("@Diagnosis", SqlDbType.VarChar).Value = visit.Diagnosis
                command.Parameters.AddWithValue("@Plan", SqlDbType.VarChar).Value = visit.Plan
                command.Parameters.AddWithValue("@ServiceTotal", SqlDbType.Decimal).Value = visit.ServiceTotal
                command.Parameters.AddWithValue("@OtherServices", SqlDbType.VarChar).Value = visit.otherServices
                command.Parameters.AddWithValue("@OSCharges", SqlDbType.Decimal).Value = visit.OSCharges
                command.Parameters.AddWithValue("@Disscount", SqlDbType.Decimal).Value = visit.Disscount
                command.Parameters.AddWithValue("@ToPay", SqlDbType.Decimal).Value = visit.ToPay
                command.Parameters.AddWithValue("@Paid", SqlDbType.Decimal).Value = visit.Paid
                command.Parameters.AddWithValue("@Oustanding", SqlDbType.Decimal).Value = visit.Oustanding
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

    '#########OUTSTANDINGS###################
    Function GetPatientOutstanding(PatientId As Integer) As Decimal
        Dim outstanding As Decimal = 0.00
        Dim query As String = "SELECT sum([Oustanding])
                            FROM [MedicalRecords].[dbo].[Visit]
                            WHERE [PatientId]=@PatientId"
        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = PatientId
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                If reader.Read Then
                    outstanding = If(Not IsDBNull(reader(0)), CDec(reader(0)), 0.00)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return outstanding
    End Function
    '########### DELETE Visit ####################
    Sub DeleteVisit(ByVal id As Integer)
        Dim query As String = "DELETE FROM [dbo].[Visit]
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
