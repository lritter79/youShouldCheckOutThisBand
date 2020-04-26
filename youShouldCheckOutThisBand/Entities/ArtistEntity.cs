using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using youShouldCheckOutThisBand.Models;

namespace youShouldCheckOutThisBand.Entities
{
    public class ArtistEntity:BaseArtist
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
        public virtual ICollection<GenreArtistJoinEntity> ArtistsGenres { get; set; }
        public virtual ICollection<ArtistAlbumJoinEntity> ArtistsAlbums { get; set; }
        public virtual ICollection<TrackArtistJoinEntity> ArtistsTracks { get; set; }
        /// <summary>
        /// The Spotify ID for the artist.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }





        
    }
}
