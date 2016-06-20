using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsolidator
{
    public class TransactionHandler
    {
        public List<TransactionDetails> GetAllTransactions(string memberId)
        {
            DateTime fromDate = DateTime.Now.AddDays(-1).Date;
            DateTime toDate = DateTime.Now.Date;
            var operations = new Operations();
            List<spGetTranscationDetailsByTimeStampResult> transactions = operations.GetTranscationDetailsByTimeStamp(fromDate, toDate);
            List<TransactionDetails> cbTransactionDetailList = new List<TransactionDetails>();
            if (transactions != null)
            {
                cbTransactionDetailList = Translator.ToCbTransactionDetail(transactions);
            }
            return cbTransactionDetailList;
        }
    }
}
