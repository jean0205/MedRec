Imports System.Data.SqlClient
Imports System.Reflection

Public Class FamilyHistDB

    Dim conString As String = My.Settings.connectString
    '########### INSERT Contraceptive ####################
    Sub insertFamily(ByVal familiy As FamilyHist)
        Dim query As String = "INSERT INTO [dbo].[FamilyHist]
                               ([PatientId],[FamilyMember],[Disease],[Alive],[SavedBy],[SavedTime])
                         VALUES
                               (@PatientId, @FamilyMember, @Disease, @Alive, @SavedBy, @SavedTime)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = familiy.PatientId
                command.Parameters.AddWithValue("@FamilyMember", SqlDbType.VarChar).Value = familiy.FamilyMember
                command.Parameters.AddWithValue("@Disease", SqlDbType.VarChar).Value = familiy.Disease
                command.Parameters.AddWithValue("@Alive", SqlDbType.Bit).Value = familiy.Alive
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = Form1.user.User
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = familiy.SavedTime
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
    Function GetFamiliyList(patientId As Integer) As List(Of FamilyHist)
        Dim familiList As New List(Of FamilyHist)
        Dim query As String = "SELECT *
                              FROM [dbo].[FamilyHist]
                              WHERE PatientId=@PatientId"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim family As New FamilyHist
                Dim properties As List(Of PropertyInfo) = family.GetType().GetProperties().ToList
                While reader.Read
                    family = New FamilyHist
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(properties.IndexOf(prop)) Then
                            prop.SetValue(family, reader(properties.IndexOf(prop)))
                        End If
                    Next
                    familiList.Add(family)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return familiList
    End Function
    Function GetFamilyById(id As Integer) As FamilyHist
        Dim family As New FamilyHist
        Dim query As String = "SELECT *
                              FROM [dbo].[FamilyHist]
                              WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim properties As List(Of PropertyInfo) = family.GetType().GetProperties().ToList
                While reader.Read
                    family = New FamilyHist
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(properties.IndexOf(prop)) Then
                            prop.SetValue(family, reader(properties.IndexOf(prop)))
                        End If
                    Next
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return family
    End Function


    Sub updateFamily(ByVal familiy As FamilyHist)
        Dim query As String = "UPDATE [dbo].[FamilyHist]
                                SET [FamilyMember] = @FamilyMember, [Disease] = @Disease, [Alive] = @Alive, 
                                    [SavedBy] = @SavedBy, [SavedTime] = @SavedTime
	                               WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = familiy.Id
                command.Parameters.AddWithValue("@FamilyMember", SqlDbType.VarChar).Value = familiy.FamilyMember
                command.Parameters.AddWithValue("@Disease", SqlDbType.VarChar).Value = familiy.Disease
                command.Parameters.AddWithValue("@Alive", SqlDbType.Bit).Value = familiy.Alive
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = Form1.user.User
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = familiy.SavedTime
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
    Sub DeleteFamily(ByVal id As Integer)
        Dim query As String = "DELETE FROM [dbo].[FamilyHist]
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
