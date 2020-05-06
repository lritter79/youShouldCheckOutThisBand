using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly DbContextOptions<YSCOTBContext> _options;

        public YSCOTBSeeder(YSCOTBContext ctx, IWebHostEnvironment hosting, UserManager<AppUser> userManager, DbContextOptions<YSCOTBContext> options)
        {
            _context = ctx;
            _hosting = hosting;
            _userManager = userManager;
            _options = options;

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
                    UserName = "foo@bar.com"
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
                //InsertNewAlbumWithTrack();
            }
            //{
            //    //if artists is empty, create sample data

            //    var sampleArtists = new List<ArtistEntity>()
            //    {
            //        new ArtistEntity()
            //        {
            //            Name = "Dr. Dre",
            //            Uri = "6DPYiyq5kWVQS4RGwxzPC7",
                        
            //        }
            //    };

            //    foreach (ArtistEntity a in sampleArtists)
            //    {
            //        _context.Artists.Add(a);
            //    }

            //    var sampleImages = new List<ArtistImageEntity>()
            //    {
            //        new ArtistImageEntity()
            //        {
            //            Url = "https://www.biography.com/.image/ar_1:1%2Cc_fill%2Ccs_srgb%2Cg_face%2Cq_auto:good%2Cw_300/MTQ3NTI3MDgzNTIwNjk3ODM4/dr_dre_photo_by_christopher_pol_getty_images_entertainment_getty_120919208.jpg",
            //            Height=100,
            //            Width=100,
            //            Artist = sampleArtists.FirstOrDefault(a => a.Id == 1)
            //        }
            //    };

            //    foreach (ArtistImageEntity a in sampleImages)
            //    {
            //        _context.ArtistImages.Add(a);
            //    }

            //    var sampleGenres = new List<GenreEntity>()
            //    {
            //        new GenreEntity()
            //        {
            //            Name = "Hip Hop"
            //        }
            //    };

            //    foreach(var g in sampleGenres)
            //    {
            //        _context.Genres.Add(g);
            //    }

            //    var sampleGenreArtistJoin = new GenreArtistJoinEntity
            //    {
            //        ArtistId = sampleArtists[0].Id,
            //        GenreId = sampleGenres[0].Id,
            //        Artist = sampleArtists[0],
            //        Genre = sampleGenres[0]
            //    };

            //    var sampleAlbum = new AlbumEntity {
            //        Uri = "spotify:album:6ZnMFVV5HDv2xmHG7bn7et",
                    
            //    };

            //    var sampleTrack = new TrackEntity
            //    {
            //        Uri = "spotify:track:503OTo2dSqe7qk76rgsbep",
            //        Album = sampleAlbum
            //    };

            //    var sampleArtistAlbumJoin = new ArtistAlbumJoinEntity
            //    {
            //        Album = sampleAlbum,
            //        Artist = sampleArtists[0],
            //        AlbumId = sampleAlbum.Id,
            //        ArtistId = sampleArtists[0].Id
            //    };

            //    var sampleAlbumGenreJoin = new

            //    sampleAlbum.Tracks.Add(sampleTrack);
                

            //    sampleArtists[0].ArtistsGenres.Add(sampleGenreArtistJoin);

            //    sampleArtists[0].Images.Add(sampleImages[0]);

            //    _context.ArtistsAlbums.Add(sampleArtistAlbumJoin);

            //    _context.GenresArtists.Add(sampleGenreArtistJoin);

            //}
            
            _context.SaveChanges();
        }

        private void InsertNewAlbumWithTrack()
        {


            var album = new AlbumEntity
            {
                Name = "Compton",
                Tracks = new List<TrackEntity>()
                {
                    new TrackEntity()
                    {
                        Name = "Intro",
                        Uri = "spotify:track:1uftnTuei3ckZpNZxHKgRJ"
                    }
                },
                Uri = "spotify:album:6ZnMFVV5HDv2xmHG7bn7et"
            };

            _context.SaveChanges();
        }

        private void AddNewTrackToExistingArtistWhileTracked()
        {
            var album = _context.Albums.FirstOrDefault();
            album.Tracks.Add(new TrackEntity
            {
                Name = "It's All On Me",
                Uri = "spotify:track:57KXAlfzVwxhBtHkvMatrd"
            });

            _context.SaveChanges();
        }

        private void AddNewTrackToExistingArtistWhileUntracked(int albumId)
        {
            var album = _context.Albums.Find(albumId);
            album.Tracks.Add(new TrackEntity
            {
                Name = "All In A Days Work",
                Uri = "spotify:track:53RG6rDqEvGDsZ0Ijr3ur1"
            });

            using (var newContext = new YSCOTBContext(_options))
            {
                                   //this updates the existing object, and adds the the track
                //newContext.Albums.Update(album);
                                //Attach just connects the object and sets it's state to unmodified
                                //but still inserts the track with the album's id
                newContext.Albums.Attach(album);
                newContext.SaveChanges();
            }
        }

        private void AddNewTrackToExistingArtistWhileUntracked_EasyVersion(int albumId)
        {
            var track = new TrackEntity
            {
                Name = "Loose Cannon",
                Uri = "spotify:track:5Pkik37ckb0NKfsxkVH5Ky",
                AlbumId = albumId
            };

            using (var newContext = new YSCOTBContext(_options))
            {
                newContext.Tracks.Add(track);
                newContext.SaveChanges();
            }
        }
    }
}
