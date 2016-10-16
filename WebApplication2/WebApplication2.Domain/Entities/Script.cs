using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Domain.Entities
{
    [Table("Script")]
    public class Script
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [MaxLength]
        public string Scripts { get; set; }

        public bool IsDeleted { get; set; }
    }
}
