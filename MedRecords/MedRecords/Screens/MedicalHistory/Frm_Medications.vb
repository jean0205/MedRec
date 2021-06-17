Imports System.Reflection

Public Class Frm_Medications
    Dim dbMedication As New MedicationsDB
    Dim util As New Util
    Dim patientId As Integer
    Dim visitId As Integer
    Dim medicationId As Integer
    Dim updating As Boolean = False
    Dim medication As New Medications

    Sub New(patientId As Integer, visitId As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        Me.patientId = patientId
        Me.visitId = visitId
        Me.updating = False
    End Sub
    Sub New(medicationId As Integer, updating As Boolean)

        ' This call is required by the designer.
        InitializeComponent()
        Me.medicationId = medicationId
        Me.updating = updating
    End Sub
    Private Sub Frm_Medications_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If updating Then
            loadmedication()
        End If
    End Sub
    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        saveUpdateMedication()
    End Sub

    Sub loadmedication()
        Try
            medication = dbMedication.GetMedicationById(medicationId)
            Dim properties As List(Of PropertyInfo) = medication.GetType().GetProperties().ToList
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    txt.Text = properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).
                        First.GetValue(medication).ToString.ToUpper
                End If
            Next
            chkActive.Checked = medication.Active
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub saveUpdateMedication()
        Try
            Dim newMedication As New Medications
            newMedication.id = medicationId
            newMedication.VisitId = visitId
            Dim properties As List(Of PropertyInfo) = newMedication.GetType().GetProperties().ToList
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).First.SetValue(newMedication, txt.Text.ToUpper)
                End If
            Next
            newMedication.Active = chkActive.Checked
            newMedication.SavedBy = "jcsoto"
            newMedication.SavedTime = Today
            If updating Then
                dbMedication.updateMedication(newMedication)
            Else
                newMedication.PatientId = patientId
                dbMedication.insertMedication(newMedication)
                updating = False
            End If
            util.InformationMessage("Medication successfully saved", "Medication")
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
            chkActive.Checked = False
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub


End Class