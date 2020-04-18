using youShouldCheckOutThisBand.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace youShouldCheckOutThisBand.Contexts
{
    public class SongDb : DbContext
    {
        public DbSet<SongEntity> Songs { get; set; }
    }
}
