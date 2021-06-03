using SporSalonuLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuLib
{
    /// <summary>
    /// Farklı databaselerde aynı fonksiyonları kullanmak için bu fonksiyonları bu interfacete tanımlıyoruz.
    /// </summary>
    public interface IDataConnection
    {
        /// <summary>
        /// Kişiyi oluşturmak için gerekli işlemleri yapacak olan fonksiyon.
        /// </summary>
        /// <param name="model"></param>
        bool CreatePerson(PersonModel model);

        /// <summary>
        /// Seçilen kişinin bilgilerinin güncellemeye yarar.
        /// </summary>
        /// <param name="model"></param>
        void UpdatePerson(PersonModel model);

        /// <summary>
        /// Seçilen kişiyi databaseden silmeye yarar.
        /// </summary>
        /// <param name="model"></param>
        void RemovePerson(PersonModel model);

        /// <summary>
        /// Girilen programı kaydetmemize yarar.
        /// </summary>
        /// <param name="program"></param>
        void CreateWorkoutProgram(PersonModel model);

        /// <summary>
        /// Spor salonuna giriş yaptığı tarihi ekler
        /// </summary>
        void AddCheckInDate(PersonModel p);

        /// <summary>
        /// Spor salonundan çıkış yaptığı tarihi ekler
        /// </summary>
        void AddCheckOutDate(PersonModel p);

        /// <summary>
        /// Verilen kişi id'si ile program bulmaya yarar.
        /// </summary>
        /// <param name="model"></param>
        string GetWorkoutProgram(PersonModel model);

        /// <summary>
        /// Olan bir kişiyi çekmemizi sağlayacak fonksiyon.
        /// </summary>
        /// <returns></returns>
        PersonModel GetPerson(PersonModel p);

        /// <summary>
        /// Bütün kişilerin listesini okumaya yarar.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        PersonModel GetPersonAll(PersonModel p);

        /// <summary>
        /// Kişinin yağ, kilo gibi endeks hesaplamalarını yapar
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        string GetProgramCalculations(PersonModel p);

        /// <summary>
        /// Şifre eklemeye yarar
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        bool AddPassword(PersonModel p, string pswd);

        /// <summary>
        /// Girilen şifrenin olup olmadığını sorgular
        /// </summary>
        /// <param name="pswd"></param>
        /// <returns></returns>
        string GetPassword(string pswd);


    }
}
