using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    
    public class GenreArtistJoinEntity
    {
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public virtual ArtistEntity Artist { get; set; }
        [ForeignKey("GenreId")]
        public virtual GenreEntity Genre { get; set; }
    }
}
