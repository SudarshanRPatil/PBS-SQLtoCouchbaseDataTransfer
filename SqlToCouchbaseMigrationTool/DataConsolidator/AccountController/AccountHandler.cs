using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using PD=PIMS.DataContract;
using PC=PIMS.Client;
using DataConsolidator.Model;

namespace DataConsolidator
{
    public class AccountHandler
    {
        private MemberDataHelper _memberDataHelper;
        public AccountHandler()
        {
             _memberDataHelper = new MemberDataHelper();
        }

        public void GetMemberAccountDetails(string userName)
        {
            //TODO : get details from table . if not esists fetch them from vexiere and store in table
           
            var memberDetails = _memberDataHelper.RetrieveMemberDetailsFromDB(userName) ??
                             GetAccountDetailsFromVexiere(userName);
        }


        private Owner GetAccountDetailsFromVexiere(string userName)
        {
            var vexiereUser = GetAccountDetailsByUserName(userName);
            var membershipDetails = GetMemberShipDetails(vexiereUser);
            var memberDetails = new Owner
                {
                    Username = vexiereUser.UserName,
                    CountryOfResidence = (vexiereUser.Profile != null) ? vexiereUser.Profile.CountryCode : string.Empty,                    
                    Memberships = GetMemberShipDetails(vexiereUser)
                };
                                                      
            return memberDetails;
        }

        //private Dictionary<int,string> GetMemberShipDetails(PD.User account)
        //{
           
        //    var memberShipDetails = new Dictionary<int, string>();
        //    var memberShips = string.Empty;
        //    var memberShipstatuses = string.Empty;
        //    if(account.Profile!=null && account.Profile.Memberships!=null)
        //    {
        //        var count = 1;
        //        account.Profile.Memberships.ToList().ForEach(m =>
        //        {
        //            memberShips = string.Format("{0}{1}", m.MembershipType, (count<account.Profile.Memberships.Count)?"|":string.Empty);
        //            memberShipstatuses = string.Format("{0}{1}", m.Status, (count < account.Profile.Memberships.Count) ? "|" : string.Empty);
        //            count++;
        //        });

        //    }           
        //    memberShipDetails.Add(1,memberShips);
        //    memberShipDetails.Add(2,memberShipstatuses);
        //    return memberShipDetails;           

        //}

        private List<Membership> GetMemberShipDetails(PD.User account)
        {
            var memberShips = new List<Membership>();
            if (account.Profile != null && account.Profile.Memberships != null)
            {
               
                account.Profile.Memberships.ToList().ForEach(m =>
                    {
                        var memberShip = new Membership
                            {
                                Type = m.MembershipType,
                                Status = MemberDataHelper.ToEnum<StatusType>(m.Status)
                            };  
                        memberShips.Add(memberShip);         
                });

            }
            return memberShips;
        }

        private PD.User GetAccountDetailsByUserName(string userName)
        {

           
            PD.User account = null;
            try
            {                             
                    var getUserRequest = new PD.GetUserRequest()
                    {
                        AccountInformationFlag = PD.AccountInformation.All,
                        IdentifierType = PD.AccountIdentifierType.Username,
                        Username = userName
                    };
                    var getUserResponse = new PC.Client().GetUser(getUserRequest);
                    if (getUserResponse != null && getUserResponse.ServiceStatus != null)
                    {
                        if (getUserResponse.ServiceStatus.Status == PD.ServiceStatusType.Failure)
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
