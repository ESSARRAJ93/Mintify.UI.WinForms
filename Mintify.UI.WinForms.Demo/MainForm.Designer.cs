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
            this.CkdThemeMode = new System.Windows.Forms.CheckBox();
            this.LblTheme = new System.Windows.Forms.Label();
            this.MntThemeProvider = new Mintify.UI.WinForms.Components.MintThemeProvider(this.components);
            this.SuspendLayout();
            // 
            // CkdThemeMode
            // 
            this.CkdThemeMode.AutoSize = true;
            this.CkdThemeMode.Location = new System.Drawing.Point(12, 12);
            this.CkdThemeMode.Name = "CkdThemeMode";
            this.CkdThemeMode.Size = new System.Drawing.Size(123, 20);
            this.CkdThemeMode.TabIndex = 0;
            this.CkdThemeMode.Text = "Current Theme :";
            this.CkdThemeMode.UseVisualStyleBackColor = true;
            this.CkdThemeMode.CheckedChanged += new System.EventHandler(this.CkdThemeMode_CheckedChanged);
            // 
            // LblTheme
            // 
            this.LblTheme.AutoSize = true;
            this.LblTheme.Location = new System.Drawing.Point(140, 14);
            this.LblTheme.Name = "LblTheme";
            this.LblTheme.Size = new System.Drawing.Size(44, 16);
            this.LblTheme.TabIndex = 1;
            this.LblTheme.Text = "label1";
            // 
            // MntThemeProvider
            // 
            mintSchemeHelper1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            mintSchemeHelper1.ForeColor = System.Drawing.Color.White;
            this.MntThemeProvider.DarkTheme = mintSchemeHelper1;
            mintSchemeHelper2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            mintSchemeHelper2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.MntThemeProvider.LightTheme = mintSchemeHelper2;
            this.MntThemeProvider.TargetForm = this;
            this.MntThemeProvider.Theme = Mintify.UI.WinForms.Schemes.ThemeMode.Light;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblTheme);
            this.Controls.Add(this.CkdThemeMode);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CkdThemeMode;
        private System.Windows.Forms.Label LblTheme;
        private Components.MintThemeProvider MntThemeProvider;
    }
}