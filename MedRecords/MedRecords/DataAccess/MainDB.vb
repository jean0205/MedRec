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

    'Dim WithEvents RS As New SQLDMO.Restore
    'Dim oSQL As New SQLDMO.SQLServer
    Sub backupDatabase(ByVal path As String)

        Dim query As String = "DECLARE @BackupFile varchar(100)
                SET @BackupFile = " & path & "
                BACKUP DATABASE MedicalRecords to disk = @BackupFile"

        Dim query2 As String = "DECLARE @BackupFile varchar(100)" +
                " SET @BackupFile = 'C:\\Database\\Clinic_' +" +
                " REPLACE(convert(nvarchar(20), GetDate(), 120), ':', '-') + " +
                "'.BAK' " +
                "BACKUP DATABASE MedicalRecords to disk = @BackupFile"


        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
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
    Sub RestoreDatabase(ByVal path As String)

        Dim query As String = "USE master
                                Alter database MedicalRecords  Set offline With rollback immediate 
                RESTORE DATABASE MedicalRecords FROM DISK ='" + path + "' WITH REPLACE alter database MedicalRecords set online"

        Dim query2 As String = "Declare @BackupFile varchar(100)" +
                " Set @BackupFile = 'C:\\Database\\Clinic_' +" +
                " REPLACE(convert(nvarchar(20), GetDate(), 120), ':', '-') + " +
                "'.BAK' " +
                "BACKUP DATABASE MedicalRecords to disk = @BackupFile"


        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
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
