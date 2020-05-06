using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using youShouldCheckOutThisBand.Contexts;
using youShouldCheckOutThisBand.Data;
using youShouldCheckOutThisBand.Entities;
using youShouldCheckOutThisBand.Models;
using youShouldCheckOutThisBand.ViewModel;

namespace youShouldCheckOutThisBand.Controllers
{
    //this controller is for returning views to the user
    //app controller will look for views in the "app" folder in the view folder
    public class AppController : Controller
    {
        private readonly IYSCOTBRepository _repository;
        private readonly ISpotifyApiRepository _spotify;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public AppController (IYSCOTBRepository repo, ISpotifyApiRepository spotify, IMapper mapper, UserManager<AppUser> userManager)
        {
            _repository = repo;
            _spotify = spotify;
            _mapper = mapper;
            _userManager = userManager;
        }

        //the action is where the logic happens, the controller maps to the action so it can return that view
        public IActionResult Index()
        {
            ViewBag.Title = "You Should Check Out This Band";
            IEnumerable<AlbumCoverEntity> albumCovers = _repository.GetTopThreeAlbumCoverEntities().ToList();
            return View(albumCovers);
        }

        //specify routing
        [HttpGet("AddRecommendation")]
        [Authorize]
        public IActionResult AddRecommendation()
        {
            return View();
        }
        
        //this is for when the user makes a suggestion post
        [HttpPost("AddRecommendation")]
        [Authorize]
        public async Task<IActionResult> AddRecommendationAsync(AddRecommendationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //this is where we have to get the song by uri, get album and artists, and images
                    //add them to the db and display that it's been added to the user
                    var spotifyTrack = _spotify.GetTrackInfo(model.SpotifyUri);
                    //get the more detailed verson of each artist and the album with the spotify api
                    spotifyTrack.Album = _spotify.GetAlbum(spotifyTrack.Album.Uri);
                    spotifyTrack.Artists = spotifyTrack.Artists
                                                       .Select(artist => _spotify.GetArtist(artist.Uri));
                    var trackEntity = _mapper.Map<Track, TrackEntity>(spotifyTrack);
                    trackEntity.TracksArtists = spotifyTrack.Artists
                                                        .Select(a => _mapper.Map<Tuple<Track, Artist>, TrackArtistJoinEntity>(new Tuple<Track, Artist>(spotifyTrack, a))).ToList();
                    foreach (TrackArtistJoinEntity trackArtistJoin in trackEntity.TracksArtists)
                    {
                        var artist = spotifyTrack.Artists.First(artist => artist.Id == trackArtistJoin.ArtistId);

                        if (artist != null)
                        {
                            trackArtistJoin.Artist.ArtistsGenres = artist.Genres
                                                                         .Select(g => _mapper.Map<Tuple<string, Artist>, GenreArtistJoinEntity>(new Tuple<string, Artist>(g, artist))).ToList();
                        }

                         
                    }
                    var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);

                    var recEntity = new RecommendationEntity()
                    {
                        UserId = currentUser.Id,
                        User = currentUser,
                        Track = trackEntity

                    };

                    _repository.AddRecommendation(recEntity);
                    //_repo.AddAlbum();
                    if (_repository.SaveAll())
                    {
                        ViewBag.UserMessage = "Added";
                    }
                    else
                    {
                        ViewBag.UserMessage = "Something went wrong or you've already recommended this song";
                    }
                    
                    

                }
                //else
                //{
                //    var errors = ModelState;
                //    //show errors
                //}
            }
            catch (Exception exception)
            {
                throw exception;
            }
            
            return View();
        }


        [HttpGet("Artists")]
        public IActionResult Artists()
        {
            //return the bands people suggested
            var results = _repository.GetAllArtistEntities()
                                     .Select(entity => _mapper.Map<ArtistEntity, Artist>(entity))
                                     .ToList();
            return View(results);
        }

        [Authorize]
        [HttpGet("Tracks")]
        public IActionResult Tracks()
        {
            //return the bands people suggested
            
            return View();
        }
    }
}