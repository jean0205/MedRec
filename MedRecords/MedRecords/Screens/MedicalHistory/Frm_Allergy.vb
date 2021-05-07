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
    Sub New(ilnessId As Integer, updating As Boolean)

        ' This call is required by the designer.
        InitializeComponent()
        Me.allergyId = ilnessId
        Me.updating = updating
    End Sub
    Private Sub Frm_Allergy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If updating Then
            loadAllergies()
        End If
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
            Dim allery As New Allergy
            allery.id = allergyId
            allergy.Name = txtName.Text.ToUpper
            allergy.NatureOfReaction = cmbReaction.SelectedItem
            allery.SavedBy = "jcsoto"
            allery.SavedTime = Today
            If updating Then
                dbAllergy.up(allery)
            Else
                allery.PatientId = patientId
                medProblemDB.insertIlness(allery)
                updating = False
            End If
            util.InformationMessage("Medical Problem/Ilness successfully saved", "Medical Problem/Ilness")
            cleanAfterInsert()
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
End Class