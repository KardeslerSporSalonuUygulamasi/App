using SporSalonuLib.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuLib
{
    /// <summary>
    /// Program.cs'te GlobalConfig.InitializeConnections(DatabaseType.TextFile) dediğimizde
    /// text dosyaları ile database oluşturacağımızı belirtiyoruz.
    /// </summary>
    public static class GlobalConfig
    {
        /// <summary>
        /// Globalconfig'in altında Connection adında bir IDataConnection
        /// </summary>
        public static IDataConnection Connection { get; private set; }

        /// <summary>
        /// Hangi databasei kullanacağımızı seçtiğimizde onu devreye sokan fonksiyon
        /// </summary>
        /// <param name="db"></param>
        public static void InitializeConnections(DatabaseType db)
        {
            if (db == DatabaseType.TextFile)
            {
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }


    }
}
