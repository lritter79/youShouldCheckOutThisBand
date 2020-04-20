using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using youShouldCheckOutThisBand.ViewModel;

namespace youShouldCheckOutThisBand.Controllers
{
    public class AppController : Controller
    {
        
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
        public IActionResult AddRecommendation(AddRecommendationViewModel model)
        {
            //this is where we have to get the song by uri, get album and artits, and images
            //add them to the db and display that it's been added to the user
            return View();
        }
    }
}