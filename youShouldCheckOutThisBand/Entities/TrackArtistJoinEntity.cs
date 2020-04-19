using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    public class TrackArtistJoinEntity
    {
        public string ArtistSpotifyId { get; set; }
        public string TrackSpotifyId { get; set; }
        public TrackEntity Track { get; set; }
        public ArtistEntity Artist {get;set;}
    }
}
