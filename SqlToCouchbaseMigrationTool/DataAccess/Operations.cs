using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Operations : IOperation
    {

        public List<spGetTranscationDetailsResult> GetTranscationDetails(string userName, DateTime fromDate, DateTime toDate)
        {
            var travelCreditDbDataContext = new TravelCreditDBDataContext();

            List<spGetTranscationDetailsResult> getSuccessStatResult = travelCreditDbDataContext.spGetTranscationDetails(userName, fromDate, toDate).ToList();

            return getSuccessStatResult;
        }

        public List<spMemberExistsInMemberDetailsResult> GetMemberDetails(string memberName)
        {

            var travelCreditDbDataContext = new TravelCreditDBDataContext();

            List<spMemberExistsInMemberDetailsResult> getSuccessStatResult = travelCreditDbDataContext.spMemberExistsInMemberDetails(memberName).ToList();

            return getSuccessStatResult;
        }

        public List<spGetProductDetailsByConfirmationNumberResult> GetProductDetailsByConfirmationNumber(string confirmationNumber)
        {
            var tripDbDataContext = new TripDBDataContext();

            List<spGetProductDetailsByConfirmationNumberResult> getSuccessStatResult = tripDbDataContext.spGetProductDetailsByConfirmationNumber(confirmationNumber).ToList();

            return getSuccessStatResult;
        }
    }
}
