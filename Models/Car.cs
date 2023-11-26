using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvidentaMasini.Models
{
    public class Car
    {
        [Required]
        [Display(Name = "Numar de sasiu (VIN)")]
        public string? vin {  get; set; }
        [Required]
        [Display(Name = "Marca")]
        public string? make { get; set; }
        [Required]
        [Display(Name = "Tip")]
        public string? tip { get; set; }
        [Required]
        [Display(Name = "Model")]
        public string? model { get; set; }
        [Required]
        [Display(Name = "Capacitatea cilindrica")]
        public int capacity { get; set; }
        [Required]
        [ForeignKey("combustionId")]
        public virtual CombustionType? combustion { get; set; }
        [Required]
        [Display(Name = "Masa maxima autorizata")]
        public int weight {  get; set; }
        [Required]
        [Display(Name = "Culoare")]
        public string? color { get; set; }
        [Required]
        [Display(Name = "Puterea (kW)")]
        public int power { get; set; }
        [Required]
        [Display(Name = "CIV")]
        public string? civ {  get; set; }
        [Required]
        [Display(Name = "Nr. de inmatriculare")]
        public string? plates { get; set; }
        [Required]
        [Display(Name = "Data ultimei inamtricularii")]
        public DateTime? registration { get; set; }
        [Required]
        [Display(Name = "Proprietar")]
        public string? owner { get; set;}
        [Required]
        [Display(Name = "Revizie ITP")]
        public DateTime? revision { get; set; }

    }
}
