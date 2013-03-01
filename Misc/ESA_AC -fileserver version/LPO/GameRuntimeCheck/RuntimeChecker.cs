using System;
using System.Diagnostics;
using System.IO;
using System.Timers;
using LPO.Global;
using LPO.Utillity;
using System.ComponentModel;
using System.Net;
using System.Collections.Generic;
using ESA_AC;
using System.Net.Sockets;
using System.Text;
using ESA_AC.GameRuntimeCheck;
using System.Reflection;
using System.Management;

namespace LPO.GameRuntimeCheck
{
    class RuntimeChecker
    {
        private ProcessWatchDog watcher;
        private Timer timer;
        private Timer gamerunningtimer;
        private string username;
        private string getGameExec = File.ReadAllText("C:\\esagamerac\\chosengameexec.txt");

        private ServerType type;
        internal event CheckerStoppedEvent OnStopped;

        public RuntimeChecker(ServerType type, string username)
        {
            this.type = type;
            this.username = username;

            RequestHelper.requestFolder(GetServerLocation(), "REQUEST GAME FOLDER ", username + "\\" + File.ReadAllText("C:\\esagamerac\\chosengame.txt"));

            if (Directory.Exists("c:\\esagamerac\\acscreens") == false)
                Directory.CreateDirectory("c:\\esagamerac\\acscreens");

            ProcessManagement.TriggerTaskmanager(false);
            Process[] processlist = null;
            processlist = System.Diagnostics.Process.GetProcesses();

            GameReport report = new GameReport();
            string realtime = System.DateTime.Now.ToString();

            report.WriteLine("Anti Cheat Report: " + realtime.Remove(11) + "  " + DateTime.Now.TimeOfDay + Environment.NewLine);
            report.WriteLine("From user: " + username + "." + Environment.NewLine);
            report.WriteLine("User playing: " + File.ReadAllText("C:\\esagamerac\\chosengame.txt"));
            report.WriteLine("Match ID: " + File.ReadAllText("C:\\esagamerac\\matchid.txt"));

            foreach (Process proc_loopVariable in processlist)
            {
                report.WriteLine(proc_loopVariable.ProcessName + " " + proc_loopVariable.MainWindowTitle + Environment.NewLine);
            }

            File.WriteAllText("c:\\esagamerac\\ac_logbeforegame.txt", report.toFile());

            RequestHelper.uploadFile(GetServerLocation(), username, File.ReadAllText("C:\\esagamerac\\chosengame.txt"), "ac_logbeforegame.txt", "c:\\esagamerac\\ac_logbeforegame.txt");

            GameReport driverreport = new GameReport();

            driverreport.WriteLine("System drivers:");
            driverreport.WriteLine(Environment.NewLine);
 
            SelectQuery query = new SelectQuery("Win32_SystemDriver");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            foreach (ManagementObject ManageObject in searcher.Get())
                    {
                        driverreport.WriteLine("Path: " + ManageObject["PathName"].ToString());
                        driverreport.WriteLine("Description: " + ManageObject["Description"].ToString());
                        driverreport.WriteLine(Environment.NewLine);
            }

            File.WriteAllText("c:\\esagamerac\\driverreport_beforegame.txt", driverreport.toFile());

            RequestHelper.uploadFile(GetServerLocation(), username, File.ReadAllText("c:\\esagamerac\\chosengame.txt"), "driverreport_beforegame.txt", "c:\\esagamerac\\driverreport_beforegame.txt");

            using (ScreenshotDump screenpre = new ScreenshotDump())
            {
                int getTimepre = TextHandling.GetUnixTimestamp();
                
                try
                {
                    screenpre.SaveToFile("c:\\esagamerac\\acscreens\\" + "screen_beforegame_" + getTimepre + ".jpeg");

                    RequestHelper.uploadFile(GetServerLocation(), username, File.ReadAllText("C:\\esagamerac\\chosengame.txt"), "screen_beforegame_" + getTimepre + ".jpeg", "c:\\esagamerac\\acscreens\\" + "screen_beforegame_" + getTimepre + ".jpeg");
                }

                catch (Exception)
                {
                    File.WriteAllText("c:\\esagamerac\\acscreens\\captureerror_" + getTimepre + ".txt", "Failed to grab screenshot!");

                    RequestHelper.uploadFile(GetServerLocation(), username, File.ReadAllText("C:\\esagamerac\\chosengame.txt"), "captureerror_" + getTimepre + ".txt", "c:\\esagamerac\\acscreens\\captureerror_" + getTimepre + ".txt");
                }
            }

            //---timer---
            this.timer = new Timer()
            {
                AutoReset = true,
                Interval = 30000,
                Enabled = true
            };

            timer.Elapsed += tick;
            timer.Start();

            this.watcher = new ProcessWatchDog(1000);
            this.watcher.OnNewProcess += new NewProcessStartedEvent(watcher_OnNewProcess);

            this.gamerunningtimer = new Timer()
            {
                AutoReset = true,
                Interval = 5000,
                Enabled = true
            };

            gamerunningtimer.Elapsed += gametick;
            gamerunningtimer.Start();

          LaunchGame();
        }

