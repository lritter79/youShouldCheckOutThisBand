using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    public class Track
    {
        public Track()
        {
            Artists = new List<Artist>();
        }

        public Album Album { get; set; }
        public ICollection<Artist> Artists { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
