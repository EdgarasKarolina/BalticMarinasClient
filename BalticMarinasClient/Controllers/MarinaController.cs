using BalticMarinasClient.ApiClient;
using BalticMarinasClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace BalticMarinasClient.Controllers
{
    public class MarinaController : Controller
    {
        BookMarinaClient bookMarinaClient = new BookMarinaClient();

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(string marinaName, string phone, string email, double depth, string cityName, string country, string zipCodeNumber, int totalBerths, int isShower, int isToilet, int isInternet, int isPharmacy, int isElectricity, int isRepairing, int isStore, int isTelephone, int isHotel, int isCafeteria, string description)
        {
            Marina marina = new Marina() { MarinaName = marinaName, Phone = phone, Email = email, Depth = depth, CityName = cityName, Country = country, ZipCodeNumber = zipCodeNumber, TotalBerths = totalBerths, IsShower = isShower, IsToilet = isToilet, IsInternet = isInternet, IsPharmacy = isPharmacy, IsElectricity = isElectricity, IsRepairing = isRepairing, IsStore = isStore, IsTelephone = isTelephone, IsHotel = isHotel, IsCafeteria = isCafeteria, Description = description };
            bookMarinaClient.CreateMarina(marina);
            return RedirectToAction("Index", "Marina");
        }

        public IActionResult Index()
        {
            var marinas = bookMarinaClient.GetAllMarinas().Result;
            ViewBag.MarinasList = marinas;
            return View();
        }

        public IActionResult Details(int? id)
        {
            var marinas = bookMarinaClient.GetMarinaById(id).Result;
            var comments = bookMarinaClient.GetAllCommentsByMarinaId(id).Result;
            ViewBag.Comments = comments;
            ViewBag.MarinasList = marinas;
            return View();
        }

        public IActionResult ByCountry(string country = "", string checkIn = "", string checkOut = "")
        {
            var marinas = bookMarinaClient.GetMarinasByCountry(country).Result;
            ViewBag.MarinasList = marinas;
            ViewBag.CheckIn = checkIn;
            ViewBag.CheckOut = checkOut;
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? marinaId)
        {
            bookMarinaClient.DeleteMarinaById(marinaId);
            return RedirectToAction("Index", "Home");
        }

        //[Authorize(Roles = "Admin")]
        //[HttpPost]
        //public IActionResult UploadImages(List<IFormFile> files, string checkIn)
        //{
        //    foreach (var file in files)
        //    {
        //        if (file.Length > 0)
        //        {
        //            using (var ms = new MemoryStream())
        //            {
        //                file.CopyTo(ms);
        //                var fileBytes = ms.ToArray();
        //                string s = Convert.ToBase64String(fileBytes);
        //            }
        //        }
        //    }
        //        return RedirectToAction("Index", "Marina");
        //}
    }
}