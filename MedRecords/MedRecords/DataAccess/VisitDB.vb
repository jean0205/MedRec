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


    'VISIT REPORTS

    '########### Get PATIENT VISIT LIST ####################
    Async Function GetVisitTable() As Task(Of DataTable)
        Dim query As String = "SELECT V.Id,[PatientId],concat (P.[First Name],' ',P.[Last Name]),[VisitDate],[ServicesId],
                                    [ServiceTotal],[OtherServices],[OSCharges],[Disscount],[ToPay],[Paid],[Oustanding]
                              FROM [dbo].[Visit] V inner join Patient P on V.PatientId=p.Id
                                order by VisitDate desc"
        Dim table As New DataTable
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    Dim reader As SqlDataReader = Await command.ExecuteReaderAsync()
                    table.Load(reader)
                    reader.Close()
                    connection.Close()
                    command.Dispose()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
        Return table
    End Function

    'VISIT DASHBOARD

    '########### Get PATIENT VISIT LIST ####################
    Async Function GetVisitTabledASH() As Task(Of DataTable)
        Dim query As String = "SELECT [PatientId],concat (P.[First Name],' ',P.[Last Name]), P.[Date OB],P.[Paper Record],
                                        p.[Registration Date] ,V.Id,[VisitDate],[ServicesId],
                                        [ServiceTotal],[OtherServices],[OSCharges],[Disscount],
                                        [ToPay],[Paid],[Oustanding]
                               FROM [dbo].[Visit] V inner join Patient P on V.PatientId=p.Id"
        Dim table As New DataTable
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    Dim reader As SqlDataReader = Await command.ExecuteReaderAsync()
                    table.Load(reader)
                    reader.Close()
                    connection.Close()
                    command.Dispose()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
        Return table
    End Function


    Async Function GetPatientListAsync(active As Boolean) As Task(Of List(Of PatientE))
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
                Dim reader As SqlDataReader = Await command.ExecuteReaderAsync()
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
End Class
