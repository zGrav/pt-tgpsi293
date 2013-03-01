using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows;
using System.Diagnostics;
using Microsoft.Win32;

namespace ESA_AC
{
    public partial class GameList : Form
    {
        public string gameChosen { get; set; }
        public string gameChosenExec { get; set; }
        public string matchID { get; set; }

        public GameList()
        {
            InitializeComponent();
            try
            {
                if (File.Exists("C:\\esagamerac\\chosengame.txt"))
                {
                    listBox1.SelectedItem = File.ReadAllText("C:\\esagamerac\\chosengame.txt");

                    gameChosen = File.ReadAllText("C:\\esagamerac\\chosengame.txt");
                    gameChosenExec = File.ReadAllText("C:\\esagamerac\\chosengameexec.txt");
                    matchID = File.ReadAllText("C:\\esagamerac\\matchid.txt");
                }
            }

            catch (FileNotFoundException) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            try
            {
                int temp = Convert.ToInt32(textBox1.Text);
                File.WriteAllText("C:\\esagamerac\\matchid.txt", textBox1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid value on Match ID");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            
            File.WriteAllText("C:\\esagamerac\\chosengame.txt", listBox1.SelectedItem.ToString());
            
            switch (listBox1.SelectedIndex)
            {
                case 0: File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", "steam://run/10");
                    break;

                case 1: File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", "steam://run/240");
                    break;

                case 2: File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", "steam://run/730");
                    break;

                case 3: File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", "steam://run/570");
                    break;

                case 4:
                    openFileDialog1.Filter = "fifa13.exe|fifa13.exe| Exe Files (.exe)|*.exe";
                    if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                        string fullPath = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                        string execName = openFileDialog1.SafeFileName;
                        File.WriteAllText("C:\\esagamerac\\chosengamefullexec.txt", fullPath);
                        File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", execName);
                    }
                        break;
                    
                case 5:
                    openFileDialog1.Filter = "lol.launcher.admin.exe|lol.launcher.admin.exe| Exe Files (.exe)|*.exe";
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string fullPath = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                        string execName = openFileDialog1.SafeFileName;
                        File.WriteAllText("C:\\esagamerac\\chosengamefullexec.txt", fullPath);
                        File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", execName);
                    }
                    break;

                case 6: File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", "steam://run/90002");
                    break;

                case 7:

                    string browser = string.Empty;
                    RegistryKey key = null;

            try
             {

            key = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);
            browser = key.GetValue(null).ToString().ToLower().Replace("\"", "");

            if (!browser.EndsWith("exe"))
                 {
                     browser = browser.Substring(0, browser.LastIndexOf(".exe")+4);
                 }

                }
                finally
                {

                if (key != null) key.Close();

                }

            if (browser.Contains("iexplore"))
            {
                browser = "iexplore.exe";
            }

            else if (browser.Contains("firefox"))
            {
                browser = "firefox.exe";
            }

            else if (browser.Contains("chrome"))
            {
                browser = "chrome.exe";
            }

                    File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", browser); 
                    File.WriteAllText("C:\\esagamerac\\chosengamefullexec.txt", browser);
                    break;

                case 8:
                    openFileDialog1.Filter = "ManiaPlanet.exe|ManiaPlanet.exe| Exe Files (.exe)|*.exe";
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string fullPath = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                        string execName = openFileDialog1.SafeFileName;
                        File.WriteAllText("C:\\esagamerac\\chosengamefullexec.txt", fullPath);
                        File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", execName);
                    }
                    break;

                case 9:
                    openFileDialog1.Filter = "StarCraft II.exe|StarCraft II.exe| Exe Files (.exe)|*.exe";
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string fullPath = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                        string execName = openFileDialog1.SafeFileName;
                        File.WriteAllText("C:\\esagamerac\\chosengamefullexec.txt", fullPath);
                        File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", execName);
                    }
                    break;

                case 10:
                    File.WriteAllText("C:\\esagamerac\\chosengameexec.txt", "steam://run/440");
                    break;

                default: MessageBox.Show("An error occurred.");
                    break;
            }

            try
            {
                gameChosen = File.ReadAllText("C:\\esagamerac\\chosengame.txt");
                gameChosenExec = File.ReadAllText("C:\\esagamerac\\chosengameexec.txt");
                matchID = File.ReadAllText("C:\\esagamerac\\matchid.txt");
            }

            catch (FileNotFoundException) { }

            this.Close();
        }
    }
}
