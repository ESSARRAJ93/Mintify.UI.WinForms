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
            {
                CkdThemeMode.Checked = true;
                MntMode.Text = "Dark Theme";
            }
            else
            {
                CkdThemeMode.Checked = false;
                MntMode.Text = "Light Theme";
            }
        }

        private void CkdThemeMode_CheckedChanged(object sender, EventArgs e)
        {
            //CkdThemeMode.Checked = !CkdThemeMode.Checked;
            
            if (CkdThemeMode.Checked)
            {
                MntThemeProvider.Theme = Schemes.ThemeMode.Dark;
                MntThemeProvider.SavePreference();
                MntMode.Text = "Dark Theme";
            }
            else
            {
                MntThemeProvider.Theme = Schemes.ThemeMode.Light;
                MntThemeProvider.SavePreference();
                MntMode.Text = "Light Theme";
            }
        }

        private void MntMode_Click(object sender, EventArgs e)
        {

        }
    }
}
