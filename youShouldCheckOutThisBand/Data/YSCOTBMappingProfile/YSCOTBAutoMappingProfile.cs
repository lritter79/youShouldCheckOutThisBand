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
            CreateMap<AlbumCoverEntity, Image>()
                .ReverseMap();

            CreateMap<Image, ArtistImageEntity>()
                .ReverseMap();

            CreateMap<Track, TrackEntity>()           
                .ForMember(entity => entity.Album, opts => opts.MapFrom(model => model.Album))
                .ForMember(entity => entity.TracksArtists, opts => opts.MapFrom(model => model.Artists))
                .ReverseMap();

            CreateMap<Artist, TrackArtistJoinEntity>()
                .ForMember(entity => entity.Artist, opts => opts.MapFrom(model => model))              
                .ReverseMap();


            //CreateMap<string, GenreEntity>()
            //    .ForMember(entity => entity.Name, opts => opts.MapFrom(model => model))
            //    .ReverseMap();

            //CreateMap<string, string>()
            //    .ForMember(entity => entity, opts => opts.MapFrom(model => model))
            //    .ReverseMap();

            CreateMap<Artist, ArtistEntity>()
                .ForMember(entity => entity.ArtistsAlbums, opts => opts.MapFrom(model => model.Albums
                                                                              .Select(album => album)))
                .ForMember(entity => entity.ArtistsTracks, opts => opts.MapFrom(model => model.Tracks
                                                                                        .Select(track => track)))
                .ForMember(entity => entity.Images, opts => opts.MapFrom(model => model.Images
                                                                                       .Select(image => image)))

                .ReverseMap();

            CreateMap<Album, AlbumEntity>()
                .ForMember(entity => entity.Images, opts => opts.MapFrom(model => model.Images
                                                                                       .Select(image => image)))
                .ReverseMap();
            //joiners
            CreateMap<Tuple<Artist, Album>, ArtistAlbumJoinEntity>()
                .ForMember(entity => entity.Artist, opts => opts.MapFrom(model => model.Item1))
                .ForMember(entity => entity.ArtistId, opts => opts.MapFrom(model => model.Item1.Id))
                .ForMember(entity => entity.Album, opts => opts.MapFrom(model => model.Item2))
                .ForMember(entity => entity.AlbumId, opts => opts.MapFrom(model => model.Item2.Id))
                .ReverseMap();

            CreateMap<Tuple<Track, Artist>, TrackArtistJoinEntity>()
                .ForMember(entity => entity.Track, opts => opts.MapFrom(model => model.Item1))
                .ForMember(entity => entity.TrackId, opts => opts.MapFrom(model => model.Item1.Id))
                .ForMember(entity => entity.Artist, opts => opts.MapFrom(model => model.Item2))
                .ForMember(entity => entity.ArtistId, opts => opts.MapFrom(model => model.Item2.Id))
                .ReverseMap();

            


        }
    }
}
