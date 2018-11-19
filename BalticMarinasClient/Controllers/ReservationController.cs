using BalticMarinasClient.ApiClient;
using Microsoft.AspNetCore.Mvc;

namespace BalticMarinasClient.Controllers
{
    public class ReservationController : Controller
    {
        BookMarinaClient eventClient = new BookMarinaClient();
        EmailClient emailClient = new EmailClient();

        public IActionResult Reserve(int berthId, int customerId, string checkIn, string checkOut)
        {
            eventClient.CreateReservation(berthId, customerId, checkIn, checkOut);
            emailClient.SendConfirmationEmail("Succes", "edgarasvilija@gmail.com");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult PersonalInformation(int berthId, int customerId, string checkIn, string checkOut)
        {
            ViewBag.BerthId = berthId;
            ViewBag.CustomerId = customerId;
            ViewBag.CheckIn = checkIn;
            ViewBag.CheckOut = checkOut;
            return View();
        }

        public IActionResult Payment(int berthId, int customerId, string checkIn, string checkOut)
        {
            ViewBag.BerthId = berthId;
            ViewBag.CustomerId = customerId;
            ViewBag.CheckIn = checkIn;
            ViewBag.CheckOut = checkOut;
            return View();
        }
    }
}