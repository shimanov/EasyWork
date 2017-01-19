using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Domain.Entities
{
    [Table("PhoneBook")]
    public class PhoneBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required, MaxLength(100)]
        public string Fio { get; set; }

        [Required, MaxLength(50)]
        public string Pochtamt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
