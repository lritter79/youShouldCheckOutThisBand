using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    public abstract class BaseTrack
    {
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

        /// <summary>
        /// The upvotes a track gets 
        /// </summary>
        public int UpVotes { get; set; }
        
        /// <summary>
        /// The upvotes a track gets 
        /// </summary>
        public int DownVotes { get; set; }

        public int Id { get; set; }
    }
}
