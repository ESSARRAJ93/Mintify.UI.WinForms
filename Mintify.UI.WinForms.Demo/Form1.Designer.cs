namespace Mintify.UI.WinForms.Demo
{
    partial class Form1
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
            this.mintControl1 = new Mintify.UI.WinForms.Controls.MintControl();
            this.SuspendLayout();
            // 
            // mintControl1
            // 
            this.mintControl1.BorderColor = System.Drawing.Color.Empty;
            this.mintControl1.BorderRadius = 0;
            this.mintControl1.BorderThickness = 0;
            this.mintControl1.Location = new System.Drawing.Point(422, 175);
            this.mintControl1.MinimumSize = new System.Drawing.Size(0, 26);
            this.mintControl1.Name = "mintControl1";
            this.mintControl1.Size = new System.Drawing.Size(94, 26);
            this.mintControl1.TabIndex = 0;
            this.mintControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mintControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.MintControl mintControl1;
    }
}

