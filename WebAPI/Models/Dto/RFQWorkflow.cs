using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public partial class RFQWorkflow
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RFQId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public DateTime? Time { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(150)")]
        public string Reason { get; set; }

        public byte? Level { get; set; }

        public long? Status { get; set; }
    }
}
