namespace CosmicCodex.Api.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool HasLife { get; set; }
        public int StarSystemId { get; set; }
        public StarSystem? StarSystem { get; set; }
    }
}