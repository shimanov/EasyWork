using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Models.Authentication
{
    public class AuthenticationParams
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательное поле для заполнения")]
        [MinLength(3, ErrorMessage = "Минимум 3 символа")]
        public string User { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно для заполнения")]
        [MinLength(5, ErrorMessage = "Минимум 5 символов")]
        public string Password { get; set; }

        public bool IsAuthFailed { get; set; }
    }
}
