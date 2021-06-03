using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SporSalonu;
using SporSalonuLib;
using SporSalonuLib.Models;

namespace SporSalonuUI
{
    /// <summary>
    /// Bu form üye bulma, listeleme ve çeşitli butonlarla işlem yapma görevlerini icra eder.
    /// </summary>
    public partial class UyeBul : Form
    {
        public readonly Giris giris;                // Giris formuna erişmeye yarar
        private bool uyeFound = false;              // uyenin bulunup bulunmadığını kontrol etmeye yarar
        private bool uyeNew = false;                // uyenin yeni olup olmadığını kontrol etmeye yarar
        private bool uyeProgram = false;            // uyenin programının mı istendiğini kontrol etmekye yarar
        private string selectedUye = "";            // selected üyeyi boş stringe eşitliyoruz
        public bool loginFormAnswer = false;        // login formdan cevap gelip gelmediğini kontrol etmeye yarar
        public bool loginFormFailedRespond = false; // login formda şifrenin hatalı olup olmadığını kontrol etmemizi yarar

        public PersonModel pModel = new PersonModel(); // Public ve global bir personmodel 

        /// <summary>
        ///  Giris form için tasarlaış bir constructor. Giris kendisini pass ederek çağırır.
        /// </summary>
        /// <param name="girisForm"></param>
        public UyeBul(Giris girisForm)
        {
            giris = girisForm;
            InitializeComponent();
            StartTimer();       // timer başlatılır
            adminLabel.Hide();  // admin label gizleniyor
        }

        /// <summary>
        /// Guncelleme ekranı için admin yetkisi gerekli. Bundan dolayı Şifre girme ekranı çağırılıyor.
        /// </summary>
        public void Guncelle()
        {
            LoginForm lgnfrm = new LoginForm(this);
            lgnfrm.Show();
            return;
        }

        /// <summary>
        /// Her çift saniyede admin yazısı gözüküyor. (Not: Son güncellemeyle bu admin yazısı artık gözükmemekte çünkü formlar arası geçiş direkt olmakta)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (loginFormAnswer && DateTime.UtcNow.Second % 2 == 0) adminLabel.Show();
            else adminLabel.Hide();
        }

