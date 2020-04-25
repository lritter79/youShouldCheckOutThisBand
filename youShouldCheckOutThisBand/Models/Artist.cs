using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    public class Artist:BaseArtist
    {

        public Artist()
        {
            Images = new List<Image>();
            Genres = new List<Genre>();
            Albums = new List<Album>();
            Tracks = new List<Track>();
        }
        public ICollection<Image> Images;
        public ICollection<Genre> Genres;
        public ICollection<Track> Tracks;
        public ICollection<Album> Albums;
    }
}
