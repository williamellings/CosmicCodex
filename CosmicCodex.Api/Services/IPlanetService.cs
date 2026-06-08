using CosmicCodex.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmicCodex.Api.Services
{
    public interface IPlanetService
    {
        Task<IEnumerable<PlanetDto>> GetAllAsync();
        Task<PlanetDto?> GetByIdAsync(int id);
        Task<PlanetDto> CreateAsync(PlanetCreateDto dto);
        Task<bool> UpdateAsync(int id, PlanetCreateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}