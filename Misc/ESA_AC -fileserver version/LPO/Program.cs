using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LPO.Global;
using LPO.Utillity;

namespace LPO
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            Core.Initialize();
        }
    }
}
