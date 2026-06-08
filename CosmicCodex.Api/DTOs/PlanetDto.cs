namespace CosmicCodex.Api.DTOs
{
    public class PlanetDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool HasLife { get; set; }
        public int StarSystemId { get; set; }
    }
}