using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AS2_Tracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm parent = new MainForm();
            Application.Run(parent);

            SetStartup(); // Add app to startup registry if it's not already
            UpdateHandler.InstallUpdateSyncWithInfo(parent); // Check for updates
        }

        static void SetStartup()
        {
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (Properties.Settings.Default.startRegistryExists != true
                && Properties.Settings.Default.shouldRunOnStartup == true)
            {
                registry.SetValue("AS2_Tracker", Application.ExecutablePath.ToString());
                Properties.Settings.Default.startRegistryExists = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                if (registry != null && Properties.Settings.Default.shouldRunOnStartup != true)
                {
                    registry.DeleteValue("AS2_Tracker", false);
                }
            }
        }
    }
}
