using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using youShouldCheckOutThisBand.Models;

namespace youShouldCheckOutThisBand.Entities
{
    public class GenreEntity:Genre
    {

        public GenreEntity ()
        {
            GenresAlbums = new List<GenreAlbumJoinEntity>();
            GenresArtists = new List<GenreArtistJoinEntity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }

        public ICollection<GenreArtistJoinEntity> GenresArtists { get; set; }

        public ICollection<GenreAlbumJoinEntity> GenresAlbums { get; set; }
    }

}
