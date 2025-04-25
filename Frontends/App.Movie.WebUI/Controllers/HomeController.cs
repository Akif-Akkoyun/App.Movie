using Microsoft.AspNetCore.Mvc;

namespace App.Movie.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
