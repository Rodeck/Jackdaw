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
        public DbSet<Place> Places { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<ProcessedMaterial> ProcessedMaterials { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<MenuModel> Menu { get; set; }
    }
}