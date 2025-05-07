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
            this.MntThemeProvider = new Mintify.UI.WinForms.Components.MintThemeProvider(this.components);
            this.MntMode = new Mintify.UI.WinForms.Controls.MintLabel();
            this.SuspendLayout();
            // 
            // CkdThemeMode
            // 
            this.CkdThemeMode.AutoSize = true;
            this.CkdThemeMode.Location = new System.Drawing.Point(12, 17);
            this.CkdThemeMode.Name = "CkdThemeMode";
            this.CkdThemeMode.Size = new System.Drawing.Size(123, 20);
            this.CkdThemeMode.TabIndex = 0;
            this.CkdThemeMode.Text = "Current Theme :";
            this.CkdThemeMode.UseVisualStyleBackColor = true;
            this.CkdThemeMode.CheckedChanged += new System.EventHandler(this.CkdThemeMode_CheckedChanged);
            // 
            // MntThemeProvider
            // 
            mintSchemeHelper1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            mintSchemeHelper1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            mintSchemeHelper1.FillColor = System.Drawing.Color.Empty;
            mintSchemeHelper1.ForeColor = System.Drawing.Color.White;
            mintSchemeHelper1.TextColor = System.Drawing.Color.Empty;
            this.MntThemeProvider.DarkTheme = mintSchemeHelper1;
            mintSchemeHelper2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            mintSchemeHelper2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            mintSchemeHelper2.FillColor = System.Drawing.Color.Empty;
            mintSchemeHelper2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            mintSchemeHelper2.TextColor = System.Drawing.Color.Empty;
            this.MntThemeProvider.LightTheme = mintSchemeHelper2;
            this.MntThemeProvider.TargetForm = this;
            this.MntThemeProvider.Theme = Mintify.UI.WinForms.Schemes.ThemeMode.Light;
            // 
            // MntMode
            // 
            this.MntMode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.MntMode.BorderRadius = 0;
            this.MntMode.BorderThickness = 0;
            this.MntMode.Location = new System.Drawing.Point(150, 12);
            this.MntMode.Name = "MntMode";
            this.MntMode.Padding = new System.Windows.Forms.Padding(5);
            this.MntMode.Size = new System.Drawing.Size(82, 28);
            this.MntMode.TabIndex = 2;
            this.MntMode.Text = "mintLabel1";
            this.MntMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MntMode.ThemeProvider = this.MntThemeProvider;
            this.MntMode.Click += new System.EventHandler(this.MntMode_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MntMode);
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
        private Components.MintThemeProvider MntThemeProvider;
        private Controls.MintLabel MntMode;
    }
}