#Region "Imports"
Imports System.Net.Sockets
Imports System.Text
Imports System.IO
Imports System.ComponentModel

#End Region

Public Class Main

#Region "Dims"
    Dim cSocket As New System.Net.Sockets.TcpClient() ' Initiates client socket.
    Public Shared servStream As NetworkStream ' Server stream
    Dim read As String
    Dim count As Integer
#End Region

#Region "Multithreading + Message Handling"
    Private Sub msgthread()

        If Me.InvokeRequired Then ' Thank you André for helping me out on this part.
            Me.Invoke(New MethodInvoker(AddressOf msgthread)) ' Multithread
        Else
            Try
            Catch ex As NullReferenceException
            End Try
        End If

    End Sub
#End Region

#Region "Stresstest Button"
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim usercount As Integer
        If String.IsNullOrEmpty(TextBox3.Text) Then
            MsgBox("Please insert a IP.")
        Else
            If Not IsNumeric(TextBox1.Text) Then
                MsgBox("Please insert a numeric value into the Port textbox.")
            Else
                Try
                    Do
                        Try
                            Dim nickname As String = "yo" & usercount
                            cSocket = New System.Net.Sockets.TcpClient
                            msgthread()
                            If String.IsNullOrEmpty(TextBox2.Text) Then
                                MsgBox("Please insert a value into the Amount of Users Textbox.")
                                Exit Sub
                            End If
                            cSocket.Connect(TextBox3.Text, TextBox2.Text) ' Connects to IP and port
                            servStream = cSocket.GetStream() ' Client to Server handling
                            Dim Stream_out As Byte() = System.Text.Encoding.ASCII.GetBytes(nickname + "$")
                            servStream.Write(Stream_out, 0, Stream_out.Length)
                            servStream.Flush()
                            usercount = usercount + 1
                            count = count + 1
                            Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf getMsg) ' Client Threading
                            ctThread.Start()
                        Catch ex As SocketException
                            If MsgBox("Error performing Stresstest.") = DialogResult.OK Then
                                My.Computer.FileSystem.WriteAllText("StressTest " + FormatDateTime(DateAndTime.Today, DateFormat.LongDate) + ".log", "Stress test FAILED at: " + DateTime.UtcNow + Environment.NewLine, True)
                                Exit Sub
                            End If
                        End Try
                    Loop Until count = TextBox1.Text
                    MsgBox("Stress test completed." + Environment.NewLine + "Amount of users tested: " & usercount)
                Catch ex As IOException
                End Try
            End If
        End If
    End Sub
#End Region

#Region "Get Message handle"
    Private Sub getMsg()
        Try
            Do While True
                servStream = cSocket.GetStream() ' Server to Client Handling
                Dim buffSize As Integer ' Buffer size
                Dim Stream_in(10024) As Byte ' Buffer size for BuffSize (also max bytes allowed by server.)
                buffSize = cSocket.ReceiveBufferSize
                servStream.Read(Stream_in, 0, buffSize)
                Dim returnd As String = System.Text.Encoding.ASCII.GetString(Stream_in)
                read = "" + returnd ' Data received from server.
                msgthread()
            Loop
        Catch ex As IOException

        Catch ex2 As ObjectDisposedException

        Catch ex3 As InvalidOperationException

        Catch ex4 As Win32Exception
            End
        End Try
    End Sub
#End Region

    Private Sub Main_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            cSocket.Close()
            My.Computer.FileSystem.WriteAllText("StressTest " + FormatDateTime(DateAndTime.Today, DateFormat.LongDate) + ".log", "Stress test completed at: " + DateTime.UtcNow + Environment.NewLine, True)
            End
        Catch ex As IOException
        End Try
    End Sub
End Class
