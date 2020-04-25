﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using youShouldCheckOutThisBand.Models;

namespace youShouldCheckOutThisBand.Entities
{
    public class AlbumCoverEntity:Image
    {
        /// <summary>
        /// this is autogenerated since images in spotify dont have spotify ids
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        

        public int AlbumId { get; set; }

        [ForeignKey("AlbumId")]
        public virtual AlbumEntity Album { get; set; }
    }
}
