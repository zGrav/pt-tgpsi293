Public Class Browser
    Public url As String
    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        url = ToolStripTextBox1.Text
        If ToolStripTextBox1.Text = "" Then
            MsgBox("Please insert a valid URL")
        End If
        WebBrowser1.Navigate(url)
    End Sub
End Class

' leChat Client - Browser - This program might be rewritten using aSync Sockets like the Files and ReceiveFiles on the Client were implemented or fully recoded in C#.

' This seriously took a lot of my time and my sleep.
' So please, contribute and report bugs or any new features you would like to be implemented.
' Contact me at zgrav@null.net for more information
' Check out my Github if you're interested on any other project that I might have - http://github.com/zGrav
' Don't steal Source Code, read it, learn it, adapt it and give credit to original owner.
' This program was developed by me and my coworker EvilMonstah/Diogo Alexandre who helped out on ideas, documentation and implementation of some features.
' (c) zGrav/David Samuel - 22nd June 2012