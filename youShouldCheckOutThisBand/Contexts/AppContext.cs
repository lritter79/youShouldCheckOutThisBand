using Microsoft.EntityFrameworkCore;
using youShouldCheckOutThisBand.Entities;

namespace youShouldCheckOutThisBand.Contexts
{
    public class AppContext:DbContext
    {

        

        public DbSet<ArtistImageEntity> ArtistImages { get; set; }
        public DbSet<TrackEntity> Tracks { get; set; }
        public DbSet<AlbumEntity> Albums { get; set; }
        public DbSet<ArtistEntity> Artists { get; set; }
        public DbSet<AlbumCoverEntity> AlbumCovers { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //point to local sql server instance and says that database will be called "AppData"
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSSQLLocalDB; Initial Catalog = AppData");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //getting the keys for join tables for many to many relationships
            modelBuilder.Entity<ArtistAlbumJoinEntity>().HasKey(s => new { s.ArtistSpotifyId, s.AlbumSpotifyId });
            modelBuilder.Entity<TrackArtistJoinEntity>().HasKey(s => new { s.ArtistSpotifyId, s.TrackSpotifyId });
            modelBuilder.Entity<GenreArtistJoinEntity>().HasKey(s => new { s.ArtistSpotifyId, s.GenreId });
            modelBuilder.Entity<GenreAlbumJoinEntity>().HasKey(s => new { s.AlbumSpotifyId, s.GenreId });
            
        }

        
    }
}
