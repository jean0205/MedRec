Public Class Frm_Allergy
    Dim dbAllergy As New AllergyDB
    Dim util As New Util
    Dim patientId As Integer
    Dim allergyId As Integer
    Dim updating As Boolean = False
    Dim allergy As New Allergy
    Sub New(patientId As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        Me.patientId = patientId
        Me.updating = False
    End Sub
    Sub New(allergyId As Integer, updating As Boolean)

        ' This call is required by the designer.
        InitializeComponent()
        Me.allergyId = allergyId
        Me.updating = updating
    End Sub
    Private Sub Frm_Allergy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If updating Then
            loadAllergies()
        End If
    End Sub
    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        saveUpdateAllergy()
    End Sub

    Sub loadAllergies()
        Try
            allergy = dbAllergy.GetAllergyById(allergyId)
            txtName.Text = allergy.Name
            cmbReaction.SelectedItem = allergy.NatureOfReaction
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub saveUpdateAllergy()
        Try
            Dim newAllergy As New Allergy
            newAllergy.id = allergyId
            newAllergy.Name = txtName.Text.ToUpper
            newAllergy.NatureOfReaction = cmbReaction.SelectedItem
            newAllergy.SavedBy = "jcsoto"
            newAllergy.SavedTime = Today
            If updating Then
                dbAllergy.updateAllergy(newAllergy)
            Else
                newAllergy.Patientid = patientId
                dbAllergy.insertAllergy(newAllergy)
                updating = False
            End If
            util.InformationMessage("Allergy successfully saved", "Allergy")
            cleanAfterInsert()
            Me.Close()
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Private Sub cleanAfterInsert()
        txtName.Clear()
        cmbReaction.SelectedItem = Nothing
    End Sub


End Class