Imports System.Data.SqlClient

Public Class ServiceDB

    Dim conString As String = My.Settings.connectString
    '########### SELETC PATIENT ####################
    Function GetSeriveList() As List(Of Service)
        Dim serviceList As New List(Of Service)
        Dim query As String = "SELECT [Id],[Name],[Description],[Cost]
                                FROM [dbo].[Service]"
        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read
                    Dim service As New Service
                    If Not reader.IsDBNull(0) Then
                        service.Id = reader(0)
                    End If
                    If Not reader.IsDBNull(1) Then
                        service.Name = reader(1)
                    End If
                    If Not reader.IsDBNull(2) Then
                        service.Description = reader(2)
                    End If
                    If Not reader.IsDBNull(3) Then
                        service.Cost = reader(3)
                    End If
                    serviceList.Add(service)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return serviceList
    End Function
    Function GetServiceById(id As Integer) As Service
        Dim service As New Service
        Dim query As String = "SELECT [Id],[Name],[Description],[Cost]
                                FROM [dbo].[Service]
                                    where Id=@Id"
        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read
                    If Not reader.IsDBNull(0) Then
                        service.Id = reader(0)
                    End If
                    If Not reader.IsDBNull(1) Then
                        service.Name = reader(1)
                    End If
                    If Not reader.IsDBNull(2) Then
                        service.Description = reader(2)
                    End If
                    If Not reader.IsDBNull(3) Then
                        service.Cost = reader(3)
                    End If
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return service
    End Function

    '########### INSERT PATIENT ####################
    Sub insertService(ByVal service As Service)
        Dim query As String = "INSERT INTO [dbo].[Service]
                                       ([Name],[Description],[Cost])
                                 VALUES
                                       (@Name, @Description, @Cost)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = service.Name
                command.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = service.Description
                command.Parameters.AddWithValue("@Cost", SqlDbType.Decimal).Value = service.Cost
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
    Sub updateService(ByVal service As Service)
        Dim query As String = "UPDATE [dbo].[Service]
                                       SET [Name] = @Name, [Description] = @Description, [Cost] = @Cost
                                     WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = service.Id
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = service.Name
                command.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = service.Description
                command.Parameters.AddWithValue("@Cost", SqlDbType.Decimal).Value = service.Cost
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
    Sub DeleteService(ByVal id As Integer)
        Dim query As String = "DELETE FROM [dbo].[Service]
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
