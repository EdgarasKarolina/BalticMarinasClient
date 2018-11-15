using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalticMarinasClient.ApiClient;
using Microsoft.AspNetCore.Mvc;

namespace BalticMarinasClient.Controllers
{
    public class ReservationController : Controller
    {
        BookMarinaClient eventClient = new BookMarinaClient();

        public IActionResult Reserve(int berthId, int customerId, string checkIn, string checkOut)
        {
            eventClient.CreateReservation(berthId, customerId, checkIn, checkOut);
            return RedirectToAction("Index", "Home");
        }
    }
}