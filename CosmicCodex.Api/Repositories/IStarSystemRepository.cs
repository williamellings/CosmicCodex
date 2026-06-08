using CosmicCodex.Api.Models;
using System.Threading.Tasks;

namespace CosmicCodex.Api.Repositories
{
    public interface IStarSystemRepository : IGenericRepository<StarSystem>
    {
        Task<StarSystem?> GetWithPlanetsAsync(int id);
    }
}