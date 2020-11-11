using System.ComponentModel.DataAnnotations;

namespace CourtApi.Models
{
    public class Procuratorate
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        [Key]
        public string Name { get; set; }
    }
}