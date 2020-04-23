using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    [Table("GenreAlbumJoinTable")]
    public class GenreAlbumJoinEntity
    {
        public int GenreId { get; set; }
        public int AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public virtual AlbumEntity Album { get; set; }
        [ForeignKey("GenreId")]
        public virtual GenreEntity Genre { get; set; }
    }
}
