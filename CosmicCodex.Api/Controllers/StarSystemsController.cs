using CosmicCodex.Api.DTOs;
using CosmicCodex.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmicCodex.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StarSystemsController : ControllerBase
    {
        private readonly IStarSystemService _starSystemService;

        // Här använder vi DI med interface istället för konkret klass (Krav!)
        public StarSystemsController(IStarSystemService starSystemService)
        {
            _starSystemService = starSystemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StarSystemDto>>> GetAll()
        {
            var systems = await _starSystemService.GetAllAsync();
            return Ok(systems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StarSystemDto>> GetById(int id)
        {
            var system = await _starSystemService.GetByIdAsync(id);
            if (system == null)
            {
                return NotFound($"Stjärnsystemet med ID {id} hittades inte.");
            }
            return Ok(system);
        }

        [HttpPost]
        public async Task<ActionResult<StarSystemDto>> Create(StarSystemCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdSystem = await _starSystemService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdSystem.Id }, createdSystem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StarSystemCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var success = await _starSystemService.UpdateAsync(id, dto);
            if (!success)
            {
                return NotFound($"Kunnde inte uppdatera. Stjärnsystemet med ID {id} hittades inte.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _starSystemService.DeleteAsync(id);
            if (!success)
            {
                return NotFound($"Kunnde inte radera. Stjärnsystemet med ID {id} hittades inte.");
            }

            return NoContent();
        }
    }
}