using BalticMarinasClient.ApiClient;
using BalticMarinasClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalticMarinasClient.Controllers
{
    public class BerthController : Controller
    {
        BookMarinaClient bookMarinaClient = new BookMarinaClient();

        [Authorize(Roles = "Admin")]
        public IActionResult Create(int marinaId)
        {
            ViewBag.MarinaId = marinaId;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(int marinaId, double price)
        {
            Berth berth = new Berth() { MarinaId = marinaId, Price = price };
            bookMarinaClient.CreateBerth(berth);
            return RedirectToAction("Index", "Marina");
        }

        public IActionResult Index(int? marinaId)
        {
            var berths = bookMarinaClient.GetBerthsByMarinaId(marinaId).Result;
            ViewBag.BerthsList = berths;
            ViewBag.MarinaId = marinaId;
            return View();
        }

        public IActionResult Available(int? marinaId, string checkIn, string checkOut)
        {
            var berths = bookMarinaClient.GetAvailableBerthsByMarina(marinaId, checkIn, checkOut).Result;
            ViewBag.BerthsList = berths;
            ViewBag.CheckIn = checkIn;
            ViewBag.CheckOut = checkOut;
            return View();
        }

        public IActionResult Details(int? marinaId, int? berthId)
        {
            var berths = bookMarinaClient.GetBerthByMarinaIdAndBerthId(marinaId, berthId).Result;
            ViewBag.BerthsList = berths;
            ViewBag.BerthId = berthId;
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? berthId)
        {
            bookMarinaClient.DeleteBerthById(berthId);
            return RedirectToAction("Index", "Home");
        }
    }
}