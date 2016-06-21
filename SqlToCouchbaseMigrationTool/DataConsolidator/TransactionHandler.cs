using DataAccess;
using DataConsolidator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsolidator
{
    public class TransactionHandler
    {
        public List<TransactionDetails> GetAllTransactionsByUsername(string memberName, DateTime lastExecutedDate,
            Owner owner)
        {
            var operations = new Operations();
            var transactions = operations.GetTranscationDetails(memberName);
                //Replace this with user specific sp
            var cbTransactionDetailList = new List<TransactionDetails>();
            if (transactions != null)
            {
                //If transaction has orderid
                //GET that trip details and convert it to RedemptiondetailsObj
                cbTransactionDetailList = Translator.ToCBTransactionDetailList(transactions, owner);
            }
            return cbTransactionDetailList;
        }

        public List<TransactionDetails> GetAllTransactionsByTimestamp(DateTime fromDate, DateTime toDate)
        {
            var operations = new Operations();
            var transactions = operations.GetTranscationDetails(fromDate, toDate);
            var cbTransactionDetailList = new List<TransactionDetails>();
            if (transactions != null && transactions.Count > 0)
            {
                foreach (var trans in transactions)
                {
                    var username = trans.Username;
                    var accHandler = new AccountHandler();
                    var owner = accHandler.GetMemberAccountDetails(username);
                    cbTransactionDetailList.Add(Translator.ToCBTransactionDetails(trans, owner));
                }
            }
            return cbTransactionDetailList;
        }
    }
}
