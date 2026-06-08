using Microsoft.EntityFrameworkCore;
using System.Numerics;
using CosmicCodex.Api.Models;

namespace CosmicCodex.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Dessa DbSets representerar tabellerna i din databas
        public DbSet<StarSystem> StarSystems { get; set; }
        public DbSet<Planet> Planets { get; set; }
    }
}