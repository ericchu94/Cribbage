using Microsoft.EntityFrameworkCore;

namespace Cribbage.Models
{
    public class CribbageContext : DbContext
    {
        public CribbageContext(DbContextOptions<CribbageContext> options)
            : base(options)
        { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
