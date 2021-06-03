
namespace SporSalonuUI
{
    partial class Giris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
            this.SporSalonuLabel = new System.Windows.Forms.Label();
            this.YeniUyeButton = new System.Windows.Forms.Button();
            this.UyeSecButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // SporSalonuLabel
            // 
            this.SporSalonuLabel.AutoSize = true;
            this.SporSalonuLabel.Font = new System.Drawing.Font("Segoe UI Emoji", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SporSalonuLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.SporSalonuLabel.Location = new System.Drawing.Point(253, 7);
            this.SporSalonuLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SporSalonuLabel.Name = "SporSalonuLabel";
            this.SporSalonuLabel.Size = new System.Drawing.Size(603, 64);
            this.SporSalonuLabel.TabIndex = 0;
            this.SporSalonuLabel.Text = "Spor Salonuna hosgeldiniz!";
            this.SporSalonuLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // YeniUyeButton
            // 
            this.YeniUyeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.YeniUyeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YeniUyeButton.Font = new System.Drawing.Font("Segoe UI Emoji", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YeniUyeButton.ForeColor = System.Drawing.Color.Black;
            this.YeniUyeButton.Location = new System.Drawing.Point(614, 197);
            this.YeniUyeButton.Margin = new System.Windows.Forms.Padding(2);
            this.YeniUyeButton.Name = "YeniUyeButton";
            this.YeniUyeButton.Size = new System.Drawing.Size(259, 58);
            this.YeniUyeButton.TabIndex = 1;
            this.YeniUyeButton.Text = "Yeni Üye";
            this.YeniUyeButton.UseVisualStyleBackColor = false;
            this.YeniUyeButton.Click += new System.EventHandler(this.YeniUyeButton_Click);
            // 
            // UyeSecButton
            // 
            this.UyeSecButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.UyeSecButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.UyeSecButton.FlatAppearance.BorderSize = 0;
            this.UyeSecButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UyeSecButton.Font = new System.Drawing.Font("Segoe UI Emoji", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UyeSecButton.ForeColor = System.Drawing.Color.Black;
            this.UyeSecButton.Location = new System.Drawing.Point(614, 274);
            this.UyeSecButton.Margin = new System.Windows.Forms.Padding(2);
            this.UyeSecButton.Name = "UyeSecButton";
            this.UyeSecButton.Size = new System.Drawing.Size(259, 58);
            this.UyeSecButton.TabIndex = 2;
            this.UyeSecButton.Text = "Üye Seç";
            this.UyeSecButton.UseVisualStyleBackColor = false;
            this.UyeSecButton.Click += new System.EventHandler(this.UyeSecButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(79, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 367);
            this.panel1.TabIndex = 3;
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1024, 543);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.UyeSecButton);
            this.Controls.Add(this.YeniUyeButton);
            this.Controls.Add(this.SporSalonuLabel);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SporSalonuLabel;
        private System.Windows.Forms.Button YeniUyeButton;
        private System.Windows.Forms.Button UyeSecButton;
        private System.Windows.Forms.Panel panel1;
    }
}