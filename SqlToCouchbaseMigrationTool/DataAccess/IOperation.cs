using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IOperation
    {

        List<spGetTranscationDetailsResult> GetTranscationDetails(string userName, DateTime fromDate, DateTime toDate);
        List<spMemberExistsInMemberDetailsResult> GetMemberDetails(string memberName);
        List<spGetProductDetailsByConfirmationNumberResult> GetProductDetailsByConfirmationNumber(string confirmationNumber);

    }
}
