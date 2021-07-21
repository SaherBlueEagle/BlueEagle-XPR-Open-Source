Public Class Loading
    '##################################################
    '################### CODED  #######################
    '##################### BY #########################
    '############### Saher Blue Eagle  ################
    '###############  XPR OPEN SOURCE  ################
    '##################################################
    '##################################################
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label3.Text = "...."
        Button2.Visible = False
        Timer1.Start()
    End Sub
    Dim loadcounter As Integer = 1
    Dim bigcount As Integer = 0
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If bigcount = 3 Then
            bigcount = 0
            About.Show()
            Button2.Visible = True
            Timer1.Stop()
        ElseIf bigcount < 3 Then

            If loadcounter = 6 Then
                bigcount += 1
                loadcounter = 1
                Label3.Text = "...."
            ElseIf loadcounter = 1 Then
                Label3.Text = "Loading."
                Label3.Update()
                loadcounter += 1
            ElseIf loadcounter = 2 Then
                Label3.Text = "Loading.."
                Label3.Update()
                loadcounter += 1
            ElseIf loadcounter = 3 Then
                Label3.Text = "Loading..."
                Label3.Update()
                loadcounter += 1
            ElseIf loadcounter = 4 Then
                Label3.Text = "Loading...."
                Label3.Update()
                loadcounter += 1
            ElseIf loadcounter = 5 Then
                Label3.Text = "Loading....."
                Label3.Update()
                loadcounter += 1
            ElseIf loadcounter = 6 Then
                Label3.Text = "Loading....."
                Label3.Update()
                loadcounter += 1
            End If
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        About.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        End
    End Sub
End Class