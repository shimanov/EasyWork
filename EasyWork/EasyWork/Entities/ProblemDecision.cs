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
    [Table("ProblemDecision")]
    public class ProblemDecision : BaseIdEntity
    {
        [Required]
        [StringLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Problem { get; set; }

        [Required]
        [MaxLength]
        [Column(TypeName = "nvarchar")]
        public string Decision { get; set; }

        [Required]
        public DateTime DataAdditional { get; set; }
    }
}
