using youShouldCheckOutThisBand.Entities;
using youShouldCheckOutThisBand.Models;

namespace youShouldCheckOutThisBand.Data
{
    public interface ISpotifyApiRepository
    {
        TrackDto GetTrackInfo(string trackId);
    }
}