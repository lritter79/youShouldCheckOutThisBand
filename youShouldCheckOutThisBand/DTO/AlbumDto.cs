﻿using System;
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
            TrackIds = new List<int>();
            TrackUris = new List<string>();
            ImageIds = new List<int>();
            ImageUrls = new List<string>();
        }

        public int Id { get; set; }
        public ICollection<int> ArtistIds { get; set; }
        public ICollection<string> ArtistUris{ get; set; }
        public ICollection<int> ImageIds { get; set; }
        public ICollection<string> ImageUrls { get; set; }
        public ICollection<int> TrackIds { get; set; }
        public ICollection<string> TrackUris { get; set; }

    }
}
