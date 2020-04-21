using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.ViewModel
{
    public class AddRecommendationViewModel
    {
        [Required]
        public string SpotifyUri { get; set; }
    }
}
