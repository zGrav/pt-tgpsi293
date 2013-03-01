namespace LPO
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.Button3 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(25, 232);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(104, 41);
            this.Button3.TabIndex = 16;
            this.Button3.Text = "Register";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(292, 232);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(104, 41);
            this.Button2.TabIndex = 15;
            this.Button2.Text = "Cancel";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(13, 171);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 16);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "Password:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(10, 144);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(74, 16);
            this.Label1.TabIndex = 13;
            this.Label1.Text = "Username:";
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(90, 167);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.PasswordChar = '*';
            this.TextBox2.Size = new System.Drawing.Size(300, 20);
            this.TextBox2.TabIndex = 12;
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(90, 140);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(300, 20);
            this.TextBox1.TabIndex = 11;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(162, 232);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(104, 41);
            this.Button1.TabIndex = 10;
            this.Button1.Text = "Login";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // PictureBox1
            // 
            this.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(13, 12);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(383, 113);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 9;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(408, 296);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.PictureBox PictureBox1;
    }
}

