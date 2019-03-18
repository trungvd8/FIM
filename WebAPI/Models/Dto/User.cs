using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public partial class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "NCHAR(50)")]
        public string Display { get; set; }

        [Required]
        [Column(TypeName = "NCHAR(50)")]
        public string Name { get; set; }

        public Guid? ADGroupId { get; set; }

        public Guid? RoleId { get; set; }

        [Required]
        [Column(TypeName = "XML")]
        public string Token { get; set; }

        [Required]
        public long Version { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
