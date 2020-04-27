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
    public class GenreEntity
    {

        public GenreEntity ()
        {
            GenresAlbums = new List<GenreAlbumJoinEntity>();
            GenresArtists = new List<GenreArtistJoinEntity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [Ignore]
        public ICollection<GenreArtistJoinEntity> GenresArtists { get; set; }

        [Ignore]
        public ICollection<GenreAlbumJoinEntity> GenresAlbums { get; set; }
    }

}