        /// <summary>
        /// Timerı başlatan fonksiyon. Her 1 saniye bir tick olarak ayarlanarak aktive ediliyor.
        /// </summary>
        private void StartTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer_Tick);
            timer1.Enabled = true;
        }

        /// <summary>
        /// Bu fonksiyon Üyeyi bularak bizi Üye Oluştur formuna gönderir.
        /// UyeBul formunda arama kısmına ad yazdığımızda uyeyi güncellememiz için gerekli forma gönderecek
        /// fonksiyon. Üye güncelleme için yönetici yetkisi gerektiğinden ilk önce şifre girme formu çağırılır.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void bulButton_Click(object sender, EventArgs e)
        {
            if (!loginFormAnswer && !loginFormFailedRespond) { Guncelle(); return; }
            else if (loginFormFailedRespond) { MessageBox.Show("Yanlış şifre!", "Hata"); loginFormFailedRespond = false; return; }
            
            PersonModel p = new PersonModel();
            p.Adı = uyeBulTextBox.Text; // adı na eşitler ve database den o adda kişiyi bulmak için ilgili fonksiyonu çağırır

            p = GlobalConfig.Connection.GetPerson(p);

            if (p.Uyeler != null)                   // Dönüş null değilse uyeleri liste halinde list boxta göstermek için gerekli işlemleri yapar
            {
                uyeBulListBox.Items.Clear();
                ConvertFromListToPersonModel(p);
                return;
            }

            if (p.Soyadı != null) // soyadı nullsa databasede böyle bir kişi bulunamamiştır. yeni üye oluşturma ekranına atılır.
            {
                uyeFound = true;
                UyeOlusturma frm = new UyeOlusturma(p, 1, this);
                frm.Show();
                this.Close();
            }
            else
            {
                DialogResult YesOrNo = MessageBox.Show($"{p.Adı} adlı üyeyü kayıt etmek ister misiniz?", "Kaydetmek ister misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (YesOrNo == DialogResult.Yes)
                {
                    uyeNew = true;
                    uyeFound = false;
                    UyeOlusturma frm = new UyeOlusturma(p, this);
                    frm.Show();
                    this.Close();
                }
                else
                {
                    return;
                }
            }

        }
        /// <summary>
        /// Tüm üyeleri listelemek için gerekli işlemleri yapar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listeleButton_Click(object sender, EventArgs e)
        {
            uyeBulListBox.Items.Clear();
            PersonModel p = new PersonModel();
            p = GlobalConfig.Connection.GetPersonAll(p);

            ConvertFromListToPersonModel(p);

        }
        /// <summary>
        /// Listeyi PersonModel haline çevirir.
        /// </summary>
        /// <param name="p"></param>
        public void ConvertFromListToPersonModel(PersonModel p)
        {
            p.Uyeler = String.Join("",p.Uyeler.Split('[', '\'', ']'));
            p.Uyeler = " " + p.Uyeler;

            string[] outputSplitted = p.Uyeler.Split(',');

            foreach(string splitted in outputSplitted)
            {
                string removedSpace = splitted.Remove(0,1);
                uyeBulListBox.Items.Add(removedSpace.Replace('|', '\t'));
            }
        }
        /// <summary>
        /// Form kapanırsa bir öncek formu gösterir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UyeBul_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!uyeFound && !uyeNew && !uyeProgram)
            {
                uyeFound = !uyeFound;
                giris.Show(); 
            }
        }
        /// <summary>
        /// Enter tuşuna basıldığında aramayı yapar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uyeBulTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                bulButton_Click(this, EventArgs.Empty);
            }
        }

        private void uyeBulListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uyeBulListBox.SelectedItem != null)
            {
                selectedUye = uyeBulListBox.SelectedItem.ToString(); 
                string selectedUyeId = selectedUye.Split('\t')[0];
                uyeBulTextBox.Text = selectedUyeId;
            }
        }

        /// <summary>
        /// Üyenin üstüne çift tıklanınca üye güncelleme ekranını açar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uyeBulListBox_DoubleClick(object sender, EventArgs e)
        {
            if (uyeBulListBox.SelectedItem == null) return;

            if (!loginFormAnswer && !loginFormFailedRespond) { Guncelle(); return; }
            else if (loginFormFailedRespond) { MessageBox.Show("Yanlış şifre!", "Hata"); loginFormFailedRespond = false; return; }

            PersonModel p = new PersonModel();
            p.Adı = uyeBulTextBox.Text;

            p = GlobalConfig.Connection.GetPerson(p);

            uyeFound = true;
            UyeOlusturma frm = new UyeOlusturma(p, 1, this);
            frm.Show();
            this.Close();
        }

        /// <summary>
        /// Üyenin programını getirir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void programıBulButton_Click(object sender, EventArgs e)
        {
            PersonModel p = new PersonModel();
            p.id = uyeBulTextBox.Text;
            p.Adı = p.id; 
            p = GlobalConfig.Connection.GetPerson(p);

            if(p.Soyadı == null) { return; }

            p.Program = GlobalConfig.Connection.GetWorkoutProgram(p);
            p.Program = p.Program.Replace(';', ' ');
            p.Program = p.Program.Replace('*', '\n');
            pModel = p;

            pModel.hesaplamalar = GlobalConfig.Connection.GetProgramCalculations(pModel);
            
            uyeProgram = true;

            ProgramOluşturForm frm = new ProgramOluşturForm(this);
            frm.Show();
            this.Close();
        }

        private void uyeGirisiButton_Click(object sender, EventArgs e)
        {
            PersonModel p = new PersonModel();
            p.Adı = uyeBulTextBox.Text;

            p = GlobalConfig.Connection.GetPerson(p);
            if(p.Soyadı == null) { return; }



            uyeFound = true;
            UyeGirisiForm frm = new UyeGirisiForm(p, this);
            frm.Show();
            this.Close();
        }
    }
}
