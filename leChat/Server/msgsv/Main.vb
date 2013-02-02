'OPTIONALFIX:
' Sending same message on disconnect (dataclnt.indexof problem, kind of useful to be honest.)

'Disabled Exception messages

#Region "Imports"
Imports System.Net.Sockets
Imports System.Text
Imports System.Net
Imports System.Threading
Imports System.IO
Imports System
Imports System.Console
Imports System.Windows.Forms

#End Region

Module Main

#Region "Timer Tick - Clientlist"
    Public Sub tick(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        Console.WriteLine()
        Console.WriteLine("User List updated.")
        Console.WriteLine()
        Dim countclient As Integer = count - 1
        Dim i As Integer = 0
        While i <> countclient
            Try
                If i <> countclient Then
                    bcast("$Username: " & userlist.Item(i).ToString, Nothing, False)
                    Thread.Sleep(500) 'temporary fix?
                    i = i + 1
                End If
            Catch ex As ArgumentOutOfRangeException
                Exit While
            End Try
        End While
    End Sub
#End Region

#Region "Dims"
    Dim port As String ' Port used for Server
    Dim dataClnt As String ' Data from Client
    Dim clList As New Hashtable ' Clients
    Dim clntDisc As Boolean ' Client Disconnect
    Dim count As Integer ' Used for clients ID
    Dim fileflag As Boolean ' File Flagging
    Dim msg2 As String ' Client Commands
    Dim concmds As String ' Console cmds
    Dim userlist As New ArrayList ' Connected users
    Dim iplist As New ArrayList ' Connected users IP
    Dim listtimer As New System.Timers.Timer ' Clientlist Timer
    Dim banlist As New ArrayList ' Ban list
    Dim banstr As String ' Ban User String
    Dim banfile As String ' Ban files
    Dim iprange As String ' IP Range ban
    Dim internalIP As New ArrayList ' GetIPv4 workaround if more than one network card detected
    Dim intIPcount As Integer ' Counts Internal IP's for workaround
    Dim intIPchoice As Integer ' Choice of Internal IP
    Dim colorchoice As String ' Console Foreground color
    Dim socketlist As New ArrayList ' Connected user sockets
    Dim usersearch As String ' Workaround for client termination
    Dim PrettyVersion As String = "1.0"
    Dim BuildNumber As String = "2"
    Dim BuildDate As String = "13-07-2012"
#End Region

#Region "ASCII art"
    ' Art courtesy of patorjk.com/software/taag/
    Dim asc1 As String = " _           ____   _               _   "
    Dim asc2 As String = "| |   ___   / ___| | |__     __ _  | |_ "
    Dim asc3 As String = "| |  / _ \ | |     | '_ \   / _` | | __|"
    Dim asc4 As String = "| | |  __/ | |___  | | | | | (_| | | |_ "
    Dim asc5 As String = "|_|  \___|  \____| |_| |_|  \__,_|  \__|"
#End Region

#Region "Get IPv4 Function"
    Private Function GetIPv4Address() As String
        ' Using code from http://stackoverflow.com/questions/2234757/how-do-i-get-a-computers-name-and-ip-address-using-vb-net due to difference from WinXP/Win7 IPconfig
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)
        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPv4Address = ipheal.ToString()
                internalIP.Add(GetIPv4Address)
            End If
        Next
    End Function
#End Region

