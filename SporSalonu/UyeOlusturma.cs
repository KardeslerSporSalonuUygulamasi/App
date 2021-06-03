using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SporSalonu;
using SporSalonuLib;
using SporSalonuLib.Models;


namespace SporSalonuUI
{
    /// <summary>
    /// Uye oluşturma formunun classı. Bu class form üzerindeki elemanlara erişip onları da kullanarak
    /// çeşitli işlemler yapabilmemizi sağlar.
    /// </summary>
    public partial class UyeOlusturma : Form
    {
        public bool guncelle = false;                   // Güncelleme durmunu kontrol etmeye yarar
        public bool yonlendirmeForm = false;            // Herhangi bir formdan mı yönlendirildi kontrol etmemize yarar
        public string finalProgram = "";                // Programın güncel halini formlar arasından güncelleyebilmemize yarar
        public PersonModel pmodel = new PersonModel();  // formlar arası üyeyi bilgilerine erişebilmemize yarar
        public bool loginFormAnswer = false;            // Şifre formunda şifre girişme durumunu kontrol edebilmeye yarar
        public bool loginFormFailedRespond = false;     // Şifre formunda yanlış şifre girilme durumunu kontrol eder
        public readonly Giris giris;                    // Giriş formuna erişebilmeye yarar.
        public readonly UyeBul bul;                     // Üye Bul formuna erişebilmeye yarar
        public bool adminMi = false;

        /// <summary>
        /// Giriş formundan erişilmesi ve normal modda üye kaydı yapılması durumu için Giriş formuna özel Constructor.
        /// </summary>
        /// <param name="girisForm"> 
        /// giris formuna erişebilmemiz için o form bu constructora erişirken kendisini de gönderir.
        /// </param>
        public UyeOlusturma(Giris girisForm)
        {
            giris = girisForm;
            InitializeComponent();
            uyeSilButton.Hide();
            adminPanel.Hide();

        }

        /// <summary>
        /// Uye bul formundan erişilmek için tasarlanmış Constructor.
        /// </summary>
        /// <param name="p"> PersonModel üye, UyeBul formundan gönderilir. </param>
        /// <param name="bulForm"> UyeBul form kendisine erişebilmemiz için kendisini constructora pass eder. </param>
        public UyeOlusturma(PersonModel p, UyeBul bulForm)
        {
            bul = bulForm;
            yonlendirmeForm = true;
            InitializeComponent();
            uyeSilButton.Hide();
            adminPanel.Hide();
        }

        /// <summary>
        /// UyeBul formundan isim yazıp Üye Bul'a bastığımızda olan üyeyi bu forma
        /// getiriyoruz. Olan üyeyi getirdiğimiz için Üye Oluştur butonunu Üyeyi Güncelle
        /// şeklinde değiştiriyoruz. Bu constructor da UyeBul forma özel olarak tasarlandı.
        /// </summary>
        /// <param name="p"> PersonModel üye, UyeBul formundan gönderilir. </param>
        /// <param name="i"> UyeBul a özel ikinci constructor oluşturabilmek için bir parametre. Tamamen işlevsiz. </param>
        /// <param name="bulForm"> UyeBul form kendisine erişebilmemiz için kendisini constructora pass eder. </param>
        public UyeOlusturma(PersonModel p, int i, UyeBul bulForm)
        {
            
            bul = bulForm;                          // bul UyeBul'a erişebilmemiz için bulForma eşitleniyor
            guncelle = true;                        // Var olan üye güncelleneceği için güncelle true yapılıyor
            InitializeComponent();                  // Designerda yapılan form bu fonksiyon ile hayata geçiriliyor.
            uyeSilButton.Show();                    // Üye silme butonu aktif hale getiriliyor
            adminPanel.Hide();                      // adminPanel şifre ile aktif hale geleceğinden saklanıyor
            isimTextBox.Text = p.Adı;               // ÜyeBul formda bulunan üye bilgileri gerkli yerlere yazılıyor.
            soyisimTextBox.Text = p.Soyadı;         // ..

            emailTextBox.Text = p.EmailAdress;
            telefonTextBox.Text = p.Telefon;
            kiloTextBox.Text = p.Kilo;
            yasComboBox.SelectedItem = p.Yas;
            cinsiyetComboBox.SelectedItem = p.Cinsiyet;
            boyTextBox.Text = p.Boy;

            tcTextBox.Hide();
            tcTextBox.Text = p.id;
            tcLabel.Text = p.id;
            finalProgram = GlobalConfig.Connection.GetWorkoutProgram(p); // Program ilgili fonksiyon ile csv dosyasından okunmak üzere p ile
            finalProgram = finalProgram.Replace(';', ' ');               // gönderiliyor. Ardından terminal ile gönderilmesinden dolayı yapılan
            finalProgram = finalProgram.Replace('*', '\n');              // değişiklikler geri alınıyor.

            abonelikTipiComboBox.Text = p.abonelikTipi;
            fiyatTextBox.Text = p.fiyat;
            string kayitTarihi = String.Join("",p.kayitTarihi.Split('\n', '\r'));
            kayitTarihiDateTimePicker.Text = kayitTarihi;

            dogumTarihiDateTimePicker.Text = p.DogumTarihi;

            pmodel = p;         // Farklı fonksiyonlardan ya da formlardan erişilebilmek üzere p global olan pmodele veriliyor.

            uyeOlusturButton.Text = "Üyeyi Güncelle"; // Üye oluşturun yazısı ve rengi değiştiriliyor.
            uyeOlusturButton.BackColor = Color.Red;
            uyeOlusturButton.ForeColor = Color.White;
        }

