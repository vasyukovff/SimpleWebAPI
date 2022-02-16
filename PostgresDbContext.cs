using Microsoft.EntityFrameworkCore;
using SimpleWebAPI.Models;

namespace SimpleWebAPI
{
    public class PostgresDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=simpleWebAPI;Username=postgres;Password=root");
        }

        public DbSet<VideoGameModel> VideoGames { get; set; }
    }
}
