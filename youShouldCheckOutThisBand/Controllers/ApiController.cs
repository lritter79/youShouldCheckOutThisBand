using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly ISpotifyApiRepository _spotify;
        private readonly IMapper _mapper;

        public ApiController(IYSCOTBRepository repo, ISpotifyApiRepository spotifyApi, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            _spotify = spotifyApi;
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

        [Route("~/api/Tracks")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<TrackEntity>> Tracks()
        {
            //try adding logic here to get data via spotify api
            try
            {

                return Ok(_repo.GetAllTracks());
            }
            catch (Exception ex)
            {
                return BadRequest("failed to get track " + ex.Message);
            }
        }

        [Route("~/api/ArtistImages")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<ArtistImageEntity>> ArtistImages()
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

        [Route("~/api/AddSongRecommendation/{id}")]
        [HttpPost("{id:alpha}")]
        public IActionResult AddSongRecommendation(string id)
        {
            //try adding logic here to get data via spotify api
            try
            {
                var s = _spotify.GetTrackInfo(id);

                var track = _mapper.Map<TrackDto, TrackEntity>(s);
                
                //c# does not let you return interface types without being wrapped in an okay
                _repo.AddTrack(track);
                if (_repo.SaveAll())
                {
                    return Created($"api/Tracks/{track.Uri}", track);
                }
                else
                {
                    return BadRequest("track was not added cussessfully");
                }

            }
            catch (Exception ex)
            {
                return BadRequest("failed to add track:  " + ex.Message);
            }
        }


    }
}