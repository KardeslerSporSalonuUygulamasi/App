
namespace SporSalonu
{
    partial class ProgramOluşturForm
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
            this.programOlusturLabel = new System.Windows.Forms.Label();
            this.programComboBox = new System.Windows.Forms.ComboBox();
            this.isimLabel = new System.Windows.Forms.Label();
            this.programRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.programıEkleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // programOlusturLabel
            // 
            this.programOlusturLabel.AutoSize = true;
            this.programOlusturLabel.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.programOlusturLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.programOlusturLabel.Location = new System.Drawing.Point(28, 30);
            this.programOlusturLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.programOlusturLabel.Name = "programOlusturLabel";
            this.programOlusturLabel.Size = new System.Drawing.Size(228, 40);
            this.programOlusturLabel.TabIndex = 22;
            this.programOlusturLabel.Text = "Program Oluştur";
            // 
            // programComboBox
            // 
            this.programComboBox.BackColor = System.Drawing.Color.Black;
            this.programComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.programComboBox.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programComboBox.ForeColor = System.Drawing.Color.White;
            this.programComboBox.FormattingEnabled = true;
            this.programComboBox.Items.AddRange(new object[] {
            "Başlangıç seviyesi program",
            "Orta seviye program",
            "İleri seviye program"});
            this.programComboBox.Location = new System.Drawing.Point(209, 123);
            this.programComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.programComboBox.Name = "programComboBox";
            this.programComboBox.Size = new System.Drawing.Size(447, 38);
            this.programComboBox.TabIndex = 37;
            this.programComboBox.SelectedValueChanged += new System.EventHandler(this.programComboBox_SelectedValueChanged_1);
            // 
            // isimLabel
            // 
            this.isimLabel.AutoSize = true;
            this.isimLabel.Font = new System.Drawing.Font("Segoe UI Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isimLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.isimLabel.Location = new System.Drawing.Point(28, 117);
            this.isimLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.isimLabel.Name = "isimLabel";
            this.isimLabel.Size = new System.Drawing.Size(134, 41);
            this.isimLabel.TabIndex = 38;
            this.isimLabel.Text = "Program:";
            // 
            // programRichTextBox
            // 
            this.programRichTextBox.BackColor = System.Drawing.Color.Black;
            this.programRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.programRichTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.programRichTextBox.Location = new System.Drawing.Point(35, 237);
            this.programRichTextBox.Name = "programRichTextBox";
            this.programRichTextBox.Size = new System.Drawing.Size(621, 238);
            this.programRichTextBox.TabIndex = 39;
            this.programRichTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(28, 193);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 41);
            this.label1.TabIndex = 40;
            this.label1.Text = "Program Detayı:";
            // 
            // programıEkleButton
            // 
            this.programıEkleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.programıEkleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.programıEkleButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.programıEkleButton.Location = new System.Drawing.Point(35, 504);
            this.programıEkleButton.Margin = new System.Windows.Forms.Padding(2);
            this.programıEkleButton.Name = "programıEkleButton";
            this.programıEkleButton.Size = new System.Drawing.Size(621, 41);
            this.programıEkleButton.TabIndex = 41;
            this.programıEkleButton.Text = "Programı ekle";
            this.programıEkleButton.UseVisualStyleBackColor = false;
            this.programıEkleButton.Click += new System.EventHandler(this.programıEkleButton_Click);
            // 
            // ProgramOluşturForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(695, 582);
            this.Controls.Add(this.programıEkleButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.programRichTextBox);
            this.Controls.Add(this.isimLabel);
            this.Controls.Add(this.programComboBox);
            this.Controls.Add(this.programOlusturLabel);
            this.Name = "ProgramOluşturForm";
            this.Text = "ProgramOluşturForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label programOlusturLabel;
        private System.Windows.Forms.ComboBox programComboBox;
        private System.Windows.Forms.Label isimLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button programıEkleButton;
        protected System.Windows.Forms.RichTextBox programRichTextBox;
    }
}