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
    public partial class UyeOlusturma : Form
    {
        public bool guncelle = false;
        public string finalProgram = "";
        public readonly ProgramOluşturForm prolusturfrm;
        public PersonModel pmodel;

        public UyeOlusturma()
        {
            InitializeComponent();
            uyeSilButton.Hide();
            // TODO - Bu alanları programı yapmak kolay olsun diye yaptın. SİL!
            isimTextBox.Text = "ahmet yusuf";
            soyisimTextBox.Text = "birinci";
            emailTextBox.Text = "email@mail.com";
            telefonTextBox.Text = "0321848245";
            kiloTextBox.Text = "20";
            yasComboBox.Text = "45";
            boyTextBox.Text = "186";


        }

        /// <summary>
        /// UyeBul formundan isim yazıp Üye Bul'a bastığımızda olan üyeyi bu forma
        /// getiriyoruz. Olan üyeyi getirdiğimiz için Üye Oluştur butonunu Üyeyi Güncelle
        /// şeklinde değiştiriyoruz.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="i"></param>
        public UyeOlusturma(PersonModel p, int i)
        {
            guncelle = true;
            InitializeComponent();
            uyeSilButton.Show();
            isimTextBox.Text = p.Adı;
            soyisimTextBox.Text = p.Soyadı;

            emailTextBox.Text = p.EmailAdress;
            telefonTextBox.Text = p.Telefon;
            kiloTextBox.Text = p.Kilo;
            yasComboBox.SelectedItem = p.Yas;
            cinsiyetComboBox.SelectedItem = p.Cinsiyet;
            boyTextBox.Text = p.Boy;
            tcTextBox.Text = p.id;
            finalProgram = p.Program;

            pmodel = p;

            uyeOlusturButton.Text = "Üyeyi Güncelle";
            uyeOlusturButton.BackColor = Color.Red;
            uyeOlusturButton.ForeColor = Color.White;
        }

        /// <summary>
        /// Formda boş alan var mı diye kontrol yapan fonksiyon.
        /// </summary>
        /// <returns>
        /// Boş alan varsa false yoksa true döner.
        /// </returns>
        private bool FormOnayi()
        {
            if (isimTextBox.Text.Length == 0)       return false;

            if (soyisimTextBox.Text.Length == 0)    return false;

            if (emailTextBox.Text.Length == 0)      return false;

            if (telefonTextBox.Text.Length == 0)    return false;

            if (yasComboBox.Text.Length == 0)       return false;

            if (kiloTextBox.Text.Length == 0)       return false;

            if (!dogumTarihiDateTimePicker.Checked) return false;

            if (tcTextBox.Text.Length == 0)         return false;

            if (cinsiyetComboBox.Text.Length == 0)  return false;

            if (finalProgram.Length == 0)           return false;


            return true;
        }

        /// <summary>
        /// Butona basıldığı zaman bir adet PersonModel nesnesi oluşturulur
        /// ve parametrelerini teker teker teker verir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uyeOlusturButton_Click(object sender, EventArgs e)
        {
            // %90 gereksiz if statement
            //if(uyeOlusturButton.Text == "Üyeyi Güncelle") { guncelle = true; }

            if (FormOnayi() && !guncelle)
            {
                PersonModel p = new PersonModel();

                p.Adı = isimTextBox.Text;
                p.Soyadı = soyisimTextBox.Text;
                p.EmailAdress = emailTextBox.Text;
                p.Telefon = telefonTextBox.Text;
                p.Kilo = kiloTextBox.Text;
                p.Yas = (string)yasComboBox.SelectedItem;
                p.DogumTarihi = dogumTarihiDateTimePicker.Text;
                p.Boy = boyTextBox.Text;
                p.Cinsiyet = (string)cinsiyetComboBox.SelectedItem;
                p.id = tcTextBox.Text;
                p.Program = finalProgram.Replace("\n", "*");


                GlobalConfig.Connection.CreateWorkoutProgram(p, p.Program);

                // İstenilen databasede kişi oluşturulması için Globalcofige
                // oradan da Database'e özel CreatePerson fonksiyonuna gider.
                GlobalConfig.Connection.CreatePerson(p);


                // TODO - Bu alanları programı yaparken kolaylık olsun diye kapadın. AÇ!

                // Alanlar tekrar boş haline geri döndürülüyor.
                //isimTextBox.Text = "";
                //soyisimTextBox.Text = "";
                //emailTextBox.Text = "";
                //telefonTextBox.Text = "";
                //kiloTextBox.Text = "";
                //yasComboBox.Text = "";
                //boyTextBox.Text = "";
            }
            else if(FormOnayi() && guncelle)
            {
                PersonModel p = new PersonModel();

                p.Adı = isimTextBox.Text;
                p.Soyadı = soyisimTextBox.Text;
                p.EmailAdress = emailTextBox.Text;
                p.Telefon = telefonTextBox.Text;
                p.Kilo = kiloTextBox.Text;
                p.Yas = (string)yasComboBox.SelectedItem;
                p.DogumTarihi = dogumTarihiDateTimePicker.Text;
                p.Boy = boyTextBox.Text;
                p.Cinsiyet = (string)cinsiyetComboBox.SelectedItem;
                p.id = tcTextBox.Text;
                p.Program = finalProgram.Replace("\n", "*");

                GlobalConfig.Connection.CreateWorkoutProgram(p, finalProgram);


                // İstenilen databasede kişi oluşturulması için Globalcofige
                // oradan da Database'e özel CreatePerson fonksiyonuna gider.
                GlobalConfig.Connection.UpdatePerson(p);
                this.Close();
                guncelle = false;
            }
            else
            {
                MessageBox.Show("Alanların hepsini doldurmalısınız!");
            }
        }

        private void programıEkleButton_Click(object sender, EventArgs e)
        {
            ProgramOluşturForm frm = new ProgramOluşturForm(this);
            frm.Show();
        }

        private void UyeOlusturma_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Giris frm = new Giris();
            //frm.Show();
        }

        private void uyeSilButton_Click(object sender, EventArgs e)
        {
            GlobalConfig.Connection.RemovePerson(pmodel);
            this.Close();
        }
    }
}
