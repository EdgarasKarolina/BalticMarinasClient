using BalticMarinasClient.ApiClient;
using BalticMarinasClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BalticMarinasClient.Controllers
{
    public class ReservationController : Controller
    {
        BookMarinaClient bookmarinaClient = new BookMarinaClient();
        EmailClient emailClient = new EmailClient();

        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            int customerId = Int32.Parse(User.FindFirst("UserId").Value);

            var items = bookmarinaClient.GetAllReservationsByCustomerId(customerId).Result;
            ViewBag.ItemsList = items;
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult Reserve(int berthId, string checkIn, string checkOut)
        {
            int customerId = Int32.Parse(User.FindFirst("UserId").Value);
            string email = User.FindFirst("Email").Value;

            Reservation reservation = new Reservation() { BerthId = berthId, CustomerId = customerId, CheckIn = checkIn, CheckOut = checkOut };
            bookmarinaClient.CreateReservation(reservation);
            emailClient.SendConfirmationEmail("Succes", email);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "User")]
        public IActionResult PersonalInformation(int berthId, string checkIn, string checkOut)
        {
            string email = User.FindFirst("Email").Value;
            ViewBag.BerthId = berthId;
            ViewBag.CheckIn = checkIn;
            ViewBag.CheckOut = checkOut;
            ViewBag.Email = email;
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