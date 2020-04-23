using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using youShouldCheckOutThisBand.Contexts;
using youShouldCheckOutThisBand.Entities;

namespace youShouldCheckOutThisBand.Data
{
    public class YSCOTBSeeder
    {
        private readonly YSCOTBContext _context;
        private readonly IWebHostEnvironment _hosting;

        public YSCOTBSeeder(YSCOTBContext ctx, IWebHostEnvironment hosting)
        {
            _context = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Artists.Any())
            {
                //if artists is empty, create sample data

                var sampleArtists = new List<ArtistEntity>()
                {
                    new ArtistEntity()
                    {
                        Name = "Dr. Dre",
                        Uri = "6DPYiyq5kWVQS4RGwxzPC7",
                        Images = new List<ArtistImageEntity>()
                    }
                };

                foreach (ArtistEntity a in sampleArtists)
                {
                    _context.Artists.Add(a);
                }

                var sampleImages = new List<ArtistImageEntity>()
                {
                    new ArtistImageEntity()
                    {
                        Url = "https://www.biography.com/.image/ar_1:1%2Cc_fill%2Ccs_srgb%2Cg_face%2Cq_auto:good%2Cw_300/MTQ3NTI3MDgzNTIwNjk3ODM4/dr_dre_photo_by_christopher_pol_getty_images_entertainment_getty_120919208.jpg",
                        Height=100,
                        Width=100,
                        Artist = sampleArtists.FirstOrDefault(a => a.Id == 1)
                    }
                };

                foreach (ArtistImageEntity a in sampleImages)
                {
                    _context.ArtistImages.Add(a);
                }

                var sampleGenres = new List<GenreEntity>()
                {
                    new GenreEntity()
                    {
                        Name = "Hip Hop"
                    }
                };

                foreach(var g in sampleGenres)
                {
                    _context.Genres.Add(g);
                }

                var sampleGenreArtistJoin = new GenreArtistJoinEntity
                {
                    ArtistId = sampleArtists[0].Id,
                    GenreId = sampleGenres[0].Id,
                    Artist = sampleArtists[0],
                    Genre = sampleGenres[0]
                };

                

                sampleArtists[0].ArtistsGenres.Add(sampleGenreArtistJoin);

                sampleArtists[0].Images.Add(sampleImages[0]);

                _context.GenresArtists.Add(sampleGenreArtistJoin);

            }
            
            _context.SaveChanges();
        }
    }
}
