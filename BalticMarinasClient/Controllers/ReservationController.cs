using BalticMarinasClient.ApiClient;
using BalticMarinasClient.Models;
using BalticMarinasClient.Utilities;
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

        public IActionResult PersonalInformation(int berthId, string checkIn, string checkOut)
        {
            bool isLoggedIn = HttpContext.User.Identity.IsAuthenticated;

            if(HttpContext.User.Identity.IsAuthenticated == true)
            {
                int customerId = Int32.Parse(User.FindFirst("UserId").Value);
                string email = User.FindFirst("Email").Value;

                Reservation reservation = new Reservation() { BerthId = berthId, CustomerId = customerId, CheckIn = checkIn, CheckOut = checkOut };
                bookmarinaClient.CreateReservation(reservation);

                ViewBag.BerthId = berthId;
                ViewBag.CheckIn = checkIn;
                ViewBag.CheckOut = checkOut;
                ViewBag.Email = email;

                return View();
            }
            else
            {
                return RedirectToAction("LoginOrRegister", "User");
            }
        }

        [Authorize(Roles = "User")]
        public IActionResult Payment(int berthId, string checkIn, string checkOut, string email)
        {
            int customerId = Int32.Parse(User.FindFirst("UserId").Value);
            var reservationId = bookmarinaClient.GetReservationId(berthId, customerId, checkIn, checkOut).Result;
            bookmarinaClient.DeleteNotPaidReservation(reservationId);

           
            ViewBag.BerthId = berthId;
            ViewBag.CheckIn = checkIn;
            ViewBag.CheckOut = checkOut;
            ViewBag.Email = email;
            ViewBag.ReservationId = reservationId;
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult Reserve(int berthId, string checkIn, string checkOut, string email, int reservationId)
        {
            bookmarinaClient.UpdateReservation(reservationId);

            var count = bookmarinaClient.GetIfReservationExists(reservationId).Result;

            if (count > 0)
            {
                emailClient.SendConfirmationEmail(Constants.ConfirmedEmailBody, email);
                return RedirectToAction("Confirmation", "Reservation");
            }

            else
            {
                emailClient.SendConfirmationEmail(Constants.FailedEmailBody, email);
                return RedirectToAction("Failed", "Reservation");
            }
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        public IActionResult Failed()
        {
            return View();
        }
    }
}