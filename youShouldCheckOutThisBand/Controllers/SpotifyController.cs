using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using youShouldCheckOutThisBand.Data;
using youShouldCheckOutThisBand.Entities;
using youShouldCheckOutThisBand.Extensions;
using youShouldCheckOutThisBand.Models;

namespace youShouldCheckOutThisBand.Controllers
{
    //this api is all about getting data back from the spotify api
    
    [Route("api/[controller]")]
    //says that we're returning application.json with this controller
    [Produces("application/json")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SpotifyController : ControllerBase
    {
        private readonly IYSCOTBRepository _repo;
        private readonly ISpotifyApiRepository _spotify;
        private readonly IMapper _mapper;

        public SpotifyController(IYSCOTBRepository repo, ISpotifyApiRepository spotifyApi, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            _spotify = spotifyApi;
        }

        
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Route("api/[controller]/[action]/{uri}")]
        [HttpGet("{uri}")]
        public IActionResult GetTrack(string uri)
        {
            try
            {
                //c# does not let you return interface types without being wrapped in an okay

                var track = _spotify.GetTrackInfo(uri);

                if (track != null)
                {
                    return Ok(track);
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

        [Route("~/api/AddSongRecommendation/{uri}")]
        [HttpPost("{uri:alpha}")]
        public ActionResult<TrackEntity> AddSongRecommendation(string uri)
        {

            //try adding logic here to get data via spotify api
            try
            {
                string id = Helpers.GetIdFromUri(uri);
                var spotifyTrack = _spotify.GetTrackInfo(id);


                var trackEntity = _mapper.Map<Track, TrackEntity>(spotifyTrack);
                //var albumEntity = _mapper.Map<Album, A>
                //c# does not let you return interface types without being wrapped in an okay
                trackEntity.TracksArtists = spotifyTrack.Artists
                                                        .Select(a => _mapper.Map<Tuple<Track, Artist>, TrackArtistJoinEntity>(new Tuple<Track, Artist>(spotifyTrack, a))).ToList();
                
                //.SelectMany(tuple => _mapper.Map<Tuple<Track, Artist>, TrackArtistJoinEntity>(tuple));

                _repo.AddTrack(trackEntity);
                //_repo.AddAlbum();
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
            catch (DbUpdateException)
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