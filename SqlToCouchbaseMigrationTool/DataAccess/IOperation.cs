using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess
{
    public interface IOperation
    {

        List<spGetTranscationDetailsResult> GetTranscationDetails(string userName, DateTime fromDate, DateTime toDate);
        List<spMemberExistsInMemberDetailsResult> GetMemberDetails(string memberName);
        bool InsertMemberDetails(Owner memberDetails);
        List<spGetProductDetailsByConfirmationNumberResult> GetProductDetailsByConfirmationNumber(string confirmationNumber);

    }
}
