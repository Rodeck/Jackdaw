using ArenaAlbionuPoradnik.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ArenaAlbionuPoradnik.Helpers
{
    public class AADataContext: DbContext
    {
        public AADataContext() : base("AAData")
        {

        }

        public DbSet<NKingdom> Kingdoms { get; set; }
        public DbSet<NLocation> Locations { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}