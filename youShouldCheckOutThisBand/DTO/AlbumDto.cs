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
            ArtistIds = new List<int>();
            ArtistUris = new List<string>();
        }

        public string AlbumType { get; set; }
        public ICollection<int> ArtistIds { get; set; }
        public ICollection<string> ArtistUris{ get; set; }
        public string Href { get; set; }
        public ICollection<int> ImageIds { get; set; }
        public string Name { get; set; }
        public string Release_Date { get; set; }
        public string Release_Date_Precision { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
