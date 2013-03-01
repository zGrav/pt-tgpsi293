using Microsoft.Win32;
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace LPO.Utillity
{
    class ProcessManagement
    {
        internal static unsafe bool ProcessIsRunning(string processName)
        {
            fixed (char* namePtr = processName)
            {
                return (NativeProcessHelper.Helper.ContainsProcess(namePtr) == 1);
            }
        }

        internal static void TriggerTaskmanager(bool enable)
        {
            try
            {
                RegistryKey systemRegistry = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");

                systemRegistry.SetValue("DisableTaskMgr", enable ? 0 : 1);
                systemRegistry.Close();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You need to run this program with administrator privileges to be able to use it.", "Application error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
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
    }
}
