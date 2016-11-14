using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.Identity
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Passord { get; set; }
    }
}
