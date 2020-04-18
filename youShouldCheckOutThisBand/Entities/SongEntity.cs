using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    public class SongEntity
    {
        /// <summary>
        /// The Spotify ID for the track.
        /// </summary>
        public string Id { get; set; }

        //fk for an albums table 
        public int AlbumId { get; set; }

        //don't include artist ad because a track can have a one to many relationship with artists, so that would require a jointable with song id and artist ids

        /// <summary>
        /// A link to the Web API endpoint providing full details of the track.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// A link to a 30 second preview (MP3 format) of the track. Can be null
        /// </summary>
        public string PreviewUrl { get; set; }

        /// <summary>
        /// The Spotify URI for the track.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// The name of the track.
        /// </summary>
        public string Name { get; set; }
    }
}
