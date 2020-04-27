using youShouldCheckOutThisBand.Entities;
using youShouldCheckOutThisBand.Models;

namespace youShouldCheckOutThisBand.Data
{
    public interface ISpotifyApiRepository
    {
        Track GetTrackInfo(string trackUri);
        Album GetAlbum(string albumUri);
        Artist GetArtist(string artistUri);
    }
}