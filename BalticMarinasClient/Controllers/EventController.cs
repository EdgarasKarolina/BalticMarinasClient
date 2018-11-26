using BalticMarinasClient.ApiClient;
using BalticMarinasClient.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Delete(int? id)
        {
            eventClient.DeleteEventById(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateEvent(string title, string location, string period, string description)
        {
            Event newEvent = new Event() { Title = title, Location = location, Period = period, Description = description };
            eventClient.CreateEvent(newEvent);
            return RedirectToAction("Index", "Home");
        }
    }
}