using SporSalonuLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuLib
{
    /// <summary>
    /// Birden fazla database tanımlanırsa bütün kodu değiştirmememiz için
    /// interface tanımlıyoruz.
    /// </summary>
    public interface IDataConnection
    {
        /// <summary>
        /// Seçilen Databasede kişiyi oluşturmak için gerekli işlemleri yapacak olan fonksiyon.
        /// </summary>
        /// <param name="model"></param>
        void CreatePerson(PersonModel model);

        /// <summary>
        /// Bütün kişileri çekmemize yarayacak fonksiyon.
        /// </summary>
        /// <returns></returns>
        List<PersonModel> GetPerson_All();
    }
}
