
namespace SporSalonu
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.sifreLabel = new System.Windows.Forms.Label();
            this.sifrelTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sifreLabel
            // 
            this.sifreLabel.AutoSize = true;
            this.sifreLabel.Font = new System.Drawing.Font("Segoe UI Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifreLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.sifreLabel.Location = new System.Drawing.Point(53, 38);
            this.sifreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sifreLabel.Name = "sifreLabel";
            this.sifreLabel.Size = new System.Drawing.Size(78, 41);
            this.sifreLabel.TabIndex = 3;
            this.sifreLabel.Text = "Şifre:";
            // 
            // sifrelTextBox
            // 
            this.sifrelTextBox.BackColor = System.Drawing.Color.Black;
            this.sifrelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifrelTextBox.ForeColor = System.Drawing.Color.White;
            this.sifrelTextBox.Location = new System.Drawing.Point(147, 47);
            this.sifrelTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.sifrelTextBox.MaxLength = 8;
            this.sifrelTextBox.Name = "sifrelTextBox";
            this.sifrelTextBox.PasswordChar = '*';
            this.sifrelTextBox.Size = new System.Drawing.Size(187, 32);
            this.sifrelTextBox.TabIndex = 4;
            this.sifrelTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sifrelTextBox_KeyDown);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(410, 119);
            this.Controls.Add(this.sifrelTextBox);
            this.Controls.Add(this.sifreLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Yap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sifreLabel;
        private System.Windows.Forms.TextBox sifrelTextBox;
    }
}