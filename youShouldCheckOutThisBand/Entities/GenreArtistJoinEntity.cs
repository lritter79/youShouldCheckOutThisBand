using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    public class GenreArtistJoinEntity
    {
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public ArtistEntity Artist{ get; set; }
        public GenreEntity Genre { get; set; }
    }
}
