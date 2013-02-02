Imports System.Xml
Imports System.Xml.XPath

Public Class RSS
    Private Url As String
    Private Sub Main_Load(sender As System.Object, e As System.EventArgs)
        Url = String.Empty ' Clears Feed path.
    End Sub
    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            Url = Me.ToolStripTextBox1.Text ' Receives url from textbox.
            TreeView1.Nodes.Clear() ' Clears any previous feed if existant.
            Me.Cursor = Cursors.WaitCursor ' Changes Cursor
            Dim docxml As New XmlDocument() ' Creates temp XML Doc
            Try
                docxml.Load(Url) ' Loads feed to XML Doc
                Me.Cursor = Cursors.Default ' Returns default cursor.
            Catch ex1 As Exception
                Me.Cursor = Cursors.Default
                MessageBox.Show(ex1.Message)
                Return
            End Try
            Dim nav As XPathNavigator = docxml.CreateNavigator() ' Creates a Navigator for the feeds.
            Try
                Dim nodes As XPathNodeIterator = nav.Select("/rss/channel/item/title")
                While nodes.MoveNext
                    Dim node As XPathNavigator = nodes.Current
                    Dim temp As String = node.Value.Trim()
                    temp = temp.Replace(ControlChars.CrLf, "")
                    temp = temp.Replace(ControlChars.Lf, "")
                    temp = temp.Replace(ControlChars.Cr, "")
                    temp = temp.Replace(ControlChars.FormFeed, "")
                    temp = temp.Replace(ControlChars.NewLine, "")
                    TreeView1.Nodes.Add(temp)
                End While
                Dim positionnode As Integer = 0
                Dim nodesLink As XPathNodeIterator = nav.Select("/rss/channel/item/link")
                While nodesLink.MoveNext
                    Dim node As XPathNavigator = nodesLink.Current
                    Dim temp As String = node.Value.Trim()
                    temp = temp.Replace(ControlChars.CrLf, "")
                    temp = temp.Replace(ControlChars.Lf, "")
                    temp = temp.Replace(ControlChars.Cr, "")
                    temp = temp.Replace(ControlChars.FormFeed, "")
                    temp = temp.Replace(ControlChars.NewLine, "")
                    TreeView1.Nodes(positionnode).Nodes.Add(temp)
                    positionnode += 1
                End While
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error loading feed.")
            End Try
            Me.Cursor = Cursors.Default
        Catch ex2 As Exception
            MessageBox.Show(ex2.ToString(), "Initializing failure.")
        End Try
    End Sub

    Private Sub TreeView1_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Try
            Dim temp As String = TreeView1.SelectedNode.Text.Substring(0, 4)
            If temp = "http" Then
                WebBrowser1.Navigate(TreeView1.SelectedNode.Text)
            End If
        Catch
        End Try
    End Sub
End Class

' leChat Client - RSS - This program might be rewritten using aSync Sockets like the Files and ReceiveFiles on the Client were implemented or fully recoded in C#.

' This seriously took a lot of my time and my sleep.
' So please, contribute and report bugs or any new features you would like to be implemented.
' Contact me at zgrav@null.net for more information
' Check out my Github if you're interested on any other project that I might have - http://github.com/zGrav
' Don't steal Source Code, read it, learn it, adapt it and give credit to original owner.
' This program was developed by me and my coworker EvilMonstah/Diogo Alexandre who helped out on ideas, documentation and implementation of some features.
' (c) zGrav/David Samuel - 22nd June 2012