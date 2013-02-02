<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.cntbutton = New System.Windows.Forms.Button()
        Me.chattxt = New System.Windows.Forms.TextBox()
        Me.msgtxt = New System.Windows.Forms.TextBox()
        Me.sendBtn = New System.Windows.Forms.Button()
        Me.Clearbtn = New System.Windows.Forms.Button()
        Me.sndbtn = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SendFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WhoisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrefBtn = New System.Windows.Forms.Button()
        Me.CapsONoff = New System.Windows.Forms.PictureBox()
        Me.NumONoff = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtrasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RSSReaderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommandsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.WebBrowserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.CapsONoff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumONoff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cntbutton
        '
        Me.cntbutton.Location = New System.Drawing.Point(128, 36)
        Me.cntbutton.Name = "cntbutton"
        Me.cntbutton.Size = New System.Drawing.Size(81, 23)
        Me.cntbutton.TabIndex = 2
        Me.cntbutton.Text = "Connect"
        Me.cntbutton.UseVisualStyleBackColor = True
        '
        'chattxt
        '
        Me.chattxt.Location = New System.Drawing.Point(33, 67)
        Me.chattxt.Multiline = True
        Me.chattxt.Name = "chattxt"
        Me.chattxt.ReadOnly = True
        Me.chattxt.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.chattxt.Size = New System.Drawing.Size(261, 351)
        Me.chattxt.TabIndex = 3
        '
        'msgtxt
        '
        Me.msgtxt.Location = New System.Drawing.Point(0, 424)
        Me.msgtxt.Name = "msgtxt"
        Me.msgtxt.Size = New System.Drawing.Size(308, 20)
        Me.msgtxt.TabIndex = 4
        '
        'sendBtn
        '
        Me.sendBtn.Location = New System.Drawing.Point(314, 422)
        Me.sendBtn.Name = "sendBtn"
        Me.sendBtn.Size = New System.Drawing.Size(75, 23)
        Me.sendBtn.TabIndex = 6
        Me.sendBtn.Text = "Send"
        Me.sendBtn.UseVisualStyleBackColor = True
        '
        'Clearbtn
        '
        Me.Clearbtn.Location = New System.Drawing.Point(47, 36)
        Me.Clearbtn.Name = "Clearbtn"
        Me.Clearbtn.Size = New System.Drawing.Size(75, 23)
        Me.Clearbtn.TabIndex = 8
        Me.Clearbtn.Text = "Clear"
        Me.Clearbtn.UseVisualStyleBackColor = True
        '
        'sndbtn
        '
        Me.sndbtn.Location = New System.Drawing.Point(215, 36)
        Me.sndbtn.Name = "sndbtn"
        Me.sndbtn.Size = New System.Drawing.Size(68, 23)
        Me.sndbtn.TabIndex = 9
        Me.sndbtn.Text = "Files"
        Me.sndbtn.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(300, 65)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(99, 355)
        Me.ListBox1.TabIndex = 10
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SendFileToolStripMenuItem, Me.WhoisToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(118, 48)
        '
        'SendFileToolStripMenuItem
        '
        Me.SendFileToolStripMenuItem.Name = "SendFileToolStripMenuItem"
        Me.SendFileToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.SendFileToolStripMenuItem.Text = "Send File"
        '
        'WhoisToolStripMenuItem
        '
        Me.WhoisToolStripMenuItem.Name = "WhoisToolStripMenuItem"
        Me.WhoisToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.WhoisToolStripMenuItem.Text = "Whois"
        '
        'PrefBtn
        '
        Me.PrefBtn.Location = New System.Drawing.Point(289, 36)
        Me.PrefBtn.Name = "PrefBtn"
        Me.PrefBtn.Size = New System.Drawing.Size(75, 23)
        Me.PrefBtn.TabIndex = 11
        Me.PrefBtn.Text = "Preferences"
        Me.PrefBtn.UseVisualStyleBackColor = True
        '
        'CapsONoff
        '
        Me.CapsONoff.Location = New System.Drawing.Point(12, 67)
        Me.CapsONoff.Name = "CapsONoff"
        Me.CapsONoff.Size = New System.Drawing.Size(12, 14)
        Me.CapsONoff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CapsONoff.TabIndex = 12
        Me.CapsONoff.TabStop = False
        '
        'NumONoff
        '
        Me.NumONoff.Location = New System.Drawing.Point(12, 87)
        Me.NumONoff.Name = "NumONoff"
        Me.NumONoff.Size = New System.Drawing.Size(12, 14)
        Me.NumONoff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.NumONoff.TabIndex = 13
        Me.NumONoff.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.ExtrasToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(410, 24)
        Me.MenuStrip1.TabIndex = 14
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreferencesToolStripMenuItem, Me.AboutToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'PreferencesToolStripMenuItem
        '
        Me.PreferencesToolStripMenuItem.Name = "PreferencesToolStripMenuItem"
        Me.PreferencesToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.PreferencesToolStripMenuItem.Text = "Preferences"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(129, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ExtrasToolStripMenuItem
        '
        Me.ExtrasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RSSReaderToolStripMenuItem, Me.WebBrowserToolStripMenuItem})
        Me.ExtrasToolStripMenuItem.Name = "ExtrasToolStripMenuItem"
        Me.ExtrasToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.ExtrasToolStripMenuItem.Text = "Extras"
        '
        'RSSReaderToolStripMenuItem
        '
        Me.RSSReaderToolStripMenuItem.Name = "RSSReaderToolStripMenuItem"
        Me.RSSReaderToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RSSReaderToolStripMenuItem.Text = "RSS Reader"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CommandsToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'CommandsToolStripMenuItem
        '
        Me.CommandsToolStripMenuItem.Name = "CommandsToolStripMenuItem"
        Me.CommandsToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.CommandsToolStripMenuItem.Text = "Commands"
        '
        'WebBrowserToolStripMenuItem
        '
        Me.WebBrowserToolStripMenuItem.Name = "WebBrowserToolStripMenuItem"
        Me.WebBrowserToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.WebBrowserToolStripMenuItem.Text = "Web Browser"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 452)
        Me.Controls.Add(Me.NumONoff)
        Me.Controls.Add(Me.CapsONoff)
        Me.Controls.Add(Me.PrefBtn)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.sndbtn)
        Me.Controls.Add(Me.Clearbtn)
        Me.Controls.Add(Me.sendBtn)
        Me.Controls.Add(Me.msgtxt)
        Me.Controls.Add(Me.chattxt)
        Me.Controls.Add(Me.cntbutton)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.Text = "Client"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.CapsONoff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumONoff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cntbutton As System.Windows.Forms.Button
    Friend WithEvents chattxt As System.Windows.Forms.TextBox
    Friend WithEvents msgtxt As System.Windows.Forms.TextBox
    Friend WithEvents sendBtn As System.Windows.Forms.Button
    Friend WithEvents Clearbtn As System.Windows.Forms.Button
    Friend WithEvents sndbtn As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents PrefBtn As System.Windows.Forms.Button
    Friend WithEvents CapsONoff As System.Windows.Forms.PictureBox
    Friend WithEvents NumONoff As System.Windows.Forms.PictureBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreferencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SendFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WhoisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExtrasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CommandsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RSSReaderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents WebBrowserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