        /// <summary>
        /// Formda boş alan var mı diye kontrol yapan varsa başlıklarını kırmızı yoksa eski rengi mavi yapan fonksiyon.
        /// </summary>
        /// <returns>
        /// Boş alan varsa false yoksa true döner.
        /// </returns>
        private bool FormOnayi()
        {
            bool tamamlanmis = true;
            if (isimTextBox.Text.Length == 0) { isimLabel.ForeColor = Color.Red; tamamlanmis = false;  }
            else isimLabel.ForeColor = Color.DodgerBlue;

            if (soyisimTextBox.Text.Length == 0)    { soyisimLabel.ForeColor = Color.Red; tamamlanmis = false;  }
            else soyisimLabel.ForeColor = Color.DodgerBlue;

            if (emailTextBox.Text.Length == 0 || !emailTextBox.Text.Contains('@'))
            {
                emailLabel.ForeColor = Color.Red;
                tamamlanmis = false;
            }
            else emailLabel.ForeColor = Color.DodgerBlue;

            if (telefonTextBox.Text.Length == 0)    { telefonLabel.ForeColor = Color.Red; tamamlanmis = false;  }
            else telefonLabel.ForeColor = Color.DodgerBlue;

            if (yasComboBox.Text.Length == 0)       { yasLabel.ForeColor = Color.Red; tamamlanmis = false;  }
            else yasLabel.ForeColor = Color.DodgerBlue;

            if (kiloTextBox.Text.Length == 0)       { kiloLabel.ForeColor = Color.Red; tamamlanmis = false;  }
            else kiloLabel.ForeColor = Color.DodgerBlue;

            if (boyTextBox.Text.Length == 0)        { boyLabel.ForeColor = Color.Red; tamamlanmis = false;  }
            else boyLabel.ForeColor = Color.DodgerBlue;

            if (!dogumTarihiDateTimePicker.Checked) { dogumTarihiLabel.ForeColor = Color.Red; tamamlanmis = false;  }
            else dogumTarihiLabel.ForeColor = Color.DodgerBlue;

            if (!kayitTarihiDateTimePicker.Checked) { kayitTarihiLabel.ForeColor = Color.Red; tamamlanmis = false;  }
            else kayitTarihiLabel.ForeColor = Color.DodgerBlue;

            if (tcTextBox.Text.Length == 0)         { tcLabel.ForeColor = Color.Red; tamamlanmis = false;  }
            else tcLabel.ForeColor = Color.DodgerBlue;

            if (cinsiyetComboBox.Text.Length == 0)  { cinsiyetLabel.ForeColor = Color.Red; tamamlanmis = false;  }
            else cinsiyetLabel.ForeColor = Color.DodgerBlue;

            if (finalProgram.Length == 0 && !adminMi){ programıEkleButton.ForeColor = Color.Red; tamamlanmis = false;  }
            else programıEkleButton.ForeColor = Color.White;

            if (abonelikTipiComboBox.SelectedItem == null && !adminMi) { abonelikTipiLabel.ForeColor = Color.Red; tamamlanmis = false;  }
            else abonelikTipiLabel.ForeColor = Color.DodgerBlue;

            if (fiyatTextBox.Text.Length == 0 && !adminMi) { fiyatLabel.ForeColor = Color.Red; tamamlanmis = false;  }    
            else fiyatLabel.ForeColor = Color.DodgerBlue;

            if (!tamamlanmis) { return false; }

            return true;
        }

