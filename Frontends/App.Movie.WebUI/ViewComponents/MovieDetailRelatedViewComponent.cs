using Microsoft.AspNetCore.Mvc;

namespace App.Movie.WebUI.ViewComponents
{
    public class MovieDetailRelatedViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
