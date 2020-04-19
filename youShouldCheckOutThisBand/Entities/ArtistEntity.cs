using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    public class ArtistEntity
    {
        public ArtistEntity ()
        {
            Images = new List<ArtistImageEntity>();
            Genres = new List<GenreEntity>();
            Albums = new List<AlbumEntity>();
            Tracks = new List<TrackEntity>();
        }
        //artists can have a one to many relationship with genres and images
        public ICollection<ArtistImageEntity> Images { get; set; }
        public ICollection<GenreEntity> Genres { get; set; }
        public ICollection<AlbumEntity> Albums { get; set; }
        public ICollection<TrackEntity> Tracks { get; set; }
        /// <summary>
        /// The Spotify ID for the artist.
        /// </summary>
        [Key]
        public string SpotifyId { get; set; }

        /// <summary>
        /// The name of the artist
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Spotify URI for the artist.
        /// </summary>
        public string Uri { get; set; }

        
    }
}
