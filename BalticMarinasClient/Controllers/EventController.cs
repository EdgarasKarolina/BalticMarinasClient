﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalticMarinasClient.ApiClient;
using Microsoft.AspNetCore.Mvc;

namespace BalticMarinasClient.Controllers
{
    public class EventController : Controller
    {
        EventClient eventClient = new EventClient();

        public IActionResult Index()
        {
            var data = eventClient.GetAllRoles().Result;
            return View();
        }
    }
}