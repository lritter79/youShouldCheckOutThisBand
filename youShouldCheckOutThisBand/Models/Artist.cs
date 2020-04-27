using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    [NotMapped]
    public class Artist:BaseArtist
    {

        public Artist()
        {
            Images = new List<Image>();
            Genres = new List<string>();
            Albums = new List<Album>();
            Tracks = new List<Track>();
        }
        public ICollection<Image> Images;
        [Ignore]
        public ICollection<string> Genres;
        public ICollection<Track> Tracks;
        public ICollection<Album> Albums;
    }
}
