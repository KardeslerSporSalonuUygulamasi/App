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
using SporSalonuUI;
using SporSalonuLib;

namespace SporSalonu
{
    public partial class ProgramOluşturForm : Form
    {
        public readonly UyeOlusturma uye;
        public readonly UyeBul uyeBul;
        public bool fromUyeBulForm = false;
        public bool fromUyeOlusturlForm = false;
        private string[] hesaplamalar;


        public string endString = "";

        string baslangıc = 
                "Koşu bandı : 10 Dakika = Kardiyo\n"    +
                "Eliptik Bisiklet : 5 Dakika = Kardiyo\n"           +
                "Leg Press :  3 Set 10 Tekrar = Bacak\n"            +
                "Calf Raises : 3 Set 10 Tekrar = Kalf\n"            +
                "Dumbbell Bench Press: 3 set 10 Tekrar = Göğüs\n"   +
                "Dumbbell Shoulder Press: 3 Set 10 Tekrar = Omuz\n" +
                "Lat Pulldown : 3 Set 10 Tekrar = Sırt\n"           +
                "Barbell Curl : 3 Set 10 Tekrar = Ön Kol\n"         +
                "Triceps Push Down : 3 Set 10 Tekrar = Arka Kol\n"  +
                "Crunch : 1 Set Max. Tekrar = Karın";

        string orta = 
                "Koşu bandı : 6 derece eğim  3-6 km/s hızda interval koşu 13 dakika.\n" +
                "Squat : 3 Set 10 Tekrar\n"                     +
                "Bench Press : 3 Set 10 Tekrar\n"               +
                "Dumbbell Fly : 3 Set 10 Tekrar\n"              +
                "Barfiks: 3 Set Maksimum Tekrar\n"              +
                "Barbell Shoulder Press : 3 Set 10 Tekrar\n"    +
                "Alternating Dumbbell Curl : 3 Set 10 Tekrar\n" +
                "Triceps Extension : 3 Set 10 Tekrar\n"         +
                "Cable Crunch : 3 Set Maksimum Tekrar";
        
        string ileri = 
                "Koşu bandı : 4 derece eğim 20 Dakika = Kardiyo\n"    +
                "Eliptik Bisiklet : 15 Dakika = Kardiyo\n"           +
                "Leg Press :  5 Set 15 Tekrar = Bacak\n"            +
                "Calf Raises : 5 Set 20 Tekrar = Kalf\n"            +
                "Dumbbell Bench Press: 5 set 15 Tekrar = Göğüs\n"   +
                "Dumbbell Shoulder Press: 5 Set 20 Tekrar = Omuz\n" +
                "Lat Pulldown : 5 Set 20 Tekrar = Sırt\n"           +
                "Barbell Curl : 5 Set 20 Tekrar = Ön Kol\n"         +
                "Triceps Push Down : 5 Set 20 Tekrar = Arka Kol\n"  +
                "Crunch : 1 Set Max. Tekrar = Karın";

        string ozel = 
                "Koşu bandı : \n"    +
                "Eliptik Bisiklet : \n"           +
                "Leg Press : \n"            +
                "Calf Raises : \n"            +
                "Dumbbell Bench Press: \n"   +
                "Dumbbell Shoulder Press: \n" +
                "Lat Pulldown : \n"           +
                "Barbell Curl : \n"         +
                "Triceps Push Down : \n"  +
                "Crunch : ";
               

