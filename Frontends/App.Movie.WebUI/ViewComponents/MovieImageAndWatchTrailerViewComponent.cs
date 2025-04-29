using Microsoft.AspNetCore.Mvc;

namespace App.Movie.WebUI.ViewComponents
{
    public class MovieImageAndWatchTrailerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
