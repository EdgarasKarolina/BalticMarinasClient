using BalticMarinasClient.ApiClient;
using Microsoft.AspNetCore.Mvc;

namespace BalticMarinasClient.Controllers
{
    public class SellBuyController : Controller
    {
        SellBuyClient sellBuyClient = new SellBuyClient();

        public IActionResult Index()
        {
            var items = sellBuyClient.GetAllSoldItems().Result;
            ViewBag.ItemsList = items;
            return View();
        }
    }
}