using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using youShouldCheckOutThisBand.Models;

namespace youShouldCheckOutThisBand.Entities
{
    public class TrackEntity:BaseTrack
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
        public new int Id { get; set; }

        [Required]
        public new string Uri { get; set; }

        //track has a one to one relationship to album
        [ForeignKey("AlbumId")]
        public virtual Album Album { get; set; }

        public int AlbumId { get; set; }

        //tracks can have a one to many relationship with artists
        public ICollection<TrackArtistJoinEntity> TracksArtists { get; set; }    

    }
}
