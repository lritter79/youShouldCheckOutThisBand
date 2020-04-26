using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    public class RecommendationEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]    
        public int TrackId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("TrackId")]
        public virtual TrackEntity Track { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
    }
}
