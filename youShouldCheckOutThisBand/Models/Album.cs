using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    public class Album
    {
        public Album()
        {
            Artists = new List<Artist>();
            Images = new List<Image>();
        }

        public string AlbumType { get; set; }
        public ICollection<Artist> Artists{ get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public ICollection<Image> Images { get; set; }
        public string Name { get; set; }
        public string Release_Date { get; set; }
        public string Release_Date_Precision { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
