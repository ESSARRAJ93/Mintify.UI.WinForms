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
                LblTheme.Text = "Dark Theme";
            }
            else
            {
                CkdThemeMode.Checked = false;
                LblTheme.Text = "Light Theme";
            }
        }

        private void CkdThemeMode_CheckedChanged(object sender, EventArgs e)
        {
            //CkdThemeMode.Checked = !CkdThemeMode.Checked;
            
            if (CkdThemeMode.Checked)
            {
                MntThemeProvider.Theme = Schemes.ThemeMode.Dark;
                MntThemeProvider.SavePreference();
                LblTheme.Text = "Dark Theme";
            }
            else
            {
                MntThemeProvider.Theme = Schemes.ThemeMode.Light;
                MntThemeProvider.SavePreference();
                LblTheme.Text = "Light Theme";
            }
        }
    }
}
