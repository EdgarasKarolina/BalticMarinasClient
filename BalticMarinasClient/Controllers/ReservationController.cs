using BalticMarinasClient.ApiClient;
using BalticMarinasClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BalticMarinasClient.Controllers
{
    public class ReservationController : Controller
    {
        BookMarinaClient eventClient = new BookMarinaClient();
        EmailClient emailClient = new EmailClient();

        [Authorize(Roles = "User")]
        public IActionResult Reserve(int berthId, string checkIn, string checkOut)
        {
            int customerId = Int32.Parse(User.FindFirst("UserId").Value);

            Reservation reservation = new Reservation() { BerthId = berthId, CustomerId = customerId, CheckIn = checkIn, CheckOut = checkOut };
            eventClient.CreateReservation(reservation);
            emailClient.SendConfirmationEmail("Succes", "edgarasvilija@gmail.com");
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "User")]
        public IActionResult PersonalInformation(int berthId, string checkIn, string checkOut)
        {
            ViewBag.BerthId = berthId;
            ViewBag.CheckIn = checkIn;
            ViewBag.CheckOut = checkOut;
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult Payment(int berthId, string checkIn, string checkOut)
        {
            ViewBag.BerthId = berthId;
            ViewBag.CheckIn = checkIn;
            ViewBag.CheckOut = checkOut;
            return View();
        }
    }
}