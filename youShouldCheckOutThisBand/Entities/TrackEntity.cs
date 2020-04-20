using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    public class TrackEntity
    {
        
        public TrackEntity()
        {
            TracksArtists = new List<TrackArtistJoinEntity>();
        }
        /// <summary>
        /// The Spotify ID for the track.
        /// </summary>
        [Key]
        public string SpotifyId { get; set; }

        //track has a one to one relationship to album
        public AlbumEntity Album { get; set; }

        //tracks can have a one to many relationship with artists
        public ICollection<TrackArtistJoinEntity> TracksArtists { get; set; }

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
        /// The down/upvotes a track gets 
        /// </summary>
        public int Votes { get; set; }
    }
}
