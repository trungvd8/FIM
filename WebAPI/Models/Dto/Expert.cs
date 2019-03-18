using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public partial class Expert
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "NCHAR(10)")]
        public string ExpertContent { get; set; }
    }
}
