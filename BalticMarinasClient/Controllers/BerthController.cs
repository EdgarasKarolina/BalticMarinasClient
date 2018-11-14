﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalticMarinasClient.ApiClient;
using Microsoft.AspNetCore.Mvc;

namespace BalticMarinasClient.Controllers
{
    public class BerthController : Controller
    {
        BookMarinaClient bookMarinaClient = new BookMarinaClient();

        public IActionResult Index(int? id)
        {
            var berths = bookMarinaClient.GetBerthsByMarinaId(id).Result;
            ViewBag.BerthsList = berths;
            return View();
        }

        //public IActionResult Available(int? marinaId, string checkIn, string checkOut)
        public IActionResult Available(int? marinaId)
        {
            var berths = bookMarinaClient.GetAvailableBerthsByMarina(marinaId, "2019-10-16", "2019-10-20").Result;
            ViewBag.BerthsList = berths;
            return View();
        }

        public IActionResult Details(int? marinaId, int? berthId)
        {
            var berths = bookMarinaClient.GetBerthByMarinaIdAndBerthId(marinaId, berthId).Result;
            ViewBag.BerthsList = berths;
            return View();
        }
    }
}