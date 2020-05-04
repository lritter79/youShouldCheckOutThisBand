using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using youShouldCheckOutThisBand.Models;

namespace youShouldCheckOutThisBand.Entities
{
    public class AlbumEntity:BaseAlbum
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

        
        [Ignore]
        public virtual ICollection<ArtistAlbumJoinEntity> AlbumsArtists { get; set; }
        [Ignore]
        public virtual ICollection<GenreAlbumJoinEntity> AlbumsGenres { get; set; }
        public ICollection<TrackEntity> Tracks { get; set; }
        public virtual ICollection<AlbumCoverEntity> Images { get; set; }

        /// <summary>
        /// The Spotify ID for the album.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("ReleaseDatePrecision")]
        public new string Release_Date_Precision { get; set; }
        [Column("ReleaseDate")]
        public new string Release_Date { get; set; }

    }
}
