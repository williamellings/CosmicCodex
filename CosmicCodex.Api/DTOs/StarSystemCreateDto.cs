using System.ComponentModel.DataAnnotations;

namespace CosmicCodex.Api.DTOs
{
    public class StarSystemCreateDto
    {
        [Required(ErrorMessage = "Namnet på stjärnsystemet krävs.")]
        [StringLength(100, ErrorMessage = "Namnet får inte vara längre än 100 tecken.")]
        public string Name { get; set; } = string.Empty;
    }
}