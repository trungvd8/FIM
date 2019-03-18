using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public partial class Organization
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "NCHAR(10)")]
        public string Code { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        [Required]
        [Column(TypeName = "NCHAR(10)")]
        public string TaxCode { get; set; }

        [Required]
        public long Version { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public Guid? OrganizationUnitId { get; set; }

        public Guid? ADGroupId { get; set; }
    }
}
