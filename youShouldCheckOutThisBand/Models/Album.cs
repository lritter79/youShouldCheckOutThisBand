using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    [NotMapped]
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
        //using the jsonignore decorator because we dont need to get all tracks from spotify, plus the code will break up the tracks 
        //of an album getting deserialized
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public IEnumerable<Track> Tracks { get; set; }
    }
}
