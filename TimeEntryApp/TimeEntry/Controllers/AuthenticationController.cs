﻿using DataAccessLayer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjectLayer.Models;
using DataAccessLayer;
using BusinessLogic;

namespace TimeEntry.Controllers
{
    public class AuthenticationController : Controller
    {
        //private readonly AppDbContext _db;
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AccountBL _accountBL;

        public AuthenticationController(AccountBL acccount)
        {         
            _accountBL = acccount;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountBL.CheckUser(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountBL.CreateUser(model);


                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Authentication");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
            }
            return View(model);
        }

       
    }
}

