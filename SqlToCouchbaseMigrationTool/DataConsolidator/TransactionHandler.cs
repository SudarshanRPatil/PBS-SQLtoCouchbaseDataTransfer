using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace DataConsolidator
{
    public class TransactionHandler
    {
        public List<TransactionDetails> GetAllTransactions(string memberId)
        {
            List<spGetTranscationDetailsResult> transactions = Get
            if (transactions != null)
            {
                List<TransactionDetails> cbTransactionDetailList = Translator.ToCBTransactionDetail(transactions);
            }
        }
    }
}
