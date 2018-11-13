using System;
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

        //[HttpDelete, ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            eventClient.DeleteEventById(id);
            return RedirectToAction("Index");
            //return View();
        }
    }
}