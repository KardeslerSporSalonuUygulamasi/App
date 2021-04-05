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
    public partial class UyeBul : Form
    {
        public UyeBul()
        {
            InitializeComponent();
        }

        /// <summary>
        /// UyeBul formunda arama kısmına tam ad yazdığımızda uyeyi bulmamıza yarayacak fonk.
        /// Bu fonksiyon Üyeyi bularak bizi Üye Oluştur formuna gönderir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bulButton_Click(object sender, EventArgs e)
        {
            // TODO - Sadece ad girildiğinde aynı addaki üyeleri listeleyebilecek şekilde düzenlenebilir.
            PersonModel p = new PersonModel();
            p.Adı = uyeBulTextBox.Text;

            p = GlobalConfig.Connection.GetPerson(p);

            UyeOlusturma frm = new UyeOlusturma(p, 1);
            frm.Show();
            
            this.Close();
        }
    }
}
