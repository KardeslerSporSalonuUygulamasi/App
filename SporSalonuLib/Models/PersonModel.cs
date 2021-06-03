using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuLib.Models
{

    /// <summary>
    /// Bir kişiyi ifade eder
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// Her bir kişi için tek bir id.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Kişinin adı.
        /// </summary>
        public string Adı { get; set; }

        /// <summary>
        /// Kişinin soyadı.
        /// </summary>
        public string Soyadı { get; set; }

        /// <summary>
        /// Kişinin email adresi.
        /// </summary>
        public string EmailAdress { get; set; }

        /// <summary>
        /// Kişinin telefon numarası.
        /// </summary>
        public string Telefon { get; set; }

        /// <summary>
        /// Kişinin kilosu
        /// </summary>
        public string Kilo { get; set; }

        /// <summary>
        /// Kişinin Yaşı
        /// </summary>
        public string Yas { get; set; }

        /// <summary>
        /// Kişinin cinsiyeti.
        /// </summary>
        public string Cinsiyet { get; set; }

        /// <summary>
        /// Kişinin doğum tarihi
        /// </summary>
        public string DogumTarihi { get; set; }

        /// <summary>
        /// Kişinin programı
        /// </summary>
        public string Program { get; set; }

        /// <summary>
        /// Kişinin boyu
        /// </summary>
        public string Boy { get; set; }

        /// <summary>
        /// Kişinin tercih ettiği abonelik tipi
        /// </summary>
        public string abonelikTipi { get; set; }

        /// <summary>
        /// kişiye uygun görülen ücret
        /// </summary>
        public string fiyat { get; set; }

        /// <summary>
        /// Kişinin kaydının başladığı tarih
        /// </summary>
        public string kayitTarihi { get; set; }

        /// <summary>
        /// Hesaplamalar tutulur. YağsizKilo|boykilo|netyağ
        /// </summary>
        public string hesaplamalar { get; set; }

        /// <summary>
        /// Kişinin tam adını dönen bir fonksiyon.
        /// </summary>
        public string TamAd
        {
            get
            {
                return $"{ Adı } { Soyadı }";
            }

            set
            {
                TamAd = $"{ Adı }";
            }

        }
        public string Uyeler { get; set; }

        public string passwd { get; set; }

    }
}
