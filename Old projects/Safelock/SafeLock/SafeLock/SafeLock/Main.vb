Imports System.IO
Imports System
Imports System.Data.SqlClient

' revision 0.1c

Public Class Main
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub
    Dim filename As String
    Dim filepath As String

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            If Not IO.File.Exists("C:\Windows\System32\defrag.exe") Then
            Else
                System.Diagnostics.Process.Start("C:\Windows\System32\defrag.exe")
            End If
            If Not IO.File.Exists("C:\Windows\System32\defrag.msc") Then
            Else
                System.Diagnostics.Process.Start("C:\Windows\System32\defrag.msc")
            End If
            If Not IO.File.Exists("C:\Windows\System32\dfrgui.exe") Then
            Else
                System.Diagnostics.Process.Start("C:\Windows\System32\dfrgui.exe")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabPage1.Text = "Local"
        TabPage2.Text = "Remote"
        Dim di As DirectoryInfo = New DirectoryInfo("c:\Safelock")
        Try
            If Not di.Exists Then
                MsgBox("SafeLock protected folder does not exist, the program will recreate it now.")
                di.Create()
                di.Attributes = FileAttributes.Hidden
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        Settings.Show()
    End Sub
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Public Function BuildDirectory(ByVal aNode As TreeNode) As String
        Dim theNode As TreeNode = aNode
        Dim strDir As String = "c:\safelock"
        While Not (theNode Is Nothing)
            If theNode.Text.Substring((theNode.Text.Length - 1)) <> "\" Then
                strDir = "\" + strDir
            End If
            strDir = theNode.Text + strDir
            theNode = theNode.Parent
        End While
        Return strDir
    End Function
    Public Sub PopulateNode(ByVal aNode As TreeNode, ByVal strDir As String)
        Me.Cursor = Cursors.WaitCursor
        ' Dim Dir As Directory
        Dim count As Integer = 0
        Dim M_STRFILTER = "*.*"
        Dim i As Integer
        For i = 0 To (Directory.GetDirectories(strDir).Length) - 1
            Dim ChildNode As New TreeNode(Directory.GetDirectories(strDir)(i).ToString, 1, 0)
            i = aNode.Nodes.Add(ChildNode)
            count += 1
        Next i

        For i = 0 To (Directory.GetFiles(strDir, M_STRFILTER).Length) - 1
            Dim ChildNode As New TreeNode(Directory.GetFiles(strDir, M_STRFILTER)(i).ToString, 2, 2)
            i = aNode.Nodes.Add(ChildNode)
        Next i
        aNode.Expand()
        Me.Cursor = Cursors.Arrow

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oNode As New System.Windows.Forms.TreeNode()
        Try
            oNode.ImageIndex = 0
            oNode.SelectedImageIndex = 0
            oNode.Text = "C:\"
            TreeView1.Nodes.Add(oNode)
            'oNode.Nodes.Add("")
        Catch ex As Exception
            MsgBox("Cannot create initial node:" & ex.ToString)
        End Try
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Text = e.Node.Text
        If Directory.Exists(e.Node.Text) = True Then PopulateNode(e.Node, e.Node.Text)
        'If File.Exists(e.Node.Text) = True Then MsgBox(e.Node.Text)

        filename = e.Node.Text
        filepath = e.Node.Text
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If MsgBox("Are you sure that you want to delete this file?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            IO.File.Delete(filename)
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If System.IO.File.Exists(filename) Then
            SaveFileDialog1.Filter = "All Files (*.*)| *.*"
            SaveFileDialog1.InitialDirectory = filepath
            SaveFileDialog1.ShowDialog()
            Dim path2 As String = SaveFileDialog1.FileName
            If SaveFileDialog1.FileName <> Nothing Then

                OpenBase64.OpenBase64.EncodeFile(filename, path2)
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If System.IO.File.Exists(filename) Then
            SaveFileDialog1.Filter = "All Files (*.*)| *.*"
            SaveFileDialog1.InitialDirectory = "c:\safelock"
            SaveFileDialog1.ShowDialog()
            Dim path2 As String = SaveFileDialog1.FileName
            If SaveFileDialog1.FileName <> Nothing Then
                OpenBase64.OpenBase64.DecodeFile(filename, path2)
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If System.IO.File.Exists(filename) Then
            Dim conn As New SqlConnection
            conn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename='L:\Backup M2\PSI\Prog\Projecto Tecnologico\SafeLock\SafeLock\SafeLock\Safelock_DB.mdf';Integrated Security=True;User Instance=True"

            Try

                conn.Open()
            Catch ex As SqlException
                MsgBox("Error connecting to Database")
            End Try
            If System.IO.File.Exists(filename) Then
                OpenFileDialog1.Filter = "All Files (*.*)| *.*"
                OpenFileDialog1.InitialDirectory = "c:\safelock"
                OpenFileDialog1.ShowDialog()
                Dim path2 As String = OpenFileDialog1.FileName
                If OpenFileDialog1.FileName <> Nothing Then
                    Dim adapter As New SqlDataAdapter
                    Dim query = "INSERT INTO Files (GUID, Timestamp, Filename, Filedata) VALUES ('" + My.Computer.Name + "','" + System.DateTime.Now + "','" + filename + "','" + path2 + "')"
                    Dim cmd As New SqlCommand

                    cmd.Connection = conn
                    cmd.CommandText = query
                    adapter.SelectCommand = cmd

                    Dim data As SqlDataReader
                    data = cmd.ExecuteReader
                    If (data.Read()) Then
                        MsgBox("File uploaded.")
                    Else
                        MsgBox("Error.")
                    End If
                End If
            End If
        End If
    End Sub
End Class
