using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;

        public YSCOTBSeeder(YSCOTBContext ctx, IWebHostEnvironment hosting, UserManager<AppUser> userManager)
        {
            _context = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        //make seed asynchronous by making it a task
        public async Task SeedAsync()
        {
            _context.Database.EnsureCreated();

            //await makes it async
            AppUser user = await _userManager.FindByEmailAsync("foo@bar.com");
            //create user if user hasnt been created already
            if (user == null)
            {
                user = new AppUser()
                {
                    FirstName = "Biff",
                    LastName = "Boof",
                    Email = "foo@bar.com",
                    UserName = "Test"
                };

                //asyncly created user
                var result = await _userManager.CreateAsync(user, "Dummy1794!");
                //if new user isnt created
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user");
                }
            }

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
