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
    public static class ApiLists
    {
        private const string BaseUrl = "https://localhost:44329/api/";
        public static int GetCount()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                HttpResponseMessage result = client.GetAsync($"userdetail/?count=").Result;

                return Convert.ToInt32(result.Content.ReadAsStringAsync().Result);
            }
        }
        public static List<UserDetail> GetUserDetails()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                HttpResponseMessage result = client.GetAsync("userdetail").Result;
                List<UserDetail> UserDetails = result.Content.ReadAsAsync<List<UserDetail>>().Result;
                return UserDetails;
            }
        }
        public static UserDetail GetUserDetail(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                HttpResponseMessage result = client.GetAsync($"userdetail/{id}").Result;

                string str = result.Content.ReadAsStringAsync().Result;
                UserDetail UserDetail = JsonConvert.DeserializeObject<UserDetail>(str);
                return UserDetail;
            }
        }
        public static string InsertUserDetail(UserDetail UserDetail)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                return client.PostAsJsonAsync($"userdetail", UserDetail).Result.Content.ReadAsStringAsync().Result;
            }
        }

        public static string UpdateUserDetail(UserDetail UserDetail)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                return client.PutAsJsonAsync($"userdetail", UserDetail).Result.Content.ReadAsStringAsync().Result;
            }
        }

        public static void DeleteUserDetail(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                HttpResponseMessage result = client.DeleteAsync($"userdetail/{id}").Result;

            }
        }
    }
}
