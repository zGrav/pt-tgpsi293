using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESA_AC.GameRuntimeCheck;

namespace ESA_FileServer_Stresstest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int countU; //user
        int countG; //game
        int countB; //both
        int countF; //files

        private void button1_Click(object sender, EventArgs e)
        {
            countU = 0;

            while (countU != 100)
            {
                RequestHelper.requestFolder("192.168.5.132", "REQUEST USER FOLDER ", "user" + countU);
                countU++;
            }

      }

        private void button2_Click(object sender, EventArgs e)
        {
            countG = 0;

            while (countG != 100)
            {
                RequestHelper.requestFolder("192.168.1.3", "REQUEST GAME FOLDER ", "user" + countG + "/" + "game" + countG);
                countG++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            countB = 0;

            while (countB != 100)
            {
                RequestHelper.requestFolder("192.168.1.3", "REQUEST USER FOLDER ", "user" + countB);
                RequestHelper.requestFolder("192.168.1.3", "REQUEST GAME FOLDER ", "user" + countB + "/" + "game" + countB);
                countB++;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RequestHelper.requestFolder("192.168.1.3", "REQUEST USER FOLDER ", "stress");
            RequestHelper.requestFolder("192.168.1.3", "REQUEST GAME FOLDER ", "stress" + "/" + "test");

            

            countF = 0;

            while (countF != 100)
            {
                File.WriteAllText("c:\\test_" + countF + ".txt", "stresstest!");

                RequestHelper.uploadFile("192.168.1.3", "stress", "test", "test_" + countF + ".txt", "c:\\test_" + countF + ".txt");

                countF++;
            }
        }
    }
}