        private void LaunchGame()
        {
            try
            {
                try
                {
                    bool notSteam = true;

                    if (type == ServerType.PrimaryServer)
                    {

                        if (getGameExec.Equals("steam://run/10"))
                        {
                            Process.Start("steam://run/10");
                            getGameExec = "hl.exe";
                            File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", "hl.exe");
                            notSteam = false;
                        }

                        else if (getGameExec.Equals("steam://run/90002"))
                        {
                            Process.Start("steam://run/90002");
                            getGameExec = "hl1";
                            File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", "hl.exe");
                            notSteam = false;
                        }

                        else if (getGameExec.Equals("steam://run/240"))
                        {
                            Process.Start("steam://run/240");
                            getGameExec = "hl2.exe";
                            File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", "hl2.exe");
                            notSteam = false;
                        }

                        else  if (getGameExec.Equals("steam://run/440"))
                        {
                            Process.Start("steam://run/440");
                            getGameExec = "hl2.exe";
                            File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", "hl2.exe");
                            notSteam = false;
                        }

                        else if (getGameExec.Equals("steam://run/730"))
                        {
                            Process.Start("steam://run/730");
                            getGameExec = "csgo.exe";
                            File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", "csgo.exe");
                            notSteam = false;
                        }

                        else  if (getGameExec.Equals("steam://run/570"))
                        {
                            Process.Start("steam://run/570");
                            getGameExec = "dota2.exe";
                            File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", "dota2.exe");
                            notSteam = false;
                        }

                        else  if (notSteam == true)
                        {
                                string checkifBrowser;

                                checkifBrowser = File.ReadAllText("C:\\esagamerac\\chosengamefullexec.txt");

                                if (checkifBrowser.Contains("iexplore"))
                                {
                                    Process.Start("iexplore.exe", " http://quakelive.com");
                                }

                                if (checkifBrowser.Contains("firefox"))
                                {
                                    Process.Start("firefox.exe", " http://quakelive.com");
                                }

                                if (checkifBrowser.Contains("chrome"))
                                {
                                    Process.Start("chrome.exe", " http://quakelive.com");
                                }

                                if (checkifBrowser.Contains("firefox.exe") == false && checkifBrowser.Contains("chrome.exe") == false && checkifBrowser.Contains("iexplore.exe") == false)
                                {
                                    Process.Start(File.ReadAllText("C:\\esagamerac\\chosengamefullexec.txt"));
                                }
                        }
                    }
                }

                catch (Win32Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Game was not detected on this game path.");
                    CheckIfGameIsRunning();
                }

            }

            catch (IOException)
            {
                System.Windows.Forms.MessageBox.Show("Invalid or Non-Existant Game Path.");
                CheckIfGameIsRunning();
            }

        }

        internal static bool TaskManagerIsRunning()
        {
            Process[] processes = Process.GetProcessesByName("taskmgr");
            if (processes.Length > 0)
            {
                for (int i = 0; i < processes.Length; i++)
                {
                    processes[i].Kill();
                }

                return true;
            }

            return false;
        }

        internal static bool IsGameRunning(string process)
        {
            Process[] processes = Process.GetProcessesByName(process);
            if (processes.Length > 0)
            {
                for (int i = 0; i < processes.Length; i++)
                {
                    processes[i].Kill();
                }

                return true;
            }

            return false;
        }

