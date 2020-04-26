using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using youShouldCheckOutThisBand.Entities;
using youShouldCheckOutThisBand.ViewModel;

namespace youShouldCheckOutThisBand.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UserManager<AppUser> _userManager { get; }

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }


        public IActionResult Login()
        {
            //user is a controller property
            //this asks "has the user already logged in?"
            //safety valve to prevent someone from logging in multiple times
            if (User.Identity.IsAuthenticated)
            {
                //RedirectToAction = redirect to specific controller and actions
                return RedirectToAction("Index", "App");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "App");
        }

        [HttpPost]
        //make this an async task method because we're using an asynchronous function to return a value
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager
                    //this allows us to sign in with just user name and password
                    //since this is async it returns a task
                    .PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, loginViewModel.RememberMe,
                    //this means dont lock account if name and password dont match
                    false);
                if (result.Succeeded)
                {
                    if(Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        //adds a qstring that says where to go if login successful
                        Redirect(Request.Query["ReturnUrl"]
                            //first tells it to get the first value inside the query string
                            .First());
                    }
                    else
                    {
                        //send them to a static place
                        return RedirectToAction("AddRecommendation", "App");
                    }
                    
                }
            }

            ModelState.AddModelError("", "Failed to login");

            //redirect to same view unless we successfully log in
            return View();
        }

        [HttpPost]//this is a REST call is part of the account system
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);

                if(user != null)
                {
                    var result = await _signInManager
                    //checks the password without giving a result back
                    .CheckPasswordSignInAsync(user, model.Password, false);

                    if (result.Succeeded)
                    {
                        //claims are a set of properties with well known values in them
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames
                            //the name of the subject
                            .Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames
                            //the username matched to the indentity in the user object that's available to every view and controller
                            .UniqueName, user.UserName)
                        };

                        //key = the secret used to encrypt the token
                        var key = new SymmetricSecurityKey(Encoding.UTF8
                                                                    //gets a string from config and turns it to bytes
                                                                    .GetBytes(_configuration["Tokens:key"]));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            //set issuer
                            _configuration["Tokens:Issuer"],
                            _configuration["Tokens:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(70),
                            signingCredentials: credentials
                            );

                        //write new anon object
                        var results = new
                        {
                            token = new JwtSecurityTokenHandler()
                                        .WriteToken(token),
                            expiration = token.ValidTo
                        };

                    return Created("", results);
                    }
                }

                
            }

                return BadRequest();
            
            
        }
    }
}