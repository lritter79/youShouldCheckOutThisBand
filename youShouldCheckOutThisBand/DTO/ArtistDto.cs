using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    public class ArtistDto:BaseArtist
    {
        public ArtistDto()
        {

            Tracks = new List<TrackDto>();
            
            ImageIds = new List<int>();
            ImageUrls = new List<string>();
        }
        public ICollection<int> ImageIds { get; set; }
        public ICollection<string> ImageUrls { get; set; }
        public ICollection<TrackDto> Tracks { get; set; }
        public ICollection<string> TrackUris { get; set; }
        public int Id { get; set; }
    }
}
