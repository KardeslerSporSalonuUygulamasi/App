/*
 Bu C# solution'u Uludağ Üniversitesi Bİlgisayar Mühendisliği bölümü "PYTHON PROGRAMLAMAYA GİRİŞ" dersi proje 
ödevi "Bir spor salonuna gelen kişilerin geliş gidiş takvim bilgilerinden yaptıkları sporun detay kayıtlarına
kadar bilgilerini tutacak olan bir python projesi(.Net Framework ile entegre edilecek)"'nin .Net (C#) ayağıdır.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SporSalonuLib;

namespace SporSalonuUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            // Database bağlantısını tanımlıyoruz.
            GlobalConfig.InitializeConnections(DatabaseType.PyCSVFile);

            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Giris());
        }
    }
}
