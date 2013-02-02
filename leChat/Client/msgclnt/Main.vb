'Disabled Exception messages

#Region "Imports"
Imports System.Runtime.InteropServices
Imports System.Net.Sockets
Imports System.Text
Imports System.IO
Imports System.ComponentModel

#End Region

Public Class Main

#Region "Client info Structure"
    Public info As New Cinfo
#End Region

#Region "Window Flashing Notification"
    <DllImport("user32.dll", EntryPoint:="FlashWindow")> _
    Public Shared Function FlashWindow(ByVal hWnd As Integer, bInvert As Integer) As Integer
    End Function
#End Region

#Region "Structure"
    Public Structure Cinfo
        '---General---
        Public Nickname As String
        Public Status As String
        Public Name As String
        Public Description As String
        Public Age As String
        '---Server---
        Public IP As String
        Public Port As String
        Public ServerName As String
        '---Notifications---
        Public SoundCheck As Boolean
        Public FromFile As Boolean
        Public FilePath As String
    End Structure
#End Region

#Region "Dims"
    Dim cSocket As New System.Net.Sockets.TcpClient() ' Initiates client socket.
    Public Shared servStream As NetworkStream ' Server stream
    Dim read As String
    Dim connB As Boolean = True
    Dim flash As Boolean = False
    Dim lngret As Long
#End Region

#Region "Send Button"
    Private Sub sendBtn_Click(sender As System.Object, e As System.EventArgs) Handles sendBtn.Click
        If msgtxt.Text = "/help" Or msgtxt.Text = "/cmds" Or msgtxt.Text = "/commands" Then
            MsgBox("Please check the Help menu for available commands.")
        End If
        If msgtxt.Text = Nothing Or msgtxt.Text = "" Then
            Exit Sub
        Else
            Try
                Dim Stream_out As Byte() = System.Text.Encoding.ASCII.GetBytes(msgtxt.Text + "$") 'Passes msgtxt content to OutStream and encoded.
                servStream.Write(Stream_out, 0, Stream_out.Length) ' Send message to server
                servStream.Flush() ' Resets stream
                msgtxt.Text = ""
            Catch ex As Exception
                If msgtxt.Text.Contains("I'm now currently") Then
                    Exit Sub
                End If
                chattxt.Text = chattxt.Text + Environment.NewLine + " >> " + "Could not send message!"
                msgtxt.Text = ""
            End Try
        End If
    End Sub
#End Region

#Region "Multithreading + Message Handling"
    Private Sub msgthread()

        If Me.InvokeRequired Then ' Thank you André for helping me out on this part.
            Me.Invoke(New MethodInvoker(AddressOf msgthread)) ' Multithread
        Else
            Try
                Dim Copystr As String
                Dim copystrlength As Integer
                'If read.Contains(info.Nickname) AndAlso read.Contains("joined") Then
                '    ListBox1.Items.Add(info.Nickname)
                'End If
                If read.Contains("$Username: ") Then
                    read = read.Substring(11)
                    Copystr = read
                    copystrlength = Copystr.LastIndexOf("/getusers")
                    If Copystr.Contains("/getusers") Then
                        Copystr = Copystr.Substring(0, copystrlength)
                    End If
                    If ListBox1.Items.Contains(Copystr) Then
                        read = ""
                        Copystr = ""
                        Exit Sub
                    Else
                        ListBox1.Items.Add(Copystr)
                        read = ""
                        Copystr = ""
                        Exit Sub
                    End If
                End If
                If read.Contains("Server Operator has terminated your connection. $") Then
                    read = read.Substring(0, 47)
                    cntbutton.PerformClick()
                    ListBox1.Items.Clear()
                End If
                If read.Contains(" has disconnected. $") Then
                    Dim copyread As String = read
                    Dim copyreadlength As Integer = copyread.LastIndexOf("$")
                    Dim readlength As Integer = read.LastIndexOf(" has disconnected. $")
                    copyread = copyread.Substring(0, copyreadlength)
                    read = read.Substring(0, readlength)
                    Dim readcopy As String = read
                    For i = 0 To ListBox1.Items.Count - 1
                        If ListBox1.Items(i).ToString.Contains(readcopy) Then
                            ListBox1.Items.RemoveAt(i)
                            ListBox1.Refresh()
                        End If
                    Next
                    read = ""
                    chattxt.Text = chattxt.Text + Environment.NewLine + " >> " + copyread
                    Exit Sub
                End If
                If read.Contains("has changed his name to ") = True Then
                    ListBox1.Items.Clear()
                    msgtxt.Text = "/getusers"
                    sendBtn.PerformClick()
                    msgtxt.Text = ""
                End If
                If read.Contains("You were banned from the server. $") Then
                    read = read.Substring(0, 33)
                    cntbutton.PerformClick()
                    ListBox1.Items.Clear()
                End If
                If read.Contains("You were disconnected due to a ban. $") Then
                    read = read.Substring(0, 36)
                    cntbutton.PerformClick()
                    ListBox1.Items.Clear()
                End If
                If read.Contains("joined ") Then
                    ListBox1.Items.Clear()
                    msgtxt.Text = "/getusers"
                    sendBtn.PerformClick()
                    msgtxt.Text = ""
                    'ListBox1.Items.Clear()
                    'msgtxt.Text = "/getusers"
                    'sendBtn.PerformClick()
                    'msgtxt.Text = ""
                End If
            Catch ex As NullReferenceException
            End Try
            chattxt.Text = chattxt.Text + Environment.NewLine + " >> " + read
        End If

    End Sub
