using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public partial class RFQDetail
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? RFQId { get; set; }

        public Guid? CategoryId { get; set; }

        public Guid? SubRootCategoryId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(500)")]
        public string Description { get; set; }

        public long Quantity { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(20)")]
        public string Unit { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(500)")]
        public string Note { get; set; }

        public DateTime NoteForVendor { get; set; }

        [Required]
        public bool IsApproved { get; set; }

        [Required]
        public byte Order { get; set; }

        public Guid? QuotationId { get; set; }

        public Guid? VendorId { get; set; }
    }
}
