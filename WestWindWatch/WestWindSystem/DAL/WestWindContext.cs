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

        // Categories, BuildVersions, Regions name is whatever you want
        // DbSet manages a collection of <> type objects
        public DbSet<BuildVersion> BuildVersions { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;


        public DbSet<Region> Regions { get; set; } = null!;

        public DbSet<Territory> Territories  { get; set; } = null!;
    }
}
