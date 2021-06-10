Imports System.Data.SqlClient

Public Class SamsDB
    Dim conString As String = My.Settings.connectString
    Async Function GetPatientsSamsTableMonth(dates As Date) As Task(Of DataTable)
        Dim query As String = "SELECT [Id]
                                      ,[PatientName]
                                      ,[Service]
                                      ,[Date]
                                      ,[Cost]
                                  FROM [dbo].[Patient_Sams]
                                  WHERE MONTH([Date])=@Month and YEAR([Date])=@Year"
        Dim table As New DataTable
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Month", SqlDbType.VarChar).Value = dates.Month
                command.Parameters.AddWithValue("@Year", SqlDbType.VarChar).Value = dates.Year
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
    Async Function GetPatientsSamsTableAll() As Task(Of DataTable)
        Dim query As String = "SELECT [Id]
                                      ,[PatientName]
                                      ,[Service]
                                      ,[Date]
                                      ,[Cost]
                                  FROM [dbo].[Patient_Sams]"
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
    Async Function GetPatientsSamsTablePeriod(date1 As Date, date2 As Date) As Task(Of DataTable)
        Dim query As String = "SELECT [Id]
                                      ,[PatientName]
                                      ,[Service]
                                      ,[Date]
                                      ,[Cost]
                                  FROM [dbo].[Patient_Sams]
                                  WHERE [Date] Between @Date1 and @Date2"
        Dim table As New DataTable
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Date1", SqlDbType.VarChar).Value = date1
                command.Parameters.AddWithValue("@Date2", SqlDbType.VarChar).Value = date2
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

    Sub insertPatientSams(PatientName As String, Service As String, DateS As String, Cost As Decimal)
        Dim query As String = "INSERT INTO [dbo].[Patient_Sams]
                                   ([PatientName],[Service],[Date],[Cost])
                             VALUES
                                   (@PatientName, @Service, @Date, @Cost)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientName", SqlDbType.VarChar).Value = PatientName
                command.Parameters.AddWithValue("@Service", SqlDbType.VarChar).Value = Service
                command.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = DateS
                command.Parameters.AddWithValue("@Cost", SqlDbType.Decimal).Value = Cost
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

    Sub DeletePatientSams(ByVal id As Integer)
        Dim query As String = "DELETE FROM [dbo].[Patient_Sams]
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

    '################ SAMS SURGERIES##########################

    Async Function GetSamsSurgeryTableMonth(dates As Date) As Task(Of DataTable)
        Dim query As String = "SELECT [Id]
                                      ,[PatientName]
                                      ,[Surgery]
                                      ,[Date]
                                      ,[Paid]
                                  FROM [dbo].[Surgery_Sams]
                                  WHERE MONTH([Date])=@Month and YEAR([Date])=@Year"
        Dim table As New DataTable
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Month", SqlDbType.VarChar).Value = dates.Month
                command.Parameters.AddWithValue("@Year", SqlDbType.VarChar).Value = dates.Year
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

    Async Function GetSurgerySamsTableAll() As Task(Of DataTable)
        Dim query As String = "SELECT [Id]
                                      ,[PatientName]
                                      ,[Surgery]
                                      ,[Date]
                                      ,[Paid]
                                  FROM [dbo].[Surgery_Sams]"
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
    Async Function GetSurgerySamsTablePeriod(date1 As Date, date2 As Date) As Task(Of DataTable)
        Dim query As String = "SELECT [Id]
                                      ,[PatientName]
                                      ,[Surgery]
                                      ,[Date]
                                      ,[Paid]
                                  FROM [dbo].[Surgery_Sams]
                                  WHERE [Date] Between @Date1 and @Date2"
        Dim table As New DataTable
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Date1", SqlDbType.VarChar).Value = date1
                command.Parameters.AddWithValue("@Date2", SqlDbType.VarChar).Value = date2
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
    Sub insertSurgerySams(PatientName As String, Surgery As String, DateS As String, Paid As Decimal)
        Dim query As String = "INSERT INTO [dbo].[Surgery_Sams]
                                   ([PatientName],[Surgery],[Date],[Paid])
                             VALUES
                                   (@PatientName, @Surgery, @Date, @Paid)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientName", SqlDbType.VarChar).Value = PatientName
                command.Parameters.AddWithValue("@Surgery", SqlDbType.VarChar).Value = Surgery
                command.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = DateS
                command.Parameters.AddWithValue("@Paid", SqlDbType.Decimal).Value = Paid
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
    Sub DeleteSurgerySams(ByVal id As Integer)
        Dim query As String = "DELETE FROM [dbo].[Surgery_Sams]
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

    '################ Expenses ##########################

    Async Function GetExpensesMonth(dates As Date) As Task(Of DataTable)
        Dim query As String = "SELECT  [Id]
                                      ,[Date]
                                      ,[Expense]
                                      ,[Cost]
                                  FROM [dbo].[Expenses]
                                  WHERE MONTH([Date])=@Month and YEAR([Date])=@Year"
        Dim table As New DataTable
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Month", SqlDbType.VarChar).Value = dates.Month
                command.Parameters.AddWithValue("@Year", SqlDbType.VarChar).Value = dates.Year
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

    Async Function GetExpensesAll() As Task(Of DataTable)
        Dim query As String = "SELECT [Id]
                                  ,[Date]
                                  ,[Expense]
                                  ,[Cost]
                              FROM [dbo].[Expenses]"
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
    Async Function GetExpensesPeriod(date1 As Date, date2 As Date) As Task(Of DataTable)
        Dim query As String = "SELECT [Id]
                                      ,[Date]
                                      ,[Expense]
                                      ,[Cost]
                                  FROM [dbo].[Expenses]
                                  WHERE [Date] Between @Date1 and @Date2"
        Dim table As New DataTable
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Date1", SqlDbType.VarChar).Value = date1
                command.Parameters.AddWithValue("@Date2", SqlDbType.VarChar).Value = date2
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
    Sub insertExpense(expenses As String, DateS As String, Paid As Decimal)
        Dim query As String = "INSERT INTO [dbo].[Expenses]
                                       ([Date],[Expense],[Cost])
                                 VALUES
                                       (@Date, @Expense, @Cost)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Expense", SqlDbType.VarChar).Value = expenses
                command.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = DateS
                command.Parameters.AddWithValue("@Cost", SqlDbType.Decimal).Value = Paid
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
    Sub DeleteExpense(ByVal id As Integer)
        Dim query As String = "DELETE FROM [dbo].[Expenses]
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
