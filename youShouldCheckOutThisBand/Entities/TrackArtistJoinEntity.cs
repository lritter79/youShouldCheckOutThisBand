using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    public class TrackArtistJoinEntity
    {
        public int ArtistId { get; set; }
        public int TrackId { get; set; }
        [ForeignKey("TrackId")]
        public TrackEntity Track { get; set; }
        [ForeignKey("ArtistId")]
        public ArtistEntity Artist {get;set;}
    }
}
