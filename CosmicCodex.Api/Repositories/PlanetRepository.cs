using CosmicCodex.Api.Data;
using CosmicCodex.Api.Models;

namespace CosmicCodex.Api.Repositories
{
    public class PlanetRepository : GenericRepository<Planet>, IPlanetRepository
    {
        public PlanetRepository(AppDbContext context) : base(context)
        {
        }
    }
}