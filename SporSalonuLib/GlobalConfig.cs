using SporSalonuLib.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuLib
{
    /// <summary>
    /// Program.cs'te GlobalConfig.InitializeConnections(DatabaseType.PyCSVFile) dediğimizde
    /// csv dosyaları ile database oluşturacağımızı belirtiyoruz.
    /// </summary>
    public static class GlobalConfig
    {
        /// <summary>
        /// Globalconfig'in altında Connection adında bir IDataConnection tanımlanıyor.
        /// Böylece GlobalConfig.Connection ile IDataConnectionda tanımlanan tüm fonksiyonlara ulaşılabilecek
        /// ve Program.cs kodu haricinde herhangi bir database belirtmemize gerek kalmadan otomatik olarak
        /// seçilen Databasein Classındaki fonksiyonlara ulaşılacak. 
        /// 
        /// Bu herhangi bir database değişikliğinde her bir .cs dosyasındaki ilgili fonksiyonları/ fonksiyon adlarını değiştirmek yerine
        /// program.cs dosyasından database tipini değiştirmek ve o database için yeni bir class oluşturup fonksiyonları IDataConnection
        /// dosyasını implemente ederek yazmak yetecek.
        /// </summary>
        public static IDataConnection Connection { get; private set; }

        /// <summary>
        /// Hangi databasei kullanacağımızı seçtiğimizde onu devreye sokan fonksiyon. Connection seçilen database göre bir nesneyi gösterecek
        /// şekilde eşitleniyor. Bu yukarıda yazılanları yapabilmemizi sağlıyor.
        /// </summary>
        /// <param name="db"></param>
        public static void InitializeConnections(DatabaseType db)
        {
            if (db == DatabaseType.PyCSVFile)
            {
                PyCsvConnector pycsv = new PyCsvConnector();
                Connection = pycsv;
            }
        }


    }
}
