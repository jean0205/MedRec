Imports System.Reflection

Public Class FrmSurgery
    Dim dbSurgery As New SurgeryDB
    Dim util As New Util
    Dim patientId As Integer
    Dim surgeryId As Integer
    Dim updating As Boolean = False
    Dim surgery As New Surgery

    Sub New(patientId As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        Me.patientId = patientId
        Me.updating = False
    End Sub
    Sub New(surgeryId As Integer, updating As Boolean)

        ' This call is required by the designer.
        InitializeComponent()
        Me.surgeryId = surgeryId
        Me.updating = updating
    End Sub
    Private Sub FrmSurgery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If updating Then
            loadSurgery()
        End If
    End Sub
    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        saveUpdateSurgery()
    End Sub

    Sub loadSurgery()
        Try
            surgery = dbSurgery.GetSurgeryById(surgeryId)
            Dim properties As List(Of PropertyInfo) = surgery.GetType().GetProperties().ToList
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    txt.Text = properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).
                        First.GetValue(surgery).ToString.ToUpper
                End If
            Next
            dtpDate.Value = surgery.SurgeryDate
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub saveUpdateSurgery()
        Try
            Dim newSurgery As New Surgery
            newSurgery.id = surgeryId
            Dim properties As List(Of PropertyInfo) = newSurgery.GetType().GetProperties().ToList
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).First.SetValue(newSurgery, txt.Text.ToUpper)
                End If
            Next
            newSurgery.SurgeryDate = dtpDate.Value
            newSurgery.SavedBy = "jcsoto"
            newSurgery.SavedTime = Today
            If updating Then
                dbSurgery.updateSurgery(newSurgery)
            Else
                newSurgery.PatientId = patientId
                dbSurgery.insertSurgery(newSurgery)
                updating = False
            End If
            util.InformationMessage("Surgery successfully saved", "Surgery")
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
            dtpDate.Value = Today
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

End Class