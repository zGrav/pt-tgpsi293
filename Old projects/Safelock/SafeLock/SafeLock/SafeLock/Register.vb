Imports System.Data.SqlClient
Public Class Register
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub RegisterValidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterValidate.Click
        Dim conn As New SqlConnection
        conn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename='F:\Backup M2\PSI\Prog\Projecto Tecnologico\SafeLock\SafeLock\SafeLock\Safelock_DB.mdf';Integrated Security=True;User Instance=True"
 
        Try
            conn.Open()
        Catch ex As SqlException
            MsgBox("Error connecting to Database")
        End Try

    Dim adapter As New SqlDataAdapter
    Dim query = "SELECT * FROM Users WHERE Username = '" + UserNameField.Text + "' and GUID = '" + My.Computer.Name + "'"
    Dim cmd As New SqlCommand

        cmd.Connection = conn
        cmd.CommandText = query
        adapter.SelectCommand = cmd

    Dim data As SqlDataReader
        data = cmd.ExecuteReader
        If data.HasRows = 0 Then
            conn.Close()
            If TermsCheck.CheckState = CheckState.Checked Then
                conn.Open()
                Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(PassWordField.Text)
                Dim strb64 As String
                strb64 = Convert.ToBase64String(byt)
                Dim register As New SqlDataAdapter
                Dim query2 = "INSERT INTO Users (GUID, Username, Password, Security_Question, Security_Answer) VALUES ('" + My.Computer.Name + "','" + UserNameField.Text + "','" + strb64 + "','" + SecurityQuestions.SelectedItem + "','" + SecurityAnswer.Text + "')"
                cmd.Connection = conn
                cmd.CommandText = query2
                register.SelectCommand = cmd
                data = cmd.ExecuteReader
                MsgBox("Thank you for registering." & Environment.NewLine & "Please keep this data in a safe piece of paper." & Environment.NewLine & "Username: " & UserNameField.Text & Environment.NewLine & "Password: " & passwordfield.Text & Environment.NewLine & "Security Question: " & SecurityQuestions.SelectedItem & Environment.NewLine & "Security Answer: " & SecurityAnswer.Text)
                Me.Hide()
            Else
                MsgBox("Please accept the ToS of our program.")
            End If
        Else
            MsgBox("User already exists.")
        End If
    End Sub

    Private Sub Register_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class