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
            Artists = new List<ArtistDto>();
        }

        public AlbumDto Album { get; set; }
        public ICollection<ArtistDto> Artists { get; set; }
        public string Href { get; set; }
        public string PreviewUrl { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        public string Votes { get; set; }
    }
}
