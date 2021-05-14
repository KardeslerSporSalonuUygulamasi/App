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
    public class TextConnector : IDataConnection
    {
        public void CreatePerson(PersonModel model)
        {
            string personInfo= ConvertToPersonModels(model);

            Console.WriteLine(personInfo);

            string fileName = @"test.py" + personInfo;
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

            MessageBox.Show("Üye başarıyla oluşturulmuştur!", "Başarılı ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Console.ReadLine();

        }
        public void UpdatePerson(PersonModel model)
        {
            string personInfo = ConvertToPersonModelsForUpdate(model);

            Console.WriteLine(personInfo);

            string fileName = @"test.py" + personInfo;
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
            MessageBox.Show("Üye başarıyla günclelenmiştir!", "Başarılı güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //Console.ReadLine();

        }
        public void RemovePerson(PersonModel model)
        {
            {
                string personInfo = $" s { model.id }";

                Console.WriteLine(personInfo);

                string fileName = @"test.py" + personInfo;
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

        private string ConvertToPersonModelsForUpdate(PersonModel p)
        {
            return $" g \"{ p.id }|{ p.Adı }|{ p.Soyadı }|{ p.Yas }|{ p.Cinsiyet }|{ p.Boy }|{ p.Kilo }|{ p.Telefon }|{ p.EmailAdress }|{ p.DogumTarihi }|{ p.Program }\"";
        }

        public string ConvertToPersonModels(PersonModel p)
        {
            return $" w \"{ p.id }|{ p.Adı }|{ p.Soyadı }|{ p.Yas }|{ p.Cinsiyet }|{ p.Boy }|{ p.Kilo }|{ p.Telefon }|{ p.EmailAdress }|{ p.DogumTarihi }|{ p.Program }\"";
        }

        public PersonModel ConvertFromStringToPersonModel(string output, PersonModel person)
        {
            if (output.Length == 0)
            {
                MessageBox.Show("Bu adda bir üye bulunamamıştır!");
                person.Adı = "*";
                return person;
            }

            output = output.Replace('"', ' ');
            string[] outputSplitted = output.Split('|');
            int lastIndex = outputSplitted[1].Split(' ').Length - 1;

            Console.WriteLine(output);
            person.id =             outputSplitted[0];

            //int count = 0;
            //person.Adı = "";
            //while (count != lastIndex)
            //{
            //    person.Adı += ' ' + (outputSplitted[1].Split(' '))[count];
            //    count++;
            //}

            person.Adı =            outputSplitted[1];
            person.Soyadı =         outputSplitted[2];
            person.Yas =            outputSplitted[3];
            person.Cinsiyet=        outputSplitted[4];
            person.Boy =            outputSplitted[5];
            person.Kilo =           outputSplitted[6];
            person.Telefon =        outputSplitted[7];
            person.EmailAdress =    outputSplitted[8];
            person.DogumTarihi =    outputSplitted[9];
            person.Program =        outputSplitted[10].Replace('*', '\n');




            return person;
        }

        public PersonModel GetPerson(PersonModel person)
        {
            // TODO - Get person from python script via Fullname

            string personName = $" r \"{ person.Adı }\"";

            string fileName = @"test.py" + personName;

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


            return ConvertFromStringToPersonModel(output, person);
        }

    }
}

