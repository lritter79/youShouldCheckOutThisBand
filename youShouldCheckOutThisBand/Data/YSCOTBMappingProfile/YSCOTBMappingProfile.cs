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
            CreateMap<AlbumCoverEntity, ImageDto>()
                .ReverseMap();
            CreateMap<ImageDto, ArtistImageEntity>()
                .ReverseMap();
            
            //CreateMap<TrackEntity, TrackDto>()
            //    .ForMember(tdto => tdto.Artists, opts => opts.MapFrom(te => te.TracksArtists
            //                                                                  .Select(ta => ta.Artist)))
            //    .ForMember(tdto => tdto.Album, opts => opts.MapFrom(te => te.Album));
        }



        
    }
}
