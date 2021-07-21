Public Class Android_File_editor
    Public sock As Integer
    Protected Friend filepaTH As String = ""


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'save
        Form1.Server.Send_DX(sock, "save_edit" & SplitData & filepaTH & SplitData & RichTextBox1.Text & SplitData)
    End Sub
End Class