#Region "TCP/IP protocol and Client handling"

    Sub Main()
        If Directory.Exists(Application.StartupPath & "\Log") = False Then
            Call Directory.CreateDirectory(Application.StartupPath & "\Log")
        End If
        My.Computer.FileSystem.WriteAllText("Log\Server Log " + FormatDateTime(DateAndTime.Today, DateFormat.LongDate) + ".log", DateTime.UtcNow + " >> " + "Server start!" + Environment.NewLine, True)
        Console.WindowWidth = "100"
        Console.WindowHeight = "50"
        Console.Title = "leChat Server"
        Try
            For i = 0 To My.Computer.FileSystem.GetFiles("Bans\").Count - 1
                banfile = My.Computer.FileSystem.GetFiles("Bans\")(i).ToString
                banfile = banfile.Remove(0, My.Computer.FileSystem.CurrentDirectory.Count + 6)
                banlist.Add(banfile)
            Next
        Catch ex As Exception
        End Try
        Console.WriteLine("leChat Server - Startup - Console Color setting:")
        Console.WriteLine()
        Console.WriteLine("Please pick your console color.")
        Console.WriteLine()
        Console.WriteLine("1 - White")
        Console.WriteLine("2 - Red")
        Console.WriteLine("3 - Cyan")
        Console.WriteLine("4 - Green")
        Console.WriteLine("5 - Yellow")
        Console.WriteLine("6 - Magenta")
        Console.WriteLine("7 - Default (Gray)")
        Console.WriteLine()
        colorchoice = ReadLine()
        If Not IsNumeric(colorchoice) Then
            Console.WriteLine()
            Console.WriteLine("Incorrect color value detected. Setting to 7 - Default (Gray).")
            Console.ForegroundColor = ConsoleColor.Gray
        End If
        Select Case colorchoice
            Case "1"
                Console.ForegroundColor = ConsoleColor.White
            Case "2"
                Console.ForegroundColor = ConsoleColor.Red
            Case "3"
                Console.ForegroundColor = ConsoleColor.Cyan
            Case "4"
                Console.ForegroundColor = ConsoleColor.Green
            Case "5"
                Console.ForegroundColor = ConsoleColor.Yellow
            Case "6"
                Console.ForegroundColor = ConsoleColor.Magenta
            Case "7"
                Console.ForegroundColor = ConsoleColor.Gray
            Case Else
                Console.WriteLine()
                Console.WriteLine("Incorrect color value detected. Setting to 7 - Default (Gray).")
                Console.ForegroundColor = ConsoleColor.Gray
                Thread.Sleep(1000)
        End Select
        ' BEGIN: GetIPv4 workaround if more than one network card installed/detected.
        GetIPv4Address()
        Console.Clear()
        If internalIP.Count > 1 Then
            Console.WriteLine("leChat Server - Startup - IP setting:")
            Console.WriteLine()
            Console.WriteLine("Please select your IP that you use to access the Internet.")
            Console.WriteLine("We recommend only choosing another IP if you are using this program for testing purposes only.")
            Console.WriteLine()
            For intIPcount = 0 To internalIP.Count - 1
                Console.WriteLine(intIPcount + 1 & " - " & internalIP.Item(intIPcount).ToString)
            Next
            Try
                Console.WriteLine()
                intIPchoice = ReadLine()
            Catch ex As Exception
            End Try
            If intIPchoice < 1 Or intIPchoice > internalIP.Count Then
                Console.WriteLine()
                Console.WriteLine("An incorrect IP value has been detected. Program restarting in 3 seconds.")
                Console.WriteLine()
                If Directory.Exists(Application.StartupPath & "\Log") = False Then
                    Call Directory.CreateDirectory(Application.StartupPath & "\Log")
                End If
                My.Computer.FileSystem.WriteAllText("Log\Server Log " + FormatDateTime(DateAndTime.Today, DateFormat.LongDate) + ".log", DateTime.UtcNow + " >> " + "Server restarted!" + Environment.NewLine, True)
                Thread.Sleep(3000)
                Application.Restart()
                End
            End If
            Console.Clear()
        End If
        ' END: GetIPv4 workaround if more than one network card installed/detected.
        Console.WriteLine("leChat Server - Startup - Port setting:")
        Console.WriteLine()
        Console.WriteLine("Please insert a port.")
        Console.WriteLine()
        Console.WriteLine("If no port is entered, the default will be 8888.")
        Console.WriteLine()
        port = ReadLine()
        If port = "0" Then
            Console.WriteLine()
            Console.WriteLine("An incorrect port value has been detected. Program restarting in 3 seconds.")
            If Directory.Exists(Application.StartupPath & "\Log") = False Then
                Call Directory.CreateDirectory(Application.StartupPath & "\Log")
            End If
            My.Computer.FileSystem.WriteAllText("Log\Server Log " + FormatDateTime(DateAndTime.Today, DateFormat.LongDate) + ".log", DateTime.UtcNow + " >> " + "Server restarted!" + Environment.NewLine, True)
            Thread.Sleep(3000)
            Application.Restart()
            End
        End If
        If port = Nothing Then
            port = 8888
        End If
        If IsNumeric(port) = True Then
            '---timer---
            listtimer.AutoReset = True
            listtimer.Interval = 60000
            AddHandler listtimer.Elapsed, AddressOf tick
            listtimer.Enabled = True
            listtimer.Start()
            '---timer end---

            Try
                Dim server As TcpListener
                If internalIP.Count > 1 Then
                    server = New TcpListener(System.Net.IPAddress.Parse(internalIP.Item(intIPchoice - 1).ToString), port)
                Else
                    server = New TcpListener(System.Net.IPAddress.Parse(internalIP.Item(intIPchoice).ToString), port)
                End If
                Dim client As TcpClient
                Console.Clear()
                Dim conShellThread As Threading.Thread = New Threading.Thread(AddressOf conShell)
                server.Start()
                Console.WriteLine(asc1)
                Thread.Sleep(100)
                Console.WriteLine(asc2)
                Thread.Sleep(100)
                Console.WriteLine(asc3)
                Thread.Sleep(100)
                Console.WriteLine(asc4)
                Thread.Sleep(100)
                Console.WriteLine(asc5)
                Thread.Sleep(100)
                Console.WriteLine("                                     " + PrettyVersion)
                Thread.Sleep(100)
                Console.WriteLine()
                Console.WriteLine("Setting up leChat Server Environment:")
                Thread.Sleep(100)
                Console.WriteLine("Resetting and loading Hashtables & Arraylists")
                Thread.Sleep(100)
                Console.WriteLine("Optimizing Server connection")
                Thread.Sleep(100)
                Console.WriteLine("Setting port")
                Thread.Sleep(100)
                Console.WriteLine("Loading User Ban list")
                Thread.Sleep(100)
                Console.WriteLine("Resetting Client Update timer")
                Thread.Sleep(200)
                Console.WriteLine()
                Console.WriteLine("leChat Server Environment is ready!")
                Thread.Sleep(150)
                If internalIP.Count > 1 Then
                    message("IP: " + internalIP.Item(intIPchoice - 1))
                Else
                    message("IP: " + internalIP.Item(intIPchoice).ToString)
                End If
                message("Port: " + port)
                conShellThread.Start()
                count = 0
                While (True)
                    count += 1
                    client = server.AcceptTcpClient()
                    Dim bytes(10024) As Byte
                    Dim netwrkStream As NetworkStream = client.GetStream() ' Network and Client data Stream
                    netwrkStream.Read(bytes, 0, CInt(client.ReceiveBufferSize)) ' Reads data received from client.
                    dataClnt = System.Text.Encoding.ASCII.GetString(bytes)
                    If dataClnt.IndexOf("$") < 0 Then
                        clntDisc = True
                        Exit Sub
                    Else
                        dataClnt = dataClnt.Substring(0, dataClnt.IndexOf("$"))
                        Dim orgnick As String
                        Dim countuser As Integer
                        Dim orgnickbackup As String
                        orgnick = dataClnt
                        countuser = countuser + 1
                        orgnickbackup = orgnick
                        If countuser > 1 AndAlso orgnick = dataClnt Then
                            If clList.Contains(orgnickbackup) Then
                                dataClnt = dataClnt & "_" & countuser
                                orgnick = ""
                                message("Multiple nickname found: " & orgnickbackup)
                                clList(dataClnt) = client
                                bcast(dataClnt + " " + "(" + Convert.ToString(count) + ")" + " " + "joined " + DateAndTime.Now, dataClnt, False)
                                message(dataClnt + " " + "(" + Convert.ToString(count) + ")" + " " + "joined the lobby. " + DateTime.Now)
                                Dim clienth2 As New handleClnt
                                clienth2.startClient(client, dataClnt, clList)
                                singlebcast("This nickname is in use by another client.", Nothing, False)
                                countuser = 0
                                Continue While
                            End If
                        End If
                        If userlist.Contains(orgnickbackup) Then
                            For i = 0 To userlist.Count - 1
                                If userlist.Item(i).ToString.Contains(orgnickbackup) Then
                                    countuser = countuser + 1
                                End If
                            Next
                            dataClnt = dataClnt & "_" & countuser
                            orgnick = ""
                            message("Multiple nickname found: " & orgnickbackup)
                            clList(dataClnt) = client
                            bcast(dataClnt + " " + "(" + Convert.ToString(count) + ")" + " " + "joined " + DateAndTime.Now, dataClnt, False)
                            message(dataClnt + " " + "(" + Convert.ToString(count) + ")" + " " + "joined the lobby. " + DateTime.Now)
                            Dim clienth3 As New handleClnt
                            clienth3.startClient(client, dataClnt, clList)
                            singlebcast("This nickname is in use by another client.", Nothing, False)
                            countuser = 0
                            Continue While
                        Else
                            clList(dataClnt) = client
                            bcast(dataClnt + " " + "(" + Convert.ToString(count) + ")" + " " + "joined " + DateAndTime.Now, dataClnt, False)
                            message(dataClnt + " " + "(" + Convert.ToString(count) + ")" + " " + "joined the lobby. " + DateTime.Now)
                            Dim clienth As New handleClnt
                            clienth.startClient(client, dataClnt, clList) ' Client handler
                        End If
                    End If
                End While
            Catch ex As IOException
                '  message("Socket not disposed properly.")
                clntDisc = True
            End Try
        Else
            Console.WriteLine()
            Console.WriteLine("An incorrect port value has been detected. Program restarting in 3 seconds.")
            Console.WriteLine()
            If Directory.Exists(Application.StartupPath & "\Log") = False Then
                Call Directory.CreateDirectory(Application.StartupPath & "\Log")
            End If
            My.Computer.FileSystem.WriteAllText("Log\Server Log " + FormatDateTime(DateAndTime.Today, DateFormat.LongDate) + ".log", DateTime.UtcNow + " >> " + "Server restarted!" + Environment.NewLine, True)
            Thread.Sleep(3000)
            Application.Restart()
            End
        End If
    End Sub
#End Region

#Region "Console loading"
    Sub message(ByVal svmsg As String)
        Try
            svmsg.Trim()
            Console.WriteLine()
            Console.WriteLine(" >> " + svmsg)
            Console.WriteLine()
            If Directory.Exists(Application.StartupPath & "\Log") = False Then
                Call Directory.CreateDirectory(Application.StartupPath & "\Log")
            End If
            My.Computer.FileSystem.WriteAllText("Log\Server Log " + FormatDateTime(DateAndTime.Today, DateFormat.LongDate) + ".log", DateTime.UtcNow + " >> " + svmsg + Environment.NewLine, True)
        Catch ex As IOException
            Console.WriteLine()
            Console.WriteLine("Could not write to log file.")
            Console.WriteLine()
        End Try
    End Sub
#End Region

#Region "Broadcasting"
    Private Sub bcast(ByVal msg As String, ByVal userName As String, ByVal msgflag As Boolean)
        Dim Item As DictionaryEntry
        Try
            For Each Item In clList
                Dim bcastSocket As TcpClient 'Broadcast Socket
                bcastSocket = CType(Item.Value, TcpClient)
                Dim bcastStream As NetworkStream = bcastSocket.GetStream()
                Dim bcastBytes As [Byte]() 'Broadcast Length received on bcastStream.Write
                If msgflag = True Then
                    bcastBytes = Encoding.ASCII.GetBytes(DateTime.Now + " " + userName + " says : " + msg)
                    msg2 = msg
                Else
                    bcastBytes = Encoding.ASCII.GetBytes(msg)
                End If

                bcastStream.Write(bcastBytes, 0, bcastBytes.Length)
                bcastStream.Flush()
            Next
        Catch ex As IOException
            '   message("Socket not disposed properly.")
            clntDisc = True

        Catch ex2 As ObjectDisposedException
            '     message("Object not disposed properly.")
            clntDisc = True

        Catch ex3 As InvalidOperationException
            '       message("Socket not disposed properly.")
            clntDisc = True
        End Try
    End Sub

    Private Sub singlebcast(ByVal msg As String, ByVal userName As String, ByVal msgflag As Boolean)
        Dim userindex As Integer
        Try
            For i = 0 To userlist.Count - 1
                If dataClnt <> Nothing Then
                    userindex = userlist.IndexOf(dataClnt)
                End If
                If banstr <> Nothing Then
                    userindex = userlist.IndexOf(banstr)
                End If
                If banfile <> Nothing Then
                    userindex = iplist.IndexOf(banfile)
                    If userindex = -1 Then
                        userindex = userlist.IndexOf(banfile)
                    End If
                    If userindex = -1 Then
                        userindex = iplist.Contains(banfile)
                    End If
                End If
                If usersearch <> Nothing Then
                    userindex = userlist.IndexOf(usersearch)
                End If
                Dim bcastSocket As TcpClient 'Broadcast Socket
                bcastSocket = CType(socketlist.Item(userindex), TcpClient)
                Dim bcastStream As NetworkStream = bcastSocket.GetStream()
                Dim bcastBytes As [Byte]() 'Broadcast Length received on bcastStream.Write
                bcastBytes = Encoding.ASCII.GetBytes(msg)

                bcastStream.Write(bcastBytes, 0, bcastBytes.Length)
                bcastStream.Flush()
            Next
        Catch ex4 As ArgumentOutOfRangeException

        Catch ex As IOException
            '   message("Socket not disposed properly.")
            clntDisc = True

        Catch ex2 As ObjectDisposedException
            '     message("Object not disposed properly.")
            clntDisc = True

        Catch ex3 As InvalidOperationException
            '       message("Socket not disposed properly.")
            clntDisc = True
        End Try
    End Sub

#End Region

#Region "Client/Chat handling"
    Public Class handleClnt
        Dim cSocket As TcpClient ' Client Socket
        Dim clName As String
        Dim clList As Hashtable
        Dim cnum As Integer
        Dim cip As String

        Public Sub startClient(ByVal inClntSocket As TcpClient, ByVal clntName As String, ByVal cList As Hashtable)
            Me.cSocket = inClntSocket ' Client Socket
            Me.clName = clntName ' Client Name
            Me.clList = cList ' Client List
            Me.cip = inClntSocket.Client.RemoteEndPoint.ToString
            cip = cip.Substring(0, cip.IndexOf(":"))
            Me.cnum = count ' Client Number
            userlist.Add(Me.clName)
            iplist.Add(Me.cip)
            socketlist.Add(Me.cSocket)
            Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf initiateChat) ' Client Threading
            ctThread.Start()
        End Sub

        Private Sub initiateChat() ' Message from Client
            Dim bytesFrom(10024) As Byte
            Dim dataClnt As String ' Data from Client to Server
            While (True)
                Try
                    Dim Stream_network As NetworkStream = cSocket.GetStream() ' Network Stream
                    Stream_network.Read(bytesFrom, 0, CInt(cSocket.ReceiveBufferSize))
                    dataClnt = System.Text.Encoding.ASCII.GetString(bytesFrom)
                    If dataClnt.IndexOf("$") < 0 Then
                        clntDisc = True
                        cdisc()
                        Exit Sub
                    Else
                        dataClnt = dataClnt.Substring(0, dataClnt.IndexOf("$"))
                        message("Client - " + DateTime.Now + " " + Me.clName + " " + Me.cip + " " + "(" + Convert.ToString(cnum) + ")" + " : " + dataClnt)
                        Dim namelength As Integer
                        namelength = Me.clName.Length
                        If dataClnt.Contains("is sending a file") = True Then
                            fileflag = True
                            bcast(dataClnt, clName, False)
                        Else
                            fileflag = False
                            cmds()
                            If dataClnt = "/getusers" Then
                                msg2 = dataClnt
                                cmds()
                                bcast("Command typed: " + dataClnt, Nothing, False)
                            ElseIf dataClnt.Contains("/whois") Then
                                msg2 = dataClnt
                                cmds()
                                bcast("Command typed: " + dataClnt, Nothing, False)
                            ElseIf dataClnt.Contains("/myinfo") Then
                                msg2 = dataClnt
                                cmds()
                                bcast("Command typed: " + dataClnt, Nothing, False)
                            Else
                                bcast(dataClnt, clName, True)
                            End If
                        End If
                        If dataClnt.Contains("has changed his name to ") = True Then
                            Dim length As Integer
                            Dim copystring As String
                            Dim stringv2 As String = " has changed his name to "
                            copystring = dataClnt.Remove(0, namelength)
                            length = stringv2.Length
                            copystring = copystring.Remove(0, length - 1)
                            copystring = copystring.Replace(" ", "")
                            For i = 0 To userlist.Count - 1
                                If userlist.Item(i).ToString.Contains(Me.clName) Then
                                    userlist.RemoveAt(i)
                                End If
                            Next
                            For i = 0 To Me.clList.Count - 1
                                If clList.Contains(Me.clName) Then
                                    clList.Remove(Me.clName)
                                    clList.Add(copystring, cSocket)
                                End If
                            Next
                            Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf initiateChat)
                            Me.clName = copystring
                            userlist.Add(copystring)
                            dataClnt = copystring
                            startClient(cSocket, copystring, clList)
                            ctThread.Start()
                        End If
                    End If
                    Try
                        For i = 0 To My.Computer.FileSystem.GetFiles("Bans\").Count - 1
                            banfile = My.Computer.FileSystem.GetFiles("Bans\")(i).ToString
                            banfile = banfile.Remove(0, My.Computer.FileSystem.CurrentDirectory.Count + 6)
                            If userlist.Item(i).ToString.Contains(banfile) Or iplist.Item(i).ToString.Contains(banfile) Then
                                singlebcast("You were disconnected due to a ban. $", Nothing, Nothing)
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                Catch ex2 As Exception
                    If cSocket.Connected = False Then
                        clntDisc = True
                        cSocket.Close()
                        cdisc()
                        Exit Sub
                    End If
                End Try
            End While
        End Sub

        Sub cdisc()
            If clntDisc = True Then
                message(clName + " " + "(" + Convert.ToString(cnum) + ")" + " " + "has disconnected. " + DateTime.Now)
                bcast(clName + " has disconnected. $", Nothing, False)
                If Me.cnum = cnum Then
                    clList.Remove(Me.clName)
                    clList.Remove(Me.cip)
                    clList.Remove(Me.cnum)
                    clList.Remove(Me.cSocket)
                    userlist.Remove(Me.clName)
                    iplist.Remove(Me.cip)
                    socketlist.Remove(Me.cSocket)
                End If
                cSocket.Close()
                clntDisc = False
                Exit Sub
            End If
        End Sub

        Sub cmds()
            Dim whoisstr As String
            If msg2 Is Nothing Then
                Exit Sub
            Else
                Select Case msg2
                    Case "/getusers"
                        If msg2 = "/getusers" Then
                            Dim countclient As Integer = count - 1
                            Dim i As Integer = 0
                            While i <> countclient
                                Try
                                    If i <> countclient Then
                                        bcast("$Username: " & userlist.Item(i).ToString, Nothing, False)
                                        Thread.Sleep(500) 'temporary fix?
                                        i = i + 1
                                    End If
                                Catch ex As ArgumentOutOfRangeException
                                    Exit While
                                End Try
                            End While
                        End If
                    Case "/myinfo"
                        Dim getip As String
                        If msg2 = "/myinfo" Then
                            msg2 = ""
                            getip = Me.cip
                            bcast("IP is: " + getip + " ", Me.clName, False)
                        End If
                End Select

                If msg2.Contains("/whois") Then
                    whoisstr = "/whoisstr"
                End If
                Select Case whoisstr
                    Case "/whoisstr"
                        Dim copy As String
                        copy = msg2
                        msg2 = ""
                        copy = copy.Remove(0, 7)
                        Dim i As Integer
                        Dim test As Integer = count - 1
                        While i <> test
                            Try
                                If i <> test Then
                                    If userlist.Item(i).Equals(copy) Then
                                        Dim ip As String
                                        ip = iplist.Item(i).ToString
                                        bcast("Whois" + Environment.NewLine + "Username: " + copy + Environment.NewLine + "IP: " + ip, Nothing, False)
                                    End If
                                    i = i + 1
                                End If
                            Catch ex As ArgumentOutOfRangeException
                            End Try
                        End While
                End Select

            End If
        End Sub
    End Class
#End Region

#Region "Console Shell/Commands"
    Public Sub conShell()
        While (True)
            Try
                Console.WriteLine()
                Console.WriteLine("leChat Server - Awaiting command input (type help for a command list):")
                Console.WriteLine()
                concmds = ReadLine()
                concmds = concmds.ToLower
                conCmdinterp()
                If Directory.Exists(Application.StartupPath & "\Log") = False Then
                    Call Directory.CreateDirectory(Application.StartupPath & "\Log")
                End If
                My.Computer.FileSystem.WriteAllText("Log\Server Log " + FormatDateTime(DateAndTime.Today, DateFormat.LongDate) + ".log", DateTime.UtcNow + " >> " + "Command typed: " + concmds + Environment.NewLine, True)
            Catch ex As IOException
                Console.WriteLine()
                Console.WriteLine("Could not write to log file.")
                Console.WriteLine()
            End Try
        End While
    End Sub
    Private Sub conCmdinterp()
        Select Case concmds
            Case "help"
                Console.WriteLine()
                Console.WriteLine("leChat Server - Available commands:")
                Console.WriteLine()
                Console.WriteLine("Server management commands:")
                Console.WriteLine()
                Console.WriteLine("info - displays IP & Port in use and Server uptime.")
                Console.WriteLine("about - displays server version, revision and build date")
                Console.WriteLine("shoutouts - thank you to the following people")
                Console.WriteLine("color - sets/changes console text color")
                Console.WriteLine("restart - restarts server")
                Console.WriteLine("shutdown - shutdowns the server")
                Console.WriteLine("clear - clears console.")
                Console.WriteLine()
                Console.WriteLine("User related commands:")
                Console.WriteLine()
                Console.WriteLine("list - type for more options")
                Console.WriteLine("locate - type for more options")
                Console.WriteLine("terminate - type for more options")
                Console.WriteLine("ban - adds a user/IP/IP Range to the ban list")
                Console.WriteLine("unban - unbans a user/IP/IP Range from the list")
                Console.WriteLine("say - sends a message to clients as Server Operator")
                Console.WriteLine("timer on - starts the userlist timer if disabled.")
                Console.WriteLine("timer off - stops the userlist timer if enabled.")
                Console.WriteLine("refresh bans - updates ban list if manually edited")
                Console.WriteLine("delete bans - deletes all bans")
                Console.WriteLine()
            Case "info"
                Dim uptime As TimeSpan = DateTime.Now - Process.GetCurrentProcess().StartTime
                Console.WriteLine()
                Console.WriteLine(asc1)
                Console.WriteLine(asc2)
                Console.WriteLine(asc3)
                Console.WriteLine(asc4)
                Console.WriteLine(asc5)
                Console.WriteLine()
                Console.WriteLine("Current Server info:")
                Console.WriteLine()
                If internalIP.Count > 1 Then
                    Console.WriteLine("IP: " + internalIP.Item(intIPchoice - 1))
                Else
                    Console.WriteLine("IP: " + internalIP.Item(intIPchoice).ToString)
                End If
                Console.WriteLine("Port: " & port)
                Console.WriteLine("Amount of connected users: " & userlist.Count)
                Console.WriteLine("Server Uptime: " & uptime.ToString.Substring(0, 8))
            Case "about"
                Console.WriteLine()
                Console.WriteLine(asc1)
                Console.WriteLine(asc2)
                Console.WriteLine(asc3)
                Console.WriteLine(asc4)
                Console.WriteLine(asc5)
                Console.WriteLine()
                Console.WriteLine("Server specifications:")
                Console.WriteLine()
                Console.WriteLine("Version " & PrettyVersion & " - revision " & BuildNumber & " - build date " & BuildDate)
                Console.WriteLine()
                Console.WriteLine("For bug reports & feature implementation or any other info, please report them to zgrav@null.net")
                Console.WriteLine()
                Console.WriteLine("Thank you for trying out this software! :D")
            Case "color"
                Console.WriteLine()
                Console.WriteLine("Please pick your console color.")
                Console.WriteLine()
                Console.WriteLine("1 - White")
                Console.WriteLine("2 - Red")
                Console.WriteLine("3 - Cyan")
                Console.WriteLine("4 - Green")
                Console.WriteLine("5 - Yellow")
                Console.WriteLine("6 - Magenta")
                Console.WriteLine("7 - Default (Gray)")
                Console.WriteLine()
                colorchoice = ReadLine()
                If Not IsNumeric(colorchoice) Then
                    Console.WriteLine()
                    Console.WriteLine("Incorrect color value detected.")
                    Thread.Sleep(1000)
                End If
                Select Case colorchoice
                    Case "1"
                        Console.ForegroundColor = ConsoleColor.White
                    Case "2"
                        Console.ForegroundColor = ConsoleColor.Red
                    Case "3"
                        Console.ForegroundColor = ConsoleColor.Cyan
                    Case "4"
                        Console.ForegroundColor = ConsoleColor.Green
                    Case "5"
                        Console.ForegroundColor = ConsoleColor.Yellow
                    Case "6"
                        Console.ForegroundColor = ConsoleColor.Magenta
                    Case "7"
                        Console.ForegroundColor = ConsoleColor.Gray
                    Case Else
                        Console.WriteLine()
                        Console.WriteLine("Incorrect color value detected.")
                        Thread.Sleep(1000)
                End Select
            Case "shoutouts"
                Console.Clear()
                Console.WriteLine(asc1)
                Console.WriteLine(asc2)
                Console.WriteLine(asc3)
                Console.WriteLine(asc4)
                Console.WriteLine(asc5)
                Console.WriteLine()
                Console.WriteLine("Shoutouts to the following people!")
                Console.WriteLine()
                Console.WriteLine("zGrav/David Samuel - tryhard coder.")
                Console.WriteLine("EvilMonstah/Diogo Alexandre - epic nublet that codes random stuff <3")
                Console.WriteLine("Mauro Henriques - Go do the emulator, bro! :P")
                Console.WriteLine("João Mota - poor guy, trolololol")
                Console.WriteLine("João Pedro - stop downloading stuff bro!")
                Console.WriteLine("Pedro Duarte - go back to your seat, dang it!")
                Console.WriteLine("Ricardo Silva - Speedy Gonzales!")
                Console.WriteLine("Kelton Silva - the crazy one o_O")
                Console.WriteLine("Rui Rodrigues - the gypsy!")
                Console.WriteLine("Alex Junior - the romantic (?) one")
                Console.WriteLine("Rafael Antunes - The data storage guy!")
                Console.WriteLine("Rest of the 293 class!")
                Console.WriteLine("Martin Nyfløtt - Epic C# beast, and the one who gave me some tips on how to port this into C# which I might do later on :3")
                Console.WriteLine("Laurent Maes - JOHN HOLMES BRO!")
                Console.WriteLine("fkn0wned.com people, just because they're awesome.")
                Console.WriteLine("Everyone else that saw this project going up!")
                Console.WriteLine()
                Console.WriteLine("All of the teachers that helped us during the making of this project.")
                Console.WriteLine()
                Console.WriteLine("A special shoutout to my sister and her boyfriend for everything!")
            Case "list"
                Console.WriteLine()
                Console.WriteLine("list users - lists connected users")
                Console.WriteLine("list bans - lists current bans")
                Console.WriteLine()
            Case "list bans"
                Try
                    For i = 0 To My.Computer.FileSystem.GetFiles("Bans\").Count - 1
                        banfile = My.Computer.FileSystem.GetFiles("Bans\")(i).ToString
                        banfile = banfile.Remove(0, My.Computer.FileSystem.CurrentDirectory.Count + 6)
                        If banlist.Contains(banfile) Then
                            Continue For
                        End If
                        banlist.Add(banfile)
                    Next
                Catch ex As Exception
                End Try
                Try
                    If banlist.Count > 0 Then
                        For i = 0 To My.Computer.FileSystem.GetFiles("Bans\").Count - 1
                            banfile = My.Computer.FileSystem.GetFiles("Bans\")(i).ToString
                            banfile = banfile.Remove(0, My.Computer.FileSystem.CurrentDirectory.Count + 6)
                            Console.WriteLine()
                            Console.WriteLine(banfile & " - Reason: " & My.Computer.FileSystem.ReadAllText("Bans\" & banfile))
                        Next
                    Else
                        Console.WriteLine()
                        Console.WriteLine("No bans to display")
                        Console.WriteLine()
                    End If
                Catch ex As Exception
                End Try
            Case "list users"
                Dim countclient As Integer = count
                countclient = countclient - 1
                Try
                    For i = 0 To countclient
                        Console.WriteLine()
                        Console.WriteLine("Username: " & userlist.Item(i).ToString & " " & "IP: " & iplist.Item(i).ToString)
                        Console.WriteLine()
                    Next
                Catch ex As ArgumentOutOfRangeException
                    If userlist.Count = 0 Then
                        Console.WriteLine()
                        Console.WriteLine("No users connected.")
                        Console.WriteLine()
                    End If
                End Try
            Case "locate"
                Console.WriteLine()
                Console.WriteLine("Available options for locate:")
                Console.WriteLine("locate user - searchs for user if online")
                Console.WriteLine("locate ip - searchs for IP if online")
                Console.WriteLine()
            Case "locate user"
                Dim searchuser As String
                Try
                    If userlist.Count = 0 Then
                        Console.WriteLine()
                        Console.WriteLine("There are no users connected!")
                        Console.WriteLine()
                    Else
                        For i = 0 To userlist.Count - 1
                            Console.WriteLine()
                            Console.WriteLine("Insert a user to search:")
                            Console.WriteLine()
                            searchuser = ReadLine()
                            If userlist.Item(i).ToString.Contains(searchuser) Then
                                Console.WriteLine()
                                Console.WriteLine("User " + searchuser + " is online.")
                                Console.WriteLine("IP: " + iplist.Item(i).ToString)
                                Console.WriteLine()
                            Else
                                Console.WriteLine()
                                Console.WriteLine("User " + searchuser + " is offline.")
                                Console.WriteLine("Cannot grab IP since user is offline.")
                                Console.WriteLine()
                            End If
                        Next
                    End If
                Catch ex As ArgumentOutOfRangeException
                Catch ex2 As Exception
                End Try
            Case "locate ip"
                Dim searchip As String
                Try
                    If userlist.Count = 0 Then
                        Console.WriteLine()
                        Console.WriteLine("There are no users connected!")
                        Console.WriteLine()
                    Else
                        Console.WriteLine()
                        Console.WriteLine("Insert a IP to search:")
                        Console.WriteLine()
                        searchip = ReadLine()
                        For i = 0 To iplist.Count - 1
                            If iplist.Item(i).ToString.Contains(searchip) Then
                                Console.WriteLine()
                                Console.WriteLine("IP found! It's assigned to: " + userlist.Item(i).ToString)
                                Console.WriteLine()
                            Else
                                Console.WriteLine()
                                Console.WriteLine("IP not found!")
                                Console.WriteLine()
                            End If
                        Next
                    End If
                Catch ex As ArgumentOutOfRangeException
                Catch ex2 As Exception
                End Try
            Case "ban"
                Try
                    Dim banchoice As Integer
                    Dim banstrindex As Integer
                    Dim banip As String
                    Dim reason As String
                    Console.WriteLine()
                    Console.WriteLine("Choose a ban method")
                    Console.WriteLine("1 - Online method")
                    Console.WriteLine("2 - Offline method")
                    Console.WriteLine("3 - IP Range Ban")
                    Console.WriteLine()
                    banchoice = ReadLine()
                    If Not IsNumeric(banchoice) Or banchoice < 0 Or banchoice > 3 Then
                        Console.WriteLine()
                        Console.WriteLine("Invalid choice detected. Please try again.")
                        Console.WriteLine()
                        banchoice = ReadLine()
                        Console.WriteLine()
                    End If
                    Console.WriteLine()
                    If banchoice = 1 Then
                        If userlist.Count > 0 Then
                            Console.WriteLine()
                            Console.WriteLine("Input a user to add to ban list.")
                            Console.WriteLine()
                            banstr = ReadLine()
                            If String.IsNullOrWhiteSpace(banstr) Then
                                Console.WriteLine()
                                Console.WriteLine("Please input a user.")
                                Console.WriteLine()
                                banstr = ReadLine()
                                Console.WriteLine()
                                If String.IsNullOrWhiteSpace(banstr) Then
                                    Exit Sub
                                End If
                            End If
                            Console.WriteLine()
                            Console.WriteLine("Input a reason.")
                            Console.WriteLine()
                            reason = ReadLine()
                            If String.IsNullOrWhiteSpace(reason) Then
                                Console.WriteLine()
                                Console.WriteLine("Please input a reason.")
                                Console.WriteLine()
                                reason = ReadLine()
                                If String.IsNullOrWhiteSpace(reason) Then
                                    Exit Sub
                                End If
                            End If
                            If userlist.Contains(banstr) Then
                                banstrindex = userlist.IndexOf(banstr)
                                banip = iplist.Item(banstrindex).ToString
                                banlist.Add(banip)
                                Console.WriteLine()
                                Console.WriteLine("User " & banstr & " with the IP " & banip & " has been banned from the Server.")
                                Console.WriteLine("IP added to ban list with the following reason: " & reason)
                                Console.WriteLine()
                                singlebcast("You were banned from the server. $", Nothing, False)
                                If Directory.Exists(Application.StartupPath & "\Bans") = False Then
                                    Call Directory.CreateDirectory(Application.StartupPath & "\Bans")
                                End If
                                My.Computer.FileSystem.WriteAllText("Bans\" & banip, reason + Environment.NewLine, True)
                                userlist.RemoveAt(banstrindex)
                                iplist.RemoveAt(banstrindex)
                                socketlist.RemoveAt(banstrindex)
                            Else
                                Console.WriteLine()
                                Console.WriteLine("User not found!")
                                Console.WriteLine()
                            End If
                        Else
                            Console.WriteLine()
                            Console.WriteLine("No users to ban.")
                            Console.WriteLine()
                        End If
                    End If
                    If banchoice = 2 Then
                        Dim methodchoice As Integer
                        Console.WriteLine()
                        Console.WriteLine("Please choose your method of offline ban")
                        Console.WriteLine("1 - User")
                        Console.WriteLine("2 - IP")
                        Console.WriteLine()
                        methodchoice = ReadLine()
                        If Not IsNumeric(methodchoice) Or methodchoice < 1 Or methodchoice > 2 Then
                            Console.WriteLine()
                            Console.WriteLine("Invalid choice detected. Please try again.")
                            Console.WriteLine()
                            methodchoice = ReadLine()
                            Console.WriteLine()
                        End If
                        If methodchoice = 1 Then
                            Console.WriteLine()
                            Console.WriteLine("Input user to add to ban list.")
                            Console.WriteLine()
                            banstr = ReadLine()
                            If String.IsNullOrWhiteSpace(banstr) Then
                                Exit Sub
                            End If
                            Console.WriteLine()
                            Console.WriteLine("Input a reason.")
                            Console.WriteLine()
                            reason = ReadLine()
                            If String.IsNullOrWhiteSpace(reason) Then
                                Console.WriteLine("Please input a reason.")
                                Console.WriteLine()
                                reason = ReadLine()
                                If String.IsNullOrWhiteSpace(reason) Then
                                    Exit Sub
                                End If
                            End If
                            If userlist.Contains(banstr) Then
                                Console.WriteLine("This user is online! Please ban him using the Online user method.")
                            Else
                                Console.WriteLine()
                                Console.WriteLine("User " & banstr & " has been banned from the Server.")
                                Console.WriteLine("Reason: " & reason)
                                Console.WriteLine()
                                banlist.Add(banstr)
                                If Directory.Exists(Application.StartupPath & "\Bans") = False Then
                                    Call Directory.CreateDirectory(Application.StartupPath & "\Bans")
                                End If
                                My.Computer.FileSystem.WriteAllText("Bans\" & banstr, reason + Environment.NewLine, True)
                            End If
                        End If
                        If methodchoice = 2 Then
                            Console.WriteLine()
                            Console.WriteLine("Input IP to add to ban list.")
                            Console.WriteLine()
                            banstr = ReadLine()
                            If String.IsNullOrWhiteSpace(banstr) Then
                                Console.WriteLine("Please input a IP.")
                                Console.WriteLine()
                                banstr = ReadLine()
                                If String.IsNullOrWhiteSpace(banstr) Then
                                    Exit Sub
                                End If
                            End If
                            Console.WriteLine()
                            Console.WriteLine("Input a reason.")
                            Console.WriteLine()
                            reason = ReadLine()
                            If String.IsNullOrWhiteSpace(reason) Then
                                Console.WriteLine("Please input a reason.")
                                Console.WriteLine()
                                reason = ReadLine()
                                If String.IsNullOrWhiteSpace(reason) Then
                                    Exit Sub
                                End If
                            End If
                            If iplist.Contains(banstr) Then
                                Console.WriteLine("This IP is online! Please ban the corresponding user using the Online ban method.")
                            Else
                                Console.WriteLine()
                                Console.WriteLine("IP " & banstr & " has been banned from the Server.")
                                Console.WriteLine("Reason: " & reason)
                                Console.WriteLine()
                                banlist.Add(banstr)
                                If Directory.Exists(Application.StartupPath & "\Bans") = False Then
                                    Call Directory.CreateDirectory(Application.StartupPath & "\Bans")
                                End If
                                My.Computer.FileSystem.WriteAllText("Bans\" & banstr, reason + Environment.NewLine, True)
                            End If
                        End If
                    End If
                    If banchoice = 3 Then
                        Console.WriteLine()
                        Console.WriteLine("Insert a IP range to ban.")
                        Console.WriteLine("Example: 172.147")
                        Console.WriteLine()
                        iprange = ReadLine()
                        If Not IsNumeric(iprange) Or String.IsNullOrWhiteSpace(iprange) Then
                            Console.WriteLine()
                            Console.WriteLine("Invalid IP detected, please try again.")
                            iprange = ReadLine()
                            If String.IsNullOrWhiteSpace(iprange) Then
                                Exit Sub
                            End If
                        Else
                            Console.WriteLine()
                            Console.WriteLine("IP Range " & iprange & " has been blocked from accessing the Server.")
                            Console.WriteLine()
                            banlist.Add(iprange)
                            If Directory.Exists(Application.StartupPath & "\Bans") = False Then
                                Call Directory.CreateDirectory(Application.StartupPath & "\Bans")
                            End If
                            My.Computer.FileSystem.WriteAllText("Bans\" & iprange, "IP Range Ban", True)
                        End If
                    End If
                Catch ex As Exception
                End Try
            Case "unban"
                Dim unbanstr As String
                Try
                    If banlist.Count > 0 Then
                        Console.WriteLine()
                        Console.WriteLine("Input a user/IP/IP Range from the list to unban.")
                        Console.WriteLine()
                        Try
                            For i = 0 To My.Computer.FileSystem.GetFiles("Bans\").Count - 1
                                banfile = My.Computer.FileSystem.GetFiles("Bans\")(i).ToString
                                banfile = banfile.Remove(0, My.Computer.FileSystem.CurrentDirectory.Count + 6)
                                Console.WriteLine(banfile)
                            Next
                        Catch ex As Exception
                        End Try
                        Console.WriteLine()
                        unbanstr = ReadLine()
                        Console.WriteLine()
                        If banlist.Contains(unbanstr) Then
                            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.CurrentDirectory + "\Bans\" + unbanstr)
                            Console.WriteLine()
                            Console.WriteLine("User/IP/IP Range was unbanned.")
                            Console.WriteLine()
                            banlist.Remove(unbanstr)
                        End If
                    Else
                        Console.WriteLine()
                        Console.WriteLine("No users/IP/IP Range to unban.")
                        Console.WriteLine()
                    End If
                Catch ex As Exception
                End Try
            Case "refresh bans"
                Try
                    For i = 0 To My.Computer.FileSystem.GetFiles("Bans\").Count - 1
                        banfile = My.Computer.FileSystem.GetFiles("Bans\")(i).ToString
                        banfile = banfile.Remove(0, My.Computer.FileSystem.CurrentDirectory.Count + 6)
                        If banlist.Contains(banfile) Then
                            Continue For
                        End If
                        banlist.Add(banfile)
                    Next
                    Console.WriteLine()
                    Console.WriteLine("Ban list updated")
                    Console.WriteLine()
                Catch ex As Exception
                End Try
            Case "delete bans"
                Dim delchoice As String
                Dim banshrtfile As String
                Try
                    Console.WriteLine()
                    Console.WriteLine("Are you sure that you want to perform this operation?")
                    Console.WriteLine("Press Y/N")
                    Console.WriteLine()
                    delchoice = ReadLine()
                    Console.WriteLine()
                    If delchoice = "Y" Or delchoice = "y" Then
                        If banlist.Count > 0 Then
                            For i = 0 To My.Computer.FileSystem.GetFiles("Bans\").Count - 1
                                i = 0
                                banfile = My.Computer.FileSystem.GetFiles("Bans\")(i).ToString
                                My.Computer.FileSystem.DeleteFile(banfile)
                                banshrtfile = banfile
                                banshrtfile = banshrtfile.Remove(0, My.Computer.FileSystem.CurrentDirectory.Count + 6)
                                banlist.Remove(banshrtfile)
                            Next
                            Console.WriteLine()
                            Console.WriteLine("Bans deleted.")
                            Console.WriteLine()
                        Else
                            Console.WriteLine()
                            Console.WriteLine("No bans to delete.")
                            Console.WriteLine()
                        End If
                    End If
                    If delchoice = "N" Or delchoice = "n" Then
                        Console.WriteLine()
                        Console.WriteLine("Operation aborted.")
                        Console.WriteLine()
                    End If
                Catch ex As Exception
                    Console.WriteLine()
                    Console.WriteLine("Bans deleted.")
                    Console.WriteLine()
                End Try
            Case "clear"
                Try
                    Console.Clear()
                    If Directory.Exists(Application.StartupPath & "\Log") = False Then
                        Call Directory.CreateDirectory(Application.StartupPath & "\Log")
                    End If
                    My.Computer.FileSystem.WriteAllText("Log\Server Log " + FormatDateTime(DateAndTime.Today, DateFormat.LongDate) + ".log", DateTime.UtcNow + " >> " + "Console cleared!" + Environment.NewLine, True)
                Catch ex As IOException
                    Console.WriteLine()
                    Console.WriteLine("Could not write to log file.")
                    Console.WriteLine()
                End Try
            Case "shutdown"
                Try
                    If Directory.Exists(Application.StartupPath & "\Log") = False Then
                        Call Directory.CreateDirectory(Application.StartupPath & "\Log")
                    End If
                    My.Computer.FileSystem.WriteAllText("Log\Server Log " + FormatDateTime(DateAndTime.Today, DateFormat.LongDate) + ".log", DateTime.UtcNow + " >> " + "Server shutdown!" + Environment.NewLine, True)
                Catch ex As IOException
                    Console.WriteLine()
                    Console.WriteLine("Could not write to log file.")
                    Console.WriteLine()
                End Try
                Console.WriteLine()
                Console.WriteLine("leChat Server Environment terminated!")
                Console.WriteLine("Server shutting down in 3 seconds.")
                Console.WriteLine()
                Thread.Sleep(3000)
                End
            Case "terminate"
                Console.WriteLine()
                Console.WriteLine("Available options for terminate:")
                Console.WriteLine("terminate connection - Kills a connected client.")
                Console.WriteLine("terminate all - Kills all connected clients.")
                Console.WriteLine()
            Case "terminate connection"
                If userlist.Count > 0 Then
                    Console.WriteLine()
                    Console.WriteLine("Please input the name of the user:")
                    Console.WriteLine()
                    usersearch = ReadLine()
                    If userlist.Contains(usersearch) Then
                        singlebcast("Server Operator has terminated your connection. $", Nothing, False)
                        message("User: " & usersearch & " connection has been terminated.")
                    Else
                        Console.WriteLine()
                        Console.WriteLine("User: " & usersearch & " was not found.")
                        Console.WriteLine()
                    End If
                Else
                    Console.WriteLine()
                    Console.WriteLine("No users connected!")
                    Console.WriteLine()
                End If
            Case "terminate all"
                Dim termchoice As String
                If userlist.Count > 0 Then
                    Console.WriteLine()
                    Console.WriteLine("Are you sure that you want to perform this operation?")
                    Console.WriteLine("Press Y/N")
                    Console.WriteLine()
                    termchoice = ReadLine()
                    If termchoice = "Y" Or termchoice = "y" Then
                        bcast("Server Operator has terminated your connection. $", Nothing, False)
                        message("All connections terminated.")
                    End If
                    If termchoice = "N" Or termchoice = "n" Then
                        Console.WriteLine("Operation canceled.")
                    End If
                Else
                    Console.WriteLine()
                    Console.WriteLine("No users connected!")
                    Console.WriteLine()
                End If
            Case "restart"
                Try
                    If Directory.Exists(Application.StartupPath & "\Log") = False Then
                        Call Directory.CreateDirectory(Application.StartupPath & "\Log")
                    End If
                    My.Computer.FileSystem.WriteAllText("Log\Server Log " + FormatDateTime(DateAndTime.Today, DateFormat.LongDate) + ".log", DateTime.UtcNow + " >> " + "Server restarted!" + Environment.NewLine, True)
                    Console.WriteLine()
                    Console.WriteLine("leChat Server Environment terminated!")
                    Console.WriteLine("Server restarting in 3 seconds.")
                    Console.WriteLine()
                    Thread.Sleep(3000)
                    Application.Restart()
                    End
                Catch ex As IOException
                    Console.WriteLine()
                    Console.WriteLine("Could not write to log file.")
                    Console.WriteLine()
                End Try
            Case "say"
                Try
                    Dim msgstr As String
                    Console.WriteLine()
                    Console.WriteLine("Please input your message:")
                    Console.WriteLine()
                    msgstr = ReadLine()
                    bcast(msgstr, "Server Operator", True)
                Catch ex As SocketException
                End Try
            Case "timer on"
                If listtimer.Enabled = False Then
                    listtimer.AutoReset = True
                    listtimer.Enabled = True
                    listtimer.Start()
                    message("Userlist Timer enabled.")
                Else
                    message("Userlist Timer is already running!")
                End If
            Case "timer off"
                If listtimer.Enabled = True Then
                    listtimer.AutoReset = False
                    listtimer.Enabled = False
                    message("Userlist Timer disabled.")
                Else
                    message("Userlist Timer is already stopped!")
                End If
            Case Else
                Console.WriteLine()
                Console.WriteLine("leChat Server - Input command not recognized!")
        End Select
    End Sub
#End Region

End Module

' leChat Server - This program might be rewritten using aSync Sockets like the Files and ReceiveFiles on the Client were implemented or fully recoded in C#.

' This seriously took a lot of my time and my sleep.
' So please, contribute and report bugs or any new features you would like to be implemented.
' Contact me at zgrav@null.net for more information
' Check out my Github if you're interested on any other project that I might have - http://github.com/zGrav
' Don't steal Source Code, read it, learn it, adapt it and give credit to original owner.
' This program was developed by me and my coworker EvilMonstah/Diogo Alexandre who helped out on ideas, documentation and implementation of some features.
' (c) zGrav/David Samuel - 22nd June 2012