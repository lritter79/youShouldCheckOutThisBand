using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    public abstract class BaseArtist
    {
        public string Type { get; set; }
        public string Href { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
    }
}
