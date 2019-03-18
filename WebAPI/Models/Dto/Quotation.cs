using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public partial class Quotation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid QuotationHeaderId { get; set; }

        [Required]
        public Guid RFQDetailId { get; set; }

        public int? UnitPrice { get; set; }

        public long? Price { get; set; }

        [Required]
        [Column(TypeName = "NCHAR(10)")]
        public string TaxType { get; set; }

        public long? TaxAmount { get; set; }

        public long? Total { get; set; }

        public string Note { get; set; }

        public DateTime NoteForVendor { get; set; }

        public Guid VendorId { get; set; }
    }
}
