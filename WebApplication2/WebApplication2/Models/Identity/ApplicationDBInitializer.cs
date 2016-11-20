using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication2.Models.Identity
{
    public class ApplicationDBInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManeger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //Create two roles
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            //Create roles
            roleManeger.Create(role1);
            roleManeger.Create(role2);

            //Create users
            var admin = new ApplicationUser
            {
                Email = "d.a.shimanov@gmail.com",
                UserName = "d.a.shimanov@gmail.com"
            };
            string password = "qwep[]ghjB1";
            var result = userManager.Create(admin, password);

            //If create user sacees
            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }
            base.Seed(context);
        }
    }
}
