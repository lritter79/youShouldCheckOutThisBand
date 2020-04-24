using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using youShouldCheckOutThisBand.Data;
using youShouldCheckOutThisBand.Entities;
using youShouldCheckOutThisBand.Models;

namespace youShouldCheckOutThisBand.Controllers
{
    //attributed route
    
    [Route("api/[controller]")]
    [ApiController]
    //says that we're returning application.json with this controller
    [Produces("application/json")]
    public class ApiController : ControllerBase
    {
        private readonly IYSCOTBRepository _repo;
        private readonly SpotifyToken _token;

        public ApiController(IYSCOTBRepository repo, SpotifyToken token)
        {
            _repo = repo;
            _token = token;
        }

        [Route("~/api/Artists/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpGet("{id:int}")]
        public IActionResult Artists(int id)
        {
            try
            {
                //c# does not let you return interface types without being wrapped in an okay

                var artist = _repo.GetArtistById(id);

                if (artist != null)
                {
                    return Ok(artist);
                }
                else
                {
                    return BadRequest("artist not found");
                }

                
                
                //okay converts whatever you return into a 200 code with the objects

            }
            catch (Exception ex)
            {
                return BadRequest("failed to get artists: " + ex.Message);
            }
        }

        [Route("~/api/Artists")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<ArtistEntity>> Artists()
        {
            try
            {
                //var t = _token.GetAccessToken();
                //c# does not let you return interface types without being wrapped in an okay
                return Ok(_repo.GetAllArtistEntities());
                //okay converts whatever you return into a 200 code with the objects
                
            }
            catch (Exception ex)
            {
                return BadRequest("failed to get artists: " + ex.Message);
            }
            
        }

        [Route("~/api/AddSongRecommendation")]
        [HttpPost]
        public IActionResult AddSongRecommendation([FromBody] TrackEntity track)
        {
            //try adding logic here to get data via spotify api
            try
            {
                
                //c# does not let you return interface types without being wrapped in an okay
                _repo.AddTrack(track);
                _repo.SaveAll();
                return Created($"api/Tracks/{track.Uri}", track);
                //okay converts whatever you return into a 200 code with the objects

            }
            catch (Exception ex)
            {
                return BadRequest("failed to get artists: " + ex.Message);
            }
        }


    }
}