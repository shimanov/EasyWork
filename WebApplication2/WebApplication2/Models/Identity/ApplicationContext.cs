using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication2.Models.Identity
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("IdentityDb")
        {
            
        }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}
