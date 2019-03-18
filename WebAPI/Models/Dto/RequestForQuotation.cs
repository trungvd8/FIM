using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Modules.Repository;

namespace WebAPI.Models
{
    public partial class RequestForQuotation: Base
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(150)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(150)")]
        public string ReceivedAddress { get; set; }

        [Required]
        public Guid OrganizationUnitId { get; set; }

        [Required]
        public Guid OrganizationId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid HandlerId { get; set; }

        [Required]
        public Guid SubRootCategoryId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string Note { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(500)")]
        public string Comment { get; set; }

        public Guid? FileId { get; set; }

        public Guid? QuotationByVendorId { get; set; }

        public Guid? PurchaseRequestId { get; set; }

        internal override string _Id => throw new NotImplementedException();
    }
}
