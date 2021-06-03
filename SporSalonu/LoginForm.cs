using SporSalonuLib;
using SporSalonuUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonu
{
    /// <summary>
    /// Bu Form admin işlerinin yapılabilmesi için basit bir şifre girme arayüzü sunar.
    /// </summary>
    public partial class LoginForm : Form
    {
        public readonly UyeBul bul;     // UyeBul formuna erişebilmemizi sağlar
        public readonly Giris giris;    // Giris formuna erişebilmemizi sağlar
        private string controlPaswd;    // Şifre kontrol sonucu için dönülen stringi ifade eder
        private int hangi = 0;          // hangi formdan gelindiğini ayırt etmeye yarar

        /// <summary>
        /// Kullanılmayan boş constructor
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// UyeBul formundan erişilen constructor. hangi değişkeni 1 yapılır. Ve görsel tasarım için InitializeComponent()
        /// çağırılır.
        /// </summary>
        /// <param name="uyeBul"> UyeBUl formu çağırırken kendini pass eder. </param>
        public LoginForm(UyeBul uyeBul)
        {
            bul = uyeBul;
            hangi = 1;
            InitializeComponent();
        }

        /// <summary>
        /// Giris formundan erişilmesi için tasarlanan constructor. hangi değişkeni 2 yapılır. Ve görsel tasarım için InitializeComponent()
        /// çağırılır.
        /// </summary>
        /// <param name="girisForm"> Giris formu çağırırken kendini pass eder. </param>
        public LoginForm(Giris girisForm)
        {
            giris = girisForm;
            hangi = 2;
            InitializeComponent();
        }

        /// <summary>
        /// Eğer ENTER tuşuna basıldığında geldiği forma göre bir if statementa giren ve şifre kontrolü için gerekli kontrolleri yapan fonksiyon
        /// </summary>
        /// <param name="e"></param>
        private void isKeyEnter(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape) { this.Close(); return; }

            if(e.KeyCode == Keys.Enter && hangi == 1)
            {
                controlPaswd = GlobalConfig.Connection.GetPassword(sifrelTextBox.Text);
                if (controlPaswd == "sifre mevcut") bul.loginFormAnswer = true;
                else bul.loginFormFailedRespond = true;
                this.Close();
                bul.bulButton_Click(this, EventArgs.Empty);
                

            }

            if(e.KeyCode == Keys.Enter && hangi == 2)
            {
                controlPaswd = GlobalConfig.Connection.GetPassword(sifrelTextBox.Text);
                if (controlPaswd == "sifre mevcut") giris.loginFormAnswer = true;
                else giris.loginFormFailedRespond = true;
                this.Close();
                giris.YeniUyeButton_Click(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// ENTER tuşuna basılırsa kontrol yapar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sifrelTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            isKeyEnter(e);
        }
    }
}
