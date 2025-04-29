using Microsoft.AspNetCore.Mvc;

namespace App.Movie.WebUI.ViewComponents
{
    public class MovieRateViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