#End Region

#Region "Connect/Dc button"
    Private Sub cntbutton_Click(sender As System.Object, e As System.EventArgs) Handles cntbutton.Click
        If connB = True Then
            Try
                If info.Nickname = "" Or info.Nickname Is Nothing Or _
                    info.IP = "" Or info.IP Is Nothing Or Not IsNumeric(info.IP) Then
                    MsgBox("Please review needed fields on preferences.")
                    chattxt.Clear()
                    Exit Sub
                Else
                    cSocket = New System.Net.Sockets.TcpClient
                    msgthread()
                    If Not IsNumeric(info.IP) AndAlso Not IsNumeric(info.Port) Then
                        MsgBox("Please review IP and Port setting. Only numeric characters allowed.")
                        chattxt.Clear()
                        Exit Sub
                    End If
                    If Not IsNumeric(info.IP) Then
                        MsgBox("Please review IP setting. Only numeric characters allowed.")
                        chattxt.Clear()
                        Exit Sub
                    End If
                    If Not IsNumeric(info.Port) Then
                        MsgBox("Please review Port setting. Only numeric characters allowed.")
                        chattxt.Clear()
                        Exit Sub
                    End If
                    cSocket.Connect(info.IP, info.Port) ' Connects to IP and port determined by svip and port.
                    servStream = cSocket.GetStream() ' Client to Server handling

                    Dim Stream_out As Byte() = System.Text.Encoding.ASCII.GetBytes(info.Nickname + "$")
                    servStream.Write(Stream_out, 0, Stream_out.Length)
                    servStream.Flush()

                    Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf getMsg) ' Client Threading
                    ctThread.Start()
                    cntbutton.Text = "Disconnect"
                    sndbtn.Enabled = True
                    connB = False
                End If
            Catch ex As SocketException
                chattxt.Text = chattxt.Text + Environment.NewLine + " >> " + "Connection timed out! Check IP/port"
                cntbutton.Enabled = True
                sndbtn.Enabled = False
            End Try
        ElseIf connB = False Then
            CheckForIllegalCrossThreadCalls = False
            sndbtn.Enabled = False
            cntbutton.Text = "Connect"
            servStream.Flush()
            cSocket.Close()
            ListBox1.Items.Clear()
            connB = True
            CheckForIllegalCrossThreadCalls = True
        End If
    End Sub
#End Region

#Region "Get Message handle"
    Private Sub getMsg()
        Try
            Do While True
                If cSocket.Connected = False Then
                    CheckForIllegalCrossThreadCalls = False
                    chattxt.Text = chattxt.Text + Environment.NewLine + " >> " + "Disconnected from server!"
                    ListBox1.Items.Clear()
                    CheckForIllegalCrossThreadCalls = True
                    Exit Sub
                Else

                    servStream = cSocket.GetStream() ' Server to Client Handling
                    Dim buffSize As Integer ' Buffer size
                    Dim Stream_in(10024) As Byte ' Buffer size for BuffSize (also max bytes allowed by server.)
                    buffSize = cSocket.ReceiveBufferSize
                    servStream.Read(Stream_in, 0, buffSize)
                    Dim returnd As String = System.Text.Encoding.ASCII.GetString(Stream_in)
                    read = "" + returnd ' Data received from server.
                    msgthread()
                End If
            Loop
        Catch ex As IOException
            CheckForIllegalCrossThreadCalls = False
            chattxt.Text = chattxt.Text + Environment.NewLine + " >> " + "Connection terminated!"
            cntbutton.Enabled = True
            cntbutton.Text = "Connect"
            ListBox1.Items.Clear()
            sndbtn.Enabled = False
            CheckForIllegalCrossThreadCalls = True

        Catch ex2 As ObjectDisposedException
            CheckForIllegalCrossThreadCalls = False
            'chattxt.Text = chattxt.Text + Environment.NewLine + " >> " + "Object not disposed properly!"
            cntbutton.Enabled = True
            sndbtn.Enabled = False
            CheckForIllegalCrossThreadCalls = True

        Catch ex3 As InvalidOperationException
            CheckForIllegalCrossThreadCalls = False
            'chattxt.Text = chattxt.Text + Environment.NewLine + " >> " + "Invalid Operation exception!"
            cntbutton.Enabled = True
            sndbtn.Enabled = False
            CheckForIllegalCrossThreadCalls = True

        Catch ex4 As Win32Exception
            End
        End Try
    End Sub
