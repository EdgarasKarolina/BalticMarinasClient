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
            return View();
        }
    }
}