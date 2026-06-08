using CosmicCodex.Api.DTOs;
using CosmicCodex.Api.Models;
using CosmicCodex.Api.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmicCodex.Api.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly IPlanetRepository _repository;

        public PlanetService(IPlanetRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PlanetDto>> GetAllAsync()
        {
            var planets = await _repository.GetAllAsync();
            return planets.Select(p => new PlanetDto
            {
                Id = p.Id,
                Name = p.Name,
                HasLife = p.HasLife,
                StarSystemId = p.StarSystemId
            });
        }

        public async Task<PlanetDto?> GetByIdAsync(int id)
        {
            var planet = await _repository.GetByIdAsync(id);
            if (planet == null) return null;

            return new PlanetDto
            {
                Id = planet.Id,
                Name = planet.Name,
                HasLife = planet.HasLife,
                StarSystemId = planet.StarSystemId
            };
        }

        public async Task<PlanetDto> CreateAsync(PlanetCreateDto dto)
        {
            var planet = new Planet
            {
                Name = dto.Name,
                HasLife = dto.HasLife,
                StarSystemId = dto.StarSystemId
            };
            await _repository.AddAsync(planet);

            return new PlanetDto
            {
                Id = planet.Id,
                Name = planet.Name,
                HasLife = planet.HasLife,
                StarSystemId = planet.StarSystemId
            };
        }

        public async Task<bool> UpdateAsync(int id, PlanetCreateDto dto)
        {
            var planet = await _repository.GetByIdAsync(id);
            if (planet == null) return false;

            planet.Name = dto.Name;
            planet.HasLife = dto.HasLife;
            planet.StarSystemId = dto.StarSystemId;

            await _repository.UpdateAsync(planet);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var planet = await _repository.GetByIdAsync(id);
            if (planet == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}