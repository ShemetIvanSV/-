using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учёт_Технических_Ресурсов.Model.Users
{
    class UserContext : DbContext
    {
        static UserContext()
        {
            Database.SetInitializer(new UsersInitializer());
        }
        public UserContext() : base("UserDataBase") { }
        public DbSet<User> Users { get; set; }
    }
}
