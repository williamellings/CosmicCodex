using CosmicCodex.Api.DTOs;
using CosmicCodex.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmicCodex.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanetsController : ControllerBase
    {
        private readonly IPlanetService _planetService;

        // Här använder vi DI med interface istället för konkret klass (Krav!)
        public PlanetsController(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanetDto>>> GetAll()
        {
            var planets = await _planetService.GetAllAsync();
            return Ok(planets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlanetDto>> GetById(int id)
        {
            var planet = await _planetService.GetByIdAsync(id);
            if (planet == null)
            {
                return NotFound($"Planeten med ID {id} hittades inte.");
            }
            return Ok(planet);
        }

        [HttpPost]
        public async Task<ActionResult<PlanetDto>> Create(PlanetCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdPlanet = await _planetService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdPlanet.Id }, createdPlanet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PlanetCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var success = await _planetService.UpdateAsync(id, dto);
            if (!success)
            {
                return NotFound($"Kunde inte uppdatera. Planeten med ID {id} hittades inte.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _planetService.DeleteAsync(id);
            if (!success)
            {
                return NotFound($"Kunde inte radera. Planeten med ID {id} hittades inte.");
            }

            return NoContent();
        }
    }
}