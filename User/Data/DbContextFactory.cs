using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public partial class UserEntities
    {
        public UserEntities(string connectionString) : base(connectionString)
        {
        }
    }
    public class DbContextFactory
    {

        public static UserEntities Create()
        {
            string connectionString =
            "metadata=res://*/User.csdl|res://*/User.ssdl|res://*/User.msl;provider=System.Data.SqlClient;provider connection string=\";data source=.;initial catalog=User;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework\";";
            UserEntities context = new UserEntities(connectionString);

            return context;
        }
    }
}
