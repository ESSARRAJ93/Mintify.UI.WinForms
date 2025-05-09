namespace Mintify.UI.WinForms.Demo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Mintify.UI.WinForms.Schemes.MintSchemeHelper mintSchemeHelper1 = new Mintify.UI.WinForms.Schemes.MintSchemeHelper();
            Mintify.UI.WinForms.Schemes.MintSchemeHelper mintSchemeHelper2 = new Mintify.UI.WinForms.Schemes.MintSchemeHelper();
            Mintify.UI.WinForms.Schemes.MintSchemeHelper mintSchemeHelper3 = new Mintify.UI.WinForms.Schemes.MintSchemeHelper();
            Mintify.UI.WinForms.Schemes.MintSchemeHelper mintSchemeHelper4 = new Mintify.UI.WinForms.Schemes.MintSchemeHelper();
            Mintify.UI.WinForms.Schemes.MintSchemeHelper mintSchemeHelper5 = new Mintify.UI.WinForms.Schemes.MintSchemeHelper();
            Mintify.UI.WinForms.Schemes.MintSchemeHelper mintSchemeHelper6 = new Mintify.UI.WinForms.Schemes.MintSchemeHelper();
            this.MntDark = new Mintify.UI.WinForms.Controls.MintLabel();
            this.MntLight = new Mintify.UI.WinForms.Controls.MintLabel();
            this.MntSwitch = new Mintify.UI.WinForms.Controls.MintSwitch();
            this.MntThemeProvider = new Mintify.UI.WinForms.Components.MintThemeProvider(this.components);
            this.SuspendLayout();
            // 
            // MntDark
            // 
            this.MntDark.BorderColor = System.Drawing.Color.Black;
            this.MntDark.BorderRadius = 5;
            this.MntDark.BorderThickness = 0;
            this.MntDark.Location = new System.Drawing.Point(10, 14);
            this.MntDark.Name = "MntDark";
            this.MntDark.Size = new System.Drawing.Size(36, 18);
            this.MntDark.TabIndex = 5;
            this.MntDark.Text = "Dark";
            this.MntDark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MntDark.ThemeProvider = null;
            // 
            // MntLight
            // 
            this.MntLight.BorderColor = System.Drawing.Color.Black;
            this.MntLight.BorderRadius = 5;
            this.MntLight.BorderThickness = 0;
            this.MntLight.Location = new System.Drawing.Point(107, 14);
            this.MntLight.Name = "MntLight";
            this.MntLight.Size = new System.Drawing.Size(35, 18);
            this.MntLight.TabIndex = 4;
            this.MntLight.Text = "Light";
            this.MntLight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MntLight.ThemeProvider = null;
            // 
            // MntSwitch
            // 
            this.MntSwitch.BorderColor = System.Drawing.Color.Black;
            this.MntSwitch.BorderRadius = 0;
            this.MntSwitch.BorderThickness = 0;
            this.MntSwitch.Checked = false;
            mintSchemeHelper1.BackColor = System.Drawing.Color.Empty;
            mintSchemeHelper1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(180)))), ((int)(((byte)(137)))));
            mintSchemeHelper1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(180)))), ((int)(((byte)(137)))));
            mintSchemeHelper1.ForeColor = System.Drawing.Color.Empty;
            mintSchemeHelper1.SchemeFor = Mintify.UI.WinForms.Schemes.TargetScheme.Control;
            mintSchemeHelper1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MntSwitch.CheckedSwitchColor = mintSchemeHelper1;
            mintSchemeHelper2.BackColor = System.Drawing.Color.Empty;
            mintSchemeHelper2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(180)))), ((int)(((byte)(137)))));
            mintSchemeHelper2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            mintSchemeHelper2.ForeColor = System.Drawing.Color.Empty;
            mintSchemeHelper2.SchemeFor = Mintify.UI.WinForms.Schemes.TargetScheme.Control;
            mintSchemeHelper2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MntSwitch.CheckedToggleColor = mintSchemeHelper2;
            this.MntSwitch.Location = new System.Drawing.Point(52, 12);
            this.MntSwitch.Name = "MntSwitch";
            this.MntSwitch.Size = new System.Drawing.Size(49, 22);
            this.MntSwitch.TabIndex = 3;
            this.MntSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MntSwitch.ThemeProvider = null;
            mintSchemeHelper3.BackColor = System.Drawing.Color.Empty;
            mintSchemeHelper3.BorderColor = System.Drawing.Color.Gray;
            mintSchemeHelper3.FillColor = System.Drawing.Color.Transparent;
            mintSchemeHelper3.ForeColor = System.Drawing.Color.Empty;
            mintSchemeHelper3.SchemeFor = Mintify.UI.WinForms.Schemes.TargetScheme.Control;
            mintSchemeHelper3.TextColor = System.Drawing.Color.White;
            this.MntSwitch.UncheckedSwitchColor = mintSchemeHelper3;
            mintSchemeHelper4.BackColor = System.Drawing.Color.Empty;
            mintSchemeHelper4.BorderColor = System.Drawing.Color.Gray;
            mintSchemeHelper4.FillColor = System.Drawing.Color.Gray;
            mintSchemeHelper4.ForeColor = System.Drawing.Color.Empty;
            mintSchemeHelper4.SchemeFor = Mintify.UI.WinForms.Schemes.TargetScheme.Control;
            mintSchemeHelper4.TextColor = System.Drawing.Color.White;
            this.MntSwitch.UncheckedToggleColor = mintSchemeHelper4;
            this.MntSwitch.CheckedChanged += new System.EventHandler(this.MntSwitch_CheckedChanged);
            // 
            // MntThemeProvider
            // 
            mintSchemeHelper5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            mintSchemeHelper5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            mintSchemeHelper5.FillColor = System.Drawing.Color.Empty;
            mintSchemeHelper5.ForeColor = System.Drawing.Color.White;
            mintSchemeHelper5.SchemeFor = Mintify.UI.WinForms.Schemes.TargetScheme.Form;
            mintSchemeHelper5.TextColor = System.Drawing.Color.Empty;
            this.MntThemeProvider.DarkTheme = mintSchemeHelper5;
            mintSchemeHelper6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            mintSchemeHelper6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            mintSchemeHelper6.FillColor = System.Drawing.Color.Empty;
            mintSchemeHelper6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            mintSchemeHelper6.SchemeFor = Mintify.UI.WinForms.Schemes.TargetScheme.Form;
            mintSchemeHelper6.TextColor = System.Drawing.Color.Empty;
            this.MntThemeProvider.LightTheme = mintSchemeHelper6;
            this.MntThemeProvider.TargetForm = this;
            this.MntThemeProvider.Theme = Mintify.UI.WinForms.Schemes.ThemeMode.Light;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MntDark);
            this.Controls.Add(this.MntLight);
            this.Controls.Add(this.MntSwitch);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Components.MintThemeProvider MntThemeProvider;
        private Controls.MintSwitch MntSwitch;
        private Controls.MintLabel MntDark;
        private Controls.MintLabel MntLight;
    }
}