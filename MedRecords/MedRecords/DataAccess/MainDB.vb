Imports System.Data.SqlClient

Public Class MainDB
    Dim conString As String = My.Settings.connectString

    'Select the list of ptients
    Async Function GetPatientList(active As Boolean) As Task(Of DataTable)
        Dim table As New DataTable
        Dim query As String = "SELECT [Id],[First Name],[Last Name],[Others Name],[Address],[Parish]
                              ,[Date OB]
	                          FROM [dbo].[Patient]
	                          WHERE ACTIVE =@ACTIVE"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@ACTIVE", SqlDbType.Bit).Value = active
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
        Return table
    End Function

End Class
