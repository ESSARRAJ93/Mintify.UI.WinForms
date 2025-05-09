using System;
using System.Windows.Forms;

namespace Mintify.UI.WinForms.Demo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MntThemeProvider.LoadPreference();
            if(MntThemeProvider.Theme == Schemes.ThemeMode.Dark)
                MntSwitch.Checked = true;
            else MntSwitch.Checked = false;

        }

        private void MntMode_Click(object sender, EventArgs e)
        {

        }

        private void MntSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (MntSwitch.Checked == true)
            {
                MntThemeProvider.Theme = Schemes.ThemeMode.Dark;
                MntThemeProvider.SavePreference();
            }
            else
            {
                MntThemeProvider.Theme = Schemes.ThemeMode.Light;
                MntThemeProvider.SavePreference();
            }
        }
    }
}
