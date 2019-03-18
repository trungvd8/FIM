using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public partial class Vendor
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "NCHAR(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(150)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "NCHAR(10)")]
        public string TaxCode { get; set; }

        [Required]
        [Column(TypeName = "NCHAR(50)")]
        public string Owner { get; set; }

        [Required]
        [Column(TypeName = "NCHAR(20)")]
        public string Phone { get; set; }

        [Column(TypeName = "NCHAR(150)")]
        public string Email { get; set; }

        [Column(TypeName = "NCHAR(150)")]
        public string Website { get; set; }

        [Column(TypeName = "NCHAR(150)")]
        public string BankAccount { get; set; }

        [Column(TypeName = "NVARCHAR(150)")]
        public string Bank { get; set; }

        [Column(TypeName = "NVARCHAR(150)")]
        public string BankBranch { get; set; }

        [Required]
        public bool IsLock { get; set; }

        [Required]
        public bool Approved { get; set; }
    }
}
