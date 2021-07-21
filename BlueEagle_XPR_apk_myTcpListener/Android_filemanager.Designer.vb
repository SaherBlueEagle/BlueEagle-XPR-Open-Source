<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Android_filemanager
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Android_filemanager))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileInTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetWallpaperToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenDowloadsFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecuteFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextNotepadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApkInstallerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureGifToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureJpgjpegToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Video3gpmpgToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AudioWavmp3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WordPadRtfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdobePdfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentDocdocxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PowerpointPptpptxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcelXlsxlsxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileZiprarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnknownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(683, 70)
        Me.Panel1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(0, 45)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 21)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Back"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(0, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(679, 26)
        Me.TextBox1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Local Path"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ListView1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(410, 387)
        Me.Panel2.TabIndex = 1
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.White
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.ForeColor = System.Drawing.Color.Black
        Me.ListView1.FullRowSelect = True
        Me.ListView1.LargeImageList = Me.ImageList1
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(410, 387)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 180
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Ext Type"
        Me.ColumnHeader2.Width = 120
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Size"
        Me.ColumnHeader3.Width = 100
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Consolas", 11.25!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.ViewImageToolStripMenuItem, Me.UploadFileToolStripMenuItem, Me.DownloadFileToolStripMenuItem, Me.DeleteFileToolStripMenuItem, Me.RenameFileToolStripMenuItem, Me.OpenFileInTextToolStripMenuItem, Me.AddNewFolderToolStripMenuItem, Me.AddNewFileToolStripMenuItem, Me.SetWallpaperToolStripMenuItem, Me.OpenDowloadsFolderToolStripMenuItem, Me.ExecuteFileToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(261, 268)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.BackgroundImage = CType(resources.GetObject("RefreshToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.RefreshToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefreshToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.RefreshToolStripMenuItem.Image = CType(resources.GetObject("RefreshToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'ViewImageToolStripMenuItem
        '
        Me.ViewImageToolStripMenuItem.BackgroundImage = CType(resources.GetObject("ViewImageToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.ViewImageToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewImageToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.ViewImageToolStripMenuItem.Image = CType(resources.GetObject("ViewImageToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ViewImageToolStripMenuItem.Name = "ViewImageToolStripMenuItem"
        Me.ViewImageToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.ViewImageToolStripMenuItem.Text = "View Thumbnail"
        '
        'UploadFileToolStripMenuItem
        '
        Me.UploadFileToolStripMenuItem.BackgroundImage = CType(resources.GetObject("UploadFileToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.UploadFileToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UploadFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.UploadFileToolStripMenuItem.Image = CType(resources.GetObject("UploadFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UploadFileToolStripMenuItem.Name = "UploadFileToolStripMenuItem"
        Me.UploadFileToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.UploadFileToolStripMenuItem.Text = "Upload File"
        '
        'DownloadFileToolStripMenuItem
        '
        Me.DownloadFileToolStripMenuItem.BackgroundImage = CType(resources.GetObject("DownloadFileToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.DownloadFileToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DownloadFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.DownloadFileToolStripMenuItem.Image = CType(resources.GetObject("DownloadFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DownloadFileToolStripMenuItem.Name = "DownloadFileToolStripMenuItem"
        Me.DownloadFileToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.DownloadFileToolStripMenuItem.Text = "Download File"
        '
        'DeleteFileToolStripMenuItem
        '
        Me.DeleteFileToolStripMenuItem.BackgroundImage = CType(resources.GetObject("DeleteFileToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.DeleteFileToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.DeleteFileToolStripMenuItem.Image = CType(resources.GetObject("DeleteFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteFileToolStripMenuItem.Name = "DeleteFileToolStripMenuItem"
        Me.DeleteFileToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.DeleteFileToolStripMenuItem.Text = "Delete File"
        '
        'RenameFileToolStripMenuItem
        '
        Me.RenameFileToolStripMenuItem.BackgroundImage = CType(resources.GetObject("RenameFileToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.RenameFileToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RenameFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.RenameFileToolStripMenuItem.Image = CType(resources.GetObject("RenameFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RenameFileToolStripMenuItem.Name = "RenameFileToolStripMenuItem"
        Me.RenameFileToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.RenameFileToolStripMenuItem.Text = "Rename File"
        '
        'OpenFileInTextToolStripMenuItem
        '
        Me.OpenFileInTextToolStripMenuItem.BackgroundImage = CType(resources.GetObject("OpenFileInTextToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.OpenFileInTextToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenFileInTextToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.OpenFileInTextToolStripMenuItem.Image = CType(resources.GetObject("OpenFileInTextToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenFileInTextToolStripMenuItem.Name = "OpenFileInTextToolStripMenuItem"
        Me.OpenFileInTextToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.OpenFileInTextToolStripMenuItem.Text = "Edit File in TextEditor"
        '
        'AddNewFolderToolStripMenuItem
        '
        Me.AddNewFolderToolStripMenuItem.BackgroundImage = CType(resources.GetObject("AddNewFolderToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.AddNewFolderToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddNewFolderToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.AddNewFolderToolStripMenuItem.Image = CType(resources.GetObject("AddNewFolderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddNewFolderToolStripMenuItem.Name = "AddNewFolderToolStripMenuItem"
        Me.AddNewFolderToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.AddNewFolderToolStripMenuItem.Text = "Add New Folder"
        '
        'AddNewFileToolStripMenuItem
        '
        Me.AddNewFileToolStripMenuItem.BackgroundImage = CType(resources.GetObject("AddNewFileToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.AddNewFileToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddNewFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.AddNewFileToolStripMenuItem.Image = CType(resources.GetObject("AddNewFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddNewFileToolStripMenuItem.Name = "AddNewFileToolStripMenuItem"
        Me.AddNewFileToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.AddNewFileToolStripMenuItem.Text = "Add New File"
        '
        'SetWallpaperToolStripMenuItem
        '
        Me.SetWallpaperToolStripMenuItem.BackgroundImage = CType(resources.GetObject("SetWallpaperToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.SetWallpaperToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SetWallpaperToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.SetWallpaperToolStripMenuItem.Image = CType(resources.GetObject("SetWallpaperToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SetWallpaperToolStripMenuItem.Name = "SetWallpaperToolStripMenuItem"
        Me.SetWallpaperToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.SetWallpaperToolStripMenuItem.Text = "Set Wallpaper"
        '
        'OpenDowloadsFolderToolStripMenuItem
        '
        Me.OpenDowloadsFolderToolStripMenuItem.BackgroundImage = CType(resources.GetObject("OpenDowloadsFolderToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.OpenDowloadsFolderToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenDowloadsFolderToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.OpenDowloadsFolderToolStripMenuItem.Image = CType(resources.GetObject("OpenDowloadsFolderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenDowloadsFolderToolStripMenuItem.Name = "OpenDowloadsFolderToolStripMenuItem"
        Me.OpenDowloadsFolderToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.OpenDowloadsFolderToolStripMenuItem.Text = "Open Dowloads Folder"
        '
        'ExecuteFileToolStripMenuItem
        '
        Me.ExecuteFileToolStripMenuItem.BackgroundImage = CType(resources.GetObject("ExecuteFileToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.ExecuteFileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PictureToolStripMenuItem, Me.TextNotepadToolStripMenuItem, Me.ApkInstallerToolStripMenuItem, Me.PictureGifToolStripMenuItem, Me.PictureJpgjpegToolStripMenuItem, Me.Video3gpmpgToolStripMenuItem, Me.AudioWavmp3ToolStripMenuItem, Me.WordPadRtfToolStripMenuItem, Me.AdobePdfToolStripMenuItem, Me.DocumentDocdocxToolStripMenuItem, Me.PowerpointPptpptxToolStripMenuItem, Me.ExcelXlsxlsxToolStripMenuItem, Me.FileZiprarToolStripMenuItem, Me.UnknownToolStripMenuItem})
        Me.ExecuteFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.ExecuteFileToolStripMenuItem.Image = CType(resources.GetObject("ExecuteFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExecuteFileToolStripMenuItem.Name = "ExecuteFileToolStripMenuItem"
        Me.ExecuteFileToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.ExecuteFileToolStripMenuItem.Text = "Execute File With"
        '
        'PictureToolStripMenuItem
        '
        Me.PictureToolStripMenuItem.BackgroundImage = CType(resources.GetObject("PictureToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.PictureToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.PictureToolStripMenuItem.Image = CType(resources.GetObject("PictureToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PictureToolStripMenuItem.Name = "PictureToolStripMenuItem"
        Me.PictureToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.PictureToolStripMenuItem.Text = "Picture"
        '
        'TextNotepadToolStripMenuItem
        '
        Me.TextNotepadToolStripMenuItem.BackgroundImage = CType(resources.GetObject("TextNotepadToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.TextNotepadToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.TextNotepadToolStripMenuItem.Image = CType(resources.GetObject("TextNotepadToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TextNotepadToolStripMenuItem.Name = "TextNotepadToolStripMenuItem"
        Me.TextNotepadToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.TextNotepadToolStripMenuItem.Text = "Text / Notepad"
        '
        'ApkInstallerToolStripMenuItem
        '
        Me.ApkInstallerToolStripMenuItem.BackgroundImage = CType(resources.GetObject("ApkInstallerToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.ApkInstallerToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.ApkInstallerToolStripMenuItem.Image = CType(resources.GetObject("ApkInstallerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ApkInstallerToolStripMenuItem.Name = "ApkInstallerToolStripMenuItem"
        Me.ApkInstallerToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.ApkInstallerToolStripMenuItem.Text = "Apk Installer"
        '
        'PictureGifToolStripMenuItem
        '
        Me.PictureGifToolStripMenuItem.BackgroundImage = CType(resources.GetObject("PictureGifToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.PictureGifToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.PictureGifToolStripMenuItem.Image = CType(resources.GetObject("PictureGifToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PictureGifToolStripMenuItem.Name = "PictureGifToolStripMenuItem"
        Me.PictureGifToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.PictureGifToolStripMenuItem.Text = "Picture gif"
        '
        'PictureJpgjpegToolStripMenuItem
        '
        Me.PictureJpgjpegToolStripMenuItem.BackgroundImage = CType(resources.GetObject("PictureJpgjpegToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.PictureJpgjpegToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.PictureJpgjpegToolStripMenuItem.Image = CType(resources.GetObject("PictureJpgjpegToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PictureJpgjpegToolStripMenuItem.Name = "PictureJpgjpegToolStripMenuItem"
        Me.PictureJpgjpegToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.PictureJpgjpegToolStripMenuItem.Text = "Picture jpg ,jpeg"
        '
        'Video3gpmpgToolStripMenuItem
        '
        Me.Video3gpmpgToolStripMenuItem.BackgroundImage = CType(resources.GetObject("Video3gpmpgToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.Video3gpmpgToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.Video3gpmpgToolStripMenuItem.Image = CType(resources.GetObject("Video3gpmpgToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Video3gpmpgToolStripMenuItem.Name = "Video3gpmpgToolStripMenuItem"
        Me.Video3gpmpgToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.Video3gpmpgToolStripMenuItem.Text = "video 3gp,mpg"
        '
        'AudioWavmp3ToolStripMenuItem
        '
        Me.AudioWavmp3ToolStripMenuItem.BackgroundImage = CType(resources.GetObject("AudioWavmp3ToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.AudioWavmp3ToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.AudioWavmp3ToolStripMenuItem.Image = CType(resources.GetObject("AudioWavmp3ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AudioWavmp3ToolStripMenuItem.Name = "AudioWavmp3ToolStripMenuItem"
        Me.AudioWavmp3ToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.AudioWavmp3ToolStripMenuItem.Text = "audio wav,mp3"
        '
        'WordPadRtfToolStripMenuItem
        '
        Me.WordPadRtfToolStripMenuItem.BackgroundImage = CType(resources.GetObject("WordPadRtfToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.WordPadRtfToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.WordPadRtfToolStripMenuItem.Image = CType(resources.GetObject("WordPadRtfToolStripMenuItem.Image"), System.Drawing.Image)
        Me.WordPadRtfToolStripMenuItem.Name = "WordPadRtfToolStripMenuItem"
        Me.WordPadRtfToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.WordPadRtfToolStripMenuItem.Text = "WordPad rtf"
        '
        'AdobePdfToolStripMenuItem
        '
        Me.AdobePdfToolStripMenuItem.BackgroundImage = CType(resources.GetObject("AdobePdfToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.AdobePdfToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.AdobePdfToolStripMenuItem.Image = CType(resources.GetObject("AdobePdfToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AdobePdfToolStripMenuItem.Name = "AdobePdfToolStripMenuItem"
        Me.AdobePdfToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.AdobePdfToolStripMenuItem.Text = "Adobe pdf"
        '
        'DocumentDocdocxToolStripMenuItem
        '
        Me.DocumentDocdocxToolStripMenuItem.BackgroundImage = CType(resources.GetObject("DocumentDocdocxToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.DocumentDocdocxToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.DocumentDocdocxToolStripMenuItem.Image = CType(resources.GetObject("DocumentDocdocxToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DocumentDocdocxToolStripMenuItem.Name = "DocumentDocdocxToolStripMenuItem"
        Me.DocumentDocdocxToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.DocumentDocdocxToolStripMenuItem.Text = "document doc,docx"
        '
        'PowerpointPptpptxToolStripMenuItem
        '
        Me.PowerpointPptpptxToolStripMenuItem.BackgroundImage = CType(resources.GetObject("PowerpointPptpptxToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.PowerpointPptpptxToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.PowerpointPptpptxToolStripMenuItem.Image = CType(resources.GetObject("PowerpointPptpptxToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PowerpointPptpptxToolStripMenuItem.Name = "PowerpointPptpptxToolStripMenuItem"
        Me.PowerpointPptpptxToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.PowerpointPptpptxToolStripMenuItem.Text = "Powerpoint ppt,pptx"
        '
        'ExcelXlsxlsxToolStripMenuItem
        '
        Me.ExcelXlsxlsxToolStripMenuItem.BackgroundImage = CType(resources.GetObject("ExcelXlsxlsxToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.ExcelXlsxlsxToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.ExcelXlsxlsxToolStripMenuItem.Image = CType(resources.GetObject("ExcelXlsxlsxToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExcelXlsxlsxToolStripMenuItem.Name = "ExcelXlsxlsxToolStripMenuItem"
        Me.ExcelXlsxlsxToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.ExcelXlsxlsxToolStripMenuItem.Text = "Excel xls,xlsx"
        '
        'FileZiprarToolStripMenuItem
        '
        Me.FileZiprarToolStripMenuItem.BackgroundImage = CType(resources.GetObject("FileZiprarToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.FileZiprarToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.FileZiprarToolStripMenuItem.Image = CType(resources.GetObject("FileZiprarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FileZiprarToolStripMenuItem.Name = "FileZiprarToolStripMenuItem"
        Me.FileZiprarToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.FileZiprarToolStripMenuItem.Text = "File zip,rar"
        '
        'UnknownToolStripMenuItem
        '
        Me.UnknownToolStripMenuItem.BackgroundImage = CType(resources.GetObject("UnknownToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.UnknownToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.UnknownToolStripMenuItem.Image = CType(resources.GetObject("UnknownToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UnknownToolStripMenuItem.Name = "UnknownToolStripMenuItem"
        Me.UnknownToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.UnknownToolStripMenuItem.Text = "unknown"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "shell32_5.ico")
        Me.ImageList1.Images.SetKeyName(1, "shell32_1.ico")
        Me.ImageList1.Images.SetKeyName(2, "shell32_151.ico")
        Me.ImageList1.Images.SetKeyName(3, "shell32_152.ico")
        Me.ImageList1.Images.SetKeyName(4, "pdf.ico")
        Me.ImageList1.Images.SetKeyName(5, "shell32_153.ico")
        Me.ImageList1.Images.SetKeyName(6, "shell32_154.ico")
        Me.ImageList1.Images.SetKeyName(7, "shell32_512.ico")
        Me.ImageList1.Images.SetKeyName(8, "shell32_16824.ico")
        Me.ImageList1.Images.SetKeyName(9, "shell32_16825.ico")
        Me.ImageList1.Images.SetKeyName(10, "USER32_100.ico")
        Me.ImageList1.Images.SetKeyName(11, "shell32_16823.ico")
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.SplitContainer1)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 70)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(683, 471)
        Me.Panel3.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel5)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel6)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Size = New System.Drawing.Size(683, 391)
        Me.SplitContainer1.SplitterDistance = 414
        Me.SplitContainer1.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel2)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(410, 387)
        Me.Panel5.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(261, 340)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Button1)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 359)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(261, 28)
        Me.Panel6.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(47, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(214, 28)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Download selected image file"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Image Viewer"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Snow
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 391)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(683, 80)
        Me.Panel4.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Status"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Android_filemanager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 541)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Android_filemanager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Android File Manager "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownloadFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileInTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetWallpaperToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenDowloadsFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ViewImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExecuteFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextNotepadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ApkInstallerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureGifToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureJpgjpegToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Video3gpmpgToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AudioWavmp3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WordPadRtfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdobePdfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DocumentDocdocxToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PowerpointPptpptxToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExcelXlsxlsxToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileZiprarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnknownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
