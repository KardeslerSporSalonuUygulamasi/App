
namespace SporSalonuUI
{
    partial class UyeBul
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UyeBul));
            this.uyeBulLabel = new System.Windows.Forms.Label();
            this.uyeBulTextBox = new System.Windows.Forms.TextBox();
            this.uyeninAdınıGirinizLabel = new System.Windows.Forms.Label();
            this.bulButton = new System.Windows.Forms.Button();
            this.uyeBulListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // uyeBulLabel
            // 
            this.uyeBulLabel.AutoSize = true;
            this.uyeBulLabel.Font = new System.Drawing.Font("Segoe UI Light", 32.2F);
            this.uyeBulLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.uyeBulLabel.Location = new System.Drawing.Point(8, 24);
            this.uyeBulLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uyeBulLabel.Name = "uyeBulLabel";
            this.uyeBulLabel.Size = new System.Drawing.Size(161, 59);
            this.uyeBulLabel.TabIndex = 0;
            this.uyeBulLabel.Text = "Üye Bul";
            // 
            // uyeBulTextBox
            // 
            this.uyeBulTextBox.BackColor = System.Drawing.Color.Black;
            this.uyeBulTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.uyeBulTextBox.ForeColor = System.Drawing.Color.White;
            this.uyeBulTextBox.Location = new System.Drawing.Point(17, 175);
            this.uyeBulTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.uyeBulTextBox.Name = "uyeBulTextBox";
            this.uyeBulTextBox.Size = new System.Drawing.Size(316, 32);
            this.uyeBulTextBox.TabIndex = 2;
            // 
            // uyeninAdınıGirinizLabel
            // 
            this.uyeninAdınıGirinizLabel.AutoSize = true;
            this.uyeninAdınıGirinizLabel.Font = new System.Drawing.Font("Segoe UI Light", 26.2F);
            this.uyeninAdınıGirinizLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.uyeninAdınıGirinizLabel.Location = new System.Drawing.Point(20, 106);
            this.uyeninAdınıGirinizLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uyeninAdınıGirinizLabel.Name = "uyeninAdınıGirinizLabel";
            this.uyeninAdınıGirinizLabel.Size = new System.Drawing.Size(325, 47);
            this.uyeninAdınıGirinizLabel.TabIndex = 3;
            this.uyeninAdınıGirinizLabel.Text = "Üyenlin adını giriniz: ";
            // 
            // bulButton
            // 
            this.bulButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.bulButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bulButton.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bulButton.Location = new System.Drawing.Point(93, 231);
            this.bulButton.Margin = new System.Windows.Forms.Padding(2);
            this.bulButton.Name = "bulButton";
            this.bulButton.Size = new System.Drawing.Size(166, 45);
            this.bulButton.TabIndex = 4;
            this.bulButton.Text = "Bul";
            this.bulButton.UseVisualStyleBackColor = false;
            this.bulButton.Click += new System.EventHandler(this.bulButton_Click);
            // 
            // uyeBulListBox
            // 
            this.uyeBulListBox.BackColor = System.Drawing.Color.Black;
            this.uyeBulListBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.uyeBulListBox.ForeColor = System.Drawing.Color.White;
            this.uyeBulListBox.FormattingEnabled = true;
            this.uyeBulListBox.ItemHeight = 25;
            this.uyeBulListBox.Location = new System.Drawing.Point(395, 17);
            this.uyeBulListBox.Margin = new System.Windows.Forms.Padding(2);
            this.uyeBulListBox.Name = "uyeBulListBox";
            this.uyeBulListBox.Size = new System.Drawing.Size(401, 454);
            this.uyeBulListBox.TabIndex = 5;
            // 
            // UyeBul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(826, 502);
            this.Controls.Add(this.uyeBulListBox);
            this.Controls.Add(this.bulButton);
            this.Controls.Add(this.uyeninAdınıGirinizLabel);
            this.Controls.Add(this.uyeBulTextBox);
            this.Controls.Add(this.uyeBulLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UyeBul";
            this.Text = "UyeBul";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uyeBulLabel;
        private System.Windows.Forms.TextBox uyeBulTextBox;
        private System.Windows.Forms.Label uyeninAdınıGirinizLabel;
        private System.Windows.Forms.Button bulButton;
        private System.Windows.Forms.ListBox uyeBulListBox;
    }
}