'aSync Sockets

#Region "Imports"
Imports System
Imports System.Net.Sockets
Imports System.Text
Imports System.IO
#End Region

Partial Public Class Files

#Region "Declarations"
    Private splitfile As String = "'\'" ' File splitter
    Public Shared fName As String
    Private splited As String() = Nothing ' Data splitted
    Private cData As Byte() ' Data to be sent
    Private OriFPath As String
    Public Shared svip As String

    Public Sub New()
        InitializeComponent()
    End Sub
#End Region

#Region "Browse"
    Private Sub browsebtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browsebtn.Click
        Dim delimit As Char() = splitfile.ToCharArray() ' Splits file
        OpenFileDialog1.FileName = "Select a file"
        OpenFileDialog1.ShowDialog()
        TextBox1.Text = OpenFileDialog1.SafeFileName
        OriFPath = OpenFileDialog1.FileName
        fName = TextBox1.Text
        If TextBox1.Text IsNot Nothing Then
            Sendbtn.Enabled = True
        End If
    End Sub
#End Region

#Region "Send"
    Private Sub sendbtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Sendbtn.Click
        Try
            svip = InputBox("Client IP?")
            If svip = "" Or svip = Nothing Or Not IsNumeric(svip) Then
                Exit Sub
            Else
                Dim clientSock As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

                Dim fileName As Byte() = Encoding.UTF8.GetBytes(fName) ' Encodes fName
                Dim datafile As Byte() = File.ReadAllBytes(OriFPath) ' Reads file bytes
                Dim fileLen As Byte() = BitConverter.GetBytes(fileName.Length) ' Returns Length of filename
                cData = New Byte(4 + fileName.Length + (datafile.Length - 1)) {}
                'Copys to cData
                fileLen.CopyTo(cData, 0)
                fileName.CopyTo(cData, 4)
                datafile.CopyTo(cData, 4 + fileName.Length)

                ' Connects and sends cData
                clientSock.Connect(svip, 8889)
                clientSock.Send(cData)
                ' Dim localip As String
                'localip = clientSock.LocalEndPoint.ToString
                'localip.Substring(0, localip.IndexOf(":"))
                Dim Stream_out As Byte() = System.Text.Encoding.ASCII.GetBytes(Main.info.Nickname + " is sending a file: " + fName + " to: " + svip + "$") 'Passes msgtxt content to OutStream and encoded.
                Main.servStream.Write(Stream_out, 0, Stream_out.Length) ' Send message to server
                Main.servStream.Flush() ' Resets stream
                clientSock.Close()
            End If
        Catch ex As SocketException
            MsgBox("Impossible to send file!")
        End Try
    End Sub
#End Region
End Class

' leChat Client - File Transfer (aSync Sockets) - This program might be rewritten using aSync Sockets like the Files and ReceiveFiles on the Client were implemented or fully recoded in C#.

' This seriously took a lot of my time and my sleep.
' So please, contribute and report bugs or any new features you would like to be implemented.
' Contact me at zgrav@null.net for more information
' Check out my Github if you're interested on any other project that I might have - http://github.com/zGrav
' Don't steal Source Code, read it, learn it, adapt it and give credit to original owner.
' This program was developed by me and my coworker EvilMonstah/Diogo Alexandre who helped out on ideas, documentation and implementation of some features.
' (c) zGrav/David Samuel - 22nd June 2012