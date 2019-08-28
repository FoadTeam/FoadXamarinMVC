namespace XamarinMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using XamarinMVC.Models;
    using System.Web.Security;


    internal sealed class Configuration : DbMigrationsConfiguration<XamarinMVC.Models.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "XamarinMVC.Models.DatabaseContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(XamarinMVC.Models.DatabaseContext context)
        {
            string MyHash = FormsAuthentication.HashPasswordForStoringInConfigFile("Foad@372", "MD5");
            DatabaseContext db = new DatabaseContext();
            if (db.Roles.Count() == 0)
            {
                Role role = new Role()
                {
                    RoleName = "Admin",
                    RoleTitle = "مدیر"
                  

                };
                db.Roles.Add(role);
                db.SaveChanges();
                User user = new User()
                {
                    IsActive = true,
                    Code = "123456",
                    RoleId = role.Id,
                    Mobile = "09393169709",
                    Password = MyHash ,
                    UserName = "Foad"
                };
                db.Users.Add(user);
                db.SaveChanges();

                Role role2 = new Role()
                {
                    RoleName = "user",
                    RoleTitle = "standarduser"


                };
                db.Roles.Add(role2);
                db.SaveChanges();

            }
            if(db.Settings.Count() == 0)
            {
                Setting setting = new Setting
                {
                    FactorIsSend=false,
                    Name="FoadXamarinMVC"
                };
                db.Settings.Add(setting);
                db.SaveChanges();
            }
        }
    }
}
