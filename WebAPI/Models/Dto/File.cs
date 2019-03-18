using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public partial class File
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public byte[] Content { get; set; }
    }
}
