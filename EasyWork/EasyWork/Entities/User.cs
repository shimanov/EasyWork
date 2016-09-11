using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyWork.Entities.BaseId;

namespace EasyWork.Entities
{
    public class User : BaseIdEntity
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar")]
        public string Login { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(15)]
        [Column(TypeName = "nvarhar")]
        public string Passord { get; set; }
    }
}
