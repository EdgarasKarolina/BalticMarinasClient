using BalticMarinasClient.ApiClient;
using BalticMarinasClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalticMarinasClient.Controllers
{
    public class MarinaController : Controller
    {
        BookMarinaClient bookMarinaClient = new BookMarinaClient();

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(string marinaName, string phone, string email, double depth, string cityName, string country, string zipCodeNumber, int totalBerths, int isShower, int isToilet, int isInternet)
        {
            Marina marina = new Marina() { MarinaName = marinaName, Phone = phone, Email = email, Depth = depth, CityName = cityName, Country = country, ZipCodeNumber = zipCodeNumber, TotalBerths = totalBerths, IsShower = isShower, IsToilet = isToilet, IsInternet = isInternet };
            bookMarinaClient.CreateMarina(marina);
            return RedirectToAction("Index", "Marina");
        }

        public IActionResult Index()
        {
            var marinas = bookMarinaClient.GetAllMarinas().Result;
            ViewBag.MarinasList = marinas;
            return View();
        }

        public IActionResult Details(int? id)
        {
            var marinas = bookMarinaClient.GetMarinaById(id).Result;
            var items = bookMarinaClient.GetAllCommentsByMarinaId(id).Result;
            ViewBag.ItemsList = items;
            ViewBag.MarinasList = marinas;
            return View();
        }

        public IActionResult ByCountry(string country = "", string checkIn = "", string checkOut = "")
        {
            var marinas = bookMarinaClient.GetMarinasByCountry(country).Result;
            ViewBag.MarinasList = marinas;
            ViewBag.CheckIn = checkIn;
            ViewBag.CheckOut = checkOut;
            return View();
        }
    }
}