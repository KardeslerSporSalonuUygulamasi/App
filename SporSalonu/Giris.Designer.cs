
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
            this.SporSalonuLabel.Location = new System.Drawing.Point(337, 9);
            this.SporSalonuLabel.Name = "SporSalonuLabel";
            this.SporSalonuLabel.Size = new System.Drawing.Size(753, 80);
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
            this.YeniUyeButton.Location = new System.Drawing.Point(818, 243);
            this.YeniUyeButton.Name = "YeniUyeButton";
            this.YeniUyeButton.Size = new System.Drawing.Size(345, 71);
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
            this.UyeSecButton.Location = new System.Drawing.Point(818, 337);
            this.UyeSecButton.Name = "UyeSecButton";
            this.UyeSecButton.Size = new System.Drawing.Size(345, 71);
            this.UyeSecButton.TabIndex = 2;
            this.UyeSecButton.Text = "Üye Seç";
            this.UyeSecButton.UseVisualStyleBackColor = false;
            this.UyeSecButton.Click += new System.EventHandler(this.UyeSecButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SporSalonuUI.Properties.Resources.bodybuilding_PNG55;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(152, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 425);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1365, 668);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.UyeSecButton);
            this.Controls.Add(this.YeniUyeButton);
            this.Controls.Add(this.SporSalonuLabel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Giris";
            this.Text = "Giris";
            this.Load += new System.EventHandler(this.Giris_Load);
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