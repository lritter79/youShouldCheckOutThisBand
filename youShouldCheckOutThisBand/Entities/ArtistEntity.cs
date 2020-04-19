using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    public class ArtistEntity
    {
        //artists can have a one to many relationship with genres and images

        /// <summary>
        /// The Spotify ID for the artist.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the artist
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Spotify URI for the artist.
        /// </summary>
        public string Uri { get; set; }
    }
}
