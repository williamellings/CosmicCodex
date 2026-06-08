using System.Collections.Generic;

namespace CosmicCodex.Api.DTOs
{
    public class StarSystemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<PlanetDto> Planets { get; set; } = new List<PlanetDto>();
    }
}