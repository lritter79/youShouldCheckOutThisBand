using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    public class Album : BaseAlbum
    {
        public Album ()
        {
            Artists = new List<Artist>();
            Images = new List<Image>();
            Tracks = new List<Track>();
        }

        public IEnumerable<Artist> Artists { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
    }
}
