using System.ComponentModel.DataAnnotations;

namespace CourtApi.Models
{
    public class CriminalCase
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Objective { get; set; }

        [StringLength(255)]
        [Required]
        public string Subjective { get; set; }
    }
}