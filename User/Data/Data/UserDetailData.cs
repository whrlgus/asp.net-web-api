using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserDetailData
    {
        public int GetCount()
        {
            using (UserEntities context = DbContextFactory.Create())
            {
                return context.UserDetails.Count();
            }
        }
        public List<UserDetail> GetAll()
        {
            using (UserEntities context = DbContextFactory.Create())
            {
                IQueryable<UserDetail> query = context.Set<UserDetail>();
                var list = query.ToList();
                return list;
            }
        }

        public UserDetail GetByPK(int id)
        {
            using (UserEntities context = DbContextFactory.Create())
            {
                return context.UserDetails.FirstOrDefault(x => x.UserId == id);
            }
        }

        public void Insert(UserDetail userDetail)
        {
            using (UserEntities context = DbContextFactory.Create())
            {
                context.Set<UserDetail>().Add(userDetail);
                context.Entry(userDetail).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(UserDetail userDetail)
        {
            using (UserEntities context = DbContextFactory.Create())
            {
                context.Entry(userDetail).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteByPK(int id)
        {
            using (UserEntities context = DbContextFactory.Create())
            {
                var userDetail = context.UserDetails.FirstOrDefault(x => x.UserId == id);
                if (userDetail == null)
                    return;
                context.Entry(userDetail).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
