using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BalticMarinasClient.Models;
using Microsoft.Extensions.Options;
using BalticMarinasClient.Utilities;
using BalticMarinasClient.ApiClient;

namespace BalticMarinasClient.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IOptions<ApplicationSettings> appSettings;

        EventClient eventClient = new EventClient();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
