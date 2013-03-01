using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LPO.GameRuntimeCheck;

namespace LPO.Global
{
    class GlobalSettings
    {
        //internal static string Website_URL = "http://esagameractest.byethost12.com";
        internal static string Website_URL = "http://strikker.org/wallet";
        internal static string FTPHost = "ftp://ftp.esagameractest.bugs3.com/esatest"; //used for autoupdate only.
        internal static string FTPUser = "u572093037.esatest"; //used for autoupdate only.
        internal static string FTPPass = "oliver"; //used for autoupdate only.
        internal static string RequestHost = "192.168.5.132"; //used to communicate with main FileServer
        internal static string BackupRequestHost = "127.0.0.1";//used to communicate with backup FileServer
    }
}
