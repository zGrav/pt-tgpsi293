Imports System.IO

Public Class Preferences

#Region "Declarations"
    Dim idx As Integer
    Dim OriFPath As String
    Dim fName As String
    Dim strBasePath As String
    Dim s As String
#End Region

    Private Sub Preferences_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If StatusBox.Text = Nothing Then
            StatusBox.SelectedItem = "Online"
        End If


        If My.Settings.Nickname = Nothing Then
            NickTxt.Text = Environment.UserName
        Else
            NickTxt.Text = My.Settings.Nickname
        End If
        StatusBox.SelectedIndex = My.Settings.Status
        NameTxt.Text = My.Settings.Name
        DescTxt.Text = My.Settings.Description
        AgeTxt.Text = My.Settings.Age
        IPTxt.Text = My.Settings.IP
        PortTxt.Text = My.Settings.Port
        ServerTxt.Text = My.Settings.ServerName
        soundcheck.Checked = My.Settings.SoundCheck
        spcheck.Checked = My.Settings.SpathCheck
        filepath.Text = My.Settings.SoundPath

        'Data Grid Read File
        Try
            ServerList.DataSource = Nothing
            ds.ReadXml("serverList.xml")
            ServerList.DataSource = ds
            ServerList.DataMember = "ServerTable"

            'For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            ' ServerList.Rows.Add(ds.Tables(0).Rows(i))
            ' Next

        Catch ex As Exception

        End Try
        '------
    End Sub

    Private Sub TextChanged(sender As System.Object, e As System.EventArgs) Handles NickTxt.TextChanged, IPTxt.TextChanged, PortTxt.TextChanged, ServerTxt.TextChanged
        If NickTxt.Text <> "" AndAlso IPTxt.Text <> "" AndAlso PortTxt.Text <> "" Then
            ApplyBtn.Enabled = True
        ElseIf NickTxt.Text = "" Or IPTxt.Text = "" Or PortTxt.Text = "" Then
            ApplyBtn.Enabled = False
        End If
        If ServerTxt.Text <> "" AndAlso IPTxt.Text <> "" AndAlso PortTxt.Text <> "" Then
            Addbtn.Enabled = True
        ElseIf ServerTxt.Text = "" Or IPTxt.Text = "" Or PortTxt.Text = "" Then
            Addbtn.Enabled = False
        End If
    End Sub

    Private Sub ServerList_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ServerList.CellClick
        Dim i As Integer
        Try
            i = ServerList.CurrentRow.Index
            ServerTxt.Text = ServerList.Item(0, i).Value
            IPTxt.Text = ServerList.Item(1, i).Value
            PortTxt.Text = ServerList.Item(2, i).Value
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Addbtn_Click(sender As System.Object, e As System.EventArgs) Handles Addbtn.Click
        Try
            ServerTable.Rows.Add(ServerTxt.Text, IPTxt.Text, PortTxt.Text)
            ServerList.DataSource = ds
            ServerList.DataMember = "ServerTable"
            ds.WriteXml("serverList.xml")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RemoveBtn_Click(sender As System.Object, e As System.EventArgs) Handles RemoveBtn.Click
        Try
            idx = ServerList.CurrentRow.Index
            ServerTable.Rows.Remove(ServerTable.Rows(idx))
            ds = ServerList.DataSource
            ServerList.DataMember = "ServerTable"
            ds.WriteXml("serverList.xml")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub soundStateChanged(sender As System.Object, e As System.EventArgs) Handles soundcheck.CheckedChanged, spcheck.CheckedChanged
        If soundcheck.Checked = True Then
            spcheck.Enabled = True
            If spcheck.Checked = True Then
                filepath.Enabled = True
                filebtn.Enabled = True
            ElseIf spcheck.Checked = False Then
                filepath.Enabled = False
                filebtn.Enabled = False
            End If
        ElseIf soundcheck.Checked = False Then
            spcheck.Enabled = False
            filepath.Enabled = False
            filebtn.Enabled = False
        End If
    End Sub

    Private Sub filebtn_Click(sender As System.Object, e As System.EventArgs) Handles filebtn.Click
        Try
            SoundDialog.Filter = "Wave Files(*.wav)|*.wav"
            strBasePath = Application.StartupPath & "\Notification"
            SoundDialog.FileName = ""
            SoundDialog.ShowDialog()
            filepath.Text = SoundDialog.SafeFileName
            OriFPath = SoundDialog.FileName
            fName = filepath.Text
            If Directory.Exists(strBasePath) = False Then
                Call Directory.CreateDirectory(strBasePath)
            End If
            If fName <> Nothing Then
                s = fName.Substring(fName.LastIndexOf("\"c) + 1)
                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Notification\" & s) Then
                    If MsgBox("Sound already exists on notification folder, do you want to overwrite it?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Notification\" & s)
                    Else
                        Exit Sub
                    End If
                    My.Computer.FileSystem.CopyFile(OriFPath, Application.StartupPath & "\Notification\" & s)
                End If
            End If
        Catch ex As IOException
        End Try
    End Sub

    Private Sub ApplyBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApplyBtn.Click
        My.Settings.Nickname = NickTxt.Text
        My.Settings.Status = StatusBox.SelectedIndex
            My.Settings.Name = NameTxt.Text
            My.Settings.Description = DescTxt.Text
            My.Settings.Age = AgeTxt.Text
            My.Settings.IP = IPTxt.Text
            My.Settings.Port = PortTxt.Text
            My.Settings.ServerName = ServerTxt.Text
            My.Settings.SoundCheck = soundcheck.Checked
            My.Settings.SpathCheck = spcheck.Checked
            My.Settings.SoundPath = filepath.Text

            My.Settings.Save()
    End Sub

    Private Sub ModifyBtn_Click(sender As System.Object, e As System.EventArgs) Handles ModifyBtn.Click
        Dim i As Integer
        i = ServerList.CurrentRow.Index
        ServerList.Item(0, i).Value = ServerTxt.Text
        ServerList.Item(1, i).Value = IPTxt.Text
        ServerList.Item(2, i).Value = PortTxt.Text

    End Sub


    Private Sub StatusBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles StatusBox.SelectedIndexChanged
        Try
                If StatusBox.SelectedItem = "Custom" Then
                Dim customstr As String = InputBox("Insert a Custom status.", "Waiting for input")
                Main.msgtxt.Text = "I'm now currently " + customstr
                Main.sendBtn.PerformClick()
                Main.msgtxt.Text = ""
                Else
                Main.msgtxt.Text = "I'm now currently " + StatusBox.Text
                Main.sendBtn.PerformClick()
                Main.msgtxt.Text = ""
                End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub IPTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles IPTxt.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub PortTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles PortTxt.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

End Class

' leChat Client - Preferences Menu - This program might be rewritten using aSync Sockets like the Files and ReceiveFiles on the Client were implemented or fully recoded in C#.

' This seriously took a lot of my time and my sleep.
' So please, contribute and report bugs or any new features you would like to be implemented.
' Contact me at zgrav@null.net for more information
' Check out my Github if you're interested on any other project that I might have - http://github.com/zGrav
' Don't steal Source Code, read it, learn it, adapt it and give credit to original owner.
' This program was developed by me and my coworker EvilMonstah/Diogo Alexandre who helped out on ideas, documentation and implementation of some features.
' (c) zGrav/David Samuel - 22nd June 2012