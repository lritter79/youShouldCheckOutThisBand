using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using youShouldCheckOutThisBand.Data;
using youShouldCheckOutThisBand.Entities;

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
        public ApiController(IYSCOTBRepository repo)
        {
            _repo = repo;
        }

        [Route("~/api/Artists")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<ArtistEntity>> Artists()
        {
            try
            {
                //c# does not let you return interface types without being wrapped in an okay
                return Ok(_repo.GetAllArtistEntities());
                //okay converts whatever you return into a 200 code with the objects
                
            }
            catch (Exception ex)
            {
                return BadRequest("failed to get artists: " + ex.Message);
            }
            
        }
    }
}