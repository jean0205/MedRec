Imports System.Reflection

Public Class Frm_MedicalProblems
    Dim medProblemDB As New MedicalProblemsDB
    Dim util As New Util
    Dim patientId As Integer
    Dim updating As Boolean = False
    Sub New(patientId As Integer, updating As Boolean)

        ' This call is required by the designer.
        InitializeComponent()
        Me.patientId = patientId

    End Sub
    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        saveUpdateMedicalProblem()
    End Sub

    Sub saveUpdateMedicalProblem()
        Try
            Dim newIlness As New MedicalProblems
            Dim properties As List(Of PropertyInfo) = newIlness.GetType().GetProperties().ToList
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).First.SetValue(newIlness, txt.Text.ToUpper)
                End If
            Next
            newIlness.ProblemDate = dtpProblem.Value
            newIlness.isGynecologic = chkGynec.Checked
            If updating Then
                medProblemDB.updateIlness(newIlness)
            Else
                medProblemDB.insertIlness(newIlness)
                updating = False
            End If
            util.InformationMessage("Medical Problem/Ilness successfully saved", "Medical Problem/Ilness")
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
            dtpProblem.Value = Today
            chkGynec.Checked = False

        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
End Class