Public Class Frm_Visit
    Dim util As New Util
    Private Sub Frm_Visit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler txtSpo2.KeyPress, AddressOf util.txtOnlyIntegersNumber_KeyPress
    End Sub
End Class