Public Class Frm_Pregnancy
    Dim dbPregnancy As New PregnacyDB
    Dim util As New Util
    Dim patientId As Integer
    Dim pregnancyId As Integer
    Dim updating As Boolean = False
    Dim pregnancy As New Pregnacy

    Sub New(patientId As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        Me.patientId = patientId
        Me.updating = False
    End Sub
    Sub New(pregnancyId As Integer, updating As Boolean)

        ' This call is required by the designer.
        InitializeComponent()
        Me.pregnancyId = pregnancyId
        Me.updating = updating
    End Sub
    Private Sub Frm_Pregnancy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If updating Then
            loadPregnancies()
        End If
    End Sub

    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        saveUpdatePregnancy()
    End Sub

    Sub loadPregnancies()
        Try
            pregnancy = dbPregnancy.GetPregnancyById(pregnancyId)
            dtpDate.Value = pregnancy.PregnancyDate
            rbtnCsection.Checked = pregnancy.CSection
            rbtnMisscarriage.Checked = pregnancy.Miscarriage
            rbtnNormal.Checked = pregnancy.Normal
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub saveUpdatePregnancy()
        Try
            Dim newPregnancy As New Pregnacy
            newPregnancy.id = pregnancyId
            newPregnancy.PregnancyDate = dtpDate.Value
            newPregnancy.Normal = rbtnNormal.Checked
            newPregnancy.CSection = rbtnCsection.Checked
            newPregnancy.Miscarriage = rbtnMisscarriage.Checked
            newPregnancy.SavedBy = "jcsoto"
            newPregnancy.SavedTime = Today
            If updating Then
                dbPregnancy.updatePregnancy(newPregnancy)
            Else
                newPregnancy.Patientid = patientId
                dbPregnancy.insertPregnancy(newPregnancy)
                updating = False
            End If
            util.InformationMessage("Pregnancy successfully saved", "Pregnancy")
            cleanAfterInsert()
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub cleanAfterInsert()
        dtpDate.Value = Today
        rbtnCsection.Checked = False
        rbtnMisscarriage.Checked = False
        rbtnNormal.Checked = False
    End Sub
End Class