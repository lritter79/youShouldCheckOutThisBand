using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using youShouldCheckOutThisBand.Data;
using youShouldCheckOutThisBand.Entities;
using youShouldCheckOutThisBand.Models;

namespace youShouldCheckOutThisBand.Controllers
{
    //this api is all about getting data
    
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
        public ActionResult<IEnumerable<Track>> Tracks()
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
        public ActionResult<IEnumerable<Image>> ArtistImages()
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
        public ActionResult<TrackEntity> AddSongRecommendation(string id)
        {
            //try adding logic here to get data via spotify api
            try
            {
                var s = _spotify.GetTrackInfo(id);

                var track = _mapper.Map<Track, TrackDto>(s);

                var trackEntity = _mapper.Map<TrackDto, TrackEntity>(track);
                
                //c# does not let you return interface types without being wrapped in an okay
                _repo.AddTrack(trackEntity);

                bool isSaved = _repo.SaveAll();

                if (isSaved)
                {

                    return Created($"api/Tracks/{trackEntity.Uri}", trackEntity);
                }
                else
                {
                    return BadRequest("track was not added cussessfully");
                }

            }           
            catch (DbUpdateException ex)
            {
                return BadRequest("This song has already been recommended");
            }
            catch (Exception ex)
            {
                string error = $"failed to add track: {ex.InnerException.Message}, {ex.Message}";
                error = error.Replace(System.Environment.NewLine, " ");

                return BadRequest(error);
            }
        }


    }
}