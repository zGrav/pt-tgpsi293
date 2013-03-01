using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using LPO.Global;
using LPO.Utillity;
using System.Net.Sockets;
using System.Text;
using ESA_AC.GameRuntimeCheck;

namespace LPO
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            UpdateProgressStatus("Starting application...");

            if (Directory.Exists("c:\\esagamerac") == false)
            {
                Directory.CreateDirectory("C:\\esagamerac");
            }

            if (File.Exists(Application.StartupPath + "\\" + "ProcessHelper.dll") == false)
            {
                UpdateProgressStatus("Downloading files needed...");
                //MessageBox.Show("You're missing a crucial DLL file, program will now download the missing file.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //To-do: Convert to async and make form that displays the progress
                try
                {
                    FtpWebRequest ftp2 = (FtpWebRequest)FtpWebRequest.Create(GlobalSettings.FTPHost + "/" + "update" + "/" + "ProcessHelper.dll"); //todo
                    ftp2.Credentials = new NetworkCredential(GlobalSettings.FTPUser, GlobalSettings.FTPPass);
                    ftp2.KeepAlive = false;
                    ftp2.UseBinary = true;
                    ftp2.Method = WebRequestMethods.Ftp.DownloadFile;
                    ftp2.BeginGetResponse(new AsyncCallback(GotFTPStram), ftp2);
                }

                catch (WebException)
                {
                    MessageBox.Show("Cannot download required files! Program terminating.");
                    Application.Exit();
                }
            }
            else
            {
                ContinueApplicationstartup();
            }
        }

        private void UpdateDllFiles()
        {
            if (File.Exists(Application.StartupPath + "\\" + "ProcessHelper.dll"))
            {
                File.Delete(Application.StartupPath + "\\" + "ProcessHelper.dll");
            }

            File.Copy("c:\\ProcessHelper.dll", Application.StartupPath + "\\" + "ProcessHelper.dll");
            File.Delete("c:\\ProcessHelper.dll");
            ContinueApplicationstartup();
        }


        private void GotFTPStram(IAsyncResult iAr)
        {
            UpdateProgressStatus("Installing files...");
            FtpWebRequest requestHandle = (FtpWebRequest)iAr.AsyncState;
            using (WebResponse response = requestHandle.EndGetResponse(iAr))
            {
                using (System.IO.Stream ResponseStream2 = response.GetResponseStream())
                {
                    using (System.IO.FileStream fs2 = new System.IO.FileStream("C:\\ProcessHelper.dll", FileMode.Create))
                    {
                        byte[] buffer2 = new byte[2048];
                        int read2 = 0;
                        do
                        {
                            read2 = ResponseStream2.Read(buffer2, 0, buffer2.Length);
                            fs2.Write(buffer2, 0, read2);
                        } while (!(read2 == 0));
                        ResponseStream2.Close();
                        fs2.Flush();
                        fs2.Close();
                    }

                    ResponseStream2.Close();
                }
            }

            UpdateDllFiles();
        }

        private void ContinueApplicationstartup()
        {
            UpdateProgressStatus("Starting application...");
            string username = string.Empty;
            if (File.Exists("C:\\esagamerac\\myusername.txt"))
            {
                username = File.ReadAllText("C:\\esagamerac\\myusername.txt");
            }

            try
            {
                if (ProcessManagement.ProcessIsRunning(File.ReadAllText("C:\\esagamerac\\chosengameexec.txt")))
                {
                    string filename = "C:\\esagamerac\\acscreens\\gameclosed.txt";
                    System.IO.StreamWriter objWriter = new System.IO.StreamWriter(filename);
                    string realtime = System.DateTime.Now.ToString();
                    objWriter.WriteLine("Anticheat closed while game was running!" + DateTime.Now);
                    objWriter.Close();

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

            catch (Exception) { }

            UpdateProgressStatus("Checking for updates..");
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(GlobalSettings.FTPHost + "/" + "update" + "/" + "ac.exe.newver"); //todo
            ftp.Credentials = new NetworkCredential(GlobalSettings.FTPUser, GlobalSettings.FTPPass);
            ftp.KeepAlive = false;
            ftp.UseBinary = true;
            ftp.Method = WebRequestMethods.Ftp.DownloadFile;
            ftp.BeginGetResponse(GotFTPUpdateResponse, ftp);
        }

        private void GotFTPUpdateResponse(IAsyncResult iar)
        {
            UpdateProgressStatus("Installing updates...");
            try
            {
                FtpWebRequest requestHandle = (FtpWebRequest)iar.AsyncState;

                using (WebResponse FtpResponse = requestHandle.EndGetResponse(iar))
                {
                    using (System.IO.Stream ResponseStream = FtpResponse.GetResponseStream())
                    {

                        using (System.IO.FileStream fs = new System.IO.FileStream("C:\\ac_updated.exe", FileMode.Create))
                        {
                            byte[] buffer = new byte[2048];
                            int read = 0;
                            do
                            {
                                read = ResponseStream.Read(buffer, 0, buffer.Length);
                                fs.Write(buffer, 0, read);
                            } while (read != 0);
                            ResponseStream.Close();
                            fs.Flush();
                            fs.Close();
                        }
                        ResponseStream.Close();

                    }
                }
            }
            catch (WebException)
            {
               // MessageBox.Show("Cannot download required files! Program terminating.");
                
            }

            UpdateProgressStatus("Checking files...");

            //autoupdate code
            
            //string lul = null;
            //string lulupdate = null;
            ////lolcode ftw
            //lul = Core.MD5Encoder.EncodeHashFromFile(Application.ExecutablePath);
            //lulupdate = Core.MD5Encoder.EncodeHashFromFile("c:\\ac_updated.exe");
            //if (lul != lulupdate)
            //{
            //    if (MessageBox.Show("There is a update available, would you like to perform it?" + Environment.NewLine + "We remind you that playing with a outdated version will lead to a 3 day suspension.", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        File.Copy("c:\\ac_updated.exe", Application.StartupPath + "\\" + "ac_updated.exe");
            //        File.Delete("c:\\ac_updated.exe");
            //        MessageBox.Show("You can now run the updated version called ac_updated.exe and delete old version." + Environment.NewLine + "Please rename the ac_updated.exe to ac.exe or anything at your choice to avoid update bugs." + Environment.NewLine + "DO NOT DELETE THE .DLL OR ELSE YOU WILL NOT BE ABLE TO LOGIN.");
            //        Environment.Exit(0);
            //    }
            //    else //if (!System.Diagnostics.Debugger.IsAttached)
            //    {
            //        File.Delete("c:\\ac_updated.exe");
            //        Environment.Exit(0);
            //    }

            //}
            //else
            //{
                if (File.Exists("c:\\ac_updated.exe")) {
                File.Delete("c:\\ac_updated.exe");
                }
                //MessageBox.Show("No update available at the moment.");
            //}

            ShowMainFormCallback callback = new ShowMainFormCallback(ShowMainForm);
            this.BeginInvoke(callback, new object[] { });
        }

        delegate void ShowMainFormCallback();

        delegate void UpdateProgressStatusCallback(string text);

        private void ShowMainForm()
        {
            Core.DisplayLoginForm();
            this.Hide();
        }

        private void UpdateProgressStatus(string text)
        {
            if (InvokeRequired)
            {
                UpdateProgressStatusCallback d = new UpdateProgressStatusCallback(UpdateProgressStatus);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                label1.Text = text;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
