using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DbConfigurations
    {
        private static string ReadDataMigrationDatabaseKey
        {
            get { return GetDataMigrationDbConnectionString() ?? "TravelCreditDB"; }
        }

        private static string WriteDataMigrationDatabaseKey
        {
            get { return GetDataMigrationDbConnectionString() ?? "TravelCreditDB"; }
        }

        public static string ReadDataMigrationDatabaseConnection
        {
            get { return ReadDataMigrationDatabaseKey; }
        }

        public static string WriteDataMigrationDatabaseConnection
        {
            get { return WriteDataMigrationDatabaseKey; }
        }

        private static string GetDataMigrationDbConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["TravelCreditDB"].ConnectionString;
        }
    }
}