        /// <summary>
        /// Butona basıldığı zaman bir adet PersonModel nesnesi oluşturulur ve üyeye ait girilen bilgileri 
        /// bu nesneye veren ardından bu kişiyi oluşturması için gerekli fonksiyonu çağıran ve oluşturulabilirse
        /// oluşturulan programı da kayıt etmesi için diğer ilgili fonksiyınu çağiran fonksiyon.
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
                p = pmodel;
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
                
                p.kayitTarihi = kayitTarihiDateTimePicker.Text;
                

                if (adminMi)
                {
                    p.abonelikTipi = "-----";
                    p.fiyat = "-----";
                    p.Program = "-----|-----|-----|-----|-----|-----|-----";
                }
                else
                {
                    p.abonelikTipi = abonelikTipiComboBox.SelectedItem.ToString();
                    p.fiyat = fiyatTextBox.Text;
                    p.Program = finalProgram.Replace("\n", "*");
                }




                // İstenilen databasede kişi oluşturulması için Globalcofige
                // oradan da Database'e özel CreatePerson fonksiyonuna gider.
                if (!GlobalConfig.Connection.CreatePerson(p))
                {
                    return;
                }
                GlobalConfig.Connection.CreateWorkoutProgram(p);
                GlobalConfig.Connection.AddPassword(p, selectPswdTextBox.Text);
                this.Close();
                giris.Show();
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
                p.id = tcLabel.Text;
                
                p.kayitTarihi = kayitTarihiDateTimePicker.Text;

                if (adminMi)
                {
                    p.abonelikTipi = "-----";
                    p.fiyat = "-----";
                    p.Program = "-----|-----|-----|-----|-----|-----|-----";
                }
                else
                {
                    p.abonelikTipi = abonelikTipiComboBox.SelectedItem.ToString();
                    p.fiyat = fiyatTextBox.Text;
                    p.Program = finalProgram.Replace("\n", "*");
                }

                // İstenilen databasede kişi oluşturulması için Globalcofige
                // oradan da Database'e özel CreatePerson fonksiyonuna gider.
                GlobalConfig.Connection.UpdatePerson(p);
                GlobalConfig.Connection.CreateWorkoutProgram(p);
                
