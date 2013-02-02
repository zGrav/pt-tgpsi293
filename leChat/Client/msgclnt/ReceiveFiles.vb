#Region "Imports"
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.Net.Sockets
#End Region

Partial Public Class ReceiveFiles

#Region "Declarations"
    Private thread1 As Thread
    Private flag As Integer = 0
    Private receivedPath As String
    Private savePath As String
    Public Delegate Sub invokehelp()

    Public Sub New() ' Threading
        MyBase.New()
        thread1 = New Thread(New ThreadStart(AddressOf StartServer))
        thread1.Start()
        InitializeComponent()
    End Sub
#End Region

#Region "Class State + isDone Reset"
    Public Class State

        ' Client socket.
        Public Socket_w As Socket = Nothing

        Public Const BufferSize As Integer = 1638400 ' 2MB

        ' Receive buffer.
        Public buffer() As Byte = New Byte((BufferSize) - 1) {}
    End Class

    Public Shared isDone As ManualResetEvent = New ManualResetEvent(False)
#End Region

#Region "Start"
    Public Sub StartServer()
        Dim bytes() As Byte = New Byte((1024) - 1) {}
        Dim endIP As IPEndPoint = New IPEndPoint(IPAddress.Any, 8889)
        Dim listenSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Try
            listenSocket.Bind(endIP)
            listenSocket.Listen(100)

            While True
                isDone.Reset()
                listenSocket.BeginAccept(New AsyncCallback(AddressOf Accept), listenSocket)
                isDone.WaitOne()

            End While
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Accept"
    Public Sub Accept(ByVal ar As IAsyncResult)
        isDone.Set()
        Dim listenSocket As Socket = CType(ar.AsyncState, Socket)
        Dim handle As Socket = listenSocket.EndAccept(ar)
        Dim stateofSocket As State = New State
        Dim filename As String = Files.fName
        Dim ciplocal As String
        Dim cipremote As String
        cipremote = handle.RemoteEndPoint.ToString
        cipremote = cipremote.Substring(0, cipremote.IndexOf(":"))
        ciplocal = handle.LocalEndPoint.ToString
        ciplocal = ciplocal.Substring(0, ciplocal.IndexOf(":"))
        stateofSocket.Socket_w = handle
        If handle.Connected = True Then
            If MsgBox("Incoming file " + Files.fName + ", do you want to accept it?", MsgBoxStyle.YesNo) = DialogResult.No Then
                Dim Stream_out As Byte() = System.Text.Encoding.ASCII.GetBytes(Main.info.Nickname + " " + ciplocal + " declined file: " + Files.fName + " from: " + cipremote + "$") 'Passes msgtxt content to OutStream and encoded.
                Main.servStream.Write(Stream_out, 0, Stream_out.Length) ' Send message to server
                Main.servStream.Flush() ' Resets stream
                Exit Sub
            Else
                Dim Stream_out As Byte() = System.Text.Encoding.ASCII.GetBytes(Main.info.Nickname + " " + ciplocal + " accepted file: " + Files.fName + " from: " + cipremote + "$") 'Passes msgtxt content to OutStream and encoded.
                Main.servStream.Write(Stream_out, 0, Stream_out.Length) ' Send message to server
                Main.servStream.Flush() ' Resets stream
                handle.BeginReceive(stateofSocket.buffer, 0, State.BufferSize, 0, New AsyncCallback(AddressOf Read), stateofSocket)
                flag = 0
            End If
        End If
    End Sub
#End Region

#Region "Read"
    Public Sub Read(ByVal ar As IAsyncResult)
        Dim fileNameLength As Integer = 1
        Dim contofFile As String = String.Empty
        Dim stateofSocket As State = CType(ar.AsyncState, State)
        Dim handle As Socket = stateofSocket.Socket_w
        Dim bytes_Read As Integer = handle.EndReceive(ar)
        If (bytes_Read > 0) Then
            If (flag = 0) Then
                fileNameLength = BitConverter.ToInt32(stateofSocket.buffer, 0)
                Dim fileName As String = Encoding.UTF8.GetString(stateofSocket.buffer, 4, fileNameLength)
                receivedPath = savePath & "\" & fileName
                flag = (flag + 1)
            End If
            If (flag >= 1) Then
                Dim write_file As BinaryWriter = New BinaryWriter(File.Open(receivedPath, FileMode.Append))
                If (flag = 1) Then
                    write_file.Write(stateofSocket.buffer, (4 + fileNameLength), (bytes_Read - (4 + fileNameLength)))
                    flag = (flag + 1)
                Else
                    write_file.Write(stateofSocket.buffer, 0, bytes_Read)
                End If
                write_file.Close()
                handle.BeginReceive(stateofSocket.buffer, 0, State.BufferSize, 0, New AsyncCallback(AddressOf Read), stateofSocket)
            End If
        Else
            Invoke(New invokehelp(AddressOf Labelchange))
        End If
    End Sub
#End Region

#Region "Misc"

    Public Sub Labelchange()
        Label1.Text = "Download complete!"
    End Sub

    Private Sub ReceiveFiles_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
        thread1.Abort()
    End Sub

    Private Sub savepathbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savepathbtn.Click
        FolderBrowserDialog1.ShowDialog()
        savePath = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub ReceiveFiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        savePath = My.Computer.FileSystem.SpecialDirectories.Desktop
    End Sub
#End Region
End Class

' leChat Client - Recieve Files (aSync Sockets) - This program might be rewritten using aSync Sockets like the Files and ReceiveFiles on the Client were implemented or fully recoded in C#.

' This seriously took a lot of my time and my sleep.
' So please, contribute and report bugs or any new features you would like to be implemented.
' Contact me at zgrav@null.net for more information
' Check out my Github if you're interested on any other project that I might have - http://github.com/zGrav
' Don't steal Source Code, read it, learn it, adapt it and give credit to original owner.
' This program was developed by me and my coworker EvilMonstah/Diogo Alexandre who helped out on ideas, documentation and implementation of some features.
' (c) zGrav/David Samuel - 22nd June 2012