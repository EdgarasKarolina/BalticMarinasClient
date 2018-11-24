using BalticMarinasClient.ApiClient;
using BalticMarinasClient.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}