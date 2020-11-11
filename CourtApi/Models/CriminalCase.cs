using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtApi.Models
{
    public class CriminalCase : CourtCase
    {
        [StringLength(255)]
        [Required]
        public string Objective { get; set; }

        [StringLength(255)]
        [Required]
        public string Subjective { get; set; }
    }
}