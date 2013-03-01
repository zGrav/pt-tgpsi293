namespace LPO
{
    partial class ReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.Label2 = new System.Windows.Forms.Label();
            this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(12, 237);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(356, 45);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Use the textbox above to report the Hacker/cheater you\'ve found. You should state" +
                " the time, the date and the server where you caught the hacker. You should also " +
                "provide us a way to contact you.";
            
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.Location = new System.Drawing.Point(12, 130);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.Size = new System.Drawing.Size(587, 101);
            this.RichTextBox1.TabIndex = 9;
            this.RichTextBox1.Text = "";
            
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(369, 73);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(216, 25);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Hacker Report Tool";
            
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(-99, 2);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(713, 128);
            this.PictureBox1.TabIndex = 7;
            this.PictureBox1.TabStop = false;
           
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Location = new System.Drawing.Point(374, 237);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(225, 44);
            this.Button1.TabIndex = 6;
            this.Button1.Text = "Send your Report";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 288);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.RichTextBox1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportForm";
            this.Text = "Report Tool";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.RichTextBox RichTextBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Button Button1;
    }
}