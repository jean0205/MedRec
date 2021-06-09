Imports System.Data.SqlClient
Imports System.Reflection

Public Class HabitsDB
    Dim conString As String = My.Settings.connectString
    '########### INSERT Contraceptive ####################
    Sub insertHabit(ByVal habit As Habits)
        Dim query As String = "INSERT INTO [dbo].[Habits]
                                   ([PatientId],[Habit],[Frequency],[From],[SavedBy],[SavedTime])
                             VALUES
                                   (@PatientId,@Habit, @Frequency, @From, @SavedBy, @SavedTime)"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = habit.PatientId
                command.Parameters.AddWithValue("@Habit", SqlDbType.VarChar).Value = habit.Habit
                command.Parameters.AddWithValue("@Frequency", SqlDbType.VarChar).Value = habit.Frequency
                command.Parameters.AddWithValue("@From", SqlDbType.Date).Value = habit.FromD
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = habit.SavedBy
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = habit.SavedTime
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
    Function GetHabitsList(patientId As Integer) As List(Of Habits)
        Dim habitList As New List(Of Habits)
        Dim query As String = "SELECT *
                              FROM [dbo].[Habits]
                              WHERE PatientId=@PatientId"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = patientId
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim habit As New Habits
                Dim properties As List(Of PropertyInfo) = habit.GetType().GetProperties().ToList
                While reader.Read
                    habit = New Habits
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(properties.IndexOf(prop)) Then
                            prop.SetValue(habit, reader(properties.IndexOf(prop)))
                        End If
                    Next
                    habitList.Add(habit)
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return habitList
    End Function
    Function GetHabitById(id As Integer) As Habits
        Dim habit As New Habits
        Dim query As String = "SELECT *
                              FROM [dbo].[Habits]
                              WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Dim properties As List(Of PropertyInfo) = habit.GetType().GetProperties().ToList
                While reader.Read
                    habit = New Habits
                    For Each prop As PropertyInfo In properties
                        If Not reader.IsDBNull(properties.IndexOf(prop)) Then
                            prop.SetValue(habit, reader(properties.IndexOf(prop)))
                        End If
                    Next
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return habit
    End Function


    Sub updateHabit(ByVal habit As Habits)
        Dim query As String = "UPDATE [dbo].[Habits]
                                SET [Habit] = @Habit, [Frequency] = @Frequency, [From] = @From, [SavedBy] = @SavedBy,
                                    [SavedTime] = @SavedTime
	                               WHERE Id=@Id"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = habit.Id
                command.Parameters.AddWithValue("@Habit", SqlDbType.VarChar).Value = habit.Habit
                command.Parameters.AddWithValue("@Frequency", SqlDbType.VarChar).Value = habit.FromD
                command.Parameters.AddWithValue("@From", SqlDbType.Date).Value = habit.FromD
                command.Parameters.AddWithValue("@SavedBy", SqlDbType.VarChar).Value = habit.SavedBy
                command.Parameters.AddWithValue("@SavedTime", SqlDbType.DateTime).Value = habit.SavedTime
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
    Sub DeleteHabit(ByVal id As Integer)
        Dim query As String = "DELETE FROM [dbo].[Habits]
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
