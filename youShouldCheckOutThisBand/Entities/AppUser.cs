using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.Entities
{
    public class AppUser: IdentityUser
    {
        public AppUser()
        {
            Recommendations = new List<RecommendationEntity>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<RecommendationEntity> Recommendations{ get; set; }
}
}
