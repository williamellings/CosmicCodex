using CosmicCodex.Api.Data;
using CosmicCodex.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CosmicCodex.Api.Repositories
{
    public class StarSystemRepository : GenericRepository<StarSystem>, IStarSystemRepository
    {
        public StarSystemRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<StarSystem?> GetWithPlanetsAsync(int id)
        {
            return await _context.StarSystems
                .Include(s => s.Planets)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}