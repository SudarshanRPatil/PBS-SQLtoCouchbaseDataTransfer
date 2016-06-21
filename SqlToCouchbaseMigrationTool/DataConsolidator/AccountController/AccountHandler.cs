using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using PD = PIMS.DataContract;
using PC = PIMS.Client;
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

        public Owner GetMemberAccountDetails(string userName)
        {
            //TODO: add error handling . if account retrived from vexiere is null throw exception
            try
            {
                var memberDetails = _memberDataHelper.RetrieveMemberDetailsFromDB(userName);
                if (memberDetails == null)
                {
                    memberDetails = GetAccountDetailsFromVexiere(userName);
                    if (memberDetails == null)
                        throw new Exception(string.Format("Member with username {0} does not exists in a system", userName));

                    _memberDataHelper.StoreMemberDetailsInDB(memberDetails);
                }
                return memberDetails;
            }
            catch (Exception ex)
            {


            }
            return null;
        }


        public Owner GetAccountDetailsFromVexiere(string userName)
        {
            var vexiereUser = GetAccountDetailsByUserName(userName);

            if (vexiereUser != null)
            {
                var memberDetails = new Owner
                {
                    Username = vexiereUser.UserName,
                    CountryOfResidence = (vexiereUser.Profile != null) ? vexiereUser.Profile.CountryCode : string.Empty,
                    Memberships = GetMemberShipDetails(vexiereUser)
                };

                return memberDetails;
            }
            return null;
        }


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
                                                                                      Status = m.Status
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
