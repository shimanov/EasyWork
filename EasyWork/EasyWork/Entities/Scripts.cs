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
    [Table("Scripts")]
    public class Scripts : BaseIdEntity
    {
        [Required]
        [StringLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Description { get; set; }

        [Required]
        [StringLength(450)]
        [Column(TypeName = "nvarchar")]
        public string Script { get; set; }

        [Required]
        public DateTime DataAddition { get; set; }
    }
}
