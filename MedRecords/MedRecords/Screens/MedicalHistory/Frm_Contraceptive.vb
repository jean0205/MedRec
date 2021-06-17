Imports System.Reflection

Public Class Frm_Contraceptive
    Dim dbContraceptive As New ContraceptiveDB
    Dim util As New Util
    Dim patientId As Integer
    Dim contraceptiveId As Integer
    Dim updating As Boolean = False
    Dim contraceptive As New Contraceptive

    Sub New(patientId As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        Me.patientId = patientId
        Me.updating = False
    End Sub
    Sub New(contraceptiveId As Integer, updating As Boolean)

        ' This call is required by the designer.
        InitializeComponent()
        Me.contraceptiveId = contraceptiveId
        Me.updating = updating
    End Sub
    Private Sub Frm_Contraceptive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If updating Then
            loadContraceptive()
        End If
    End Sub

    Sub loadContraceptive()
        Try
            contraceptive = dbContraceptive.GetContraceptiveById(contraceptiveId)
            Dim properties As List(Of PropertyInfo) = contraceptive.GetType().GetProperties().ToList
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    txt.Text = properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).
                        First.GetValue(contraceptive).ToString.ToUpper
                End If
            Next
            dtpFrom.Value = contraceptive.FromD
            dtpTo.Value = contraceptive.ToDate
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub saveUpdateContraceptive()
        Try
            Dim newcontraceptive As New Contraceptive
            newcontraceptive.Id = contraceptiveId
            Dim properties As List(Of PropertyInfo) = newcontraceptive.GetType().GetProperties().ToList
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).First.SetValue(newcontraceptive, txt.Text.ToUpper)
                End If
            Next
            newcontraceptive.FromD = dtpFrom.Value
            newcontraceptive.ToDate = dtpTo.Value
            newcontraceptive.SavedBy = "jcsoto"
            newcontraceptive.SavedTime = Today
            If updating Then
                dbContraceptive.updateContraceptive(newcontraceptive)
            Else
                newcontraceptive.PatientId = patientId
                dbContraceptive.insertContraceptive(newcontraceptive)
                updating = False
            End If
            util.InformationMessage("contraceptive successfully saved", " Contraceptive")
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
            dtpFrom.Value = Today
            dtpTo.Value = Today
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        saveUpdateContraceptive()
    End Sub
End Class