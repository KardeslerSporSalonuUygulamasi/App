
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramOluşturForm));
            this.programOlusturLabel = new System.Windows.Forms.Label();
            this.programComboBox = new System.Windows.Forms.ComboBox();
            this.programıEkleButton = new System.Windows.Forms.Button();
            this.gunlerProgramTabControl = new System.Windows.Forms.TabControl();
            this.pazartesiTabPage = new System.Windows.Forms.TabPage();
            this.pazartesiRchTextBox = new System.Windows.Forms.RichTextBox();
            this.saliTabPage = new System.Windows.Forms.TabPage();
            this.saliRichTextBox = new System.Windows.Forms.RichTextBox();
            this.carsambaTabPage = new System.Windows.Forms.TabPage();
            this.carsambaRichTextBox = new System.Windows.Forms.RichTextBox();
            this.persembeTabPage = new System.Windows.Forms.TabPage();
            this.persembeRİchTextBox = new System.Windows.Forms.RichTextBox();
            this.cumaTabPage = new System.Windows.Forms.TabPage();
            this.cumaRichTextBox = new System.Windows.Forms.RichTextBox();
            this.cumartesiTabPage = new System.Windows.Forms.TabPage();
            this.cumartesiRichTextBox = new System.Windows.Forms.RichTextBox();
            this.pazarTabPage = new System.Windows.Forms.TabPage();
            this.pazaProgramRichBox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.yagsizKiloLabel = new System.Windows.Forms.Label();
            this.netYağLabel = new System.Windows.Forms.Label();
            this.labelGuncelle1 = new System.Windows.Forms.Label();
            this.labelGuncelle3 = new System.Windows.Forms.Label();
            this.labelGuncelle2 = new System.Windows.Forms.Label();
            this.fazlaUzunLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gunlerProgramTabControl.SuspendLayout();
            this.pazartesiTabPage.SuspendLayout();
            this.saliTabPage.SuspendLayout();
            this.carsambaTabPage.SuspendLayout();
            this.persembeTabPage.SuspendLayout();
            this.cumaTabPage.SuspendLayout();
            this.cumartesiTabPage.SuspendLayout();
            this.pazarTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            "İleri seviye program",
            "Özel"});
            this.programComboBox.Location = new System.Drawing.Point(489, 335);
            this.programComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.programComboBox.Name = "programComboBox";
            this.programComboBox.Size = new System.Drawing.Size(289, 38);
            this.programComboBox.TabIndex = 37;
            this.programComboBox.SelectedValueChanged += new System.EventHandler(this.programComboBox_SelectedValueChanged_1);
            // 
            // programıEkleButton
            // 
            this.programıEkleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.programıEkleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.programıEkleButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.programıEkleButton.Location = new System.Drawing.Point(39, 761);
            this.programıEkleButton.Margin = new System.Windows.Forms.Padding(2);
            this.programıEkleButton.Name = "programıEkleButton";
            this.programıEkleButton.Size = new System.Drawing.Size(735, 41);
            this.programıEkleButton.TabIndex = 41;
            this.programıEkleButton.Text = "Programı ekle";
            this.programıEkleButton.UseVisualStyleBackColor = false;
            this.programıEkleButton.Click += new System.EventHandler(this.programıEkleButton_Click);
            // 
            // gunlerProgramTabControl
            // 
            this.gunlerProgramTabControl.Controls.Add(this.pazartesiTabPage);
            this.gunlerProgramTabControl.Controls.Add(this.saliTabPage);
            this.gunlerProgramTabControl.Controls.Add(this.carsambaTabPage);
            this.gunlerProgramTabControl.Controls.Add(this.persembeTabPage);
            this.gunlerProgramTabControl.Controls.Add(this.cumaTabPage);
            this.gunlerProgramTabControl.Controls.Add(this.cumartesiTabPage);
            this.gunlerProgramTabControl.Controls.Add(this.pazarTabPage);
            this.gunlerProgramTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gunlerProgramTabControl.Location = new System.Drawing.Point(35, 355);
            this.gunlerProgramTabControl.Name = "gunlerProgramTabControl";
            this.gunlerProgramTabControl.SelectedIndex = 0;
            this.gunlerProgramTabControl.Size = new System.Drawing.Size(743, 385);
            this.gunlerProgramTabControl.TabIndex = 42;
            this.gunlerProgramTabControl.SelectedIndexChanged += new System.EventHandler(this.gunlerProgramTabControl_SelectedIndexChanged);
            // 
            // pazartesiTabPage
            // 
            this.pazartesiTabPage.BackColor = System.Drawing.Color.Black;
            this.pazartesiTabPage.Controls.Add(this.pazartesiRchTextBox);
            this.pazartesiTabPage.ForeColor = System.Drawing.Color.White;
            this.pazartesiTabPage.Location = new System.Drawing.Point(4, 25);
            this.pazartesiTabPage.Name = "pazartesiTabPage";
            this.pazartesiTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pazartesiTabPage.Size = new System.Drawing.Size(735, 356);
            this.pazartesiTabPage.TabIndex = 0;
            this.pazartesiTabPage.Text = "Pazartesi";
            // 
            // pazartesiRchTextBox
            // 
            this.pazartesiRchTextBox.BackColor = System.Drawing.Color.Black;
            this.pazartesiRchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pazartesiRchTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.pazartesiRchTextBox.Location = new System.Drawing.Point(-4, -2);
            this.pazartesiRchTextBox.Name = "pazartesiRchTextBox";
            this.pazartesiRchTextBox.Size = new System.Drawing.Size(743, 360);
            this.pazartesiRchTextBox.TabIndex = 44;
            this.pazartesiRchTextBox.Text = "";
            this.pazartesiRchTextBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // saliTabPage
            // 
            this.saliTabPage.BackColor = System.Drawing.Color.Black;
            this.saliTabPage.Controls.Add(this.saliRichTextBox);
            this.saliTabPage.ForeColor = System.Drawing.Color.White;
            this.saliTabPage.Location = new System.Drawing.Point(4, 25);
            this.saliTabPage.Name = "saliTabPage";
            this.saliTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.saliTabPage.Size = new System.Drawing.Size(735, 356);
            this.saliTabPage.TabIndex = 1;
            this.saliTabPage.Text = "Salı";
            // 
            // saliRichTextBox
            // 
            this.saliRichTextBox.BackColor = System.Drawing.Color.Black;
            this.saliRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.saliRichTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.saliRichTextBox.Location = new System.Drawing.Point(-4, -2);
            this.saliRichTextBox.Name = "saliRichTextBox";
            this.saliRichTextBox.Size = new System.Drawing.Size(743, 360);
            this.saliRichTextBox.TabIndex = 44;
            this.saliRichTextBox.Text = "";
            // 
            // carsambaTabPage
            // 
            this.carsambaTabPage.BackColor = System.Drawing.Color.Black;
            this.carsambaTabPage.Controls.Add(this.carsambaRichTextBox);
            this.carsambaTabPage.ForeColor = System.Drawing.Color.White;
            this.carsambaTabPage.Location = new System.Drawing.Point(4, 25);
            this.carsambaTabPage.Name = "carsambaTabPage";
            this.carsambaTabPage.Size = new System.Drawing.Size(735, 356);
            this.carsambaTabPage.TabIndex = 2;
            this.carsambaTabPage.Text = "Çarşamba";
            this.carsambaTabPage.Click += new System.EventHandler(this.carsambaTabPage_Click);
            // 
            // carsambaRichTextBox
            // 
            this.carsambaRichTextBox.BackColor = System.Drawing.Color.Black;
            this.carsambaRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.carsambaRichTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.carsambaRichTextBox.Location = new System.Drawing.Point(-4, -2);
            this.carsambaRichTextBox.Name = "carsambaRichTextBox";
            this.carsambaRichTextBox.Size = new System.Drawing.Size(743, 360);
            this.carsambaRichTextBox.TabIndex = 44;
            this.carsambaRichTextBox.Text = "";
            // 
            // persembeTabPage
            // 
            this.persembeTabPage.BackColor = System.Drawing.Color.Black;
            this.persembeTabPage.Controls.Add(this.persembeRİchTextBox);
            this.persembeTabPage.ForeColor = System.Drawing.Color.White;
            this.persembeTabPage.Location = new System.Drawing.Point(4, 25);
            this.persembeTabPage.Name = "persembeTabPage";
            this.persembeTabPage.Size = new System.Drawing.Size(735, 356);
            this.persembeTabPage.TabIndex = 3;
            this.persembeTabPage.Text = "Perşembe";
            // 
            // persembeRİchTextBox
            // 
            this.persembeRİchTextBox.BackColor = System.Drawing.Color.Black;
            this.persembeRİchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.persembeRİchTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.persembeRİchTextBox.Location = new System.Drawing.Point(-4, -2);
            this.persembeRİchTextBox.Name = "persembeRİchTextBox";
            this.persembeRİchTextBox.Size = new System.Drawing.Size(743, 360);
            this.persembeRİchTextBox.TabIndex = 44;
            this.persembeRİchTextBox.Text = "";
            // 
            // cumaTabPage
            // 
            this.cumaTabPage.BackColor = System.Drawing.Color.Black;
            this.cumaTabPage.Controls.Add(this.cumaRichTextBox);
            this.cumaTabPage.ForeColor = System.Drawing.Color.White;
            this.cumaTabPage.Location = new System.Drawing.Point(4, 25);
            this.cumaTabPage.Name = "cumaTabPage";
            this.cumaTabPage.Size = new System.Drawing.Size(735, 356);
            this.cumaTabPage.TabIndex = 4;
            this.cumaTabPage.Text = "Cuma";
            // 
            // cumaRichTextBox
            // 
            this.cumaRichTextBox.BackColor = System.Drawing.Color.Black;
            this.cumaRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cumaRichTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.cumaRichTextBox.Location = new System.Drawing.Point(-4, -2);
            this.cumaRichTextBox.Name = "cumaRichTextBox";
            this.cumaRichTextBox.Size = new System.Drawing.Size(743, 360);
            this.cumaRichTextBox.TabIndex = 44;
            this.cumaRichTextBox.Text = "";
            // 
            // cumartesiTabPage
            // 
            this.cumartesiTabPage.BackColor = System.Drawing.Color.Black;
            this.cumartesiTabPage.Controls.Add(this.cumartesiRichTextBox);
            this.cumartesiTabPage.ForeColor = System.Drawing.Color.White;
            this.cumartesiTabPage.Location = new System.Drawing.Point(4, 25);
            this.cumartesiTabPage.Name = "cumartesiTabPage";
            this.cumartesiTabPage.Size = new System.Drawing.Size(735, 356);
            this.cumartesiTabPage.TabIndex = 5;
            this.cumartesiTabPage.Text = "Cumartesi";
            // 
            // cumartesiRichTextBox
            // 
            this.cumartesiRichTextBox.BackColor = System.Drawing.Color.Black;
            this.cumartesiRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cumartesiRichTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.cumartesiRichTextBox.Location = new System.Drawing.Point(-4, -2);
            this.cumartesiRichTextBox.Name = "cumartesiRichTextBox";
            this.cumartesiRichTextBox.Size = new System.Drawing.Size(743, 360);
            this.cumartesiRichTextBox.TabIndex = 44;
            this.cumartesiRichTextBox.Text = "";
            // 
            // pazarTabPage
            // 
            this.pazarTabPage.BackColor = System.Drawing.Color.Black;
            this.pazarTabPage.Controls.Add(this.pazaProgramRichBox);
            this.pazarTabPage.ForeColor = System.Drawing.Color.White;
            this.pazarTabPage.Location = new System.Drawing.Point(4, 25);
            this.pazarTabPage.Name = "pazarTabPage";
            this.pazarTabPage.Size = new System.Drawing.Size(735, 356);
            this.pazarTabPage.TabIndex = 6;
            this.pazarTabPage.Text = "Pazar";
            // 
            // pazaProgramRichBox
            // 
            this.pazaProgramRichBox.BackColor = System.Drawing.Color.Black;
            this.pazaProgramRichBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pazaProgramRichBox.ForeColor = System.Drawing.SystemColors.Window;
            this.pazaProgramRichBox.Location = new System.Drawing.Point(-4, -2);
            this.pazaProgramRichBox.Name = "pazaProgramRichBox";
            this.pazaProgramRichBox.Size = new System.Drawing.Size(743, 362);
            this.pazaProgramRichBox.TabIndex = 43;
            this.pazaProgramRichBox.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label8.Location = new System.Drawing.Point(28, 293);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(221, 41);
            this.label8.TabIndex = 44;
            this.label8.Text = "Program Detayı:";
            // 
            // yagsizKiloLabel
            // 
            this.yagsizKiloLabel.AutoSize = true;
            this.yagsizKiloLabel.Font = new System.Drawing.Font("Segoe UI Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yagsizKiloLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.yagsizKiloLabel.Location = new System.Drawing.Point(334, 38);
            this.yagsizKiloLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yagsizKiloLabel.Name = "yagsizKiloLabel";
            this.yagsizKiloLabel.Size = new System.Drawing.Size(151, 41);
            this.yagsizKiloLabel.TabIndex = 45;
            this.yagsizKiloLabel.Text = "Yağsız kilo:";
            // 
            // netYağLabel
            // 
            this.netYağLabel.AutoSize = true;
            this.netYağLabel.Font = new System.Drawing.Font("Segoe UI Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.netYağLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.netYağLabel.Location = new System.Drawing.Point(19, 38);
            this.netYağLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.netYağLabel.Name = "netYağLabel";
            this.netYağLabel.Size = new System.Drawing.Size(122, 41);
            this.netYağLabel.TabIndex = 48;
            this.netYağLabel.Text = "Net Yağ:";
            // 
            // labelGuncelle1
            // 
            this.labelGuncelle1.AutoSize = true;
            this.labelGuncelle1.Font = new System.Drawing.Font("Segoe UI Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelGuncelle1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelGuncelle1.Location = new System.Drawing.Point(160, 38);
            this.labelGuncelle1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGuncelle1.Name = "labelGuncelle1";
            this.labelGuncelle1.Size = new System.Drawing.Size(63, 41);
            this.labelGuncelle1.TabIndex = 51;
            this.labelGuncelle1.Text = "Kilo";
            // 
            // labelGuncelle3
            // 
            this.labelGuncelle3.AutoSize = true;
            this.labelGuncelle3.Font = new System.Drawing.Font("Segoe UI Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelGuncelle3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelGuncelle3.Location = new System.Drawing.Point(19, 106);
            this.labelGuncelle3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGuncelle3.Name = "labelGuncelle3";
            this.labelGuncelle3.Size = new System.Drawing.Size(63, 41);
            this.labelGuncelle3.TabIndex = 50;
            this.labelGuncelle3.Text = "Kilo";
            // 
            // labelGuncelle2
            // 
            this.labelGuncelle2.AutoSize = true;
            this.labelGuncelle2.Font = new System.Drawing.Font("Segoe UI Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelGuncelle2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelGuncelle2.Location = new System.Drawing.Point(502, 38);
            this.labelGuncelle2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGuncelle2.Name = "labelGuncelle2";
            this.labelGuncelle2.Size = new System.Drawing.Size(63, 41);
            this.labelGuncelle2.TabIndex = 49;
            this.labelGuncelle2.Text = "Kilo";
            // 
            // fazlaUzunLabel
            // 
            this.fazlaUzunLabel.AutoSize = true;
            this.fazlaUzunLabel.Font = new System.Drawing.Font("Segoe UI Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fazlaUzunLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.fazlaUzunLabel.Location = new System.Drawing.Point(11, 147);
            this.fazlaUzunLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fazlaUzunLabel.Name = "fazlaUzunLabel";
            this.fazlaUzunLabel.Size = new System.Drawing.Size(33, 41);
            this.fazlaUzunLabel.TabIndex = 52;
            this.fazlaUzunLabel.Text = "a";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.netYağLabel);
            this.groupBox1.Controls.Add(this.fazlaUzunLabel);
            this.groupBox1.Controls.Add(this.yagsizKiloLabel);
            this.groupBox1.Controls.Add(this.labelGuncelle2);
            this.groupBox1.Controls.Add(this.labelGuncelle1);
            this.groupBox1.Controls.Add(this.labelGuncelle3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox1.Location = new System.Drawing.Point(35, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 204);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İstatistikler";
            // 
            // ProgramOluşturForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(818, 833);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.programComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gunlerProgramTabControl);
            this.Controls.Add(this.programıEkleButton);
            this.Controls.Add(this.programOlusturLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProgramOluşturForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Program Oluştur";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProgramOluşturForm_FormClosed);
            this.gunlerProgramTabControl.ResumeLayout(false);
            this.pazartesiTabPage.ResumeLayout(false);
            this.saliTabPage.ResumeLayout(false);
            this.carsambaTabPage.ResumeLayout(false);
            this.persembeTabPage.ResumeLayout(false);
            this.cumaTabPage.ResumeLayout(false);
            this.cumartesiTabPage.ResumeLayout(false);
            this.pazarTabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label programOlusturLabel;
        private System.Windows.Forms.ComboBox programComboBox;
        private System.Windows.Forms.Button programıEkleButton;
        private System.Windows.Forms.TabControl gunlerProgramTabControl;
        private System.Windows.Forms.TabPage pazartesiTabPage;
        private System.Windows.Forms.TabPage saliTabPage;
        private System.Windows.Forms.TabPage carsambaTabPage;
        private System.Windows.Forms.TabPage persembeTabPage;
        private System.Windows.Forms.TabPage cumaTabPage;
        private System.Windows.Forms.TabPage cumartesiTabPage;
        private System.Windows.Forms.TabPage pazarTabPage;
        private System.Windows.Forms.Label label8;
        protected System.Windows.Forms.RichTextBox pazaProgramRichBox;
        protected System.Windows.Forms.RichTextBox pazartesiRchTextBox;
        protected System.Windows.Forms.RichTextBox saliRichTextBox;
        protected System.Windows.Forms.RichTextBox carsambaRichTextBox;
        protected System.Windows.Forms.RichTextBox persembeRİchTextBox;
        protected System.Windows.Forms.RichTextBox cumaRichTextBox;
        protected System.Windows.Forms.RichTextBox cumartesiRichTextBox;
        private System.Windows.Forms.Label yagsizKiloLabel;
        private System.Windows.Forms.Label netYağLabel;
        private System.Windows.Forms.Label labelGuncelle1;
        private System.Windows.Forms.Label labelGuncelle3;
        private System.Windows.Forms.Label labelGuncelle2;
        private System.Windows.Forms.Label fazlaUzunLabel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}