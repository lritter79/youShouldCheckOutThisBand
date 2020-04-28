using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using youShouldCheckOutThisBand.Contexts;
using youShouldCheckOutThisBand.Entities;
using youShouldCheckOutThisBand.Extensions;

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

        public IEnumerable<TrackEntity> GetAllTracks(bool includeArtist = true)
        {
            if (includeArtist)
            {
                return _context.Tracks
                .Include(t => t.Album)
                .Include(ta => ta.TracksArtists)
                .ThenInclude(a => a.Artist).ToList();
            }
            else
            {
                return _context.Tracks
                    .Include(t => t.Album).ToList();
            }
            
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

        public IEnumerable<TrackEntity> GetTracksByUser(string username, bool includeArtists = true)
        {
            if (includeArtists)
            {

                var query = from TrackEntity in _context.Tracks
                            join RecommendationEntity in _context.Recommendations on TrackEntity.Id equals RecommendationEntity.Track.Id
                            join AppUser in _context.Users on RecommendationEntity.UserId equals AppUser.Id
                            where AppUser.UserName == username
                            select new TrackEntity();

                return query.ToList();
            }
            else
            {
                var tracks = from TrackEntity in _context.Tracks
                join RecommendationEntity in _context.Recommendations on TrackEntity.Id equals RecommendationEntity.Track.Id
                join AppUser in _context.Users on RecommendationEntity.UserId equals AppUser.Id             
                where AppUser.UserName == username
                select new TrackEntity();
                
                foreach (TrackEntity t in tracks)
                {
                    t.TracksArtists = (from TrackArtistJoinEntity in _context.ArtistsTracks
                                      where TrackArtistJoinEntity.TrackId == t.Id
                                      select new TrackArtistJoinEntity()).ToList();
                    foreach (TrackArtistJoinEntity ta in t.TracksArtists)
                    {
                        ta.Artist = (from ArtistEntity in _context.Artists
                                    where ArtistEntity.Id == ta.ArtistId
                                    select new ArtistEntity()).FirstOrDefault();
                    }
                }
                
                return tracks.ToList();
            }
        }

        public void AddRecommendation(RecommendationEntity recommendation)
        {
            try
            {
                if (_context.Tracks.Any(track => track.Uri == recommendation.Track.Uri))
                {
                    recommendation.Track = _context.Tracks.Select(track => track)
                                                          .Include(track => track.Album)
                                                          .Where(track => track.Uri == recommendation.Track.Uri)
                                                          .First();
                    recommendation.Track.UpVotes += 1;

                }

                //var album = recommendation.Track.Album;
                if (_context.Albums.Any(album => album.Uri == recommendation.Track.Album.Uri))
                {
                    recommendation.Track.Album = _context.Albums.Select(album => album)
                                                                .Where(album => album.Uri == recommendation.Track.Album.Uri).First();
                }


                foreach (TrackArtistJoinEntity artistJoinEntity in recommendation.Track.TracksArtists)
                {
                    if (_context.Artists.Any(artist => artist.Uri == artistJoinEntity.Artist.Uri))
                    {
                        artistJoinEntity.Artist = _context.Artists.Select(artist => artist)
                                                                  .Where(artist => artist.Uri == artistJoinEntity.Artist.Uri).First();
                        artistJoinEntity.ArtistId = artistJoinEntity.Artist.Id;
                    }

                    if (_context.Tracks.Any(track => track.Uri == artistJoinEntity.Track.Uri))
                    {
                        artistJoinEntity.Track = _context.Tracks.Select(track => track)
                                                                  .Where(track => track.Uri == artistJoinEntity.Track.Uri).First();
                        artistJoinEntity.Track.UpVotes += 1;
                        artistJoinEntity.TrackId = artistJoinEntity.Track.Id;
                    }
                }

                if (!_context.Recommendations.Any(rec => rec.User == recommendation.User && rec.Track == recommendation.Track))
                {
                    _context.Recommendations.Add(recommendation);
                }

                    //var trackArtists = recommendation.Track.TracksArtists;


                    //recommendation.Track.TracksArtists = null;

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //foreach (TrackArtistJoinEntity artist in recommendation.Track.TracksArtists)
            //{
            //    if (IsItNew(ar))
            //}
            


            //if (context.ObjectStateManager.GetObjectStateEntry(myEntity).State == EntityState.Detached)
            //{
            //    context.MyEntities.AddObject(myEntity);
            //}
        }


        public static bool IsItNew(YSCOTBContext context, ArtistEntity entity)
        {
            if (context.Artists.Find(entity.Uri) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
                                  
        //public ArtistEntity GetArtistById(9string genre)
        //{
        //    return _context.Artists.Where(a => a.ArtistsGenres
        //                                        .Any(g => g.Genre.Name == genre));
        //}
    }
}
