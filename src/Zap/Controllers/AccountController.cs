using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Zap.Models;


namespace Zap.Controllers
{
    public class AccountController : Controller
    {
        [Route("Account/Login")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("Account/Login")]
        [HttpPost]
        public IActionResult Signup(SignUpUserModel userModel)
        {
            if (!ModelState.IsValid)
                return View();

            // TODO: Create account in database here.
            return Redirect("/Home/Index");
        }

        [Route("Account/SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }

        [Route("Account/SignIn")]
        [HttpPost]
        public IActionResult SignIn(SignInModel model)
        {
            if (!ModelState.IsValid)
                return View();
            
            // TODO: Check account credentials against database here.
            return Redirect("/Home/Index");
        }
    }
}

