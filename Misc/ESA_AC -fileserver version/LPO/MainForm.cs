using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using LPO.GameRuntimeCheck;
using LPO.Global;
using LPO.Utillity;
using ESA_AC;
using System.ComponentModel;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Net;
using ESA_AC.GameRuntimeCheck;

namespace LPO
{
    public partial class MainForm : Form
    {
        private string username;

        public MainForm()
        {
            InitializeComponent();

            FormClosed += new FormClosedEventHandler(MainForm_FormClosed);

            this.KeyPreview = true;

            try
            {
            username = File.ReadAllText("C:\\esagamerac\\myusername.txt");

            try
            {
                RequestHelper.requestFolder(GlobalSettings.RequestHost, "REQUEST USER FOLDER ", username);
            }

            catch (Exception)
            {
                try
                {
                    RequestHelper.requestFolder(GlobalSettings.BackupRequestHost, "REQUEST USER FOLDER ", username);
                }

                catch (Exception)
                {
                    MessageBox.Show("Failed to connect to servers. Program will now exit.");
                    string grabProc;
                    try {
                    grabProc = File.ReadAllText("c:\\esagamerac\\chosengameexec.txt");
                    grabProc = grabProc.Substring(0, grabProc.Length - 4);

                    RuntimeChecker.IsGameRunning(grabProc); }
                    catch (Exception) {}
                    Environment.Exit(0);
                }
            }

            if (Directory.Exists("c:\\esagamerac\\acscreens") == false)
            {
                Directory.CreateDirectory("c:\\esagamerac\\acscreens");
            }

            ToolStripLabel3.Text = "Welcome, " + username + "!";

                if (ProcessManagement.ProcessIsRunning(File.ReadAllText("C:\\esagamerac\\chosengameexec.txt")))
                {
                    GameReport report = new GameReport();
                    report.WriteLine("Anticheat closed while game was running! " + DateTime.Now.ToString());

                    File.WriteAllText("C:\\esagamerac\\acscreens\\gameclosed.txt", report.toFile());

                    try
                    {
                        RequestHelper.uploadFile(GlobalSettings.RequestHost, username, File.ReadAllText("C:\\esagamerac\\chosengame.txt"), "game_closed.txt", "C:\\esagamerac\\acscreens\\gameclosed.txt");
                    }

                    catch (Exception)
                    {
                        try
                        {
                            RequestHelper.uploadFile(GlobalSettings.BackupRequestHost, username, File.ReadAllText("C:\\esagamerac\\chosengame.txt"), "game_closed.txt", "C:\\esagamerac\\acscreens\\gameclosed.txt");
                        }

                        catch (Exception) { }
                    }

                }

            }
            catch (FileNotFoundException) { }

        }

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ProcessManagement.TriggerTaskmanager(true);
                notifyIcon1.Visible = false;
                Environment.Exit(0);
            }
            catch (Exception)
            {
                Environment.Exit(0);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            GameList showGames = new GameList();
            dr = showGames.ShowDialog();

            if (dr == DialogResult.Cancel)
            {
                MessageBox.Show("Game Launch canceled.");
            }

            else if (dr == DialogResult.OK)
            {
                string grabName;
                grabName = File.ReadAllText("C:\\esagamerac\\chosengameexec.txt");

                if (grabName.Equals("steam://run/10"))
                {
                    grabName = "hl.exe";
                }

                else if (grabName.Equals("steam://run/90002"))
                {
                    grabName = "hl.exe";
                }

                else if (grabName.Equals("steam://run/240"))
                {
                    grabName = "hl2.exe";
                }

                else if (grabName.Equals("steam://run/440"))
                {
                    grabName = "hl2.exe";
                }

                else if (grabName.Equals("steam://run/730"))
                {
                    grabName = "csgo.exe";
                }

                else if (grabName.Equals("steam://run/570"))
                {
                    grabName = "dota2.exe";
                }

                if (ProcessManagement.ProcessIsRunning(grabName))
                {
                    grabName = grabName.Substring(0, grabName.Length - 4);
                    RuntimeChecker.IsGameRunning(grabName); //kills old process and opens new one with anticheat
                    ProcessManagement.TriggerTaskmanager(true);
                    Thread.Sleep(1000);
                }

                bool primaryFail = false;
                bool secondaryFail = false;

                try
                {
                    label3.Text = "Game is running!";
                    RuntimeChecker checker = new RuntimeChecker(ServerType.PrimaryServer, username);
                    checker.OnStopped += new CheckerStoppedEvent(checker_OnStopped);
                }
                catch (Exception)
                {
                    primaryFail = true;
                }

                if (primaryFail == true)
                {
                    try
                    {
                        label3.Text = "Game is running!";
                        RuntimeChecker checker = new RuntimeChecker(ServerType.SecondaryServer, username);
                        checker.OnStopped += new CheckerStoppedEvent(checker_OnStopped);
                    }
                    catch (Exception)
                    {
                        secondaryFail = true;
                    }
                }

                if (primaryFail == true && secondaryFail == true)
                {
                    MessageBox.Show("Both servers have failed to stay alive.");
                    checker_OnStopped();

                    string grabProc;
                    grabProc = grabName;
                    grabProc = grabProc.Substring(0, grabProc.Length - 4);

                    RuntimeChecker.IsGameRunning(grabProc);
                    
                }
            }
        }

