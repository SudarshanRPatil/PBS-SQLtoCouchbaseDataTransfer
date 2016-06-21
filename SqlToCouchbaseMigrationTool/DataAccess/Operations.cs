using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess
{
    public class Operations : IOperation
    {
        public List<spGetTranscationDetailsResult> GetTranscationDetails(string userName)
        {
            var travelCreditDbDataContext = new TravelCreditDBDataContext();

            List<spGetTranscationDetailsResult> getSuccessStatResult = travelCreditDbDataContext.spGetTranscationDetails(userName, null, null).ToList();

            return getSuccessStatResult;
        }

        public List<spGetTranscationDetailsResult> GetTranscationDetails(DateTime fromDate, DateTime toDate)
        {
            var travelCreditDbDataContext = new TravelCreditDBDataContext();

            List<spGetTranscationDetailsResult> getSuccessStatResult = travelCreditDbDataContext.spGetTranscationDetails(null, fromDate, toDate).ToList();

            return getSuccessStatResult;
        }

        public List<spMemberExistsInMemberDetailsResult> GetMemberDetails(string memberName)
        {
            var travelCreditDbDataContext = new TravelCreditDBDataContext();
            var getSuccessStatResult = new List<spMemberExistsInMemberDetailsResult>();
            try
            {
                getSuccessStatResult = travelCreditDbDataContext.spMemberExistsInMemberDetails(memberName).ToList();
            }
            catch (Exception)
            {
                //TODO: log exception /handle
            }

            return getSuccessStatResult;
        }

        public bool InsertMemberDetails(Owner memberDetails)
        {
            var travelCreditDbDataContext = new TravelCreditDBDataContext();
            bool result;
            try
            {
                travelCreditDbDataContext.spInsertMemberInMemberDetails(memberDetails.Username,memberDetails.Memberships,memberDetails.MembershipStatuses,memberDetails.CountryOfResidence);
                result= true;

            }
            catch (Exception)
            {
                result=false;
                //TODO: log exception /handle
            }
            return result;
        }

        public List<spGetProductDetailsByConfirmationNumberResult> GetProductDetailsByConfirmationNumber(string confirmationNumber)
        {
            var tripDbDataContext = new TripDBDataContext();

            List<spGetProductDetailsByConfirmationNumberResult> getSuccessStatResult = tripDbDataContext.spGetProductDetailsByConfirmationNumber(confirmationNumber).ToList();

            return getSuccessStatResult;
        }

        public List<spGetTranscationDetailsResult> GetTranscationDetails(string userName, DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }
    }
}
