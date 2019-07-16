using Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            // get all
            List<UserDetail> UserDetails = ApiLists.GetUserDetails();

            // get by pk
            UserDetail UserDetail = ApiLists.GetUserDetail(1);

            // post
            int prevCnt = ApiLists.GetCount();
            UserDetail data = new UserDetail
            {
                UserId = prevCnt+1,
                UserName = "genie",
                FirstName = "will",
                LastName = "smith",
                Gender = "male",
                Password = "a1234",
                Status = 1
            };
            ApiLists.InsertUserDetail(data);

            // put
            data.UserId = prevCnt + 1;
            data.Password = "xxxxxxxx";
            ApiLists.UpdateUserDetail(data);

            // delete
            ApiLists.DeleteUserDetail(prevCnt + 1);
        }
        
    }
}
