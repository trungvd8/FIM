using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public partial class RFQMailCC
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RFQId { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
