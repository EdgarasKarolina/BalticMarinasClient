using BalticMarinasClient.ApiClient;
using BalticMarinasClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace BalticMarinasClient.Controllers
{
    public class UserController : Controller
    {
        UserClient userClient = new UserClient();

        public IActionResult RegistrationForm()
        {
            return View();
        }

        public IActionResult CreateUser(string userName, string userPassword, string firstName, string lastName, string email, string phoneNumber, string country, int isAdmin)
        {
            User user = new User() { UserName = userName, UserPassword = userPassword, FirstName = firstName, LastName = lastName, Email = email, PhoneNumber = phoneNumber, Country = country, IsAdmin = isAdmin};
            userClient.CreateUser(user);
            return RedirectToAction("Index", "Home");
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
                int userId = userClient.GetUserId(userName, userPassword).Result;

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, userName));
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserId", userId.ToString()));

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
    }
}