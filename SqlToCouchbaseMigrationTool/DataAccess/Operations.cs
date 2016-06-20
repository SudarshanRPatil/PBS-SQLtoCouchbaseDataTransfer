using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Operations : IOperation
    {
        public List<spGetTranscationDetailsByTimeStampResult> GetTranscationDetailsByTimeStamp(DateTime fromDate, DateTime toDate)
        {
            var travelCreditDbDataContext = new TravelCreditDBDataContext();

            List<spGetTranscationDetailsByTimeStampResult> getSuccessStatResult = travelCreditDbDataContext.spGetTranscationDetailsByTimeStamp(fromDate, toDate).ToList();

            return getSuccessStatResult;
        }

        public List<spGetTranscationDetailsByMemberNameResult> GetTranscationDetailsByUserName(string userName)
        {
            var travelCreditDbDataContext = new TravelCreditDBDataContext();

            List<spGetTranscationDetailsByMemberNameResult> getSuccessStatResult = travelCreditDbDataContext.spGetTranscationDetailsByMemberName(userName).ToList();

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
