using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlToCouchbaseMigrationTool
{
    public class Constants
    {
        public static string FromDate = "FromDate";
        public static string ToDate = "ToDate";

        public static bool UseSpecificDate
        {
            get
            {
                string useSpecificDate = ConfigurationManager.AppSettings["UseSpecificDate"] ?? "True";
                if (string.Equals(useSpecificDate, "y", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(useSpecificDate, "True", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(useSpecificDate, "yes", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
