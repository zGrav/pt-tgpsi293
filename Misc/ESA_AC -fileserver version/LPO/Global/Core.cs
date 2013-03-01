using System.Windows.Forms;
using LPO.Cryptography;
using LPO.Cryptography.ComputerID;
using LPO.Utillity;
using System;

namespace LPO.Global
{
    class Core
    {
        internal static MD5CryptoService MD5Encoder;

        private static string computerHardwareID;

        internal static string ComputerHWID
        {
            get
            {
                return computerHardwareID;
            }
        }

        public static void Initialize()
        {
            try
            {
                MD5Encoder = new MD5CryptoService();

                string hwid = ComputerIDFactory.GenerateComputerID();
                computerHardwareID = MD5Encoder.EncodeHash(hwid);
                ProcessManagement.TriggerTaskmanager(true);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoadingForm());
            }
            catch (Exception) { }
        }

        internal static void DisplayLoginForm()
        {
            DisplayForm(new LoginForm());
        }

        internal static void DisplayRegisterForm()
        {
            DisplayForm(new RegisterForm());
        }

        internal static void DisplayReportForm()
        {
            DisplayForm(new ReportForm());
        }

        internal static void DisplayMainForm()
        {
            DisplayForm(new MainForm());
        }

        private static void DisplayForm(Form form)
        {
            form.Show();
        }



    }
}
