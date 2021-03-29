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
        public Giris()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void YeniUyeButton_Click(object sender, EventArgs e)
        {
            UyeOlusturma frm = new UyeOlusturma();
            frm.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void UyeSecButton_Click(object sender, EventArgs e)
        {
            UyeBul frm = new UyeBul();
            frm.Show();
        }
    }
}
