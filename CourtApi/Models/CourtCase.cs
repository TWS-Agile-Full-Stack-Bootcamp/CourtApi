using System;
using System.ComponentModel.DataAnnotations;

namespace CourtApi.Models
{
    public class CourtCase
    {
        public int Id { get; set; }

        [StringLength(255)] [Required] public string Name { get; set; }

        [Required] public DateTime? CreatedDate { get; set; }

        public CriminalCase Detail { get; set; }
    }

    public class Procuratorate
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        [Key]
        public string Name { get; set; }
    }
}