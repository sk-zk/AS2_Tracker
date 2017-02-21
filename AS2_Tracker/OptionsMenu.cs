using System;
using System.Windows.Forms;
using System.IO;

namespace AS2_Tracker
{
    public partial class OptionsMenu : Form
    {
        /*
        Construct the form
        */
        private MainForm parent;
        public OptionsMenu(MainForm ParentForm)
        {
            InitializeComponent();

            parent = ParentForm; // Set the parent form
            userSelectedFilePath = Properties.Settings.Default.outputPath; // Set the selected path to the setting
        }

        /*
        File dialog logic
        */
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Log files | *.log";

			dialog.InitialDirectory = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
				"unity3d/Audiosurf, LLC/Audiosurf 2/");

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                userSelectedFilePath = dialog.FileName;

                Properties.Settings.Default.outputPath = dialog.FileName;
                Properties.Settings.Default.Save();
				Properties.Settings.Default.Upgrade();

                if (!parent.loadFileToolStripMenuItem.Enabled)
                    parent.loadFileToolStripMenuItem.Enabled = true;
            }
        }

        public string userSelectedFilePath
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //text change logic goes here
        }

        private void shouldStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (!shouldStartup.Checked)
            {
                Properties.Settings.Default.shouldRunOnStartup = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.shouldRunOnStartup = true;
                Properties.Settings.Default.Save();
            }
        }

        private void shouldTrayNotify_CheckedChanged(object sender, EventArgs e)
        {
            if (!shouldTrayNotify.Checked)
            {
                Properties.Settings.Default.shouldTrayNotify = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.shouldTrayNotify = true;
                Properties.Settings.Default.Save();
            }
        }

        private void OptionsMenu_Shown(object sender, EventArgs e)
        {
            shouldTrayNotify.Checked = Properties.Settings.Default.shouldTrayNotify;
            shouldStartup.Checked = Properties.Settings.Default.shouldRunOnStartup;
        }
    }
}
