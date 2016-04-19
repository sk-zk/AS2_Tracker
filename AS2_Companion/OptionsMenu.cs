using System;
using System.Windows.Forms;

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

            dialog.Filter = "Text Files | *.txt";

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                userSelectedFilePath = dialog.FileName;

                Properties.Settings.Default.outputPath = dialog.FileName;
                Properties.Settings.Default.Save();

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
    }
}
