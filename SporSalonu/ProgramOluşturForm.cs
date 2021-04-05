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
    public partial class ProgramOluşturForm : Form
    {
        string baslangıc = " Koşu bandı : 10 Dakika = Kardiyo\n"    +
                "Eliptik Bisiklet : 5 Dakika = Kardiyo\n"           +
                "Leg Press :  3 Set 10 Tekrar = Bacak\n"            +
                "Calf Raises : 3 Set 10 Tekrar = Kalf\n"            +
                "Dumbbell Bench Press: 3 set 10 Tekrar = Göğüs\n"   +
                "Dumbbell Shoulder Press: 3 Set 10 Tekrar = Omuz\n" +
                "Lat Pulldown : 3 Set 10 Tekrar = Sırt\n"           +
                "Barbell Curl : 3 Set 10 Tekrar = Ön Kol\n"         +
                "Triceps Push Down : 3 Set 10 Tekrar = Arka Kol\n"  +
                "Crunch : 1 Set Max. Tekrar = Karın";

        string orta = "Koşu bandı : 6 derece eğim  3-6 km/s hızda interval koşu 13 dakika.\n" +
                "Squat : 3 Set 10 Tekrar\n"                     +
                "Bench Press : 3 Set 10 Tekrar\n"               +
                "Dumbbell Fly : 3 Set 10 Tekrar\n"              +
                "Barfiks: 3 Set Maksimum Tekrar\n"              +
                "Barbell Shoulder Press : 3 Set 10 Tekrar\n"    +
                "Alternating Dumbbell Curl : 3 Set 10 Tekrar\n" +
                "Triceps Extension : 3 Set 10 Tekrar\n"         +
                "Cable Crunch : 3 Set Maksimum Tekrar";
               

        public ProgramOluşturForm()
        {
            InitializeComponent();

            
        }

        private void programComboBox_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (programComboBox.SelectedIndex == 0)
            {
                programRichTextBox.Text = baslangıc;
            }
            else if (programComboBox.SelectedIndex == 1)
            {
                programRichTextBox.Text = orta;
            }
        }
    }
}
