using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SporSalonuUI;
using SporSalonuLib.Models;
using SporSalonuLib;


namespace SporSalonu
{
    /// <summary>
    /// Bu form Uyenin spor salonuna giriş çıkışı ile ilgili işlemleri yapabilmesi için tasarlanmıştır.
    /// </summary>
    public partial class UyeGirisiForm : Form
    {
        public readonly UyeBul bul;         // Uye bul formuna erişebilmemize yarar
        private PersonModel pmodel;         // global bir PersonModel 

        /// <summary>
        /// Parametre almayan bir constructor
        /// </summary>
        public UyeGirisiForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// PersonModel ve UyeBul form pass edilen bir constructor. Formdaki ilgili başlık kısımlarının
        /// üye bilgileri ile değişimi işlemi, global personmodelin p yi alması, timerın başlatılması
        /// ve designerda yapılan tasarımın hayata geçirilme işlemi burada yapılıyor.
        /// </summary>
        /// <param name="p"> UyeBulda bulunan üye buraya pass ediliyor. </param>
        /// <param name="bulForm"> UyeBul form kendisini bu constructora pass eder. </param>
        public UyeGirisiForm(PersonModel p, UyeBul bulForm)
        {
            bul = bulForm;

            InitializeComponent();

            isimLabel.Text = p.Adı;
            soyisimLabel.Text = p.Soyadı;
            tcLabel.Text = p.id;
            telefonLabel.Text = p.Telefon;
            emailLabel.Text = p.EmailAdress;
            cinsiyetLabel.Text = p.Cinsiyet;
            kiloLabel.Text = p.Kilo;
            boyLabel.Text = p.Boy;
            yasLabel.Text = p.Yas;
            saatLabel.Text = "";

            pmodel = p;
            StartTimer();
        }

        /// <summary>
        /// Bu form kapatıldığında geldiği form kapatıldığı için iki önceki form gösterilir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UyeGirisiForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            bul.giris.Show();
        }

        /// <summary>
        /// Giriş yapa basılırsa database'in ilgili fonksiyonuna pmodel pass edilir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void girisYapButton_Click(object sender, EventArgs e)
        {
            GlobalConfig.Connection.AddCheckInDate(pmodel);
        }

        /// <summary>
        /// Çıkış yapa basılırsa database'in ilgili fonksiyonuna pmodel pass edilir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cikisYapButton_Click(object sender, EventArgs e)
        {
            GlobalConfig.Connection.AddCheckOutDate(pmodel);
        }

        /// <summary>
        /// Formda saati gösterebilmek için her timer tikinde saat label'i şimdiki tarih ve saat ile değiştiriliyor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            saatLabel.Text = DateTime.Now.ToString();
        }

        /// <summary>
        /// Timer bu fonksiyon ile başlatılıyor. Her 1 saniyde timerın timer tick fonksiyou başlatılmak üzere timer aktif ediliyor.
        /// </summary>
        private void StartTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }
    }
}
