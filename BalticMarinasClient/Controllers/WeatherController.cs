using BalticMarinasClient.ApiClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalticMarinasClient.Controllers
{
    public class WeatherController : Controller
    {
        WeatherClient eventClient = new WeatherClient();

        [Authorize]
        public IActionResult Index()
        {
            //added code
            string userName = HttpContext.User.Identity.Name;

            bool isUser = false;

            isUser = HttpContext.User.IsInRole("User");


            var weathers = eventClient.GetAllWeather().Result;
            ViewBag.WeatherList = weathers;
            return View();
        }

    }
}