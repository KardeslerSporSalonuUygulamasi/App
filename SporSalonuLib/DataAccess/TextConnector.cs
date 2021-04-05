using SporSalonuLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;

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

            p.StartInfo = new ProcessStartInfo(@"D:\Python39\python.exe", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Console.WriteLine(output);

            //Console.ReadLine();

        }
        public string ConvertToPersonModels(PersonModel p)
        {
            return $" w \"{ p.id }|{ p.TamAd }|{ p.Yas }|{ p.Cinsiyet }|{ p.Boy }|{ p.Kilo }|{ p.Telefon }|{ p.EmailAdress }|{ p.DogumTarihi }|{ p.Program }\"";
        }

        public PersonModel ConvertFromStringToPersonModel(string output, PersonModel person)
        {

            output = output.Replace('"', ' ');
            string[] outputSplitted = output.Split('|');
            Console.WriteLine(output);
            person.id =             outputSplitted[0];
            person.Adı =            (outputSplitted[1].Split(' '))[0];
            person.Soyadı =         (outputSplitted[1].Split(' '))[1];
            person.Yas =            outputSplitted[2];
            person.Cinsiyet=        outputSplitted[3];
            person.Boy =            outputSplitted[4];
            person.Kilo =           outputSplitted[5];
            person.Telefon =        outputSplitted[6];
            person.EmailAdress =    outputSplitted[7];
            person.DogumTarihi =    outputSplitted[8];
            person.Program =        outputSplitted[9].Replace('*', '\n');


            return person;
        }

        public PersonModel GetPerson(PersonModel person)
        {
            // TODO - Get person from python script via Fullname

            string personName = $" r \"{ person.Adı }\"";

            string fileName = @"test.py" + personName;

            Process pros = new Process();

            pros.StartInfo = new ProcessStartInfo(@"D:\Python39\python.exe", fileName)
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
