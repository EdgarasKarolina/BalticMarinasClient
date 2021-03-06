﻿using BalticMarinasClient.ApiClient;
using BalticMarinasClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace BalticMarinasClient.Controllers
{
    public class UserController : Controller
    {
        UserClient userClient = new UserClient();

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([Bind("UserName", "UserPassword", "FirstName", "LastName", "Email", "PhoneNumber", "Country")] User user)
        {
            if(ModelState.IsValid)
            {
                userClient.Register(user);
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(string userName, string userPassword)
        {
            int ifUserValid = userClient.AuthenticateUser(userName, userPassword).Result;
            
            if(ifUserValid > 0)
            {
                int userId = Convert.ToInt32(userClient.GetUserIdEmailIsAdmin(userName, userPassword).Result[0]);
                string email = userClient.GetUserIdEmailIsAdmin(userName, userPassword).Result[1].ToString();
                int isAdmin = Convert.ToInt32(userClient.GetUserIdEmailIsAdmin(userName, userPassword).Result[2]);

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, userName));
                if(isAdmin == 0)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "User"));
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }
                claims.Add(new Claim("UserId", userId.ToString()));
                claims.Add(new Claim("Email", email));

                var identity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.
                        AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var props = new AuthenticationProperties();
                props.IsPersistent = true;

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.
                        AuthenticationScheme,
                            principal, props).Wait();

                return RedirectToAction("Index", "Home");
            }

            else { return RedirectToAction("Index", "Home"); }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LoginOrRegister()
        {
            return View();
        }
    }
}