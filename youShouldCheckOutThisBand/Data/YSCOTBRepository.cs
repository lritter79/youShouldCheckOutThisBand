using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using youShouldCheckOutThisBand.Contexts;
using youShouldCheckOutThisBand.Entities;

namespace youShouldCheckOutThisBand.Data
{
    /*
     * 
     */
    public class YSCOTBRepository : IYSCOTBRepository
    {
        private readonly YSCOTBContext _context;

        public YSCOTBRepository(YSCOTBContext ctx)
        {
            _context = ctx;
        }

        

        public void AddTrack(TrackEntity track)
        {
            _context.Tracks.Add(track);
        }

        public void AddAlbum(AlbumEntity album)
        {
            _context.Albums.Add(album);
        }

        public void AddArtist(ArtistEntity artist)
        {
            _context.Artists.Add(artist);
        }

        public void AddArtistImages(IEnumerable<ArtistImageEntity> artistImageEntities)
        {
            _context.ArtistImages.AddRange(artistImageEntities);
        }
        
        public void AddAlbumCovers(IEnumerable<AlbumCoverEntity> albumCoverEntities)
        {
            _context.AlbumCovers.AddRange(albumCoverEntities);
        }

        public void AddArtistAlbumJoinEntity(ArtistAlbumJoinEntity artistAlbumJoinEntity)
        {
            _context.ArtistsAlbums.Add(artistAlbumJoinEntity);
        }
        
        public void AddGenreAlbumJoinEntity(GenreAlbumJoinEntity genreAlbumJoinEntity)
        {
            _context.GenresAlbums.Add(genreAlbumJoinEntity);
        }

        public IEnumerable<ArtistEntity> GetAllArtistEntities()
        {

            return _context.Artists.Include(g => g.ArtistsGenres).ThenInclude(ag => ag.Genre).Include(g => g.Images).ToList();

        }

        public IEnumerable<TrackEntity> GetAllTracks()
        {
            return _context.Tracks
                .Include(t => t.Album).Include(ta => ta.TracksArtists).ThenInclude(a => a.Artist).ToList();
        }

        public ArtistEntity GetArtistById(int id)
        {
            return _context.Artists
                .Include(g => g.ArtistsGenres)
                .ThenInclude(ag => ag.Genre)
                .Include(g => g.Images)
                .Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<ArtistEntity> GetArtistsByGenre(int genreId)
        {
            var artists = (from a in _context.Artists
                           where a.ArtistsGenres.Any(a => a.GenreId == genreId)
                           select new ArtistEntity
                           {
                               Id = a.Id,
                               Name = a.Name,
                               Uri = a.Uri,
                               Images = a.Images,
                               ArtistsGenres = (from ag in _context.GenresArtists
                                                where ag.ArtistId == a.Id
                                                select new GenreArtistJoinEntity
                                                {
                                                    Genre = ag.Genre
                                                }).ToList()                                                   
                           });

            return artists;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 1;
        }

        //public ArtistEntity GetArtistById(9string genre)
        //{
        //    return _context.Artists.Where(a => a.ArtistsGenres
        //                                        .Any(g => g.Genre.Name == genre));
        //}
    }
}