        public ProgramOluşturForm(UyeOlusturma uyeForm)
        {
            uye = uyeForm;
            fromUyeOlusturlForm = true;
            InitializeComponent();
            string[] fazlaUzun;
            fazlaUzunLabel.Text = "";

            hesaplamalar = uye.pmodel.hesaplamalar.Replace(';',' ').Split('|');
            labelGuncelle1.Text = hesaplamalar[0];
            labelGuncelle2.Text = hesaplamalar[1];
            if (hesaplamalar[2].Length > 50)
            {
                fazlaUzun = hesaplamalar[2].Split(',');
                labelGuncelle3.Text = fazlaUzun[0];
                fazlaUzunLabel.Text = fazlaUzun[1];
            }
            else
                labelGuncelle3.Text = hesaplamalar[2];
            

            if (uye.guncelle)
            {
                string[] splittedFinalProgram;
                splittedFinalProgram = uye.finalProgram.Split('|');

                if(splittedFinalProgram.Length < 7) 
                { 
                    MessageBox.Show("Bu üyenin programı bulunamamıştır! Yeni Programını oluşturmak için lütfen \"OK\" basiniz!", "Hata");
                    pazartesiRchTextBox.Text    = "";
                    saliRichTextBox.Text        = "";
                    carsambaRichTextBox.Text    = "";
                    persembeRİchTextBox.Text    = "";
                    cumaRichTextBox.Text        = "";
                    cumartesiRichTextBox.Text   = "";
                    pazaProgramRichBox.Text     = "";
                    return;
                }

                pazartesiRchTextBox.Text = splittedFinalProgram[0];
                saliRichTextBox.Text = splittedFinalProgram[1];
                carsambaRichTextBox.Text = splittedFinalProgram[2];
                persembeRİchTextBox.Text = splittedFinalProgram[3];
                cumaRichTextBox.Text = splittedFinalProgram[4];
                cumartesiRichTextBox.Text = splittedFinalProgram[5];
                pazaProgramRichBox.Text = splittedFinalProgram[6];


            }
        }
        public ProgramOluşturForm(UyeBul uyeBulForm)
        {
            uyeBul = uyeBulForm;
            fromUyeBulForm = true;
            InitializeComponent();
            string[] fazlaUzun;
            fazlaUzunLabel.Text = "";


            hesaplamalar = uyeBul.pModel.hesaplamalar.Replace(';',' ').Split('|');
            labelGuncelle1.Text = hesaplamalar[0];
            labelGuncelle2.Text = hesaplamalar[1];
            if (hesaplamalar[2].Length > 50)
            {
                fazlaUzun = hesaplamalar[2].Split(',');
                labelGuncelle3.Text = fazlaUzun[0];
                fazlaUzunLabel.Text = fazlaUzun[1];
            }
            else
                labelGuncelle3.Text = hesaplamalar[2];


            string[] splittedFinalProgram;
            splittedFinalProgram = uyeBul.pModel.Program.Split('|');

            if(splittedFinalProgram.Length < 7) 
            { 
                MessageBox.Show("Bu üyenin programı bulunamamıştır! Yeni Programını oluşturmak için lütfen \"OK\" basiniz!", "Hata");
                pazartesiRchTextBox.Text    = "";
                saliRichTextBox.Text        = "";
                carsambaRichTextBox.Text    = "";
                persembeRİchTextBox.Text    = "";
                cumaRichTextBox.Text        = "";
                cumartesiRichTextBox.Text   = "";
                pazaProgramRichBox.Text     = "";
                return;
            }

            pazartesiRchTextBox.Text = splittedFinalProgram[0];
            saliRichTextBox.Text = splittedFinalProgram[1];
            carsambaRichTextBox.Text = splittedFinalProgram[2];
            persembeRİchTextBox.Text = splittedFinalProgram[3];
            cumaRichTextBox.Text = splittedFinalProgram[4];
            cumartesiRichTextBox.Text = splittedFinalProgram[5];
            pazaProgramRichBox.Text = splittedFinalProgram[6];
        }

        private void programComboBox_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (programComboBox.SelectedIndex == 0)
            {
                switch (gunlerProgramTabControl.SelectedTab.Text)
                {
                    
                    case "*Pazartesi*": case "Pazartesi":  pazartesiRchTextBox.Text =  baslangıc;  break;
                    case "*Salı*":      case "Salı":       saliRichTextBox.Text =      baslangıc;  break;
                    case "*Çarşamba*":  case "Çarşamba":   carsambaRichTextBox.Text =  baslangıc;  break;
                    case "*Perşembe*":  case "Perşembe":   persembeRİchTextBox.Text =  baslangıc;  break;
                    case "*Cuma*":      case "Cuma":       cumaRichTextBox.Text =      baslangıc;  break;
                    case "*Cumartesi*": case "Cumartesi":  cumartesiRichTextBox.Text = baslangıc;  break;
                    case "*Pazar*":     case "Pazar":      pazaProgramRichBox.Text =   baslangıc;  break;

                    default: break;
                }
            }
            else if (programComboBox.SelectedIndex == 1)
            {

                switch (gunlerProgramTabControl.SelectedTab.Text)
                {
                    case "*Pazartesi*": case "Pazartesi":  pazartesiRchTextBox.Text =  orta;  break;
                    case "*Salı*":      case "Salı":       saliRichTextBox.Text =      orta;  break;
                    case "*Çarşamba*":  case "Çarşamba":   carsambaRichTextBox.Text =  orta;  break;
                    case "*Perşembe*":  case "Perşembe":   persembeRİchTextBox.Text =  orta;  break;
                    case "*Cuma*":      case "Cuma":       cumaRichTextBox.Text =      orta;  break;
                    case "*Cumartesi*": case "Cumartesi":  cumartesiRichTextBox.Text = orta;  break;
                    case "*Pazar*":     case "Pazar":      pazaProgramRichBox.Text =   orta;  break;
                    default: break;
                }
            }
            else if (programComboBox.SelectedIndex == 2)
            {
                switch (gunlerProgramTabControl.SelectedTab.Text)
                {
                    case "*Pazartesi*": case "Pazartesi":  pazartesiRchTextBox.Text =  ileri;  break;
                    case "*Salı*":      case "Salı":       saliRichTextBox.Text =      ileri;  break;
                    case "*Çarşamba*":  case "Çarşamba":   carsambaRichTextBox.Text =  ileri;  break;
                    case "*Perşembe*":  case "Perşembe":   persembeRİchTextBox.Text =  ileri;  break;
                    case "*Cuma*":      case "Cuma":       cumaRichTextBox.Text =      ileri;  break;
                    case "*Cumartesi*": case "Cumartesi":  cumartesiRichTextBox.Text = ileri;  break;
                    case "*Pazar*":     case "Pazar":      pazaProgramRichBox.Text =   ileri;  break;
                    default: break;
                }
            }
            else if (programComboBox.SelectedIndex == 3)
            {
                switch (gunlerProgramTabControl.SelectedTab.Text)
                {
                    case "*Pazartesi*": case "Pazartesi":  pazartesiRchTextBox.Text =  ozel;  break;
                    case "*Salı*":      case "Salı":       saliRichTextBox.Text =      ozel;  break;
                    case "*Çarşamba*":  case "Çarşamba":   carsambaRichTextBox.Text =  ozel;  break;
                    case "*Perşembe*":  case "Perşembe":   persembeRİchTextBox.Text =  ozel;  break;
                    case "*Cuma*":      case "Cuma":       cumaRichTextBox.Text =      ozel;  break;
                    case "*Cumartesi*": case "Cumartesi":  cumartesiRichTextBox.Text = ozel;  break;
                    case "*Pazar*":     case "Pazar":      pazaProgramRichBox.Text =   ozel;  break;
                    default: break;
                }
            }
        }

