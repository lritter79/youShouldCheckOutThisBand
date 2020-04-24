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
    public class ApiController : ControllerBase
    {
        private readonly IYSCOTBRepository _repo;
        public ApiController(IYSCOTBRepository repo)
        {
            _repo = repo;
        }

        [Route("~/api/Artists")]
        [HttpGet]
        public IEnumerable<ArtistEntity> Artists()
        {
            return _repo.GetAllArtistEntities();
        }
    }
}