using System.ComponentModel.DataAnnotations;

namespace CosmicCodex.Frontend.DTOs
{
    public class PlanetCreateDto
    {
        [Required(ErrorMessage = "Planetens namn krävs.")]
        [StringLength(100, ErrorMessage = "Namnet får inte vara längre än 100 tecken.")]
        public string Name { get; set; } = string.Empty;

        public bool HasLife { get; set; }

        [Required]
        public int StarSystemId { get; set; }
    }
}