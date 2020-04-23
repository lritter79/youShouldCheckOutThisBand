using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    public class ArtistAlbumJoinEntity
    {
        
        public int ArtistId { get; set; }        
        public int AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public virtual AlbumEntity Album { get; set; }
        [ForeignKey("ArtistId")]
        public virtual ArtistEntity Artist { get; set; }
    }
}
