using Microsoft.AspNetCore.Mvc;

namespace ShopApp.Controllers
{
    public class HangHoaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
