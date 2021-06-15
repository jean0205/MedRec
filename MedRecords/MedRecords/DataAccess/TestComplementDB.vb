Imports System.Data.SqlClient
Imports System.Reflection

Public Class TestComplementDB
    Dim conString As String = My.Settings.connectString


    '########### SELETC Test ####################
    Function GetTestList(patientId As Integer) As List(Of TestComplement)
        Dim testList As New List(Of TestComplement)
        Dim query As String = "SELECT [Id],[PatientId],[VisitId],[Name],[Result],[TestDate]
                                  ,[Comments],[SavedBy],[SavedTime]
                              FROM [dbo].[TestComplementariy]
                              WHERE PatientId=@PatientId"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim test As New TestComplement
                Dim properties As List(Of PropertyInfo) = test.GetType().GetProperties().ToList
                While reader.Read
                    test = New TestComplement
                    For Each prop As PropertyInfo In properties
                        If prop.Name <> "File" AndAlso prop.Name <> "VisitDate" AndAlso Not reader.IsDBNull(reader.GetOrdinal(prop.Name)) Then
                            prop.SetValue(test, reader(prop.Name))
                        End If
                    Next
                    testList.Add(test)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return testList
    End Function
    Function GetTestListVisitView(patientId As Integer) As List(Of TestComplement)
        Dim testList As New List(Of TestComplement)
        Dim query As String = "SELECT T.Id, T.PatientId,[VisitId], V.VisitDate,[Name],[Result],[TestDate]
                                  ,[Comments],[SavedBy],[SavedTime]
                              FROM [dbo].[TestComplementariy] T full join Visit V on T.VisitId=V.Id
                              WHERE T.PatientId=@PatientId"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim test As New TestComplement
                Dim properties As List(Of PropertyInfo) = test.GetType().GetProperties().ToList
                While reader.Read
                    test = New TestComplement
                    For Each prop As PropertyInfo In properties
                        If prop.Name <> "File" AndAlso Not reader.IsDBNull(reader.GetOrdinal(prop.Name)) Then
                            prop.SetValue(test, reader(prop.Name))
                        End If
                    Next
                    testList.Add(test)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return testList
    End Function
    Function GetTestById(id As Integer) As TestComplement
        Dim test As New TestComplement
        Dim query As String = "SELECT *
                              FROM [dbo].[TestComplementariy]
                              WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim properties As List(Of PropertyInfo) = test.GetType().GetProperties().ToList
                While reader.Read
                    test = New TestComplement
                    For Each prop As PropertyInfo In properties
                        If prop.Name <> "VisitDate" AndAlso Not reader.IsDBNull(reader.GetOrdinal(prop.Name)) Then
                            prop.SetValue(test, reader(prop.Name))
                        End If
                    Next
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return test
    End Function
    Function getTestDocument(id As Integer) As Byte()
        Dim query As String = "SELECT [File] FROM [dbo].[TestComplementariy]
                               WHERE Id=@Id"
        Dim bytes As Byte()
        bytes = New Byte() {}
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
                Try
                    connection.Open()
                    Dim reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read Then
                        If Not IsDBNull(reader("File")) Then
                            bytes = DirectCast(reader("File"), Byte())
                        End If
                    End If
                        reader.Close()
                    connection.Close()
                    command.Dispose()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
        Return bytes
    End Function

    '########### INSERT Test ####################
    Sub insertTest(ByVal test As TestComplement)
        Dim query As String = "INSERT INTO [dbo].[TestComplementariy]
                                   ([PatientId],[VisitId],[Name],[Result],[TestDate],[Comments]
                                   ,[File],[SavedBy],[SavedTime])
                             VALUES
                                   (@PatientId, @VisitId, @Name, @Result, @Date, @Comments, 
		                           @File, @SavedBy, @SavedTime)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = test.PatientId
                command.Parameters.AddWithValue("@VisitId", SqlDbType.Int).Value = test.VisitId
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = test.Name
                command.Parameters.AddWithValue("@Result", SqlDbType.VarChar).Value = test.Result
                command.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = test.TestDate
                command.Parameters.AddWithValue("@Comments", SqlDbType.VarChar).Value = test.Comments
                command.Parameters.AddWithValue("@File", SqlDbType.VarBinary).Value = test.File
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = Form1.user.User
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = test.SavedTime
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
    Sub insertTestNoFile(ByVal test As TestComplement)
        Dim query As String = "INSERT INTO [dbo].[TestComplementariy]
                                   ([PatientId],[VisitId],[Name],[Result],[TestDate],[Comments]
                                   ,[SavedBy],[SavedTime])
                             VALUES
                                   (@PatientId, @VisitId, @Name, @Result, @Date, @Comments, 
		                           @SavedBy, @SavedTime)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = test.PatientId
                command.Parameters.AddWithValue("@VisitId", SqlDbType.Int).Value = test.VisitId
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = test.Name
                command.Parameters.AddWithValue("@Result", SqlDbType.VarChar).Value = test.Result
                command.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = test.TestDate
                command.Parameters.AddWithValue("@Comments", SqlDbType.VarChar).Value = test.Comments
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = Form1.user.User
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = test.SavedTime
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

    '########### UPDATE SURGERY ####################
    Sub updateTestFile(ByVal test As TestComplement)
        Dim query As String = "UPDATE [dbo].[TestComplementariy]
                               SET [Name] = @Name, [Result] = @Result, [TestDate] = @TestDate, 
                                    [Comments] = @Comments, [File] = @File, [SavedBy] = @SavedBy, [SavedTime] = @SavedTime
		                            WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = test.Id
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = test.Name
                command.Parameters.AddWithValue("@Result", SqlDbType.VarChar).Value = test.Result
                command.Parameters.AddWithValue("@TestDate", SqlDbType.Date).Value = test.TestDate
                command.Parameters.AddWithValue("@Comments", SqlDbType.VarChar).Value = test.Comments
                command.Parameters.AddWithValue("@File", SqlDbType.VarBinary).Value = test.File
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = Form1.user.User
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = test.SavedTime
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
    Sub updateTestNOFile(ByVal test As TestComplement)
        Dim query As String = "UPDATE [dbo].[TestComplementariy]
                               SET [Name] = @Name, [Result] = @Result, [TestDate] = @TestDate, 
                                    [Comments] = @Comments, [SavedBy] = @SavedBy, [SavedTime] = @SavedTime
		                            WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = test.Id
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = test.Name
                command.Parameters.AddWithValue("@Result", SqlDbType.VarChar).Value = test.Result
                command.Parameters.AddWithValue("@TestDate", SqlDbType.Date).Value = test.TestDate
                command.Parameters.AddWithValue("@Comments", SqlDbType.VarChar).Value = test.Comments
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = Form1.user.User
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = test.SavedTime
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

    '########### DELETE SURGERY ####################
    Sub DeleteTest(ByVal id As Integer)
        Dim query As String = "DELETE FROM [dbo].[TestComplementariy]
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