        private bool FormOnayi()
        {
            bool tamamlanmis = true;
            if (pazartesiRchTextBox.Text.Length == 0)   { pazartesiTabPage.Text = "*Pazartesi*" ;   tamamlanmis = false; } else pazartesiTabPage.Text = "Pazartesi" ; 
            if (saliRichTextBox.Text.Length == 0)       { saliTabPage.Text      = "*Salı*"      ;   tamamlanmis = false; } else saliTabPage.Text      = "Salı"      ;
            if (carsambaRichTextBox.Text.Length == 0)   { carsambaTabPage.Text  = "*Çarşamba*"  ;   tamamlanmis = false; } else carsambaTabPage.Text  = "Çarşamba"  ;
            if (persembeRİchTextBox.Text.Length == 0)   { persembeTabPage.Text  = "*Perşembe*"  ;   tamamlanmis = false; } else persembeTabPage.Text  = "Perşembe"  ;
            if (cumaRichTextBox.Text.Length == 0)       { cumaTabPage.Text      = "*Cuma*"      ;   tamamlanmis = false; } else cumaTabPage.Text      = "Cuma"      ;
            if (cumartesiRichTextBox.Text.Length == 0)  { cumartesiTabPage.Text = "*Cumartesi*" ;   tamamlanmis = false; } else cumartesiTabPage.Text = "Cumartesi" ;
            if (pazaProgramRichBox.Text.Length == 0)    { pazarTabPage.Text     = "*Pazar*"     ;   tamamlanmis = false; } else pazarTabPage.Text     = "Pazar"     ;
            if (!tamamlanmis) return false;
            return true;
        }

        private void programıEkleButton_Click(object sender, EventArgs e)
        {
            if(!FormOnayi())
            {
                MessageBox.Show("Lütfen program kısmını doldurunuz!", "Boş alan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(fromUyeOlusturlForm)
            {

                uye.finalProgram = $"{pazartesiRchTextBox.Text}|{saliRichTextBox.Text}|{carsambaRichTextBox.Text}|" +
                    $"{persembeRİchTextBox.Text}|{cumaRichTextBox.Text}|{cumartesiRichTextBox.Text}|{pazaProgramRichBox.Text}";


                this.Close();
                uye.Show();
            }
            else if (fromUyeBulForm)
            {
                uyeBul.pModel.Program = ($"{pazartesiRchTextBox.Text}|{saliRichTextBox.Text}|{carsambaRichTextBox.Text}|" +
                    $"{persembeRİchTextBox.Text}|{cumaRichTextBox.Text}|{cumartesiRichTextBox.Text}|{pazaProgramRichBox.Text}")
                    .Replace('\n', '*');
                GlobalConfig.Connection.CreateWorkoutProgram(uyeBul.pModel);


                this.Close();
                uyeBul.giris.Show();
            }
            
        }

        private void ProgramOluşturForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (fromUyeOlusturlForm)
            {
                uye.Show(); 
            }
            else if (fromUyeBulForm)
            {
                uyeBul.giris.Show();
            }
        }

        private void carsambaTabPage_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunlerProgramTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            programComboBox.Text = "";
        }
    }
}
