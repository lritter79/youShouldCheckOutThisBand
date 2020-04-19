using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    public class ArtistEntity
    {
        //artists can have a one to many relationship with genres and images

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

        public ICollection<ImageEntity> Images { get; set; } = new List<ImageEntity>();
        public ICollection<AlbumEntity> Artists { get; set; } = new List<AlbumEntity>();
        public ICollection<GenreEntity> Genres { get; set; } = new List<GenreEntity>();
    }
}
