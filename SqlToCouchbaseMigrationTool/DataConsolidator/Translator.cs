using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsolidator
{
    public static class Translator
    {
        internal static List<TransactionDetails> ToCbTransactionDetail(List<spGetTranscationDetailsResult> transactions)
        {
            if (transactions != null && transactions.Count > 0)
            {
                List<TransactionDetails> cbTransactiondetails = new List<TransactionDetails>();
                foreach (var transaction in transactions)
                {
                    var transactionDetail = new TransactionDetails
                    {
                        DocumentId = new Guid().ToString(),
                        TransactionId = transaction.TransactionId.ToString(),
                        ReferenceTransactionId = transaction.ReferenceTransactionId.ToString(),
                        TransactionType = transaction.TransactionType.ToCBTransactionType(),
                        Currency = transaction.Currency,
                        Amount = transaction.Amount,
                        ConversionFactor = transaction.ConversionFactor,
                        USDEquivalentAmount = transaction.UsdEquivalentAmount,
                        SoftCashProgram = transaction.SoftcashProgram.ToCBSoftCashProgram(),
                        Timestamp = transaction.Timestamp, 
                        Reason = transaction.Reason,
                        Comment = transaction.Comment,
                        Validity = transaction.Validity,
                        Availability = transaction.Availability.ToCBAvailabilityType(),
                        TransactionStatus = transaction.TransactionStatus.ToCBTransactionStatus(),
                        //ClosingAmount = transaction.ClosingAmount,
                        //Owner  
                        Source = new Model.Source
                        {
                            Application = transaction.Application,
                        },
                        RequesterName = transaction.RequesterUserName,
                        //RedemptionDetails
                    };
                    cbTransactiondetails.Add(transactionDetail);
                }
                return cbTransactiondetails;
            }
            return new List<TransactionDetails>();
            
        }

        internal static TransactionType ToCBTransactionType(this string transactionType)
        {
            TransactionType cbTransactionType;
            Enum.TryParse(transactionType, out cbTransactionType);
            return cbTransactionType;
        }

        internal static CategoryType ToCBSoftCashProgram(this string softcashProgram)
        {
            CategoryType cbsoftcashProgram;
            Enum.TryParse(softcashProgram, out cbsoftcashProgram);
            return cbsoftcashProgram;
        }

        internal static AvailibilityType ToCBAvailabilityType(this string availability)
        {
            AvailibilityType cbAvailabilityType;
            Enum.TryParse(availability, out cbAvailabilityType);
            return cbAvailabilityType;
        }

        internal static TransactionStatusType ToCBTransactionStatus(this string transactionStatus)
        {
            TransactionStatusType cbTransactionStatus;
            Enum.TryParse(transactionStatus, out cbTransactionStatus);
            return cbTransactionStatus;
        }
    }
}
