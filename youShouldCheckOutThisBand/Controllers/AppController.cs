using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using youShouldCheckOutThisBand.Contexts;
using youShouldCheckOutThisBand.Data;
using youShouldCheckOutThisBand.Entities;
using youShouldCheckOutThisBand.ViewModel;

namespace youShouldCheckOutThisBand.Controllers
{
    //app controller will look for views in the "app" folder in the view folder
    public class AppController : Controller
    {
        private readonly IYSCOTBRepository _reposity;
        private readonly ISpotifyApiRepository _spotify;
        private readonly IMapper _mapper;

        public AppController (IYSCOTBRepository repo, ISpotifyApiRepository spotify, IMapper mapper)
        {
            _reposity = repo;
            _spotify = spotify;
            _mapper = mapper;
        }

        //the action is where the logic happens, the controller maps to the action so it can return that view
        public IActionResult Index()
        {
            ViewBag.Title = "You Should Check Out This Band";
            return View();
        }

        //specify routing
        [HttpGet("AddRecommendation")]
        public IActionResult AddRecommendation()
        {
            return View();
        }
        
        //this is for when the user makes a suggestion post
        [HttpPost("AddRecommendation")]
        public IActionResult AddRecommendation([FromBody]AddRecommendationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //this is where we have to get the song by uri, get album and artits, and images
                    //add them to the db and display that it's been added to the user
                    var trackToAdd = _spotify.GetTrackInfo(Helpers.GetIdFromUri(model.SpotifyUri));

                }
                else
                {
                    var errors = ModelState;
                    //show errors
                }
            }
            catch
            {
                
            }
            
            return View();
        }

        [HttpGet("Bands")]
        public IActionResult Bands()
        {
            //return the bands people suggested
            var results = _reposity.GetAllArtistEntities();
            return View(results.ToList());
        }
    }
}