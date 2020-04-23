using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    public class ArtistEntity
    {
        public ArtistEntity ()
        {
            Images = new List<ArtistImageEntity>();
            ArtistsGenres = new List<GenreArtistJoinEntity>();
            ArtistsAlbums = new List<ArtistAlbumJoinEntity>();
            ArtistsTracks = new List<TrackArtistJoinEntity>();
        }
        //artists can have a one to many relationship with genres and images
        public ICollection<ArtistImageEntity> Images { get; set; }
        public ICollection<GenreArtistJoinEntity> ArtistsGenres { get; set; }
        public ICollection<ArtistAlbumJoinEntity> ArtistsAlbums { get; set; }
        public ICollection<TrackArtistJoinEntity> ArtistsTracks { get; set; }
        /// <summary>
        /// The Spotify ID for the artist.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
