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
        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public IActionResult Signup(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                // write your code

                ModelState.Clear();
            }
            return View();
        }
    }
}

