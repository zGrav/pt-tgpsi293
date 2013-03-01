using System;
using System.Net.Mail;
using System.Windows.Forms;
using LPO.Global;

namespace LPO
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            System.Net.WebClient getip = new System.Net.WebClient();
            string ip = getip.DownloadString("http://automation.whatismyip.com/n09230945.asp"); //Recode in async + exceptionhandling


            //to-do: Recode this in async, the code should be pushed to a HTTP POST form request
            MailMessage Mail = new MailMessage();
            Mail.Subject = "Report Tool - Cheat Report";
            Mail.To.Add("lulwutpt@googlemail.com");
            Mail.From = new MailAddress("lulwutpt@googlemail.com");
            Mail.Body = RichTextBox1.Text + " | Message sent from PC with HWID= " + Core.ComputerHWID + " And from IP= " + ip;

            SmtpClient SMTP = new SmtpClient("smtp.gmail.com");
            SMTP.EnableSsl = true;
            SMTP.Credentials = new System.Net.NetworkCredential("lulwutpt", "123456oldacc");
            SMTP.Port = 587;
            SMTP.Send(Mail);

            MessageBox.Show("Report has been sent");
            this.Hide();
        }
    }
}
