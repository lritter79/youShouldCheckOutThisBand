using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using youShouldCheckOutThisBand.Contexts;
using youShouldCheckOutThisBand.Entities;

namespace youShouldCheckOutThisBand.Data
{
    public class YSCOTBRepository : IYSCOTBRepository
    {
        private readonly YSCOTBContext _context;

        public YSCOTBRepository(YSCOTBContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<ArtistEntity> GetAllArtistEntities()
        {
            return _context.Artists.ToList();
        }

        public IEnumerable<ArtistEntity> GetArtistsByGenre(string genre)
        {
            return _context.Artists.Where(a => a.ArtistsGenres
                                                .Any(g => g.Genre.Name == genre));
        }

        //public ArtistEntity GetArtistById(string genre)
        //{
        //    return _context.Artists.Where(a => a.ArtistsGenres
        //                                        .Any(g => g.Genre.Name == genre));
        //}
    }
}
