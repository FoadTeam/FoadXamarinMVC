using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace XamarinMVC.Models
{
    public class DatabaseContext :DbContext
    {
        static DatabaseContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext,Migrations.Configuration>());
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> users { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}