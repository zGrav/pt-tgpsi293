<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewGame
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
        Me.txtp1name = New System.Windows.Forms.TextBox()
        Me.p1Label = New System.Windows.Forms.Label()
        Me.boxp1 = New System.Windows.Forms.ComboBox()
        Me.p1play = New System.Windows.Forms.RadioButton()
        Me.p2play = New System.Windows.Forms.RadioButton()
        Me.boxp2 = New System.Windows.Forms.ComboBox()
        Me.p2Label = New System.Windows.Forms.Label()
        Me.txtp2name = New System.Windows.Forms.TextBox()
        Me.boxskin = New System.Windows.Forms.ComboBox()
        Me.checktimer = New System.Windows.Forms.CheckBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtp1name
        '
        Me.txtp1name.Location = New System.Drawing.Point(77, 9)
        Me.txtp1name.Name = "txtp1name"
        Me.txtp1name.Size = New System.Drawing.Size(100, 20)
        Me.txtp1name.TabIndex = 2
        '
        'p1Label
        '
        Me.p1Label.AutoSize = True
        Me.p1Label.Location = New System.Drawing.Point(9, 12)
        Me.p1Label.Name = "p1Label"
        Me.p1Label.Size = New System.Drawing.Size(62, 13)
        Me.p1Label.TabIndex = 3
        Me.p1Label.Text = "Player One:"
        '
        'boxp1
        '
        Me.boxp1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.boxp1.Enabled = False
        Me.boxp1.FormattingEnabled = True
        Me.boxp1.Location = New System.Drawing.Point(77, 35)
        Me.boxp1.Name = "boxp1"
        Me.boxp1.Size = New System.Drawing.Size(121, 21)
        Me.boxp1.TabIndex = 4
        '
        'p1play
        '
        Me.p1play.AutoSize = True
        Me.p1play.Location = New System.Drawing.Point(12, 62)
        Me.p1play.Name = "p1play"
        Me.p1play.Size = New System.Drawing.Size(73, 17)
        Me.p1play.TabIndex = 5
        Me.p1play.TabStop = True
        Me.p1play.Text = "1st to play"
        Me.p1play.UseVisualStyleBackColor = True
        '
        'p2play
        '
        Me.p2play.AutoSize = True
        Me.p2play.Location = New System.Drawing.Point(12, 149)
        Me.p2play.Name = "p2play"
        Me.p2play.Size = New System.Drawing.Size(73, 17)
        Me.p2play.TabIndex = 9
        Me.p2play.TabStop = True
        Me.p2play.Text = "1st to play"
        Me.p2play.UseVisualStyleBackColor = True
        '
        'boxp2
        '
        Me.boxp2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.boxp2.Enabled = False
        Me.boxp2.FormattingEnabled = True
        Me.boxp2.Location = New System.Drawing.Point(77, 122)
        Me.boxp2.Name = "boxp2"
        Me.boxp2.Size = New System.Drawing.Size(121, 21)
        Me.boxp2.TabIndex = 8
        '
        'p2Label
        '
        Me.p2Label.AutoSize = True
        Me.p2Label.Location = New System.Drawing.Point(9, 99)
        Me.p2Label.Name = "p2Label"
        Me.p2Label.Size = New System.Drawing.Size(63, 13)
        Me.p2Label.TabIndex = 7
        Me.p2Label.Text = "Player Two:"
        '
        'txtp2name
        '
        Me.txtp2name.Location = New System.Drawing.Point(77, 99)
        Me.txtp2name.Name = "txtp2name"
        Me.txtp2name.Size = New System.Drawing.Size(100, 20)
        Me.txtp2name.TabIndex = 6
        '
        'boxskin
        '
        Me.boxskin.FormattingEnabled = True
        Me.boxskin.Items.AddRange(New Object() {"Default", "Space"})
        Me.boxskin.Location = New System.Drawing.Point(49, 184)
        Me.boxskin.Name = "boxskin"
        Me.boxskin.Size = New System.Drawing.Size(121, 21)
        Me.boxskin.TabIndex = 10
        '
        'checktimer
        '
        Me.checktimer.AutoSize = True
        Me.checktimer.Location = New System.Drawing.Point(12, 211)
        Me.checktimer.Name = "checktimer"
        Me.checktimer.Size = New System.Drawing.Size(82, 17)
        Me.checktimer.TabIndex = 11
        Me.checktimer.Text = "Timed plays"
        Me.checktimer.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(126, 227)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 12
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(207, 227)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 187)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Skin:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Piece:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Piece:"
        '
        'frmNewGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.checktimer)
        Me.Controls.Add(Me.boxskin)
        Me.Controls.Add(Me.p2play)
        Me.Controls.Add(Me.boxp2)
        Me.Controls.Add(Me.p2Label)
        Me.Controls.Add(Me.txtp2name)
        Me.Controls.Add(Me.p1play)
        Me.Controls.Add(Me.boxp1)
        Me.Controls.Add(Me.p1Label)
        Me.Controls.Add(Me.txtp1name)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmNewGame"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Game"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtp1name As System.Windows.Forms.TextBox
    Friend WithEvents p1Label As System.Windows.Forms.Label
    Friend WithEvents boxp1 As System.Windows.Forms.ComboBox
    Friend WithEvents p1play As System.Windows.Forms.RadioButton
    Friend WithEvents p2play As System.Windows.Forms.RadioButton
    Friend WithEvents boxp2 As System.Windows.Forms.ComboBox
    Friend WithEvents p2Label As System.Windows.Forms.Label
    Friend WithEvents txtp2name As System.Windows.Forms.TextBox
    Friend WithEvents boxskin As System.Windows.Forms.ComboBox
    Friend WithEvents checktimer As System.Windows.Forms.CheckBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
