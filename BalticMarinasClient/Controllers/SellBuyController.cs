using BalticMarinasClient.ApiClient;
using BalticMarinasClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult IndexUser()
        {
            int userId = Int32.Parse(User.FindFirst("UserId").Value);

            var items = sellBuyClient.GetAllSoldItemsByUserId(userId).Result;
            ViewBag.ItemsList = items;
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
            int userId = Int32.Parse(User.FindFirst("UserId").Value);

            SoldItem soldItem = new SoldItem() { Title = title, Category = category, Price = price, MadeYear = madeYear, Description = description, UserId = userId };
            sellBuyClient.CreateSoldItem(soldItem);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin, User")]
        public IActionResult Delete(int? id)
        {
            sellBuyClient.DeleteSoldItemById(id);
            return RedirectToAction("Index");
        }
    }
}