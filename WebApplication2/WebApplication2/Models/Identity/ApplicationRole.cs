using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
