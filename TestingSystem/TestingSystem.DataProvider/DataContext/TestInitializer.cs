using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TestingSystem.DataProvider.Manager;
using TestingSystem.Model;
using TestingSystem.Model.Identity;

namespace TestingSystem.DataProvider.DataContext
{
    public class TestInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            roleManager.Create(role1);
            roleManager.Create(role2);

            var admin = new ApplicationUser { Email = "admin@admin.com", UserName = "admin" };
            string password = "admin@admin.com";
            var result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }

            db.SaveChanges();
            base.Seed(db);
        }
    }
}
