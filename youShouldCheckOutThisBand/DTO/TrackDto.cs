using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    public class TrackDto:BaseTrack
    {
        public TrackDto()
        {
            ArtistIds = new List<int>();
            ArtistUris = new List<string>();
        }
        
        public int AlbumId { get; set; }
        public string AlbumUri { get; set; }
        public ICollection<int> ArtistIds { get; set; }
        public ICollection<string> ArtistUris { get; set; }

    }
}
