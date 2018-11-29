using BalticMarinasClient.ApiClient;
using BalticMarinasClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalticMarinasClient.Controllers
{
    public class SellBuyController : Controller
    {
        SellBuyClient sellBuyClient = new SellBuyClient();

        public IActionResult Index()
        {
            var items = sellBuyClient.GetAllSoldItems().Result;
            ViewBag.ItemsList = items;
            return View();
        }

        public IActionResult Details(int? id)
        {
            var soldItem = sellBuyClient.GetSoldItemById(id).Result;
            ViewBag.Item = soldItem;
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Create(string title, string category, decimal price, string madeYear, string description)
        {
            SoldItem soldItem = new SoldItem() { Title = title, Category = category, Price = price, MadeYear = madeYear, Description = description, UserId = 1 };
            sellBuyClient.CreateSoldItem(soldItem);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            sellBuyClient.DeleteSoldItemById(id);
            return RedirectToAction("Index");
        }
    }
}