﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Domain.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public bool IsDeleted { get; set; }

        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

    }
}