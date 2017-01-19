using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace WebApplication2.Domain.Entities
{
    [Table("Script")]
    public class Script
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [Required, AllowHtml, MaxLength]
        public string Scripts { get; set; }

        public bool IsDeleted { get; set; }
    }
}
