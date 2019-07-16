using WebApiClient;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Collections.Generic;

namespace UnitTest
{

    [TestClass]
    public class UnitTest
    {

        [TestMethod()]
        public void GetUserDetailTest()
        {
            List<UserDetail> userDetails = ApiLists.GetUserDetails();
            Assert.AreEqual(userDetails.Count > 0, true);
        }

        [TestMethod()]
        public void GetUserDetailsTest()
        {
            UserDetail UserDetail = ApiLists.GetUserDetail(1);
            Assert.AreEqual(UserDetail.UserName, "rogers63");
        }

        [TestMethod()]
        public void InsertUserDetailTest()
        {
            int prevCount = ApiLists.GetCount();
            UserDetail data = new UserDetail
            {
                UserId = 100,
                UserName = "genie",
                FirstName = "will",
                LastName = "smith",
                Gender = "male",
                Password = "oooooo"
            };
            ApiLists.InsertUserDetail(data);
            int currCount = ApiLists.GetCount();
            Assert.AreEqual(prevCount+1, currCount);
        }

        [TestMethod()]
        public void UpdateUserDetailTest()
        {
            string prevPassword = ApiLists.GetUserDetail(100).Password;
            UserDetail data = new UserDetail
            {
                UserId = 100,
                UserName = "genie",
                FirstName = "will",
                LastName = "smith",
                Gender = "male",
                Password = "xxxxxxxx"
            };
            ApiLists.UpdateUserDetail(data);
            string currPassword = ApiLists.GetUserDetail(100).Password;

            Assert.AreEqual(prevPassword != currPassword, true);
        }

        [TestMethod()]
        public void DeleteUserDetailTest()
        {
            int prevCount = ApiLists.GetCount();
            ApiLists.DeleteUserDetail(100);
            int currCount = ApiLists.GetCount();

            Assert.AreEqual(prevCount, currCount+1);
        }

    }
}
