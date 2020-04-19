using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    public class GenreAlbumJoinEntity
    {
        public int GenreId { get; set; }
        public string AlbumSpotifyId { get; set; }
        public AlbumEntity Album { get; set; }
        public GenreEntity Genre { get; set; }
    }
}
