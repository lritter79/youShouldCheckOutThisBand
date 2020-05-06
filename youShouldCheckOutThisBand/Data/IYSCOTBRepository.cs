using System.Collections.Generic;
using youShouldCheckOutThisBand.Entities;

namespace youShouldCheckOutThisBand.Data
{
    public interface IYSCOTBRepository
    {
        void AddAlbum(AlbumEntity album);
        void AddArtist(ArtistEntity artist);
        void AddTrack(TrackEntity track);
        void AddRecommendation(RecommendationEntity recommendation);
        IEnumerable<ArtistEntity> GetAllArtistEntities();
        IEnumerable<TrackEntity> GetAllTracks(bool includeArtist = true);
        ArtistEntity GetArtistById(int id);
        IEnumerable<ArtistEntity> GetArtistsByGenre(int genreId);
        bool SaveAll();
        IEnumerable<TrackEntity> GetTracksByUser(string username, bool includeArtists);
        IEnumerable<AlbumCoverEntity> GetTopThreeAlbumCoverEntities();
        int AlterTrackVotes(bool vote, string trackUri);
    }
}