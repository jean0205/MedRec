Imports System.IO
Imports System.Reflection

Public Class Frm_Test
    Dim filePath As String
    Dim util As New Util
    Dim dbTest As New TestComplementDB
    Dim patientId As Integer
    Dim testId As Integer
    Dim visitId As Integer = 0
    Dim updating As Boolean = False
    Dim test As New TestComplement

    Sub New(patientId As Integer, visitId As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        Me.patientId = patientId
        Me.visitId = visitId
        Me.updating = False
    End Sub
    Sub New(testId As Integer, updating As Boolean)

        ' This call is required by the designer.
        InitializeComponent()
        Me.testId = testId
        Me.updating = updating
    End Sub
    Private Sub Frm_Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If updating Then
            loadTest()
        End If
    End Sub
    Private Sub ibtnImportFile_Click(sender As Object, e As EventArgs) Handles ibtnImportFile.Click
        SelectFile()
    End Sub
    Private Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnSave.Click
        saveUpdateSurgery()
    End Sub




#Region "Metodos"
    Sub loadTest()
        Try
            test = dbTest.GetTestById(testId)
            Dim properties As List(Of PropertyInfo) = test.GetType().GetProperties().ToList
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    txt.Text = properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).
                        First.GetValue(test).ToString.ToUpper
                End If
            Next
            dtpDate.Value = test.TestDate
            getInvoiceDocument(test.Id)
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub

    Sub saveUpdateSurgery()
        Try
            Dim newTest As New TestComplement
            newTest.Id = testId
            newTest.VisitId = visitId
            Dim properties As List(Of PropertyInfo) = newTest.GetType().GetProperties().ToList
            For Each txt As TextBox In gbInfo.Controls.OfType(Of TextBox)
                If properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).Any Then
                    properties.Where(Function(r) r.Name = txt.Name.Replace("txt", String.Empty)).First.SetValue(newTest, txt.Text.ToUpper)
                End If
            Next
            newTest.TestDate = dtpDate.Value
            If Not String.IsNullOrEmpty(filePath) Then
                Using fs As Stream = File.OpenRead(filePath)
                    Using br As New BinaryReader(fs)
                        Dim bytes As Byte() = br.ReadBytes(fs.Length)
                        newTest.File = bytes
                    End Using
                End Using
            End If
            newTest.SavedBy = "jcsoto"
            newTest.SavedTime = Today
            If updating Then
                If String.IsNullOrEmpty(filePath) Then
                    dbTest.updateTestNOFile(newTest)
                Else
                    dbTest.updateTestFile(newTest)
                End If
            Else
                newTest.PatientId = patientId
                If String.IsNullOrEmpty(filePath) Then
                    dbTest.insertTestNoFile(newTest)
                Else
                    dbTest.insertTest(newTest)
                End If

                updating = False
            End If
            util.InformationMessage("Test/Complementary successfully saved", "Test/Complementary")
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
            dtpDate.Value = Today
            openDocumentInBrowser(String.Empty)
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub SelectFile()
        Try
            Dim ofd As OpenFileDialog = New OpenFileDialog
            ofd.DefaultExt = "pdf"
            ofd.FileName = "Upload File"
            'ofd.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads")
            ofd.Filter = "All files|*.*|PDF files|*.pdf"
            ofd.Title = "Select file"
            If ofd.ShowDialog() <> DialogResult.Cancel Then
                Dim fdirectory As New FileInfo(ofd.FileName)
                Dim fName As New FileInfo(ofd.FileName)
                Dim folder As String = fdirectory.Directory.ToString()
                Dim name As String = fName.Name
                Dim ext As String = fName.Extension
                filePath = fName.ToString
                openDocumentInBrowser(fName.ToString)
            End If
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub
    Sub openDocumentInBrowser(path As String)
        wb1.Navigate(path)
    End Sub

    Sub getInvoiceDocument(id As Integer)
        Try
            Dim myFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Tests\"
            If Not Directory.Exists(myFolder) Then
                Directory.CreateDirectory(myFolder)
            End If
            'Dim files() As String = IO.Directory.GetFiles(myFolder, "*.*")
            'If files.Length > 0 Then
            '    FileSystem.Kill(myFolder & "*.*")
            'End If
            File.WriteAllBytes(myFolder & "Test" & id, dbTest.getTestDocument(id))
            Dim path As String = myFolder & "Test" & id
            openDocumentInBrowser(path)
        Catch ex As Exception
            util.ErrorMessage(ex.Message, "Error")
        End Try
    End Sub


#End Region
End Class