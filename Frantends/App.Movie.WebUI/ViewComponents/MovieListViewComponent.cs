using Microsoft.AspNetCore.Mvc;

namespace App.Movie.WebUI.ViewComponents
{
    public class MovieListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
