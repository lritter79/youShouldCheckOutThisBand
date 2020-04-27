using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Models
{
    [NotMapped]
    public class Track:BaseTrack
    {
        public Album Album { get; set; }
        [Ignore]
        public IEnumerable<Artist> Artists {get;set;}     
        public int SumOfVotes
        {
            get
            {
                return UpVotes - DownVotes;
            }
        }

    }
}
