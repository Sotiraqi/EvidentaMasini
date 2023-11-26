using System.ComponentModel.DataAnnotations;

namespace EvidentaMasini.Models
{
    public class CombustionType
    {
        [Key]
        public int combustionId { get; set; }
        [Required]
        [Display(Name = "Tip combustibil")]
        public string? combustion { get; set; }
    }
}
