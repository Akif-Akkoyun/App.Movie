using Microsoft.AspNetCore.Mvc;

namespace App.Movie.WebUI.ViewComponents
{
    public class MovieOverviewViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
