using youShouldCheckOutThisBand.Entities;
using youShouldCheckOutThisBand.Models;

namespace youShouldCheckOutThisBand.Data
{
    public interface ISpotifyApiRepository
    {
        Track GetTrackInfo(string trackId);
    }
}