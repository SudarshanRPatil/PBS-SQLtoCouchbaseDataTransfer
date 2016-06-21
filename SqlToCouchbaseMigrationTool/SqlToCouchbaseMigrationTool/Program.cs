using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataConsolidator;

namespace SqlToCouchbaseMigrationTool
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if(string.Equals(ConfigurationManager.AppSettings["Strategy"], "PerUser", StringComparison.InvariantCultureIgnoreCase)){
                
                var members = GetAllMembers();
                var lastExecutionDate = Convert.ToDateTime(ConfigurationManager.AppSettings["LastExecutionDate"]);
                foreach(var member in members){
                    List<TransactionDetails> transactionsOfmember = GetTransactionDetailsByUsername(member, lastExecutionDate);
                    //Upsert all transactions of member to couchbase
                }
            }
            else
            {
                DateTime fromDate = DateTime.Now.AddDays(-1).Date;
                DateTime toDate = DateTime.Now.Date;

                if (Constants.UseSpecificDate)
                {
                    fromDate = Convert.ToDateTime(ConfigurationManager.AppSettings[Constants.FromDate]);
                    toDate = Convert.ToDateTime(ConfigurationManager.AppSettings[Constants.ToDate]);
                }

                List<TransactionDetails> transactionsInCurrentTimestamp = GetTransactionDetailsByTimestamp(fromDate, toDate);
                //Upsert all transactions between given timeframe to couchbase
            } 

            
        }

        private static List<string> GetAllMembers()
        {
            throw new NotImplementedException();
        }

        public static List<TransactionDetails> GetTransactionDetailsByTimestamp(DateTime fromDate, DateTime toDate)
        {
            
            var transactionHandler = new TransactionHandler();
            List<TransactionDetails> transactionDetails = transactionHandler.GetAllTransactionsByTimestamp(fromDate, toDate);
            return transactionDetails;
        }

        public static List<TransactionDetails> GetTransactionDetailsByUsername(string username, DateTime lastExecutiondate)
        {
            var accountHandler = new AccountHandler();
            var owner = accountHandler.GetMemberAccountDetails(username);
            var transactionHandler = new TransactionHandler();
            List<TransactionDetails> transactionDetails = transactionHandler.GetAllTransactionsByUsername(username, lastExecutiondate, owner);
            return transactionDetails;
        }
    }
}
