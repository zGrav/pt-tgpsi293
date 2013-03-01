namespace LPO
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Button1 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.PictureBox4 = new System.Windows.Forms.PictureBox();
            this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
            this.LinkLabel2 = new System.Windows.Forms.LinkLabel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.launchGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(0, 28);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(394, 52);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "Run game with anticheat";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.PictureBox4);
            this.GroupBox1.Controls.Add(this.LinkLabel1);
            this.GroupBox1.Controls.Add(this.LinkLabel2);
            this.GroupBox1.Location = new System.Drawing.Point(91, 153);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(181, 192);
            this.GroupBox1.TabIndex = 18;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Report Tool";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(6, 170);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(164, 12);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "You can also report bugs and problems!";
            // 
            // PictureBox4
            // 
            this.PictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox4.Image")));
            this.PictureBox4.Location = new System.Drawing.Point(21, 45);
            this.PictureBox4.Name = "PictureBox4";
            this.PictureBox4.Size = new System.Drawing.Size(131, 123);
            this.PictureBox4.TabIndex = 3;
            this.PictureBox4.TabStop = false;
            this.PictureBox4.Click += new System.EventHandler(this.PictureBox4_Click);
            // 
            // LinkLabel1
            // 
            this.LinkLabel1.AutoSize = true;
            this.LinkLabel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LinkLabel1.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LinkLabel1.LinkColor = System.Drawing.Color.Black;
            this.LinkLabel1.Location = new System.Drawing.Point(11, 16);
            this.LinkLabel1.Name = "LinkLabel1";
            this.LinkLabel1.Size = new System.Drawing.Size(159, 13);
            this.LinkLabel1.TabIndex = 16;
            this.LinkLabel1.Text = "Want to Report a Cheater/Bug?";
            // 
            // LinkLabel2
            // 
            this.LinkLabel2.AutoSize = true;
            this.LinkLabel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LinkLabel2.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LinkLabel2.LinkColor = System.Drawing.Color.Black;
            this.LinkLabel2.Location = new System.Drawing.Point(11, 29);
            this.LinkLabel2.Name = "LinkLabel2";
            this.LinkLabel2.Size = new System.Drawing.Size(151, 13);
            this.LinkLabel2.TabIndex = 17;
            this.LinkLabel2.Text = "Use the REPORT TOOL here!";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(-7, 351);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(401, 136);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 13;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 26;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(394, 52);
            this.button2.TabIndex = 27;
            this.button2.Text = "Manual check for updates";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripLabel3,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(394, 25);
            this.toolStrip1.TabIndex = 28;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolStripLabel3
            // 
            this.ToolStripLabel3.Name = "ToolStripLabel3";
            this.ToolStripLabel3.Size = new System.Drawing.Size(57, 22);
            this.ToolStripLabel3.Text = "Welcome";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ESA Anticheat";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 48);
            // 
            // launchGameToolStripMenuItem
            // 
            this.launchGameToolStripMenuItem.Name = "launchGameToolStripMenuItem";
            this.launchGameToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.launchGameToolStripMenuItem.Text = "Launch Game";
            this.launchGameToolStripMenuItem.Click += new System.EventHandler(this.launchGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 483);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ESAGamer Anticheat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox PictureBox4;
        internal System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel ToolStripLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchGameToolStripMenuItem;
        internal System.Windows.Forms.LinkLabel LinkLabel1;
        internal System.Windows.Forms.LinkLabel LinkLabel2;
    }
}