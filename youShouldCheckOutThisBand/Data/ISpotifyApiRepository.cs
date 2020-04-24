using youShouldCheckOutThisBand.Entities;

namespace youShouldCheckOutThisBand.Data
{
    public interface ISpotifyApiRepository
    {
        ArtistEntity GetTrackInfo(string trackId);
    }
}