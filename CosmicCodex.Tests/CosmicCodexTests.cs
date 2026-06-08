using CosmicCodex.Api.DTOs;
using CosmicCodex.Api.Models;
using CosmicCodex.Api.Repositories;
using CosmicCodex.Api.Services;
using NSubstitute;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmicCodex.Tests
{
    public class CosmicCodexTests
    {
        private readonly IStarSystemRepository _starSystemRepositoryMock;
        private readonly IPlanetRepository _planetRepositoryMock;
        private readonly StarSystemService _starSystemService;
        private readonly PlanetService _planetService;

        public CosmicCodexTests()
        {
            // Initialize mocks using NSubstitute
            _starSystemRepositoryMock = Substitute.For<IStarSystemRepository>();
            _planetRepositoryMock = Substitute.For<IPlanetRepository>();

            // Inject mocks into the services via constructor injection
            _starSystemService = new StarSystemService(_starSystemRepositoryMock);
            _planetService = new PlanetService(_planetRepositoryMock);
        }

        // ==========================================
        // STAR SYSTEM SERVICE TESTS
        // ==========================================

        [Fact]
        public async Task StarSystem_GetAll_ReturnsAllSystems_HappyPath()
        {
            // --- Arrange ---
            var fakeSystems = new List<StarSystem>
            {
                new StarSystem { Id = 1, Name = "Milky Way" },
                new StarSystem { Id = 2, Name = "Andromeda" }
            };
            _starSystemRepositoryMock.GetAllAsync().Returns(fakeSystems);

            // --- Act ---
            var result = await _starSystemService.GetAllAsync();

            // --- Assert ---
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Milky Way", result.First().Name);
        }

        [Fact]
        public async Task StarSystem_GetById_ReturnsSystemWithPlanets_HappyPath()
        {
            // --- Arrange ---
            var systemId = 1;
            var fakeSystem = new StarSystem
            {
                Id = systemId,
                Name = "Solar System",
                Planets = new List<Planet> { new Planet { Id = 10, Name = "Earth", StarSystemId = systemId } }
            };
            _starSystemRepositoryMock.GetWithPlanetsAsync(systemId).Returns(fakeSystem);

            // --- Act ---
            var result = await _starSystemService.GetByIdAsync(systemId);

            // --- Assert ---
            Assert.NotNull(result);
            Assert.Equal("Solar System", result.Name);
            Assert.Single(result.Planets);
            Assert.Equal("Earth", result.Planets.First().Name);
        }

        [Fact]
        public async Task StarSystem_GetById_ReturnsNull_WhenSystemDoesNotExist_EdgeCase()
        {
            // --- Arrange ---
            var nonExistingId = 999;
            _starSystemRepositoryMock.GetWithPlanetsAsync(nonExistingId).Returns((StarSystem?)null);

            // --- Act ---
            var result = await _starSystemService.GetByIdAsync(nonExistingId);

            // --- Assert ---
            Assert.Null(result);
        }

        [Fact]
        public async Task StarSystem_Update_ReturnsFalse_WhenSystemNotFound_ErrorHandling()
        {
            // --- Arrange ---
            var systemId = 5;
            var updateDto = new StarSystemCreateDto { Name = "New Name" };
            _starSystemRepositoryMock.GetByIdAsync(systemId).Returns((StarSystem?)null);

            // --- Act ---
            var result = await _starSystemService.UpdateAsync(systemId, updateDto);

            // --- Assert ---
            Assert.False(result);
        }


        // ==========================================
        // PLANET SERVICE TESTS
        // ==========================================

        [Fact]
        public async Task Planet_Create_ReturnsCreatedPlanetDto_HappyPath()
        {
            // --- Arrange ---
            var createDto = new PlanetCreateDto { Name = "Mars", HasLife = false, StarSystemId = 1 };

            // --- Act ---
            var result = await _planetService.CreateAsync(createDto);

            // --- Assert ---
            Assert.NotNull(result);
            Assert.Equal("Mars", result.Name);
            Assert.False(result.HasLife);
            Assert.Equal(1, result.StarSystemId);
        }

        [Fact]
        public async Task Planet_GetById_ReturnsCorrectPlanet_HappyPath()
        {
            // --- Arrange ---
            var planetId = 42;
            var fakePlanet = new Planet { Id = planetId, Name = "Tatooine", HasLife = true, StarSystemId = 2 };
            _planetRepositoryMock.GetByIdAsync(planetId).Returns(fakePlanet);

            // --- Act ---
            var result = await _planetService.GetByIdAsync(planetId);

            // --- Assert ---
            Assert.NotNull(result);
            Assert.Equal("Tatooine", result.Name);
            Assert.True(result.HasLife);
        }

        [Fact]
        public async Task Planet_Delete_ReturnsFalse_WhenPlanetNotFound_ErrorHandling()
        {
            // --- Arrange ---
            var planetId = 100;
            _planetRepositoryMock.GetByIdAsync(planetId).Returns((Planet?)null);

            // --- Act ---
            var result = await _planetService.DeleteAsync(planetId);

            // --- Assert ---
            Assert.False(result);
        }
    }
}