﻿using BalticMarinasClient.ApiClient;
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