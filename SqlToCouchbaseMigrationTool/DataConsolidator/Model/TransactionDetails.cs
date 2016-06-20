using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConsolidator.Model;

namespace DataConsolidator
{
    public class TransactionDetails
    {
        public string DocumentId { get; set; }

        public string TransactionId { get; set; }

        public string ReferenceTransactionId { get; set; }

        public TransactionType TransactionType { get; set; }

        public string Currency { get; set; }

        public decimal? Amount { get; set; }

        public decimal? ConversionFactor { get; set; }

        public decimal? USDEquivalentAmount { get; set; }

        public CategoryType SoftCashProgram { get; set; }

        public DateTime? Timestamp { get; set; }

        public string Reason { get; set; }

        public string Comment { get; set; }

        public DateTime? Validity { get; set; }

        public AvailibilityType Availability { get; set; }

        public TransactionStatusType TransactionStatus { get; set; }

        public decimal? ClosingAmount { get; set; }

        public Source Source { get; set; }

        public Owner Owner { get; set; }

        public string RequesterName { get; set; }

        public RedemptionDetails RedemptionDetails { get; set; }

    }

    public enum TransactionType
    {
        Credit = 0,
        Debit = 1
    }

    public enum CategoryType
    {
        RoviaBucks = 0,
        TravelDollars = 1

    }

    public enum AvailibilityType
    {
        Immediate = 0,
        Accrual = 1
    }

    public enum TransactionStatusType
    {
        ApprovalPending = 0,
        Completed = 1,
        OnHold = 2
    }
}
