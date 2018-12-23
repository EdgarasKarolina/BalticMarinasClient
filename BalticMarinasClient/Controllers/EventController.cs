using BalticMarinasClient.ApiClient;
using BalticMarinasClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BalticMarinasClient.Controllers
{
    public class EventController : Controller
    {
        EventClient eventClient = new EventClient();

        public IActionResult Index()
        {
            var events = eventClient.GetAllEvents().Result;
            ViewBag.EventsList = events;
            return View();
        }

        public IActionResult Details(int? id)
        {
            var events = eventClient.GetEventById(id).Result;
            ViewBag.EventsList = events;
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult IndexUser()
        {
            int userId = Int32.Parse(User.FindFirst("UserId").Value);

            var items = eventClient.GetAllEventsByUserId(userId).Result;
            ViewBag.ItemsList = items;
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            eventClient.DeleteEventById(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(string title, string location, string period, string description)
        {
            Event newEvent = new Event() { Title = title, Location = location, Period = period, Description = description, UserId = userId };
            eventClient.CreateEvent(newEvent);
            return RedirectToAction("Index", "Home");
        }
    }
}