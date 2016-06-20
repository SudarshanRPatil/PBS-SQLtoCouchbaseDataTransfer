using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Operations : IOperation
    {
        public List<spGetTranscationDetailsResult> GetTranscationDetails(DateTime fromDate, DateTime toDate)
        {
            var getSuccessStatResult = new List<spGetTranscationDetailsResult>();

            DataMigrationDbContext.UsingCommonContentDbRead(db =>
            {
                getSuccessStatResult = db.spGetTranscationDetails(fromDate, toDate).ToList();
            });

            return getSuccessStatResult;

        }


        public spMemberExistsInMemberDetailsResult GetMemberDetails(string memberName)
        {
            
        }
    }
}
