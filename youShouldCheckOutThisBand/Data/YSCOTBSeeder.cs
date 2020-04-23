using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using youShouldCheckOutThisBand.Contexts;
using youShouldCheckOutThisBand.Entities;

namespace youShouldCheckOutThisBand.Data
{
    public class YSCOTBSeeder
    {
        private readonly YSCOTBContext _context;
        private readonly IWebHostEnvironment _hosting;

        public YSCOTBSeeder(YSCOTBContext ctx, IWebHostEnvironment hosting)
        {
            _context = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Artists.Any())
            {
                //if artists is empty, create sample data

                var sampleArtist = new ArtistEntity()
                {
                    Name = "Dr. Dre",
                    Uri = "6DPYiyq5kWVQS4RGwxzPC7"
                };

                _context.Artists.Add(sampleArtist);
            }

            _context.SaveChanges();
        }
    }
}
