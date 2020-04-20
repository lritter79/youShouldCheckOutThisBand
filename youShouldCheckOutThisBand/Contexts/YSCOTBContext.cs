using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using youShouldCheckOutThisBand.Entities;

namespace youShouldCheckOutThisBand.Contexts
{
    public class YSCOTBContext:DbContext
    {

        public DbSet<ArtistImageEntity> ArtistImages { get; set; }
        public DbSet<TrackEntity> Tracks { get; set; }
        public DbSet<AlbumEntity> Albums { get; set; }
        public DbSet<ArtistEntity> Artists { get; set; }
        public DbSet<AlbumCoverEntity> AlbumCovers { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }

        public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFilter((category, level) =>
                    //this part is so we only see db commands
                    category == DbLoggerCategory.Database.Command.Name
                    //this part filters a certain level of detail
                    && level == LogLevel.Information)
                .AddConsole();                
            });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //point to local sql server instance and says that database will be called "AppData"
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = YSCOTBAppData")
                .UseLoggerFactory(ConsoleLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //getting the keys for join tables for many to many relationships
            modelBuilder.Entity<ArtistAlbumJoinEntity>().ToTable("ArtistAlbumJoinTable").HasKey(s => new { s.ArtistSpotifyId, s.AlbumSpotifyId });
            modelBuilder.Entity<TrackArtistJoinEntity>().HasKey(s => new { s.ArtistSpotifyId, s.TrackSpotifyId });
            modelBuilder.Entity<GenreArtistJoinEntity>().HasKey(s => new { s.ArtistSpotifyId, s.GenreId });
            modelBuilder.Entity<GenreAlbumJoinEntity>().HasKey(s => new { s.AlbumSpotifyId, s.GenreId });

            //set votes on a track to 1 as the default
            modelBuilder.Entity<TrackEntity>()
                .Property(t => t.Votes)
                .HasDefaultValue(1);
        }

        
    }
}
