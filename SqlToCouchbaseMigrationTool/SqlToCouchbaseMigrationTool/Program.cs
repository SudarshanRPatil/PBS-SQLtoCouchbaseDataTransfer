using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace SqlToCouchbaseMigrationTool
{
    public class Program
    {
        private static void Main(string[] args)
        {
            DateTime fromDate = DateTime.Now.AddDays(-1).Date;
            DateTime toDate = DateTime.Now.Date;

            if (Constants.UseSpecificDate)
            {
                fromDate = Convert.ToDateTime(ConfigurationManager.AppSettings[Constants.FromDate]);
                toDate = Convert.ToDateTime(ConfigurationManager.AppSettings[Constants.ToDate]);
            }

            const string memberId = "3285301";

            GetTranscationDetails(memberId,fromDate, toDate);
        }

        private static void GetTranscationDetails(string memberId,DateTime fromDate, DateTime toDate)
        {
            var ops = new DataAccess.Operations();
            var getSuccessStatResult = ops.GetTranscationDetails(memberId, fromDate, toDate);
        }
    }
}
