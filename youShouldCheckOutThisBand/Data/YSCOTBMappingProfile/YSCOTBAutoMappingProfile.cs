using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using youShouldCheckOutThisBand.Entities;
using youShouldCheckOutThisBand.Models;

namespace youShouldCheckOutThisBand.Data.YSCOTBMappingProfile
{
    public class YSCOTBAutoMappingProfile : Profile
    {
        public YSCOTBAutoMappingProfile()
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
                .ForMember(tdto => tdto.AlbumUri, opts => opts.MapFrom(te => te.Album.Uri))
                .ForMember(tdto => tdto.AlbumId, opts => opts.MapFrom(te => te.Album.Id))
                .ReverseMap();
            
            CreateMap<Track, TrackDto>()
                .ForMember(tdto => tdto.ArtistUris, opts => opts.MapFrom(te => te.Artists
                                                                              .Select(ta => ta.Uri)))               
                .ForMember(tdto => tdto.Uri, opts => opts.MapFrom(te => te.Uri))
                .ForMember(tdto => tdto.AlbumUri, opts => opts.MapFrom(te => te.Album.Uri))
                .ForMember(tdto => tdto.AlbumId, opts => opts.Ignore())
                .ReverseMap();

            CreateMap<Artist, ArtistDto>()
                .ReverseMap();
            
            CreateMap<ArtistEntity, ArtistDto>()
                .ForMember(ArtistDto => ArtistDto.ImageIds, opts => opts.MapFrom(Artist => Artist.Images
                                                                              .Select(img => img.Id)))
                .ReverseMap();

            CreateMap<Album, AlbumDto>()
                .ForPath(Adto => Adto.Images, opts => opts.MapFrom(a => a.Images))
                .ReverseMap();

            CreateMap<AlbumEntity, AlbumDto>()
                .ForPath(Adto => Adto.Artists, opts => opts.MapFrom(a => a.AlbumsArtists
                                                                              .Select(ar => ar.Artist)))
                .ForPath(Adto => Adto.Tracks, opts => opts.MapFrom(a => a.Tracks
                                                                              .Select(tr => tr)))
                .ForPath(Adto => Adto.Images, opts => opts.MapFrom(a => a.Images))
                .ReverseMap();

            CreateMap<AlbumDto, ArtistAlbumJoinEntity>()
                .ForPath(artistAlbumJoinEntity => artistAlbumJoinEntity.Album, opts => opts.MapFrom(a => a))
                .ReverseMap();
            
            CreateMap<ArtistDto, ArtistAlbumJoinEntity>()
                .ForPath(artistAlbumJoinEntity => 
                artistAlbumJoinEntity.Artist, opts => opts.MapFrom(a => a))                                          
                .ReverseMap();

        }




    }
}
