using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public partial class PurchaseRequest
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(150)")]
        public string Description { get; set; }

        public int Level { get; set; }

        [Required]
        [Column(TypeName = "NCHAR(10)")]
        public string Status { get; set; }

        public Guid? RootCategoryId { get; set; }

        public Guid? SubRootCategoryId { get; set; }

        public Guid? FileId { get; set; }

        public Guid? BudgetOrganizationId { get; set; }

        public Guid? BudgetOrganizationUnitId { get; set; }

        public Guid? BudgetGeoId { get; set; }

        [Required]
        [Column(TypeName = "NCHAR(10)")]
        public string BudgetPeriod { get; set; }

        public Guid? ProjectId { get; set; }

        public Guid? ProjectBudgetId { get; set; }

        public DateTime RequestCreateDate { get; set; }

        public Guid? RequestOrganizationId { get; set; }

        public Guid? RequestOrganizationUnitId { get; set; }

        public Guid? RequestUserId { get; set; }

        [Required]
        [Column(TypeName = "NCHAR(20)")]
        public string RequestPhoneNumber { get; set; }

        public DateTime? ReceiptDate { get; set; }

        [Column(TypeName = "NVARCHAR(150)")]
        public string ReceiveAddress { get; set; }

        public Guid? ReceiveOrganizationId { get; set; }

        public Guid? ReceiveOrganizationUnitId { get; set; }

        public Guid? ReceiveUserId { get; set; }

        [Column(TypeName = "NCHAR(20)")]
        public string ReceivePhoneNumber { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string BOMApprover { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string FADApprover { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string FPDApprover { get; set; }

        public DateTime CreateDate { get; set; }

        [Column(TypeName = "NVARCHAR(150)")]
        public string Comment { get; set; }

        [Column(TypeName = "NCHAR(50)")]
        public string Instock { get; set; }

        public Guid? VendorId { get; set; }

        [Column(TypeName = "NVARCHAR(150)")]
        public string Note { get; set; }

        [Column(TypeName = "NCHAR(150)")]
        public string BudgetRemaining { get; set; }

        [Required]
        public bool FrameContract { get; set; }

        public long Total { get; set; }
    }
}
