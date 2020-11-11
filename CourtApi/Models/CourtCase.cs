using System;
using System.ComponentModel.DataAnnotations;

namespace CourtApi.Models
{
    public class CourtCase
    {
        public int Id { get; set; }

        [StringLength(255)] [Required] public string Name { get; set; }

        [Required] public DateTime? CreatedDate { get; set; }

        public CaseDetail Detail { get; set; }
    }
}