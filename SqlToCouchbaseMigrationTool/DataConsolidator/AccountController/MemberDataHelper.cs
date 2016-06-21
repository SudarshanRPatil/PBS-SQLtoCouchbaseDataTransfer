using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DBO = DataAccess.Model;
using DataConsolidator.Model;

namespace DataConsolidator
{
    public class MemberDataHelper
    {
        public Owner RetrieveMemberDetailsFromDB(string memberName)
        {
            var dbMemberDetails = new Operations().GetMemberDetails(memberName);
            Owner memberDetails = null;
            if(dbMemberDetails!=null && dbMemberDetails.Count>0)
            {
                var memberDetailsDB= dbMemberDetails[0];
               memberDetails = new Owner
                    {
                        Username = memberDetailsDB.MemberName,
                        CountryOfResidence = memberDetailsDB.MemberCountry,
                        Memberships = GetMemberShipDetails(memberDetailsDB.MemberShips, memberDetailsDB.MemberShipStatus)
                    };
                return memberDetails;
            }
            return memberDetails;
        }

        public void StoreMemberDetailsInDB(Owner memberDetails)
        {
            
        }

        private List<Membership> GetMemberShipDetails(string memberShipTypes, string memberShipStatuses)
        {
            var separators =new char[ ]{'|'};
            var memberShips = new List<Membership>();
            var memberShipTypesList = memberShipTypes.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            var memberShipStatusList = memberShipStatuses.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            //if(memberShipTypesList.Count()==memberShipStatusList.Count())
            //{
                var count = 0;
                foreach (var memberShipType in memberShipTypesList)
                {
                    var memberShip = new Membership
                        {
                            Type = memberShipType,
                            Status = ToEnum<StatusType>(memberShipStatusList[count])
                        };
                    count++;
                    memberShips.Add(memberShip);
                }
                
           // }
            return memberShips;
        }

        public static T ToEnum<T>(string value) where T : struct
        {
            var a = (T)Enum.Parse(typeof(T), value, true);
            T enumVal;
            Enum.TryParse(value, true, out enumVal);
            return enumVal;
        }
    }
}
