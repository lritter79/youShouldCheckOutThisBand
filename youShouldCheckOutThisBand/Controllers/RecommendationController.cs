using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using youShouldCheckOutThisBand.Contexts;
using youShouldCheckOutThisBand.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;

namespace youShouldCheckOutThisBand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RecommendationController : ControllerBase
    {
        private readonly YSCOTBContext _context;
        private readonly IMapper _mapper;
        private UserManager<AppUser> _userManager { get; }

        public RecommendationController(YSCOTBContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        // GET: api/Recommendation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecommendationEntity>>> GetRecommendations()
        {
            return await _context.Recommendations.ToListAsync();
        }

        // GET: api/Recommendation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecommendationEntity>> GetRecommendationEntity(int id)
        {
            var recommendationEntity = await _context.Recommendations.FindAsync(id);

            if (recommendationEntity == null)
            {
                return NotFound();
            }

            return recommendationEntity;
        }

        // PUT: api/Recommendation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRecommendationEntity(int id, RecommendationEntity recommendationEntity)
        //{
        //    if (id != recommendationEntity.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(recommendationEntity).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RecommendationEntityExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Recommendation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        //[HttpPost]
        //public async Task<IActionResult> Post(RecommendationEntity recommendationEntity)
        //{

        //    //try adding logic here to get data via spotify api
        //    try
        //    {
        //        string id = Helpers.GetIdFromUri(uri);
        //        var spotifyTrack = _spotify.GetTrackInfo(id);


        //        var trackEntity = _mapper.Map<Track, TrackEntity>(spotifyTrack);
        //        //var albumEntity = _mapper.Map<Album, A>
        //        //c# does not let you return interface types without being wrapped in an okay
        //        trackEntity.TracksArtists = spotifyTrack.Artists
        //                                                .Select(a => _mapper.Map<Tuple<Track, Artist>, TrackArtistJoinEntity>(new Tuple<Track, Artist>(spotifyTrack, a))).ToList();

        //        //.SelectMany(tuple => _mapper.Map<Tuple<Track, Artist>, TrackArtistJoinEntity>(tuple));

        //        _repo.AddTrack(trackEntity);
        //        //_repo.AddAlbum();
        //        bool isSaved = _repo.SaveAll();

        //        if (isSaved)
        //        {


        //            return Created($"api/Tracks/{trackEntity.Uri}", trackEntity);
        //        }
        //        else
        //        {
        //            return BadRequest("track was not added cussessfully");
        //        }

        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        return BadRequest("This song has already been recommended");
        //    }
        //    catch (Exception ex)
        //    {
        //        string error = $"failed to add track: {ex.InnerException.Message}, {ex.Message}";
        //        error = error.Replace(System.Environment.NewLine, " ");

        //        return BadRequest(error);
        //    }
        //}

        // DELETE: api/Recommendation/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<RecommendationEntity>> DeleteRecommendationEntity(int id)
        //{
        //    var recommendationEntity = await _context.Recommendations.FindAsync(id);
        //    if (recommendationEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Recommendations.Remove(recommendationEntity);
        //    await _context.SaveChangesAsync();

        //    return recommendationEntity;
        //}

        //private bool RecommendationEntityExists(int id)
        //{
        //    return _context.Recommendations.Any(e => e.Id == id);
        //}
    }
}
