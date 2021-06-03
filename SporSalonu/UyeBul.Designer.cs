
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UyeBul));
            this.uyeBulLabel = new System.Windows.Forms.Label();
            this.uyeBulTextBox = new System.Windows.Forms.TextBox();
            this.uyeninAdınıGirinizLabel = new System.Windows.Forms.Label();
            this.guncelleButton = new System.Windows.Forms.Button();
            this.uyeBulListBox = new System.Windows.Forms.ListBox();
            this.listeleButton = new System.Windows.Forms.Button();
            this.programıBulButton = new System.Windows.Forms.Button();
            this.uyeGirisiButton = new System.Windows.Forms.Button();
            this.bulButton = new System.Windows.Forms.Button();
            this.adminLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.uyeBulTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uyeBulTextBox_KeyDown);
            // 
            // uyeninAdınıGirinizLabel
            // 
            this.uyeninAdınıGirinizLabel.AutoSize = true;
            this.uyeninAdınıGirinizLabel.Font = new System.Drawing.Font("Segoe UI Light", 26.2F);
            this.uyeninAdınıGirinizLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.uyeninAdınıGirinizLabel.Location = new System.Drawing.Point(20, 106);
            this.uyeninAdınıGirinizLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uyeninAdınıGirinizLabel.Name = "uyeninAdınıGirinizLabel";
            this.uyeninAdınıGirinizLabel.Size = new System.Drawing.Size(318, 47);
            this.uyeninAdınıGirinizLabel.TabIndex = 3;
            this.uyeninAdınıGirinizLabel.Text = "Üyenin adını giriniz: ";
            // 
            // guncelleButton
            // 
            this.guncelleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.guncelleButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.guncelleButton.FlatAppearance.BorderSize = 2;
            this.guncelleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guncelleButton.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guncelleButton.Location = new System.Drawing.Point(17, 289);
            this.guncelleButton.Margin = new System.Windows.Forms.Padding(2);
            this.guncelleButton.Name = "guncelleButton";
            this.guncelleButton.Size = new System.Drawing.Size(316, 35);
            this.guncelleButton.TabIndex = 4;
            this.guncelleButton.Text = "Güncelle";
            this.guncelleButton.UseVisualStyleBackColor = false;
            this.guncelleButton.Click += new System.EventHandler(this.bulButton_Click);
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
            this.uyeBulListBox.SelectedIndexChanged += new System.EventHandler(this.uyeBulListBox_SelectedIndexChanged);
            this.uyeBulListBox.DoubleClick += new System.EventHandler(this.uyeBulListBox_DoubleClick);
            // 
            // listeleButton
            // 
            this.listeleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.listeleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listeleButton.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listeleButton.Location = new System.Drawing.Point(183, 231);
            this.listeleButton.Margin = new System.Windows.Forms.Padding(2);
            this.listeleButton.Name = "listeleButton";
            this.listeleButton.Size = new System.Drawing.Size(150, 45);
            this.listeleButton.TabIndex = 6;
            this.listeleButton.Text = "Üye Listele";
            this.listeleButton.UseVisualStyleBackColor = false;
            this.listeleButton.Click += new System.EventHandler(this.listeleButton_Click);
            // 
            // programıBulButton
            // 
            this.programıBulButton.BackColor = System.Drawing.Color.Indigo;
            this.programıBulButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.programıBulButton.FlatAppearance.BorderSize = 2;
            this.programıBulButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.programıBulButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.programıBulButton.ForeColor = System.Drawing.SystemColors.Window;
            this.programıBulButton.Location = new System.Drawing.Point(17, 341);
            this.programıBulButton.Margin = new System.Windows.Forms.Padding(2);
            this.programıBulButton.Name = "programıBulButton";
            this.programıBulButton.Size = new System.Drawing.Size(315, 38);
            this.programıBulButton.TabIndex = 43;
            this.programıBulButton.Text = "Programı Bul";
            this.programıBulButton.UseVisualStyleBackColor = false;
            this.programıBulButton.Click += new System.EventHandler(this.programıBulButton_Click);
            // 
            // uyeGirisiButton
            // 
            this.uyeGirisiButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.uyeGirisiButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uyeGirisiButton.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.uyeGirisiButton.Location = new System.Drawing.Point(18, 231);
            this.uyeGirisiButton.Margin = new System.Windows.Forms.Padding(2);
            this.uyeGirisiButton.Name = "uyeGirisiButton";
            this.uyeGirisiButton.Size = new System.Drawing.Size(161, 45);
            this.uyeGirisiButton.TabIndex = 44;
            this.uyeGirisiButton.Text = "Üye Girişi";
            this.uyeGirisiButton.UseVisualStyleBackColor = false;
            this.uyeGirisiButton.Click += new System.EventHandler(this.uyeGirisiButton_Click);
            // 
            // bulButton
            // 
            this.bulButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.bulButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bulButton.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bulButton.Location = new System.Drawing.Point(17, 289);
            this.bulButton.Margin = new System.Windows.Forms.Padding(2);
            this.bulButton.Name = "bulButton";
            this.bulButton.Size = new System.Drawing.Size(316, 35);
            this.bulButton.TabIndex = 4;
            this.bulButton.Text = "Guncelle";
            this.bulButton.UseVisualStyleBackColor = false;
            this.bulButton.Click += new System.EventHandler(this.bulButton_Click);
            // 
            // adminLabel
            // 
            this.adminLabel.AutoSize = true;
            this.adminLabel.BackColor = System.Drawing.Color.Transparent;
            this.adminLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminLabel.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            this.adminLabel.ForeColor = System.Drawing.Color.Red;
            this.adminLabel.Location = new System.Drawing.Point(252, 74);
            this.adminLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.adminLabel.Name = "adminLabel";
            this.adminLabel.Size = new System.Drawing.Size(81, 32);
            this.adminLabel.TabIndex = 45;
            this.adminLabel.Text = "Admin";
            // 
            // UyeBul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(826, 502);
            this.Controls.Add(this.adminLabel);
            this.Controls.Add(this.uyeGirisiButton);
            this.Controls.Add(this.programıBulButton);
            this.Controls.Add(this.listeleButton);
            this.Controls.Add(this.uyeBulListBox);
            this.Controls.Add(this.guncelleButton);
            this.Controls.Add(this.uyeninAdınıGirinizLabel);
            this.Controls.Add(this.uyeBulTextBox);
            this.Controls.Add(this.uyeBulLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UyeBul";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UyeBul";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UyeBul_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uyeBulLabel;
        private System.Windows.Forms.TextBox uyeBulTextBox;
        private System.Windows.Forms.Label uyeninAdınıGirinizLabel;
        private System.Windows.Forms.Button guncelleButton;
        private System.Windows.Forms.ListBox uyeBulListBox;
        private System.Windows.Forms.Button listeleButton;
        private System.Windows.Forms.Button programıBulButton;
        private System.Windows.Forms.Button uyeGirisiButton;
        private System.Windows.Forms.Button bulButton;
        private System.Windows.Forms.Label adminLabel;
        private System.Windows.Forms.Timer timer1;
    }
}