namespace LPO
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.Label4 = new System.Windows.Forms.Label();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(38, 102);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(95, 16);
            this.Label4.TabIndex = 23;
            this.Label4.Text = "E-mail Adress:";
            // 
            // TextBox3
            // 
            this.TextBox3.Location = new System.Drawing.Point(139, 102);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(155, 20);
            this.TextBox3.TabIndex = 22;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(97, 4);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(116, 31);
            this.Label3.TabIndex = 21;
            this.Label3.Text = "Register";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(7, 128);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(206, 191);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 20;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(62, 74);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 16);
            this.Label2.TabIndex = 19;
            this.Label2.Text = "Password:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(59, 47);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(74, 16);
            this.Label1.TabIndex = 18;
            this.Label1.Text = "Username:";
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(139, 74);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.PasswordChar = '*';
            this.TextBox2.Size = new System.Drawing.Size(155, 20);
            this.TextBox2.TabIndex = 17;
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(139, 43);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(155, 20);
            this.TextBox1.TabIndex = 16;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(220, 128);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 27);
            this.Button1.TabIndex = 15;
            this.Button1.Text = "Register";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 322);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RegisterForm";
            this.Text = "Register";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox TextBox3;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Button Button1;
    }
}