using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using youShouldCheckOutThisBand.Entities;
using youShouldCheckOutThisBand.Models;

namespace youShouldCheckOutThisBand.Data
{
    public class SpotifyApiRepository : ISpotifyApiRepository
    {
        private readonly SpotifyToken _token;

        public SpotifyApiRepository(SpotifyToken spotifyToken)
        {
            _token = spotifyToken;
        }


        public ArtistEntity GetTrackInfo(string trackId)
        {

            var requestUrl = "https://api.spotify.com/v1/tracks/" + trackId + "?market=" + _token._MarketCode;

            string webResponse = string.Empty;

            try
            {
                // Get token for request
                HttpClient hc = new HttpClient();
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(requestUrl),
                    Method = HttpMethod.Get
                };
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Authorization = new AuthenticationHeaderValue("Authorization", "Bearer " + _token.AccessToken);
                // TODO: Had a task cancelled here, too many errors. Find a better way to process this maybe.
                // Same code is in GetTrackFeatures function.
                var task = hc.SendAsync(request)
                    .ContinueWith((taskwithmsg) =>
                    {
                        var response = taskwithmsg.Result;
                        var jsonTask = response.Content.ReadAsStringAsync();
                        webResponse = jsonTask.Result;
                    });
                task.Wait();


            }
            catch (WebException ex)
            {
                Console.WriteLine("Track Request Error: " + ex.Status);
            }
            catch (TaskCanceledException tex)
            {
                Console.WriteLine("Track Request Error: " + tex.Message);
            }

            var track = JsonConvert.DeserializeObject<ArtistEntity>(webResponse);

            return track;
        }
    }
}
