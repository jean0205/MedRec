Public Class VisitE
    Public Property Id As Integer
    Public Property PatientId As Integer
    Public Property ServicesId As List(Of Integer)

    Public Property VisitDate As DateTime

    '###### Vital Signs and physical Exam #######
    Public Property RespiratoryRate As Integer
    Public Property HeartRate As Integer
    Public Property BloodPAlta As Integer
    Public Property BloodPBaja As Integer
    Public Property SpO2 As Integer
    Public Property Temperature As Decimal
    Public Property PhysicalExam As String
    Public Property PatientComplain As String
    Public Property Diagnosis As String
    Public Property Plan As String

    '###### charges and fees #######
    Public Property ServiceTotal As Decimal
    Public Property otherServices As String
    Public Property OSCharges As Decimal
    Public Property Disscount As Decimal
    Public Property ToPay As Decimal
    Public Property Paid As Decimal
    Public Property Oustanding As Decimal


End Class
