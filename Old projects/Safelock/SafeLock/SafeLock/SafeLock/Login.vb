Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.IO
Public Class Login

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim conn As New SqlConnection
        conn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename='F:\Backup M2\PSI\Prog\Projecto Tecnologico\SafeLock\SafeLock\SafeLock\Safelock_DB.mdf';Integrated Security=True;User Instance=True"

        Try
            conn.Open()
        Catch ex As SqlException
            MsgBox("Error connecting to Database")
        End Try
        'B64 encrypt
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(PasswordTextBox.Text)
        Dim strb64enc As String
        strb64enc = Convert.ToBase64String(byt)

        ' B64 decrypt
        'Dim b As Byte() = Convert.FromBase64String(strb64enc)
        'Dim strb64dec As String
        'strb64dec = System.Text.Encoding.UTF8.GetString(b)
        ' End

        Dim adapter As New SqlDataAdapter
        Dim query = "SELECT * FROM Users WHERE Username = '" + UsernameTextBox.Text + "' and Password = '" + strb64enc + "'"
        Dim cmd As New SqlCommand

        cmd.Connection = conn
        cmd.CommandText = query
        adapter.SelectCommand = cmd

        Dim data As SqlDataReader
        data = cmd.ExecuteReader
        If (data.Read()) Then
            MsgBox("Welcome " & UsernameTextBox.Text)
            Main.Show()
            Me.Hide()
        Else
            MsgBox("User not recognized.")
        End If
        conn.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LinkRegister_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkRegister.LinkClicked
        If Register.ShowDialog = DialogResult.OK Then

        End If

    End Sub


End Class
