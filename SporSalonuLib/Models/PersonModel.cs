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
        public int id { get; set; }

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
        /// Kişinin doğum tarihi
        /// </summary>
        public string DogumTarihi { get; set; }

        /// <summary>
        /// Kişinin programı
        /// </summary>
        public string Program { get; set; }

        /// <summary>
        /// Kişinin tam adını dönen bir fonksiyon.
        /// </summary>
        public string TamAd
        {
            get
            {
                return $"{ Adı } { Soyadı }";
            }

        }

    }
}
