using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SporSalonuLib;
using SporSalonuLib.Models;


namespace SporSalonuUI
{
    public partial class UyeOlusturma : Form
    {
        public UyeOlusturma()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void UyeOlusturma_Load(object sender, EventArgs e)
        {

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

            if (programRichTextBox.Text.Length == 0) return false;

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
            if (FormOnayi())
            {
                PersonModel p = new PersonModel();

                p.Adı = isimTextBox.Text;
                p.Soyadı = soyisimTextBox.Text;
                p.EmailAdress = emailTextBox.Text;
                p.Telefon = telefonTextBox.Text;
                p.Kilo = kiloTextBox.Text;
                p.Yas = (string)yasComboBox.SelectedItem;

                // İstenilen databasede kişi oluşturulması için Globalcofige
                // oradan da CreatePerson fonksiyonuna gider.
                GlobalConfig.Connection.CreatePerson(p);

                // Alanlar tekrar boş haline geri döndürülüyor.
                isimTextBox.Text = "";
                soyisimTextBox.Text = "";
                emailTextBox.Text = "";
                telefonTextBox.Text = "";
                kiloTextBox.Text = "";
                yasComboBox.Text = "";
            }
            else
            {
                MessageBox.Show("Alanların hepsini doldurmalısınız!");
            }
        }
    }
}
