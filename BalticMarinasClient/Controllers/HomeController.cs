using BalticMarinasClient.ApiClient;
using BalticMarinasClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics;

namespace BalticMarinasClient.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IOptions<ApplicationSettings> appSettings;

        EventClient eventClient = new EventClient();

        public IActionResult Index()
        {
            List<SelectListItem> Locations = new List<SelectListItem>();
            Locations.Add(new SelectListItem() { Text = "Select Location", Value = "Select Location" });
            Locations.Add(new SelectListItem() { Text = "Lithuania", Value = "Lithuania" });
            Locations.Add(new SelectListItem() { Text = "Latvia", Value = "Latvia" });
            Locations.Add(new SelectListItem() { Text = "Estonia", Value = "Estonia" });

            ViewBag.Locations = new SelectList(Locations, "Value", "Text");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
