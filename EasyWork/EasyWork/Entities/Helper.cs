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
    public class Helper : BaseIdEntity
    {
        [Required]
        [StringLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Help { get; set; }

        [MaxLength]
        [Column(TypeName = "nvarchar")]
        public string Text { get; set; }
    }
}
