using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using youShouldCheckOutThisBand.Data;
using youShouldCheckOutThisBand.Models;

namespace youShouldCheckOutThisBand.Controllers
{
    [Route("api/Tracks")]
    [ApiController]
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
        public ActionResult<IEnumerable<Track>> Get(bool includeArtists = true)
        {
            //try adding logic here to get data via spotify api
            try
            {

                return Ok(_repo.GetAllTracks(includeArtists));
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
