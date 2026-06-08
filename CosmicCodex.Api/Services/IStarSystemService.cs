using CosmicCodex.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmicCodex.Api.Services
{
    public interface IStarSystemService
    {
        Task<IEnumerable<StarSystemDto>> GetAllAsync();
        Task<StarSystemDto?> GetByIdAsync(int id);
        Task<StarSystemDto> CreateAsync(StarSystemCreateDto dto);
        Task<bool> UpdateAsync(int id, StarSystemCreateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}