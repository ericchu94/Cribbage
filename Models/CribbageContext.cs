using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cribbage.Models
{
    public class CribbageContext : DbContext
    {
        public CribbageContext(DbContextOptions<CribbageContext> options)
            : base(options)
        { }

        public DbSet<Game> Games { get; set; }
    }
}
