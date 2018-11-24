using BalticMarinasClient.ApiClient;
using Microsoft.AspNetCore.Mvc;

namespace BalticMarinasClient.Controllers
{
    public class UserController : Controller
    {
        UserClient userClient = new UserClient();
        public IActionResult Index()
        {
            return View();
        }
    }
}