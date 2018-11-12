using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalticMarinasClient.ApiClient;
using Microsoft.AspNetCore.Mvc;

namespace BalticMarinasClient.Controllers
{
    public class MarinaController : Controller
    {
        BookMarinaClient bookMarinaClient = new BookMarinaClient();

        public IActionResult Index()
        {
            var marinas = bookMarinaClient.GetAllMarinas().Result;
            ViewBag.MarinasList = marinas;
            return View();
        }

        public IActionResult Details(int? id)
        {
            var marinas = bookMarinaClient.GetMarinaById(id).Result;
            ViewBag.MarinasList = marinas;
            return View();
        }
    }
}