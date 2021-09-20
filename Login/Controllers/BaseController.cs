using DNTCaptcha.Core;
using Login.Data;
using Login.Models;
using Login.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Controllers
{
    public class BaseController : Controller
    {
        private readonly MyDbContext _db;
        private readonly UserManager<Application> _user;
        private readonly SignInManager<Application> _signIn;

        public BaseController(MyDbContext db, UserManager<Application> user, SignInManager<Application> signIn)
        {
            _db = db;
            _user = user;
            _signIn = signIn;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateDNTCaptcha(
            ErrorMessage = "Please Enter Valid Captcha",
            CaptchaGeneratorLanguage = Language.English,
            CaptchaGeneratorDisplayMode = DisplayMode.ShowDigits)]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

            if (ModelState.IsValid)
            {
                var user = await _user.FindByEmailAsync(loginViewModel.Email);
                if (user != null)
                {
                    var result =
                        await _signIn.PasswordSignInAsync
                        (user.Email, loginViewModel.Password,
                            loginViewModel.RememberMe, true);

                    if (result.Succeeded)
                    {
                        //  HttpContext.Session.SetString("user", user.UserName);
                        return RedirectToAction("Index", "Session");
                    }

                }
            }
            ModelState.AddModelError("", "Invalid login");
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Application
                {
                    UserName = model.Name,
                    Email = model.Email,
                    EmailConfirmed = true

                };

                var userObj = await _user.FindByEmailAsync(model.Email);
                if (userObj == null)
                {
                    var result = await _user.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        //await _user.AddToRoleAsync(user, "Customer");

                        return RedirectToAction("Index", "Home");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }

            }


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signIn.SignOutAsync();
            return RedirectToAction("Login", "Base");
        }
    }
}
