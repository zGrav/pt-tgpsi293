using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using LPO.Global;
using LPO.Utillity;
using System.Net.Mail;

namespace LPO
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text != null && TextBox1.Text != null)
            {
                if (string.IsNullOrEmpty(TextBox1.Text)|| string.IsNullOrEmpty(TextBox2.Text) || TextBox1.Text == " " || TextBox2.Text == " " || string.IsNullOrEmpty(TextBox3.Text) || TextBox3.Text == " ")
                {
                    DisplayRegisterError("Not enough data to continue the registry!");
                    return;
                }

                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GlobalSettings.Website_URL + "/register.php");
                    
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    string Post = ("username=" + TextBox1.Text + "&password=" + Core.MD5Encoder.EncodeHash(TextBox2.Text) + "&hwid=" + Core.ComputerHWID);
                    byte[] byteArray = Encoding.UTF8.GetBytes(Post);
                    request.ContentLength = byteArray.Length;
                    Stream DataStream = request.GetRequestStream();
                    DataStream.Write(byteArray, 0, byteArray.Length);
                    DataStream.Close();
                    WebResponse Response = request.GetResponse();
                    DataStream = Response.GetResponseStream();
                    StreamReader reader = new StreamReader(DataStream);
                    string ServerResponse = reader.ReadToEnd();
                    reader.Close();
                    DataStream.Close();
                    Response.Close();


                    System.Net.WebClient getip = new System.Net.WebClient();
                    string ip = getip.DownloadString("http://automation.whatismyip.com/n09230945.asp");

                    string password = TextBox2.Text;

                    string email = TextBox3.Text;

                    
                    MailMessage Mail = new MailMessage();
                    Mail.Subject = "Register Form - New Client Registered, " + TextBox1.Text + " .";
                    Mail.To.Add("lulwutpt@googlemail.com");
                    Mail.From = new MailAddress("lulwutpt@googlemail.com");
                    Mail.Body = "The user with the username: " + TextBox1.Text + " and the e-mail: " + email + " just registered with the password " + Core.MD5Encoder.EncodeHash(password) + "." + " | Registered in a PC with HWID= " + Core.ComputerHWID + " and the IP= " + ip;

                    SmtpClient SMTP = new SmtpClient("smtp.gmail.com");
                    SMTP.EnableSsl = true;
                    SMTP.Credentials = new System.Net.NetworkCredential("lulwutpt", "123456oldacc");
                    SMTP.Port = 587;
                    SMTP.Send(Mail);

                    string lul = ServerResponse;

                   // lul = lul.Substring(0, lul.Length - 154);

                    switch (TextHandling.Parse(lul))
                    {
                        case 0:
                            DisplayRegisterError("No data to register!");
                            break;
                        case 1:
                            DisplayRegisterError("Registered!");
                            break;
                        case 2:
                            DisplayRegisterError("User already exist!");
                            break;
                        case 3:
                            DisplayRegisterError("Unable to connect to database!");
                            break;
                    }
                }
                catch
                {
                    DisplayRegisterError("Could not connect to server!");
                    return;
                }
            }
            else
            {
                DisplayRegisterError("No username and/or password!");
                return;
            }

            this.Close();
        }

        private void DisplayRegisterError(string message, bool success = false)
        {
            MessageBox.Show(message, "Register", MessageBoxButtons.OK, success ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(GlobalSettings.Website_URL);
        }
    }
}
