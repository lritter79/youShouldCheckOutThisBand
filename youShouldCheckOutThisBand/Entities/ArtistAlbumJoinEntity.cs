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
        public AlbumEntity Album { get; set; }
        public ArtistEntity Artist { get; set; }
    }
}
