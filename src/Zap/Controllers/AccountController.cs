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
            return RedirectToPage("/Home/Index");
        }
    }
}

