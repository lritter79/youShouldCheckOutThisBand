using System.Collections.Generic;
using youShouldCheckOutThisBand.Entities;

namespace youShouldCheckOutThisBand.Data
{
    public interface IYSCOTBRepository
    {
        IEnumerable<ArtistEntity> GetAllArtistEntities();
        IEnumerable<ArtistEntity> GetArtistsByGenre(string genre);
    }
}