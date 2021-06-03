using SporSalonuLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;
using System.Windows;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using SporSalonuLib;
using System.Windows.Forms;

namespace SporSalonuLib.DataAccess
{
    /// <summary>
    ///  Bu classın adı Python kodunu çalıştırdığı ve csv dosyasına kayıt yapıldığı için PyCsvConnector yapılmıştır.
    /// PyCsvConnector'un amacı .NetFramework ile Python arasında bir köprü olmak ve fonksiyonlarıyla python ile 
    /// yazılmış bir kodu çalıştırarak veri depolama işlerini yapmasktır ve bunun için gerekli bilgileri terminale 
    /// yazdırmak suretiyle göndermektir.
    /// </summary>
    public class PyCsvConnector : IDataConnection
    {
        /// <summary>
        /// Verilen PersonModeli ConvertToPersonModels() fonksiyonu stringe dönüştürdükten sonra
        /// python scriptimizi dönülen stringi argüman olarak vererek çalıştırıyoruz ve pythonun 
        /// terminale yazdırdığını okuyoruz.
        /// </summary>
        /// <param name="model"></param>
        public bool CreatePerson(PersonModel model)
        {
            string personInfo= ConvertToPersonModels(model);

            Console.WriteLine(personInfo);

            string fileName = @"Proje1.py" + personInfo;
            Process p = new Process();

            p.StartInfo = new ProcessStartInfo(@"python.exe", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Console.WriteLine(output); 

            if(output == $"{model.id} numaralı üye oluşturuluyor.\r\n")
            {
                MessageBox.Show("Üye başarıyla oluşturulmuştur!", "Başarılı ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show($"{model.id} kimlik numaralı bir üye zaten bulunmakta!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Gelen PersonModeli ConvertToPersonModelsForUpdate() fonksiyou ile stringe dönüştürüldükten sonra
        /// python dosyasına gönderiyoruz. Böylece olan bir üyenin değiştirilmiş kaydını python ile csv
        /// dosyasına yazdırmış oluyoruz.
        /// </summary>
        /// <param name="model"></param>
        public void UpdatePerson(PersonModel model)
        {
            string personInfo = ConvertToPersonModelsForUpdate(model);

            Console.WriteLine(personInfo);

            string fileName = @"Proje1.py" + personInfo;
            Process p = new Process();

            p.StartInfo = new ProcessStartInfo(@"python.exe", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Console.WriteLine(output);

            if (output == "Üye başarıyla güncellenmiştir.\r\n")
            {
                MessageBox.Show("Üye başarıyla günclelenmiştir!", "Başarılı güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            //Console.ReadLine();

        }

        /// <summary>
        /// PersonModel ile gelen üye kaydının id sini "s" argümanı ile birlikte python dosyasına gönderiyoruz.
        /// Python csv dosyasının içinden id ile kaydı bulur ve kişiyi siler.
        /// </summary>
        /// <param name="model"></param>
        public void RemovePerson(PersonModel model)
        {
            {
                string personInfo = $" s { model.id }";

                Console.WriteLine(personInfo);

                string fileName = @"Proje1.py" + personInfo;
                Process p = new Process();

                p.StartInfo = new ProcessStartInfo(@"python.exe", fileName)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();

                Console.WriteLine(output);

                //MessageBox.Show("Üye başarıyla oluşturulmuştur!");
                MessageBox.Show("Üye başarıyla silinmiştir!", "Başarılı silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// PersonModel ile gelen üye kaydından id ile program kısmının boşluklarının ; ile değiştirilmiş hali
        /// "pw" (program write) argümanı ile python dosyası ile Programlar klasörü altına id adlı csv dosyasına
        /// yazdırılıyor.
        /// </summary>
        /// <param name="model"></param>
        public void CreateWorkoutProgram(PersonModel model)
        {
            
            Console.WriteLine(model.Program);

            string fileName = @"Proje1.py pw " + model.id + " " + model.Program.Replace(' ', ';');
            Process p = new Process();

            p.StartInfo = new ProcessStartInfo(@"python.exe", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Console.WriteLine(output);

            //MessageBox.Show("Üye başarıyla oluşturulmuştur!");
            MessageBox.Show("Program başarıyla eklendi!", "Başarılı ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        /// <summary>
        /// PersonModel ile gelen üye kaydının id si ile "pr" (program read) argümanı ile python dosyasına gönderiliyor.
        /// Python ile Programlar klasörü altında id adlı csv klasörü aranıyor. Bulunursa konsola belirli bir yazdırılıyor.
        /// Biz de konsoldan programı okuyoruz ve döndürüyoruz.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetWorkoutProgram(PersonModel model)
        {

            string fileName = @"Proje1.py pr " + model.id;
            Process p = new Process();

            p.StartInfo = new ProcessStartInfo(@"python", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Console.WriteLine(output);

            return output;

        }

        /// <summary>
        /// Verilen PersonModeli ile gönderilen verilerin arasına | karakterini koyarak düz bir stringe dönüştürür.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string ConvertToPersonModelsForUpdate(PersonModel p)
        {
            return $" g \"{ p.id }|{ p.Adı }|{ p.Soyadı }|{ p.Yas }|{ p.Cinsiyet }|{ p.Boy }|{ p.Kilo }|{ p.Telefon }|{ p.EmailAdress }|{ p.DogumTarihi }|" +
                $"{ p.abonelikTipi }|{ p.fiyat }|{ p.kayitTarihi }\"";
        }

        /// <summary>
        /// Verilen PersonModeli ile gönderilen verilerin arasına | karakterini koyarak düz bir stringe dönüştürür.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string ConvertToPersonModels(PersonModel p)
        {
            return $" w \"{ p.id }|{ p.Adı }|{ p.Soyadı }|{ p.Yas }|{ p.Cinsiyet }|{ p.Boy }|{ p.Kilo }|{ p.Telefon }|{ p.EmailAdress }|" +
                $"{ p.DogumTarihi }|{ p.abonelikTipi }|{ p.fiyat }|{ p.kayitTarihi }\"";
        }

        /// <summary>
        /// Pythonun terminale yazdırdığı üyeyi okuyarak PersonModele çevirir.
        /// </summary>
        /// <param name="output"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public PersonModel ConvertFromStringToPersonModel(string output, PersonModel person)
        {
            output = output.Replace('"', ' ');
            string[] outputSplitted = output.Split('|');
            int lastIndex = outputSplitted[1].Split(' ').Length - 1;

            Console.WriteLine(output);
            person.id =             outputSplitted[0];
            person.Adı =            outputSplitted[1];
            person.Soyadı =         outputSplitted[2];
            person.Yas =            outputSplitted[3];
            person.Cinsiyet=        outputSplitted[4];
            person.Boy =            outputSplitted[5];
            person.Kilo =           outputSplitted[6];
            person.Telefon =        outputSplitted[7];
            person.EmailAdress =    outputSplitted[8];
            person.DogumTarihi =    outputSplitted[9];
            person.abonelikTipi =   outputSplitted[10];
            person.fiyat =          outputSplitted[11];
            person.kayitTarihi =    outputSplitted[12];

            return person;
        }

        /// <summary>
        /// PersonModelde adı yerine yazılarak arama yerinden buraya gönerilir. Burada "r" (read) argümanı ile adı
        /// gönderilir. Python üyeler arasında arama yapar ve bulursa geri döndürür. Sonra gelen stringi 
        /// ConvertFromStringToPersonModel() Fonksiyonuyla PersonModele döndürüp return eder.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public PersonModel GetPerson(PersonModel person)
        {

            string personName = $" r \"{ person.Adı }\"";

            string fileName = @"Proje1.py" + personName;

            Process pros = new Process();

            pros.StartInfo = new ProcessStartInfo(@"python", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            pros.Start();
            string output = pros.StandardOutput.ReadToEnd();
            pros.WaitForExit();

            Console.WriteLine(output);
            
            if (output.Length == 0)
            {
                MessageBox.Show("Bu adda bir üye bulunamamıştır!");
                return person;
            }

            if (output[0] == '[')
            {
                person.Uyeler = output;
                return person;
            }

            return ConvertFromStringToPersonModel(output, person);
        }

        /// <summary>
        /// "ra" (read all) argümanı ile python kodunu çalıştırınca python kodu bize bütün üyeleri okur ve bize 
        /// terminale yazdırır. Gelen üyeler PersonModel.Uyeler kısmına
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public PersonModel GetPersonAll(PersonModel person)
        {

            string personName = $" ra";

            string fileName = @"Proje1.py" + personName;

            Process pros = new Process();

            pros.StartInfo = new ProcessStartInfo(@"python", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            pros.Start();
            string output = pros.StandardOutput.ReadToEnd();
            pros.WaitForExit();

            Console.WriteLine(output);

            person.Uyeler = output;
            return person;
        }

        /// <summary>
        /// PersonModel ile gelen Cinsiyet Boy Kilo bilgilerini "c" (calculations) argümanı ile python kodunu çalıştırır.
        /// Pythondan gelen cevabı terminalden okur ve hiç değiştirmeden string olarak return eder.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string GetProgramCalculations(PersonModel p)
        {

            string personName = $" c \"{ p.Cinsiyet }|{ p.Boy }|{ p.Kilo }\"";

            string fileName = @"Proje1.py" + personName;

            Process pros = new Process();

            pros.StartInfo = new ProcessStartInfo(@"python", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            pros.Start();
            string output = pros.StandardOutput.ReadToEnd();
            pros.WaitForExit();

            Console.WriteLine(output);

            return output;
        }

        /// <summary>
        /// "cid" (checkin date) argümanı ile şimdiki tarih ve saati python koduna kişinin idsi ile gönderir.
        /// </summary>
        public void AddCheckInDate(PersonModel p)
        {

            string consolText = $" cid {p.id} {DateTime.Now}";

            string fileName = @"Proje1.py" + consolText;

            Process pros = new Process();

            pros.StartInfo = new ProcessStartInfo(@"python", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            pros.Start();
            string output = pros.StandardOutput.ReadToEnd();
            pros.WaitForExit();

            Console.WriteLine(output);
        }

        /// <summary>
        /// "cod" (checkout date) argümanı ile şimdiki tarih ve saati python koduna kişinin idsi ile gönderir.
        /// </summary>
        /// <param name="p"></param>
        public void AddCheckOutDate(PersonModel p)
        {
            string consolText = $" cod {p.id} {DateTime.Now}";

            string fileName = @"Proje1.py" + consolText;

            Process pros = new Process();

            pros.StartInfo = new ProcessStartInfo(@"python", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            pros.Start();
            string output = pros.StandardOutput.ReadToEnd();
            pros.WaitForExit();

            Console.WriteLine(output);
        }

        /// <summary>
        /// Admin yapılacak kişinin şifresini ve id'sini "ap" (add password) ile birlikte gönderir.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="pswd"></param>
        /// <returns> Eğer sifre oluşturuldu. döndüyse true döner. değilse false. </returns>
        public bool AddPassword(PersonModel p, string pswd)
        {
            string consolText = $" ap {p.id} {pswd}";

            string fileName = @"Proje1.py" + consolText;

            Process pros = new Process();

            pros.StartInfo = new ProcessStartInfo(@"python", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            pros.Start();
            string output = pros.StandardOutput.ReadToEnd();
            pros.WaitForExit();

            Console.WriteLine(output);

            if (output == "sifre olusturuldu.") return true;
            return false;
        }

        /// <summary>
        /// Girilen şifreyi "gp" (get password) argümanı ile python'a gönderir. Python şifrelerin içinde
        /// girilen şifreyi arar. Eğer girilen şifreyle eşleşen bir şifre varsa terminale "Dogru" yazdırır.
        /// Yoksa "Yanlıs" yazdırır. 
        /// </summary>
        /// <param name="pswd"></param>
        /// <returns> Python kodunun ternminale yazdırdığı olduğu gibi geri döndürülüyor. </returns>
        public string GetPassword(string pswd)
        {
            string consolText = $" gp {pswd}";
            Console.WriteLine(pswd);
            string fileName = @"Proje1.py" + consolText;

            Process pros = new Process();

            pros.StartInfo = new ProcessStartInfo(@"python", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            pros.Start();
            string output = pros.StandardOutput.ReadToEnd();
            pros.WaitForExit();

            Console.WriteLine(output);

            output = String.Join("",output.Split('\n', '\r'));
            return output;
            

        }
    }
}

