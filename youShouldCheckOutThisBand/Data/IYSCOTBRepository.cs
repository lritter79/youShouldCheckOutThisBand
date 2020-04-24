using System.Collections.Generic;
using youShouldCheckOutThisBand.Entities;

namespace youShouldCheckOutThisBand.Data
{
    //the interface can be good for testing
    public interface IYSCOTBRepository
    {
        IEnumerable<ArtistEntity> GetAllArtistEntities();
        IEnumerable<ArtistEntity> GetArtistsByGenre(int genreId);
        bool SaveAll();
        ArtistEntity GetArtistById(int id);
        void AddTrack(TrackEntity track);
    }
}