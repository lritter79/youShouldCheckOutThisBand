using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace youShouldCheckOutThisBand.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            //this asks "has the user already logged in?"
            //safety valve to prevent someone from logging in multiple times
            if (User.Identity.IsAuthenticated)
            {
                //RedirectToAction = redirect to specific controller and actions
                return RedirectToAction("Index", "App");
            }
            return View();
        }
    }
}