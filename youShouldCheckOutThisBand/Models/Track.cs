using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    public class Track:BaseTrack
    {
        public Album Album { get; set; }
        public IEnumerable<Artist> Artists {get;set;}     
        public string Url  {get;set;}

    }
}
