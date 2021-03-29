
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
            this.button1 = new System.Windows.Forms.Button();
            this.uyeBulListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // uyeBulLabel
            // 
            this.uyeBulLabel.AutoSize = true;
            this.uyeBulLabel.Font = new System.Drawing.Font("Segoe UI Light", 32.2F);
            this.uyeBulLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.uyeBulLabel.Location = new System.Drawing.Point(11, 30);
            this.uyeBulLabel.Name = "uyeBulLabel";
            this.uyeBulLabel.Size = new System.Drawing.Size(200, 72);
            this.uyeBulLabel.TabIndex = 0;
            this.uyeBulLabel.Text = "Üye Bul";
            // 
            // uyeBulTextBox
            // 
            this.uyeBulTextBox.BackColor = System.Drawing.Color.Black;
            this.uyeBulTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.uyeBulTextBox.ForeColor = System.Drawing.Color.White;
            this.uyeBulTextBox.Location = new System.Drawing.Point(23, 215);
            this.uyeBulTextBox.Name = "uyeBulTextBox";
            this.uyeBulTextBox.Size = new System.Drawing.Size(420, 38);
            this.uyeBulTextBox.TabIndex = 2;
            // 
            // uyeninAdınıGirinizLabel
            // 
            this.uyeninAdınıGirinizLabel.AutoSize = true;
            this.uyeninAdınıGirinizLabel.Font = new System.Drawing.Font("Segoe UI Light", 26.2F);
            this.uyeninAdınıGirinizLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.uyeninAdınıGirinizLabel.Location = new System.Drawing.Point(26, 131);
            this.uyeninAdınıGirinizLabel.Name = "uyeninAdınıGirinizLabel";
            this.uyeninAdınıGirinizLabel.Size = new System.Drawing.Size(408, 60);
            this.uyeninAdınıGirinizLabel.TabIndex = 3;
            this.uyeninAdınıGirinizLabel.Text = "Üyenlin adını giriniz: ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(124, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 55);
            this.button1.TabIndex = 4;
            this.button1.Text = "Bul";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // uyeBulListBox
            // 
            this.uyeBulListBox.BackColor = System.Drawing.Color.Black;
            this.uyeBulListBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.uyeBulListBox.ForeColor = System.Drawing.Color.White;
            this.uyeBulListBox.FormattingEnabled = true;
            this.uyeBulListBox.ItemHeight = 31;
            this.uyeBulListBox.Location = new System.Drawing.Point(527, 21);
            this.uyeBulListBox.Name = "uyeBulListBox";
            this.uyeBulListBox.Size = new System.Drawing.Size(533, 562);
            this.uyeBulListBox.TabIndex = 5;
            // 
            // UyeBul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1102, 618);
            this.Controls.Add(this.uyeBulListBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uyeninAdınıGirinizLabel);
            this.Controls.Add(this.uyeBulTextBox);
            this.Controls.Add(this.uyeBulLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UyeBul";
            this.Text = "UyeBul";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uyeBulLabel;
        private System.Windows.Forms.TextBox uyeBulTextBox;
        private System.Windows.Forms.Label uyeninAdınıGirinizLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox uyeBulListBox;
    }
}