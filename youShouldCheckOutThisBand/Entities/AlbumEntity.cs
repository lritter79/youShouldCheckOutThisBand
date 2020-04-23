using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    public class AlbumEntity
    {

        public AlbumEntity ()
        {
            Images = new List<AlbumCoverEntity>();
            AlbumsArtists = new List<ArtistAlbumJoinEntity>();
            AlbumsGenres = new List<GenreAlbumJoinEntity>();
            Tracks = new List<TrackEntity>();
        }

        //genres, tracks, and artists are to be stored as ids in join tables
        //since albums have a one to many relationship with
        //artists, tracks, and genres

        //albums also have multiple images that they are attached to because the cover can come in different sizes

        public ICollection<AlbumCoverEntity> Images { get; set; }
        public ICollection<ArtistAlbumJoinEntity> AlbumsArtists { get; set; }
        public ICollection<GenreAlbumJoinEntity> AlbumsGenres { get; set; }
        public ICollection<TrackEntity> Tracks { get; set; } 


        /// <summary>
        /// The Spotify ID for the album.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// The type of the album: one of "album" , "single" , or "compilation".
        /// </summary>
        public string AlbumType { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the album.
        /// </summary>
        public string Href { get; set; }
       
        /// <summary>
        /// The label for the album.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The name of the album. In case of an album takedown, the value may be an empty string.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The date the album was first released, for example "1981-12-15". Depending on the precision, it might be shown as "1981" or "1981-12".
        /// </summary>
        public string ReleaseDate { get; set; }

        /// <summary>
        /// The precision with which release_date value is known: "year" , "month" , or "day".
        /// </summary>
        public string ReleaseDatePrecision { get; set; }

        /// <summary>
        /// The Spotify URI for the album.
        /// </summary>
        public string Uri { get; set; }
    }
}