#End Region

#Region "Main Load + Textbox scrolling + KeyDown"


    Private Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            If Directory.Exists(Application.StartupPath & "\History") = False Then
                Call Directory.CreateDirectory(Application.StartupPath & "\History")
            End If
            My.Computer.FileSystem.WriteAllText("History\History " + FormatDateTime(DateAndTime.Today, DateFormat.LongDate) + ".log", Environment.NewLine + DateTime.UtcNow + " Client start!" + Environment.NewLine, True)
            With info
                '---General---
                .Nickname = My.Settings.Nickname
                .Status = My.Settings.Status
                .Name = My.Settings.Name
                .Description = My.Settings.Description
                .Age = My.Settings.Age
                '---Server---
                .IP = My.Settings.IP
                .Port = My.Settings.Port
                .ServerName = My.Settings.ServerName
                '---Notifications---
                .SoundCheck = My.Settings.SoundCheck
                .FromFile = My.Settings.SpathCheck
                .FilePath = My.Settings.SoundPath
            End With
            sndbtn.Enabled = False
            CapsLock()
            NumLock()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chattxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles chattxt.TextChanged

        If Me.WindowState = FormWindowState.Minimized Then
            FlashWindow(Me.Handle, 1)

            With info
                If .SoundCheck = True AndAlso .FromFile = False Then
                    Dim sound As New Media.SoundPlayer(My.Resources.Notification)
                    sound.Load()
                    sound.Play()
                ElseIf .SoundCheck = True AndAlso .FromFile = True Then
                    Dim sound As New Media.SoundPlayer()
                    sound.SoundLocation = Application.StartupPath & "\Notification\" & .FilePath
                    sound.Load()
                    sound.Play()
                End If
            End With

        End If

        chattxt.Select(chattxt.Text.Length, 0)
        chattxt.ScrollToCaret() ' Textbox scroll.
    End Sub

    Private Sub msgtxt_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles msgtxt.KeyDown
        CapsLock()
        NumLock()
        Select Case e.KeyCode
            Case Keys.Enter
                sendBtn.PerformClick()
        End Select
        e.Handled = True
    End Sub

    Private Sub Main_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If connB = False Then
                cntbutton.PerformClick()
            End If
            If Directory.Exists(Application.StartupPath & "\History") = False Then
                Call Directory.CreateDirectory(Application.StartupPath & "\History")
            End If
            My.Computer.FileSystem.WriteAllText("History\History " + FormatDateTime(DateAndTime.Today, DateFormat.LongDate) + ".log", chattxt.Text + " " + DateTime.UtcNow, True)
        Catch ex As ObjectDisposedException
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If connB = False Then
            cntbutton.PerformClick()
        End If
        If Directory.Exists(Application.StartupPath & "\History") = False Then
            Call Directory.CreateDirectory(Application.StartupPath & "\History")
        End If
        My.Computer.FileSystem.WriteAllText("History\History " + FormatDateTime(DateAndTime.Today, DateFormat.LongDate) + ".log", chattxt.Text + " " + DateTime.UtcNow, True)
        End
    End Sub
#End Region

#Region "Clear button"

    Private Sub Clearbtn_Click(sender As System.Object, e As System.EventArgs) Handles Clearbtn.Click
        If Directory.Exists(Application.StartupPath & "\History") = False Then
            Call Directory.CreateDirectory(Application.StartupPath & "\History")
        End If
        My.Computer.FileSystem.WriteAllText("History\History " + FormatDateTime(DateAndTime.Today, DateFormat.LongDate) + ".log", chattxt.Text + " " + DateTime.UtcNow, True)
        chattxt.Clear()
        ListBox1.Items.Clear()
    End Sub

#End Region

