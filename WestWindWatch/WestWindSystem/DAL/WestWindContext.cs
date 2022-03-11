using Microsoft.EntityFrameworkCore; // for DbContext, DbContextOptions
using WestWindSystem.Entities; // for Category

namespace WestWindSystem.DAL
{
    internal class WestWindContext : DbContext
    {
        public WestWindContext()
        {

        }

       public WestWindContext(DbContextOptions<WestWindContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<BuildVersion> BuildVersions { get; set; } = null!;

        public DbSet<BuildVersion> Region { get; set; } = null!;
    }
}
