using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication2.Models.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
            
        }

        public string Description { get; set; }
    }
}
