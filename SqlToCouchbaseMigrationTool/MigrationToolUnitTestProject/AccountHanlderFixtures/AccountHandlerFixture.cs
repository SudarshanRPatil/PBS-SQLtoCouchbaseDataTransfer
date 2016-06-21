using System;
using DataConsolidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MigrationToolUnitTestProject.AccountHanlderTestCases
{
    [TestClass]
    public class AccountHandlerFixture
    {
        [TestMethod]
        public void GetAccountDetailsFromVexiere()
        {
            var memberName = "3285301";
            var user = new AccountHandler().GetAccountDetailsFromVexiere(memberName);            
                Assert.AreNotEqual(null,user);
                Assert.AreEqual(memberName, user.Username);
        }

        //delete member details for required member from table and test changes\
        //TODO: need to refactor
        [TestMethod]
        public void GetMemberAccountDetails_MemberDoesNotExistInDB()
        {
            var memberName = "3285301";
            var user = new AccountHandler().GetMemberAccountDetails(memberName);
            Assert.AreNotEqual(null, user);
            Assert.AreEqual(memberName, user.Username);
        }
    }
}
