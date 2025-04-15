using Microsoft.AspNetCore.Mvc;

namespace App.Movie.WebUI.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult List()
        {
            ViewBag.v1= "Film Listesi";
            ViewBag.v2 = "Ana Sayfa";
            ViewBag.v3 = "Tüm Filmler";
            return View();
        }
    }
}
