using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using youShouldCheckOutThisBand.Entities;
using youShouldCheckOutThisBand.Models;

namespace youShouldCheckOutThisBand.Data.YSCOTBMappingProfile
{
    public class YSCOTBMappingProfile : Profile
    {
        public YSCOTBMappingProfile()
        {
            CreateMap<Track, TrackEntity>()
                .ForMember(te => te.Album, tm => tm.MapFrom(t => t.Album))
                .ReverseMap();
        }



        
    }
}
