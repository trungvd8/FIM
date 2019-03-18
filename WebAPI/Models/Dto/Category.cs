using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public partial class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(200)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(200)")]
        public string Description { get; set; }

        public Guid? ExpertId { get; set; }

        public DateTime? DateTime { get; set; }

        [Required]
        public byte Level { get; set; }

        public Guid? ParentCategoryId { get; set; }

        public Guid? MasterContractId { get; set; }

        public Guid? CategoryOrganizationId { get; set; }
    }
}
