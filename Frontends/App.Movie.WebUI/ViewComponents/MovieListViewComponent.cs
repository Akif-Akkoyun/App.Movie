using App.Movie.Dto.Dtos.MovieDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace App.Movie.WebUI.ViewComponents
{
    public class MovieListViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MovieListViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7050/list");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
