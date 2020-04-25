using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    public class AlbumDto:BaseAlbum
    {
        public AlbumDto()
        {
            ArtistIds = new List<int>();
            ArtistUris = new List<string>();
        }

        public ICollection<int> ArtistIds { get; set; }
        public ICollection<string> ArtistUris{ get; set; }
        public ICollection<int> ImageIds { get; set; }


    }
}
