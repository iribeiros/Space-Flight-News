using Microsoft.EntityFrameworkCore;
using Space_Flight_News.Models;

namespace Space_Flight_News.Data
{
    public class SpaceflightDBContext : DbContext
    {
        public SpaceflightDBContext(DbContextOptions<SpaceflightDBContext> options) : base(options)
        {

        }

        public DbSet<Spaceflight> Spaceflights { get; set; }



    }
}
