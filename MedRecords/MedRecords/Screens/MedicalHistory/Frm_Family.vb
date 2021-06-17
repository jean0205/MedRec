Imports System.Reflection

Public Class Frm_Family
    Dim familiDB As New FamilyHistDB
    Dim util As New Util
    Dim patientId As Integer
    Dim familyId As Integer
    Dim updating As Boolean = False
    Dim family As New FamilyHist
    Sub New(patientId As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        Me.patientId = patientId
        Me.updating = False
    End Sub
    Sub New(ilnessId As Integer, updating As Boolean)
        ' This call is required by the designer.
        InitializeComponent()
        Me.familyId = ilnessId
        Me.updating = updating
    End Sub
    Private Sub Frm_MedicalProblems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If updating Then
            loadFamily()
        End If
    End Sub
    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        saveUpdateFamily()
    End Sub

    Sub loadFamily()
        Try
            family = familiDB.GetFamilyById(familyId)
            Dim properties As List(Of PropertyInfo) = family.GetType().GetProperties().ToList
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    txt.Text = properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).
                        First.GetValue(family).ToString.ToUpper
                End If
            Next
            chkAlive.Checked = family.Alive
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub saveUpdateFamily()
        Try
            Dim newFamily As New FamilyHist
            newFamily.Id = familyId
            Dim properties As List(Of PropertyInfo) = newFamily.GetType().GetProperties().ToList
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).First.SetValue(newFamily, txt.Text.ToUpper)
                End If
            Next
            newFamily.Alive = chkAlive.Checked
            newFamily.SavedBy = "jcsoto"
            newFamily.SavedTime = Today
            If updating Then
                familiDB.updateFamily(newFamily)
            Else
                newFamily.PatientId = patientId
                familiDB.insertFamily(newFamily)
                updating = False
            End If
            util.InformationMessage("Family history successfully saved", "Family history")
            cleanAfterInsert()
            Me.Close()
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub cleanAfterInsert()
        Try
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                txt.Clear()
            Next
            chkAlive.Checked = False
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
End Class