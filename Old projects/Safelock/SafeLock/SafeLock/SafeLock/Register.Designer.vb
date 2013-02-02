<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Register
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Register))
        Me.Username = New System.Windows.Forms.Label()
        Me.UserNameField = New System.Windows.Forms.TextBox()
        Me.Password = New System.Windows.Forms.Label()
        Me.Terms = New System.Windows.Forms.GroupBox()
        Me.TermsText = New System.Windows.Forms.Label()
        Me.RegisterValidate = New System.Windows.Forms.Button()
        Me.TermsCheck = New System.Windows.Forms.CheckBox()
        Me.PassWordField = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SecurityQuestions = New System.Windows.Forms.ComboBox()
        Me.Security_Answer = New System.Windows.Forms.Label()
        Me.SecurityAnswer = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.HelpBox1 = New System.Windows.Forms.PictureBox()
        Me.HelpBox2 = New System.Windows.Forms.PictureBox()
        Me.HelpBox3 = New System.Windows.Forms.PictureBox()
        Me.HelpNotifications = New System.Windows.Forms.ToolTip(Me.components)
        Me.Terms.SuspendLayout()
        CType(Me.HelpBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HelpBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HelpBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Username
        '
        Me.Username.AutoSize = True
        Me.Username.Location = New System.Drawing.Point(240, 13)
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(55, 13)
        Me.Username.TabIndex = 0
        Me.Username.Text = "&Username"
        '
        'UserNameField
        '
        Me.UserNameField.Location = New System.Drawing.Point(240, 30)
        Me.UserNameField.MaxLength = 14
        Me.UserNameField.Name = "UserNameField"
        Me.UserNameField.Size = New System.Drawing.Size(234, 20)
        Me.UserNameField.TabIndex = 1
        '
        'Password
        '
        Me.Password.AutoSize = True
        Me.Password.Location = New System.Drawing.Point(240, 58)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(53, 13)
        Me.Password.TabIndex = 2
        Me.Password.Text = "&Password"
        '
        'Terms
        '
        Me.Terms.Controls.Add(Me.TermsText)
        Me.Terms.Location = New System.Drawing.Point(12, 13)
        Me.Terms.Name = "Terms"
        Me.Terms.Size = New System.Drawing.Size(222, 221)
        Me.Terms.TabIndex = 3
        Me.Terms.TabStop = False
        Me.Terms.Text = "Terms and Conditions."
        '
        'TermsText
        '
        Me.TermsText.Location = New System.Drawing.Point(6, 20)
        Me.TermsText.Name = "TermsText"
        Me.TermsText.Size = New System.Drawing.Size(201, 176)
        Me.TermsText.TabIndex = 0
        Me.TermsText.Text = resources.GetString("TermsText.Text")
        '
        'RegisterValidate
        '
        Me.RegisterValidate.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.RegisterValidate.Location = New System.Drawing.Point(289, 211)
        Me.RegisterValidate.Name = "RegisterValidate"
        Me.RegisterValidate.Size = New System.Drawing.Size(75, 23)
        Me.RegisterValidate.TabIndex = 6
        Me.RegisterValidate.Text = "Register"
        Me.RegisterValidate.UseVisualStyleBackColor = True
        '
        'TermsCheck
        '
        Me.TermsCheck.AutoSize = True
        Me.TermsCheck.Location = New System.Drawing.Point(240, 188)
        Me.TermsCheck.Name = "TermsCheck"
        Me.TermsCheck.Size = New System.Drawing.Size(228, 17)
        Me.TermsCheck.TabIndex = 5
        Me.TermsCheck.Text = "I agree to application terms and conditions."
        Me.TermsCheck.UseVisualStyleBackColor = True
        '
        'PassWordField
        '
        Me.PassWordField.Location = New System.Drawing.Point(240, 74)
        Me.PassWordField.MaxLength = 50
        Me.PassWordField.Name = "PassWordField"
        Me.PassWordField.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PassWordField.Size = New System.Drawing.Size(234, 20)
        Me.PassWordField.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(240, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Security &Question"
        '
        'SecurityQuestions
        '
        Me.SecurityQuestions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SecurityQuestions.FormattingEnabled = True
        Me.SecurityQuestions.Items.AddRange(New Object() {"One of your wishes?", "What's the street name of the place you were born?", "What's your first pet name?"})
        Me.SecurityQuestions.Location = New System.Drawing.Point(240, 118)
        Me.SecurityQuestions.Name = "SecurityQuestions"
        Me.SecurityQuestions.Size = New System.Drawing.Size(260, 21)
        Me.SecurityQuestions.Sorted = True
        Me.SecurityQuestions.TabIndex = 3
        '
        'Security_Answer
        '
        Me.Security_Answer.AutoSize = True
        Me.Security_Answer.Location = New System.Drawing.Point(240, 146)
        Me.Security_Answer.Name = "Security_Answer"
        Me.Security_Answer.Size = New System.Drawing.Size(83, 13)
        Me.Security_Answer.TabIndex = 9
        Me.Security_Answer.Text = "Security &Answer"
        '
        'SecurityAnswer
        '
        Me.SecurityAnswer.Location = New System.Drawing.Point(240, 162)
        Me.SecurityAnswer.MaxLength = 50
        Me.SecurityAnswer.Name = "SecurityAnswer"
        Me.SecurityAnswer.Size = New System.Drawing.Size(234, 20)
        Me.SecurityAnswer.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(399, 211)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'HelpBox1
        '
        Me.HelpBox1.BackgroundImage = Global.SafeLock.My.Resources.Resources.VSDocs
        Me.HelpBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.HelpBox1.Location = New System.Drawing.Point(480, 30)
        Me.HelpBox1.Name = "HelpBox1"
        Me.HelpBox1.Size = New System.Drawing.Size(20, 20)
        Me.HelpBox1.TabIndex = 12
        Me.HelpBox1.TabStop = False
        Me.HelpNotifications.SetToolTip(Me.HelpBox1, "Choose an available username for your account login, both username and password a" & _
        "re essential for user to remember. (Max characters is 15.)")
        '
        'HelpBox2
        '
        Me.HelpBox2.BackgroundImage = Global.SafeLock.My.Resources.Resources.VSDocs
        Me.HelpBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.HelpBox2.Location = New System.Drawing.Point(480, 74)
        Me.HelpBox2.Name = "HelpBox2"
        Me.HelpBox2.Size = New System.Drawing.Size(20, 20)
        Me.HelpBox2.TabIndex = 13
        Me.HelpBox2.TabStop = False
        Me.HelpNotifications.SetToolTip(Me.HelpBox2, "Type the password you desire, take care on choosing your password. (Max character" & _
        "s is 100.)")
        '
        'HelpBox3
        '
        Me.HelpBox3.AccessibleDescription = ""
        Me.HelpBox3.BackgroundImage = Global.SafeLock.My.Resources.Resources.VSDocs
        Me.HelpBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.HelpBox3.Location = New System.Drawing.Point(480, 162)
        Me.HelpBox3.Name = "HelpBox3"
        Me.HelpBox3.Size = New System.Drawing.Size(20, 20)
        Me.HelpBox3.TabIndex = 14
        Me.HelpBox3.TabStop = False
        Me.HelpNotifications.SetToolTip(Me.HelpBox3, "Type the answer to the question above selected. (Max characters allowed is 50.)")
        '
        'Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 245)
        Me.Controls.Add(Me.HelpBox3)
        Me.Controls.Add(Me.HelpBox2)
        Me.Controls.Add(Me.HelpBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.SecurityAnswer)
        Me.Controls.Add(Me.Security_Answer)
        Me.Controls.Add(Me.SecurityQuestions)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PassWordField)
        Me.Controls.Add(Me.TermsCheck)
        Me.Controls.Add(Me.RegisterValidate)
        Me.Controls.Add(Me.Terms)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.UserNameField)
        Me.Controls.Add(Me.Username)
        Me.Name = "Register"
        Me.Text = "Register"
        Me.Terms.ResumeLayout(False)
        CType(Me.HelpBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HelpBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HelpBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Username As System.Windows.Forms.Label
    Friend WithEvents UserNameField As System.Windows.Forms.TextBox
    Friend WithEvents Password As System.Windows.Forms.Label
    Friend WithEvents Terms As System.Windows.Forms.GroupBox
    Friend WithEvents TermsText As System.Windows.Forms.Label
    Friend WithEvents RegisterValidate As System.Windows.Forms.Button
    Friend WithEvents TermsCheck As System.Windows.Forms.CheckBox
    Friend WithEvents PassWordField As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SecurityQuestions As System.Windows.Forms.ComboBox
    Friend WithEvents Security_Answer As System.Windows.Forms.Label
    Friend WithEvents SecurityAnswer As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents HelpBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents HelpBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents HelpBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents HelpNotifications As System.Windows.Forms.ToolTip
End Class
