﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Account;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Web.Models;
using StoreOfBuild.Web.ViewsModels;

namespace StoreOfBuild.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthentication _authentication;
        public AccountController(IAuthentication authenticatio)
        {
            _authentication = authenticatio;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authentication.Authenticate(model.Email, model.Password);
            if (result)
                return Redirect("/");
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
        }
        
    }
}
