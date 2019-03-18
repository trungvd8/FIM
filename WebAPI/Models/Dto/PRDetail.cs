using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public partial class PRDetail
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid PurchaseRequestId { get; set;  }

        public Guid? RFQId { get; set;  }

        public Guid? CategoryId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string Unit { get; set; }

        [Required]
        public int RequestQuantity { get; set; }

        [Required]
        public int InstockQuantity { get; set; }

        [Required]
        public int PurchaseQuantity { get; set; }

        [Required]
        public int UnitPrice { get; set; }

        [Required]
        public long Price { get; set; }

        public int? RemainQuantity { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string TaxType { get; set; }

        public long TaxAmount { get; set; }

        public long Total { get; set; }

        [Column(TypeName = "NVARCHAR(150)")]
        public string Note { get; set; }

        public int Order { get; set; }

        [Column(TypeName = "NVARCHAR(150)")]
        public string Description { get; set; }
    }
}
