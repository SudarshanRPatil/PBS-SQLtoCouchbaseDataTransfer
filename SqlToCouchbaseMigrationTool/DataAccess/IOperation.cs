using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IOperation
    {
        List<spGetTranscationDetailsByTimeStampResult> GetTranscationDetailsByTimeStamp(DateTime fromDate, DateTime toDate);
        List<spGetTranscationDetailsByMemberNameResult> GetTranscationDetailsByUserName(string userName);
        List<spMemberExistsInMemberDetailsResult> GetMemberDetails(string memberName);
        List<spGetProductDetailsByConfirmationNumberResult> GetProductDetailsByConfirmationNumber(string confirmationNumber);
    }
}
