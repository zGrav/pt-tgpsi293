<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.GameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangePictureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayerOneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayerTwoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.GameStatusLabel = New System.Windows.Forms.Label()
        Me.p2Label = New System.Windows.Forms.Label()
        Me.GameLabel = New System.Windows.Forms.Label()
        Me.p1Label = New System.Windows.Forms.Label()
        Me.playerlabel = New System.Windows.Forms.Label()
        Me.ImageOpen = New System.Windows.Forms.OpenFileDialog()
        Me.timer_play = New System.Windows.Forms.Timer(Me.components)
        Me.countdownlabel = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(24, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(326, 333)
        Me.Panel1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GameToolStripMenuItem, Me.OptionsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(492, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GameToolStripMenuItem
        '
        Me.GameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem})
        Me.GameToolStripMenuItem.Name = "GameToolStripMenuItem"
        Me.GameToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.GameToolStripMenuItem.Text = "Game"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePictureToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'ChangePictureToolStripMenuItem
        '
        Me.ChangePictureToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlayerOneToolStripMenuItem, Me.PlayerTwoToolStripMenuItem})
        Me.ChangePictureToolStripMenuItem.Name = "ChangePictureToolStripMenuItem"
        Me.ChangePictureToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ChangePictureToolStripMenuItem.Text = "Change Picture"
        '
        'PlayerOneToolStripMenuItem
        '
        Me.PlayerOneToolStripMenuItem.Name = "PlayerOneToolStripMenuItem"
        Me.PlayerOneToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.PlayerOneToolStripMenuItem.Text = "Player One"
        '
        'PlayerTwoToolStripMenuItem
        '
        Me.PlayerTwoToolStripMenuItem.Name = "PlayerTwoToolStripMenuItem"
        Me.PlayerTwoToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.PlayerTwoToolStripMenuItem.Text = "Player Two"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(492, 404)
        Me.ShapeContainer1.TabIndex = 2
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = -3
        Me.LineShape2.X2 = 373
        Me.LineShape2.Y1 = 367
        Me.LineShape2.Y2 = 367
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 373
        Me.LineShape1.X2 = 373
        Me.LineShape1.Y1 = 26
        Me.LineShape1.Y2 = 403
        '
        'GameStatusLabel
        '
        Me.GameStatusLabel.AutoSize = True
        Me.GameStatusLabel.Location = New System.Drawing.Point(10, 378)
        Me.GameStatusLabel.Name = "GameStatusLabel"
        Me.GameStatusLabel.Size = New System.Drawing.Size(71, 13)
        Me.GameStatusLabel.TabIndex = 3
        Me.GameStatusLabel.Text = "Game Status:"
        '
        'p2Label
        '
        Me.p2Label.AutoSize = True
        Me.p2Label.Location = New System.Drawing.Point(376, 339)
        Me.p2Label.Name = "p2Label"
        Me.p2Label.Size = New System.Drawing.Size(39, 13)
        Me.p2Label.TabIndex = 7
        Me.p2Label.Text = "Label2"
        '
        'GameLabel
        '
        Me.GameLabel.AutoSize = True
        Me.GameLabel.Location = New System.Drawing.Point(87, 378)
        Me.GameLabel.Name = "GameLabel"
        Me.GameLabel.Size = New System.Drawing.Size(39, 13)
        Me.GameLabel.TabIndex = 8
        Me.GameLabel.Text = "Label1"
        '
        'p1Label
        '
        Me.p1Label.AutoSize = True
        Me.p1Label.Location = New System.Drawing.Point(376, 147)
        Me.p1Label.Name = "p1Label"
        Me.p1Label.Size = New System.Drawing.Size(39, 13)
        Me.p1Label.TabIndex = 6
        Me.p1Label.Text = "Label1"
        '
        'playerlabel
        '
        Me.playerlabel.AutoSize = True
        Me.playerlabel.Location = New System.Drawing.Point(249, 378)
        Me.playerlabel.Name = "playerlabel"
        Me.playerlabel.Size = New System.Drawing.Size(39, 13)
        Me.playerlabel.TabIndex = 9
        Me.playerlabel.Text = "Label1"
        '
        'ImageOpen
        '
        Me.ImageOpen.FileName = "OpenFileDialog1"
        '
        'timer_play
        '
        '
        'countdownlabel
        '
        Me.countdownlabel.AutoSize = True
        Me.countdownlabel.Location = New System.Drawing.Point(411, 378)
        Me.countdownlabel.Name = "countdownlabel"
        Me.countdownlabel.Size = New System.Drawing.Size(39, 13)
        Me.countdownlabel.TabIndex = 10
        Me.countdownlabel.Text = "Label1"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(379, 232)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 101)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(379, 40)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(102, 103)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 404)
        Me.Controls.Add(Me.countdownlabel)
        Me.Controls.Add(Me.playerlabel)
        Me.Controls.Add(Me.GameLabel)
        Me.Controls.Add(Me.p2Label)
        Me.Controls.Add(Me.p1Label)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GameStatusLabel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TicTacToe"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents GameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents GameStatusLabel As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents p2Label As System.Windows.Forms.Label
    Friend WithEvents GameLabel As System.Windows.Forms.Label
    Friend WithEvents p1Label As System.Windows.Forms.Label
    Friend WithEvents playerlabel As System.Windows.Forms.Label
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangePictureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlayerOneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlayerTwoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents timer_play As System.Windows.Forms.Timer
    Friend WithEvents countdownlabel As System.Windows.Forms.Label
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
