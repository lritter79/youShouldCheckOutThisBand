using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //track has a one to one relationship to album
        public AlbumEntity Album { get; set; }

        //tracks can have a one to many relationship with artists
        public ICollection<TrackArtistJoinEntity> TracksArtists { get; set; }

        

    }
}
