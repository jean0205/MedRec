Imports System.IO

Public Class Frm_FileViewer

    Dim dbTest As New TestComplementDB
    Dim util As New Util
    Dim id As Integer
    Sub New(id As Integer)


        ' This call is required by the designer.
        InitializeComponent()
        Me.id = id

    End Sub
    Private Sub Frm_FileViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getTestFile(id)
    End Sub

    Sub openDocumentInBrowser(path As String)
        wb1.Navigate(path)
    End Sub
    Sub getTestFile(id As Integer)
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
End Class