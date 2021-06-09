Imports System.Reflection

Public Class Frm_Habits
    Dim dbHabit As New HabitsDB
    Dim util As New Util
    Dim patientId As Integer
    Dim habitId As Integer
    Dim updating As Boolean = False
    Dim habit As New Habits

    Sub New(patientId As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        Me.patientId = patientId
        Me.updating = False
    End Sub
    Sub New(contraceptiveId As Integer, updating As Boolean)

        ' This call is required by the designer.
        InitializeComponent()
        Me.habitId = contraceptiveId
        Me.updating = updating
    End Sub
    Private Sub Frm_Contraceptive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If updating Then
            loadHabit()
        End If
    End Sub

    Sub loadHabit()
        Try
            habit = dbHabit.GetHabitById(habitId)
            Dim properties As List(Of PropertyInfo) = habit.GetType().GetProperties().ToList
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    txt.Text = properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).
                        First.GetValue(habit).ToString.ToUpper
                End If
            Next
            dtpFrom.Value = habit.FromD
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub saveUpdateHabit()
        Try
            Dim newHabit As New Habits
            newHabit.Id = habitId
            Dim properties As List(Of PropertyInfo) = newHabit.GetType().GetProperties().ToList
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).First.SetValue(newHabit, txt.Text.ToUpper)
                End If
            Next
            newHabit.FromD = dtpFrom.Value
            newHabit.SavedBy = "jcsoto"
            newHabit.SavedTime = Today
            If updating Then
                dbHabit.updateHabit(newHabit)
            Else
                newHabit.PatientId = patientId
                dbHabit.insertHabit(newHabit)
                updating = False
            End If
            util.InformationMessage("Habit successfully saved", "Habit")
            cleanAfterInsert()
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub cleanAfterInsert()
        Try
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                txt.Clear()
            Next
            dtpFrom.Value = Today
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        saveUpdateHabit()
    End Sub
End Class