        private void Execute()
        {
            try
            {
                string username = File.ReadAllText("c:\\esagamerac\\myusername.txt");

                Process[] processlist = System.Diagnostics.Process.GetProcesses();
                
                GameReport report = new GameReport();
                report.WriteLine("Anti Cheat Report: " + DateTime.Now.ToString().Remove(11) + "  " + DateTime.Now.TimeOfDay + Environment.NewLine);
                report.WriteLine("From user: " + username + "." + Environment.NewLine);
                report.WriteLine("User is playing: " + File.ReadAllText("C:\\esagamerac\\chosengame.txt"));
                report.WriteLine("Match ID: " + File.ReadAllText("C:\\esagamerac\\matchid.txt"));

                foreach (Process process in processlist)
                {
                    report.WriteLine(process.ProcessName + " " + process.MainWindowTitle + Environment.NewLine);
                }

                int getTime = TextHandling.GetUnixTimestamp();

                File.WriteAllText("c:\\esagamerac\\" + "ac_log_" + getTime + ".txt", report.toFile());

                RequestHelper.uploadFile(GetServerLocation(), username, File.ReadAllText("C:\\esagamerac\\chosengame.txt"), "ac_log_" + getTime + ".txt", "c:\\esagamerac\\" + "ac_log_" + getTime + ".txt");

                GameReport driverreport = new GameReport();

                driverreport.WriteLine("System drivers:");
                driverreport.WriteLine(Environment.NewLine);

                SelectQuery query = new SelectQuery("Win32_SystemDriver");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                foreach (ManagementObject ManageObject in searcher.Get())
                {
                    driverreport.WriteLine("Path: " + ManageObject["PathName"].ToString());
                    driverreport.WriteLine("Description: " + ManageObject["Description"].ToString());
                    driverreport.WriteLine(Environment.NewLine);
                }

                File.WriteAllText("c:\\esagamerac\\driverreport_" + getTime + ".txt", driverreport.toFile());

                RequestHelper.uploadFile(GetServerLocation(), username, File.ReadAllText("c:\\esagamerac\\chosengame.txt"), "driverreport_" + getTime + ".txt", "c:\\esagamerac\\driverreport_" + getTime + ".txt");

                using (ScreenshotDump screen = new ScreenshotDump())
                {
                    int getTime2 = TextHandling.GetUnixTimestamp();

                    try
                    {
                        screen.SaveToFile("c:\\esagamerac\\acscreens\\" + "screen_" + getTime2 + ".jpeg");

                        RequestHelper.uploadFile(GetServerLocation(), username, File.ReadAllText("C:\\esagamerac\\chosengame.txt"), "screen_" + getTime2 + ".jpeg", "c:\\esagamerac\\acscreens\\" + "screen_" + getTime2 + ".jpeg");
                    }

                    catch (Exception)
                    {
                        File.WriteAllText("c:\\esagamerac\\acscreens\\captureerror_" + getTime2 + ".txt", "Failed to grab screenshot!");

                        RequestHelper.uploadFile(GetServerLocation(), username, File.ReadAllText("C:\\esagamerac\\chosengame.txt"), "captureerror_" + getTime2 + ".txt", "c:\\esagamerac\\acscreens\\captureerror_" + getTime2 + ".txt");
                    }
                }

                if (ProcessManagement.ProcessIsRunning("taskmgr.exe"))
                {
                    GameReport taskmgrReport = new GameReport();

                    taskmgrReport.WriteLine("Taskmgr opened while anticheat running for user " + username);

                    File.WriteAllText("C:\\esagamerac\\acscreens\\taskmgr.txt", taskmgrReport.toFile());

                    RequestHelper.uploadFile(GetServerLocation(), username, File.ReadAllText("C:\\esagamerac\\chosengame.txt"), "taskmgr.txt", "C:\\esagamerac\\acscreens\\taskmgr.txt");

                    TaskManagerIsRunning();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An error has occurred: " + Environment.NewLine +  ex.ToString());
            }
        }


        internal void tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            Execute();
        }

        internal void gametick(object sender, System.Timers.ElapsedEventArgs e)
        {
            CheckIfGameIsRunning();
        }

        internal void CheckIfGameIsRunning()
        {
            if (!ProcessManagement.ProcessIsRunning(File.ReadAllText("C:\\esagamerac\\chosengameexec.txt")))
            {
                ProcessManagement.TriggerTaskmanager(true);
                timer.Enabled = false;
                timer.Stop();

                gamerunningtimer.Enabled = false;
                gamerunningtimer.Stop();

                if (OnStopped != null)
                    OnStopped();
            }
        }

        private void watcher_OnNewProcess(int PID)
        {
            try {
            Process process = Process.GetProcessById(PID);

            GameReport report = new GameReport();
            report.WriteLine("New process started => " + process.ProcessName + " " + process.MainWindowTitle + " " + DateTime.Now.ToString() + Environment.NewLine);

            File.WriteAllText("c:\\esagamerac\\" + "newproc.txt", report.toFile());

            RequestHelper.uploadFile(GetServerLocation(), username, File.ReadAllText("C:\\esagamerac\\chosengame.txt"), "newproc.txt", "c:\\esagamerac\\newproc.txt");

                }
            catch (ArgumentException)
            {

            }
        }

        private string GetServerLocation()
        {
                if (type == ServerType.PrimaryServer)
                {
                    return GlobalSettings.RequestHost;
                }
                else if (type == ServerType.SecondaryServer)
                {
                    return GlobalSettings.BackupRequestHost;
                }

            throw new InvalidOperationException(); //Then the function is invalid when this is called
        }
    }

    enum ServerType
    {
        PrimaryServer = 1, // mainserver
        SecondaryServer = 2 //backupserver
    }

    delegate void CheckerStoppedEvent();
}
