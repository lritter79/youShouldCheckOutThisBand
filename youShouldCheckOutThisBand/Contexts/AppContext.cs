
using Microsoft.EntityFrameworkCore;
using youShouldCheckOutThisBand.Entities;

namespace youShouldCheckOutThisBand.Contexts
{
    public class AppContext: DbContext
    {

        public AppContext()
            : base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //point to local sql server instance and says that database will be called "AppData"
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSSQLLocalDB; Initial Catalog = AppData");
        }

        public DbSet<ImageEntity> Images { get; set; }
        public DbSet<TrackEntity> Tracks { get; set; }
        public DbSet<AlbumEntity> Albums { get; set; }
        public DbSet<ArtistEntity> Artists { get; set; }
    }
}
