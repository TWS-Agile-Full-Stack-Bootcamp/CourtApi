using System.ComponentModel.DataAnnotations;

namespace CourtApi.Models
{
    public class Prosecutor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Procuratorate Procuratorate { get; set; }
    }
}