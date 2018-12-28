using BalticMarinasClient.ApiClient;
using BalticMarinasClient.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BalticMarinasClient.Controllers
{
    public class CommentController : Controller
    {
        BookMarinaClient bookmarinaClient = new BookMarinaClient();
        UserClient userClient = new UserClient();

        public IActionResult Create(int? marinaId)
        {
            ViewBag.MarinaId = marinaId;
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Body", "MarinaId")] Comment comment)
        {
            DateTime today = DateTime.Today;
            int userId = Int32.Parse(User.FindFirst("UserId").Value);
            comment.UserName = userClient.GetUserName(userId).Result;
            comment.TimePlaced = today;
            if (ModelState.IsValid)
            {
                bookmarinaClient.CreateComment(comment);
                return RedirectToAction("Index", "Home");
            }
            return View(comment);
        }
    }
}