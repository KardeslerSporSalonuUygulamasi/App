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
        /// Seçilen database tipinde seçilen kişinin bilgilerinin güncellemeye yarar.
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
        void CreateWorkoutProgram(PersonModel model, string program);

        /// <summary>
        /// Olan bir kişiyi python scripti aracılığıyla çekmemizi sağlayacak fonksiyon.
        /// </summary>
        /// <returns></returns>
        PersonModel GetPerson(PersonModel p);
    }
}