#Region "File transfer"

    Private Sub sndbtn_Click(sender As System.Object, e As System.EventArgs) Handles sndbtn.Click
        Filesv2.Show()
    End Sub
#End Region

#Region "Misc"

    Private Sub msgtxt_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles msgtxt.MouseClick
        CapsLock()
        NumLock()
    End Sub

    Private Sub msgtxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles msgtxt.TextChanged
        CapsLock()
        NumLock()
    End Sub

    Public Shared Sub CapsLock()
        If Control.IsKeyLocked(Keys.CapsLock) Then
            Main.CapsONoff.Image = My.Resources.CapsOn
        Else
            Main.CapsONoff.Image = My.Resources.CapsOff
        End If
    End Sub
    Public Shared Sub NumLock()
        If My.Computer.Keyboard.NumLock = True Then
            Main.NumONoff.Image = My.Resources.NumOn
        Else
            Main.NumONoff.Image = My.Resources.NumOff
        End If
    End Sub

#End Region

#Region "Preferences info"

    Private Sub PrefBtn_Click(sender As System.Object, e As System.EventArgs) Handles PrefBtn.Click
        Preferences.ServerList.DataSource = Nothing
        Try
            If Preferences.ShowDialog = DialogResult.OK Then
                With info
                    If .Nickname <> "" AndAlso Preferences.NickTxt.Text <> .Nickname AndAlso cSocket.Connected = True Then
                        Dim Stream_out As Byte() = System.Text.Encoding.ASCII.GetBytes(.Nickname + " has changed his name to " + Preferences.NickTxt.Text + "$")
                        servStream.Write(Stream_out, 0, Stream_out.Length) ' Send message to server
                        servStream.Flush() ' Resets stream
                    End If
                    '---General---
                    .Nickname = Preferences.NickTxt.Text
                    .Status = Preferences.StatusBox.SelectedIndex
                    .Name = Preferences.NameTxt.Text
                    .Description = Preferences.DescTxt.Text
                    .Age = Preferences.AgeTxt.Text
                    '---Server---
                    .IP = Preferences.IPTxt.Text
                    .Port = Preferences.PortTxt.Text
                    .ServerName = Preferences.ServerTxt.Text
                    '---Notifications---
                    .SoundCheck = Preferences.soundcheck.Checked
                    .FromFile = Preferences.spcheck.Checked
                    .FilePath = Preferences.filepath.Text
                End With
            End If
        Catch ex3 As NullReferenceException
        Catch ex As ObjectDisposedException
        Catch ex2 As IOException
        End Try
    End Sub

    Private Sub PreferencesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PreferencesToolStripMenuItem.Click
        PrefBtn.PerformClick()
    End Sub

#End Region

#Region "Context Menu"
    Private Sub WhoIsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WhoisToolStripMenuItem.Click
        Try
            If ListBox1.SelectedItem Is Nothing Then
                Exit Sub
            Else
                msgtxt.Text = "/whois " + ListBox1.SelectedItem
                sendBtn.PerformClick()
                msgtxt.Text = ""
            End If
        Catch ex As Exception
            chattxt.Text = chattxt.Text + Environment.NewLine + " >> " + "Could not whois user!"
            msgtxt.Text = ""
        End Try
    End Sub

    Private Sub SendFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SendFileToolStripMenuItem.Click
        WhoisToolStripMenuItem.PerformClick()
        Files.Show()
    End Sub
#End Region

#Region "Menu"
    Private Sub CommandsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CommandsToolStripMenuItem.Click
        MsgBox("Available commands:" & Environment.NewLine & "/getusers - Gets a list of connected users." & Environment.NewLine & "/whois username - Returns username and IP address of the user." & Environment.NewLine & "/myinfo - Returns your IP")
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub WebBrowserToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WebBrowserToolStripMenuItem.Click
        Browser.Show()
    End Sub

    Private Sub RSSReaderToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RSSReaderToolStripMenuItem.Click
        RSS.Show()
    End Sub
#End Region


End Class

' leChat Client - Main - This program might be rewritten using aSync Sockets like the Files and ReceiveFiles on the Client were implemented or fully recoded in C#.

' This seriously took a lot of my time and my sleep.
' So please, contribute and report bugs or any new features you would like to be implemented.
' Contact me at zgrav@null.net for more information
' Check out my Github if you're interested on any other project that I might have - http://github.com/zGrav
' Don't steal Source Code, read it, learn it, adapt it and give credit to original owner.
' This program was developed by me and my coworker EvilMonstah/Diogo Alexandre who helped out on ideas, documentation and implementation of some features.
' (c) zGrav/David Samuel - 22nd June 2012