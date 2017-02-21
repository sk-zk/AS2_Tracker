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

        
        }

        
    }
}
