Imports System.Data.SqlClient
Imports System.Reflection

Public Class UserDB
    Dim conString As String = My.Settings.connectString

    '########### INSERT Appoitment ####################
    Sub insertUser(ByVal user As Users)
        Dim query As String = "INSERT INTO [dbo].[UserAccess]
                                       ([Name],[User],[Password],[Users],[PatientFile],[Visits]
                                       ,[Services],[Surgeries],[Expenses],[Reports],[Sams],[Backup],[Restore])
                                 VALUES
                                       (@Name, @User, @Password, @Users, @PatientFile, @Visits,
		                               @Services,@Surgeries, @Expenses, @Reports, @Sams, @Backup, @Restore)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = user.Name
                command.Parameters.AddWithValue("@User", SqlDbType.VarChar).Value = user.User
                command.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = user.Password
                command.Parameters.AddWithValue("@Users", SqlDbType.Bit).Value = user.Users
                command.Parameters.AddWithValue("@PatientFile", SqlDbType.Bit).Value = user.PatientFile
                command.Parameters.AddWithValue("@Visits", SqlDbType.Bit).Value = user.Visits
                command.Parameters.AddWithValue("@Services", SqlDbType.Bit).Value = user.Services
                command.Parameters.AddWithValue("@Surgeries", SqlDbType.Bit).Value = user.Surgeries
                command.Parameters.AddWithValue("@Expenses", SqlDbType.Bit).Value = user.Expenses
                command.Parameters.AddWithValue("@Reports", SqlDbType.Bit).Value = user.Reports
                command.Parameters.AddWithValue("@Sams", SqlDbType.Bit).Value = user.Sams
                command.Parameters.AddWithValue("@Backup", SqlDbType.Bit).Value = user.Backup
                command.Parameters.AddWithValue("@Restore", SqlDbType.Bit).Value = user.Restore
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

    '########### SELETC users List ####################
    Function GetUserList() As List(Of Users)
        Dim userList As New List(Of Users)
        Dim query As String = "SELECT [Id],[Name],[User],[Password],[Users],[PatientFile],[Visits]
                                  ,[Services],[Surgeries],[Expenses],[Reports],[Sams],[Backup],[Restore]
                              FROM [dbo].[UserAccess]"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)

            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim user As New Users
                Dim properties As List(Of PropertyInfo) = user.GetType().GetProperties().ToList
                While reader.Read
                    user = New Users
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(properties.IndexOf(prop)) Then
                            prop.SetValue(user, reader(properties.IndexOf(prop)))
                        End If
                    Next
                    userList.Add(user)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return userList
    End Function
    Function GetUserById(id As Integer) As Users
        Dim user As New Users
        Dim query As String = "SELECT [Id],[Name],[User],[Password],[Users],[PatientFile],[Visits]
                                  ,[Services],[Surgeries],[Expenses],[Reports],[Sams],[Backup],[Restore]
                              FROM [dbo].[UserAccess]
                                Where Id =@Id"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim properties As List(Of PropertyInfo) = user.GetType().GetProperties().ToList
                While reader.Read
                    user = New Users
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(properties.IndexOf(prop)) Then
                            prop.SetValue(user, reader(properties.IndexOf(prop)))
                        End If
                    Next
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return user
    End Function
    Function GetUserByUserName(userName As String) As Users
        Dim user As New Users
        Dim query As String = "SELECT [Id],[Name],[User],[Password],[Users],[PatientFile],[Visits]
                                  ,[Services],[Surgeries],[Expenses],[Reports],[Sams],[Backup],[Restore]
                              FROM [dbo].[UserAccess]
                                Where [User] =@User"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@User", SqlDbType.VarChar).Value = userName
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim properties As List(Of PropertyInfo) = user.GetType().GetProperties().ToList
                While reader.Read
                    user = New Users
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(properties.IndexOf(prop)) Then
                            prop.SetValue(user, reader(properties.IndexOf(prop)))
                        End If
                    Next
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return user
    End Function
    Function validLoging(user As String, pasword As String) As Boolean
        Dim resul As Boolean = False
        Dim query As String = "SELECT *
                              FROM [dbo].[UserAccess]
                                Where [User] =@User and Password=@Password"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@User", SqlDbType.VarChar).Value = user
            command.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = pasword
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                resul = reader.Read
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return resul
    End Function

    Sub updateUserandPassword(id As Integer, name As String, user As String, password As String)
        Dim query As String = "UPDATE [dbo].[UserAccess]
                                    SET [Name] = @Name, [User] = @User, [Password] = @Password
	                               WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)

                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = name
                command.Parameters.AddWithValue("@User", SqlDbType.VarChar).Value = user
                command.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = password
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
    Sub updateUserAccess(user As Users)
        Dim query As String = "UPDATE [dbo].[UserAccess]
                                   SET [Users] = @Users, [PatientFile] = @PatientFile, [Visits] = @Visits,
                                   [Services] = @Services,[Surgeries]=@Surgeries, [Expenses] = @Expenses, [Reports] = @Reports,
                                   [Sams] = @Sams, [Backup] = @Backup, [Restore] = @Restore
	                               WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = user.id
                command.Parameters.AddWithValue("@Users", SqlDbType.Bit).Value = user.Users
                command.Parameters.AddWithValue("@PatientFile", SqlDbType.Bit).Value = user.PatientFile
                command.Parameters.AddWithValue("@Visits", SqlDbType.Bit).Value = user.Visits
                command.Parameters.AddWithValue("@Services", SqlDbType.Bit).Value = user.Services
                command.Parameters.AddWithValue("@Surgeries", SqlDbType.Bit).Value = user.Surgeries
                command.Parameters.AddWithValue("@Expenses", SqlDbType.Bit).Value = user.Expenses
                command.Parameters.AddWithValue("@Reports", SqlDbType.Bit).Value = user.Reports
                command.Parameters.AddWithValue("@Sams", SqlDbType.Bit).Value = user.Sams
                command.Parameters.AddWithValue("@Backup", SqlDbType.Bit).Value = user.Backup
                command.Parameters.AddWithValue("@Restore", SqlDbType.Bit).Value = user.Restore
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
    '########### DELETE USER ####################
    Sub DeleteUser(ByVal id As Integer)
        Dim query As String = "DELETE FROM [dbo].[UserAccess]
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
