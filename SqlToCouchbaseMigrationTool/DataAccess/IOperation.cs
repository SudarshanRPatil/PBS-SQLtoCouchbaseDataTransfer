using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IOperation
    {
        List<spGetTranscationDetailsResult> GetTranscationDetails(DateTime fromDate, DateTime toDate);
        spMemberExistsInMemberDetailsResult GetMemberDetails(string memberName);

    }
}
