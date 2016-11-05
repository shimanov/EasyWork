using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Models.Authentication
{
    public class AuthenticationParams
    {
        public string User { get; set; }

        public string Password { get; set; }

        public bool IsAuthFailed { get; set; }
    }
}
