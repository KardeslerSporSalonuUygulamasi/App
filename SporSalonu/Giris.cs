using SporSalonu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonuUI
{
    public partial class Giris : Form
    {
        public bool loginFormAnswer;
        public bool loginFormFailedRespond;

        public Giris()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void YeniUyeButton_Click(object sender, EventArgs e)
        {
            if (!loginFormAnswer && !loginFormFailedRespond) { GirisYap(); return; }
            else if (loginFormFailedRespond) { MessageBox.Show("Yanlış şifre!", "Hata"); loginFormFailedRespond = false; return; }

            loginFormAnswer = false;
            UyeOlusturma frm = new UyeOlusturma(this);
            frm.Show();
            this.Hide(); // Formu saklıyoruz
        }

        private void UyeSecButton_Click(object sender, EventArgs e)
        {
            
            UyeBul frm = new UyeBul(this);
            frm.Show();
            this.Hide();
        }

        private void GirisYap()
        {
            LoginForm lgnfrm = new LoginForm(this);
            lgnfrm.Show();
            return;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
