using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using youShouldCheckOutThisBand.Data;
using youShouldCheckOutThisBand.Entities;
using youShouldCheckOutThisBand.Models;

namespace youShouldCheckOutThisBand.Controllers
{
    [Route("api/Tracks")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TracksController : ControllerBase
    {
        private readonly IYSCOTBRepository _repo;
        private readonly ISpotifyApiRepository _spotify;
        private readonly IMapper _mapper;

        public TracksController(IYSCOTBRepository repo, ISpotifyApiRepository spotifyApi, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            _spotify = spotifyApi;
        }

        [Route("~/api/Tracks")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Track>> Get(bool includeArtists = true, bool getTracksByUser = false)
        {
            //try adding logic here to get data via spotify api
            try
            {
                
                if (getTracksByUser)
                {
                    var username = User.Identity.Name;
                    return Ok(_repo.GetTracksByUser(username, includeArtists)
                        .Select(track => _mapper.Map<TrackEntity, Track>(track))
                        .ToList());
                }

                var trackList = _repo.GetAllTracks(includeArtists)
                                .Select(track => _mapper.Map<TrackEntity, Track>(track))
                                .ToList();

                return Ok(trackList);
            }
            catch (Exception ex)
            {
                return BadRequest("failed to get track " + ex.Message);
            }
        }

        // POST: api/Tracks
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Tracks/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
