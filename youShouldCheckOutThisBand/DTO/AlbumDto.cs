using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    public class AlbumDto
    {
        public AlbumDto()
        {
            Artists = new List<ArtistDto>();
            Images = new List<ImageDto>();
        }

        public string AlbumType { get; set; }
        public ICollection<ArtistDto> Artists{ get; set; }
        public string Href { get; set; }
        public ICollection<ImageDto> Images { get; set; }
        public string Name { get; set; }
        public string Release_Date { get; set; }
        public string Release_Date_Precision { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
