using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    public class GenreEntity
    {

        public GenreEntity ()
        {
            Albums = new List<AlbumEntity>();
            Artists = new List<ArtistEntity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ArtistEntity> Artists { get; set; }

        public ICollection<AlbumEntity> Albums { get; set; }
    }

}
