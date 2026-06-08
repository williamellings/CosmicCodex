using CosmicCodex.Api.DTOs;
using CosmicCodex.Api.Models;
using CosmicCodex.Api.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmicCodex.Api.Services
{
    public class StarSystemService : IStarSystemService
    {
        private readonly IStarSystemRepository _repository;

        public StarSystemService(IStarSystemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StarSystemDto>> GetAllAsync()
        {
            var systems = await _repository.GetAllAsync();
            return systems.Select(s => new StarSystemDto
            {
                Id = s.Id,
                Name = s.Name
            });
        }

        public async Task<StarSystemDto?> GetByIdAsync(int id)
        {
            var system = await _repository.GetWithPlanetsAsync(id);
            if (system == null) return null;

            return new StarSystemDto
            {
                Id = system.Id,
                Name = system.Name,
                Planets = system.Planets.Select(p => new PlanetDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    HasLife = p.HasLife,
                    StarSystemId = p.StarSystemId
                }).ToList()
            };
        }

        public async Task<StarSystemDto> CreateAsync(StarSystemCreateDto dto)
        {
            var system = new StarSystem { Name = dto.Name };
            await _repository.AddAsync(system);

            return new StarSystemDto { Id = system.Id, Name = system.Name };
        }

        public async Task<bool> UpdateAsync(int id, StarSystemCreateDto dto)
        {
            var system = await _repository.GetByIdAsync(id);
            if (system == null) return false;

            system.Name = dto.Name;
            await _repository.UpdateAsync(system);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var system = await _repository.GetByIdAsync(id);
            if (system == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}