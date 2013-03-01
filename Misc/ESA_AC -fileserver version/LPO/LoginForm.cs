using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using LPO.Global;
using LPO.Utillity;

namespace LPO
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            if (File.Exists("c:\\esagamerac\\myusername.txt") == true)
            {
                TextBox1.Text = File.ReadAllText("C:\\esagamerac\\myusername.txt");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("c:\\esagamerac\\myusername.txt") == true)
            {
                File.Delete("C:\\esagamerac\\myusername.txt");
            }
            
            File.WriteAllText("C:\\esagamerac\\myusername.txt", TextBox1.Text);
            try
            {
                System.Net.WebClient WC = new System.Net.WebClient();
                string hash = Core.MD5Encoder.EncodeHash(TextBox2.Text);
                string requestString = GlobalSettings.Website_URL + "/loginpc.php?username=" + TextBox1.Text + "&password=" +hash;

                WC.DownloadStringCompleted += new DownloadStringCompletedEventHandler(WC_DownloadStringCompleted);
                WC.DownloadStringAsync(new Uri(requestString));
            }
            catch (Exception ex2)
            {
                DisplayLoginError("Could not login: " + ex2.ToString());
            }
        }

        void WC_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                switch (TextHandling.Parse(e.Result))
                {
                    case 0:
                        {
                            DisplayLoginError("User does not exist");
                            break;
                        }
                    case 1: // Login successful
                        {
                            Core.DisplayMainForm();
                            this.Hide();
                            break;
                        }
                    case 2:
                        {
                            DisplayLoginError("Wrong password!" + Environment.NewLine + Environment.NewLine + "If you are sure that you are using the correct password," +
                                Environment.NewLine + "please visit the forum. Your account might be banned or suspended due to any kind of infraction.");
                            break;
                        }
                    case 3:
                        {
                            DisplayLoginError("Unable to connect to database!");
                            break;
                        }
                    case 4:
                        {
                            DisplayLoginError("Could not find table!");
                            break;
                        }
                }
            }

            catch (Exception ex2)
            {
                DisplayLoginError("Could not login: " + ex2.ToString());
            }
        }

        private void DisplayLoginError(string reason)
        {
            MessageBox.Show(reason, "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(GlobalSettings.Website_URL);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm();
            form.ShowDialog();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
