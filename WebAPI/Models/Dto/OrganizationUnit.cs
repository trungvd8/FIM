using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class OrganizationUnit
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid OrganizationId { get; set; }

        [Required]
        [Column(TypeName = "NCHAR(10)")]
        public string Code { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string Name { get; set; }

        public long? Version { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
