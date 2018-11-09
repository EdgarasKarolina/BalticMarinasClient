using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalticMarinasClient.ApiClient;
using BalticMarinasClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace BalticMarinasClient.Controllers
{
    public class WeatherController : Controller
    {
        WeatherClient eventClient = new WeatherClient();

        public IActionResult Index()
        {
            var weathers = eventClient.GetAllWeather().Result;
            ViewBag.WeatherList = weathers;
            return View();
        }

    }
}