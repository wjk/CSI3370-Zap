using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Zap.Models;


namespace Zap.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseConnection _databaseConnection;

        public AccountController(DatabaseConnection databaseConnection)
        {
            this._databaseConnection = databaseConnection;
        }

        [Route("Account/SignUp")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("Account/SignUp")]
        public IActionResult Signup(SignUpUserModel.ActionState state)
        {
            if (state == SignUpUserModel.ActionState.OK)
                return RedirectToAction("Signup");

            SignUpUserModel model = new SignUpUserModel() { State = state };
            return View(model);
        }

        [Route("Account/SignUp")]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Signup(SignUpUserModel userModel)
        {
            if (!ModelState.IsValid)
                return View();

            Account? account = Account.LookUp(userModel.Email!, _databaseConnection);
            if (account != null)
            {
                return RedirectToAction("Signup", SignUpUserModel.ActionState.DuplicateUserName);
            }

            account = new Account()
            {
                EmailAddress = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
            };
            
            PasswordHasher<Account> hasher = new PasswordHasher<Account>();
            account.HashedPassword = hasher.HashPassword(account, userModel.Password);

            account.SaveNew(_databaseConnection);
            
            HttpContext.Session.SetString("AuthenticatedUser", userModel.Email!);
            HttpContext.Session.SetString("AuthenticatedUserFriendly", account.FirstName!);
            return Redirect("/Home/Index");
        }

        [Route("Account/SignIn")]
        public IActionResult SignIn()
        {
            return View(new SignInModel());
        }

        [Route("Account/SignIn")]
        [HttpPost]
        public IActionResult SignIn(SignInModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Account? account = Account.LookUp(model.Email, _databaseConnection);
            if (account == null)
            {
                model.IsValid = false;
                return View(model);
            }

            PasswordHasher<Account> hasher = new PasswordHasher<Account>();
            var result = hasher.VerifyHashedPassword(account, account.HashedPassword, model.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                model.IsValid = false;
                return View(model);
            }
            
            HttpContext.Session.SetString("AuthenticatedUser", account.EmailAddress!);
            HttpContext.Session.SetString("AuthenticatedUserFriendly", account.FirstName!);
            return LocalRedirect("/Home/Index");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("AuthenticatedUser");
            HttpContext.Session.Remove("Flowchart");
            return LocalRedirect("/");
        }
    }
}

