﻿
using DataAccess;
using DataConsolidator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConsolidator.Model;

namespace DataConsolidator
{
    public static class Translator
    {
        internal static List<TransactionDetails> ToCBTransactionDetailList(List<spGetTranscationDetailsResult> transactions, Owner owner)
        {
            if (transactions != null && transactions.Count > 0)
            {
                var cbTransactiondetails = new List<TransactionDetails>();
                foreach (var transaction in transactions)
                {
                    var cbTransaction = ToCBTransactionDetails(transaction, owner);
                    cbTransactiondetails.Add(cbTransaction);
                }
                return cbTransactiondetails;
            }
            return new List<TransactionDetails>();
        }

        private static RedemptionDetails GetRedemptionDetails(string orderId)
        {
            RedemptionDetails redemptionDetails = null;
            if (orderId != null && Convert.ToInt64(orderId) > 0)
            {
                redemptionDetails = new RedemptionDetails();
                redemptionDetails.Products = new List<Product>();
                var operations = new Operations();
                var redemptionDetailslList = operations.GetProductDetailsByConfirmationNumber(orderId).ToList();
                foreach (var redemptionDetail in redemptionDetailslList)
                {
                    redemptionDetails.Products.Add(new Product()
                                                   {
                                                       ProductType = redemptionDetail.ProductType,
                                                       VendorId = redemptionDetail.FareSourceID.ToString(),
                                                       VendorName = redemptionDetail.FareSourceName
                                                   });
                }
            }
            return redemptionDetails;
        }

        internal static TransactionDetails ToCBTransactionDetails(spGetTranscationDetailsResult transaction, Owner owner)
        {
            var transactionDetail = new TransactionDetails
                                    {
                                        DocumentId = Guid.NewGuid().ToString(),
                                        TransactionId = transaction.TransactionId.ToString(),
                                        ReferenceTransactionId = transaction.ReferenceTransactionId.ToString(),
                                        TransactionType = transaction.TransactionType,
                                        Currency = transaction.Currency,
                                        Amount = transaction.Amount,
                                        ConversionFactor = transaction.ConversionFactor,
                                        USDEquivalentAmount = transaction.UsdEquivalentAmount,
                                        SoftCashProgram = transaction.SoftcashProgram,
                                        Timestamp = transaction.Timestamp,
                                        Reason = transaction.Reason,
                                        Comment = transaction.Comment,
                                        Validity = transaction.Validity,
                                        Availability = transaction.Availability,
                                        TransactionStatus = transaction.TransactionStatus,
                                        ClosingAmount = transaction.ClosingBalance,
                                        Owner = owner,
                                        Source = new Source
                                                 {
                                                     Application = transaction.Application,
                                                 },
                                        RequesterName = transaction.RequesterUserName,
                                        RedemptionDetails = GetRedemptionDetails(transaction.OrderId)
                                    };
            return transactionDetail;
        }

        #region code

        //internal static TransactionType ToCBTransactionType(this string transactionType)
        //{
        //    TransactionType cbTransactionType;
        //    Enum.TryParse(transactionType, out cbTransactionType);
        //    return cbTransactionType;
        //}

        //internal static CategoryType ToCBSoftCashProgram(this string softcashProgram)
        //{
        //    CategoryType cbsoftcashProgram;
        //    Enum.TryParse(softcashProgram, out cbsoftcashProgram);
        //    return cbsoftcashProgram;
        //}

        //internal static AvailibilityType ToCBAvailabilityType(this string availability)
        //{
        //    AvailibilityType cbAvailabilityType;
        //    Enum.TryParse(availability, out cbAvailabilityType);
        //    return cbAvailabilityType;
        //}

        //internal static TransactionStatusType ToCBTransactionStatus(this string transactionStatus)
        //{
        //    TransactionStatusType cbTransactionStatus;
        //    Enum.TryParse(transactionStatus, out cbTransactionStatus);
        //    return cbTransactionStatus;
        //} 

        #endregion
    }
}
