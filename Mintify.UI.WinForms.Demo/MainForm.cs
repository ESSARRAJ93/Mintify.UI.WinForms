using System;
using System.Windows.Forms;
using Mintify.UI.WinForms.Controls;

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

        private void mintTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void mintTextBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mintTextBox2.Focus();
                mintTextBox2.Text = "Enter key pressed!";
                e.SuppressKeyPress = true; // Prevents the beep sound
            }
        }

        private void mintTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mintTextBox1.Focus();
                mintTextBox1.Text = "Enter key pressed!";
                e.SuppressKeyPress = true; // Prevents the beep sound
            }
        }
    }
}
