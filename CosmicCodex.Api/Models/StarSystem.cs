namespace CosmicCodex.Api.Models
{
    public class StarSystem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Planet> Planets { get; set; } = new List<Planet>();
    }
}