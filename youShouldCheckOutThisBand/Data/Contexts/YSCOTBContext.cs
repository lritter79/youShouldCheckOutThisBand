﻿using Microsoft.EntityFrameworkCore;
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


        //passes options down to the baseclass
        public YSCOTBContext(DbContextOptions<YSCOTBContext> options): base(options)
        {

        }

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
            optionsBuilder.UseLoggerFactory(ConsoleLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            //this is where you can set properties for models

            //getting the keys for join tables for many to many relationships
            modelBuilder.Entity<ArtistAlbumJoinEntity>().ToTable("ArtistAlbumJoinTable").HasKey(s => new { s.ArtistId, s.AlbumId });
            modelBuilder.Entity<TrackArtistJoinEntity>().HasKey(s => new { s.ArtistId, s.TrackId });
            modelBuilder.Entity<GenreArtistJoinEntity>().HasKey(s => new { s.ArtistId, s.GenreId });
            modelBuilder.Entity<GenreAlbumJoinEntity>().HasKey(s => new { s.AlbumId, s.GenreId });

            //set votes on a track to 1 as the default
            modelBuilder.Entity<TrackEntity>()
                .Property(t => t.Votes)
                .HasDefaultValue(1);

            //this is one way to seed, but it's not efficient because it runs everytime dbcontext is instatiated
            //    modelBuilder.Entity<ArtistEntity>()
            //        .HasData(new ArtistEntity()
            //        {
            //            Id = "6DPYiyq5kWVQS4RGwxzPC7",
            //            Name = "Dr. Dre",
            //            Uri = "6DPYiyq5kWVQS4RGwxzPC7"
            //        });
            //}
        }
        
    }
}
