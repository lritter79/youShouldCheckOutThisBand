using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using youShouldCheckOutThisBand.Contexts;
using youShouldCheckOutThisBand.Entities;

namespace youShouldCheckOutThisBand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly YSCOTBContext _context;

        private UserManager<AppUser> _userManager { get; }

        public RecommendationController(YSCOTBContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecommendationEntity(int id, RecommendationEntity recommendationEntity)
        {
            if (id != recommendationEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(recommendationEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecommendationEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Recommendation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RecommendationEntity>> PostRecommendationEntity(RecommendationEntity recommendationEntity)
        {
            _context.Recommendations.Add(recommendationEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecommendationEntity", new { id = recommendationEntity.Id }, recommendationEntity);
        }

        // DELETE: api/Recommendation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RecommendationEntity>> DeleteRecommendationEntity(int id)
        {
            var recommendationEntity = await _context.Recommendations.FindAsync(id);
            if (recommendationEntity == null)
            {
                return NotFound();
            }

            _context.Recommendations.Remove(recommendationEntity);
            await _context.SaveChangesAsync();

            return recommendationEntity;
        }

        private bool RecommendationEntityExists(int id)
        {
            return _context.Recommendations.Any(e => e.Id == id);
        }
    }
}