        private void checker_OnStopped()
        {
            CheckForIllegalCrossThreadCalls = false;
            label3.Text = "Game is NOT running!";
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("http://esagamer.com");
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            ReportForm rpt = new ReportForm();
            rpt.ShowDialog();
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }
           //updater code

            //string currentMD5 = null;
            //string updatedMD5 = null;
            //FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create("ftp://78.110.169.171/78.110.169.171_14240/ac/" + "ac.exe.newver");
            //ftp.Credentials = new NetworkCredential("spiteful", "LPOcssSV2012");
            //ftp.KeepAlive = false;
            //ftp.UseBinary = true;
            //ftp.Method = WebRequestMethods.Ftp.DownloadFile;
            //using (FtpWebResponse FtpResponse = (FtpWebResponse)ftp.GetResponse())
            //{
            //    using (System.IO.Stream ResponseStream = FtpResponse.GetResponseStream())
            //    {

            //        using (System.IO.FileStream fs = new System.IO.FileStream("C:\\ac_updated.exe", FileMode.Create))
            //        {
            //            byte[] buffer = new byte[2048];
            //            int read = 0;
            //            do
            //            {
            //                read = ResponseStream.Read(buffer, 0, buffer.Length);
            //                fs.Write(buffer, 0, read);
            //            } while (read != 0);
            //            ResponseStream.Close();
            //            fs.Flush();
            //            fs.Close();
            //        }
            //        ResponseStream.Close();

            //    }
            //}

            ////lolcode ftw
            //currentMD5 = Core.MD5Encoder.EncodeHashFromFile(Application.ExecutablePath);
            //updatedMD5 = Core.MD5Encoder.EncodeHashFromFile("c:\\ac_updated.exe");
            //if (currentMD5 != updatedMD5)
            //{
            //    if (MessageBox.Show("There is a update available, would you like to perform it?" + Environment.NewLine + "We remind you that playing with a outdated version will lead to a 3 day suspension.", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        File.Copy("c:\\ac_updated.exe", Application.StartupPath + "\\" + "ac_updated.exe");
            //        File.Delete("c:\\ac_updated.exe");
            //        MessageBox.Show("You can now run the updated version called ac_updated.exe and delete old version." + Environment.NewLine + "Please rename the ac_updated.exe to ac.exe or anything at your choice to avoid update bugs." + Environment.NewLine + "DO NOT DELETE THE .DLL OR ELSE YOU WILL NOT BE ABLE TO LOGIN.");
            //        Environment.Exit(0);
            //    }
            //    else
            //    {
            //        File.Delete("c:\\ac_updated.exe");
            //        Environment.Exit(0);
            //    }
            //}
            //else
            //{
            //    File.Delete("c:\\ac_updated.exe");
            //}


        private void MainForm_FormClosing(System.Object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            try
            {
                if (ProcessManagement.ProcessIsRunning(File.ReadAllText("C:\\esagamerac\\chosengameexec.txt")))
                {
                    GameReport report = new GameReport();
                    report.WriteLine("Anticheat closed while game was running!");

                    File.WriteAllText("C:\\esagamerac\\acscreens\\gameclosed.txt", report.toFile());

                    try
                    {
                        RequestHelper.uploadFile(GlobalSettings.RequestHost, username, File.ReadAllText("C:\\esagamerac\\chosengame.txt"), "game_closed.txt", "C:\\esagamerac\\acscreens\\gameclosed.txt");
                    }

                    catch (Exception)
                    {
                        try
                        {
                            RequestHelper.uploadFile(GlobalSettings.BackupRequestHost, username, File.ReadAllText("C:\\esagamerac\\chosengame.txt"), "game_closed.txt", "C:\\esagamerac\\acscreens\\gameclosed.txt");
                        }

                        catch (Exception) {}
                    }
                }
            }

            catch (FileNotFoundException) { }

            ProcessManagement.TriggerTaskmanager(true);

            notifyIcon1.Visible = false;
        }

        private void MainForm_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Alt == true & e.KeyCode == Keys.F4)
            {
                e.Handled = true;
            }
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Process.Start("http://esagamer.com");
        }

        private void launchGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                Button1.PerformClick();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;

            try
            {
                ProcessManagement.TriggerTaskmanager(true);
                Environment.Exit(0);
            }
            catch (Exception eeadsawd)
            {
                MessageBox.Show(eeadsawd.ToString());
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
            }
        }



    }
}
