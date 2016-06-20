using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using PIMS.DataContract;
using PC=PIMS.Client;
using DataConsolidator.Model;

namespace DataConsolidator
{
    public class AccountHandler
    {
        public void GetMemberAccountDetails(string userName)
        {
            //TODO : get details from table . if not esists fetch them from vexiere and store in table

        }


        public MemberDetails GetAccountDetailsFromVexiere(string userName)
        {
            var vexiereUser = GetAccountDetailsByUserName(userName);
            var membershipDetails = GetMemberShipDetails(vexiereUser);
            var memberDetails = new MemberDetails
                {
                    MemberName = vexiereUser.UserName,
                    MemberCountry = (vexiereUser.Profile != null) ? vexiereUser.Profile.CountryCode : string.Empty,
                    MemberShips = membershipDetails[1],
                    MemberShipStatuses = membershipDetails[2]
                };
            return memberDetails;
        }

        public Dictionary<int,string> GetMemberShipDetails(User account)
        {
            var memberShipDetails = new Dictionary<int, string>();
            var memberShips = string.Empty;
            var memberShipstatuses = string.Empty;
            if(account.Profile!=null && account.Profile.Memberships!=null)
            {
                var count = 1;
                account.Profile.Memberships.ToList().ForEach(m =>
                {
                    memberShips = string.Format("{0}{1}", m.MembershipType, (count<account.Profile.Memberships.Count)?"|":string.Empty);
                    memberShipstatuses = string.Format("{0}{1}", m.Status, (count < account.Profile.Memberships.Count) ? "|" : string.Empty);
                    count++;
                });

            }
            memberShipDetails.Add(1,memberShips);
            memberShipDetails.Add(2,memberShipstatuses);
            return memberShipDetails;

        }

        public User GetAccountDetailsByUserName(string userName)
        {

           
            User account = null;
            try
            {                             
                    var getUserRequest = new GetUserRequest()
                    {
                        AccountInformationFlag = AccountInformation.All,
                        IdentifierType = AccountIdentifierType.Username,
                        Username = userName
                    };
                    var getUserResponse = new PC.Client().GetUser(getUserRequest);
                    if (getUserResponse != null && getUserResponse.ServiceStatus != null)
                    {
                        if (getUserResponse.ServiceStatus.Status == ServiceStatusType.Failure)
                        {
                            throw new Exception(getUserResponse.ServiceStatus.Message);
                        }
                        account = getUserResponse.User;
                    }
                
            }
            catch (Exception)
            {
               
            }
           
            return account;
        }
    }
}
