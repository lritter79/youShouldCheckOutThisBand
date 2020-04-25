using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    public class TrackDto
    {
        public TrackDto()
        {
            ArtistIds = new List<int>();
            AlbumUris = new List<string>();
        }

        public int AlbumId { get; set; }
        public string AlbumUri { get; set; }
        public ICollection<int> ArtistIds { get; set; }
        public ICollection<string> ArtistUris { get; set; }
        public string Href { get; set; }
        public string PreviewUrl { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        public string Votes { get; set; }
    }
}
