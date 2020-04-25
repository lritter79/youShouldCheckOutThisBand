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

            CreateMap<TrackEntity, TrackDto>()
                .ForMember(tdto => tdto.ArtistIds, opts => opts.MapFrom(te => te.TracksArtists
                                                                              .Select(ta => ta.Artist.Id)))
                .ForMember(tdto => tdto.ArtistUris, opts => opts.MapFrom(te => te.TracksArtists
                                                                              .Select(ta => ta.Artist.Uri)))
                .ForMember(tdto => tdto.AlbumId, opts => opts.MapFrom(te => te.Album.Uri))
                .ForMember(tdto => tdto.Uri, opts => opts.MapFrom(te => te.Uri))
                .ReverseMap();
            
            CreateMap<Track, TrackDto>()
                .ForMember(tdto => tdto.ArtistUris, opts => opts.MapFrom(te => te.Artists
                                                                              .Select(ta => ta.Uri)))
                
                .ForMember(tdto => tdto.Uri, opts => opts.MapFrom(te => te.Uri))
                .ForMember(tdto => tdto.AlbumUri, opts => opts.MapFrom(te => te.Album.Uri))
                .ForMember(tdto => tdto.AlbumId, opts => opts.Ignore())
                .ReverseMap();
            CreateMap<Album, AlbumDto>()
                .ForMember(Adto => Adto.ArtistUris, opts => opts.MapFrom(a => a.Artists
                                                                              .Select(ar => ar.Uri)))
                .ForMember(Adto => Adto.TrackUris, opts => opts.MapFrom(a => a.Tracks
                                                                              .Select(tr => tr.Uri)))
                .ForMember(Adto => Adto.ImageUrls, opts => opts.MapFrom(a => a.Images
                                                                              .Select(img => img.Url)))
                .ReverseMap();
            CreateMap<AlbumEntity, AlbumDto>()
                .ForMember(Adto => Adto.ArtistUris, opts => opts.MapFrom(a => a.AlbumsArtists
                                                                              .Select(ar => ar.Artist.Uri)))
                .ForMember(Adto => Adto.TrackUris, opts => opts.MapFrom(a => a.Tracks
                                                                              .Select(tr => tr.Uri)))
                .ForMember(Adto => Adto.ImageUrls, opts => opts.MapFrom(a => a.Images
                                                                              .Select(img => img.Url)))
                .ReverseMap();

        }




    }
}
