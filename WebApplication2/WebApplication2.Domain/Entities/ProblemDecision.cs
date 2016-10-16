using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Domain.Entities
{
    [Table("ProblemDecision")]
    public class ProblemDecision
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Problem { get; set; }

        [Required]
        [MaxLength]
        public string Decision { get; set; }

        [Required]
        [MaxLength(20)]
        public string PosVersion { get; set; }

        public DateTime DataAdditional { get; set; }

        public bool IsDeleted { get; set; }
    }
}
