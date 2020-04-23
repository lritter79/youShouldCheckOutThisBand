using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using youShouldCheckOutThisBand.Contexts;
using youShouldCheckOutThisBand.Entities;

namespace youShouldCheckOutThisBand.Data
{
    /*
     * 
     */
    public class YSCOTBRepository : IYSCOTBRepository
    {
        private readonly YSCOTBContext _context;

        public YSCOTBRepository(YSCOTBContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<ArtistEntity> GetAllArtistEntities()
        {
            var artists = _context.Artists.ToList();

            foreach (ArtistEntity a in artists)
            {
                a.Images = _context.ArtistImages.Where(img => img.Artist.Id == a.Id).ToList();
                a.ArtistsGenres = _context.GenresArtists.Where(g => g.ArtistId == a.Id).ToList();
                foreach (var ag in a.ArtistsGenres)
                {
                    ag.Genre = _context.Genres.Where(g => g.Id == ag.GenreId).FirstOrDefault();
                }
                a.ArtistsAlbums = _context.ArtistsAlbums.Where(alb => alb.ArtistId == a.Id).ToList();
            }

            return artists;

        }

        public IEnumerable<ArtistEntity> GetArtistsByGenre(string genre)
        {
            return _context.Artists.Where(a => a.ArtistsGenres
                                                .Any(g => g.Genre.Name == genre))
                                                .ToList();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 1;
        }

        //public ArtistEntity GetArtistById(9string genre)
        //{
        //    return _context.Artists.Where(a => a.ArtistsGenres
        //                                        .Any(g => g.Genre.Name == genre));
        //}
    }
}