                GlobalConfig.Connection.AddPassword(p, selectPswdTextBox.Text);
                this.Close();
                guncelle = false;
                bul.giris.Show();
            }
            else
            {
                MessageBox.Show("Alanların hepsini doldurmalısınız!");
            }
        }

        /// <summary>
        /// Programı ekle butonuna basıldığında üyenin vücut kalitesini ölçebilmemize yarayan çeşitli hesaplamaları
        /// yapabilmemiz için ilgili yerlerin doldurulduğunu kontrol eden fonksiyon. Doldurulmayan alanların başlıklarını
        /// kırmızı renge döndürür.
        /// </summary>
        /// <returns> Tüm ilgili alanlar doldurulmuş ise true döner. Boş bir alan varsa false döner. </returns>
        private bool ProgramiEkleFormOnayi()
        {
            bool tamamlanmis = true;
            if (cinsiyetComboBox.Text.Length == 0)  { cinsiyetLabel.ForeColor = Color.Red; tamamlanmis = false;  }
            else cinsiyetLabel.ForeColor = Color.DodgerBlue;

            if (kiloTextBox.Text.Length == 0)       { kiloLabel.ForeColor = Color.Red; tamamlanmis = false;  }
            else kiloLabel.ForeColor = Color.DodgerBlue;

            if (boyTextBox.Text.Length == 0)        { boyLabel.ForeColor = Color.Red; tamamlanmis = false;  }
            else boyLabel.ForeColor = Color.DodgerBlue;

            if (!tamamlanmis) return false;

            return true;
        }

        /// <summary>
        /// ProgramiEkleFormOnayi() true dönerse Boy kilo cinsiyet global PersonModel aracılığı ile Hesaplamaları pythona
        /// yaptıracak ilgili fonksiyona gönderilir. Sonuç aynı global nesnenin hesaplamalar kısmına eşitlenir ve 
        /// ProgramOluşturForm adlı form açılarak bu hali hazırdaki form açılan formdan gösterilmek üzere saklanır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void programıEkleButton_Click(object sender, EventArgs e)
        {
            if (ProgramiEkleFormOnayi())
            {
                pmodel.Kilo = kiloTextBox.Text;
                pmodel.Cinsiyet = cinsiyetComboBox.SelectedItem.ToString();
                pmodel.Boy = boyTextBox.Text;
                pmodel.hesaplamalar = GlobalConfig.Connection.GetProgramCalculations(pmodel);
                ProgramOluşturForm frm = new ProgramOluşturForm(this);
                frm.Show();
                this.Hide(); 
            }
            else
            {
                MessageBox.Show("Programı ekle butonu için Cinsiyet, Boy ve Kilo alanlarını doldurunuz!", "Boş alan!");
            }
        }
        
        /// <summary>
        /// Eğer bu form herhangi bir yolla kapatılırsa hangi formdan gelindiyse o form gösterilir. Eğer gelinen form da
        /// kapatıldıysa o zaman iki önceki forma gidilir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UyeOlusturma_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (guncelle || yonlendirmeForm)
            {
                bul.giris.Show();
                return;
            }
            giris.Show();
        }

        /// <summary>
        /// Üye sil butonuna basılırsa databaseden de silinmesi için ilgili fonksiyon çağırılır. Ve bu form kapatılır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uyeSilButton_Click(object sender, EventArgs e)
        {
            GlobalConfig.Connection.RemovePerson(pmodel);
            this.Close();
        }

        /// <summary>
        /// Formun üye oluşturmayla alakalı herhangi bir alanından ENTER tuşuna basıldığında Oluştur butanuna basılması
        /// ve bunun için onay istenmesini sağlaya fonksiyon.
        /// </summary>
        /// <param name="e"></param>
        private void isKeyEnter(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DialogResult YesOrNo = MessageBox.Show("Üyeyi kaydetmek üzeresiniz! Emin misiniz?", "Onay?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (YesOrNo == DialogResult.Yes)
                {
                    uyeOlusturButton_Click(this, EventArgs.Empty); 
                }
                else
                {
                    return;
                }
            }
        }
        #region Enter tuşunu algılama
        private void isimTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            isKeyEnter(e);
        }

        private void soyisimTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            isKeyEnter(e);
        }

        private void emailTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            isKeyEnter(e);
        }

        private void tcTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            isKeyEnter(e);
        }

        private void telefonTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            isKeyEnter(e);
        }

        private void cinsiyetComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            isKeyEnter(e);
        }

        private void kiloTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            isKeyEnter(e);
        }

        private void yasComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            isKeyEnter(e);
        }

        private void boyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            isKeyEnter(e);
        }

        private void dogumTarihiDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            isKeyEnter(e);
        }

        private void fiyatTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            isKeyEnter(e);
        }

        #endregion

        /// <summary>
        /// admin yapılmak istenen kişinin şifreye sahip olması için bir panel açılır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void adminYapButton_Click(object sender, EventArgs e)
        {
            adminPanel.Show();
            adminMi = true;
        }

        /// <summary>
        /// Admin yapılmak istenen kişi şifresini girdikten sonra ENTER tuşunu bastıktan sonra
        /// admin paneli gizlenir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectPswdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && System.Text.RegularExpressions.Regex.IsMatch(selectPswdTextBox.Text, "[0-9]"))
            {
                pmodel.passwd = selectPswdTextBox.Text;
                adminPanel.Hide();
                abonelikGroupBox.Hide();
                programıEkleButton.Hide();
            }
            else if (e.KeyCode == Keys.Enter && System.Text.RegularExpressions.Regex.IsMatch(selectPswdTextBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Şifre sadece rakamlar içermelidir!", "Hata");
            }
        }
    }
}
