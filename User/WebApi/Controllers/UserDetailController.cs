using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class UserDetailController : ApiController
    {
        public int Get(string count)
        {
            return DataRepository.UserDetail.GetCount();
        }
        // GET api/<controller>
        public List<UserDetail> Get()
        {
            return DataRepository.UserDetail.GetAll();
        }

        // GET api/<controller>/5
        public UserDetail Get(int id)
        {
            return DataRepository.UserDetail.GetByPK(id);
        }

        // POST api/<controller>
        public void Post([FromBody]UserDetail userDetail)
        {
            
            DataRepository.UserDetail.Insert(userDetail);
        }

        // PUT api/<controller>/
        public void Put([FromBody]UserDetail userDetail)
        {
            DataRepository.UserDetail.Update(userDetail);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            DataRepository.UserDetail.DeleteByPK(id);
        }
    }
}